Public Class Departamento
    Private ReadOnly _ID As Integer
    Private ReadOnly _Nombre As String

    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property

    Public ReadOnly Property Nombre As String
        Get
            Return _Nombre
        End Get
    End Property

    Public Sub New(id As Integer, nombre As String)
        _ID = id
        _Nombre = nombre
    End Sub

    Public Overrides Function ToString() As String
        Return _Nombre
    End Function
End Class