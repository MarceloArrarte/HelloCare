Imports System.Collections.Generic

Public Class Enfermedad

    Private ReadOnly _Nombre As String
    Private ReadOnly _Recomendaciones As String
    Private ReadOnly _Gravedad As Integer
    Private ReadOnly _Descripcion As String


    Public ReadOnly Property Nombre As String
        Get
            Return _Nombre
        End Get
        'Set(value As String)
        '    Try
        '        If value.Length >= 100 Then
        '            Throw New Exception("El largo del nombre no puede superar los 100 caracteres")
        '        End If
        '        _Nombre = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Public ReadOnly Property Recomendaciones As String
        Get
            Return _Recomendaciones
        End Get
        'Set(value As String)
        '    Try
        '        If value.Length >= 1000 Then
        '            Throw New Exception("La cantidad de caracteres no puede ser superior a 1000 ")
        '        End If
        '        _Recomendaciones = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Public ReadOnly Property Gravedad As Integer
        Get
            Return _Gravedad
        End Get
        'Set(value As Integer)
        '    Try
        '        If value <= 0 Then
        '            Throw New Exception("La gravedad no puede ser menor a 1")
        '        End If
        '        If value > 100 Then
        '            Throw New Exception("La gravedad no puede ser superior a 100")
        '        End If
        '        _Gravedad = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")

        '    End Try
        'End Set
    End Property

    Public ReadOnly Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        'Set(value As String)
        '    Try
        '        If value.Length >= 1000 Then
        '            Throw New Exception("La cantidad de caracteres debe ser menor a 1000.")
        '        End If
        '        _Descripcion = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Sub New(nombre As String, recomendaciones As String, gravedad As String, descripcion As String)
        ' Manejo de errores de datos ingresados
        ' nombre tiene un valor nulo
        If nombre = Nothing Then
            Throw New ArgumentNullException("nombre", "No se ingresó el nombre de la enfermedad.")
        End If

        ' nombre supera el largo máximo
        If nombre.Length > 100 Then
            Throw New ArgumentException("El largo del nombre no puede superar los 100 caracteres.")
        End If

        ' descripcion supera el largo máximo
        If descripcion.Length > 1000 Then
            Throw New ArgumentException("El largo de la descripción no puede superar los 1000 caracteres.")
        End If

        ' gravedad no es un valor numérico entero
        Dim gravedadInt As Integer
        If Not Integer.TryParse(gravedad, gravedadInt) Then
            Throw New ArgumentException("La gravedad debe tener un valor numérico.")
        End If

        ' gravedad tiene un valor inválido
        If gravedadInt < 1 Or gravedadInt > 100 Then
            Throw New ArgumentException("El índice de gravedad de la enfermedad debe ser un entero entre 1 y 100.")
        End If

        ' recomendaciones supera el largo máximo
        If recomendaciones.Length > 1000 Then
            Throw New ArgumentException("El largo de las recomendaciones no puede superar los 1000 caracteres.")
        End If

        _Nombre = nombre
        _Descripcion = descripcion
        _Gravedad = gravedad
        _Recomendaciones = recomendaciones
    End Sub

    'Set(value As String)
    'Try
    'If value.Length >= 100 Then
    'Throw New Exception("El largo del nombre no puede superar los 100 caracteres")
    'End If
    '            _Nombre = value
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '        End Try
    'End Set

    'Set(value As String)
    'Try
    'If value.Length >= 1000 Then
    'Throw New Exception("La cantidad de caracteres no puede ser superior a 1000 ")
    'End If
    '            _Recomendaciones = value
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '        End Try
    'End Set

    'Set(value As Integer)
    'Try
    'If value <= 0 Then
    'Throw New Exception("La gravedad no puede ser menor a 1")
    'End If
    'If value > 100 Then
    'Throw New Exception("La gravedad no puede ser superior a 100")
    'End If
    '            _Gravedad = value
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")

    '        End Try
    'End Set

    'Set(value As String)
    'Try
    'If value.Length >= 1000 Then
    'Throw New Exception("La cantidad de caracteres debe ser menor a 1000.")
    'End If
    '            _Descripcion = value
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '        End Try
    'End Set

    Public Overrides Function ToString() As String
        Return "Nombre: " + _Nombre.ToString() + " Descripción: " + _Descripcion.ToString() + " Gravedad: " + _Gravedad.ToString() + " Recomendaciones: " + _Recomendaciones.ToString()
    End Function
End Class
