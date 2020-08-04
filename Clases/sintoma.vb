Public Class Sintoma
    Private ReadOnly _ID As Integer
    Private ReadOnly _Recomendaciones As String
    Private ReadOnly _Nombre As String
    Private ReadOnly _Descripcion As String
    Private ReadOnly _Urgencia As Integer
    Private ReadOnly _Frecuencia As Decimal

    Public ReadOnly Property Recomendaciones As String
        Get
            Return _Recomendaciones
        End Get
    End Property

    Public ReadOnly Property Nombre As String
        Get
            Return _Nombre
        End Get
    End Property

    Public ReadOnly Property Descripcion As String
        Get
            Return _Descripcion
        End Get
    End Property

    Public ReadOnly Property Urgencia As Integer
        Get
            Return _Urgencia
        End Get
    End Property

    Public ReadOnly Property Frecuencia As Decimal
        Get
            Return _Frecuencia
        End Get
    End Property

    Public Sub New(nombre As String, descripcion As String, recomendaciones As String, urgencia As String, frecuencia As Decimal)
        ' Manejo de errores
        ' nombre tiene un valor nulo
        If nombre = Nothing Then
            Throw New ArgumentNullException("nombre", "No se ingresó el nombre del síntoma.")
        End If

        ' nombre excede el largo máximo
        If nombre.Length > 100 Then
            Throw New ArgumentException("El largo del nombre no debe superar los 100 caracteres.")
        End If

        ' descripcion excede el largo máximo
        If descripcion.Length > 1000 Then
            Throw New ArgumentException("El largo de la descripción no debe superar los 1000 caracteres.")
        End If

        ' urgencia no es un valor numérico entero
        Dim urgenciaInt As Integer
        If Not Integer.TryParse(urgencia, urgenciaInt) Then
            Throw New ArgumentException("La urgencia debe tener un valor numérico entero.")
        End If

        ' urgencia tiene un valor inválido
        If urgencia < 1 Or urgencia > 100 Then
            Throw New ArgumentException("La urgencia debe tener un valor numérico entero entre 1 y 100.")
        End If

        ' recomendaciones excede el largo máximo
        If recomendaciones.Length > 1000 Then
            Throw New ArgumentException("El largo de las recomendaciones no debe superar los 1000 caracteres.")
        End If

        _ID = Integer.MinValue
        _Nombre = nombre
        _Descripcion = descripcion
        _Urgencia = urgencia
        _Recomendaciones = recomendaciones
        _Frecuencia = frecuencia
    End Sub

    Public Sub New(id As Integer, nombre As String, descripcion As String, recomendaciones As String, urgencia As Integer)
        _ID = id
        _Nombre = nombre
        _Descripcion = descripcion
        _Urgencia = urgencia
        _Recomendaciones = recomendaciones
        _Frecuencia = Decimal.MinValue
    End Sub

    Public Overrides Function ToString() As String
        Return _Nombre
    End Function
End Class
