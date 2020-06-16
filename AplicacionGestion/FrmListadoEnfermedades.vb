Public Class FrmListadoEnfermedades
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FrmMenuPrincipal.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmVerEnfermedades.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        FrmAltaEnfermedades.Show()
        Me.Hide()

    End Sub

    Private Sub tblPatologia_Load(sender As Object, e As EventArgs) Handles MyBase.Activated
        tblPatologias.Rows.Clear()
        For Each enfermedad As CapaLogica.Enfermedad In CapaLogica.Principal.BuscarEnfermedades("", True).ToArray
            tblPatologias.Rows.Add(enfermedad.Nombre, enfermedad.Descripcion, enfermedad.Gravedad, enfermedad.Recomendaciones)
        Next

    End Sub
End Class
