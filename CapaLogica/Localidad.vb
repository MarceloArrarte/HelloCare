Public Class Localidad
    Private ReadOnly _Nombre As String
    Private ReadOnly _Departamento As String

    Public ReadOnly Property Nombre As String
        Get
            Return _Nombre
        End Get
        'Set(value As String)
        '    Try
        '        If value = Nothing Or value = "" Then
        '            Throw New Exception("El atributo se encuentra vacío.")
        '        End If
        '        If value.Length >= 100 Then
        '            Throw New Exception("El nombre de la localidad no puede superar los 100 caracteres")
        '        End If
        '        _Nombre = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Public ReadOnly Property Departamento As String
        Get
            Return _Departamento
        End Get
        'Set(value As String)
        '    Try
        '        If value = Nothing Or value = "" Then
        '            Throw New Exception("El atributo se encuentra vacío.")
        '        End If
        '        If value.Length >= 100 Then
        '            Throw New Exception("El nombre del departamento no puede superar los 100 caracteres")
        '        End If
        '           _Departamento = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Public Sub New(nombre As String, departamento As String)
        ' Manejo de errores de datos ingresados
        ' nombre tiene un valor nulo
        If nombre = Nothing Then
            Throw New ArgumentNullException("nombre", "No se ingresó el nombre de la localidad.")
        End If

        ' nombre excede el máximo de caracteres
        If nombre.Length > 100 Then
            Throw New ArgumentException("El nombre de la localidad excede los 100 caracteres de largo.")
        End If

        ' departamento tiene un valor nulo
        If departamento = Nothing Then
            Throw New ArgumentNullException("departamento", "No se ingresó el departamento de la localidad.")
        End If

        ' departamento excede el máximo de caracteres
        If departamento.Length > 100 Then
            Throw New ArgumentException("El nombre del departamento excede los 100 caracteres de largo.")
        End If

        _Nombre = nombre
        _Departamento = departamento
    End Sub
End Class
