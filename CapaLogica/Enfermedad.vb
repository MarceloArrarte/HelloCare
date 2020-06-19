Imports System.Collections.Generic

Public Class Enfermedad

    Private _Nombre As String
    Private _Recomendaciones As String
    Private _Gravedad As Integer
    Private _Descripcion As String


    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            Try
                If value.Length >= 100 Then
                    Throw New Exception("El largo del nombre no puede superar los 100 caracteres")
                End If
                _Nombre = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public Property Recomendaciones As String
        Get
            Return _Recomendaciones
        End Get
        Set(value As String)
            Try
                If value.Length >= 1000 Then
                    Throw New Exception("La cantidad de caracteres no puede ser superior a 1000 ")
                End If
                _Recomendaciones = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public Property Gravedad As Integer
        Get
            Return _Gravedad
        End Get
        Set(value As Integer)
            Try
                If value <= 0 Then
                    Throw New Exception("La gravedad no puede ser menor a 1")
                End If
                If value > 100 Then
                    Throw New Exception("La gravedad no puede ser superior a 100")
                End If
                _Gravedad = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")

            End Try
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            Try
                If value.Length >= 1000 Then
                    Throw New Exception("La cantidad de caracteres debe ser menor a 1000.")
                End If
                _Descripcion = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Sub New(nombre As String, recomendaciones As String, gravedad As Integer, descripcion As String)
        Me.Nombre = nombre
        Me.Recomendaciones = recomendaciones
        Me.Gravedad = gravedad
        Me.Descripcion = descripcion
    End Sub

    Public Overrides Function ToString() As String
        Return "Nombre: " + _Nombre.ToString() + " Descripción: " + _Descripcion.ToString() + " Gravedad: " + _Gravedad.ToString() + " Recomendaciones: " + _Recomendaciones.ToString()
    End Function
End Class
