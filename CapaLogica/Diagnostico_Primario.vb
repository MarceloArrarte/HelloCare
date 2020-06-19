Imports System

Public Class Diagnostico_Primario
    Private ReadOnly _CI_Paciente As String
    Private ReadOnly _FechaHora As Date

    Public ReadOnly Property CI_Paciente As String
        Get
            Return _CI_Paciente
        End Get
        'Set(value As String)
        '    Try
        '        If Validaciones.Cedula(value) Then
        '            _CI_Paciente = value
        '        Else
        '            Throw New Exception("El número de cédula ingresado no corresponde con el dígito verificador.")
        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Public ReadOnly Property FechaHora As Date
        Get
            Return _FechaHora
        End Get
        'Set(value As Date)
        '    Try
        '        If _FechaHora <= Now Then
        '            _FechaHora = value
        '        Else
        '            Throw New Exception("La fecha del diagnóstico primario no es correcta.")
        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Public Sub New(ciPaciente As String, fechaHora As Date)
        ' Manejo de errores de datos ingresados
        ' Errores en la cédula
        If Not Validaciones.Cedula(ciPaciente) Then
            Throw New ArgumentException("El número de cédula ingresado no corresponde con el dígito verificador.")
        End If

        ' La fecha del diagnóstico es posterior al momento actual
        If fechaHora > Now Then
            Throw New ArgumentException("La fecha del diagnóstico primario es posterior al momento actual.")
        End If

        _CI_Paciente = ciPaciente
        _FechaHora = fechaHora
    End Sub


    'Set(value As String)
    'Try
    'If Validaciones.Cedula(value) Then
    '                _CI_Paciente = value
    '            Else
    'Throw New Exception("El número de cédula ingresado no corresponde con el dígito verificador.")
    'End If
    'Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '        End Try
    'End Set

    'Set(value As Date)
    'Try
    'If _FechaHora <= Now Then
    '                _FechaHora = value
    '            Else
    'Throw New Exception("La fecha del diagnóstico primario no es correcta.")
    'End If
    'Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '        End Try
    'End Set
End Class
