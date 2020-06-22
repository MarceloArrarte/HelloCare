Public Class AsociacionSintoma
    Private ReadOnly _NombreEnfermedad As String
    Private ReadOnly _NombreSintoma As String
    Private ReadOnly _Frecuencia As Decimal

    Public ReadOnly Property NombreEnfermedad() As String
        Get
            Return _NombreEnfermedad
        End Get
        'Set(value As String)
        '    Try
        '        Dim existeEnfermedad As Boolean = False
        '        For Each e As Enfermedad In ListaEnfermedades
        '            If e.Nombre = value Then
        '                existeEnfermedad = True
        '            End If
        '        Next
        '        If Not existeEnfermedad Then
        '            Throw New Exception("La enfermedad a la que se intenta asociar el síntoma no existe.")
        '        End If

        '        _NombreEnfermedad = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Public ReadOnly Property NombreSintoma() As String
        Get
            Return _NombreSintoma
        End Get
        'Set(value As String)
        '    Try
        '        Dim existeSintoma As Boolean = False
        '        For Each s As Sintoma In ListaSintomas
        '            If s.Nombre = value Then
        '                existeSintoma = True
        '            End If
        '        Next
        '        If Not existeSintoma Then
        '            Throw New Exception("El síntoma que se intenta asociar no existe.")
        '        End If

        '        _NombreSintoma = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Public ReadOnly Property Frecuencia() As Decimal
        Get
            Return _Frecuencia
        End Get
        'Set(value As Decimal)
        '    Try
        '        If value < 0 Or value > 100 Then
        '            Throw New Exception("La frecuencia de un síntoma en una enfermedad debe ser un valor entre 0 y 100.")
        '        End If

        '        _Frecuencia = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Public Sub New(nombreEnfermedad As String, nombreSintoma As String, frecuencia As String)
        ' Manejo de errores de datos ingresados
        ' nombreEnfermedad es nulo
        If nombreEnfermedad Is Nothing Then
            Throw New ArgumentNullException("nombreEnfermedad", "No se ingresó el nombre de la enfermedad.")
        End If

        ' No existe una enfermedad con este nombre
        Dim existeEnfermedad As Boolean = False
        For Each e As Enfermedad In ListaEnfermedades
            If e.Nombre = nombreEnfermedad Then
                existeEnfermedad = True
            End If
        Next
        If Not existeEnfermedad Then
            Throw New ArgumentException("La enfermedad a la que se intenta asociar el síntoma no existe.")
        End If

        ' nombreSintoma es nulo
        If nombreSintoma Is Nothing Then
            Throw New ArgumentNullException("nombreSintoma", "No se ingresó el nombre del síntoma.")
        End If

        ' No existe un síntoma con este nombre
        Dim existeSintoma As Boolean = False
        For Each s As Sintoma In ListaSintomas
            If s.Nombre = nombreSintoma Then
                existeSintoma = True
            End If
        Next
        If Not existeSintoma Then
            Throw New ArgumentException("El síntoma que se intenta asociar no existe.")
        End If

        ' La frecuencia no es un valor numérico válido
        Dim frecuenciaDec As Decimal
        If Not Decimal.TryParse(frecuencia, frecuenciaDec) Then
            Throw New ArgumentException("Error al intentar asociar el síntoma con la enfermedad """ & nombreEnfermedad & """:" & vbNewLine & vbNewLine &
                                        "La frecuencia debe tener un valor numérico decimal.")
        End If

        ' La frecuencia no es un porcentaje válido
        If frecuencia < 0 Or frecuencia > 100 Then
            Throw New ArgumentException("La frecuencia de un síntoma en una enfermedad debe ser un valor entre 0 y 100.")
        End If

        _NombreEnfermedad = nombreEnfermedad
        _NombreSintoma = nombreSintoma
        _Frecuencia = frecuencia

        'Set(value As String)
        '    Try
        '    Dim existeEnfermedad As Boolean = False
        '    For Each e As Enfermedad In ListaEnfermedades
        '        If e.Nombre = value Then
        '            existeEnfermedad = True
        '        End If
        '    Next
        '    If Not existeEnfermedad Then
        '        Throw New Exception("La enfermedad a la que se intenta asociar el síntoma no existe.")
        '    End If

        '    _NombreEnfermedad = value
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
        'End Set

        'Set(value As String)
        '    Try
        '    Dim existeSintoma As Boolean = False
        '    For Each s As Sintoma In ListaSintomas
        '        If s.Nombre = value Then
        '            existeSintoma = True
        '        End If
        '    Next
        '    If Not existeSintoma Then
        '        Throw New Exception("El síntoma que se intenta asociar no existe.")
        '    End If

        '    _NombreSintoma = value
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
        'End Set

        'Set(value As Decimal)
        '    Try
        '    If value < 0 Or value > 100 Then
        '        Throw New Exception("La frecuencia de un síntoma en una enfermedad debe ser un valor entre 0 y 100.")
        '    End If

        '    _Frecuencia = value
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
        'End Set
    End Sub
End Class
