Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim appGestion As New AplicacionGestion.FrmLogin
        Dim appPacientes As New AplicacionPacientes.FrmLogin
        appGestion.Show()
        appPacientes.Show()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Hide()
    End Sub
End Class
