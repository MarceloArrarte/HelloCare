Imports CapaLogica

Public Class FrmAltaSintomas
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        FrmListadoSintomas.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim sintoma As New CapaLogica.Sintoma(txtNombreSintoma.Text, txtInfoSintoma.Text, txtRecomendacionSintoma.Text, txtUrgencia.Text)
        CapaLogica.Principal.IngresarSintoma(sintoma)
        Me.Close()
    End Sub

    Private Sub FrmAltaSintomas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each enfermedad As Enfermedad In BuscarEnfermedades("", True)
            tblPatologias.Rows.Add(enfermedad, False, enfermedad.Nombre, "")
        Next
    End Sub
End Class
