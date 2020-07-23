Imports System.Windows.Forms
Imports CapaLogica
Imports Clases

Public Class FrmIngresoSintoma
    ' Esta bandera se implementa para indicar al evento FormClosing 
    ' si el formulario se cierra para volver sin guardar o habiendo ingresado datos
    Private requiereConfirmacionSalida As Boolean = True
    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        'Si la lista de sintomas seleccionados esta vacia manda un mensaje de error
        If tblSeleccionados.Rows.Count() = 0 Then
            MsgBox("Debe ingrese un sintoma para recibir un diagnostico", MsgBoxStyle.Critical, "Error")
        Else
            Dim sintomasSeleccionados As New List(Of Sintoma)
            For Each r As DataGridViewRow In tblSeleccionados.Rows
                sintomasSeleccionados.Add(r.Cells(0).Value)
            Next
            'Abre la ventana de diagnostico y cierra la actual, ademas de limpiar todas las tablas utilizadas.
            Dim frm As New FrmDiagnosticoPrimario(sintomasSeleccionados)
            frm.Show()
            requiereConfirmacionSalida = False
            Me.Close()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim frm As New FrmMenuPrincipal
        frm.Show()
        Me.Close()
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
        For Each sintoma As Sintoma In CapaLogica.Principal.BuscarSintomas("", True).ToArray
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

    ' Filtra las enfermedades que el usuario puede elegir según su nombre
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        For i = 0 To tblDisponibles.Rows.Count - 1
            If tblDisponibles.Rows(i).Cells(1).Value.ToString.ToLower Like ("*" & txtBuscar.Text & "*").ToLower Then
                tblDisponibles.Rows(i).Visible = True
            Else
                tblDisponibles.Rows(i).Visible = False
            End If
        Next
    End Sub

    Private Sub FrmIngresoSintoma_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If requiereConfirmacionSalida Then
            If MsgBox("Advertencia: no se guardaron los cambios." & vbNewLine & "¿Confirma que desea cerrar la ventana?", MsgBoxStyle.YesNo, "Salir") =
                MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class