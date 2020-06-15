Public Class Usuario_Administrativo
    Inherits Usuario
    Private _CI_Administrativo As String

    'Constructor usuario_administrativo'

    Sub New(ci As String, contrasena As String)
        MyBase.New(contrasena)
        _CI_Administrativo = ci
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
End Class
