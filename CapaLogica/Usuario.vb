Public MustInherit Class Usuario
    Private ReadOnly _Contrasena As String
    Public ReadOnly Property Contrasena As String
        Get
            Return _Contrasena
        End Get
        'Set(value As String)
        '    Try
        '        If value = Nothing Or value = "" Then
        '            Throw New Exception("La contraseña se encuentra vacía.")
        '        End If
        '        If value.Length > 100 Then
        '            Throw New Exception("La clave es demasiado grande (más de 100 caracteres).")
        '        End If
        '        _Contrasena = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Public Sub New(contrasena As String)
        ' Manejo de errores de datos ingresados
        ' contrasena tiene un valor nulo
        If contrasena Is Nothing Then
            Throw New ArgumentNullException("contrasena", "La contraseña se encuentra vacía.")
        End If

        ' contrasena excede el largo máximo
        If contrasena.Length > 100 Then
            Throw New ArgumentException("La clave es demasiado grande (más de 100 caracteres).")
        End If

        _Contrasena = contrasena
    End Sub
End Class
