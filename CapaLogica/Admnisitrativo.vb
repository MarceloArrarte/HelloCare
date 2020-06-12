Public Class Admnisitrativo
    Inherits Persona

    Private _CI_Persona As String
    Private _EsEncargado As Boolean

    Public Property CI_Persona As String
        Get
            Return _CI_Persona
        End Get
        Set(value As String)
            Try
                If Validaciones.Cedula(value) Then
                    _CI_Persona = value
                Else
                    Throw New Exception("El número de cédula ingresado no corresponde con el dígito verificador.")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public Property EsEncargado As Boolean
        Get
            Return _EsEncargado
        End Get
        Set(value As Boolean)
            Try
                If value = _EsEncargado Then
                    Throw New Exception(String.Format("Este administrativo ya tiene el rol de {0}.", IIf(_EsEncargado, "encargado", "empleado")))
                Else
                    _EsEncargado = value
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property
End Class
