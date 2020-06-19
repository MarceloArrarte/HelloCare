Imports System.Windows.Forms

Public Class FrmIngresoSintoma
    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        'Si la lista de sintomas seleccionados esta vacia manda un mensaje de error
        If tblSeleccionados.Rows.Count() = 0 Then
            MsgBox("Debe ingrese un sintoma para recibir un diagnostico", MsgBoxStyle.Critical, "Error")
        Else

            'Abre la ventana de diagnostico y cierra la actual, ademas de limpiar todas las tablas utilizadas.
            Dim frm As New FrmDiagnosticoPrimario
            frm.Show()
            Me.Close()

        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim frm As New FrmMenuPrincipal
        Me.Close()
        frm.Show()
    End Sub

    'Agregar sintomas a la tabla izquierda'
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        For Each r As DataGridViewRow In tblDisponibles.SelectedRows
            tblSeleccionados.Rows.Add(r.Cells(0).Value, r.Cells(1).Value)
            tblDisponibles.Rows.Remove(r)
        Next
        tblDisponibles.ClearSelection()
        tblSeleccionados.ClearSelection()
    End Sub


    'Refrescar la lista de sintomas a seleccionar'
    Private Sub FrmIngresoSintoma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each sintoma As CapaLogica.Sintoma In CapaLogica.Principal.BuscarSintomas("", True).ToArray
            tblDisponibles.Rows.Add(sintoma, sintoma.Nombre)
        Next
    End Sub

    'Elimina sintomas previamente seleccionados'
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        For Each r As DataGridViewRow In tblSeleccionados.SelectedRows
            tblDisponibles.Rows.Add(r.Cells(0).Value, r.Cells(1).Value)
            tblSeleccionados.Rows.Remove(r)
        Next
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        For i = 0 To tblDisponibles.Rows.Count - 1
            If tblDisponibles.Rows(i).Cells(1).Value.ToString.ToLower Like ("*" & txtBuscar.Text & "*").ToLower Then
                tblDisponibles.Rows(i).Visible = True
            Else
                tblDisponibles.Rows(i).Visible = False
            End If
        Next
    End Sub
End Class