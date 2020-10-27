﻿Imports Clases
Imports CapaLogica
Public Class FrmAltaPaciente
    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        If MsgBox("Advertencia: no se guardaron los cambios." & vbNewLine & "¿Confirma que desea cerrar la ventana?", MsgBoxStyle.YesNo, "Salir") =
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
            MsgBox("Paciente agregado con éxito.", MsgBoxStyle.OkOnly, "Éxito")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged

    End Sub

    Private Sub tblLocalidad_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblLocalidad.CellContentClick

    End Sub
End Class