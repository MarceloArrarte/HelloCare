Public Class Usuario_Paciente
    Inherits Usuario
    Private _CI_Paciente As String

    Public Property CI_Paciente As String
        Get
            Return _CI_Paciente
        End Get
        Set(value As String)
            _CI_Paciente = value
        End Set
    End Property

End Class
