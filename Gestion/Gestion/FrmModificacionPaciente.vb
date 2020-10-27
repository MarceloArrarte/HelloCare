Imports CapaLogica
Imports Clases
Public Class FrmModificacionPaciente


    Dim pacienteAModificar As Paciente

    Sub New(paciente As Paciente)
        InitializeComponent()

        ' Muestra los datos del paciente a modificar en los textos

        pacienteAModificar = paciente

    End Sub
    Private Sub FrmModificacionPaciente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Vuelve invisibles las localidades
        For i = 0 To tblLocalidad.Rows.Count - 1
            tblLocalidad.Rows(i).Visible = False
        Next
        'Añade los sexos disponibles al combo box
        cmbSexo.Items.AddRange([Enum].GetNames(GetType(TiposSexo)))

        'Añade los departamentos disponibles al combo box
        cmbDepartamento.Items.AddRange(CargarTodosLosDepartamentos.ToArray)


        'Carga todas las localidades al datagrid
        For Each localidad As Localidad In CargarTodasLasLocalidades()
            tblLocalidad.Rows.Add(localidad)
        Next

        'carga los datos del paciente en los txt y en los calendarios
        txtCi.Text = pacienteAModificar.CI
        txtNombre.Text = pacienteAModificar.Nombre
        txtApellido.Text = pacienteAModificar.Apellido
        txtCorreo.Text = pacienteAModificar.Correo
        txtTelMovil.Text = pacienteAModificar.TelefonoMovil
        txtTelFijo.Text = pacienteAModificar.TelefonoFijo
        cmbSexo.SelectedItem = pacienteAModificar.Sexo.ToString
        dtpFechaNacimiento.Value = pacienteAModificar.FechaNacimiento.ToString("d-M-yyyy")
        txtCalle.Text = pacienteAModificar.Calle
        txtNumeroPuerta.Text = pacienteAModificar.NumeroPuerta
        txtApartamento.Text = pacienteAModificar.Apartamento
        cmbDepartamento.Text = pacienteAModificar.Localidad.Departamento.ToString
        cbHabilitarFD.Visible = False

        If pacienteAModificar.FechaDefuncion = Nothing Then
            dtpFechaDefuncion.Visible = False
            cbHabilitarFD.Visible = True
        Else
            dtpFechaDefuncion.Text = pacienteAModificar.FechaDefuncion.ToString("d-M-yyyy")

        End If


        'Muestra la localidad actual del pacient en el datagrid
        For Each r As DataGridViewRow In tblLocalidad.Rows
            If CType(r.Cells(0).Value, Localidad).ID = pacienteAModificar.Localidad.ID Then
                r.Visible = True

            Else
                r.Visible = False

            End If
        Next

        'Deja sin seleccionar una localidad
        tblLocalidad.ClearSelection()
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        If MsgBox("Advertencia: no se guardaron los cambios." & vbNewLine & "¿Confirma que desea cerrar la ventana?", MsgBoxStyle.YesNo, "Salir") =
            MsgBoxResult.Yes Then
            Me.Close()
        End If
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

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try
            Dim localidad As Localidad
            Try
                Localidad = tblLocalidad.SelectedRows(0).Cells(0).Value
            Catch ex As Exception
                Throw New Exception("No se selecciono ninguna localidad")
            End Try

            If dtpFechaDefuncion.Visible = True Then
                ActualizarPaciente(pacienteAModificar, txtCi.Text, txtNombre.Text, txtApellido.Text, txtCorreo.Text, localidad, txtTelMovil.Text,
                             txtTelFijo.Text, [Enum].Parse(GetType(TiposSexo), cmbSexo.SelectedItem), dtpFechaNacimiento.Value, dtpFechaDefuncion.Value, txtCalle.Text,
                             txtNumeroPuerta.Text, txtApartamento.Text)
                MsgBox("Paciente modificado con éxito.", MsgBoxStyle.OkOnly, "Éxito")
                Me.Close()
            Else
                ActualizarPaciente(pacienteAModificar, txtCi.Text, txtNombre.Text, txtApellido.Text, txtCorreo.Text, localidad, txtTelMovil.Text,
                             txtTelFijo.Text, [Enum].Parse(GetType(TiposSexo), cmbSexo.SelectedItem), dtpFechaNacimiento.Value, Nothing, txtCalle.Text,
                             txtNumeroPuerta.Text, txtApartamento.Text)
                MsgBox("Paciente modificado con éxito.", MsgBoxStyle.OkOnly, "Éxito")
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cbHabilitarFD_CheckedChanged(sender As Object, e As EventArgs) Handles cbHabilitarFD.CheckedChanged
        If cbHabilitarFD.Checked = True Then
            dtpFechaDefuncion.Visible = True
        Else
            dtpFechaDefuncion.Visible = False
        End If
    End Sub
End Class