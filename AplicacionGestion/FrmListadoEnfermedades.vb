Imports CapaLogica

Public Class FrmListadoEnfermedades
    ' Cada vez que el formulario recibe el foco, actualiza las enfermedades del sistema
    Private Sub FrmListadoEnfermedades_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        MostrarEnfermedades()
    End Sub

    Private Sub MostrarEnfermedades()
        tblEnfermedades.Rows.Clear()
        For Each enfermedad As Enfermedad In BuscarEnfermedades("", True).ToArray
            tblEnfermedades.Rows.Add(enfermedad, enfermedad.Nombre, enfermedad.Descripcion, enfermedad.Gravedad, enfermedad.Recomendaciones)
        Next
        tblEnfermedades.ClearSelection()
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    ' NO IMPLEMENTADO
    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        exploradorArchivos.ShowDialog()
        MsgBox(exploradorArchivos.FileName)
    End Sub

    ' Abre un formulario con los detalles de una enfermedad
    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        If tblEnfermedades.SelectedRows.Count = 1 Then
            Dim enfermedad As Enfermedad = tblEnfermedades.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmVerEnfermedades(enfermedad)
            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        Else
            MsgBox("Seleccione una sola fila para ver los detalles de la enfermedad.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    ' Abre un formulario para que el usuario pueda ingresar nuevos datos para una enfermedad ya almacenada
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If tblEnfermedades.SelectedRows.Count = 1 Then
            Dim enfermedad As Enfermedad = tblEnfermedades.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmModificacionEnfermedades(enfermedad)
            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        Else
            MsgBox("Seleccione una sola fila para modificar una enfermedad.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    ' Permite eliminar una o varias de las enfermedades del sistema, luego de recibir confirmación del usuario
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If tblEnfermedades.SelectedRows.Count = 0 Then
                Throw New Exception("Seleccione al menos una fila para eliminar la(s) enfermedad(es).")
            End If

            If MsgBox("¿Confirma que desea eliminar esta(s) enfermedad(es)?" & vbNewLine &
                      "Estos cambios no podrán deshacerse.", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                For Each r As DataGridViewRow In tblEnfermedades.SelectedRows
                    Dim enfermedad As Enfermedad = r.Cells(0).Value
                    EliminarEnfermedad(enfermedad)
                    EliminarAsociacionSintoma(enfermedad)
                Next
                MostrarEnfermedades()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ' Abre un formulario que permite al usuario ingresar una nueva patología
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim frm As New FrmAltaEnfermedades
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub
End Class
