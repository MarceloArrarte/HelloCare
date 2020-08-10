Public Class Paciente
    Inherits Persona

    Private ReadOnly _TelefonoMovil As String
    Private ReadOnly _TelefonoFijo As String
    Private ReadOnly _Sexo As TiposSexo
    Private ReadOnly _FechaNacimiento As Date
    Private ReadOnly _Calle As String
    Private ReadOnly _NumeroPuerta As String
    Private ReadOnly _Apartamento As String

    Public ReadOnly Property TelefonoMovil As String
        Get
            Return _TelefonoMovil
        End Get
    End Property

    Public ReadOnly Property TelefonoFijo As String
        Get
            Return _TelefonoFijo
        End Get
    End Property

    Public ReadOnly Property Sexo As TiposSexo
        Get
            Return _Sexo
        End Get
    End Property

    Public ReadOnly Property FechaNacimiento As Date
        Get
            Return _FechaNacimiento
        End Get
    End Property

    Public ReadOnly Property Calle As String
        Get
            Return _Calle
        End Get
    End Property

    Public ReadOnly Property NumeroPuerta As String
        Get
            Return _NumeroPuerta
        End Get
    End Property

    Public ReadOnly Property Apartamento As String
        Get
            Return _Apartamento
        End Get
    End Property

    Sub New(ci As String, nombre As String, apellido As String, correo As String, localidad As Localidad, telefonoMovil As String,
            telefonoFijo As String, sexo As TiposSexo, fechaNacimiento As Date, calle As String, numeroPuerta As String, apartamento As String)

        MyBase.New(ci, nombre, apellido, correo, localidad, TiposPersona.Paciente)

        ' Manejo de errores de datos ingresados
        ' telefonoMovil tiene un valor nulo
        If telefonoMovil Is Nothing Then
            Throw New ArgumentNullException("telefonoMovil", "No se ingresó el telefono móvil del paciente.")
        End If

        ' telefonoMovil excede el largo máximo
        If telefonoMovil.Length > 9 Then
            Throw New ArgumentException("El telefono móvil no puede tener mas de 9 caracteres.")
        End If

        ' telefonoFijo tiene un valor nulo
        If telefonoFijo Is Nothing Then
            Throw New ArgumentNullException("telefonoFijo", "No se ingresó el teléfono fijo del paciente.")
        End If

        ' telefonoFijo excede el largo máximo
        If telefonoMovil.Length > 8 Then
            Throw New ArgumentException("El teléfono fijo no puede tener mas de 8 caracteres.")
        End If

        ' sexo no tiene un valor válido
        If Not {"M", "F", "O"}.Contains(sexo.ToString.ToUpper) Then
            Throw New ArgumentException("No se ingresó un sexo válido.")
        End If

        ' fechaNacimiento tiene un valor nulo
        If fechaNacimiento = Nothing Then
            Throw New ArgumentNullException("fechaNacimiento", "No se ingresó la fecha de nacimiento.")
        End If

        ' fechaNacimiento representa un valor posterior al momento actual
        If fechaNacimiento > Now Then
            Throw New ArgumentException("La fecha ingresada no es correcta.")
        End If

        ' calle tiene un valor nulo
        If calle Is Nothing Then
            Throw New ArgumentNullException("calle", "No se ingresó la calle del paciente.")
        End If

        ' calle excede el largo máximo
        If calle.Length >= 100 Then
            Throw New ArgumentException("La calle no puede tener más de 100 caracteres")
        End If

        ' numeroPuerta tiene un valor nulo
        If numeroPuerta Is Nothing Then
            Throw New ArgumentNullException("numeroPuerta", "No se ingresó un número de puerta")
        End If

        ' numeroPuerta excede el largo máximo
        If numeroPuerta.Length > 10 Then
            Throw New ArgumentException("La calle no puede tener más de 10 caracteres")
        End If

        _TelefonoMovil = telefonoMovil
        _TelefonoFijo = telefonoFijo
        _Sexo = sexo
        _FechaNacimiento = fechaNacimiento
        _Calle = calle
        _NumeroPuerta = numeroPuerta
        _Apartamento = apartamento
    End Sub

    Sub New(id As Integer, ci As String, nombre As String, apellido As String, correo As String, localidad As Localidad, telefonoMovil As String,
            telefonoFijo As String, sexo As TiposSexo, fechaNacimiento As Date, calle As String, numeroPuerta As String, apartamento As String)
        MyBase.New(id, ci, nombre, apellido, correo, localidad, TiposPersona.Paciente)
        _TelefonoMovil = telefonoMovil
        _TelefonoFijo = telefonoFijo
        _Sexo = sexo
        _FechaNacimiento = fechaNacimiento
        _Calle = calle
        _NumeroPuerta = numeroPuerta
        _Apartamento = apartamento
    End Sub
End Class
