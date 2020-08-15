Imports System.IO
Imports System.Text
Imports CapaLogica
Imports Clases

Public Class FrmChatMedico
    Dim consultaEnCurso As DiagnosticoPrimarioConConsulta
    Dim mensajesMostrados As List(Of Mensaje)
    Dim cantidadTotalMensajes As Integer
    Dim lotesMensajes As Integer = 1
    Const tamanoLote As Integer = 50

    Public Sub New(consulta As DiagnosticoPrimarioConConsulta)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        consultaEnCurso = consulta
        If consultaEnCurso.Medico Is Nothing Then
            consultaEnCurso = AsignarMedicoLogeadoAConsulta(consulta)
        End If

        lblNombrePaciente.Text = consultaEnCurso.Paciente.ToString

        cantidadTotalMensajes = ContarMensajes(consulta)
        mensajesMostrados = CargarUltimosMensajesDiagnostico(consultaEnCurso, lotesMensajes * tamanoLote)
        MostrarNuevosMensajes(mensajesMostrados)

        tmrActualizaMensajes.Enabled = True
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim bytesMensaje As Byte() = Encoding.UTF8.GetBytes(txtMensaje.Text.ToCharArray)
        EnviarMensaje(FormatosMensajeAdmitidos.TXT, bytesMensaje, TiposRemitente.Medico, consultaEnCurso)
        txtMensaje.Clear()
        ActualizarMensajes()
        'mensajesMostrados.Add(EnviarMensaje(FormatosMensajeAdmitidos.TXT, bytesMensaje, TiposRemitente.Paciente, diagnosticoEnCurso))
        'cantidadTotalMensajes += 1
    End Sub

    Private Sub btnAdjuntar_Click(sender As Object, e As EventArgs) Handles btnAdjuntar.Click
        If expAdjuntar.ShowDialog() = DialogResult.OK Then
            Dim ruta As String = expAdjuntar.FileName
            Dim extension As String = Path.GetExtension(ruta)
            Dim formato As FormatosMensajeAdmitidos
            Select Case extension
                Case "PDF"
                    formato = FormatosMensajeAdmitidos.PDF
                Case "JPG"
                    formato = FormatosMensajeAdmitidos.JPG
                Case "JPEG"
                    formato = FormatosMensajeAdmitidos.JPEG
                Case "PNG"
                    formato = FormatosMensajeAdmitidos.PNG
            End Select
            Dim contenidoArchivo As Byte() = File.ReadAllBytes(ruta)
            EnviarMensaje(formato, contenidoArchivo, TiposRemitente.Paciente, consultaEnCurso)
            'mensajesMostrados.Add(EnviarMensaje(formato, contenidoArchivo, TiposRemitente.Paciente, diagnosticoEnCurso))
            'cantidadTotalMensajes += 1
            ActualizarMensajes()
        End If
    End Sub

    Private Sub tmrActualizaMensajes_Tick(sender As Object, e As EventArgs) Handles tmrActualizaMensajes.Tick
        tmrActualizaMensajes.Enabled = False
        ActualizarMensajes()
        tmrActualizaMensajes.Enabled = True
    End Sub

    Private Sub ActualizarMensajes()
        Dim cantidadActualizadaMensajes As Integer = ContarMensajes(consultaEnCurso)
        Dim cantidadNuevosMensajes As Integer = cantidadActualizadaMensajes - cantidadTotalMensajes

        If cantidadNuevosMensajes > 0 Then
            Dim nuevosMensajes As List(Of Mensaje) = CargarUltimosMensajesDiagnostico(consultaEnCurso, cantidadNuevosMensajes)
            mensajesMostrados.AddRange(nuevosMensajes)
            cantidadTotalMensajes = cantidadActualizadaMensajes
            MostrarNuevosMensajes(nuevosMensajes)
        End If
    End Sub

    Private Sub MostrarNuevosMensajes(mensajes As List(Of Mensaje))
        For Each m As Mensaje In mensajes
            If m.Formato = FormatosMensajeAdmitidos.TXT Then
                txtConversacion.Text &= m.FechaHora.ToString("(dd/MM HH:mm:ss) ") & m.Remitente.ToString.Chars(0) & ": " & m.ToString & vbNewLine
            Else
                txtConversacion.Text &= m.Remitente.ToString.Chars(0) & " envió un archivo " & m.Formato.ToString & "." & vbNewLine
                lstArchivos.Items.Add(m.ToString)
            End If
        Next
    End Sub

    Private Sub btnDiagnosticar_Click(sender As Object, e As EventArgs) Handles btnDiagnosticar.Click
        Dim frmDiagnosticoDiferencial As New FrmNuevoDiagnostico(consultaEnCurso)
        frmDiagnosticoDiferencial.ShowDialog()
        If frmDiagnosticoDiferencial.DialogResult = DialogResult.OK Then
            Dim bytesMensaje As Byte() = Encoding.UTF8.GetBytes("Diagnóstico realizado: " & frmDiagnosticoDiferencial.enfermedadDiagnosticada.ToString)
            EnviarMensaje(FormatosMensajeAdmitidos.TXT, bytesMensaje, TiposRemitente.Medico, consultaEnCurso)
            ActualizarMensajes()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class