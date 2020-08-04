Public MustInherit Class Persona
    Private ReadOnly _ID As Integer
    Private ReadOnly _CI As String
    Private ReadOnly _Nombre As String
    Private ReadOnly _Apellido As String
    Private ReadOnly _Correo As String
    Private ReadOnly _Localidad As Localidad
    Private ReadOnly _Tipo As TiposPersona

    Protected ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property

    Protected ReadOnly Property CI As String
        Get
            Return _CI
        End Get
    End Property

    Protected ReadOnly Property Nombre As String
        Get
            Return _Nombre
        End Get
    End Property

    Protected ReadOnly Property Apellido As String
        Get
            Return _Apellido
        End Get
    End Property

    Protected ReadOnly Property Correo As String
        Get
            Return _Correo
        End Get
    End Property

    Protected ReadOnly Property Localidad As Localidad
        Get
            Return _Localidad
        End Get
    End Property

    Protected ReadOnly Property Tipo As TiposPersona
        Get
            Return _Tipo
        End Get
    End Property

    Protected Sub New(ci As String, nombre As String, apellido As String, correo As String, localidad As Localidad, tipo As TiposPersona)
        ' Manejo de errores de datos ingresados
        ' Célula equivocada o con formato equivocado
        If Not Validaciones.Cedula(ci) Then
            Throw New ArgumentException("El número de cédula ingresado no corresponde con el dígito verificador.")
        End If

        ' nombre tiene un valor nulo
        If nombre = Nothing Then
            Throw New ArgumentNullException("nombre", "El nombre se encuentra vacío.")
        End If

        ' nombre excede el largo máximo
        If nombre.Length >= 100 Then
            Throw New ArgumentException("El largo del apellido no debe superar los 100 caracteres.")
        End If

        ' apellido tiene un valor nulo
        If apellido = Nothing Then
            Throw New ArgumentNullException("apellido", "El apellido se encuentra vacío.")
        End If

        ' apellido excede el largo máximo
        If apellido.Length >= 100 Then
            Throw New ArgumentException("El largo del apellido no debe superar los 100 caracteres.")
        End If

        ' Correo con un formato inválido
        If Not Validaciones.CorreoElectronico(correo) Then
            Throw New ArgumentException("El correo no tiene un formato válido.")
        End If

        _CI = ci
        _Nombre = nombre
        _Apellido = apellido
        _Correo = correo
        _Localidad = localidad
        _Tipo = tipo
    End Sub

    Protected Sub New(id As Integer, ci As String, nombre As String, apellido As String,
                      correo As String, localidad As Localidad, tipo As Enumerados.TiposPersona)
        _ID = id
        _CI = ci
        _Nombre = nombre
        _Apellido = apellido
        _Correo = correo
        _Localidad = localidad
        _Tipo = tipo
    End Sub
End Class
