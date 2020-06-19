Imports System.CodeDom
Imports CapaLogica

Public Class FrmListadoSintomas
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        FrmAltaSintomas.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnVolver.Click

        FrmMenuPrincipal.Show()
        Me.Hide()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If tblSintomas.SelectedRows.Count = 0 Then
                Throw New Exception("Seleccione al menos una fila para eliminar el/los síntoma(s).")
            End If

            For Each r As DataGridViewRow In tblSintomas.SelectedRows
                CapaLogica.EliminarSintoma(r.Cells(0).Value)
                EliminarAsociacionSintoma(CType(r.Cells(0).Value, Sintoma))
            Next
                MostrarSintomas()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        Try
            If tblSintomas.SelectedRows.Count <> 1 Then
                Throw New Exception("Seleccione una sola fila para ver los detalles del síntoma.")
            End If

            Dim sintoma As Sintoma = tblSintomas.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmVerSintomas(sintoma)
            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnImportar.Click

    End Sub

    Private Sub tblPatologias_Load(sender As Object, e As EventArgs) Handles MyBase.Activated
        MostrarSintomas()
    End Sub

    Private Sub MostrarSintomas()
        tblSintomas.Rows.Clear()
        For Each sintoma As Sintoma In BuscarSintomas("", True).ToArray
            tblSintomas.Rows.Add(sintoma, sintoma.Nombre, sintoma.Descripcion, sintoma.Urgencia, sintoma.Recomendaciones)
        Next
        tblSintomas.ClearSelection()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If tblSintomas.SelectedRows.Count <> 1 Then
            MsgBox("Seleccione una sola fila para modificar el síntoma correspondiente.")
        Else
            Dim sintoma As CapaLogica.Sintoma = tblSintomas.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmModificacionSintomas(sintoma)
            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        End If
    End Sub
End Class
