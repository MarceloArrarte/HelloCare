Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Forms
Imports CapaLogica
Imports Clases

Public Class FrmContrasenaOlvidada
    Private Sub btnEnviarCodigo_Click(sender As Object, e As EventArgs) Handles btnEnviarCodigo.Click
        If AutenticarUsuarioPaciente(txtCedula.Text, ".") = ResultadosLogin.PersonaNoExiste Then
            MostrarMensaje(MsgBoxStyle.Critical, "No se han encontrado datos registrados para un paciente con esta cédula.", "Error", "No registered data was found for this ID card.", "Error")
        Else
            EnviarCorreoRestauracionContrasena(CargarPacientePorCI(txtCedula.Text))
            MostrarMensaje(MsgBoxStyle.Information, "Se ha enviado un correo electrónico a su casilla con pasos para restaurar su contraseña. No cierre esta ventana.", "", "An e-mail with steps for restoring your password has been sent to you. Don't close this window.", "")
            txtCedula.Enabled = False
            btnEnviarCodigo.Enabled = False
            lblCodigo.Visible = True
            txtCodigo.Visible = True
            btnConfirmar.Visible = True
        End If
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        EliminarUsuarioConCodigo(txtCedula.Text, TiposUsuario.Paciente, txtCodigo.Text)
        MostrarMensaje(MsgBoxStyle.Information, "Se ha eliminado tu contraseña exitosamente. Por favor, inicia sesión utilizando únicamente tu cédula.", "", "Your password has been successfully deleted. Please sign in using only your ID card.", "")
        Me.Close()
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs)
        Dim nombreIdioma As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                idiomaSeleccionado = Idiomas.Ingles
                nombreIdioma = "en"
            Case Idiomas.Ingles
                idiomaSeleccionado = Idiomas.Espanol
                nombreIdioma = "es"
        End Select

        Dim crmIdioma As New ComponentResourceManager(GetType(FrmContrasenaOlvidada))
        For Each c As Control In Me.Controls
            crmIdioma.ApplyResources(c, c.Name, New CultureInfo(nombreIdioma))
        Next
    End Sub
End Class