﻿Imports System.Text

Public Class Mensaje
    Private ReadOnly _ID As Integer
    Private ReadOnly _FechaHora As Date
    Private ReadOnly _Formato As FormatosMensajeAdmitidos
    Private ReadOnly _Contenido() As Byte
    Private ReadOnly _Remitente As TiposRemitente
    Private ReadOnly _DiagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta

    Public Sub New(fechaHora As Date, formato As FormatosMensajeAdmitidos, contenido As Byte(), remitente As TiposRemitente,
                   diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta)
        _ID = Integer.MinValue
        _FechaHora = fechaHora
        _Formato = formato
        _Contenido = contenido
        _Remitente = remitente
        _DiagnosticoPrimarioConConsulta = diagnosticoPrimarioConConsulta
    End Sub

    Public Sub New(id As Integer, fechaHora As Date, formato As FormatosMensajeAdmitidos, contenido As Byte(), remitente As TiposRemitente,
                   diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta)
        _ID = id
        _FechaHora = fechaHora
        _Formato = formato
        _Contenido = contenido
        _Remitente = remitente
        _DiagnosticoPrimarioConConsulta = diagnosticoPrimarioConConsulta
    End Sub

    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property

    Public ReadOnly Property FechaHora As Date
        Get
            Return _FechaHora
        End Get
    End Property

    Public ReadOnly Property Formato As FormatosMensajeAdmitidos
        Get
            Return _Formato
        End Get
    End Property

    Public ReadOnly Property Contenido As Byte()
        Get
            Return _Contenido
        End Get
    End Property

    Public ReadOnly Property Remitente As TiposRemitente
        Get
            Return _Remitente
        End Get
    End Property

    Public ReadOnly Property DiagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta
        Get
            Return _DiagnosticoPrimarioConConsulta
        End Get
    End Property

    Public Overrides Function ToString() As String
        If _Formato = FormatosMensajeAdmitidos.TXT Then
            Return Encoding.UTF8.GetString(_Contenido)
        Else
            Return "Archivo " & _Formato.ToString
        End If
    End Function
End Class
