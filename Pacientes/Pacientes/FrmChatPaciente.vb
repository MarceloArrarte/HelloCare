Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports CapaLogica
Imports Clases

Public Class FrmChatPaciente
    Dim consultaEnCurso As DiagnosticoPrimarioConConsulta
    Dim cantidadTotalArchivos As Integer
    Dim cantidadTotalMensajes As Integer

    Public Sub New(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        consultaEnCurso = diagnosticoPrimarioConConsulta

        If diagnosticoPrimarioConConsulta.Medico IsNot Nothing Then
            lblMedico.Text = lblMedico.Text.Replace("#", consultaEnCurso.Medico.ToString)
        Else
            If idiomaSeleccionado = Idiomas.Espanol Then
                lblMedico.Text = "Un médico se comunicará con usted a la brevedad."
            Else
                lblMedico.Text = "A doctor will communicate with you shortly."
            End If
        End If

        cantidadTotalMensajes = ContarMensajes(consultaEnCurso)
        cantidadTotalArchivos = ContarArchivos(consultaEnCurso)
        MostrarNuevosMensajes(CargarUltimosMensajesDiagnostico(consultaEnCurso, cantidadTotalMensajes))
        MostrarNuevosMensajes(CargarUltimosMetadatosArchivosDiagnostico(consultaEnCurso, cantidadTotalArchivos))

        tmrActualizar.Enabled = True
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim bytesMensaje As Byte() = Encoding.UTF8.GetBytes(txtMensaje.Text.ToCharArray)
        EnviarMensaje(FormatosMensajeAdmitidos.TXT, bytesMensaje, TiposRemitente.Paciente, consultaEnCurso)
        txtMensaje.Clear()
        ActualizarMensajes()
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
            EnviarMensaje(FormatosMensajeAdmitidos.TXT, Encoding.UTF8.GetBytes(pacienteLogeado.ToString & " envió un archivo " & formato.ToString & " (" & nombreArchivo & ")."),
                          TiposRemitente.Paciente, consultaEnCurso)

            EnviarMensaje(formato, contenidoArchivo, TiposRemitente.Paciente, consultaEnCurso, nombreArchivo)
            ActualizarMensajes()
        End If
    End Sub

    Private Sub tmrActualizar_Tick(sender As Object, e As EventArgs) Handles tmrActualizar.Tick
        tmrActualizar.Enabled = False
        If consultaEnCurso.Medico Is Nothing AndAlso ConsultaTieneMedico(consultaEnCurso) Then
            CargarMedicoEnConsulta(consultaEnCurso)
            If idiomaSeleccionado = Idiomas.Espanol Then
                lblMedico.Text = "Usted se está comunicando con " & consultaEnCurso.Medico.ToString & "."
            Else
                lblMedico.Text = "You are communicating with " & consultaEnCurso.Medico.ToString & "."
            End If
        End If
        ActualizarMensajes()
        tmrActualizar.Enabled = True
    End Sub

    Private Sub ActualizarMensajes()
        Dim cantidadActualizadaMensajes As Integer = ContarMensajes(consultaEnCurso)
        Dim cantidadNuevosMensajes As Integer = cantidadActualizadaMensajes - cantidadTotalMensajes

        If cantidadNuevosMensajes > 0 Then
            Dim nuevosMensajes As List(Of Mensaje) = CargarUltimosMensajesDiagnostico(consultaEnCurso, cantidadNuevosMensajes)
            cantidadTotalMensajes = cantidadActualizadaMensajes
            MostrarNuevosMensajes(nuevosMensajes)
        End If

        Dim cantidadActualizadaArchivos As Integer = ContarArchivos(consultaEnCurso)
        Dim cantidadNuevosArchivos As Integer = cantidadActualizadaArchivos - cantidadTotalArchivos

        If cantidadNuevosArchivos > 0 Then
            Dim nuevosArchivos As List(Of Mensaje) = CargarUltimosMetadatosArchivosDiagnostico(consultaEnCurso, cantidadNuevosArchivos)
            cantidadTotalArchivos = cantidadActualizadaArchivos
            MostrarNuevosMensajes(nuevosArchivos)
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
                lstArchivos.Items.Add(m)
            End If
        Next
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub lstArchivos_DoubleClick(sender As Object, e As EventArgs) Handles lstArchivos.DoubleClick
        If lstArchivos.SelectedItems.Count = 1 Then
            ' Llamada a método para obtener archivo de la BD en base a ID
            Dim metadatos As Mensaje = lstArchivos.SelectedItem
            Dim contenidoArchivo As Byte() = CargarContenidoArchivoPorID(metadatos.ID)

            Dim ruta As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & metadatos.NombreArchivo
            If File.Exists(ruta) Then
                Dim extension As String = ruta.Substring(ruta.Length - 1 - StrReverse(ruta).IndexOf("."))
                Dim nombreArchivo As String = ruta.Substring(0, ruta.Length - extension.Length)
                Dim numeradorArchivo As Integer = 1
                While File.Exists(nombreArchivo & "(" & numeradorArchivo & ")" & extension)
                    numeradorArchivo += 1
                End While
                ruta = nombreArchivo & "(" & numeradorArchivo & ")" & extension
            End If
            File.WriteAllBytes(ruta, contenidoArchivo)
            Dim abrirArchivo As New Process
            abrirArchivo.StartInfo.FileName = ruta
            abrirArchivo.Start()
        End If
        lstArchivos.ClearSelected()
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        TraducirAplicacion()
    End Sub

    Private Sub lblMedico_TextChanged(sender As Object, e As EventArgs) Handles lblMedico.TextChanged
        If consultaEnCurso IsNot Nothing AndAlso consultaEnCurso.Medico IsNot Nothing Then
            lblMedico.Text = lblMedico.Text.Replace("#", consultaEnCurso.Medico.ToString)
        Else
            If idiomaSeleccionado = Idiomas.Espanol Then
                lblMedico.Text = "Un médico se comunicará con usted a la brevedad."
            Else
                lblMedico.Text = "A doctor will communicate with you shortly."
            End If
        End If
    End Sub
End Class