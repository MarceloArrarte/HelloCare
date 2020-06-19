Public Class FrmLogin
    Private Sub frmAdministrativo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

   

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim ci As String = txtCedula.Text

        Dim contrasena As String = txtContrasena.Text
        If CapaLogica.Usuario_Administrativo.Autenticar(ci, contrasena) Then
            FrmMenuPrincipal.Show()
            Me.Hide()
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