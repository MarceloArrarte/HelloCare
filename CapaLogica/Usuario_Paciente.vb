Public Class Usuario_Paciente
    Inherits Usuario
    Private _CI_Paciente As String

    'Constructor Usuario_Paciente'
    Sub New(ci As String, contrasena As String)
        MyBase.New(contrasena)
        _CI_Paciente = ci
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

End Class
