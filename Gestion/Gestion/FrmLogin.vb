﻿Imports System.ComponentModel
Imports System.Globalization
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

                Case ResultadosLogin.ContrasenaIncorrecta, ResultadosLogin.PersonaNoExiste
                    MostrarMensaje(MsgBoxStyle.Critical, "La cédula y/o contraseña ingresada no son correctas." & vbNewLine & "Verifique los datos y reintente.", "Error", "The entered ID card and/or password are not correct" & vbNewLine & "Verify your credentials and retry.", "Error")

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
                        MostrarMensaje(MsgBoxStyle.Exclamation, "Su usuario no fue creado. Tenga en cuenta que no podrá acceder al servicio HelloCare hasta que tenga su usuario personal.", "Aviso", "Your user was not created. Keep in mind you won't be able to use HelloCare until you have your personal user.", "Warning")
                        administrativoLogeado = Nothing
                    End If
            End Select
        Catch ex As Exception
            MostrarMensaje(MsgBoxStyle.Critical, ex.Message, "Error", ex.Message, "Error")
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

    Private Sub txtCedula_MouseClick(sender As Object, e As MouseEventArgs) Handles txtCedula.MouseClick
        txtCedula.Clear()
    End Sub

    Private Sub txtContrasena_TextChanged(sender As Object, e As EventArgs) Handles txtContrasena.TextChanged
        If Not txtContrasena.UseSystemPasswordChar Then
            txtContrasena.Clear()
        End If
        txtContrasena.UseSystemPasswordChar = True
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        Dim nombreIdioma As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                idiomaSeleccionado = Idiomas.Ingles
                nombreIdioma = "en"
            Case Idiomas.Ingles
                idiomaSeleccionado = Idiomas.Espanol
                nombreIdioma = "es"
        End Select

        Dim crmIdioma As New ComponentResourceManager(GetType(FrmLogin))
        For Each c As Control In Me.Controls
            crmIdioma.ApplyResources(c, c.Name, New CultureInfo(nombreIdioma))
        Next
    End Sub
End Class