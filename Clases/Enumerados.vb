Public Module Enumerados
    Public Enum Clases
        DiagnosticoPrimario
        DiagnosticoDiferencial
        Enfermedad
        Especialidad
        Departamento
        Localidad
        Sintoma
        Usuario
        Mensaje
        Administrativo
        Paciente
        Medico
        DiagnosticoPrimarioConConsulta
    End Enum

    Public Enum TiposPersona
        Funcionario
        Paciente
    End Enum

    Public Enum TiposSexo
        M
        F
        O
    End Enum

    Public Enum TiposDiagnosticosPrimarios
        Sin_Consulta
        Con_Consulta
    End Enum

    Public Enum TiposUsuarios
        Paciente
        Medico
        Administrativo
    End Enum

    Public Enum FormatosAdmitidos
        PDF
        JPG
        JPEG
        PNG
        Texto
    End Enum

    Public Enum TiposRemitente
        Medico
        Paciente
    End Enum
End Module
