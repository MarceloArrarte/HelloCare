Public Class FrmMenuPrincipalPaciente
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub btnIngresoSintoma_Click(sender As Object, e As EventArgs) Handles btnIngresoSintoma.Click
        FrmIngresoSintoma.Show()
        Me.Hide()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

    End Sub
End Class