Imports CapaLogica

Public Class FrmListadoEnfermedades
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        FrmMenuPrincipal.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        Try
            If tblEnfermedades.SelectedRows.Count = 0 Then
                Throw New Exception("Seleccione al menos una fila para ver los detalles de la enfermedad")

            End If
            If tblEnfermedades.SelectedRows.Count <> 1 Then
                Throw New Exception("Seleccione una sola fila para ver los detalles de la enfermedad.")
            End If

            Dim enfermedad As CapaLogica.Enfermedad = tblEnfermedades.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmVerEnfermedades(enfermedad)
            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnImportar.Click

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If tblEnfermedades.SelectedRows.Count = 0 Then
                Throw New Exception("Seleccione al menos una fila para eliminar la(s) enfermedad(es).")
            End If

            For Each r As DataGridViewRow In tblEnfermedades.SelectedRows
                CapaLogica.EliminarEnfermedad(r.Cells(0).Value)
                EliminarAsociacionSintoma(CType(r.Cells(0).Value, Enfermedad))
            Next
            MostrarEnfermedades()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click


        FAltaEnfermedades.Show()
        Me.Hide()

    End Sub

    Private Sub tblPatologia_Load(sender As Object, e As EventArgs) Handles MyBase.Activated
        MostrarEnfermedades()
    End Sub

    Private Sub MostrarEnfermedades()
        tblEnfermedades.Rows.Clear()
        For Each enfermedad As CapaLogica.Enfermedad In CapaLogica.Principal.BuscarEnfermedades("", True).ToArray
            tblEnfermedades.Rows.Add(enfermedad, enfermedad.Nombre, enfermedad.Descripcion, enfermedad.Gravedad, enfermedad.Recomendaciones)
        Next
        tblEnfermedades.ClearSelection()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click


        Dim enfermedad As CapaLogica.Enfermedad = tblEnfermedades.SelectedRows(0).Cells(0).Value
        Dim frm As New FrmModificacionEnfermedades(enfermedad)
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub
End Class
