Imports CapaLogica
Imports Clases
Public Class FrmListadoAdministrativos
    Private Sub FrmListadoAdministrativos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarAdministrativos()
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        If tblAdministrativo.SelectedRows.Count = 1 Then
            Dim Administrativo As Administrativo = tblAdministrativo.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmVerAdministrativo(Administrativo)
            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        Else
            MsgBox("Seleccione una sola fila para ver los detalles del administrativo.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If tblAdministrativo.SelectedRows.Count = 1 Then
            Dim Administrativo As Administrativo = tblAdministrativo.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmModificacionAdministrativo(Administrativo)
            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        Else
            MsgBox("Seleccione una sola fila para modificar los detalles del administrativo.", MsgBoxStyle.Critical, "Error")
        End If
        ActualizarAdministrativos()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim frm As New FrmAltaAdministrativo
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
        ActualizarAdministrativos()
    End Sub

    Private Sub ActualizarAdministrativos()
        tblAdministrativo.Rows.Clear()
        For Each Administrativo As Administrativo In CargarTodosLosAdministrativos()
            tblAdministrativo.Rows.Add(Administrativo, Administrativo.CI, Administrativo.Nombre, Administrativo.Apellido,
                                       Administrativo.Correo, Administrativo.Localidad, Administrativo.EsEncargado)
        Next
        tblAdministrativo.ClearSelection()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If tblAdministrativo.SelectedRows.Count > 0 Then
            If MsgBox("¿Confirma que desea eliminar este administrativo?" & vbNewLine &
                      "Estos cambios no podrán deshacerse.", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                For Each r As DataGridViewRow In tblAdministrativo.SelectedRows
                    EliminarAdministrativo(r.Cells(0).Value)
                Next
                ActualizarAdministrativos()
            End If
        Else
            MsgBox("Seleccione al menos una fila para eliminar el o los administrativos.")
        End If
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        TraducirAplicacion()
    End Sub
End Class