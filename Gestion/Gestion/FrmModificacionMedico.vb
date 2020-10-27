Imports CapaLogica
Imports Clases
Public Class FrmModificacionMedico


    Dim medicoAModificar As Medico
    Sub New(medico As Medico)
        'Carga en los txt los datos del medico
        InitializeComponent()
        txtCI.Text = medico.CI
        txtNombre.Text = medico.Nombre
        txtApellido.Text = medico.Apellido
        txtCorreo.Text = medico.Correo








        ' Almacena el medico que se va a estar modificando
        medicoAModificar = medico

    End Sub
    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        If MsgBox("Advertencia: no se guardaron los cambios." & vbNewLine & "¿Confirma que desea cerrar la ventana?", MsgBoxStyle.YesNo, "Salir") =
            MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub



    Private Sub FrmModificacionMedico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Añade todas las especialidades 
        tblEspecialidades.ClearSelection()
        For Each especialidad As Especialidad In CargarTodasLasEspecialidades()
            tblEspecialidades.Rows.Add(especialidad)
        Next


        'Precarga los datos de las especialidades del medico
        For i = 0 To medicoAModificar.Especialidades.Count - 1
            tblAsociados.Rows.Add(medicoAModificar.Especialidades(i))
        Next

        'Vuelve invisibles las filas del listado de localidades
        For i = 0 To tblLocalidad.Rows.Count - 1
            tblLocalidad.Rows(i).Visible = False
        Next




        'Añade todas las localidades existentes al data grid
        For Each localidad As Localidad In CargarTodasLasLocalidades()
            tblLocalidad.Rows.Add(localidad)
        Next
        tblLocalidad.ClearSelection()



        For Each r As DataGridViewRow In tblLocalidad.Rows
            If CType(r.Cells(0).Value, Localidad).ID = medicoAModificar.Localidad.ID Then
                r.Visible = True

            Else
                r.Visible = False

            End If
        Next



        'Añade al combo box de departamento los departamentos existentes
        cmbDepartamento.Items.AddRange(CargarTodosLosDepartamentos.ToArray)

        'Oculta las especialidades ya asignadas
        OcultarEspecialidadesSeleccionadasOFiltradas()

    End Sub


    Private Sub cmbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartamento.SelectedIndexChanged

        For Each r As DataGridViewRow In tblLocalidad.Rows
            If CType(r.Cells(0).Value, Localidad).Departamento = cmbDepartamento.SelectedItem Then
                r.Visible = True
            Else
                r.Visible = False
            End If
        Next
        'Deja sin seleccionar una localidad
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

        OcultarEspecialidadesSeleccionadasOFiltradas()
    End Sub


    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try
            Dim listaEspecialidades As New List(Of Especialidad)
            Dim localidad As Localidad


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
                MsgBox("Debe ingresar al menos una especialidad", MsgBoxStyle.Critical, "Error")
            Else
                ActualizarMedico(medicoAModificar, txtCI.Text, txtNombre.Text, txtApellido.Text, txtCorreo.Text, localidad, listaEspecialidades)

                MsgBox("Medico Modificado con éxito.", MsgBoxStyle.OkOnly, "Éxito")
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

    Private Sub OcultarEspecialidadesSeleccionadasOFiltradas()
        ' Oculta por filtro de texto
        For Each r As DataGridViewRow In tblAsociados.Rows
            If r.Cells(0).Value.ToString.ToLower Like ("*" & txtBuscarEspecialidades.Text & "*").ToLower Then
                r.Visible = True
            Else
                r.Visible = False
            End If
        Next

        ' Oculta las especialidades ya seleccionadas
        For Each rAsociada As DataGridViewRow In tblAsociados.Rows
            For Each rEspecialidad As DataGridViewRow In tblEspecialidades.Rows
                If rAsociada.Cells(0).Value = rEspecialidad.Cells(0).Value Then
                    rEspecialidad.Visible = False
                End If
            Next
        Next
        DeseleccionarTablas()

    End Sub



    Private Sub DeseleccionarTablas()
        tblAsociados.ClearSelection()
        tblEspecialidades.ClearSelection()
        tblLocalidad.ClearSelection()
    End Sub

End Class