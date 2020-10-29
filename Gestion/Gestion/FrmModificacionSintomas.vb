Imports System.ComponentModel
Imports System.Globalization
Imports CapaLogica
Imports Clases

Public Class FrmModificacionSintomas
    ' Esta bandera se implementa para indicar al evento FormClosing 
    ' si el formulario se cierra para volver sin guardar o habiendo ingresado datos
    Private requiereConfirmacionSalida As Boolean = True

    Private sintomaAModificar As Sintoma
    Sub New(sintoma As Sintoma)
        InitializeComponent()

        ' Precarga los datos del síntoma en los campos de texto correspondientes
        txtNombre.Text = sintoma.Nombre
        txtDescripcion.Text = sintoma.Descripcion
        txtUrgencia.Text = sintoma.Urgencia
        txtRecomendaciones.Text = sintoma.Recomendaciones

        ' Precarga los datos de las enfermedades asociadas al síntoma
        For i = 0 To sintoma.Enfermedades.Count - 1
            tblAsociadas.Rows.Add(sintoma.Enfermedades(i), sintoma.Enfermedades(i).Nombre, sintoma.FrecuenciaEnfermedad(i) & "%")
        Next

        sintomaAModificar = sintoma
        For Each enfermedad As Enfermedad In CargarTodasLasEnfermedades()
            tblPatologias.Rows.Add(enfermedad, enfermedad.Nombre)
        Next
        OcultarPatologiasSeleccionadasOFiltradas()
    End Sub

    ' Actualiza el filtro de texto para ocultar patologías no coincidentes
    Private Sub txtBuscarPatologia_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarPatologia.TextChanged
        OcultarPatologiasSeleccionadasOFiltradas()
    End Sub

    ' Agrega una patología a la lista de patologías asociadas
    Private Sub btnAgregarPatologia_Click(sender As Object, e As EventArgs) Handles btnAgregarPatologia.Click
        If tblPatologias.SelectedRows.Count > 0 Then
            For Each r As DataGridViewRow In tblPatologias.SelectedRows
                tblAsociadas.Rows.Add(r.Cells(0).Value, r.Cells(1).Value, "")
            Next
            OcultarPatologiasSeleccionadasOFiltradas()
        Else
            MostrarMensaje(MsgBoxStyle.Critical, "Debe seleccionar al menos una de las patologías disponibles.", "Error", "You must select at least one of the available illnesses.", "Error")
        End If
    End Sub

    ' Quita una o varias enfermedades asociadas al síntoma
    Private Sub btnQuitarPatologia_Click(sender As Object, e As EventArgs) Handles btnQuitarPatologia.Click
        If tblAsociadas.SelectedRows.Count > 0 Then
            For Each rAsociada As DataGridViewRow In tblAsociadas.SelectedRows
                For Each rPatologia As DataGridViewRow In tblPatologias.Rows
                    If rPatologia.Cells(1).Value = rAsociada.Cells(1).Value Then
                        rPatologia.Visible = True
                    End If
                Next
                tblAsociadas.Rows.Remove(rAsociada)
            Next
            OcultarPatologiasSeleccionadasOFiltradas()
        Else
            MostrarMensaje(MsgBoxStyle.Critical, "Debe seleccionar al menos una de las patologías asociadas.", "Error", "You must select at least one of the associated illnesses.", "Error")
        End If
    End Sub

    ' De la lista de patologías existentes, oculta aquellas que ya estén seleccionadas o no coincidan con el filtro de texto
    Private Sub OcultarPatologiasSeleccionadasOFiltradas()
        ' Oculta por filtro de texto
        For Each r As DataGridViewRow In tblPatologias.Rows
            If r.Cells(1).Value.ToString.ToLower Like ("*" & txtBuscarPatologia.Text & "*").ToLower Then
                r.Visible = True
            Else
                r.Visible = False
            End If
        Next

        ' Oculta las patologías ya seleccionadas
        For Each rAsociada As DataGridViewRow In tblAsociadas.Rows
            For Each rPatologia As DataGridViewRow In tblPatologias.Rows
                If rAsociada.Cells(1).Value = rPatologia.Cells(1).Value Then
                    rPatologia.Visible = False
                End If
            Next
        Next
        DeseleccionarTablas()
    End Sub

    Private Sub DeseleccionarTablas()
        tblAsociadas.ClearSelection()
        tblPatologias.ClearSelection()
    End Sub

    ' Confirma la modificación de una enfermedad
    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try
            Dim listaEnfermedades As New List(Of Enfermedad)
            Dim listaFrecuencias As New List(Of Decimal)
            For Each r As DataGridViewRow In tblAsociadas.Rows
                listaEnfermedades.Add(CType(r.Cells(0).Value, Enfermedad))
                Try
                    listaFrecuencias.Add(r.Cells(2).Value.ToString.Replace("%", ""))
                Catch ex As Exception
                    Throw New Exception("Las frecuencias solo pueden ser valores numéricos.")
                End Try
            Next

            Dim urgenciaParseado As Integer
            If Not Integer.TryParse(txtUrgencia.Text, urgenciaParseado) Then
                Throw New Exception("La gravedad debe ser un valor numérico entero.")
            End If

            ActualizarSintoma(sintomaAModificar, txtNombre.Text, txtDescripcion.Text, txtRecomendaciones.Text, urgenciaParseado,
                              listaEnfermedades, listaFrecuencias)

            MostrarMensaje(MsgBoxStyle.Information, "Modificación realizada con éxito", "Éxito", "Symptom has been successfully modified.", "Success")
            requiereConfirmacionSalida = False
            Me.Close()
        Catch ex As Exception
            MostrarMensaje(MsgBoxStyle.Critical, ex.Message, "Error", ex.Message, "Error")
        End Try
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    ' Si intenta cerrar el formulario sin guardar cambios, solicita confirmación
    Private Sub FrmModificacionSintomas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If requiereConfirmacionSalida Then
            If MostrarMensaje(MsgBoxStyle.YesNo, "Advertencia: no se guardaron los cambios." & vbNewLine & "¿Confirma que desea cerrar la ventana?", "Salir", "Warning: no changes have been saved." & vbNewLine & "Are you sure you wish to close the window?", "Exit") = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        TraducirAplicacion()
    End Sub

    Private Sub FrmModificacionSintomas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            AbrirAyuda(TiposUsuario.Administrativo, Me)
        End If
    End Sub
End Class
