Imports System.ComponentModel
Imports System.Globalization
Imports CapaLogica
Imports Clases

Public Class FrmHistorialChats
    Private mesesHistorial As Integer = 1
    Private Sub FrmHistorialChats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim consultasMedico As List(Of DiagnosticoPrimarioConConsulta) = CargarConsultasMedico(mesesHistorial)
        For Each d As DiagnosticoPrimarioConConsulta In consultasMedico
            Dim ultimoMensaje As Mensaje = CargarUltimosMensajesDiagnostico(d, 1).Single
            Dim prefijoMensaje As String
            If ultimoMensaje.Remitente = TiposRemitente.Medico Then
                prefijoMensaje = "Tú: "
            Else
                prefijoMensaje = d.Paciente.ToString & ": "
            End If

            tblChats.Rows.Add(d, d.Paciente, prefijoMensaje & ultimoMensaje.ToString,
                              ultimoMensaje.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"))
        Next
    End Sub

    Private Sub btnAbrirChat_Click(sender As Object, e As EventArgs) Handles btnAbrirChat.Click
        If tblChats.SelectedRows.Count = 1 Then
            Dim consulta As DiagnosticoPrimarioConConsulta = tblChats.SelectedRows(0).Cells(0).Value
            Dim frm As New FrmChatMedico(consulta)
            Me.Hide()
            frm.ShowDialog()
            Me.Show()
        Else
            MostrarMensaje(MsgBoxStyle.Information, "Seleccione un único chat para abrirlo.", "", "Select a single chat to open it.", "")
        End If
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        TraducirFormulario(Me)
    End Sub
End Class