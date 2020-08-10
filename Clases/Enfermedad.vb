﻿Imports System.Collections.Generic

Public Class Enfermedad

    Private ReadOnly _ID As Integer
    Private ReadOnly _Nombre As String
    Private ReadOnly _Recomendaciones As String
    Private ReadOnly _Gravedad As Integer
    Private ReadOnly _Descripcion As String
    Private ReadOnly _Sintomas As SintomasAsociados
    Private ReadOnly _Especialidad As Especialidad
    Private ReadOnly _Habilitada As Boolean

    Public ReadOnly Property Id As Integer
        Get
            Return _ID
        End Get
    End Property

    Public ReadOnly Property Nombre As String
        Get
            Return _Nombre
        End Get
    End Property

    Public ReadOnly Property Recomendaciones As String
        Get
            Return _Recomendaciones
        End Get
    End Property

    Public ReadOnly Property Gravedad As Integer
        Get
            Return _Gravedad
        End Get
    End Property

    Public ReadOnly Property Descripcion As String
        Get
            Return _Descripcion
        End Get
    End Property

    Public ReadOnly Property Sintoma(indice As Integer) As Sintoma
        Get
            Return _Sintomas.Item(indice)
        End Get
    End Property

    Public ReadOnly Property FrecuenciaSintoma(indice As Integer) As Decimal
        Get
            Return _Sintomas.Frecuencia(indice)
        End Get
    End Property

    Public ReadOnly Property Sintomas As List(Of Sintoma)
        Get
            Return _Sintomas.Items
        End Get
    End Property

    Public ReadOnly Property Especialidad As Especialidad
        Get
            Return _Especialidad
        End Get
    End Property

    Public ReadOnly Property Habilitada As Boolean
        Get
            Return _Habilitada
        End Get
    End Property

    Public Sub New(nombre As String, recomendaciones As String, gravedad As String, descripcion As String, sintomas As SintomasAsociados,
            especialidad As Especialidad)
        ' Manejo de errores de datos ingresados
        ' nombre tiene un valor nulo
        If nombre = Nothing Then
            Throw New ArgumentNullException("nombre", "No se ingresó el nombre de la enfermedad.")
        End If

        ' nombre supera el largo máximo
        If nombre.Length > 100 Then
            Throw New ArgumentException("El largo del nombre no puede superar los 100 caracteres.")
        End If

        ' descripcion supera el largo máximo
        If descripcion.Length > 1000 Then
            Throw New ArgumentException("El largo de la descripción no puede superar los 1000 caracteres.")
        End If

        ' gravedad no es un valor numérico entero
        Dim gravedadInt As Integer
        If Not Integer.TryParse(gravedad, gravedadInt) Then
            Throw New ArgumentException("La gravedad debe tener un valor numérico.")
        End If

        ' gravedad tiene un valor inválido
        If gravedadInt < 1 Or gravedadInt > 100 Then
            Throw New ArgumentException("El índice de gravedad de la enfermedad debe ser un entero entre 1 y 100.")
        End If

        ' recomendaciones supera el largo máximo
        If recomendaciones.Length > 1000 Then
            Throw New ArgumentException("El largo de las recomendaciones no puede superar los 1000 caracteres.")
        End If

        _ID = Integer.MinValue
        _Nombre = nombre
        _Descripcion = descripcion
        _Gravedad = gravedad
        _Recomendaciones = recomendaciones
        _Especialidad = especialidad
        _Sintomas = sintomas
        _Habilitada = True
    End Sub

    Public Sub New(id As Integer, nombre As String, recomendaciones As String, gravedad As Integer, descripcion As String, sintomas As SintomasAsociados,
            especialidad As Especialidad, habilitada As Boolean)
        _ID = id
        _Nombre = nombre
        _Descripcion = descripcion
        _Gravedad = gravedad
        _Recomendaciones = recomendaciones
        _Especialidad = especialidad
        _Sintomas = sintomas
        _Habilitada = habilitada
    End Sub

    Public Overrides Function ToString() As String
        Return _Nombre
    End Function
End Class