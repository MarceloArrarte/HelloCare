Imports CapaLogica

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
        Dim asociacionesConEnfermedades As List(Of AsociacionSintoma) = BuscarAsociacionesSintomas(sintoma)
        Dim enfermedadesAsociadas As New List(Of Enfermedad)
        For i = 0 To asociacionesConEnfermedades.Count - 1
            enfermedadesAsociadas.Add(BuscarEnfermedades(asociacionesConEnfermedades(i).NombreEnfermedad, True).Single)
        Next

        For i = 0 To enfermedadesAsociadas.Count - 1
            Dim valoresFila As New List(Of Object)
            valoresFila.Add(enfermedadesAsociadas(i))
            valoresFila.Add(enfermedadesAsociadas(i).Nombre)
            valoresFila.Add(asociacionesConEnfermedades(i).Frecuencia & "%")
            tblAsociadas.Rows.Add(valoresFila.ToArray)
        Next

        ' Almacena el síntoma a modificar en una variable de la clase para su uso posterior
        sintomaAModificar = sintoma
    End Sub

    ' Carga las patologías que existen en el sistema
    Private Sub FrmModificacionSintomas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each enfermedad As Enfermedad In BuscarEnfermedades("", True)
            tblPatologias.Rows.Add(enfermedad, enfermedad.Nombre)
        Next

        tblAsociadas.ClearSelection()
        tblPatologias.ClearSelection()

        OcultarPatologiasSeleccionadasOFiltradas()
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
        For Each rSeleccionado As DataGridViewRow In tblAsociadas.Rows
            For Each rPatologia As DataGridViewRow In tblPatologias.Rows
                If rSeleccionado.Cells(1).Value = rPatologia.Cells(1).Value Then
                    rPatologia.Visible = False
                End If
            Next
        Next
        tblPatologias.ClearSelection()
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
                r.Visible = False
            Next
            tblPatologias.ClearSelection()
        Else
            MsgBox("Debe seleccionar al menos una de las patologías disponibles.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    ' Quita una o varias enfermedades asociadas al síntoma
    Private Sub btnQuitarPatologia_Click(sender As Object, e As EventArgs) Handles btnQuitarPatologia.Click
        If tblAsociadas.SelectedRows.Count > 0 Then
            For i = tblAsociadas.Rows.Count - 1 To 0 Step -1
                Dim fila As DataGridViewRow = tblAsociadas.Rows(i)
                If tblAsociadas.SelectedRows.Contains(fila) Then
                    For Each r As DataGridViewRow In tblPatologias.Rows
                        If r.Cells(1).Value = fila.Cells(1).Value Then
                            r.Visible = True
                        End If
                    Next
                    tblAsociadas.Rows.Remove(fila)
                End If
            Next
            OcultarPatologiasSeleccionadasOFiltradas()
        Else
            MsgBox("Debe seleccionar al menos una de las patologías asociadas.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    ' Confirma la modificación de una enfermedad
    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try
            ' Busca el síntoma original en el sistema y lo sustituye por el nuevo
            Dim sintomaNuevo As New Sintoma(txtNombre.Text, txtDescripcion.Text, txtRecomendaciones.Text, txtUrgencia.Text)
            For Each s As Sintoma In BuscarSintomas("", True)
                If s.Nombre = sintomaAModificar.Nombre Then
                    ModificarSintoma(sintomaAModificar, sintomaNuevo)
                End If
            Next

            ' Elimina todas las asociaciones al síntoma original...
            For Each asociacion As AsociacionSintoma In BuscarAsociacionesSintomas(sintomaAModificar).ToList
                EliminarAsociacionSintoma(asociacion)
            Next

            ' y las reemplaza con las asociaciones del nuevo síntoma
            For Each r As DataGridViewRow In tblAsociadas.Rows
                Dim asociacion As New AsociacionSintoma(r.Cells(1).Value, sintomaNuevo.Nombre, r.Cells(2).Value.ToString.Replace("%", ""))
                IngresarAsociacionSintoma(asociacion)
            Next
            MsgBox("Modificación realizada con éxito")
            requiereConfirmacionSalida = False
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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
