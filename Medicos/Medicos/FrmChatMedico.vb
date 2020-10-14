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
    End Sub

    Private Sub btnAdjuntar_Click(sender As Object, e As EventArgs) Handles btnAdjuntar.Click
        If expAdjuntar.ShowDialog() = DialogResult.OK Then
            Dim ruta As String = expAdjuntar.FileName
            Dim nombreArchivo As String = expAdjuntar.SafeFileName
            Dim extension As String = Path.GetExtension(ruta)
            Dim formato As FormatosMensajeAdmitidos
            Select Case extension.ToLower
                Case ".pdf"
                    formato = FormatosMensajeAdmitidos.PDF
                Case ".jpg"
                    formato = FormatosMensajeAdmitidos.JPG
                Case ".jpeg"
                    formato = FormatosMensajeAdmitidos.JPEG
                Case ".png"
                    formato = FormatosMensajeAdmitidos.PNG
            End Select
            Dim contenidoArchivo As Byte() = File.ReadAllBytes(ruta)
            EnviarMensaje(formato, contenidoArchivo, TiposRemitente.Medico, consultaEnCurso, nombreArchivo)
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
                lstArchivos.Items.Add(m)
            End If
        Next
    End Sub

    Private Sub btnDiagnosticar_Click(sender As Object, e As EventArgs) Handles btnDiagnosticar.Click
        Dim frmDiagnosticoDiferencial As New FrmNuevoDiagnostico(consultaEnCurso)
        frmDiagnosticoDiferencial.ShowDialog()
        If frmDiagnosticoDiferencial.DialogResult = DialogResult.OK Then
            Dim bytesMensaje As Byte() = Encoding.UTF8.GetBytes("Diagnóstico realizado: " & frmDiagnosticoDiferencial.diagnosticoRealizado.EnfermedadDiagnosticada.ToString)
            EnviarMensaje(FormatosMensajeAdmitidos.TXT, bytesMensaje, TiposRemitente.Medico, consultaEnCurso)
            ActualizarMensajes()
            Dim archivosAdjuntos As New List(Of Mensaje)
            For i = 0 To lstArchivos.Items.Count - 1
                archivosAdjuntos.Add(lstArchivos.Items(i))
            Next
            EnviarSesionChat(consultaEnCurso.Paciente, frmDiagnosticoDiferencial.diagnosticoRealizado, txtConversacion.Text, archivosAdjuntos)
            MsgBox("Se ha enviado una copia de la sesión del chat al paciente.")
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub lstArchivos_DoubleClick(sender As Object, e As EventArgs) Handles lstArchivos.DoubleClick
        If lstArchivos.SelectedItems.Count = 1 Then
            Dim archivo As Mensaje = lstArchivos.SelectedItem
            Dim ruta As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & archivo.NombreArchivo
            If File.Exists(ruta) Then
                Dim extension As String = ruta.Substring(ruta.Length - 1 - StrReverse(ruta).IndexOf("."))
                Dim nombreArchivo As String = ruta.Substring(0, ruta.Length - extension.Length)
                Dim numeradorArchivo As Integer = 1
                While File.Exists(nombreArchivo & "(" & numeradorArchivo & ")" & extension)
                    numeradorArchivo += 1
                End While
                ruta = nombreArchivo & "(" & numeradorArchivo & ")" & extension
            End If
            File.WriteAllBytes(ruta, archivo.Contenido)
            Dim abrirArchivo As New Process
            abrirArchivo.StartInfo.FileName = ruta
            abrirArchivo.Start()
        End If
    End Sub
End Class