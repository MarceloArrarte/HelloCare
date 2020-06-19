Public Class FrmMenuPrincipal
    Private Sub btnIngresoSintoma_Click(sender As Object, e As EventArgs) Handles btnIngresoSintoma.Click
        Dim frm As New FrmIngresoSintoma
        frm.Show()
        Me.Close()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim frm As New FrmLogin
        frm.Show()
        Me.Close()
    End Sub
End Class