Public Class EnfermedadesAsociadas
    Private ReadOnly _Items As List(Of Enfermedad)
    Private ReadOnly _Frecuencias As List(Of Decimal)

    Public ReadOnly Property Item(indice As Integer) As Enfermedad
        Get
            Return _Items(indice)
        End Get
    End Property

    Public ReadOnly Property Frecuencia(indice As Integer) As Decimal
        Get
            Return _Frecuencias(indice)
        End Get
    End Property

    Public ReadOnly Property Items As List(Of Enfermedad)
        Get
            Return _Items
        End Get
    End Property

    Public Sub New(enfermedades As List(Of Enfermedad), frecuencias As List(Of Decimal))
        _Items = enfermedades
        _Frecuencias = frecuencias
    End Sub
End Class
