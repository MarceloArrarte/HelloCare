Imports System.Security.Cryptography

Public Class Sintoma
    Private _Recomendaciones As String
    Private _Nombre As String
    Private _Descripcion As String
    Private _Urgencia As Integer

    Public Property Recomendaciones As String
        Get
            Return _Recomendaciones
        End Get
        Set(value As String)
            Try
                If value.Length >= 1000 Then
                    Throw New Exception("El largo de las recomendaciones no debe superar los 1000 caracteres.")
                End If
                _Recomendaciones = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            Try
                If value = Nothing Or value = "" Then
                    Throw New Exception("El nombre se encuentra vacío.")
                End If
                If value.Length >= 100 Then
                    Throw New Exception("El largo del nombre no debe superar los 100 caracteres.")
                End If
                _Nombre = value
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

    Public Property Urgencia As Integer
        Get
            Return _Urgencia
        End Get
        Set(value As Integer)
            Try
                If value < 0 Or value > 100 Then
                    Throw New Exception("El índice de urgencia debe ser un valor entero entre 0 y 100.")
                End If
                If value = Nothing Then
                    Throw New Exception("El índice de urgencia se encuentra vacío.")
                End If
                _Urgencia = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public Sub New(nombre As String, descripcion As String, recomendaciones As String, urgencia As Integer)
        If urgencia < 0 Or urgencia > 100 Or descripcion.Length >= 1000 Or nombre.Length > 100 Or recomendaciones.Length >= 1000 Then
            Throw New Exception("No se pudo crear el objeto.")
        End If


        Me.Nombre = nombre 'Then
        Me.Descripcion = descripcion
        Me.Recomendaciones = recomendaciones
        Me.Urgencia = urgencia
    End Sub

    Public Overrides Function ToString() As String
        Return "Nombre: " + _Nombre.ToString() + " Descripción: " + _Descripcion.ToString() + " Urgencia: " + _Urgencia.ToString() + " Recomendaciones: " + _Recomendaciones.ToString()
    End Function
End Class
