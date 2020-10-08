Imports CapaLogica
Imports Clases

Public Class FrmContrasenaOlvidada
    Private Sub btnEnviarCodigo_Click(sender As Object, e As EventArgs) Handles btnEnviarCodigo.Click
        If AutenticarUsuarioMedico(txtCedula.Text, ".") = ResultadosLogin.PersonaNoExiste Then
            MsgBox("No se han encontrado datos registrados para un médico con esta cédula.", MsgBoxStyle.Critical, "Error")
        Else
            EnviarCorreoRestauracionContrasena(CargarMedicoPorCI(txtCedula.Text))
            MsgBox("Se ha enviado un correo electrónico a su casilla con pasos para restaurar su contraseña. No cierre esta ventana.", MsgBoxStyle.Information)
            txtCedula.Enabled = False
            btnEnviarCodigo.Enabled = False
            lblCodigo.Visible = True
            txtCodigo.Visible = True
            btnConfirmar.Visible = True
        End If
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        EliminarUsuarioConCodigo(txtCedula.Text, TiposUsuario.Paciente, txtCodigo.Text)
        MsgBox("Se ha eliminado tu contraseña exitosamente. Por favor, inicia sesión utilizando únicamente tu cédula.", MsgBoxStyle.Information)
        Me.Close()
    End Sub
End Class