Imports System

Public Class Diagnostico_Primario
    Private _CI_Paciente As String
    Private _FechaHora As DateTime
    Private _ListaEnfermedades As List(Of Enfermedad)

    Public Property CI_Paciente As String
        Get
            Return _CI_Paciente
        End Get
        Set(value As String)
            Try
                If Validaciones.Cedula(value) Then
                    _CI_Paciente = value
                Else
                    Throw New Exception("El número de cédula ingresado no corresponde con el dígito verificador.")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public Property FechaHora As Date
        Get
            Return _FechaHora
        End Get
        Set(value As Date)
            Try
                If _FechaHora <= Now Then
                    _FechaHora = value
                Else
                    Throw New Exception("La fecha del diagnóstico primario no es correcta.")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public ReadOnly Property ListaEnfermedades() As List(Of Enfermedad)
        Get
            Return _ListaEnfermedades
        End Get
    End Property
End Class
