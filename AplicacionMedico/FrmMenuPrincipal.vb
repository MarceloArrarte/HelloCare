Public Class FrmMenuPrincipal
    ' Esta bandera se implementa para indicar al evento FormClosing 
    ' si el formulario se cierra para salir al login, o para abrir la siguiente ventana
    Private cierraSesion As Boolean = True

    Private Sub btnPeticiones_Click(sender As Object, e As EventArgs) Handles btnPeticiones.Click
        Dim frm As New FrmPeticionesChat
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnHistorialChat_Click(sender As Object, e As EventArgs) Handles btnHistorialChat.Click
        Dim frm As New FrmHistorialChats
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnHistorialPacientes_Click(sender As Object, e As EventArgs) Handles btnHistorialPacientes.Click
        Dim frm As New FrmHistorialPacientes
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMenuPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If cierraSesion Then
            ' Si el usuario quiere cerrar sesión, pide confirmación
            If MsgBox("¿Confirma que desea cerrar su sesión?", MsgBoxStyle.YesNo, "Cerrar sesión") = MsgBoxResult.Yes Then
                Dim frm As New FrmLogin
                frm.Show()
            Else
                e.Cancel = True
            End If
        End If
    End Sub
End Class