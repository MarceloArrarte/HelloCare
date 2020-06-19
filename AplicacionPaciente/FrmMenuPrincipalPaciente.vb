Public Class FrmMenuPrincipalPaciente
    Private Sub btnIngresoSintoma_Click(sender As Object, e As EventArgs) Handles btnIngresoSintoma.Click
        Dim frm As New FrmIngresoSintoma
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub
End Class