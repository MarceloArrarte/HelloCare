Public Class Usuario
    Private ReadOnly _ID As Integer
    Private ReadOnly _Contrasena As String
    Private ReadOnly _Persona As Persona
    Private ReadOnly _Tipo As TiposUsuario
    Private ReadOnly _Habilitado As Boolean

    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property

    Public ReadOnly Property Contrasena As String
        Get
            Return _Contrasena
        End Get
    End Property

    Public ReadOnly Property Persona As Persona
        Get
            Return _Persona
        End Get
    End Property

    Public ReadOnly Property Tipo As TiposUsuario
        Get
            Return _Tipo
        End Get
    End Property

    Public Sub New(contrasena As String, persona As Persona)
        ' Manejo de errores de datos ingresados
        ' contrasena tiene un valor nulo
        If contrasena Is Nothing Then
            Throw New ArgumentNullException("contrasena", "La contraseña se encuentra vacía.")
        End If

        If ID.Equals(Nothing) Then
            Throw New ArgumentNullException("ID", "ID se encuentra vacía.")
        End If

        ' contrasena excede el largo máximo
        If contrasena.Length > 100 Then
            Throw New ArgumentException("La clave es demasiado grande (más de 100 caracteres).")
        End If

        _ID = Integer.MinValue
        _Contrasena = contrasena
        _Persona = persona
        '_Tipo = persona.Tipo
        Select Case persona.GetType
            Case GetType(Paciente)
                _Tipo = TiposUsuario.Paciente
            Case GetType(Medico)
                _Tipo = TiposUsuario.Medico
            Case GetType(Administrativo)
                _Tipo = TiposUsuario.Administrativo
        End Select
        _Habilitado = True
    End Sub

    Public Sub New(id As Integer, contrasena As String, persona As Persona, habilitado As Boolean)
        _ID = id
        _Contrasena = contrasena
        _Persona = persona
        '_Tipo = persona.Tipo
        Select Case persona.GetType
            Case GetType(Paciente)
                _Tipo = TiposUsuario.Paciente
            Case GetType(Medico)
                _Tipo = TiposUsuario.Medico
            Case GetType(Administrativo)
                _Tipo = TiposUsuario.Administrativo
        End Select
        _Habilitado = habilitado
    End Sub
End Class