Imports System.ComponentModel
Imports System.Globalization
Imports CapaLogica
Imports Clases

Public Class FrmListadoEnfermedades
    ' Cada vez que el formulario recibe el foco, actualiza las enfermedades del sistema
    Private Sub FrmListadoEnfermedades_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        ActualizarEnfermedades()
    End Sub

    Private Sub ActualizarEnfermedades()
        tblEnfermedades.Rows.Clear()
        For Each e As Enfermedad In CargarTodasLasEnfermedades()
            tblEnfermedades.Rows.Add(e, e.Nombre, e.Descripcion, e.Gravedad, e.Recomendaciones)
        Next
        tblEnfermedades.ClearSelection()
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        exploradorArchivos.FileName = ""
        exploradorArchivos.ShowDialog()
        Dim nombreArchivo As String = exploradorArchivos.FileName

        If nombreArchivo = "" Then
            MostrarMensaje(MsgBoxStyle.Exclamation, "No se seleccionó ningún archivo CSV para importar.", "", "No CSV file was selected.", "")
            Exit Sub
        End If

        If Not nombreArchivo.EndsWith(".csv") Then
            MostrarMensaje(MsgBoxStyle.Critical, "El archivo seleccionado no es de formato CSV.", "", "The selected file does not have the required CSV format.", "")
            Exit Sub
        End If

        ImportarEnfermedades(nombreArchivo)
        MostrarMensaje(MsgBoxStyle.Information, "¡Importación finalizada!", "Tarea completada", "Import complete!", "Task complete")
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
            MostrarMensaje(MsgBoxStyle.Critical, "Seleccione una sola fila para ver los detalles de la enfermedad.", "Error", "Select a single row to see details of the illness.", "Error")
        End If
    End Sub

    ' Abre un formulario que permite al usuario ingresar una nueva patología
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim frm As New FrmAltaEnfermedades
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
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
            MostrarMensaje(MsgBoxStyle.Critical, "Seleccione una sola fila para modificar una enfermedad.", "Error", "Select a single row to modify an illness.", "Error")
        End If
    End Sub

    ' Permite eliminar una o varias de las enfermedades del sistema, luego de recibir confirmación del usuario
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If tblEnfermedades.SelectedRows.Count > 0 Then
            If MostrarMensaje(MsgBoxStyle.YesNo, "¿Confirma que desea eliminar esta(s) enfermedad(es)?" & vbNewLine & "Estos cambios no podrán deshacerse.", "Advertencia", "Are you sure you wish to delete this illness(es)?" & vbNewLine & "These changes cannot be undone.", "Warning") = DialogResult.Yes Then
                For Each r As DataGridViewRow In tblEnfermedades.SelectedRows
                    EliminarEnfermedad(r.Cells(0).Value)
                Next
                ActualizarEnfermedades()
            End If
        Else
            MostrarMensaje(MsgBoxStyle.Information, "Seleccione al menos una fila para eliminar la(s) enfermedad(es).", "", "Select at least one row to delete the illness(es).", "")
        End If
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        TraducirAplicacion()
    End Sub

    Private Sub txtBuscarEnfermedad_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarEnfermedad.TextChanged
        For Each r As DataGridViewRow In tblEnfermedades.Rows
            If r.Cells(0).Value.ToString.ToLower Like ("*" & txtBuscarEnfermedad.Text & "*").ToLower Then
                r.Visible = True
            Else
                If Not r.Selected Then
                    r.Visible = False
                End If
            End If
        Next
    End Sub
End Class
