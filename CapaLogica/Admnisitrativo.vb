Imports System.IO

Public Class Admnisitrativo
    Inherits Persona

    Private ReadOnly _CI_Persona As String
    Private ReadOnly _EsEncargado As Boolean

    Public ReadOnly Property CI_Persona As String
        Get
            Return _CI_Persona
        End Get
    End Property

    Public ReadOnly Property EsEncargado As Boolean
        Get
            Return _EsEncargado
        End Get
    End Property

    Public Sub New(ci As String, nombre As String, apellido As String, correo As String, localidad As Localidad, encargado As Boolean)
        MyBase.New(ci, nombre, apellido, correo, localidad)

        ' Manejo de errores de datos ingresados
        ' Errores en la cédula
        If Not Validaciones.Cedula(ci) Then
            Throw New ArgumentException("El número de cédula ingresado no corresponde con el dígito verificador.")
        End If

        _CI_Persona = ci
        _EsEncargado = encargado
    End Sub
End Class
