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
    End Sub

    ' Carga las patologías que existen en el sistema
    Private Sub FrmModificacionSintomas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each enfermedad As Enfermedad In CargarTodasLasEnfermedades()
            tblPatologias.Rows.Add(enfermedad, enfermedad.Nombre)
        Next
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
            MsgBox("Debe seleccionar al menos una de las patologías disponibles.", MsgBoxStyle.Critical, "Error")
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
            MsgBox("Debe seleccionar al menos una de las patologías asociadas.", MsgBoxStyle.Critical, "Error")
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
                listaFrecuencias.Add(r.Cells(2).Value.ToString.Replace("%", ""))
            Next

            ActualizarSintoma(sintomaAModificar, txtNombre.Text, txtDescripcion.Text, txtRecomendaciones.Text, txtUrgencia.Text,
                              listaEnfermedades, listaFrecuencias)

            MsgBox("Modificación realizada con éxito")
            requiereConfirmacionSalida = False
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    ' Si intenta cerrar el formulario sin guardar cambios, solicita confirmación
    Private Sub FrmModificacionSintomas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If requiereConfirmacionSalida Then
            If MsgBox("Advertencia: no se guardaron los cambios." & vbNewLine & "¿Confirma que desea cerrar la ventana?", MsgBoxStyle.YesNo, "Salir") =
                MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class
