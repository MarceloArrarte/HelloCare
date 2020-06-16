Public Class FrmLogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ci As String = txtPaciente.Text
        Dim contrasena As String = txtContrasena.Text
        If CapaLogica.Usuario_Paciente.Autenticar(ci, contrasena) Then
            FrmMenuPrincipalPaciente.Show()
            Me.Hide()
        Else
            MsgBox("Contraseña incorrecta")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            txtContrasena.UseSystemPasswordChar = False
        Else
            txtContrasena.UseSystemPasswordChar = True
        End If
    End Sub
End Class