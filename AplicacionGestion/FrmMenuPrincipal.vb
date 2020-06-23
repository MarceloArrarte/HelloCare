Public Class FrmMenuPrincipal
    Private Sub btnABMSintomas_Click(sender As Object, e As EventArgs) Handles btnABMSintomas.Click
        Dim frm As New FrmListadoSintomas
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnABMEnfermedades_Click(sender As Object, e As EventArgs) Handles btnABMEnfermedades.Click
        Dim frm As New FrmListadoEnfermedades
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim frm As New FrmLogin
        frm.Show()
        Me.Close()
    End Sub

    ' Pide confirmación al usuario antes de cerrar sesión
    Private Sub FrmMenuPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox("¿Confirma que desea cerrar su sesión?", MsgBoxStyle.YesNo, "Cerrar sesión") = MsgBoxResult.Yes Then
            Dim frm As New FrmLogin
            frm.Show()
        Else
            e.Cancel = True
        End If
    End Sub
End Class
