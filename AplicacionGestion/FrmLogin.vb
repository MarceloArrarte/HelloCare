Public Class FrmLogin
    Private Sub frmAdministrativo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

   

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ci As String = TextBox2.Text

        Dim contrasena As String = TextBox1.Text
        If CapaLogica.Usuario_Administrativo.Autenticar(ci, contrasena) Then
            FrmMenuPrincipal.Show()
            Me.Hide()
        Else
            MsgBox("Contraseña incorrecta")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox1.UseSystemPasswordChar = False
        Else
            TextBox1.UseSystemPasswordChar = True

        End If
    End Sub
End Class