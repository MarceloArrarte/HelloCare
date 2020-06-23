Imports System

Public Class Diagnostico_Primario
    Private ReadOnly _CI_Paciente As String
    Private ReadOnly _NombreEnfermedad As String
    Private ReadOnly _FechaHora As Date
    Private ReadOnly _Coincidencia As Double

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

    Public Sub New(ciPaciente As String, nombreEnfermedad As String, fechaHora As Date, coincidencia As Double)
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

        ' La probabilidad es un valor no válido
        If coincidencia <= 0 Or coincidencia > 100 Then
            Throw New ArgumentException("El porcentaje de coincidencia debe ser un valor entre 0 y 100.")
        End If

        _CI_Paciente = ciPaciente
        _NombreEnfermedad = nombreEnfermedad
        _FechaHora = fechaHora
        _Coincidencia = coincidencia
    End Sub
End Class
