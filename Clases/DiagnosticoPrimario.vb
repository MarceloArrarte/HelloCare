Imports System

Public Class DiagnosticoPrimario
    Private ReadOnly _ID As Integer
    Private ReadOnly _CI_Paciente As String
    Private ReadOnly _FechaHora As Date
    Private ReadOnly _Tipo As TiposDiagnosticosPrimarios

    Public ReadOnly Property CI_Paciente As String
        Get
            Return _CI_Paciente
        End Get
    End Property

    Public ReadOnly Property FechaHora As Date
        Get
            Return _FechaHora
        End Get
    End Property

    Public Sub New(ciPaciente As String, fechaHora As Date, tipo As TiposDiagnosticosPrimarios)
        ' Manejo de errores de datos ingresados
        ' Errores en la cédula
        If Not Validaciones.Cedula(ciPaciente) Then
            Throw New ArgumentException("El número de cédula ingresado no corresponde con el dígito verificador.")
        End If

        ' El nombre de la enfermedad está vacío
        If nombreEnfermedad Is Nothing Then
            Throw New ArgumentNullException("nombreEnfermedad", "El nombre de la enfermedad diagnosticada se encuentra vacío.")
        End If

        ' El nombre de la enfermedad excede el largo máximo
        If nombreEnfermedad.Length > 100 Then
            Throw New ArgumentException("El nombre de la enfermedad diagnosticada excede el largo máximo.")
        End If

        ' La fecha del diagnóstico es posterior al momento actual
        If fechaHora > Now Then
            Throw New ArgumentException("La fecha del diagnóstico primario es posterior al momento actual.")
        End If

        _ID = Integer.MinValue
        _CI_Paciente = ciPaciente
        _FechaHora = fechaHora
        _Tipo = tipo
    End Sub

    Public Sub New(id As Integer, ciPaciente As String, fechaHora As Date, tipo As TiposDiagnosticosPrimarios)
        _ID = id
        _CI_Paciente = ciPaciente
        _FechaHora = fechaHora
        _Tipo = tipo
    End Sub
End Class
