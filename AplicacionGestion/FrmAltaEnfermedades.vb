Imports CapaLogica

Public Class FrmAltaEnfermedades
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        FrmListadoEnfermedades.Show()
        Me.Hide()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If txtNombre.Text = "" Then
                Throw New Exception("El nombre de la enfermedad no puede estar vacio")
            End If
            If txtGravedad.Text = "" Then
                Throw New Exception("La gravedad de la enfermedad no puede estar vacia")
            End If


            Dim enfermedad As New Enfermedad(txtNombre.Text, txtRecomendacionesSintoma.Text, Integer.Parse(txtGravedad.Text), txtDescripcion.Text)
            CapaLogica.Principal.IngresarEnfermedad(enfermedad)
            MsgBox("Enfermedad agregada con éxito.")
            Me.Close()
            'For Each r As DataGridViewRow In tblEnfermedades.SelectedRows
            '    CapaLogica.EliminarEnfermedad(r.Cells(0).Value)
            '    EliminarAsociacionSintoma(CType(r.Cells(0).Value, Enfermedad))
            'Next
            'MostrarEnfermedades()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub FrmAltaEnfermedades_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
