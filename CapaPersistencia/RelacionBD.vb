Public Class RelacionBD
    Private _NombreRelacion As String
    Private _NombreTablaPrimaria As String
    Private _NombreClavePrimaria As String
    Private _NombreTablaExterna As String
    Private _NombreClaveExterna As String

    Public ReadOnly Property Nombre As String
        Get
            Return _NombreRelacion
        End Get
    End Property

    Public ReadOnly Property NombreTablaPrimaria As String
        Get
            Return _NombreTablaPrimaria
        End Get
    End Property

    Public ReadOnly Property NombreClavePrimaria As String
        Get
            Return _NombreClavePrimaria
        End Get
    End Property

    Public ReadOnly Property NombreTablaExterna As String
        Get
            Return _NombreTablaExterna
        End Get
    End Property

    Public ReadOnly Property NombreClaveExterna As String
        Get
            Return _NombreClaveExterna
        End Get
    End Property

    Public Sub New(nombreRelacion As String, nombreTablaPrimaria As String, nombreClavePrimaria As String,
                   nombreTablaExterna As String, nombreClaveExterna As String)
        _NombreRelacion = nombreRelacion
        _NombreTablaPrimaria = nombreTablaPrimaria
        _NombreClavePrimaria = nombreClavePrimaria
        _NombreTablaExterna = nombreTablaExterna
        _NombreClaveExterna = nombreClaveExterna
    End Sub

    Public Sub AgregarRelacion(ByRef datos As DataSet)
        Dim tablaPrim As DataTable = datos.Tables(NombreTablaPrimaria)
        Dim tablaExt As DataTable = datos.Tables(NombreTablaExterna)
        Dim relacion As New DataRelation(Nombre, tablaPrim.Columns(NombreClavePrimaria), tablaExt.Columns(NombreClaveExterna))
        datos.Relations.Add(relacion)
    End Sub
End Class
