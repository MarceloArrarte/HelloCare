Public Class FrmMenuPrincipal
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnABMSintomas.Click

        FrmListadoSintomas.Show()
        Me.Hide()



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnABMEnfermedades.Click
        FrmListadoEnfermedades.Show()
        Me.Hide()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class
