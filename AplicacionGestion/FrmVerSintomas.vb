Imports CapaLogica

Public Class FrmVerSintomas
    Sub New(sintoma As Sintoma)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txtNombre.Text = sintoma.Nombre
        txtDescripcion.Text = sintoma.Descripcion
        txtRecomendaciones.Text = sintoma.Recomendaciones
        txtUrgencia.Text = sintoma.Urgencia

        Dim asociacionesConEnfermedades As List(Of AsociacionSintoma) = BuscarAsociacionesSintomas(sintoma)
        Dim enfermedadesAsociadas As New List(Of Enfermedad)
        For i = 0 To asociacionesConEnfermedades.Count - 1
            enfermedadesAsociadas.Add(BuscarEnfermedades(asociacionesConEnfermedades(i).NombreEnfermedad, True).Single)
        Next

        For i = 0 To enfermedadesAsociadas.Count - 1
            Dim valoresFila As New List(Of Object)
            valoresFila.Add(enfermedadesAsociadas(i))
            valoresFila.Add(enfermedadesAsociadas(i).Nombre)
            valoresFila.Add(enfermedadesAsociadas(i).Descripcion)
            valoresFila.Add(asociacionesConEnfermedades(i).Frecuencia & "%")
            tblPatologias.Rows.Add(valoresFila.ToArray)
        Next
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub FrmVerSintomas_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.ActiveControl = Nothing
        tblPatologias.ClearSelection()
    End Sub
End Class
