Public MustInherit Class Usuario
    Private ReadOnly _Contrasena As String
    Public ReadOnly Property Contrasena As String
        Get
            Return _Contrasena
        End Get
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
