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

    ' Indica si una combinación de usuario y contraseña es válida, o lanza una excepción si no lo es
    Public Shared Function Autenticar(ByVal ci_usuario As String, ByVal contrasena As String) As Boolean
        Dim administrativoRegistrado As Usuario_Administrativo = BuscarUsuariosAdministrativos(ci_usuario).SingleOrDefault
        If administrativoRegistrado Is Nothing Then
            Throw New Exception("No se encontró un usuario de administrativo para esta cédula.")
        End If
        If administrativoRegistrado.Contrasena = contrasena Then
            Return True
        Else
            Throw New Exception("La contraseña en incorrecta.")
        End If
    End Function
End Class
