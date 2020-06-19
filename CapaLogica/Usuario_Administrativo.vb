Public Class Usuario_Administrativo
    Inherits Usuario
    Private _CI_Administrativo As String

    'Constructor usuario_administrativo'

    Sub New(ci As String, contrasena As String)
        MyBase.New(contrasena)
        Me.CI_Administrativo = ci
    End Sub

    Public Property CI_Administrativo As String
        Get
            Return _CI_Administrativo
        End Get
        Set(value As String)
            Try
                If Validaciones.Cedula(value) Then
                    _CI_Administrativo = value
                Else
                    Throw New Exception("El número de cédula ingresado no corresponde con el dígito verificador.")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public Shared Function Autenticar(ByVal ci_usuario As String, ByVal contrasena As String) As Boolean
        Try
            Dim administrativoRegistrado As Usuario_Administrativo = Principal.BuscarUsuariosAdministrativos(ci_usuario).SingleOrDefault
            If administrativoRegistrado Is Nothing Then
                Throw New Exception("No se encontró un usuario de administrativo para esta cédula.")
            End If
            If administrativoRegistrado.Contrasena = contrasena Then
                Return True
            Else
                Throw New Exception("La contraseña en incorrecta.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function
End Class
