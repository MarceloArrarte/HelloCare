Public Class Paciente

    Inherits Persona

    Private ReadOnly _TelefonoMovil As String
    Private ReadOnly _TelefonoFijo As String
    Private ReadOnly _Sexo As Char
    Private ReadOnly _FechaNacimiento As Date
    Private ReadOnly _Calle As String
    Private ReadOnly _NumeroPuerta As String
    Private ReadOnly _Apartamento As Integer
    Private ReadOnly _ListaDiagnosticosPrimarios As List(Of Diagnostico_Primario)

    Public ReadOnly Property TelefonoMovil As String
        Get
            Return _TelefonoMovil
        End Get
        ' Set(value As String)
        ' Try
        ' If value = Nothing Or value = "" Then
        '     Throw New Exception("El telefono movil se encuentra vacío.")
        ' End If
        'If value.Length > 9 Then
        '   Throw New Exception("El largo del telefono no puede ser superior a 9 caracteres")
        '  End If
        '  _TelefonoMovil = value
        '  Catch ex As Exception
        '   MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '  End Try
        ' End Set
    End Property

    Public ReadOnly Property TelefonoFijo As String
        Get
            Return _TelefonoFijo
        End Get
        'Set(value As String)
        '    Try
        '        If value = Nothing Or value = "" Then
        '            Throw New Exception("El telefono fijo se encuentra vacío.")
        '        End If
        '        If value.Length > 8 Then
        '            Throw New Exception("El largo del telefono no puede ser superior a 8 caracteres")
        '        End If
        '        _TelefonoFijo = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try

        'End Set
    End Property

    Public ReadOnly Property Sexo As Char
        Get
            Return _Sexo
        End Get
        'Set(value As Char)
        '    Try
        '        If value = Nothing Or value = "" Then
        '            Throw New Exception("El sexo se encuentra vacío.")
        '        End If
        '        If value <> "F" And value <> "M" And value <> "O" Then
        '            Throw New Exception("El sexo no puede ser diferente de: Femenino(F), Masculino(M) u Otro(0)")
        '        End If
        '        _Sexo = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property

    Public ReadOnly Property FechaNacimiento As Date
        Get
            Return _FechaNacimiento
        End Get
        'Set(value As Date)
        '    Try
        '        If _FechaNacimiento >= Now Then
        '            Throw New Exception("La fecha de nacimiento debe ser previa a la fecha actual")
        '        End If
        '        _FechaNacimiento = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property


    Public ReadOnly Property Calle As String
        Get
            Return _Calle
        End Get
        'Set(value As String)
        '    Try
        '        If value = Nothing Or value = "" Then
        '            Throw New Exception("La calle se encuentra vacía.")
        '        End If
        '        If value >= 100 Then
        '            Throw New Exception("La cantidad de caracteres debe ser menor a 100")
        '        End If
        '        _Calle = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property


    Public ReadOnly Property NumeroPuerta As String
        Get
            Return _NumeroPuerta
        End Get
        'Set(value As String)
        '    Try
        '        If value = Nothing Or value = "" Then
        '            Throw New Exception("El numero de puerta se encuentra vacío.")
        '        End If
        '        If value.Length >= 100 Then
        '            Throw New Exception("El largo del numero de puerta no puede superar los 100 caracteres")
        '        End If
        '        _NumeroPuerta = value
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '    End Try
        'End Set
    End Property


    Public ReadOnly Property Apartamento As Integer
        Get
            Return _Apartamento
        End Get
        'Set(value As Integer)
        '    _Apartamento = value
        'End Set
    End Property

    Public ReadOnly Property ListaDiagnosticoPrimario() As List(Of Diagnostico_Primario)
        Get
            Return _ListaDiagnosticosPrimarios
        End Get
    End Property



    Sub New(ci As String, nombre As String, apellido As String, correo As String, localidad As Localidad, telefonoMovil As String,
                   telefonoFijo As String, sexo As Char, fechaNacimiento As Date, calle As String, numeroPuerta As String, apartamento As Integer)

        MyBase.New(ci, nombre, apellido, correo, localidad)

        ' Manejo de errores de datos ingresados
        ' telefonoMovil tiene un valor nulo
        If telefonoMovil Is Nothing Then
            Throw New ArgumentNullException("No se ingresó el telefono móvil del paciente.")
        End If

        ' telefonoMovil excede el largo máximo
        If telefonoMovil.Length >= 9 Then
            Throw New ArgumentException("El telefono móvil no puede tener mas de 9 caracteres.")
        End If

        ' telefonoFijo tiene un valor nulo
        If telefonoFijo Is Nothing Then
            Throw New ArgumentNullException("No se ingresó el teléfono fijo del paciente.")
        End If

        ' telefonoFijo excede el largo máximo
        If telefonoMovil.Length >= 8 Then
            Throw New ArgumentException("El teléfono fijo no puede tener mas de 8 caracteres.")
        End If

        ' sexo tiene un valor nulo
        If sexo = Nothing Then
            Throw New ArgumentNullException("No se ingresó el sexo del paciente.")
        End If

        ' sexo no tiene un valor válido
        If sexo.ToString.ToUpper <> "M" And sexo.ToString.ToUpper <> "F" And sexo.ToString.ToUpper <> "O" Then
            Throw New ArgumentException("No se ingresó un sexo válido.")
        End If

        ' fechaNacimiento tiene un valor nulo
        If fechaNacimiento = Nothing Then
            Throw New ArgumentNullException("No se ingresó la fecha de nacimiento.")
        End If

        ' fechaNacimiento representa un valor posterior al momento actual
        If fechaNacimiento > Now Then
            Throw New ArgumentException("La fecha ingresada no es correcta.")
        End If

        ' calle tiene un valor nulo
        If calle Is Nothing Then
            Throw New ArgumentNullException("No se ingresó la calle del paciente.")
        End If

        ' calle excede el largo máximo
        If calle.Length >= 100 Then
            Throw New ArgumentException("La calle no puede tener más de 100 caracteres")
        End If

        ' numeroPuerta tiene un valor nulo
        If numeroPuerta Is Nothing Then
            Throw New ArgumentNullException("No se ingresó un número de puerta")
        End If

        ' numeroPuerta excede el largo máximo
        If numeroPuerta.Length > 10 Then
            Throw New ArgumentException("La calle no puede tener más de 10 caracteres")
        End If

        ' apartamento es un número negativo
        If apartamento < 0 Then
            Throw New ArgumentException("El apartamento no puede ser un número negativo.")
        End If

        _TelefonoMovil = telefonoMovil
        _TelefonoFijo = telefonoFijo
        _Sexo = sexo
        _FechaNacimiento = fechaNacimiento
        _Calle = calle
        _NumeroPuerta = numeroPuerta
        _Apartamento = apartamento
        _ListaDiagnosticosPrimarios = New List(Of Diagnostico_Primario)
    End Sub
    Public Sub Diagnosticar(sintomas As List(Of Sintoma))

    End Sub
End Class
