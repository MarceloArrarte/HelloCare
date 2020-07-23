Imports CapaLogica
Imports Clases

Public Class FrmDiagnosticoPrimario
    ' listaSintomasIngresados recibe la lista de síntomas seleccionados en el formulario anterior
    Sub New(listaSintomasIngresados As List(Of Sintoma))
        InitializeComponent()

        ' Muestra en pantalla los síntomas seleccionados en los cuales se basa el diagnóstico primario
        lstSintomas.Items.AddRange(listaSintomasIngresados.ToArray)

        ' Muestra las recomendaciones del sistema para tratar cada síntoma ingresado
        For Each s As Sintoma In listaSintomasIngresados
            txtRecomendaciones.Text &= "Para aliviar " & s.Nombre.ToLower & ":" & vbNewLine
            txtRecomendaciones.Text &= s.Recomendaciones & vbNewLine & vbNewLine
        Next

        Dim resultadoDiagnostico As Enfermedad = Nothing
        Dim certeza As Decimal = 0

        ' Identifica las enfermedades a las cuales los síntomas ingresados se encuentran asociados por el sistema
        For Each e As Enfermedad In BuscarEnfermedades("", True)                                ' Para cada enfermedad:
            Dim lstSintomasDeEnfermedad As New List(Of Sintoma)
            Dim lstFrecuencias As New List(Of Decimal)
            For Each a As AsociacionSintoma In BuscarAsociacionesSintomas(e)                    ' Para cada asociación de un síntoma con dicha enfermedad
                lstSintomasDeEnfermedad.Add(BuscarSintomas(a.NombreSintoma, True).Single)       ' Agrega a la lista el síntoma relacionado
            Next
            Dim cantidadSintomasExistentes As Integer = lstSintomasDeEnfermedad.Count           ' Luego, cuenta cuantos síntomas se asocian con la enfermedad
            Dim cantidadSintomasCoincidentes As Integer = 0
            For Each s As Sintoma In lstSintomasDeEnfermedad        ' Para cada síntoma que se ingresó,
                If listaSintomasIngresados.Contains(s) Then         ' verifica si pertenece a la lista de síntomas asociados a la enfermedad
                    cantidadSintomasCoincidentes += 1               ' En caso afirmativo, lo contabiliza en los síntomas coincidentes
                    lstFrecuencias.Add(ObtenerFrecuencia(e, s))     ' y busca la frecuencia de dicho síntoma para esta enfermedad
                Else
                    lstFrecuencias.Add(0)                           ' En caso de que el síntoma ingresado no pertenezca a la enfermedad, agrega 0 a frecuencias
                End If
            Next
            Dim porcentajeCoincidencia As Double = (Double.Parse(cantidadSintomasCoincidentes) /        ' Expresa en porcentaje de los síntomas ingresados
                                                    Double.Parse(cantidadSintomasExistentes)) * 100     ' cuántos se asocian con la enfermedad

            Dim porcentajeProbabilidad As Double = 0                ' Calcula la certeza del diagnóstico de una enfermedad,
            For Each frecuencia As Decimal In lstFrecuencias        ' haciendo un promedio de la frecuencia con la que los síntomas ingresados
                porcentajeProbabilidad += frecuencia                ' se presentan en un caso de esa enfermedad
            Next
            porcentajeProbabilidad /= lstFrecuencias.Count

            ' Si existe una coincidencia, aunque sea parcial,
            ' y el grado de certeza del programa es superior al mínimo especificado (podrá parametrizarse)
            ' muestra la enfermedad en pantalla, indicando
            ' la coincidencia en porcentaje y cantidad de síntomas coincidentes
            If porcentajeCoincidencia > 0 And porcentajeProbabilidad > 25 Then
                tblEnfermedadesDiagnosticadas.Rows.Add(e,
                                                       String.Format("{0}% ({1} de {2})", Math.Round(porcentajeCoincidencia), cantidadSintomasCoincidentes, cantidadSintomasExistentes),
                                                       Math.Round(porcentajeProbabilidad) & "%",
                                                       e.Nombre)

                If porcentajeProbabilidad > certeza Then        ' Si se analizaron los síntomas de una enfermedad y se halló una enfermedad
                    resultadoDiagnostico = e                    ' más probable, se muestra en el Label designado para ello
                    certeza = porcentajeProbabilidad
                End If
            End If
        Next

        ' Si ninguna enfermedad almacenada tiene una coincidencia superior al mínimo configurado (no implementado todavía),
        ' despliega el mensaje correspondiente
        If tblEnfermedadesDiagnosticadas.Rows.Count = 0 Then
            tblEnfermedadesDiagnosticadas.Rows.Add("", "", "", "Ninguna enfermedad almacenada coincide con los síntomas seleccionados.")
            tblEnfermedadesDiagnosticadas.Rows(0).Height *= 2       ' Permite visualizar dicho mensaje mejor
            lblResultado.Visible = False                            ' Si no se determinó un resultado fiable, oculta el Label
        Else
            lblResultado.Text = "De acuerdo con los síntomas ingresados, la enfermedad que más probablemente padece es:" & vbNewLine &
                                resultadoDiagnostico.Nombre & ", con una certeza del " & Math.Round(certeza) & "%."
        End If
    End Sub

    ' Deselecciona lo que haya quedado seleccionado por defecto
    Private Sub DiagnosticoPrimario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tblEnfermedadesDiagnosticadas.ClearSelection()
        Me.ActiveControl = lblTitulo
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim frm As New FrmMenuPrincipal
        frm.Show()
        Me.Close()
    End Sub
End Class