Public Class Especialidad
    Private ReadOnly _ID As Integer
    Private ReadOnly _Nombre As String

    Public Sub New(nombre As String)
        _ID = Integer.MinValue
        _Nombre = nombre
    End Sub

    Public Sub New(id As Integer, nombre As String)
        _ID = id
        _Nombre = nombre
    End Sub

    Public ReadOnly Property id As Integer
        Get
            Return _ID
        End Get
    End Property

    Public ReadOnly Property nombre As String
        Get
            Return _Nombre
        End Get
    End Property
End Class
