Public Class Localidad
    Private _NombreLocalidad As String
    Private _Departamento As String

    Public Property NombreLocalidad1 As String
        Get
            Return _NombreLocalidad
        End Get
        Set(value As String)
            _NombreLocalidad = value
        End Set
    End Property

    Public Property Departamento As String
        Get
            Return _Departamento
        End Get
        Set(value As String)
            _Departamento = value
        End Set
    End Property

End Class
