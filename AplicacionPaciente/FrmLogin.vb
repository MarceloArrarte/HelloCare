Public Class FrmLogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmMenuPrincipalPaciente.Show()
        Me.Hide()

    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class