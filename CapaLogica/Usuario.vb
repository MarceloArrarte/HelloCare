Public MustInherit Class Usuario
    Private _Contrasena As String

    Public Property Contrasena As String
        Get
            Return _Contrasena
        End Get
        Set(value As String)
            Try
                If value = Nothing Or value = "" Then
                    Throw New Exception("La contraseña se encuentra vacía.")
                End If
                If _Contrasena.Length > 100 Then
                    Throw New Exception("La clave es demasiado grande (más de 100 caracteres).")
                End If
                _Contrasena = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public Shared Function Autenticar(ByVal usuario As String, ByVal contrasena As String) As Boolean

    End Function

End Class
