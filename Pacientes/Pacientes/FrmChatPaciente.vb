Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports CapaLogica
Imports Clases

Public Class FrmChatPaciente
    Dim consultaEnCurso As DiagnosticoPrimarioConConsulta
    Dim mensajesMostrados As List(Of Mensaje)
    Dim cantidadTotalMensajes As Integer
    Dim lotesMensajes As Integer = 1
    Const tamanoLote As Integer = 50

    Public Sub New(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        consultaEnCurso = diagnosticoPrimarioConConsulta

        If diagnosticoPrimarioConConsulta.Medico IsNot Nothing Then
            lblMedico.Text = lblMedico.Text.Replace("#", consultaEnCurso.Medico.ToString)
        Else
            lblMedico.Text = "Un médico se comunicará con usted a la brevedad."
        End If

        cantidadTotalMensajes = ContarMensajes(diagnosticoPrimarioConConsulta)
        mensajesMostrados = CargarUltimosMensajesDiagnostico(consultaEnCurso, lotesMensajes * tamanoLote)
        MostrarNuevosMensajes(mensajesMostrados)

        tmrActualizaMensajes.Enabled = True
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim bytesMensaje As Byte() = Encoding.UTF8.GetBytes(txtMensaje.Text.ToCharArray)
        EnviarMensaje(FormatosMensajeAdmitidos.TXT, bytesMensaje, TiposRemitente.Paciente, consultaEnCurso)
        txtMensaje.Clear()
        ActualizarMensajes()
        'mensajesMostrados.Add(EnviarMensaje(FormatosMensajeAdmitidos.TXT, bytesMensaje, TiposRemitente.Paciente, diagnosticoEnCurso))
        'cantidadTotalMensajes += 1
    End Sub

    Private Sub btnAdjuntar_Click(sender As Object, e As EventArgs) Handles btnAdjuntar.Click
        expAdjuntar.FileName = ""
        If expAdjuntar.ShowDialog() = Windows.Forms.DialogResult.OK Then
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
            EnviarMensaje(formato, contenidoArchivo, TiposRemitente.Paciente, consultaEnCurso, nombreArchivo)
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
                Dim prefijoMensaje As String = m.FechaHora.ToString("(dd/MM HH:mm:ss) ")
                If m.Remitente = TiposRemitente.Paciente Then
                    prefijoMensaje &= "Tú: "
                Else
                    prefijoMensaje &= consultaEnCurso.Medico.ToString & ": "
                End If
                txtConversacion.Text &= prefijoMensaje & m.ToString & vbNewLine
            Else
                If m.Remitente = TiposRemitente.Paciente Then
                    txtConversacion.Text &= "Enviaste un archivo " & m.Formato.ToString & " (" & m.ToString & ")." & vbNewLine
                Else
                    txtConversacion.Text &= consultaEnCurso.Medico.ToString & " envió un archivo " & m.Formato.ToString & " (" & m.ToString & ")." & vbNewLine
                End If
                lstArchivos.Items.Add(m.ToString)
            End If
        Next
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
        lstArchivos.ClearSelected()
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        Dim nombreIdioma As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                idiomaSeleccionado = Idiomas.Ingles
                nombreIdioma = "en"
            Case Idiomas.Ingles
                idiomaSeleccionado = Idiomas.Espanol
                nombreIdioma = "es"
        End Select

        Dim crmIdioma As New ComponentResourceManager(GetType(FrmChatPaciente))
        For Each c As Control In Me.Controls
            crmIdioma.ApplyResources(c, c.Name, New CultureInfo(nombreIdioma))
        Next
    End Sub
End Class