Public Class Localidad
    Private ReadOnly _ID As Integer
    Private ReadOnly _Nombre As String
    Private ReadOnly _IDDepartamento As String

    Public ReadOnly Property Nombre As String
        Get
            Return _Nombre
        End Get
    End Property

    Public ReadOnly Property IDDepartamento As String
        Get
            Return _IDDepartamento
        End Get
    End Property

    Public Sub New(nombre As String, idDepartamento As Integer)
        ' Manejo de errores de datos ingresados
        ' nombre tiene un valor nulo
        If nombre = Nothing Then
            Throw New ArgumentNullException("nombre", "No se ingresó el nombre de la localidad.")
        End If

        ' nombre excede el máximo de caracteres
        If nombre.Length > 100 Then
            Throw New ArgumentException("El nombre de la localidad excede los 100 caracteres de largo.")
        End If

        _Nombre = nombre
        _IDDepartamento = idDepartamento
    End Sub

    Public Sub New(id As Integer, nombre As String, idDepartamento As Integer)
        _ID = id
        _Nombre = nombre
        _IDDepartamento = idDepartamento
    End Sub
End Class
