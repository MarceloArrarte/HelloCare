Imports System.ComponentModel
Imports System.Globalization
Imports CapaLogica
Imports Clases

Public Class FrmHistorialChats
    Private Sub FrmHistorialChats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim consultasMedico As List(Of DiagnosticoPrimarioConConsulta)
        Try
            consultasMedico = CargarConsultasMedico()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return
        End Try

        For Each d As DiagnosticoPrimarioConConsulta In consultasMedico
            Dim ultimoMensaje As Mensaje
            Try
                ultimoMensaje = CargarUltimosMensajesDiagnostico(d, 1).SingleOrDefault
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                Return
            End Try

            If ultimoMensaje IsNot Nothing Then
                Dim prefijoMensaje As String
                If ultimoMensaje.Remitente = TiposRemitente.Medico Then
                    prefijoMensaje = "Tú: "
                Else
                    prefijoMensaje = d.Paciente.ToString & ": "
                End If

                tblChats.Rows.Add(d, d.Paciente, prefijoMensaje & ultimoMensaje.ToString, ultimoMensaje.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"))
            Else
                tblChats.Rows.Add(d, d.Paciente, "Sin mensajes.", "")
            End If
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
        TraducirAplicacion()
    End Sub
End Class