Public Class FrmLogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim ci As String = txtCedula.Text

        Dim contrasena As String = txtContrasena.Text
        If CapaLogica.Usuario_Administrativo.Autenticar(ci, contrasena) Then
            Dim frm As New FrmMenuPrincipal
            frm.Show()
            Me.Close()
        Else
            MsgBox("Contraseña incorrecta")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarContrasena.CheckedChanged
        If chkMostrarContrasena.Checked Then
            txtContrasena.UseSystemPasswordChar = False
        Else
            txtContrasena.UseSystemPasswordChar = True

        End If
    End Sub
End Class