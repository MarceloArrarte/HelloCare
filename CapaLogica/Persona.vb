Public MustInherit Class Persona
    Private ReadOnly _CI As String
    Private ReadOnly _Nombre As String
    Private ReadOnly _Apellido As String
    Private ReadOnly _Correo As String
    Private ReadOnly _Localidad As Localidad

    Protected ReadOnly Property CI As String
        Get
            Return _CI
        End Get
        'Set(value As String)
        '    Try
        '        If Validaciones.Cedula(value) Then
        '            _CI = value
        '        Else
        '            Throw New Exception("El número de cédula ingresado no corresponde con el dígito verificador.")
        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        '    _CI = value
        'End Set
    End Property

    Protected ReadOnly Property Nombre As String
        Get
            Return _Nombre
        End Get
        'Set(value As String)
        '    Try
        '        If value = Nothing Or value = "" Then
        '            Throw New Exception("El nombre se encuentra vacío.")
        '        End If
        '        If value.Length >= 100 Then
        '            Throw New Exception("El largo del nombre no debe superar los 100 caracteres.")
        '        End If
        '        _Nombre = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try

        'End Set
    End Property

    Protected ReadOnly Property Apellido As String
        Get
            Return _Apellido
        End Get
        'Set(value As String)
        '    Try
        '        If value = Nothing Or value = "" Then
        '            Throw New Exception("El apellido se encuentra vacío.")
        '        End If
        '        If value.Length >= 100 Then
        '            Throw New Exception("El largo del apellido no debe superar los 100 caracteres.")
        '        End If
        '        _Apellido = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Protected ReadOnly Property Correo As String
        Get
            Return _Correo
        End Get
        'Set(value As String)
        '    Try
        '        If Validaciones.CorreoElectronico(value) Then
        '            _Correo = value
        '        Else
        '            Throw New Exception("El correo no tiene un formato válido.")
        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Protected ReadOnly Property Localidad As Localidad
        Get
            Return _Localidad
        End Get
        'Set(value As Localidad)
        '    Try
        '        If value Is Nothing Then
        '            Throw New Exception("La localidad se encuentra vacío.")
        '        End If
        '        _Localidad = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Protected Sub New(ci As String, nombre As String, apellido As String, correo As String, localidad As Localidad)
        ' Manejo de errores de datos ingresados
        ' Célula equivocada o con formato equivocado
        If Not Validaciones.Cedula(ci) Then
            Throw New ArgumentException("El número de cédula ingresado no corresponde con el dígito verificador.")
        End If

        ' nombre tiene un valor nulo
        If nombre = Nothing Then
            Throw New ArgumentNullException("El apellido se encuentra vacío.")
        End If

        ' nombre excede el largo máximo
        If nombre.Length >= 100 Then
            Throw New ArgumentException("El largo del apellido no debe superar los 100 caracteres.")
        End If

        ' apellido tiene un valor nulo
        If apellido = Nothing Then
            Throw New ArgumentNullException("El apellido se encuentra vacío.")
        End If

        ' apellido excede el largo máximo
        If apellido.Length >= 100 Then
            Throw New ArgumentException("El largo del apellido no debe superar los 100 caracteres.")
        End If

        ' Correo con un formato inválido
        If Not Validaciones.CorreoElectronico(correo) Then
            Throw New ArgumentException("El correo no tiene un formato válido.")
        End If

        ' localidad tiene un valor nulo
        If localidad Is Nothing Then
            Throw New ArgumentNullException("La localidad se encuentra vacío.")
        End If

        _CI = ci
        _Nombre = nombre
        _Apellido = apellido
        _Correo = correo
        _Localidad = localidad
    End Sub


End Class
