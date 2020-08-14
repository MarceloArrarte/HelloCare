Public Class DiagnosticoPrimarioConConsulta
    Inherits DiagnosticoPrimario
    Private ReadOnly _Medico As Medico
    Private ReadOnly _ComentariosAdicionales As String

    Public ReadOnly Property Medico As Medico
        Get
            Return _Medico
        End Get
    End Property

    Public ReadOnly Property ComentariosAdicionales As String
        Get
            Return _ComentariosAdicionales
        End Get
    End Property

    'Public Sub New(paciente As Paciente, enfermedades As List(Of Enfermedad), fechaHora As Date, medico As Medico,
    '               diagnosticosDiferenciales As List(Of DiagnosticoDiferencial), mensajes As List(Of Mensaje), comentariosAdicionales As String)
    '    MyBase.New(paciente, enfermedades, fechaHora, TiposDiagnosticosPrimarios.Con_Consulta)
    '    _Medico = medico
    '    _DiagnosticosDiferenciales = diagnosticosDiferenciales
    '    _Mensajes = mensajes
    '    _ComentariosAdicionales = comentariosAdicionales
    'End Sub

    Public Sub New(diagnosticoPrimario As DiagnosticoPrimario, comentariosAdicionales As String)
        MyBase.New(diagnosticoPrimario.ID, diagnosticoPrimario.Paciente, diagnosticoPrimario.Sintomas, diagnosticoPrimario.EnfermedadesDiagnosticadas,
                   diagnosticoPrimario.FechaHora, TiposDiagnosticosPrimarios.Con_Consulta)
        _Medico = Nothing
        _ComentariosAdicionales = comentariosAdicionales
    End Sub

    Public Sub New(id As Integer, paciente As Paciente, sintomas As List(Of Sintoma), enfermedades As EnfermedadesDiagnosticadas, fechaHora As Date,
                   medico As Medico, comentariosAdicionales As String)

        MyBase.New(id, paciente, sintomas, enfermedades, fechaHora, TiposDiagnosticosPrimarios.Con_Consulta)
        _Medico = medico
        _ComentariosAdicionales = comentariosAdicionales
    End Sub
End Class