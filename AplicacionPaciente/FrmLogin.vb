Imports CapaLogica
Imports Clases

Public Class FrmLogin
    ' Veifica que el usuario y la contraseña sean correctos, en caso contrario muestra un error
    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim ci As String = txtCedula.Text
        Dim contrasena As String = txtContrasena.Text
        Try
            Select Case AutenticarUsuarioPaciente(ci, contrasena)
                Case ResultadosLogin.OK
                    Dim frm As New FrmMenuPrincipal
                    frm.Show()
                    Me.Close()

                Case ResultadosLogin.Error
                    MsgBox("La cédula y/o contraseña ingresada no son correctas." & vbNewLine & "Verifique los datos y reintente.")

                Case ResultadosLogin.SinUsuario
                    ' Acá tiene que ir a la ventana de registro
            End Select
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