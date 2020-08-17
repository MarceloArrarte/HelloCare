Imports CapaLogica
Imports Clases

Public Class FrmListadoSintomas
    ' Cada vez que el formulario recibe el foco, actualiza los síntomas del sistema
    Private Sub tblPatologias_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        MostrarSintomas()
    End Sub

    Private Sub MostrarSintomas()
        tblSintomas.Rows.Clear()
        For Each sintoma As Sintoma In CargarTodosLosSintomas()
            tblSintomas.Rows.Add(sintoma, sintoma.Nombre, sintoma.Descripcion, sintoma.Urgencia, sintoma.Recomendaciones)
        Next
        tblSintomas.ClearSelection()
    End Sub

    ' NO IMPLEMENTADO
    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        exploradorArchivos.ShowDialog()
        MsgBox(exploradorArchivos.FileName)
    End Sub

    ' Abre un formulario con los detalles de un síntoma
    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        If tblSintomas.SelectedRows.Count = 1 Then
            Dim sintoma As Sintoma = tblSintomas.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmVerSintomas(sintoma)
            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        Else
            MsgBox("Seleccione una sola fila para ver los detalles del síntoma.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    ' Abre un formulario que permite al usuario ingresar un nuevo síntoma
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim frm As New FrmAltaSintomas
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub

    ' Abre un formulario para que el usuario pueda ingresar nuevos datos para un síntoma ya almacenado
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If tblSintomas.SelectedRows.Count = 1 Then
            Dim sintoma As Sintoma = tblSintomas.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmModificacionSintomas(sintoma)
            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        Else
            MsgBox("Seleccione una sola fila para modificar el síntoma correspondiente.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    ' Permite eliminar uno o varios de los síntomas del sistema, luego de recibir confirmación del usuario
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If tblSintomas.SelectedRows.Count > 0 Then
            If MsgBox("¿Confirma que desea eliminar este/os síntoma(s)?" & vbNewLine &
                      "Estos cambios no podrán deshacerse.", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                For Each r As DataGridViewRow In tblSintomas.SelectedRows
                    EliminarSintoma(r.Cells(0).Value)
                Next
                MostrarSintomas()
            End If
        Else
            MsgBox("Seleccione al menos una fila para eliminar el/los síntoma(s).")
        End If
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub
End Class
