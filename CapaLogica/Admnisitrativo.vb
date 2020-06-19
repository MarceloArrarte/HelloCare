Imports System.IO

Public Class Admnisitrativo
    Inherits Persona

    Private ReadOnly _CI_Persona As String
    Private ReadOnly _EsEncargado As Boolean

    Public ReadOnly Property CI_Persona As String
        Get
            Return _CI_Persona
        End Get
        'Set(value As String)
        '    Try
        '        If Validaciones.Cedula(value) Then
        '            _CI_Persona = value
        '        Else
        '            Throw New Exception("El número de cédula ingresado no corresponde con el dígito verificador.")
        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Public ReadOnly Property EsEncargado As Boolean
        Get
            Return _EsEncargado
        End Get
        'Set(value As Boolean)
        '    Try
        '        If value = _EsEncargado Then
        '            Throw New Exception(String.Format("Este administrativo ya tiene el rol de {0}.", IIf(_EsEncargado, "encargado", "empleado")))
        '        Else
        '            _EsEncargado = value
        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
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


    'Try
    '    If Validaciones.Cedula(value) Then
    '        _CI_Persona = value
    '    Else
    '        Throw New Exception("El número de cédula ingresado no corresponde con el dígito verificador.")
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    'End Try
    'Try
    '    If value = _EsEncargado Then
    '        Throw New Exception(String.Format("Este administrativo ya tiene el rol de {0}.", IIf(_EsEncargado, "encargado", "empleado")))
    '    Else
    '        _EsEncargado = value
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    'End Try
End Class
