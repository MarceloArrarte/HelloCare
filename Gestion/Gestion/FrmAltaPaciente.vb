Imports Clases
Imports CapaLogica
Public Class FrmAltaPaciente
    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        If MostrarMensaje(MsgBoxStyle.YesNo, "Advertencia: no se guardaron los cambios." & vbNewLine & "¿Confirma que desea cerrar la ventana?", "Cerrar", "Warning: no changes have been saved." & vbNewLine & "Are you sure you wish to close this window?", "Close") =
            MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmAltaPaciente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To tblLocalidad.Rows.Count - 1
            tblLocalidad.Rows(i).Visible = False
        Next
        cmbSexo.Items.AddRange([Enum].GetNames(GetType(TiposSexo)))

        cmbDepartamento.Items.AddRange(CargarTodosLosDepartamentos.ToArray)

        For Each localidad As Localidad In CargarTodasLasLocalidades()
            tblLocalidad.Rows.Add(localidad)
            tblLocalidad.Rows(tblLocalidad.Rows.Count - 1).Visible = False
        Next
    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        For Each r As DataGridViewRow In tblLocalidad.Rows
            If CType(r.Cells(0).Value, Localidad).Departamento = cmbDepartamento.SelectedItem Then
                r.Visible = True
            Else
                r.Visible = False
            End If
        Next
        tblLocalidad.ClearSelection()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim localidad As Localidad = tblLocalidad.SelectedRows(0).Cells(0).Value

            Try
                localidad = tblLocalidad.SelectedRows(0).Cells(0).Value
            Catch ex As Exception
                Throw New Exception("No se selecciono ninguna localidad")
            End Try

            CrearPaciente(txtCi.Text, txtNombre.Text, txtApellido.Text, txtCorreo.Text, localidad, txtTelMovil.Text, txtTelFijo.Text, [Enum].Parse(GetType(TiposSexo), cmbSexo.SelectedItem), dtpFecha.Value, Nothing, txtCalle.Text, txtNumeroPuerta.Text, txtApartamento.Text)
            MostrarMensaje(MsgBoxStyle.OkOnly, "Paciente agregado con éxito.", "Éxito", "Patient successfully added.", "Success")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        TraducirAplicacion()
    End Sub
End Class