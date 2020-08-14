Public Class DiagnosticoPrimario
    Protected ReadOnly _ID As Integer
    Protected ReadOnly _Paciente As Paciente
    Protected ReadOnly _Sintomas As List(Of Sintoma)
    Protected ReadOnly _Enfermedades As EnfermedadesDiagnosticadas
    Protected ReadOnly _FechaHora As Date
    Protected ReadOnly _Tipo As TiposDiagnosticosPrimarios

    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property

    Public ReadOnly Property Paciente As Paciente
        Get
            Return _Paciente
        End Get
    End Property

    Public ReadOnly Property Sintomas As List(Of Sintoma)
        Get
            Return _Sintomas
        End Get
    End Property

    Public ReadOnly Property Sintomas(indice As Integer) As Sintoma
        Get
            Return _Sintomas(indice)
        End Get
    End Property

    Public ReadOnly Property Enfermedades As List(Of Enfermedad)
        Get
            Return _Enfermedades.Items
        End Get
    End Property

    Public ReadOnly Property EnfermedadesDiagnosticadas As EnfermedadesDiagnosticadas
        Get
            Return _Enfermedades
        End Get
    End Property

    Public ReadOnly Property Enfermedades(indice As Integer) As Enfermedad
        Get
            Return _Enfermedades.Item(indice)
        End Get
    End Property

    Public ReadOnly Property Probabilidad(indice As Integer) As Decimal
        Get
            Return _Enfermedades.Probabilidad(indice)
        End Get
    End Property

    Public ReadOnly Property FechaHora As Date
        Get
            Return _FechaHora
        End Get
    End Property

    Public ReadOnly Property Tipo As TiposDiagnosticosPrimarios
        Get
            Return _Tipo
        End Get
    End Property

    Public Sub New(paciente As Paciente, sintomas As List(Of Sintoma), enfermedades As EnfermedadesDiagnosticadas, fechaHora As Date,
                   tipo As TiposDiagnosticosPrimarios)
        ' Manejo de errores de datos ingresados
        ' Errores en la cédula
        'If Not Validaciones.Cedula(ciPaciente) Then
        '    Throw New ArgumentException("El número de cédula ingresado no corresponde con el dígito verificador.")
        'End If

        '' El nombre de la enfermedad está vacío
        'If nombreEnfermedad Is Nothing Then
        '    Throw New ArgumentNullException("nombreEnfermedad", "El nombre de la enfermedad diagnosticada se encuentra vacío.")
        'End If

        '' El nombre de la enfermedad excede el largo máximo
        'If nombreEnfermedad.Length > 100 Then
        '    Throw New ArgumentException("El nombre de la enfermedad diagnosticada excede el largo máximo.")
        'End If

        '' La fecha del diagnóstico es posterior al momento actual
        'If fechaHora > Now Then
        '    Throw New ArgumentException("La fecha del diagnóstico primario es posterior al momento actual.")
        'End If

        _ID = Integer.MinValue
        _Paciente = paciente
        _Sintomas = sintomas
        _Enfermedades = enfermedades
        _FechaHora = fechaHora
        _Tipo = tipo
    End Sub

    Public Sub New(id As Integer, paciente As Paciente, sintomas As List(Of Sintoma), enfermedades As EnfermedadesDiagnosticadas, fechaHora As Date,
                   tipo As TiposDiagnosticosPrimarios)
        _ID = id
        _Paciente = paciente
        _Sintomas = sintomas
        _Enfermedades = enfermedades
        _FechaHora = fechaHora
        _Tipo = tipo
    End Sub
End Class
