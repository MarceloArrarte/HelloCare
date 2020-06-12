Public Class Localidad
    Private _NombreLocalidad As String
    Private _Departamento As String

    Public Property NombreLocalidad1 As String
        Get
            Return _NombreLocalidad
        End Get
        Set(value As String)
            Try
                If value = Nothing Or value = "" Then
                    Throw New Exception("El atributo se encuentra vacío.")
                End If
                If value.Length >= 100 Then
                    Throw New Exception("El nombre de la localidad no puede superar los 100 caracteres")
                End If
                _NombreLocalidad = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public Property Departamento As String
        Get
            Return _Departamento
        End Get
        Set(value As String)
            Try
                If value = Nothing Or value = "" Then
                    Throw New Exception("El atributo se encuentra vacío.")
                End If
                If value.Length >= 100 Then
                    Throw New Exception("El nombre del departamento no puede superar los 100 caracteres")
                End If
                _Departamento = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

End Class
