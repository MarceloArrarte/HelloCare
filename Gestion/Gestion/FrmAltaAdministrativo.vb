Imports CapaLogica
Imports Clases
Public Class FrmAltaAdministrativo
    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        If MostrarMensaje(MsgBoxStyle.YesNo, "Advertencia: no se guardaron los cambios." & vbNewLine & "¿Confirma que desea cerrar la ventana?", "Cerrar", "Warning: no changes have been saved." & vbNewLine & "Are you sure you wish to close this window?", "Close") =
            MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmAltaAdministrativo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' comentable?

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

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

        Try
            Dim localidad As Localidad
            Dim esEncargado As Boolean
            If checkEncargado.Checked = True Then
                esEncargado = True
            Else
                esEncargado = False
            End If


            Try
                localidad = tblLocalidad.SelectedRows(0).Cells(0).Value
            Catch ex As Exception
                Throw New Exception("No se selecciono ninguna localidad")
            End Try


            CrearAdministrativo(txtCI.Text, txtNombre.Text, txtApellido.Text, txtCorreo.Text, localidad, esEncargado)
            MostrarMensaje(MsgBoxStyle.OkOnly, "Administrativo agregado con éxito.", "Éxito", "Administrative staff successfully added.", "Success")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        TraducirAplicacion()
    End Sub

    Private Sub FrmAltaAdministrativo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            AbrirAyuda(TiposUsuario.Administrativo, Me)
        End If
    End Sub
End Class