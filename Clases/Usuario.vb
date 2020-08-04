Public Class Usuario
    Private ReadOnly _ID As Integer
    Private ReadOnly _CIPaciente As String
    Private ReadOnly _Contrasena As String
    Private ReadOnly _Tipo As TiposUsuarios

    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property

    Public ReadOnly Property CIPaciente As String
        Get
            Return _CIPaciente
        End Get
    End Property

    Public ReadOnly Property Contrasena As String
        Get
            Return _Contrasena
        End Get
    End Property

    Public ReadOnly Property Tipo As TiposUsuarios
        Get
            Return _Tipo
        End Get
    End Property

    Public Sub New(ciPaciente As String, contrasena As String, tipo As TiposUsuarios)
        ' Manejo de errores de datos ingresados
        ' contrasena tiene un valor nulo
        If contrasena Is Nothing Then
            Throw New ArgumentNullException("contrasena", "La contraseña se encuentra vacía.")
        End If

        ' contrasena excede el largo máximo
        If contrasena.Length > 100 Then
            Throw New ArgumentException("La clave es demasiado grande (más de 100 caracteres).")
        End If

        _ID = Integer.MinValue
        _CIPaciente = ciPaciente
        _Contrasena = contrasena
        _Tipo = tipo
    End Sub

    Public Sub New(id As Integer, ciPaciente As String, contrasena As String, tipo As TiposUsuarios)
        _ID = id
        _CIPaciente = ciPaciente
        _Contrasena = contrasena
        _Tipo = tipo
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
