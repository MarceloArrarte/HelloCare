Public Class FrmAltaEnfermedades
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmListadoEnfermedades.Show()
        Me.Hide()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim enfermedad As New CapaLogica.Enfermedad()
        enfermedad.Descripcion = txtDescripcionSintoma.Text
        enfermedad.Nombre = txtNombreEnfermedad.Text
        enfermedad.Recomendaciones = txtRecomendacionesSintoma.Text
        enfermedad.Gravedad = Integer.Parse(txtGravedadSintoma.Text)
        CapaLogica.Principal.IngresarEnfermedad(enfermedad)
    End Sub

    Private Sub FrmAltaEnfermedades_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
