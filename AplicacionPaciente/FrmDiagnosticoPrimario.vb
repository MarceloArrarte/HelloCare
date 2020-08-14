Imports System.Windows.Forms
Imports CapaLogica
Imports Clases

Public Class FrmDiagnosticoPrimario
    Private nuevoDiagnostico As Boolean
    Private diagnosticoMostrado As DiagnosticoPrimario

    ' listaSintomasIngresados recibe la lista de síntomas seleccionados en el formulario anterior
    Sub New(sintomasIngresados As List(Of Sintoma))
        InitializeComponent()

        ' Muestra en pantalla los síntomas seleccionados en los cuales se basa el diagnóstico primario
        lstSintomas.Items.AddRange(sintomasIngresados.ToArray)

        ' Muestra las recomendaciones del sistema para tratar cada síntoma ingresado
        For Each s As Sintoma In sintomasIngresados
            txtRecomendaciones.Text &= "Para aliviar " & s.Nombre.ToLower & ":" & vbNewLine
            txtRecomendaciones.Text &= s.Recomendaciones & vbNewLine & vbNewLine
        Next

        Dim enfermedadesDiagnosticadas As EnfermedadesDiagnosticadas = Nothing
        Dim certeza As Decimal = Nothing
        Dim resultadoDiagnostico As Enfermedad = RealizarDiagnostico(sintomasIngresados, enfermedadesDiagnosticadas, certeza)

        For i = 0 To enfermedadesDiagnosticadas.Items.Count - 1
            tblEnfermedadesDiagnosticadas.Rows.Add(enfermedadesDiagnosticadas.Items(i), enfermedadesDiagnosticadas.Probabilidad(i) & "%",
                                                   enfermedadesDiagnosticadas.Item(i).Nombre)
        Next

        If enfermedadesDiagnosticadas.Items.Count = 0 Then
            tblEnfermedadesDiagnosticadas.Rows.Add("", "", "Ninguna enfermedad del sistema coincide con los síntomas seleccionados.")
            tblEnfermedadesDiagnosticadas.Rows(0).Height *= 2       ' Permite visualizar dicho mensaje mejor
            lblResultado.Visible = False                            ' Si no se determinó un resultado fiable, oculta el Label
        Else
            lblResultado.Text = "De acuerdo con los síntomas ingresados, la enfermedad que más probablemente padece es:" & vbNewLine &
                                resultadoDiagnostico.Nombre & ", con una certeza del " & Math.Round(certeza, 1) & "%."
        End If

        Dim diagnosticoRealizado As DiagnosticoPrimario = AlmacenarDiagnosticoPrimario(pacienteLogeado, sintomasIngresados, enfermedadesDiagnosticadas)
        nuevoDiagnostico = True
        diagnosticoMostrado = diagnosticoRealizado
    End Sub

    Public Sub New(diagnostico As DiagnosticoPrimario)
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each s As Sintoma In diagnostico.Sintomas
            lstSintomas.Items.Add(s)
        Next

        For i = 0 To diagnostico.Enfermedades.Count - 1
            tblEnfermedadesDiagnosticadas.Rows.Add(diagnostico.Enfermedades(i), diagnostico.Probabilidad(i) & "%", diagnostico.Enfermedades(i))
        Next

        lblResultado.Text = "El resultado del diagnóstico es " & diagnostico.Enfermedades(0).ToString & ", con una certeza del " &
                             Math.Round(diagnostico.Probabilidad(0), 1) & "%."

        ' Muestra las recomendaciones del sistema para tratar cada síntoma ingresado
        For Each s As Sintoma In diagnostico.Sintomas
            txtRecomendaciones.Text &= "Para aliviar " & s.Nombre.ToLower & ":" & vbNewLine
            txtRecomendaciones.Text &= s.Recomendaciones & vbNewLine & vbNewLine
        Next

        nuevoDiagnostico = False
        diagnosticoMostrado = diagnostico
    End Sub

    ' Deselecciona lo que haya quedado seleccionado por defecto
    Private Sub DiagnosticoPrimario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tblEnfermedadesDiagnosticadas.ClearSelection()
        Me.ActiveControl = lblTitulo

        If TryCast(diagnosticoMostrado, DiagnosticoPrimarioConConsulta) IsNot Nothing Then
            Dim cantidadDiagnosticosDiferenciales As Integer = ContarDiagnosticosDiferenciales(diagnosticoMostrado)
            lblDiagnosticosDiferenciales.Text = lblDiagnosticosDiferenciales.Text.Replace("#", cantidadDiagnosticosDiferenciales)
            If cantidadDiagnosticosDiferenciales > 0 Then
                btnDiagnosticosDiferenciales.Visible = True
            Else
                btnDiagnosticosDiferenciales.Visible = False
            End If
        Else
            lblDiagnosticosDiferenciales.Hide()
            btnDiagnosticosDiferenciales.Hide()
        End If
    End Sub

    Private Sub btnDiagnosticosDiferenciales_Click(sender As Object, e As EventArgs) Handles btnDiagnosticosDiferenciales.Click
        Dim frmDiferenciales As New FrmDiagnosticosDiferenciales(diagnosticoMostrado)
        Me.Hide()
        frmDiferenciales.ShowDialog()
        Me.DialogResult = DialogResult.None
        Me.Show()
    End Sub

    Private Sub btnRealizarConsulta_Click(sender As Object, e As EventArgs) Handles btnRealizarConsulta.Click
        Dim frmComentarios As FrmComentariosAdicionales
        Dim confirmacion As DialogResult = DialogResult.OK
        If TryCast(diagnosticoMostrado, DiagnosticoPrimarioConConsulta) Is Nothing Then
            frmComentarios = New FrmComentariosAdicionales
            confirmacion = frmComentarios.ShowDialog()
        End If
        If confirmacion = DialogResult.OK Then
            Dim diagnosticoConConsulta As DiagnosticoPrimarioConConsulta
            If TryCast(diagnosticoMostrado, DiagnosticoPrimarioConConsulta) Is Nothing Then
                diagnosticoConConsulta = AgregarConsultaADiagnostico(diagnosticoMostrado, frmComentarios.txtComentariosAdicionales.Text)
            Else
                diagnosticoConConsulta = diagnosticoMostrado
            End If
            Dim frmChat As New FrmChatPaciente(diagnosticoConConsulta)
            frmChat.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If nuevoDiagnostico Then
            Dim frm As New FrmHistorialDiagnosticos
            frm.Show()
            Me.Close()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub FrmDiagnosticoPrimario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub
End Class