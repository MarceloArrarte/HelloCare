Imports Clases

Module Listados
    Public Function CargarTablaExtendida(entidad As Enumerados.Clases) As List(Of Object)
        Dim tablasASeleccionar As New List(Of String)
        SeleccionarTablas(tablasASeleccionar, entidad)

        Dim datos As New DataSet
        For Each s As String In tablasASeleccionar
            datos.Tables.Add(SelectSimple(s))
        Next
        ConexionBD.AplicarClavesExternas(datos)

        Dim listaObjetos As New List(Of Object)
        PoblarLista(listaObjetos, entidad, datos)
        Return listaObjetos
    End Function

    Private Sub SeleccionarTablas(ByRef tablasASeleccionar As List(Of String), entidad As Enumerados.Clases)
        Select Case entidad
            Case Enumerados.Clases.DiagnosticoPrimario
                tablasASeleccionar.AddRange({"diagnosticos_primarios", "personas", "pacientes", "sistema_diagnostica", "enfermedades"})

            Case Enumerados.Clases.DiagnosticoDiferencial
                tablasASeleccionar.AddRange({"diagnosticos_diferenciales", "diagnosticos_primarios_con_consulta", "enfermedades"})

            Case Enumerados.Clases.Enfermedad
                tablasASeleccionar.AddRange({"enfermedades", "cuadro_sintomatico", "sintomas"})

            Case Enumerados.Clases.Especialidad
                tablasASeleccionar.AddRange({"especialidades", "especialidades_medicos", "medicos", "enfermedades"})

            Case Enumerados.Clases.Departamento
                tablasASeleccionar.AddRange({"departamentos", "localidades"})

            Case Enumerados.Clases.Localidad
                tablasASeleccionar.AddRange({"localidades", "departamentos", "personas", "pacientes", "medicos", "administrativos"})

            Case Enumerados.Clases.Sintoma
                tablasASeleccionar.AddRange({"sintomas", "cuadro_sintomatico", "enfermedad"})

            Case Enumerados.Clases.Usuario
                tablasASeleccionar.AddRange({"usuarios", "personas", "pacientes", "medicos", "administrativos"})

            Case Enumerados.Clases.Mensaje
                tablasASeleccionar.AddRange({"mensajes", "diagnosticos_primarios_con_consulta"})

            Case Enumerados.Clases.Administrativo
                tablasASeleccionar.AddRange({"personas", "administrativos"})

            Case Enumerados.Clases.Paciente
                tablasASeleccionar.AddRange({"personas", "pacientes", "diagnosticos_primarios"})

            Case Enumerados.Clases.Medico
                tablasASeleccionar.AddRange({"personas", "medicos", "especialidades_medicos", "especialidades", "diagnosticos_primarios_con_consulta"})

            Case Enumerados.Clases.DiagnosticoPrimarioConConsulta
                tablasASeleccionar.AddRange({"diagnosticos_primarios", "diagnosticos_primarios_con_consulta", "medicos", "mensajes"})

        End Select
    End Sub

    Private Function SelectSimple(nombreTabla As String) As DataTable
        Dim comando As String = String.Format("SELECT * FROM {0}", nombreTabla)
        Dim datos As DataSet = ConexionBD.EjecutarConsulta(comando, nombreTabla)
        Dim tabla As DataTable = datos.Tables(nombreTabla)
        Return tabla
    End Function

    Private Sub PoblarLista(ByRef lista As List(Of Object), entidad As Enumerados.Clases, datos As DataSet)
        Select Case entidad
            Case Enumerados.Clases.DiagnosticoPrimario
                For Each rDiagnosticoPrimario As DataRow In datos.Tables("diagnosticos_primarios").Rows
                    Dim idDiagnosticoPrimario As Integer = rDiagnosticoPrimario("ID")
                    Dim fechaHoraDiagnosticoPrimario As Date = rDiagnosticoPrimario("FECHA_HORA")
                    Dim tipoDiagnosticoPrimario As TiposDiagnosticosPrimarios = [Enum].Parse(GetType(TiposDiagnosticosPrimarios), rDiagnosticoPrimario("TIPO"))

                    Dim rPaciente As DataRow = rDiagnosticoPrimario.GetChildRows("diagnosticos_primarios_ibfk_1").ToList.Single
                    Dim rPersona As DataRow = rPaciente.GetChildRows("pacientes_ibfk_1").ToList.Single

                    Dim idPaciente As Integer = rPersona("ID")
                    Dim ciPaciente As String = rPersona("CI")
                    Dim nombrePaciente As String = rPersona("NOMBRE")
                    Dim apellidoPaciente As String = rPersona("APELLIDO")
                    Dim correoPaciente As String = rPersona("CORREO")
                    Dim telefonoMovilPaciente As String = rPaciente("TELEFONOMOVIL")
                    Dim telefonoFijoPaciente As String = rPaciente("TELEFONOFIJO")
                    Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), rPaciente("SEXO"))
                    Dim fechaNacimientoPaciente As Date = rPaciente("FECHANACIMIENTO")
                    Dim callePaciente As String = rPaciente("CALLE")
                    Dim numeroPuertaPaciente As String = rPaciente("NUMEROPUERTA")
                    Dim apartamentoPaciente As String = ""
                    If TypeOf rPaciente("APARTAMENTO") IsNot DBNull Then
                        apartamentoPaciente = rPaciente("APARTAMENTO")
                    End If

                    Dim pacienteDiagnosticoPrimario As New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, Nothing,
                                                                    telefonoMovilPaciente, telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente,
                                                                    callePaciente, numeroPuertaPaciente, apartamentoPaciente)

                    Dim listaEnfermedadesDiagnosticoPrimario As New List(Of Enfermedad)
                    For Each rSistemaDiagnostica As DataRow In datos.Tables("sistema_diagnostica").Rows
                        If rSistemaDiagnostica.GetChildRows("sistema_diagnostica_ibfk_1").ToList.Single Is rDiagnosticoPrimario Then
                            For Each rEnfermedad As DataRow In rSistemaDiagnostica.GetChildRows("sistema_diagnostica_ibfk_2")
                                Dim idEnfermedad As Integer = rEnfermedad("ID")
                                Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
                                Dim recomendacionesEnfermedad As String = rEnfermedad("RECOMENDACIONES")
                                Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
                                Dim descripcionEnfermedad As String = rEnfermedad("DESCRIPCION")
                                Dim probabilidadEnfermedad As String = rSistemaDiagnostica("PROBABILIDAD")

                                Dim enfermedad As New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad,
                                                                 descripcionEnfermedad, Nothing, probabilidadEnfermedad)

                                listaEnfermedadesDiagnosticoPrimario.Add(enfermedad)
                            Next
                        End If
                    Next

                    lista.Add(New DiagnosticoPrimario(idDiagnosticoPrimario, pacienteDiagnosticoPrimario, listaEnfermedadesDiagnosticoPrimario,
                                                      fechaHoraDiagnosticoPrimario, tipoDiagnosticoPrimario))


                    'For Each rPersona As DataRow In datos.Tables("pacientes").Rows
                    '    If rPersona("ID") = rDiagnosticoPrimario("ID_PACIENTE") Then
                    '        Dim idPaciente As Integer = rPersona("ID")
                    '        Dim ciPaciente As String = rPersona("CI")
                    '        Dim nombrePaciente As String = rPersona("NOMBRE")
                    '        Dim apellidoPaciente As String = rPersona("APELLIDO")
                    '        Dim correoPaciente As String = rPersona("CORREO")

                    '    End If
                    'Next

                Next



                'Case Enumerados.Clases.DiagnosticoPrimario
                '    For Each r As DataRow In tabla.Rows
                '        Dim id As Integer = r("ID")
                '        Dim ci_paciente As String = r("CI_PACIENTE")
                '        Dim fechaHora As Date = r("FECHA_HORA")
                '        Dim tipo As TiposDiagnosticosPrimarios = r("TIPO")

                '        lista.Add(New DiagnosticoPrimario(id, ci_paciente, fechaHora, tipo))
                '    Next

                'Case Enumerados.Clases.Enfermedad
                '    For Each r As DataRow In tabla.Rows
                '        Dim id As Integer = r("ID")
                '        Dim nombre As String = r("NOMBRE")
                '        Dim recomendaciones As String = r("RECOMENDACIONES")
                '        Dim gravedad As Integer = r("GRAVEDAD")
                '        Dim descripcion As String = r("DESCRIPCION")
                '        Dim idEspecialidad As Integer = r("ID_ESPECIALIDAD")

                '        lista.Add(New Enfermedad(id, nombre, recomendaciones, gravedad, descripcion, idEspecialidad))
                '    Next

                'Case Enumerados.Clases.Especialidad
                '    For Each r As DataRow In tabla.Rows
                '        Dim id As Integer = r("ID")
                '        Dim nombre As String = r("NOMBRE")

                '        lista.Add(New Especialidad(id, nombre))
                '    Next

                'Case Enumerados.Clases.Localidad
                '    For Each r As DataRow In tabla.Rows
                '        Dim id As Integer = r("ID")
                '        Dim nombre As String = r("NOMBRE")
                '        Dim idDepartamento As Integer = r("ID_DEPARTAMENTO")

                '        lista.Add(New Localidad(id, nombre, idDepartamento))
                '    Next

                'Case Enumerados.Clases.Sintoma
                '    For Each r As DataRow In tabla.Rows
                '        Dim id As Integer = r("ID")
                '        Dim nombre As String = r("NOMBRE")
                '        Dim descripcion As String = r("DESCRIPCION")
                '        Dim recomendaciones As String = r("RECOMENDACIONES")
                '        Dim urgencia As Integer = r("URGENCIA")

                '        lista.Add(New Sintoma(id, nombre, descripcion, recomendaciones, urgencia))
                '    Next

                'Case Enumerados.Clases.Usuario
                '    For Each r As DataRow In tabla.Rows
                '        Dim id As Integer = r("ID")
                '        Dim ciPaciente As String = r("CI_PACIENTE")
                '        Dim contrasena As String = r("CONTRASENIA")
                '        Dim tipo As TiposUsuarios = r("TIPO")

                '        lista.Add(New Usuario(id, ciPaciente, contrasena, tipo))
                '    Next
        End Select
    End Sub


    'Private Function SelectSimple(entidad As Enumerados.Clases) As DataTable

    '    Dim nombreTabla As String
    '    'SeleccionarTabla(nombreTabla, entidad)
    '    Dim comando As String = String.Format("SELECT * FROM {0}", nombreTabla)
    '    Dim datos As DataSet = ConexionBD.EjecutarConsulta(comando, nombreTabla)

    '    Dim lista As New List(Of Object)
    '    Dim tabla As DataTable = datos.Tables(nombreTabla)
    '    Return tabla
    '    'PoblarLista(lista, entidad, tabla)
    'End Function

    'Private Sub SeleccionarTabla(ByRef nombreTabla As String, entidad As Enumerados.Clases)
    '    Select Case entidad
    '        Case Enumerados.Clases.DiagnosticoPrimario
    '            nombreTabla = "diagnosticos_primarios"

    '        Case Enumerados.Clases.DiagnosticoDiferencial
    '            nombreTabla = "diagnoticos_diferenciales"

    '        Case Enumerados.Clases.Enfermedad
    '            nombreTabla = "enfermedades"

    '        Case Enumerados.Clases.Especialidad
    '            nombreTabla = "especialidades"

    '        Case Enumerados.Clases.Localidad
    '            nombreTabla = "localidades"

    '        Case Enumerados.Clases.Sintoma
    '            nombreTabla = "sintomas"

    '        Case Enumerados.Clases.Usuario
    '            nombreTabla = "usuarios"

    '        Case Enumerados.Clases.Chat
    '            nombreTabla = "chats"

    '        Case Enumerados.Clases.Mensaje
    '            nombreTabla = "mensajes"
    '    End Select
    'End Sub



    'Public Function SelectConHerencia(entidad As ClasesConHerencia) As List(Of Object)

    '    Dim nombreTabla As String
    '    SeleccionarTabla(nombreTabla, entidad)
    '    Dim comando As String = String.Format("SELECT * FROM {0}", nombreTabla)
    '    Dim datos As DataSet = ConexionBD.EjecutarConsulta(comando, nombreTabla)

    '    Dim lista As New List(Of Object)
    '    Dim tabla As DataTable = datos.Tables(nombreTabla)
    '    PoblarLista(lista, entidad, tabla)

    'End Function

    'Private Sub SeleccionarTabla(ByRef nombreTabla As String, entidad As ClasesConHerencia)
    '    Select Case entidad
    '        Case ClasesConHerencia.Administrativo
    '            nombreTabla = "administrativos"

    '        Case ClasesConHerencia.Paciente
    '            nombreTabla = "pacientes"

    '        Case ClasesConHerencia.Medico
    '            nombreTabla = "medicos"

    '        Case ClasesConHerencia.DiagnosticoPrimarioConConsulta
    '            nombreTabla = "diagnosticos_primarios_con_consulta"
    '    End Select
    'End Sub

    'Private Sub PoblarLista(ByRef lista As List(Of Object), entidad As ClasesConHerencia, tabla As DataTable)
    'End Sub
End Module
