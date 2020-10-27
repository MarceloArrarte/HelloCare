Imports CapaLogica
Imports Clases
Public Class FrmListadoMedicos
    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        If tblMedicos.SelectedRows.Count = 1 Then
            Dim Medico As Medico = tblMedicos.SelectedRows(0).Cells(0).Value

            Dim frm As New FrmVerMedicos(Medico)
            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        Else
            MsgBox("Seleccione una sola fila para ver los detalles del Medico", MsgBoxStyle.Critical, "Error")
        End If
        ActualizarMedicos()

    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If tblMedicos.SelectedRows.Count = 1 Then
            Dim Medico As Medico = tblMedicos.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmModificacionMedico(Medico)
            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        Else
            MsgBox("Seleccione una sola fila para modificar un Medico", MsgBoxStyle.Critical, "Error")
        End If
        ActualizarMedicos()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim frm As New FrmAltaMedico
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
        ActualizarMedicos()
    End Sub

    'Metodo para actualizar el datagrid con los medicos
    Private Sub ActualizarMedicos()
        tblMedicos.Rows.Clear()
        For Each Medico As Medico In CargarTodosLosMedicos()
            tblMedicos.Rows.Add(Medico, Medico.CI, Medico.Nombre, Medico.Apellido, Medico.Correo, Medico.Localidad)
        Next

        For intI = tblMedicos.Rows.Count - 1 To 0 Step -1
            For intJ = intI - 1 To 0 Step -1
                If tblMedicos.Rows(intI).Cells(1).Value = tblMedicos.Rows(intJ).Cells(1).Value Then
                    tblMedicos.Rows.RemoveAt(intI)
                    Exit For
                End If
            Next
        Next


        tblMedicos.ClearSelection()

    End Sub
    Private Sub FrmListadoMedico_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ActualizarMedicos()
    End Sub

    Private Sub FrmListadoMedicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarMedicos()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If tblMedicos.SelectedRows.Count > 0 Then
            If MsgBox("¿Confirma que desea eliminar este/os Medico/s?" & vbNewLine &
                      "Estos cambios no podrán deshacerse.", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                For Each r As DataGridViewRow In tblMedicos.SelectedRows
                    EliminarMedico(r.Cells(0).Value)
                Next
                ActualizarMedicos()
            End If
        Else
            MsgBox("Seleccione al menos una fila para eliminar el o los medicos.")
        End If
    End Sub

    Private Sub tblMedicos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblMedicos.CellContentClick

    End Sub
End Class