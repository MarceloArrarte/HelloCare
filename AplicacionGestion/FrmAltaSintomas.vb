Public Class FrmAltaSintomas
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmListadoSintomas.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sintoma As New CapaLogica.Sintoma()
        sintoma.Nombre = txtNombreSintoma.Text
        sintoma.Descripcion = txtInfoSintoma.Text
        sintoma.Recomendaciones = txtRecomendacionSintoma.Text
        sintoma.Urgencia = Integer.Parse(txtUrgencia.Text)
        CapaLogica.Principal.IngresarSintoma(sintoma)
    End Sub
End Class
