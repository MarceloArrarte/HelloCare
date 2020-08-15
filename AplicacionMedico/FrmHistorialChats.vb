Imports CapaLogica
Imports Clases

Public Class FrmHistorialChats
    Private mesesHistorial As Integer = 1
    Private Sub FrmHistorialChats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim consultasMedico As List(Of DiagnosticoPrimarioConConsulta) = CargarConsultasMedico(mesesHistorial)
        For Each d As DiagnosticoPrimarioConConsulta In consultasMedico
            Dim ultimoMensaje As Mensaje = CargarUltimosMensajesDiagnostico(d, 1).Single
            tblChats.Rows.Add(d, d.Paciente, ultimoMensaje.Remitente.ToString.Chars(0) & ": " & ultimoMensaje.ToString,
                              ultimoMensaje.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"))
            'If ContarDiagnosticosDiferenciales(d) = 0 Then
            '    tblChats.Rows.Add(d, d.Paciente, "No realizado", ultimoMensaje.Remitente.ToString.Chars(0) & ": " & ultimoMensaje.ToString,
            '                      ultimoMensaje.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"))
            'Else
            '    Dim ultimoDiagnosticoDiferencial As DiagnosticoDiferencial = CargarUltimoDiagnosticoDiferencialConsulta(d)
            '    tblChats.Rows.Add(d, d.Paciente, ultimoDiagnosticoDiferencial.EnfermedadDiagnosticada,
            '                      ultimoMensaje.Remitente.ToString.Chars(0) & ": " & ultimoMensaje.ToString,
            '                      ultimoMensaje.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"))
            'End If
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
            MsgBox("Seleccione un único chat para abrirlo.")
        End If
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub
End Class