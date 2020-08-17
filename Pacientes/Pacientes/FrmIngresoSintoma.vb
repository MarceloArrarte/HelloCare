Imports System.Windows.Forms
Imports CapaLogica
Imports Clases

Public Class FrmIngresoSintoma
    ' Esta bandera se implementa para indicar al evento FormClosing 
    ' si el formulario se cierra para volver sin guardar o habiendo ingresado datos
    'Private requiereConfirmacionSalida As Boolean = True

    ' Carga ambos DataGridView con los síntomas disponibles, y oculta todos en tblSeleccionados
    Private Sub FrmIngresoSintoma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each s As Sintoma In CargarTodosLosSintomas()
            tblDisponibles.Rows.Add(s, s.Nombre)
            tblSeleccionados.Rows.Add(s, s.Nombre)
            tblSeleccionados.Rows(tblSeleccionados.Rows.Count - 1).Visible = False
        Next
    End Sub

    ' Seleccionar síntomas
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        For Each r As DataGridViewRow In tblDisponibles.SelectedRows
            tblSeleccionados.Rows.Add(DuplicarFila(r))
            tblDisponibles.Rows.Remove(r)
        Next
        DeseleccionarTablas()
    End Sub

    ' Deseleccionar síntomas
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        For Each r As DataGridViewRow In tblSeleccionados.SelectedRows
            tblDisponibles.Rows.Add(DuplicarFila(r))
            tblSeleccionados.Rows.Remove(r)
        Next
        DeseleccionarTablas()
    End Sub

    ' Filtra las enfermedades que el usuario puede elegir según su nombre
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        For Each r As DataGridViewRow In tblDisponibles.Rows
            If r.Cells(1).Value.ToString.ToLower Like ("*" & txtBuscar.Text & "*").ToLower Then
                r.Visible = True
            Else
                r.Visible = False
            End If
        Next
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        'Si la lista de sintomas seleccionados esta vacía manda un mensaje de error
        If tblSeleccionados.Rows.Count() > 0 Then
            Dim sintomasSeleccionados As New List(Of Sintoma)
            For Each r As DataGridViewRow In tblSeleccionados.Rows
                sintomasSeleccionados.Add(r.Cells(0).Value)
            Next
            'Abre la ventana de diagnostico y cierra la actual
            Dim frm As New FrmDiagnosticoPrimario(sintomasSeleccionados)
            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        Else
            MsgBox("Debe ingresar al menos un síntoma para recibir un diagnóstico.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MsgBox("Advertencia: no se guardaron los cambios." & vbNewLine & "¿Confirma que desea cerrar la ventana?", MsgBoxStyle.YesNo, "Salir") =
                MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    'Private Sub FrmIngresoSintoma_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    '    If requiereConfirmacionSalida Then

    '    End If
    'End Sub

    Private Sub DeseleccionarTablas()
        tblDisponibles.ClearSelection()
        tblSeleccionados.ClearSelection()
    End Sub
End Class