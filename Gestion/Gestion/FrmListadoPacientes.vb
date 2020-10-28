Imports CapaLogica
Imports Clases
Public Class FrmListadoPacientes
    Private Sub FrmListadoPacientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarPacientes()
    End Sub

    'Abre un formulario con los detalles de un paciente
    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        If tblPacientes.SelectedRows.Count = 1 Then
            Dim Paciente As Paciente = tblPacientes.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmVerPaciente(Paciente)

            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        Else
            MsgBox("Seleccione una sola fila para ver los detalles del paciente.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    'Vuelve a la ventana anterior
    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If tblPacientes.SelectedRows.Count = 1 Then
            Dim paciente As Paciente = tblPacientes.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmModificacionPaciente(paciente)
            Me.Hide()
            frm.ShowDialog()
            ActualizarPacientes()
            Me.Show()
        Else
            MsgBox("Seleccione una sola fila para modificar el paciente correspondiente.", MsgBoxStyle.Critical, "Error")
        End If
        ActualizarPacientes()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If tblPacientes.SelectedRows.Count > 0 Then
            If MsgBox("¿Confirma que desea eliminar este paciente?" & vbNewLine &
                      "Estos cambios no podrán deshacerse.", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                For Each r As DataGridViewRow In tblPacientes.SelectedRows
                    EliminarPaciente(r.Cells(0).Value)
                Next
                ActualizarPacientes()
            End If
        Else
            MsgBox("Seleccione al menos una fila para eliminar el o los pacientes.")
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim frm As New FrmAltaPaciente
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
        ActualizarPacientes()
    End Sub
    Private Sub ActualizarPacientes()
        tblPacientes.Rows.Clear()
        For Each paciente As Paciente In CargarTodosLosPacientes()
            If paciente.FechaDefuncion = Nothing Then
                tblPacientes.Rows.Add(paciente, paciente.CI, paciente.Nombre, paciente.Apellido, paciente.Correo, paciente.Localidad, paciente.TelefonoMovil, paciente.TelefonoFijo, paciente.Sexo, paciente.FechaNacimiento, Nothing, paciente.Calle, paciente.NumeroPuerta, paciente.Apartamento)
            Else
                tblPacientes.Rows.Add(paciente, paciente.CI, paciente.Nombre, paciente.Apellido, paciente.Correo, paciente.Localidad, paciente.TelefonoMovil, paciente.TelefonoFijo, paciente.Sexo, paciente.FechaNacimiento, paciente.FechaDefuncion, paciente.Calle, paciente.NumeroPuerta, paciente.Apartamento)
            End If
        Next
        tblPacientes.ClearSelection()
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        TraducirAplicacion()
    End Sub
End Class