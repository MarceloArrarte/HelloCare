Imports System.ComponentModel
Imports System.Globalization
Imports CapaLogica
Imports Clases

Public Class FrmNuevoDiagnostico
    Private consulta As DiagnosticoPrimarioConConsulta
    Public diagnosticoRealizado As DiagnosticoDiferencial

    Public Sub New(consultaEnCurso As DiagnosticoPrimarioConConsulta)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        consulta = consultaEnCurso
    End Sub

    Private Sub FrmNuevoDiagnostico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each enfermedad As Enfermedad In CargarTodasLasEnfermedades()
            tblEnfermedades.Rows.Add(enfermedad)
        Next
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        For Each r As DataGridViewRow In tblEnfermedades.Rows
            If r.Cells(0).Value.ToString.ToLower Like ("*" & txtBuscar.Text & "*").ToLower Then
                r.Visible = True
            Else
                r.Visible = False
            End If
        Next
    End Sub

    Private Sub btnEnviarDiagnostico_Click(sender As Object, e As EventArgs) Handles btnEnviarDiagnostico.Click
        If tblEnfermedades.SelectedRows.Count = 1 Then
            Dim enfermedadDiagnosticada As Enfermedad = tblEnfermedades.SelectedRows(0).Cells(0).Value
            diagnosticoRealizado = CrearDiagnosticoDiferencial(consulta, enfermedadDiagnosticada, txtConductaASeguir.Text)
            Me.DialogResult = DialogResult.OK
            MostrarMensaje(MsgBoxStyle.Information, "Diagnóstico enviado con éxito.", "", "Diagnosis has been successfully sent.", "")
            Me.Close()
        Else
            MostrarMensaje(MsgBoxStyle.Critical, "Seleccione una sola enfermedad para realizar el diagnóstico.", "", "Select a single illness to make a diagnosis.", "")
        End If
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        Dim nombreIdioma As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                idiomaSeleccionado = Idiomas.Ingles
                nombreIdioma = "en"
            Case Idiomas.Ingles
                idiomaSeleccionado = Idiomas.Espanol
                nombreIdioma = "es"
        End Select

        Dim crmIdioma As New ComponentResourceManager(GetType(FrmNuevoDiagnostico))
        For Each c As Control In Me.Controls
            crmIdioma.ApplyResources(c, c.Name, New CultureInfo(nombreIdioma))
        Next
    End Sub
End Class