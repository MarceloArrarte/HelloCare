Imports CapaLogica
Imports Clases

Public Class FrmLogin
    ' Para esta versión inicial, se acomoda el login para permitir visualizar el de la otra aplicación
    ' En la versión final del sistema, este se centrará en la pantalla
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer = Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 50
        Dim y As Integer = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        Me.Location = New Point(x, y)
    End Sub

    ' Veifica que el usuario y la contraseña sean correctos, en caso contrario muestra un error
    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim ci As String = txtCedula.Text
        Dim contrasena As String = txtContrasena.Text
        Try
            Validaciones.Cedula(ci)
            If Usuario_Administrativo.Autenticar(ci, contrasena) Then
                Dim frm As New FrmMenuPrincipal
                frm.Show()
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    ' Permite al usuario ver su contraseña escrita en el campo de texto
    Private Sub chkMostrarContrasena_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarContrasena.CheckedChanged
        If chkMostrarContrasena.Checked Then
            txtContrasena.UseSystemPasswordChar = False
        Else
            txtContrasena.UseSystemPasswordChar = True
        End If
    End Sub
End Class