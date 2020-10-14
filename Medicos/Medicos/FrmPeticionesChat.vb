Imports CapaLogica
Imports Clases

Public Class FrmPeticionesChat
    Private Sub FrmPeticionesChat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefrescarPeticiones()
    End Sub

    Private Sub RefrescarPeticiones()
        tblPeticiones.Rows.Clear()
        For Each d As DiagnosticoPrimarioConConsulta In CargarConsultasSinAtenderParaMedicoLogeado()
            Dim enfermedadMasProbable As Enfermedad = d.Enfermedades(d.IndiceEnfermedadMasProbable)
            Dim color As Color
            Dim etiqueta As String

            If d.FechaHora.AddDays(1) < Now Then
                etiqueta = "Atrasada"
                color = Color.FromArgb(255, 97, 97)
            Else
                Select Case enfermedadMasProbable.Gravedad
                    Case 0 To 30
                        etiqueta = "Baja"
                        color = Color.LightGreen
                    Case 31 To 70
                        etiqueta = "Media"
                        color = Color.Yellow
                    Case 71 To 100
                        etiqueta = "Alta"
                        color = Color.FromArgb(255, 97, 97)
                End Select
            End If
            tblPeticiones.Rows.Add(d, d.Paciente, enfermedadMasProbable, etiqueta, d.ComentariosAdicionales, d.FechaHora)

            For Each c As DataGridViewCell In tblPeticiones.Rows(tblPeticiones.Rows.Count - 1).Cells
                c.Style.BackColor = color
            Next
        Next
        tblPeticiones.ClearSelection()
    End Sub

    Private Sub btnAceptarConsulta_Click(sender As Object, e As EventArgs) Handles btnAceptarConsulta.Click
        If tblPeticiones.SelectedRows.Count = 1 Then
            Dim peticion As DiagnosticoPrimarioConConsulta = tblPeticiones.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmChatMedico(peticion)
            Me.Hide()
            frm.ShowDialog()
            RefrescarPeticiones()
            Me.Show()
        Else
            MsgBox("Seleccione un diagnóstico para aceptar la petición e iniciar el chat.")
        End If
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub
End Class