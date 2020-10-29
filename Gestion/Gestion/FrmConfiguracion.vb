Imports Clases
Imports CapaLogica
Imports System.ComponentModel
Imports System.Globalization

Public Class FrmConfiguracion
    Private departamentos As List(Of Departamento)
    Private localidades As List(Of Localidad)
    Private especialidades As List(Of Especialidad)
    Private Sub FrmConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarDatosSistema()
    End Sub

    Private Sub ActualizarDatosSistema()
        grdDepartamentos.Rows.Clear()
        grdLocalidades.Rows.Clear()
        grdEspecialidades.Rows.Clear()
        cbxNuevoDepartamentoDeLocalidad.Items.Clear()


        departamentos = CargarTodosLosDepartamentos()
        localidades = CargarTodasLasLocalidades()
        especialidades = CargarTodasLasEspecialidades()

        For i = 0 To departamentos.Count - 1
            grdDepartamentos.Rows.Add(departamentos(i))
            cbxNuevoDepartamentoDeLocalidad.Items.Add(departamentos(i))
        Next
        For i = 0 To localidades.Count - 1
            grdLocalidades.Rows.Add(localidades(i))
        Next
        For i = 0 To especialidades.Count - 1
            grdEspecialidades.Rows.Add(especialidades(i))
        Next
    End Sub

    Private Sub txtBuscarDepartamento_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarDepartamento.TextChanged
        For Each fila As DataGridViewRow In grdDepartamentos.Rows
            If fila.Cells(0).Value.ToString.ToLower Like "*" & txtBuscarDepartamento.Text.ToLower & "*" Then
                fila.Visible = True
            Else
                fila.Visible = False
            End If
        Next
    End Sub

    Private Sub cbxDepartamentos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDepartamentos.SelectedIndexChanged
        For Each fila As DataGridViewRow In grdLocalidades.Rows
            If fila.Cells(0).Value.ToString.ToLower Like "*" & txtBuscarLocalidades.Text.ToLower & "*" And
                CType(fila.Cells(0).Value, Localidad).Departamento = cbxDepartamentos.SelectedItem Then

                fila.Visible = True
            Else
                fila.Visible = False
            End If
        Next
    End Sub

    Private Sub txtBuscarEspecialidad_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarEspecialidad.TextChanged
        For Each fila As DataGridViewRow In grdEspecialidades.Rows
            If fila.Cells(0).Value.ToString.ToLower Like "*" & txtBuscarEspecialidad.Text.ToLower & "*" Then
                fila.Visible = True
            Else
                fila.Visible = False
            End If
        Next
    End Sub

    Private Sub btnAgregarDepartamento_Click(sender As Object, e As EventArgs) Handles btnAgregarDepartamento.Click
        Dim nombreIngresado As String = txtAgregarDepartamento.Text.Trim
        If nombreIngresado <> "" Then
            Dim yaExiste As Boolean = False
            For Each d As Departamento In departamentos
                If nombreIngresado.ToLower = d.Nombre.ToLower Then
                    yaExiste = True
                End If
            Next
            If Not yaExiste Then
                CrearDepartamento(nombreIngresado)
            Else
                MostrarMensaje(MsgBoxStyle.Critical, "Ya existe un departamento con este nombre.", "Error", "A department with this name already exists.", "Error")
            End If
        Else
            MostrarMensaje(MsgBoxStyle.Critical, "El nombre del nuevo departamento no puede estar en blanco.", "Error", "The name of the new department cannot be left in blank.", "Error")
        End If

        ActualizarDatosSistema()
    End Sub

    Private Sub btnAgregarLocalidad_Click(sender As Object, e As EventArgs) Handles btnAgregarLocalidad.Click
        Dim nombreIngresado As String = txtAgregarLocalidad.Text.Trim
        If nombreIngresado <> "" Then
            Dim departamentoSeleccionado As Departamento = cbxDepartamentoDeNuevaLocalidad.SelectedItem
            Dim localidadesDelDepartamento As New List(Of Localidad)
            For Each l As Localidad In localidades
                If l.Departamento = departamentoSeleccionado Then
                    localidadesDelDepartamento.Add(l)
                End If
            Next

            Dim yaExiste As Boolean = False
            For Each l As Localidad In localidadesDelDepartamento
                If nombreIngresado.ToLower = l.Nombre.ToLower Then
                    yaExiste = True
                End If
            Next
            If Not yaExiste Then
                CrearLocalidad(nombreIngresado, departamentoSeleccionado)
            Else
                MostrarMensaje(MsgBoxStyle.Critical, "Ya existe una localidad en este departamento con este nombre.", "Error", "A location with this name already exists.", "Error")
            End If
        Else
            MostrarMensaje(MsgBoxStyle.Critical, "El nombre de la nueva localidad no puede estar en blanco.", "Error", "The name of the new location cannot be left in blank.", "Error")
        End If

        ActualizarDatosSistema()
    End Sub

    Private Sub btnAgregarEspecialidad_Click(sender As Object, e As EventArgs) Handles btnAgregarEspecialidad.Click
        Dim nombreIngresado As String = txtAgregarEspecialidad.Text.Trim
        If nombreIngresado <> "" Then
            Dim yaExiste As Boolean = False
            For Each especialidad As Especialidad In especialidades
                If nombreIngresado.ToLower = especialidad.Nombre.ToLower Then
                    yaExiste = True
                End If
            Next
            If Not yaExiste Then
                CrearEspecialidad(nombreIngresado)
            Else
                MostrarMensaje(MsgBoxStyle.Critical, "Ya existe una especialidad con este nombre.", "Error", "A specialty with this name already exists.", "Error")
            End If
        Else
            MostrarMensaje(MsgBoxStyle.Critical, "El nombre de la nueva especialidad no puede estar en blanco.", "Error", "The name of the new specialty cannot be left in blank.", "Error")
        End If

        ActualizarDatosSistema()
    End Sub

    Private Sub grdDepartamentos_SelectionChanged(sender As Object, e As EventArgs) Handles grdDepartamentos.SelectionChanged
        Dim departamentoSeleccionado As String = grdDepartamentos.SelectedRows(0).Cells(0).Value.ToString
        txtNombreDepartamentoAModificar.Text = departamentoSeleccionado
        txtEliminarDepartamento.Text = departamentoSeleccionado
    End Sub

    Private Sub grdLocalidades_SelectionChanged(sender As Object, e As EventArgs) Handles grdLocalidades.SelectionChanged
        Dim localidadSeleccionada As String = grdLocalidades.SelectedRows(0).Cells(0).Value.ToString
        txtNombreLocalidadAModificar.Text = localidadSeleccionada
        txtEliminarLocalidad.Text = localidadSeleccionada
        txtLocalidadParaCambiarDepartamento.Text = localidadSeleccionada
        If cbxDepartamentos.SelectedIndex <> -1 Then
            txtDepartamentoActual.Text = cbxDepartamentos.SelectedItem.ToString
        End If
    End Sub

    Private Sub grdEspecialidades_SelectionChanged(sender As Object, e As EventArgs) Handles grdEspecialidades.SelectionChanged
        Dim especialidadSeleccionada As String = grdEspecialidades.SelectedRows(0).Cells(0).Value.ToString
        txtNombreEspecialidadAModificar.Text = especialidadSeleccionada
        txtEliminarEspecialidad.Text = especialidadSeleccionada
    End Sub

    Private Sub btnModificarDepartamento_Click(sender As Object, e As EventArgs) Handles btnModificarDepartamento.Click
        Dim nombreActual As String = txtNombreDepartamentoAModificar.Text
        Dim nombreNuevo As String = txtNuevoNombreDepartamento.Text.Trim
        If nombreNuevo <> "" Then
            If nombreActual <> nombreNuevo Then
                Dim yaExiste As Boolean = False
                For Each d As Departamento In departamentos
                    If nombreNuevo.ToLower = d.Nombre.ToLower Then
                        yaExiste = True
                    End If
                Next
                If Not yaExiste Then
                    Dim departamento As Departamento = Nothing
                    For Each d As Departamento In departamentos
                        If d.Nombre = nombreActual Then
                            departamento = d
                        End If
                    Next
                    ActualizarDepartamento(departamento, nombreNuevo)
                Else
                    MostrarMensaje(MsgBoxStyle.Critical, "Ya existe un departamento con este nombre.", "Error", "A department with this name already exists.", "Error")
                End If
            Else
                MostrarMensaje(MsgBoxStyle.Information, "Se ha ingresado el mismo nombre de departamento. No se realizó ningún cambio.", "Aviso", "The same department name has been entered. No changes have been done.", "Warning")
            End If
        Else
            MostrarMensaje(MsgBoxStyle.Critical, "El nombre del nuevo departamento no puede estar en blanco.", "Error", "The name of the new department cannot be left in blank.", "Error")
        End If

        ActualizarDatosSistema()
    End Sub

    Private Sub btnModificarLocalidad_Click(sender As Object, e As EventArgs) Handles btnModificarLocalidad.Click
        Dim nombreActual As String = txtNombreLocalidadAModificar.Text
        Dim nombreNuevo As String = txtNuevoNombreLocalidad.Text.Trim
        If nombreNuevo <> "" Then
            If nombreActual <> nombreNuevo Then
                Dim departamentoSeleccionado As Departamento = cbxDepartamentoDeNuevaLocalidad.SelectedItem
                Dim localidadesDelDepartamento As New List(Of Localidad)
                For Each l As Localidad In localidades
                    If l.Departamento = departamentoSeleccionado Then
                        localidadesDelDepartamento.Add(l)
                    End If
                Next

                Dim yaExiste As Boolean = False
                For Each l As Localidad In localidadesDelDepartamento
                    If nombreNuevo.ToLower = l.Nombre.ToLower Then
                        yaExiste = True
                    End If
                Next
                If Not yaExiste Then
                    Dim localidad As Localidad = Nothing
                    For Each l As Localidad In localidades
                        If l.Nombre = nombreActual And l.Departamento = departamentoSeleccionado Then
                            localidad = l
                        End If
                    Next
                    ActualizarLocalidad(localidad, nombreNuevo, departamentoSeleccionado)
                Else
                    MostrarMensaje(MsgBoxStyle.Critical, "Ya existe una localidad en este departamento con este nombre.", "Error", "A location with this name already exists.", "Error")
                End If
            Else
                MostrarMensaje(MsgBoxStyle.Information, "Se ha ingresado el mismo nombre de localidad. No se realizó ningún cambio.", "Aviso", "The same location name has been entered. No changes have been done.", "Warning")
            End If
        Else
            MostrarMensaje(MsgBoxStyle.Critical, "El nombre de la nueva localidad no puede estar en blanco.", "Error", "The name of the new location cannot be left in blank.", "Error")
        End If

        ActualizarDatosSistema()
    End Sub

    Private Sub btnModificarEspecialidad_Click(sender As Object, e As EventArgs) Handles btnModificarEspecialidad.Click
        Dim nombreActual As String = txtNombreEspecialidadAModificar.Text
        Dim nombreNuevo As String = txtNuevoNombreEspecialidad.Text.Trim
        If nombreNuevo <> "" Then
            If nombreActual <> nombreNuevo Then
                Dim yaExiste As Boolean = False
                For Each especialidad As Especialidad In especialidades
                    If nombreNuevo.ToLower = especialidad.Nombre.ToLower Then
                        yaExiste = True
                    End If
                Next
                If Not yaExiste Then
                    Dim especialidad As Especialidad = Nothing
                    For Each esp As Especialidad In especialidades
                        If esp.Nombre = nombreActual Then
                            especialidad = esp
                        End If
                    Next
                    ActualizarEspecialidad(especialidad, nombreNuevo)
                Else
                    MostrarMensaje(MsgBoxStyle.Critical, "Ya existe una especialidad con este nombre.", "Error", "A specialty with this name already exists.", "Error")
                End If
            Else
                MostrarMensaje(MsgBoxStyle.Information, "Se ha ingresado el mismo nombre de especialidad. No se realizó ningún cambio.", "Aviso", "The same specialty name has been entered. No changes have been done.", "Warning")
            End If
        Else
            MostrarMensaje(MsgBoxStyle.Critical, "El nombre de la nueva especialidad no puede estar en blanco.", "Error", "The name of the new specialty cannot be left in blank.", "Error")
        End If

        ActualizarDatosSistema()
    End Sub

    Private Sub btnCambiarDepartamentoDeLocalidad_Click(sender As Object, e As EventArgs) Handles btnCambiarDepartamentoDeLocalidad.Click
        Dim departamentoActual As String = txtDepartamentoActual.Text
        Dim nuevoDepartamento As Departamento = cbxNuevoDepartamentoDeLocalidad.SelectedItem
        Dim nombreLocalidad As String = txtLocalidadParaCambiarDepartamento.Text
        If departamentoActual <> nuevoDepartamento.ToString Then
            Dim localidadesDelNuevoDepartamento As New List(Of Localidad)
            For Each l As Localidad In localidades
                If l.Departamento = nuevoDepartamento Then
                    localidadesDelNuevoDepartamento.Add(l)
                End If
            Next

            Dim yaExiste As Boolean = False
            For Each l As Localidad In localidadesDelNuevoDepartamento
                If nombreLocalidad.ToLower = l.Nombre.ToLower Then
                    yaExiste = True
                End If
            Next
            If Not yaExiste Then
                Dim localidad As Localidad = Nothing
                For Each l As Localidad In localidades
                    If l.Nombre = nombreLocalidad And l.Departamento.ToString = departamentoActual Then
                        localidad = l
                    End If
                Next
                ActualizarLocalidad(localidad, localidad.Nombre, nuevoDepartamento)
            Else
                MostrarMensaje(MsgBoxStyle.Critical, "Ya existe una localidad en este departamento con este nombre.", "Error", "A location with this name already exists.", "Error")
            End If
        Else
            MostrarMensaje(MsgBoxStyle.Information, "Se seleccionó el mismo departamento. No se realizó ningún cambio.", "Aviso", "The same department has been selected. No changes have been done.", "Warning")
        End If

        ActualizarDatosSistema()
    End Sub

    Private Sub btnEliminarDepartamento_Click(sender As Object, e As EventArgs) Handles btnEliminarDepartamento.Click
        Dim departamento As Departamento = Nothing
        Dim nombreDepartamento As String = txtEliminarDepartamento.Text
        For Each d As Departamento In departamentos
            If d.Nombre = nombreDepartamento Then
                departamento = d
            End If
        Next

        Dim tieneLocalidades As Boolean = False
        For Each l As Localidad In localidades
            If l.Departamento = departamento Then
                tieneLocalidades = True
            End If
        Next

        If Not tieneLocalidades Then
            EliminarDepartamento(departamento)
        Else
            MostrarMensaje(MsgBoxStyle.Critical, "No se puede eliminar un departamento que tenga localidades registradas. Elimine las localidades asociadas y reintente.", "Error", "A department with registered locations cannot be deleted. Delete the associated locations and retry.", "Error")
        End If

        ActualizarDatosSistema()
    End Sub

    Private Sub btnEliminarLocalidad_Click(sender As Object, e As EventArgs) Handles btnEliminarLocalidad.Click
        Dim localidad As Localidad = Nothing
        Dim nombreLocalidad As String = txtEliminarLocalidad.Text
        Dim departamento As Departamento = cbxDepartamentos.SelectedItem
        For Each l As Localidad In localidades
            If l.Nombre = nombreLocalidad And l.Departamento = departamento Then
                localidad = l
            End If
        Next

        Dim tienePersonas As Boolean = ExistenPersonasEnLocalidad(localidad)
        If Not tienePersonas Then
            EliminarLocalidad(localidad)
        Else
            MostrarMensaje(MsgBoxStyle.Critical, "No se puede eliminar una localidad que tenga personas registradas. Elimine las personas registradas y reintente.", "Error", "A location with registered people cannot be deleted. Delete all people registered in the location and retry.", "Error")
        End If

        ActualizarDatosSistema()
    End Sub

    Private Sub btnEliminarEspecialidad_Click(sender As Object, e As EventArgs) Handles btnEliminarEspecialidad.Click
        Dim especialidad As Especialidad = Nothing
        Dim nombreEspecialidad As String = txtEliminarEspecialidad.Text
        For Each esp As Especialidad In especialidades
            If esp.Nombre = nombreEspecialidad Then
                especialidad = esp
            End If
        Next

        If especialidad.Medicos.Count = 0 Then
            Dim tieneEnfermedades As Boolean = False
            For Each enfermedad As Enfermedad In CargarTodasLasEnfermedades()
                If enfermedad.Especialidad = especialidad Then
                    tieneEnfermedades = True
                End If
            Next

            If Not tieneEnfermedades Then
                EliminarEspecialidad(especialidad)
            Else
                MostrarMensaje(MsgBoxStyle.Critical, "No se puede eliminar una especialidad que tenga enfermedades asociadas. Elimine o modifique las enfermedades y reintente.", "Error", "A specialty with associated illnesses cannot be deleted. Delete or modify these illnesses and retry.", "Error")
            End If
        Else
            MostrarMensaje(MsgBoxStyle.Critical, "No se puede eliminar una especialidad que tenga médicos practicantes. Elimine la asociación y reintente.", "Error", "A specialty with associated doctors cannot be deleted. Modify the doctors' specialties and retry.", "Error")
        End If

        ActualizarDatosSistema()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        TraducirAplicacion()
    End Sub

    Private Sub FrmConfiguracion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            AbrirAyuda(TiposUsuario.Administrativo, Me)
        End If
    End Sub
End Class