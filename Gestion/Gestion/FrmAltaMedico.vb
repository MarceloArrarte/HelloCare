Imports Clases
Imports CapaLogica
Public Class FrmAltaMedico
    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        If MostrarMensaje(MsgBoxStyle.YesNo, "Advertencia: no se guardaron los cambios." & vbNewLine & "¿Confirma que desea cerrar la ventana?", "Cerrar", "Warning: no changes have been saved." & vbNewLine & "Are you sure you wish to close this window?", "Close") =
            MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmAltaMedico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Añade todas las especialidades 
        For Each especialidad As Especialidad In CargarTodasLasEspecialidades()
            tblEspecialidades.Rows.Add(especialidad)
        Next
        tblEspecialidades.ClearSelection()

        'Añade todas las localidades existentes al data grid y las oculta
        For Each localidad As Localidad In CargarTodasLasLocalidades()
            tblLocalidad.Rows.Add(localidad)
            tblLocalidad.Rows(tblLocalidad.Rows.Count - 1).Visible = False
        Next

        'Añade al combo box de departamento los departamentos existentes
        cmbDepartamento.Items.AddRange(CargarTodosLosDepartamentos.ToArray)
    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        'Dependiendo del departamento seleccionado, se muetras las respectivas localidades a seleccionar
        For Each r As DataGridViewRow In tblLocalidad.Rows
            If CType(r.Cells(0).Value, Localidad).Departamento = cmbDepartamento.SelectedItem Then
                r.Visible = True
            Else
                r.Visible = False
            End If
        Next
        tblLocalidad.ClearSelection()
    End Sub

    Private Sub txtBuscarEspecialidades_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarEspecialidades.TextChanged
        For Each r As DataGridViewRow In tblEspecialidades.Rows
            If r.Cells(0).Value.ToString.ToLower Like ("*" & txtBuscarEspecialidades.Text & "*").ToLower Then
                r.Visible = True
            Else
                If Not r.Selected Then
                    r.Visible = False
                End If
            End If
        Next
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try
            Dim listaEspecialidades As New List(Of Especialidad)
            Dim localidad As Localidad

            'Verifica si se selecciono alguna localidad
            Try
                localidad = tblLocalidad.SelectedRows(0).Cells(0).Value
            Catch ex As Exception
                Throw New Exception("No se selecciono ninguna localidad")
            End Try


            For Each r As DataGridViewRow In tblAsociados.Rows
                listaEspecialidades.Add(CType(r.Cells(0).Value, Especialidad))
            Next


            'Verifica si se ingreso una especialidad como minimo
            Dim sinEspecialidad As Boolean = True
            If tblAsociados.Rows.Count = 0 Then
                sinEspecialidad = True
            Else
                sinEspecialidad = False
            End If

            If sinEspecialidad = True Then
                MostrarMensaje(MsgBoxStyle.Critical, "Debe seleccionar al menos una especialidad.", "Error", "You must select at least one specialty.", "Error")
            Else
                CrearMedico(txtCI.Text, txtNombre.Text, txtApellido.Text, txtCorreo.Text, localidad, listaEspecialidades)
                MostrarMensaje(MsgBoxStyle.OkOnly, "Médico agregado con éxito.", "Éxito", "Doctor successfully added.", "Success")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnQuitarE_Click(sender As Object, e As EventArgs) Handles btnQuitarE.Click
        If tblAsociados.SelectedRows.Count > 0 Then
            For Each rAsociada As DataGridViewRow In tblAsociados.SelectedRows
                For Each rEspecialidad As DataGridViewRow In tblEspecialidades.Rows
                    If rEspecialidad.Cells(0).Value = rAsociada.Cells(0).Value Then
                        rEspecialidad.Visible = True
                    End If
                Next
                tblAsociados.Rows.Remove(rAsociada)
            Next
            OcultarEspecialidadesSeleccionadasOFiltradas()
        Else
            MsgBox("Debe seleccionar al menos uno de las especialidades asociadas.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub OcultarEspecialidadesSeleccionadasOFiltradas()
        ' Oculta por filtro de texto
        For Each r As DataGridViewRow In tblEspecialidades.Rows
            If r.Cells(0).Value.ToString.ToLower Like ("*" & txtBuscarEspecialidades.Text & "*").ToLower Then
                r.Visible = True
            Else
                r.Visible = False
            End If
        Next

        ' Oculta las especialidades ya seleccionadas
        For Each rAsociado As DataGridViewRow In tblAsociados.Rows
            For Each rEspecialidad As DataGridViewRow In tblEspecialidades.Rows
                If rAsociado.Cells(0).Value = rEspecialidad.Cells(0).Value Then
                    rEspecialidad.Visible = False
                End If
            Next
        Next
        DeseleccionarTablas()
    End Sub

    Private Sub DeseleccionarTablas()
        tblAsociados.ClearSelection()
        tblEspecialidades.ClearSelection()
    End Sub

    Private Sub btnAgregarE_Click(sender As Object, e As EventArgs) Handles btnAgregarE.Click
        If tblEspecialidades.SelectedRows.Count > 0 Then
            For Each r As DataGridViewRow In tblEspecialidades.SelectedRows
                tblAsociados.Rows.Add(r.Cells(0).Value)

            Next
            OcultarEspecialidadesSeleccionadasOFiltradas()
        Else
            MsgBox("Debe seleccionar al menos uno de las especialidades disponibles.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        TraducirAplicacion()
    End Sub

    Private Sub FrmAltaMedico_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            AbrirAyuda(TiposUsuario.Administrativo, Me)
        End If
    End Sub
End Class