Public Class FrmAltaEnfermedades
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        FrmListadoEnfermedades.Show()
        Me.Hide()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        
        Dim enfermedad As New CapaLogica.Enfermedad(txtDescripcion.Text, txtNombre.Text, txtRecomendacionesSintoma.Text, Integer.Parse(txtGravedad.Text))
        CapaLogica.Principal.IngresarEnfermedad(enfermedad)
        MsgBox("Enfermedad agregada con éxito.")
        Me.Close()
    End Sub

    Private Sub FrmAltaEnfermedades_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
