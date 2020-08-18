﻿Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports CapaLogica
Imports Clases

Public Class FrmChatPaciente
    Dim diagnosticoEnCurso As DiagnosticoPrimarioConConsulta
    Dim mensajesMostrados As List(Of Mensaje)
    Dim cantidadTotalMensajes As Integer
    Dim lotesMensajes As Integer = 1
    Const tamanoLote As Integer = 50

    Public Sub New(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        diagnosticoEnCurso = diagnosticoPrimarioConConsulta

        If diagnosticoPrimarioConConsulta.Medico IsNot Nothing Then
            lblMedico.Text = lblMedico.Text.Replace("#", diagnosticoEnCurso.Medico.ToString)
        Else
            lblMedico.Text = "Un médico se comunicará con usted a la brevedad."
        End If

        cantidadTotalMensajes = ContarMensajes(diagnosticoPrimarioConConsulta)
        mensajesMostrados = CargarUltimosMensajesDiagnostico(diagnosticoEnCurso, lotesMensajes * tamanoLote)
        MostrarNuevosMensajes(mensajesMostrados)

        tmrActualizaMensajes.Enabled = True
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim bytesMensaje As Byte() = Encoding.UTF8.GetBytes(txtMensaje.Text.ToCharArray)
        EnviarMensaje(FormatosMensajeAdmitidos.TXT, bytesMensaje, TiposRemitente.Paciente, diagnosticoEnCurso)
        txtMensaje.Clear()
        ActualizarMensajes()
        'mensajesMostrados.Add(EnviarMensaje(FormatosMensajeAdmitidos.TXT, bytesMensaje, TiposRemitente.Paciente, diagnosticoEnCurso))
        'cantidadTotalMensajes += 1
    End Sub

    'NO IMPLEMENTADO
    Private Sub btnAdjuntar_Click(sender As Object, e As EventArgs) Handles btnAdjuntar.Click
        If expAdjuntar.ShowDialog() = Windows.Forms.DialogResult.OK Then
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
            EnviarMensaje(formato, contenidoArchivo, TiposRemitente.Paciente, diagnosticoEnCurso)
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
        Dim cantidadActualizadaMensajes As Integer = ContarMensajes(diagnosticoEnCurso)
        Dim cantidadNuevosMensajes As Integer = cantidadActualizadaMensajes - cantidadTotalMensajes

        If cantidadNuevosMensajes > 0 Then
            Dim nuevosMensajes As List(Of Mensaje) = CargarUltimosMensajesDiagnostico(diagnosticoEnCurso, cantidadNuevosMensajes)
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class