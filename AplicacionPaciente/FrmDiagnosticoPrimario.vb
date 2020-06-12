Public Class FrmDiagnosticoPrimario
    Private Sub DiagnosticoPrimario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        FrmMenuPrincipalPaciente.Show()
        Me.Hide()
    End Sub
End Class