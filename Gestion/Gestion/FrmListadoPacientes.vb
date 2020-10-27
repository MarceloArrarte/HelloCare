Imports CapaLogica
Imports Clases
Public Class FrmListadoPacientes

    'Abre un formulario con los detalles de un paciente
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        If tblPacientes.SelectedRows.Count = 1 Then
            Dim Paciente As Paciente = tblPacientes.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmVerPaciente(Paciente)

            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        Else
            MsgBox("Seleccione una sola fila para ver los detalles del paciente.", MsgBoxStyle.Critical, "Error")
        End If
        ActualizarPacientes()
    End Sub

    'Vuelve a la ventana anterior
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
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
        For Each Paciente As Paciente In CargarTodosLosPacientes()
            If Paciente.FechaDefuncion = Nothing Then
                tblPacientes.Rows.Add(Paciente, Paciente.CI, Paciente.Nombre, Paciente.Apellido, Paciente.Correo, Paciente.Localidad, Paciente.TelefonoMovil, Paciente.TelefonoFijo, Paciente.Sexo, Paciente.FechaNacimiento, Nothing, Paciente.Calle, Paciente.NumeroPuerta, Paciente.Apartamento)
            Else
                tblPacientes.Rows.Add(Paciente, Paciente.CI, Paciente.Nombre, Paciente.Apellido, Paciente.Correo, Paciente.Localidad, Paciente.TelefonoMovil, Paciente.TelefonoFijo, Paciente.Sexo, Paciente.FechaNacimiento, Paciente.FechaDefuncion, Paciente.Calle, Paciente.NumeroPuerta, Paciente.Apartamento)
            End If
        Next


        tblPacientes.ClearSelection()



    End Sub
    Private Sub FrmListadoPacientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarPacientes()
    End Sub

    Private Sub FrmListadoPaciente_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ActualizarPacientes()
    End Sub
    Private Sub tblPacientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblPacientes.CellContentClick

    End Sub
End Class