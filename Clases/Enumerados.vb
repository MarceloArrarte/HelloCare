﻿Public Module Enumerados
    Public Enum TiposObjeto
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

    Public Enum TiposSeleccionBD
        Habilitados
        Deshabilitados
        Ambos
    End Enum

    Public Enum TiposPersona
        Funcionario
        Paciente
    End Enum

    Public Enum TiposFuncionario
        Administrativo
        Medico
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

    Public Enum TiposUsuario
        Paciente
        Medico
        Administrativo
    End Enum

    Public Enum FormatosMensajeAdmitidos
        PDF
        JPG
        JPEG
        PNG
        TXT
    End Enum

    Public Enum TiposRemitente
        Medico
        Paciente
    End Enum
End Module
