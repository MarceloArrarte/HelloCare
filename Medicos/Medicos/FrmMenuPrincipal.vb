Imports CapaLogica

Public Class FrmMenuPrincipal
    Private Sub FrmMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblLogeado.Text = lblLogeado.Text.Replace("#", medicoLogeado.ToString)
    End Sub

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
        If MsgBox("¿Confirma que desea cerrar su sesión?", MsgBoxStyle.YesNo, "Cerrar sesión") = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub
End Class