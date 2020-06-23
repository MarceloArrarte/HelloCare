Public Class Usuario_Administrativo
    Inherits Usuario
    Private ReadOnly _CI_Administrativo As String

    Public ReadOnly Property CI_Administrativo As String
        Get
            Return _CI_Administrativo
        End Get
    End Property

    Sub New(ci As String, contrasena As String)
        MyBase.New(contrasena)
        If Not Validaciones.Cedula(ci) Then
            Throw New Exception("El número de cédula ingresado no corresponde con el dígito verificador.")
        End If

        _CI_Administrativo = ci
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
