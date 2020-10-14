Imports CapaLogica
Imports Clases

Public Class FrmLogin
    ' Veifica que el usuario y la contraseña sean correctos, en caso contrario muestra un error
    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim ci As String = txtCedula.Text
        Dim contrasena As String = txtContrasena.Text
        Try
            Select Case AutenticarUsuarioAdministrativo(ci, contrasena)
                Case ResultadosLogin.OK
                    Dim frm As New FrmMenuPrincipal
                    Me.Hide()
                    frm.ShowDialog()
                    txtCedula.Clear()
                    txtContrasena.Clear()
                    Me.Show()

                Case ResultadosLogin.ContrasenaIncorrecta Or ResultadosLogin.PersonaNoExiste
                    MsgBox("La cédula y/o contraseña ingresada no son correctas." & vbNewLine & "Verifique los datos y reintente.")

                Case ResultadosLogin.SinUsuario
                    Dim frmReg As New FrmRegistro
                    Me.Hide()
                    Dim resultado As DialogResult = frmReg.ShowDialog()
                    Me.Show()
                    If resultado = DialogResult.OK Then
                        Dim frmMenu As New FrmMenuPrincipal
                        Me.Hide()
                        frmMenu.ShowDialog()
                        txtCedula.Clear()
                        txtContrasena.Clear()
                        Me.Show()
                    Else
                        MsgBox("Su usuario no fue creado. Tenga en cuenta que no podrá acceder al servicio HelloCare hasta que tenga su usuario personal.", MsgBoxStyle.Exclamation)
                        administrativoLogeado = Nothing
                    End If
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

    Private Sub btnContrasenaOlvidada_Click(sender As Object, e As EventArgs) Handles btnContrasenaOlvidada.Click
        Dim frm As New FrmContrasenaOlvidada
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub
End Class