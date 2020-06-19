Public Class Usuario_Paciente
    Inherits Usuario
    Private _CI_Paciente As String

    'Constructor Usuario_Paciente'
    Sub New(ci As String, contrasena As String)
        MyBase.New(contrasena)
        Me.CI_Paciente = ci
    End Sub

    Public Property CI_Paciente As String
        Get
            Return _CI_Paciente
        End Get
        Set(value As String)
            Try
                If Validaciones.Cedula(value) Then
                    _CI_Paciente = value
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
            Dim pacienteRegistrado As Usuario_Paciente = Principal.BuscarUsuariosPacientes(ci_usuario).SingleOrDefault
            If pacienteRegistrado Is Nothing Then
                Throw New Exception("No se encontró un usuario de paciente para esta cédula.")
            End If
            If pacienteRegistrado.Contrasena = contrasena Then
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
