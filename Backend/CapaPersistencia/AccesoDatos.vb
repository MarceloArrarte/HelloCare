Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Runtime.Remoting.Channels
Imports MySql.Data.MySqlClient
Imports MySql.Data.Types
Imports Clases
Imports System.Text
Imports System.Runtime.InteropServices.ComTypes
Imports System.Runtime.Serialization
Imports System.CodeDom

Public Module AccesoDatos
    Private Sub Main()
        Dim ci As String = "44623501"
        MsgBox(TienePersonaRegistrada(ci, TiposPersona.Paciente))
        Dim p As Paciente = ObtenerPacientePorCI(ci)
        MsgBox(TieneUsuarioRegistrado(p))
        Dim u As Usuario = ObtenerUsuarioPorPersona(p)
        Dim d As List(Of DiagnosticoPrimario) = ObtenerDiagnosticosPrimariosPorPaciente(p)
        Dim dd As List(Of DiagnosticoDiferencial) = ObtenerDiagnosticosDiferencialesPorDiagnosticoPrimarioConConsulta(d(2))
        Dim ms As List(Of Mensaje) = ObtenerUltimosMensajesPorDiagnosticoPrimarioConConsulta(d(2), 10)
    End Sub

    ' Dado un valor del enumerado Clases, devuelve una lista con los datos de todos los objetos de ese tipo almacenados en la BD.
    Public Function ObtenerListadoCompleto(entidad As TiposObjeto) As List(Of Object)
        Dim tablasASeleccionar As New List(Of String)
        AnotarTablas(tablasASeleccionar, entidad)

        Dim datos As New DataSet
        For Each t As String In tablasASeleccionar
            datos.Tables.Add(SeleccionarTabla(t, TiposSeleccionBD.Habilitados))
        Next
        ConexionBD.AplicarClavesExternas(datos)

        Dim listaObjetos As New List(Of Object)
        PoblarLista(listaObjetos, entidad, datos)
        Return listaObjetos
    End Function

    ' Agrega en la lista de String los nombres de las tablas que deben ser recorridas para completar los datos de cada clase.
    Private Sub AnotarTablas(ByRef tablasASeleccionar As List(Of String), entidad As TiposObjeto)
        Select Case entidad
            Case TiposObjeto.DiagnosticoPrimario
                tablasASeleccionar.AddRange({"diagnosticos_primarios", "pacientes", "personas", "sistema_diagnostica",
                                            "enfermedades"})

            Case TiposObjeto.DiagnosticoDiferencial
                tablasASeleccionar.AddRange({"diagnosticos_diferenciales", "diagnosticos_primarios",
                                            "diagnosticos_primarios_con_consulta", "enfermedades"})

            Case TiposObjeto.Enfermedad
                tablasASeleccionar.AddRange({"enfermedades", "cuadro_sintomatico", "sintomas",
                                            "especialidades"})

            Case TiposObjeto.Especialidad
                tablasASeleccionar.AddRange({"especialidades", "especialidades_medicos", "medicos", "funcionarios",
                                            "personas", "enfermedades"})

            Case TiposObjeto.Departamento
                tablasASeleccionar.AddRange({"departamentos", "localidades"})

            Case TiposObjeto.Localidad
                tablasASeleccionar.AddRange({"localidades", "departamentos", "personas", "pacientes", "funcionarios",
                                            "medicos", "administrativos"})

            Case TiposObjeto.Sintoma
                tablasASeleccionar.AddRange({"sintomas", "cuadro_sintomatico", "enfermedades"})

            Case TiposObjeto.Usuario
                tablasASeleccionar.AddRange({"usuarios", "personas", "pacientes", "funcionarios", "medicos", "administrativos"})

            Case TiposObjeto.Mensaje
                tablasASeleccionar.AddRange({"mensajes", "diagnosticos_primarios", "diagnosticos_primarios_con_consulta"})

            Case TiposObjeto.Administrativo
                tablasASeleccionar.AddRange({"administrativos", "personas", "funcionarios", "localidades"})

            Case TiposObjeto.Paciente
                tablasASeleccionar.AddRange({"pacientes", "personas", "localidades", "diagnosticos_primarios"})

            Case TiposObjeto.Medico
                tablasASeleccionar.AddRange({"medicos", "personas", "funcionarios", "localidades", "especialidades_medicos",
                                            "especialidades", "diagnosticos_primarios_con_consulta", "diagnosticos_primarios"})

            Case TiposObjeto.DiagnosticoPrimarioConConsulta
                tablasASeleccionar.AddRange({"diagnosticos_primarios_con_consulta", "diagnosticos_primarios", "personas",
                                            "pacientes", "funcionarios", "medicos", "mensajes", "sistema_diagnostica",
                                            "enfermedades"})

        End Select
    End Sub


    ' Llena una tabla con los datos de los registros de una tabla de la BD que cumplen con una condición.
    ' La condición pasada como argumento debe tener el siguiente formato: "columna""operador""valor"[, "columna2""operador2""valor"...]
    ' No incluir WHERE en este argumento
    Private Function SeleccionarTabla(nombreTabla As String, tipoSeleccion As TiposSeleccionBD, Optional condicion As String = "") As DataTable
        Dim comando As String = String.Format("SELECT * FROM {0} ", nombreTabla)

        If condicion <> "" Then
            comando &= "WHERE " & condicion
        End If

        Select Case tipoSeleccion
            Case TiposSeleccionBD.Habilitados
                If {"funcionarios", "enfermedades", "sintomas", "especialidades", "usuarios"}.Contains(nombreTabla) Then
                    If condicion <> "" Then
                        comando &= ", "
                    Else
                        comando &= "WHERE "
                    End If
                    comando &= "HABILITADO=TRUE"
                End If

            Case TiposSeleccionBD.Deshabilitados
                If {"funcionarios", "enfermedades", "sintomas", "especialidades", "usuarios"}.Contains(nombreTabla) Then
                    If condicion <> "" Then
                        comando &= ", "
                    Else
                        comando &= "WHERE "
                    End If
                    comando &= "HABILITADO=FALSE"
                End If
        End Select

        Dim tabla As DataTable = ConexionBD.EjecutarConsulta(comando, nombreTabla)
        'Dim datos As DataSet = ConexionBD.EjecutarConsulta(comando, nombreTabla)
        'Dim tabla As DataTable = datos.Tables(nombreTabla)
        Return tabla.Copy
    End Function

    ' Llena una lista con el tipo de objeto especificado, extraído del DataSet con los datos de la consulta a la BD.
    Private Sub PoblarLista(ByRef lista As List(Of Object), entidad As TiposObjeto, datos As DataSet)
        Select Case entidad
            Case TiposObjeto.DiagnosticoPrimario
                For Each rDiagnosticoPrimario As DataRow In datos.Tables("diagnosticos_primarios").Rows
                    Dim idDiagnosticoPrimario As Integer = rDiagnosticoPrimario("ID")
                    Dim fechaHoraDiagnosticoPrimario As Date = CType(rDiagnosticoPrimario("FECHA_HORA"), MySqlDateTime).Value
                    Dim tipoDiagnosticoPrimario As TiposDiagnosticosPrimarios = [Enum].Parse(GetType(TiposDiagnosticosPrimarios), rDiagnosticoPrimario("TIPO"))

                    Dim rPaciente As DataRow = rDiagnosticoPrimario.GetParentRow("diagnosticos_primarios_ibfk_1")
                    Dim rPersona As DataRow = rPaciente.GetParentRow("pacientes_ibfk_1")

                    Dim idPaciente As Integer = rPersona("ID")
                    Dim ciPaciente As String = rPersona("CI")
                    Dim nombrePaciente As String = rPersona("NOMBRE")
                    Dim apellidoPaciente As String = rPersona("APELLIDO")
                    Dim correoPaciente As String = rPersona("CORREO")
                    Dim telefonoMovilPaciente As String = rPaciente("TELEFONOMOVIL")
                    Dim telefonoFijoPaciente As String = rPaciente("TELEFONOFIJO")
                    Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), rPaciente("SEXO"))
                    Dim fechaNacimientoPaciente As Date = CType(rPaciente("FECHANACIMIENTO"), MySqlDateTime).Value
                    Dim callePaciente As String = rPaciente("CALLE")
                    Dim numeroPuertaPaciente As String = rPaciente("NUMEROPUERTA")
                    Dim apartamentoPaciente As String = ""
                    If TypeOf rPaciente("APARTAMENTO") IsNot DBNull Then
                        apartamentoPaciente = rPaciente("APARTAMENTO")
                    End If

                    Dim pacienteDiagnosticoPrimario As New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, Nothing,
                                                                    telefonoMovilPaciente, telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente,
                                                                    callePaciente, numeroPuertaPaciente, apartamentoPaciente)

                    Dim sintomasDiagnosticoPrimario As New List(Of Sintoma)
                    For Each rSistemaEvalua As DataRow In rDiagnosticoPrimario.GetChildRows("sistema_evalua_ibfk_1")
                        Dim rSintoma As DataRow = rSistemaEvalua.GetParentRow("sistema_evalua_ibfk_2")
                        Dim idSintoma As Integer = rSintoma("ID")
                        Dim nombreSintoma As String = rSintoma("NOMBRE")
                        Dim descripcionSintoma As String = rSintoma("DESCRIPCION")
                        Dim recomendacionesSintoma As String = rSintoma("RECOMENDACIONES")
                        Dim urgenciaSintoma As String = rSintoma("URGENCIA")
                        Dim habilitadoSintoma As Boolean = rSintoma("HABILITADO")

                        sintomasDiagnosticoPrimario.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma, Nothing, habilitadoSintoma))
                    Next

                    Dim enfermedadesDiagnosticoPrimario As New List(Of Enfermedad)
                    Dim probabilidadesEnfermedadesDiagnosticoPrimario As New List(Of Decimal)
                    For Each rSistemaDiagnostica As DataRow In rDiagnosticoPrimario.GetChildRows("sistema_diagnostica_ibfk_1")
                        Dim rEnfermedad As DataRow = rSistemaDiagnostica.GetParentRow("sistema_diagnostica_ibfk_2")

                        Dim idEnfermedad As Integer = rEnfermedad("ID")
                        Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
                        Dim recomendacionesEnfermedad As String = rEnfermedad("RECOMENDACIONES")
                        Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
                        Dim descripcionEnfermedad As String = rEnfermedad("DESCRIPCION")
                        Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")
                        Dim probabilidadEnfermedad As String = rSistemaDiagnostica("PROBABILIDAD")

                        enfermedadesDiagnosticoPrimario.Add(
                            New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad, descripcionEnfermedad,
                                           Nothing, Nothing, habilitadoEnfermedad))
                        probabilidadesEnfermedadesDiagnosticoPrimario.Add(probabilidadEnfermedad)
                    Next
                    Dim enfermedadesDiagnosticadasDiagnosticoPrimario As _
                        New EnfermedadesDiagnosticadas(enfermedadesDiagnosticoPrimario, probabilidadesEnfermedadesDiagnosticoPrimario)

                    lista.Add(New DiagnosticoPrimario(idDiagnosticoPrimario, pacienteDiagnosticoPrimario, sintomasDiagnosticoPrimario,
                                                      enfermedadesDiagnosticadasDiagnosticoPrimario, fechaHoraDiagnosticoPrimario, tipoDiagnosticoPrimario))
                Next

            Case TiposObjeto.DiagnosticoDiferencial
                For Each rDiagnosticoDiferencial As DataRow In datos.Tables("diagnosticos_diferenciales").Rows
                    Dim idDiagnosticoDiferencial As Integer = rDiagnosticoDiferencial("ID")
                    Dim conductaASeguirDiagnosticoDiferencial As String = rDiagnosticoDiferencial("CONDUCTA_A_SEGUIR")
                    Dim fechaHoraDiagnosticoDiferencial As Date = CType(rDiagnosticoDiferencial("FECHAHORA"), MySqlDateTime).Value

                    Dim rEnfermedad As DataRow = rDiagnosticoDiferencial.GetParentRow("diagnosticos_diferenciales_ibfk_2")

                    Dim idEnfermedad As Integer = rEnfermedad("ID")
                    Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
                    Dim descripcionEnfermedad As String = rEnfermedad("DESCRIPCION")
                    Dim recomendacionesEnfermedad As String = rEnfermedad("RECOMENDACIONES")
                    Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
                    Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")

                    Dim enfermedadDiagnosticoDiferencial As Enfermedad = New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad,
                                                                                        gravedadEnfermedad, descripcionEnfermedad, Nothing, Nothing,
                                                                                        habilitadoEnfermedad)

                    Dim rDiagnosticoPrimarioConConsulta As DataRow = rDiagnosticoDiferencial.GetParentRow("diagnosticos_diferenciales_ibfk_3")
                    Dim rDiagnosticoPrimario As DataRow = rDiagnosticoPrimarioConConsulta.GetParentRow("diagnosticos_primarios_con_consulta_ibfk_1")

                    Dim idDiagnosticoPrimarioConConsulta As Integer = rDiagnosticoPrimario("ID")
                    Dim fechaHoraDiagnosticoPrimarioConConsulta As Date = CType(rDiagnosticoPrimario("FECHA_HORA"), MySqlDateTime).Value
                    Dim comentariosAdicionalesDiagnosticoPrimarioConConsulta As String = rDiagnosticoPrimarioConConsulta("COMENTARIOS_ADICIONALES")

                    Dim diagnosticoPrimarioConConsultaDiagnosticoDiferencial As _
                        New DiagnosticoPrimarioConConsulta(idDiagnosticoPrimarioConConsulta, Nothing, Nothing, Nothing, fechaHoraDiagnosticoPrimarioConConsulta,
                                                           Nothing, comentariosAdicionalesDiagnosticoPrimarioConConsulta)

                    lista.Add(New DiagnosticoDiferencial(idDiagnosticoDiferencial, diagnosticoPrimarioConConsultaDiagnosticoDiferencial,
                                                         enfermedadDiagnosticoDiferencial, conductaASeguirDiagnosticoDiferencial, fechaHoraDiagnosticoDiferencial))
                Next

            Case TiposObjeto.Enfermedad
                For Each rEnfermedad As DataRow In datos.Tables("enfermedades").Rows
                    Dim idEnfermedad As Integer = rEnfermedad("ID")
                    Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
                    Dim recomendacionesEnfermedad As String = ""
                    If TypeOf rEnfermedad("RECOMENDACIONES") IsNot DBNull Then
                        recomendacionesEnfermedad = rEnfermedad("RECOMENDACIONES")
                    End If
                    Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
                    Dim descripcionEnfermedad As String = ""
                    If TypeOf rEnfermedad("DESCRIPCION") IsNot DBNull Then
                        descripcionEnfermedad = rEnfermedad("DESCRIPCION")
                    End If
                    Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")

                    Dim rEspecialidad As DataRow = rEnfermedad.GetParentRow("enfermedades_ibfk_1")

                    Dim idEspecialidad As Integer = rEspecialidad("ID")
                    Dim nombreEspecialidad As String = rEspecialidad("NOMBRE")
                    Dim habilitadoEspecialidad As Boolean = rEspecialidad("HABILITADO")

                    Dim especialidadEnfermedad As New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad)

                    Dim sintomasEnfermedad As New List(Of Sintoma)
                    Dim frecuenciasSintomasEnfermedad As New List(Of Decimal)
                    For Each rCuadroSintomatico As DataRow In rEnfermedad.GetChildRows("cuadro_sintomatico_ibfk_2")
                        Dim rSintoma As DataRow = rCuadroSintomatico.GetParentRow("cuadro_sintomatico_ibfk_1")

                        Dim idSintoma As Integer = rSintoma("ID")
                        Dim nombreSintoma As String = rSintoma("NOMBRE")
                        Dim descripcionSintoma As String = rSintoma("DESCRIPCION")
                        Dim recomendacionesSintoma As String = rSintoma("RECOMENDACIONES")
                        Dim urgenciaSintoma As Integer = rSintoma("URGENCIA")
                        Dim habilitadoSintoma As Boolean = rSintoma("HABILITADO")
                        Dim frecuenciaSintoma As Decimal = rCuadroSintomatico("FRECUENCIA")

                        sintomasEnfermedad.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma,
                                                           Nothing, habilitadoSintoma))
                        frecuenciasSintomasEnfermedad.Add(frecuenciaSintoma)
                    Next
                    Dim sintomasAsociadosEnferemedad As New SintomasAsociados(sintomasEnfermedad, frecuenciasSintomasEnfermedad)

                    lista.Add(New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad, descripcionEnfermedad,
                                             sintomasAsociadosEnferemedad, especialidadEnfermedad, habilitadoEnfermedad))
                Next

            Case TiposObjeto.Especialidad
                For Each rEspecialidad As DataRow In datos.Tables("especialidades").Rows
                    Dim idEspecialidad As Integer = rEspecialidad("ID")
                    Dim nombreEspecialidad As String = rEspecialidad("NOMBRE")
                    Dim habilitadoEspecialidad As Boolean = rEspecialidad("HABILITADO")

                    Dim listaMedicosEspecialidad As New List(Of Medico)
                    For Each rEspecialidadesMedicos As DataRow In rEspecialidad.GetChildRows("especialidades_medicos_ibfk_1")
                        Dim rMedico As DataRow = rEspecialidadesMedicos.GetParentRow("especialidades_medicos_ibfk_2")
                        Dim rFuncionario As DataRow = rMedico.GetParentRow("medicos_ibfk_1")
                        Dim rPersona As DataRow = rFuncionario.GetParentRow("funcionarios_ibfk_1")

                        Dim idMedico As Integer = rPersona("ID")
                        Dim ciMedico As String = rPersona("CI")
                        Dim nombreMedico As String = rPersona("NOMBRE")
                        Dim apellidoMedico As String = rPersona("APELLIDO")
                        Dim correoMedico As String = rPersona("CORREO")
                        Dim habilitadoMedico As Boolean = rFuncionario("HABILITADO")

                        listaMedicosEspecialidad.Add(New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, Nothing, Nothing,
                                                                habilitadoMedico))
                    Next

                    lista.Add(New Especialidad(idEspecialidad, nombreEspecialidad, listaMedicosEspecialidad, habilitadoEspecialidad))
                Next

            Case TiposObjeto.Departamento
                For Each rDepartamento As DataRow In datos.Tables("departamentos").Rows
                    Dim idDepartamento As Integer = rDepartamento("ID")
                    Dim nombreDepartamento As String = rDepartamento("NOMBRE")
                    lista.Add(New Departamento(idDepartamento, nombreDepartamento))
                Next

            Case TiposObjeto.Localidad
                For Each rLocalidad As DataRow In datos.Tables("localidades").Rows
                    Dim idLocalidad As Integer = rLocalidad("ID")
                    Dim nombreLocalidad As String = rLocalidad("NOMBRE")

                    Dim rDepartamento As DataRow = rLocalidad.GetParentRow("localidades_ibfk_1")
                    Dim idDepartamento As Integer = rDepartamento("ID")
                    Dim nombreDepartamento As String = rDepartamento("NOMBRE")

                    Dim departamentoLocalidad As New Departamento(idDepartamento, nombreDepartamento)
                    lista.Add(New Localidad(idLocalidad, nombreLocalidad, departamentoLocalidad))
                Next

            Case TiposObjeto.Sintoma
                For Each rSintoma As DataRow In datos.Tables("sintomas").Rows
                    Dim idSintoma As Integer = rSintoma("ID")
                    Dim nombreSintoma As String = rSintoma("NOMBRE")
                    Dim descripcionSintoma As String = ""
                    If TypeOf rSintoma("DESCRIPCION") IsNot DBNull Then
                        descripcionSintoma = rSintoma("DESCRIPCION")
                    End If
                    Dim recomendacionesSintoma As String = ""
                    If TypeOf rSintoma("RECOMENDACIONES") IsNot DBNull Then
                        recomendacionesSintoma = rSintoma("RECOMENDACIONES")
                    End If
                    Dim urgenciaSintoma As String = rSintoma("URGENCIA")
                    Dim habilitadoSintoma As Boolean = rSintoma("HABILITADO")

                    Dim enfermedadesSintoma As New List(Of Enfermedad)
                    Dim frecuenciasEnfermedadesSintomas As New List(Of Decimal)
                    For Each rCuadroSintomatico As DataRow In rSintoma.GetChildRows("cuadro_sintomatico_ibfk_1")
                        Dim rEnfermedad As DataRow = rCuadroSintomatico.GetParentRow("cuadro_sintomatico_ibfk_2")

                        Dim idEnfermedad As Integer = rEnfermedad("ID")
                        Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
                        Dim recomendacionesEnfermedad As String = ""
                        If TypeOf rEnfermedad("RECOMENDACIONES") IsNot DBNull Then
                            recomendacionesEnfermedad = rEnfermedad("RECOMENDACIONES")
                        End If
                        Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
                        Dim descripcionEnfermedad As String = ""
                        If TypeOf rEnfermedad("DESCRIPCION") IsNot DBNull Then
                            descripcionEnfermedad = rEnfermedad("DESCRIPCION")
                        End If
                        Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")
                        Dim frecuenciaEnfermedad As Decimal = rCuadroSintomatico("FRECUENCIA")

                        enfermedadesSintoma.Add(New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad,
                                                                    descripcionEnfermedad, Nothing, Nothing, habilitadoEnfermedad))
                        frecuenciasEnfermedadesSintomas.Add(frecuenciaEnfermedad)
                    Next
                    Dim enfermedadesAsociadasSintoma As New EnfermedadesAsociadas(enfermedadesSintoma, frecuenciasEnfermedadesSintomas)

                    lista.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma,
                                          enfermedadesAsociadasSintoma, habilitadoSintoma))
                Next

            Case TiposObjeto.Usuario
                For Each rUsuario As DataRow In datos.Tables("usuarios").Rows
                    Dim idUsuario As Integer = rUsuario("ID")
                    Dim contrasenaUsuario As String = rUsuario("CONTRASENIA")
                    Dim tipoUsuario As TiposUsuario = [Enum].Parse(GetType(TiposUsuario), rUsuario("TIPO"))
                    Dim habilitadoUsuario As Boolean = rUsuario("HABILITADO")

                    Dim personaUsuario As Persona = Nothing
                    Dim rPersona As DataRow = rUsuario.GetParentRow("usuarios_ibfk_1")
                    Select Case tipoUsuario
                        Case TiposUsuario.Paciente
                            Dim rPaciente As DataRow = rPersona.GetChildRows("pacientes_ibfk_1").Single

                            Dim idPaciente As Integer = rPersona("ID")
                            Dim ciPaciente As String = rPersona("CI")
                            Dim nombrePaciente As String = rPersona("NOMBRE")
                            Dim apellidoPaciente As String = rPersona("APELLIDO")
                            Dim correoPaciente As String = rPersona("CORREO")
                            Dim telefonoMovilPaciente As String = rPaciente("TELEFONOMOVIL")
                            Dim telefonoFijoPaciente As String = rPaciente("TELEFONOFIJO")
                            Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), rPaciente("SEXO"))
                            Dim fechaNacimientoPaciente As Date = CType(rPaciente("FECHANACIMIENTO"), MySqlDateTime).Value
                            Dim callePaciente As String = rPaciente("CALLE")
                            Dim numeroPuertaPaciente As String = rPaciente("NUMEROPUERTA")
                            Dim apartamentoPaciente As String = ""
                            If TypeOf rPaciente("APARTAMENTO") IsNot DBNull Then
                                apartamentoPaciente = rPaciente("APARTAMENTO")
                            End If

                            personaUsuario = New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, Nothing,
                                                          telefonoMovilPaciente, telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente,
                                                          callePaciente, numeroPuertaPaciente, apartamentoPaciente)

                        Case Else
                            Dim rFuncionario As DataRow = rPersona.GetChildRows("funcionarios_ibfk_1").Single
                            Select Case [Enum].Parse(GetType(TiposFuncionario), rFuncionario("TIPO"))
                                Case TiposFuncionario.Administrativo
                                    Dim rAdministrativo As DataRow = rFuncionario.GetChildRows("administrativos_ibfk_1").Single

                                    Dim idAdministrativo As Integer = rPersona("ID")
                                    Dim ciAdministrativo As String = rPersona("CI")
                                    Dim nombreAdministrativo As String = rPersona("NOMBRE")
                                    Dim apellidoAdministrativo As String = rPersona("APELLIDO")
                                    Dim correoAdministrativo As String = rPersona("CORREO")
                                    Dim esEncargadoAdministrativo As Boolean = rAdministrativo("ES_ENCARGADO")
                                    Dim habilitadoAdministrativo As Boolean = rFuncionario("HABILITADO")

                                    personaUsuario = New Administrativo(idAdministrativo, ciAdministrativo, nombreAdministrativo, apellidoAdministrativo,
                                                                        correoAdministrativo, Nothing, esEncargadoAdministrativo, habilitadoAdministrativo)

                                Case TiposFuncionario.Medico
                                    Dim idMedico As Integer = rPersona("ID")
                                    Dim ciMedico As String = rPersona("CI")
                                    Dim nombreMedico As String = rPersona("NOMBRE")
                                    Dim apellidoMedico As String = rPersona("APELLIDO")
                                    Dim correoMedico As String = rPersona("CORREO")
                                    Dim habilitadoMedico As Boolean = rFuncionario("HABILITADO")

                                    personaUsuario = New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, Nothing, Nothing,
                                                                habilitadoMedico)
                            End Select
                    End Select

                    lista.Add(New Usuario(idUsuario, contrasenaUsuario, personaUsuario, habilitadoUsuario))
                Next

            Case TiposObjeto.Mensaje
                For Each rMensaje As DataRow In datos.Tables("mensajes").Rows
                    Dim idMensaje As Integer = rMensaje("ID")
                    Dim fechaHoraMensaje As Date = CType(rMensaje("FECHAHORA"), MySqlDateTime).Value
                    Dim formatoMensaje As FormatosMensajeAdmitidos = [Enum].Parse(GetType(FormatosMensajeAdmitidos), rMensaje("FORMATO"))
                    Dim contenidoMensaje() As Byte = rMensaje("CONTENIDO")
                    Dim remitenteMensaje As TiposRemitente = [Enum].Parse(GetType(TiposRemitente), rMensaje("REMITENTE"))

                    Dim rDiagnosticoPrimarioConConsulta As DataRow = rMensaje.GetParentRow("mensajes_ibfk_1")
                    Dim rDiagnosticoPrimario As DataRow = rDiagnosticoPrimarioConConsulta.GetParentRow("diagnosticos_primarios_con_consulta_ibfk_1")

                    Dim idDiagnosticoPrimarioConConsulta As Integer = rDiagnosticoPrimario("ID")
                    Dim fechaHoraDiagnosticoPrimarioConConsulta As Date = CType(rDiagnosticoPrimario("FECHA_HORA"), MySqlDateTime).Value
                    Dim comentariosAdicionalesDiagnosticoPrimarioConConsulta As String = rDiagnosticoPrimarioConConsulta("COMENTARIOS_ADICIONALES")

                    Dim diagnosticoPrimarioConConsultaMensaje As _
                        New DiagnosticoPrimarioConConsulta(idDiagnosticoPrimarioConConsulta, Nothing, Nothing, Nothing, fechaHoraDiagnosticoPrimarioConConsulta,
                                                           Nothing, comentariosAdicionalesDiagnosticoPrimarioConConsulta)

                    lista.Add(New Mensaje(idMensaje, fechaHoraMensaje, formatoMensaje, contenidoMensaje, remitenteMensaje,
                                          diagnosticoPrimarioConConsultaMensaje))
                Next

            Case TiposObjeto.Administrativo
                For Each rAdministrativo As DataRow In datos.Tables("administrativos").Rows
                    Dim rFuncionario As DataRow = rAdministrativo.GetParentRow("administrativos_ibfk_1")
                    Dim rPersona As DataRow = rFuncionario.GetParentRow("funcionarios_ibfk_1")

                    Dim idAdministrativo As Integer = rPersona("ID")
                    Dim ciAdministrativo As String = rPersona("CI")
                    Dim nombreAdministrativo As String = rPersona("NOMBRE")
                    Dim apellidoAdministrativo As String = rPersona("APELLIDO")
                    Dim correoAdministrativo As String = rPersona("CORREO")
                    Dim esEncargadoAdministrativo As Boolean = rAdministrativo("ES_ENCARGADO")
                    Dim habilitadoAdministrativo As Boolean = rFuncionario("HABILITADO")

                    Dim rLocalidad As DataRow = rPersona.GetParentRow("personas_ibfk_1")
                    Dim idLocalidad As Integer = rLocalidad("ID")
                    Dim nombreLocalidad As String = rLocalidad("NOMBRE")

                    Dim localidadAdministrativo As New Localidad(idLocalidad, nombreLocalidad, Nothing)

                    lista.Add(New Administrativo(idAdministrativo, ciAdministrativo, nombreAdministrativo, apellidoAdministrativo,
                                                 correoAdministrativo, localidadAdministrativo, esEncargadoAdministrativo, habilitadoAdministrativo))
                Next

            Case TiposObjeto.Paciente
                For Each rPaciente As DataRow In datos.Tables("pacientes").Rows
                    Dim rPersona As DataRow = rPaciente.GetParentRow("pacientes_ibfk_1")

                    Dim idPaciente As Integer = rPersona("ID")
                    Dim ciPaciente As String = rPersona("CI")
                    Dim nombrePaciente As String = rPersona("NOMBRE")
                    Dim apellidoPaciente As String = rPersona("APELLIDO")
                    Dim correoPaciente As String = rPersona("CORREO")
                    Dim telefonoMovilPaciente As String = rPaciente("TELEFONOMOVIL")
                    Dim telefonoFijoPaciente As String = rPaciente("TELEFONOFIJO")
                    Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), rPaciente("SEXO"))
                    Dim fechaNacimientoPaciente As Date = CType(rPaciente("FECHANACIMIENTO"), MySqlDateTime).Value
                    Dim callePaciente As String = rPaciente("CALLE")
                    Dim numeroPuertaPaciente As String = rPaciente("NUMEROPUERTA")
                    Dim apartamentoPaciente As String = ""
                    If TypeOf rPaciente("APARTAMENTO") IsNot DBNull Then
                        apartamentoPaciente = rPaciente("APARTAMENTO")
                    End If

                    Dim rLocalidad As DataRow = rPersona.GetParentRow("personas_ibfk_1")
                    Dim idLocalidad As Integer = rLocalidad("ID")
                    Dim nombreLocalidad As String = rLocalidad("NOMBRE")

                    Dim localidadPaciente As New Localidad(idLocalidad, nombreLocalidad, Nothing)

                    lista.Add(New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, localidadPaciente,
                                           telefonoMovilPaciente, telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente,
                                           callePaciente, numeroPuertaPaciente, apartamentoPaciente))
                Next

            Case TiposObjeto.Medico
                For Each rMedico As DataRow In datos.Tables("medicos").Rows
                    Dim rFuncionario As DataRow = rMedico.GetParentRow("medicos_ibfk_1")
                    Dim rPersona As DataRow = rFuncionario.GetParentRow("funcionarios_ibfk_1")

                    Dim idMedico As Integer = rPersona("ID")
                    Dim ciMedico As String = rPersona("CI")
                    Dim nombreMedico As String = rPersona("NOMBRE")
                    Dim apellidoMedico As String = rPersona("APELLIDO")
                    Dim correoMedico As String = rPersona("CORREO")
                    Dim habilitadoMedico As Boolean = rFuncionario("HABILITADO")

                    Dim rLocalidad As DataRow = rPersona.GetParentRow("personas_ibfk_1")
                    Dim idLocalidad As Integer = rLocalidad("ID")
                    Dim nombreLocalidad As String = rLocalidad("NOMBRE")

                    Dim localidadMedico As New Localidad(idLocalidad, nombreLocalidad, Nothing)

                    Dim listaEspecialidadesMedico As New List(Of Especialidad)
                    For Each rEspecialidadesMedico As DataRow In rMedico.GetChildRows("especialidades_medicos_ibfk_2")
                        Dim rEspecialidad As DataRow = rEspecialidadesMedico.GetParentRow("especialidades_medicos_ibfk_1")

                        Dim idEspecialidad As Integer = rEspecialidad("ID")
                        Dim nombreEspecialidad As String = rEspecialidad("NOMBRE")
                        Dim habilitadoEspecialidad As Boolean = rEspecialidad("HABILITADO")

                        listaEspecialidadesMedico.Add(New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad))
                    Next

                    lista.Add(New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, localidadMedico, listaEspecialidadesMedico,
                                         habilitadoMedico))
                Next

            Case TiposObjeto.DiagnosticoPrimarioConConsulta
                For Each rDiagnosticoPrimarioConConsulta As DataRow In datos.Tables("diagnosticos_primarios_con_consulta").Rows
                    Dim rDiagnosticoPrimario As DataRow = rDiagnosticoPrimarioConConsulta.GetParentRow("diagnosticos_primarios_con_consulta_ibfk_1")

                    Dim idDiagnosticoPrimarioConConsulta As Integer = rDiagnosticoPrimario("ID")
                    Dim fechaHoraDiagnosticoPrimarioConConsulta As Date = CType(rDiagnosticoPrimario("FECHA_HORA"), MySqlDateTime).Value
                    Dim comentariosAdicionalesDiagnosticosPrimariosConConsulta As String = rDiagnosticoPrimarioConConsulta("COMENTARIOS_ADICIONALES")

                    Dim rPaciente As DataRow = rDiagnosticoPrimario.GetParentRow("diagnosticos_primarios_ibfk_1")
                    Dim rPersonaPaciente As DataRow = rPaciente.GetParentRow("pacientes_ibfk_1")

                    Dim idPaciente As Integer = rPersonaPaciente("ID")
                    Dim ciPaciente As String = rPersonaPaciente("CI")
                    Dim nombrePaciente As String = rPersonaPaciente("NOMBRE")
                    Dim apellidoPaciente As String = rPersonaPaciente("APELLIDO")
                    Dim correoPaciente As String = rPersonaPaciente("CORREO")
                    Dim telefonoMovilPaciente As String = rPaciente("TELEFONOMOVIL")
                    Dim telefonoFijoPaciente As String = rPaciente("TELEFONOFIJO")
                    Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), rPaciente("SEXO"))
                    Dim fechaNacimientoPaciente As Date = CType(rPaciente("FECHANACIMIENTO"), MySqlDateTime).Value
                    Dim callePaciente As String = rPaciente("CALLE")
                    Dim numeroPuertaPaciente As String = rPaciente("NUMEROPUERTA")
                    Dim apartamentoPaciente As String = ""
                    If TypeOf rPaciente("APARTAMENTO") IsNot DBNull Then
                        apartamentoPaciente = rPaciente("APARTAMENTO")
                    End If

                    Dim pacienteDiagnosticoPrimarioConConsulta As _
                        New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, Nothing,
                                     telefonoMovilPaciente, telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente,
                                     callePaciente, numeroPuertaPaciente, apartamentoPaciente)

                    Dim medicoDiagnosticoPrimarioConConsulta As Medico = Nothing
                    If TypeOf rDiagnosticoPrimarioConConsulta("ID_MEDICO") IsNot DBNull Then
                        Dim rMedico As DataRow = rDiagnosticoPrimarioConConsulta.GetParentRow("diagnosticos_primarios_con_consulta_ibfk_2")
                        Dim rFuncionario As DataRow = rMedico.GetParentRow("medicos_ibfk_1")
                        Dim rPersonaMedico As DataRow = rFuncionario.GetParentRow("funcionarios_ibfk_1")

                        Dim idMedico As Integer = rPersonaMedico("ID")
                        Dim ciMedico As String = rPersonaMedico("CI")
                        Dim nombreMedico As String = rPersonaMedico("NOMBRE")
                        Dim apellidoMedico As String = rPersonaMedico("APELLIDO")
                        Dim correoMedico As String = rPersonaMedico("CORREO")
                        Dim habilitadoMedico As Boolean = rFuncionario("HABILITADO")

                        medicoDiagnosticoPrimarioConConsulta = New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, Nothing,
                                                                          Nothing, habilitadoMedico)
                    End If

                    Dim sintomasDiagnosticoPrimario As New List(Of Sintoma)
                    For Each rSistemaEvalua As DataRow In rDiagnosticoPrimario.GetChildRows("sistema_evalua_ibfk_1")
                        Dim rSintoma As DataRow = rSistemaEvalua.GetParentRow("sistema_evalua_ibfk_2")
                        Dim idSintoma As Integer = rSintoma("ID")
                        Dim nombreSintoma As String = rSintoma("NOMBRE")
                        Dim descripcionSintoma As String = rSintoma("DESCRIPCION")
                        Dim recomendacionesSintoma As String = rSintoma("RECOMENDACIONES")
                        Dim urgenciaSintoma As String = rSintoma("URGENCIA")
                        Dim habilitadoSintoma As Boolean = rSintoma("HABILITADO")

                        sintomasDiagnosticoPrimario.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma, Nothing, habilitadoSintoma))
                    Next

                    Dim enfermedadesDiagnosticoPrimarioConConsulta As New List(Of Enfermedad)
                    Dim probabilidadesEnfermedadesDiagnosticoPrimarioConConsulta As New List(Of Decimal)
                    For Each rSistemaDiagnostica As DataRow In rDiagnosticoPrimario.GetChildRows("sistema_diagnostica_ibfk_1")
                        Dim rEnfermedad As DataRow = rSistemaDiagnostica.GetParentRow("sistema_diagnostica_ibfk_2")

                        Dim idEnfermedad As Integer = rEnfermedad("ID")
                        Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
                        Dim recomendacionesEnfermedad As String = rEnfermedad("RECOMENDACIONES")
                        Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
                        Dim descripcionEnfermedad As String = rEnfermedad("DESCRIPCION")
                        Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")
                        Dim probabilidadEnfermedad As Decimal = rSistemaDiagnostica("PROBABILIDAD")

                        enfermedadesDiagnosticoPrimarioConConsulta.Add(
                            New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad,
                                           descripcionEnfermedad, Nothing, Nothing, habilitadoEnfermedad))
                        probabilidadesEnfermedadesDiagnosticoPrimarioConConsulta.Add(probabilidadEnfermedad)
                    Next
                    Dim enfermedadesDiagnosticadasDiagnosticoPrimarioConConsulta As _
                        New EnfermedadesDiagnosticadas(enfermedadesDiagnosticoPrimarioConConsulta, probabilidadesEnfermedadesDiagnosticoPrimarioConConsulta)

                    If medicoDiagnosticoPrimarioConConsulta IsNot Nothing Then
                        lista.Add(New DiagnosticoPrimarioConConsulta(
                                  idDiagnosticoPrimarioConConsulta, pacienteDiagnosticoPrimarioConConsulta, sintomasDiagnosticoPrimario,
                                  enfermedadesDiagnosticadasDiagnosticoPrimarioConConsulta, fechaHoraDiagnosticoPrimarioConConsulta,
                                  medicoDiagnosticoPrimarioConConsulta, comentariosAdicionalesDiagnosticosPrimariosConConsulta))
                    Else
                        lista.Add(New DiagnosticoPrimarioConConsulta(
                                  idDiagnosticoPrimarioConConsulta, pacienteDiagnosticoPrimarioConConsulta, sintomasDiagnosticoPrimario,
                                  enfermedadesDiagnosticadasDiagnosticoPrimarioConConsulta, fechaHoraDiagnosticoPrimarioConConsulta,
                                  Nothing, comentariosAdicionalesDiagnosticosPrimariosConConsulta))
                    End If

                Next
        End Select
    End Sub

    ' Inserta un objeto en las tablas correspondientes de acuerdo al parámetro "entidad" mediante sentencias SQL.
    ' Para el caso de los objetos que utilizan borrado lógico, se verifica previo a las sentencias INSERT si el registro a insertar
    ' ya existe y se encuentra deshabilitado, en cuyo caso es habilitado.
    ' Cuando la operación requiere más de un comando, dichos comandos se encuentran encapsulados por BEGIN, COMMIT y ROLLBACK en un bloque Try/Catch.
    Public Sub InsertarObjeto(objetoAInsertar As Object, entidad As TiposObjeto)
        Select Case entidad
            Case TiposObjeto.DiagnosticoPrimario
                Try
                    Dim diagnosticoPrimario As DiagnosticoPrimario = objetoAInsertar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("BEGIN;")
                    comando.CommandText &= "INSERT INTO diagnosticos_primarios (ID_PACIENTE, FECHA_HORA, TIPO) VALUES (@ID_PACIENTE, @FECHA_HORA, @TIPO);"
                    comando.Parameters.AddWithValue("@ID_PACIENTE", diagnosticoPrimario.Paciente.ID)
                    comando.Parameters.AddWithValue("@FECHA_HORA", diagnosticoPrimario.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"))
                    comando.Parameters.AddWithValue("@TIPO", diagnosticoPrimario.Tipo.ToString)
                    ConexionBD.EjecutarTransaccion(comando)

                    Dim idDiagnosticoPrimarioBD As Integer = ConexionBD.ObtenerUltimoIdInsertado
                    comando.CommandText = ""
                    comando.Parameters.Clear()
                    For i = 0 To diagnosticoPrimario.Enfermedades.Count - 1
                        comando.CommandText &= String.Format("INSERT INTO sistema_diagnostica VALUES (@ID_DIAGNOSTICO_PRIMARIO, @ID_ENFERMEDAD{0}, @PROBABILIDAD{0});", i)
                        comando.Parameters.AddWithValue("@ID_ENFERMEDAD" & i, diagnosticoPrimario.Enfermedades(i).Id)
                        comando.Parameters.AddWithValue("@PROBABILIDAD" & i, diagnosticoPrimario.Probabilidad(i).ToString.Replace(",", "."))
                    Next

                    For i = 0 To diagnosticoPrimario.Sintomas.Count - 1
                        comando.CommandText &= String.Format("INSERT INTO sistema_evalua VALUES (@ID_DIAGNOSTICO_PRIMARIO, @ID_SINTOMA{0});", i)
                        comando.Parameters.AddWithValue("@ID_SINTOMA" & i, diagnosticoPrimario.Sintomas(i).ID)
                    Next
                    comando.Parameters.AddWithValue("@ID_DIAGNOSTICO_PRIMARIO", idDiagnosticoPrimarioBD)
                    comando.CommandText &= "COMMIT;"
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As MySqlException
                    ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.DiagnosticoDiferencial
                Try
                    Dim diagnosticoDiferencial As DiagnosticoDiferencial = objetoAInsertar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("INSERT INTO diagnosticos_diferenciales (ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA, ID_ENFERMEDAD, CONDUCTA_A_SEGUIR, FECHAHORA) VALUES (@ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA, @ID_ENFERMEDAD, @CONDUCTA_A_SEGUIR, @FECHAHORA);")
                    comando.Parameters.AddWithValue("@ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA", diagnosticoDiferencial.DiagnosticoPrimarioConConsulta.ID)
                    comando.Parameters.AddWithValue("@ID_ENFERMEDAD", diagnosticoDiferencial.EnfermedadDiagnosticada.Id)
                    comando.Parameters.AddWithValue("@CONDUCTA_A_SEGUIR", diagnosticoDiferencial.ConductaASeguir)
                    comando.Parameters.AddWithValue("@FECHAHORA", diagnosticoDiferencial.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"))
                    ConexionBD.EjecutarTransaccion(comando)
                Catch ex As MySqlException
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Enfermedad
                Try
                    Dim enfermedad As Enfermedad = objetoAInsertar
                    ConexionBD.Conexion.Open()

                    Dim estaDeshabilitado As Boolean = False
                    For Each r As DataRow In SeleccionarTabla("enfermedades", TiposSeleccionBD.Deshabilitados).Rows
                        If r("NOMBRE") = enfermedad.Nombre Then
                            estaDeshabilitado = True
                            Exit For
                        End If
                    Next

                    If estaDeshabilitado Then       ' Existe, y se deshabilitó
                        Dim comando As New MySqlCommand("UPDATE enfermedades SET HABILITADO=TRUE, DESCRIPCION=@DESCRIPCION, RECOMENDACIONES=@RECOMENDACIONES, GRAVEDAD=@GRAVEDAD, ID_ESPECIALIDAD=@ID_ESPECIALIDAD WHERE NOMBRE=@NOMBRE")
                        comando.Parameters.AddWithValue("@DESCRIPCION", enfermedad.Descripcion)
                        comando.Parameters.AddWithValue("@RECOMENDACIONES", enfermedad.Recomendaciones)
                        comando.Parameters.AddWithValue("@GRAVEDAD", enfermedad.Gravedad)
                        comando.Parameters.AddWithValue("@ID_ESPECIALIDAD", enfermedad.Especialidad.ID)
                        comando.Parameters.AddWithValue("@NOMBRE", enfermedad.Nombre)
                        ConexionBD.EjecutarTransaccion(comando)

                        Dim idEnfermedadBD As Integer = ConexionBD.EjecutarConsulta(String.Format("SELECT ID FROM enfermedades WHERE NOMBRE='{0}'", enfermedad.Nombre), "enfermedades").Rows(0)(0)
                        comando.CommandText = ""
                        comando.Parameters.Clear()
                        For i = 0 To enfermedad.Sintomas.Count - 1
                            comando.CommandText &= String.Format("INSERT INTO cuadro_sintomatico VALUES (@ID_SINTOMA{0}, @ID_ENFERMEDAD, @FRECUENCIA{0});", i)
                            comando.Parameters.AddWithValue("@ID_SINTOMA" & i, enfermedad.Sintomas(i))
                            comando.Parameters.AddWithValue("@FRECUENCIA" & i, enfermedad.FrecuenciaSintoma(i).ToString.Replace(",", "."))
                        Next
                        comando.Parameters.AddWithValue("@ID_ENFERMEDAD", idEnfermedadBD)
                        comando.CommandText &= "COMMIT;"
                        ConexionBD.EjecutarTransaccion(comando)
                    Else        ' Jamás existió
                        Dim comando As New MySqlCommand("BEGIN;")
                        comando.CommandText &= "INSERT INTO enfermedades (NOMBRE, DESCRIPCION, RECOMENDACIONES, GRAVEDAD, ID_ESPECIALIDAD) VALUES (@NOMBRE, @DESCRIPCION, @RECOMENDACIONES, @GRAVEDAD, @ID_ESPECIALIDAD);"
                        comando.Parameters.AddWithValue("@NOMBRE", enfermedad.Nombre)
                        comando.Parameters.AddWithValue("@DESCRIPCION", enfermedad.Descripcion)
                        comando.Parameters.AddWithValue("@RECOMENDACIONES", enfermedad.Recomendaciones)
                        comando.Parameters.AddWithValue("@GRAVEDAD", enfermedad.Gravedad)
                        comando.Parameters.AddWithValue("@ID_ESPECIALIDAD", enfermedad.Especialidad.ID)
                        ConexionBD.EjecutarTransaccion(comando)

                        Dim idEnfermedadBD As Integer = ConexionBD.ObtenerUltimoIdInsertado
                        comando.CommandText = ""
                        comando.Parameters.Clear()
                        For i = 0 To enfermedad.Sintomas.Count - 1
                            comando.CommandText &= String.Format("INSERT INTO cuadro_sintomatico VALUES (@ID_SINTOMA{0}, @ID_ENFERMEDAD, @FRECUENCIA{0});", i)
                            comando.Parameters.AddWithValue("@ID_SINTOMA" & i, enfermedad.Sintomas(i))
                            comando.Parameters.AddWithValue("@FRECUENCIA" & i, enfermedad.FrecuenciaSintoma(i).ToString.Replace(",", "."))
                        Next
                        comando.Parameters.AddWithValue("@ID_ENFERMEDAD", idEnfermedadBD)
                        comando.CommandText &= "COMMIT;"
                        ConexionBD.EjecutarTransaccion(comando)
                    End If

                Catch ex As MySqlException
                    ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Especialidad
                Try
                    Dim especialidad As Especialidad = objetoAInsertar
                    ConexionBD.Conexion.Open()

                    Dim estaDeshabilitado As Boolean = False
                    For Each r As DataRow In SeleccionarTabla("especialidades", TiposSeleccionBD.Deshabilitados).Rows
                        If r("NOMBRE") = especialidad.Nombre Then
                            estaDeshabilitado = True
                            Exit For
                        End If
                    Next

                    If estaDeshabilitado Then
                        Dim comando As New MySqlCommand("UPDATE especialidades SET HABILITADO=TRUE WHERE NOMBRE=@NOMBRE;")
                        comando.Parameters.AddWithValue("@NOMBRE", especialidad.Nombre)
                        ConexionBD.EjecutarTransaccion(comando)
                    Else
                        Dim comando As New MySqlCommand("INSERT INTO especialidades (NOMBRE) VALUES (@NOMBRE);")
                        comando.Parameters.AddWithValue("@NOMBRE", especialidad.Nombre)
                        ConexionBD.EjecutarTransaccion(comando)
                    End If

                Catch ex As MySqlException
                    ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Departamento
                Try
                    Dim departamento As Departamento = objetoAInsertar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("INSERT INTO departamentos (NOMBRE) VALUES (@NOMBRE);")
                    comando.Parameters.AddWithValue("@NOMBRE", departamento.Nombre)
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As MySqlException
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Localidad
                Try
                    Dim localidad As Localidad = objetoAInsertar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("INSERT INTO localidades (NOMBRE, ID_DEPARTAMENTO) VALUES (@NOMBRE, @ID_DEPARTAMENTO)")
                    comando.Parameters.AddWithValue("@NOMBRE", localidad.Nombre)
                    comando.Parameters.AddWithValue("@NOMBRE", localidad.Departamento.ID)
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As MySqlException
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Sintoma
                Try
                    Dim sintoma As Sintoma = objetoAInsertar
                    ConexionBD.Conexion.Open()

                    Dim estaDeshabilitado As Boolean = False
                    For Each r As DataRow In SeleccionarTabla("sintomas", TiposSeleccionBD.Deshabilitados).Rows
                        If r("NOMBRE") = sintoma.Nombre Then
                            estaDeshabilitado = True
                            Exit For
                        End If
                    Next

                    If estaDeshabilitado Then
                        Dim comando As New MySqlCommand("BEGIN;")
                        comando.CommandText &= "UPDATE sintomas SET HABILITADO=TRUE, DESCRIPCION=@DESCRIPCION, RECOMENDACIONES=@RECOMENDACIONES, URGENCIA=@URGENCIA WHERE NOMBRE=@NOMBRE;"
                        comando.Parameters.AddWithValue("@DESCRIPCION", sintoma.Descripcion)
                        comando.Parameters.AddWithValue("@RECOMENDACIONES", sintoma.Recomendaciones)
                        comando.Parameters.AddWithValue("@URGENCIA", sintoma.Urgencia)
                        comando.Parameters.AddWithValue("@NOMBRE", sintoma.Nombre)
                        ConexionBD.EjecutarTransaccion(comando)

                        Dim idSintomaBD As Integer = ConexionBD.EjecutarConsulta(String.Format("SELECT ID FROM sintomas WHERE NOMBRE='{0}'", sintoma.Nombre), "sintomas").Rows(0)(0)
                        comando.CommandText = ""
                        comando.Parameters.Clear()
                        For i = 0 To sintoma.Enfermedades.Count - 1
                            comando.CommandText &= String.Format("INSERT INTO cuadro_sintomatico VALUES (@ID_SINTOMA, @ID_ENFERMEDAD{0}, @FRECUENCIA{0});", i)
                            comando.Parameters.AddWithValue("@ID_ENFERMEDAD" & i, sintoma.Enfermedades(i).Id)
                            comando.Parameters.AddWithValue("@FRECUENCIA" & i, sintoma.FrecuenciaEnfermedad(i).ToString.Replace(",", "."))
                        Next
                        comando.Parameters.AddWithValue("@ID_SINTOMA", idSintomaBD)
                        comando.CommandText &= "COMMIT;"
                        ConexionBD.EjecutarTransaccion(comando)

                    Else
                        Dim comando As New MySqlCommand("BEGIN;")
                        comando.CommandText &= "INSERT INTO sintomas (NOMBRE, DESCRIPCION, RECOMENDACIONES, URGENCIA) VALUES (@NOMBRE, @DESCRIPCION, @RECOMENDACIONES, @URGENCIA);"
                        comando.Parameters.AddWithValue("@NOMBRE", sintoma.Nombre)
                        comando.Parameters.AddWithValue("@DESCRIPCION", sintoma.Descripcion)
                        comando.Parameters.AddWithValue("@RECOMENDACIONES", sintoma.Recomendaciones)
                        comando.Parameters.AddWithValue("@URGENCIA", sintoma.Urgencia)
                        ConexionBD.EjecutarTransaccion(comando)

                        Dim idSintomaBD As Integer = ConexionBD.ObtenerUltimoIdInsertado
                        comando.CommandText = ""
                        comando.Parameters.Clear()
                        For i = 0 To sintoma.Enfermedades.Count - 1
                            comando.CommandText &= String.Format("INSERT INTO cuadro_sintomatico VALUES (@ID_SINTOMA, @ID_ENFERMEDAD{0}, @FRECUENCIA{0});", i)
                            comando.Parameters.AddWithValue("@ID_ENFERMEDAD" & i, sintoma.Enfermedades(i).Id)
                            comando.Parameters.AddWithValue("@FRECUENCIA" & i, sintoma.FrecuenciaEnfermedad(i).ToString.Replace(",", "."))
                        Next
                        comando.Parameters.AddWithValue("@ID_SINTOMA", idSintomaBD)
                        comando.CommandText &= "COMMIT;"
                        ConexionBD.EjecutarTransaccion(comando)
                    End If

                Catch ex As MySqlException
                    ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Usuario
                Try
                    Dim usuario As Usuario = objetoAInsertar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("INSERT INTO usuarios (CONTRASENIA, TIPO, ID_PERSONA) VALUES (@CONTRASENIA, @TIPO, @ID_PERSONA);")
                    comando.Parameters.AddWithValue("@CONTRASENIA", usuario.Contrasena)
                    comando.Parameters.AddWithValue("@TIPO", usuario.Tipo)
                    comando.Parameters.AddWithValue("@ID_PERSONA", usuario.Persona.ID)
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As MySqlException
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Mensaje
                Try
                    Dim mensaje As Mensaje = objetoAInsertar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("INSERT INTO mensajes (FECHAHORA, FORMATO, CONTENIDO, REMITENTE, ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA) VALUES (@FECHAHORA, @FORMATO, @CONTENIDO, @REMITENTE, @ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA);")
                    comando.Parameters.AddWithValue("@FECHAHORA", mensaje.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"))
                    comando.Parameters.AddWithValue("@FORMATO", mensaje.Formato)
                    comando.Parameters.AddWithValue("@CONTENIDO", Encoding.UTF8.GetString(mensaje.Contenido))
                    comando.Parameters.AddWithValue("@REMITENTE", mensaje.Remitente)
                    comando.Parameters.AddWithValue("@ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA", mensaje.DiagnosticoPrimarioConConsulta.ID)
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As MySqlException
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Administrativo
                Try
                    Dim administrativo As Administrativo = objetoAInsertar
                    ConexionBD.Conexion.Open()

                    Dim estaDeshabilitado As Boolean = False
                    Dim idAdministrativoBD As Integer = -1
                    For Each a As Administrativo In ObtenerListadoCompleto(TiposObjeto.Administrativo)
                        If a.CI = administrativo.CI And a.Habilitado = False Then
                            estaDeshabilitado = True
                            idAdministrativoBD = a.ID
                        End If
                    Next

                    If estaDeshabilitado Then

                        ' ERROR?? cláusula WHERE debe comparar CI??
                        Dim comando As New MySqlCommand("BEGIN;")
                        comando.CommandText &= "UPDATE personas SET CI=@CI, NOMBRE=@NOMBRE, APELLIDO=@APELLIDO, CORREO=@CORREO, ID_LOCALIDAD=@ID_LOCALIDAD, TIPO=@TIPO WHERE ID=@ID;"
                        comando.CommandText &= "UPDATE funcionarios SET HABILITADO=TRUE WHERE ID_PERSONA=@ID;"
                        comando.CommandText &= "UPDATE administrativos SET ES_ENCARGADO=@ES_ENCARGADO WHERE ID_FUNCIONARIO=@ID;"
                        comando.CommandText &= "COMMIT;"
                        comando.Parameters.AddWithValue("@CI", administrativo.CI)
                        comando.Parameters.AddWithValue("@NOMBRE", administrativo.Nombre)
                        comando.Parameters.AddWithValue("@APELLIDO", administrativo.Apellido)
                        comando.Parameters.AddWithValue("@CORREO", administrativo.Correo)
                        comando.Parameters.AddWithValue("@ID_LOCALIDAD", administrativo.Localidad.ID)
                        comando.Parameters.AddWithValue("@TIPO", administrativo.Tipo)
                        comando.Parameters.AddWithValue("@ES_ENCARGADO", administrativo.EsEncargado)
                        comando.Parameters.AddWithValue("@ID", administrativo.ID)
                        ConexionBD.EjecutarTransaccion(comando)

                    Else
                        Dim comando As New MySqlCommand("BEGIN;")
                        comando.CommandText &= "INSERT INTO personas (CI, NOMBRE, APELLIDO, CORREO, ID_LOCALIDAD, TIPO) VALUES (@CI, @NOMBRE, @APELLIDO, @CORREO, @ID_LOCALIDAD, @TIPO);"
                        comando.Parameters.AddWithValue("@CI", administrativo.CI)
                        comando.Parameters.AddWithValue("@NOMBRE", administrativo.Nombre)
                        comando.Parameters.AddWithValue("@APELLIDO", administrativo.Apellido)
                        comando.Parameters.AddWithValue("@CORREO", administrativo.Correo)
                        comando.Parameters.AddWithValue("@ID_LOCALIDAD", administrativo.Localidad.ID)
                        comando.Parameters.AddWithValue("@TIPO", TiposPersona.Funcionario.ToString)
                        ConexionBD.EjecutarTransaccion(comando)

                        idAdministrativoBD = ConexionBD.ObtenerUltimoIdInsertado
                        comando.CommandText = ""
                        comando.Parameters.Clear()
                        comando.CommandText &= "INSERT INTO funcionarios VALUES (@ID, @TIPO);"
                        comando.CommandText &= "INSERT INTO administrativos VALUES (@ID, @ES_ENCARGADO);"
                        comando.CommandText &= "COMMIT;"
                        comando.Parameters.AddWithValue("@ID", idAdministrativoBD)
                        comando.Parameters.AddWithValue("@TIPO", TiposFuncionario.Administrativo.ToString)
                        comando.Parameters.AddWithValue("@ES_ENCARGADO", administrativo.EsEncargado)
                        ConexionBD.EjecutarTransaccion(comando)
                    End If

                Catch ex As MySqlException
                    ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Paciente
                Try
                    Dim paciente As Paciente = objetoAInsertar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("BEGIN;")
                    comando.CommandText &= "INSERT INTO personas (CI, NOMBRE, APELLIDO, CORREO, ID_LOCALIDAD, TIPO) VALUES (@CI, @NOMBRE, @APELLIDO, @CORREO, @ID_LOCALIDAD, @TIPO);"
                    comando.Parameters.AddWithValue("@CI", paciente.CI)
                    comando.Parameters.AddWithValue("@NOMBRE", paciente.Nombre)
                    comando.Parameters.AddWithValue("@APELLIDO", paciente.Apellido)
                    comando.Parameters.AddWithValue("@CORREO", paciente.Correo)
                    comando.Parameters.AddWithValue("@ID_LOCALIDAD", paciente.Localidad.ID)
                    comando.Parameters.AddWithValue("@TIPO", paciente.Tipo.ToString)
                    ConexionBD.EjecutarTransaccion(comando)

                    Dim idPacienteBD As Integer = ConexionBD.ObtenerUltimoIdInsertado
                    comando.Parameters.Clear()
                    comando.CommandText = "INSERT INTO pacientes VALUES (@ID, @TELEFONO_MOVIL, @TELEFONO_FIJO, @SEXO, @FECHA_NACIMIENTO, @CALLE, @NUMERO_PUERTA, @APARTAMENTO);"
                    comando.Parameters.AddWithValue("@ID", idPacienteBD)
                    comando.Parameters.AddWithValue("@TELEFONO_MOVIL", paciente.TelefonoMovil)
                    comando.Parameters.AddWithValue("@TELEFONO_FIJO", paciente.TelefonoFijo)
                    comando.Parameters.AddWithValue("@SEXO", paciente.Sexo.ToString)
                    comando.Parameters.AddWithValue("@FECHA_NACIMIENTO", paciente.FechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss"))
                    comando.Parameters.AddWithValue("@CALLE", paciente.Calle)
                    comando.Parameters.AddWithValue("@NUMERO_PUERTA", paciente.NumeroPuerta)
                    comando.Parameters.AddWithValue("@APARTAMENTO", paciente.Apartamento)
                    comando.CommandText &= "COMMIT;"
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As MySqlException
                    ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Medico
                Try
                    Dim medico As Medico = objetoAInsertar
                    ConexionBD.Conexion.Open()

                    Dim estaDeshabilitado As Boolean = False
                    For Each m As Medico In ObtenerListadoCompleto(TiposObjeto.Medico)
                        If m.CI = medico.CI And m.Habilitado = False Then
                            estaDeshabilitado = True
                        End If
                    Next

                    If estaDeshabilitado Then
                        Dim comando As New MySqlCommand("BEGIN;")
                        comando.CommandText &= "UPDATE personas SET CI=@CI, NOMBRE=@NOMBRE, APELLIDO=@APELLIDO, CORREO=@CORREO, ID_LOCALIDAD=@ID_LOCALIDAD, TIPO=@TIPO WHERE ID=@ID;"
                        comando.CommandText &= "UPDATE funcionarios SET HABILITADO=TRUE WHERE ID=@ID;"
                        comando.Parameters.AddWithValue("@CI", medico.CI)
                        comando.Parameters.AddWithValue("@NOMBRE", medico.Nombre)
                        comando.Parameters.AddWithValue("@APELLIDO", medico.Apellido)
                        comando.Parameters.AddWithValue("@CORREO", medico.Correo)
                        comando.Parameters.AddWithValue("@ID_LOCALIDAD", medico.Localidad.ID)
                        comando.Parameters.AddWithValue("@TIPO", medico.Tipo.ToString)
                        comando.Parameters.AddWithValue("@ID", medico.ID)
                        ConexionBD.EjecutarTransaccion(comando)

                    Else
                        Dim comando As New MySqlCommand("BEGIN;")
                        comando.CommandText &= "INSERT INTO personas (CI, NOMBRE, APELLIDO, CORREO, ID_LOCALIDAD, TIPO) VALUES (@CI, @NOMBRE, @APELLIDO, @CORREO, @ID_LOCALIDAD, @TIPO);"
                        comando.Parameters.AddWithValue("@CI", medico.CI)
                        comando.Parameters.AddWithValue("@NOMBRE", medico.Nombre)
                        comando.Parameters.AddWithValue("@APELLIDO", medico.Apellido)
                        comando.Parameters.AddWithValue("@CORREO", medico.Correo)
                        comando.Parameters.AddWithValue("@ID_LOCALIDAD", medico.Localidad.ID)
                        comando.Parameters.AddWithValue("@TIPO", medico.Tipo.ToString)
                        ConexionBD.EjecutarTransaccion(comando)

                        Dim idMedicoBD As Integer = ConexionBD.ObtenerUltimoIdInsertado
                        comando.Parameters.Clear()
                        comando.CommandText = "INSERT INTO funcionarios VALUES (@ID, @TIPO);"
                        comando.CommandText &= "INSERT INTO medicos VALUES (@ID);"
                        comando.Parameters.AddWithValue("@ID", idMedicoBD)
                        comando.Parameters.AddWithValue("@TIPO", TiposFuncionario.Medico.ToString)
                        comando.CommandText &= "COMMIT;"
                        ConexionBD.EjecutarTransaccion(comando)
                    End If

                Catch ex As MySqlException
                    ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.DiagnosticoPrimarioConConsulta
                Try
                    Dim diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta = objetoAInsertar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("BEGIN;")
                    comando.CommandText &= "INSERT INTO diagnosticos_primarios_con_consulta VALUES (@ID_DIAGNOSTICO, @ID_MEDICO, @COMENTARIOS_ADICIONALES);"
                    comando.CommandText &= "UPDATE diagnosticos_primarios SET TIPO='Con_Consulta' WHERE ID=@ID_DIAGNOSTICO;"
                    comando.Parameters.AddWithValue("@ID_DIAGNOSTICO", diagnosticoPrimarioConConsulta.ID)
                    comando.Parameters.AddWithValue("@ID_MEDICO", DBNull.Value)
                    comando.Parameters.AddWithValue("@COMENTARIOS_ADICIONALES", diagnosticoPrimarioConConsulta.ComentariosAdicionales)
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As MySqlException
                    ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try
        End Select
    End Sub

    ' Elimina un objeto en las tablas correspondientes de acuerdo al parámetro "entidad" mediante sentencias SQL.
    ' Únicamente los pacientes son eliminados físicamente de la BD. El resto de objetos son conservados mediante un borrado
    ' lógico para preservar la integridad referencial de las tablas. Cuando se "elimina" uno de estos objetos, se realiza un UPDATE
    ' en la tabla correspondiente para distinguir el registro de aquellos que no han sido dados de baja.
    ' Cuando la operación requiere más de un comando, dichos comandos se encuentran encapsulados por BEGIN, COMMIT y ROLLBACK en un bloque Try/Catch.
    Public Sub EliminarObjeto(objetoAEliminar As Object, entidad As TiposObjeto)
        Select Case entidad
            Case TiposObjeto.Enfermedad
                Try
                    Dim enfermedad As Enfermedad = objetoAEliminar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("BEGIN;")
                    comando.CommandText &= "UPDATE enfermedades SET HABILITADO=FALSE WHERE ID=@ID;"
                    comando.CommandText &= "DELETE FROM cuadro_sintomatico WHERE ID_ENFERMEDAD=@ID;"
                    comando.Parameters.AddWithValue("@ID", enfermedad.Id)
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As MySqlException
                    ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Especialidad
                Dim especialidad As Especialidad = objetoAEliminar
                ConexionBD.Conexion.Open()
                Dim comando As New MySqlCommand("UPDATE especialidades SET HABILITADO=FALSE WHERE ID=@ID")
                comando.Parameters.AddWithValue("@ID", especialidad.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Departamento
                Try
                    Dim departamento As Departamento = objetoAEliminar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("DELETE FROM departamentos WHERE ID=@ID")
                    comando.Parameters.AddWithValue("@ID", departamento.ID)
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As Exception
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Localidad
                Try
                    Dim localidad As Localidad = objetoAEliminar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("DELETE FROM localidades WHERE ID=@ID")
                    comando.Parameters.AddWithValue("@ID", localidad.ID)
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As MySqlException
                    Select Case ex.Number
                        Case 1062
                            Throw New Exception("No se puede eliminar una localidad en la que haya personas registradas.")
                        Case Else
                            Throw ex
                    End Select
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Sintoma
                Try
                    Dim sintoma As Sintoma = objetoAEliminar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("UPDATE sintomas SET HABILITADO=FALSE WHERE ID=@ID;")
                    comando.CommandText &= "DELETE FROM cuadro_sintomatico WHERE ID_SINTOMA=@ID;"
                    comando.Parameters.AddWithValue("@ID", sintoma.ID)
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As Exception
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Usuario
                Dim usuario As Usuario = objetoAEliminar
                ConexionBD.Conexion.Open()
                Dim comando As New MySqlCommand("UPDATE usuarios SET HABILITADO=FALSE WHERE ID=@ID;")
                comando.Parameters.AddWithValue("@ID", usuario.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Administrativo
                Dim administrativo As Administrativo = objetoAEliminar
                ConexionBD.Conexion.Open()
                Dim comando As New MySqlCommand("UPDATE funcionarios SET HABILITADO=FALSE WHERE ID_PERSONA=@ID")
                comando.Parameters.AddWithValue("@ID", administrativo.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Paciente
                Try
                    Dim paciente As Paciente = objetoAEliminar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("BEGIN;")
                    comando.CommandText &= "DELETE FROM personas WHERE ID=@ID;"
                    comando.CommandText &= "COMMIT;"
                    comando.Parameters.AddWithValue("@ID", paciente.ID)
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As Exception
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Medico
                Dim medico As Medico = objetoAEliminar
                ConexionBD.Conexion.Open()
                Dim comando As New MySqlCommand("UPDATE funcionarios SET HABILITADO=FALSE WHERE ID_PERSONA=@ID;")
                comando.Parameters.AddWithValue("@ID", medico.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()
        End Select
    End Sub

    ' Modifica un objeto en las tablas correspondientes de acuerdo al parámetro "entidad" mediante sentencias SQL.
    ' Cuando la operación requiere más de un comando, dichos comandos se encuentran encapsulados por BEGIN, COMMIT y ROLLBACK en un bloque Try/Catch.
    Public Sub ModificarObjeto(objetoAModificar As Object, entidad As TiposObjeto)
        Select Case entidad
            Case TiposObjeto.Enfermedad
                Try
                    Dim enfermedad As Enfermedad = objetoAModificar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("BEGIN;")
                    comando.CommandText &= "UPDATE enfermedades SET NOMBRE=@NOMBRE, DESCRIPCION=@DESCRIPCION, RECOMENDACIONES=@RECOMENDACIONES, GRAVEDAD=@GRAVEDAD, ID_ESPECIALIDAD=@ID_ESPECIALIDAD WHERE ID=@ID_ENFERMEDAD;"
                    comando.CommandText &= "DELETE FROM cuadro_sintomatico WHERE ID_ENFERMEDAD=@ID_ENFERMEDAD;"
                    For i = 0 To enfermedad.Sintomas.Count - 1
                        comando.CommandText &= String.Format("INSERT INTO cuadro_sintomatico VALUES (@ID_SINTOMA{0}, @ID_ENFERMEDAD, @FRECUENCIA{0});", i)
                        comando.Parameters.AddWithValue("@ID_SINTOMA" & i, enfermedad.Sintomas(i).ID)
                        comando.Parameters.AddWithValue("@FRECUENCIA" & i, enfermedad.FrecuenciaSintoma(i).ToString.Replace(",", "."))
                    Next
                    comando.CommandText &= "COMMIT;"
                    comando.Parameters.AddWithValue("@NOMBRE", enfermedad.Nombre)
                    comando.Parameters.AddWithValue("@DESCRIPCION", enfermedad.Descripcion)
                    comando.Parameters.AddWithValue("@RECOMENDACIONES", enfermedad.Recomendaciones)
                    comando.Parameters.AddWithValue("@GRAVEDAD", enfermedad.Gravedad)
                    comando.Parameters.AddWithValue("@ID_ESPECIALIDAD", enfermedad.Especialidad.ID)
                    comando.Parameters.AddWithValue("@ID_ENFERMEDAD", enfermedad.Id)
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As Exception
                    ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Especialidad
                Dim especialidad As Especialidad = objetoAModificar
                ConexionBD.Conexion.Open()
                Dim comando As New MySqlCommand("UPDATE especialidades SET NOMBRE=@NOMBRE WHERE ID=@ID;")
                comando.Parameters.AddWithValue("@NOMBRE", especialidad.Nombre)
                comando.Parameters.AddWithValue("@ID", especialidad.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Departamento
                Dim departamento As Departamento = objetoAModificar
                ConexionBD.Conexion.Open()
                Dim comando As New MySqlCommand("UPDATE departamentos SET NOMBRE=@NOMBRE WHERE ID=@ID;")
                comando.Parameters.AddWithValue("@NOMBRE", departamento.Nombre)
                comando.Parameters.AddWithValue("@ID", departamento.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Localidad
                Dim localidad As Localidad = objetoAModificar
                ConexionBD.Conexion.Open()
                Dim comando As New MySqlCommand("UPDATE localidades SET NOMBRE=@NOMBRE, ID_DEPARTAMENTO=@ID_DEPARTAMENTO WHERE ID=@ID;")
                comando.Parameters.AddWithValue("@NOMBRE", localidad.Nombre)
                comando.Parameters.AddWithValue("@ID_DEPARTAMENTO", localidad.Departamento.ID)
                comando.Parameters.AddWithValue("@ID", localidad.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Sintoma
                Try
                    Dim sintoma As Sintoma = objetoAModificar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("UPDATE sintomas SET NOMBRE=@NOMBRE, DESCRIPCION=@DESCRIPCION, RECOMENDACIONES=@RECOMENDACIONES, URGENCIA=@URGENCIA WHERE ID=@ID_SINTOMA;")
                    comando.CommandText &= "DELETE FROM cuadro_sintomatico WHERE ID_SINTOMA=@ID_SINTOMA;"
                    For i = 0 To sintoma.Enfermedades.Count - 1
                        comando.CommandText &= String.Format("INSERT INTO cuadro_sintomatico VALUES (@ID_SINTOMA, @ID_ENFERMEDAD{0}, @FRECUENCIA{0});", i)
                        comando.Parameters.AddWithValue("@ID_ENFERMEDAD" & i, sintoma.Enfermedades(i).Id)
                        comando.Parameters.AddWithValue("@FRECUENCIA" & i, sintoma.FrecuenciaEnfermedad(i).ToString.Replace(",", "."))
                    Next
                    comando.CommandText &= "COMMIT;"
                    comando.Parameters.AddWithValue("@NOMBRE", sintoma.Nombre)
                    comando.Parameters.AddWithValue("@DESCRIPCION", sintoma.Descripcion)
                    comando.Parameters.AddWithValue("@RECOMENDACIONES", sintoma.Recomendaciones)
                    comando.Parameters.AddWithValue("@URGENCIA", sintoma.Urgencia)
                    comando.Parameters.AddWithValue("@ID_SINTOMA", sintoma.ID)
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As Exception
                    ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Administrativo
                Try
                    Dim administrativo As Administrativo = objetoAModificar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("BEGIN;")
                    comando.CommandText &= "UPDATE personas SET CI=@CI, NOMBRE=@NOMBRE, APELLIDO=@APELLIDO, CORREO=@CORREO, ID_LOCALIDAD=@ID_LOCALIDAD, TIPO=@TIPO, WHERE ID=@ID;"
                    comando.CommandText &= "UPDATE administrativos SET ES_ENCARGADO=@ES_ENCARGADO WHERE ID_FUNCIONARIO=@ID;"
                    comando.CommandText &= "COMMIT;"
                    comando.Parameters.AddWithValue("@CI", administrativo.CI)
                    comando.Parameters.AddWithValue("@NOMBRE", administrativo.Nombre)
                    comando.Parameters.AddWithValue("@APELLIDO", administrativo.Apellido)
                    comando.Parameters.AddWithValue("@CORREO", administrativo.Correo)
                    comando.Parameters.AddWithValue("@ID_LOCALIDAD", administrativo.Localidad.ID)
                    comando.Parameters.AddWithValue("@TIPO", administrativo.Tipo.ToString)
                    comando.Parameters.AddWithValue("@ID", administrativo.ID)
                    comando.Parameters.AddWithValue("@ES_ENCARGADO", administrativo.EsEncargado)
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As Exception
                    ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Paciente
                Try
                    Dim paciente As Paciente = objetoAModificar
                    ConexionBD.Conexion.Open()
                    Dim comando As New MySqlCommand("BEGIN;")
                    comando.CommandText &= "UPDATE personas SET CI=@CI, NOMBRE=@NOMBRE, APELLIDO=@APELLIDO, CORREO=@CORREO, ID_LOCALIDAD=@ID_LOCALIDAD, TIPO=@TIPO, WHERE ID=@ID;"
                    comando.CommandText &= "UPDATE pacientes SET TELEFONOMOVIL=@TELEFONOMOVIL, TELEFONOFIJO=@TELEFONOFIJO, SEXO=@SEXO, FECHANACIMIENTO=@FECHANACIMIENTO, CALLE=@CALLE, NUMEROPUERTA=@NUMEROPUERTA, APARTAMENTO=@APARTAMENTO WHERE ID_PERSONA=@ID;"
                    comando.CommandText &= "COMMIT;"
                    comando.Parameters.AddWithValue("@CI", paciente.CI)
                    comando.Parameters.AddWithValue("@NOMBRE", paciente.Nombre)
                    comando.Parameters.AddWithValue("@APELLIDO", paciente.Apellido)
                    comando.Parameters.AddWithValue("@CORREO", paciente.Correo)
                    comando.Parameters.AddWithValue("@ID_LOCALIDAD", paciente.Localidad.ID)
                    comando.Parameters.AddWithValue("@TIPO", paciente.Tipo.ToString)
                    comando.Parameters.AddWithValue("@ID", paciente.ID)
                    comando.Parameters.AddWithValue("@TELEFONOMOVIL", paciente.TelefonoMovil)
                    comando.Parameters.AddWithValue("@TELEFONOFIJO", paciente.TelefonoFijo)
                    comando.Parameters.AddWithValue("@SEXO", paciente.Sexo.ToString)
                    comando.Parameters.AddWithValue("@FECHANACIMIENTO", paciente.FechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss"))
                    comando.Parameters.AddWithValue("@CALLE", paciente.Calle)
                    comando.Parameters.AddWithValue("@NUMEROPUERTA", paciente.NumeroPuerta)
                    comando.Parameters.AddWithValue("@APARTAMENTO", paciente.Apartamento)
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As Exception
                    ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
                    Throw ex
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Medico
                Dim medico As Medico = objetoAModificar
                ConexionBD.Conexion.Open()
                Dim comando As New MySqlCommand("UPDATE personas SET CI=@CI, NOMBRE=@NOMBRE, APELLIDO=@APELLIDO, CORREO=@CORREO, ID_LOCALIDAD=@ID_LOCALIDAD, TIPO=@TIPO, WHERE ID=@ID;")
                comando.Parameters.AddWithValue("@CI", medico.CI)
                comando.Parameters.AddWithValue("@NOMBRE", medico.Nombre)
                comando.Parameters.AddWithValue("@APELLIDO", medico.Apellido)
                comando.Parameters.AddWithValue("@CORREO", medico.Correo)
                comando.Parameters.AddWithValue("@ID_LOCALIDAD", medico.Localidad.ID)
                comando.Parameters.AddWithValue("@TIPO", medico.Tipo.ToString)
                comando.Parameters.AddWithValue("@ID", medico.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()
        End Select
    End Sub

    Public Function TienePersonaRegistrada(ci As String, tipo As TiposPersona) As Boolean
        Dim comando As New MySqlCommand("SELECT COUNT(*) FROM personas WHERE CI=@CI AND TIPO=@TIPO;")
        comando.Parameters.AddWithValue("@CI", ci)
        comando.Parameters.AddWithValue("@TIPO", tipo.ToString)
        Dim datos As DataTable = ConexionBD.EjecutarConsulta(comando)
        Dim cantidadPersonas As Integer = datos.Rows(0)(0)
        Return cantidadPersonas = 1
    End Function

    Public Function ObtenerMedicoPorCI(ci As String) As Medico
        Dim comando As New MySqlCommand("SELECT * FROM ObtenerMedicos WHERE `CI Persona`=@CI;")
        comando.Parameters.AddWithValue("@CI", ci)
        Dim datos As DataTable = ConexionBD.EjecutarConsulta(comando)
        Dim filas As DataRowCollection = datos.Rows

        Dim idMedico As Integer = filas(0)("ID Persona")
        Dim ciMedico As String = filas(0)("CI Persona")
        Dim nombreMedico As String = filas(0)("Nombre persona")
        Dim apellidoMedico As String = filas(0)("Apellido persona")
        Dim correoMedico As String = filas(0)("Correo persona")
        Dim idLocalidad As String = filas(0)("ID localidad")
        Dim nombreLocalidad As String = filas(0)("Nombre localidad")
        Dim idDepartamento As String = filas(0)("ID departamento")
        Dim nombreDepartamento As String = filas(0)("Nombre departamento")

        Dim departamentoLocalidad As New Departamento(idDepartamento, nombreDepartamento)
        Dim localidadMedico As New Localidad(idLocalidad, nombreLocalidad, departamentoLocalidad)

        Dim especialidadesMedico As New List(Of Especialidad)
        For i = 0 To filas.Count - 1
            Dim idEspecialidad As String = filas(i)("ID especialidad")
            Dim nombreEspecialidad As String = filas(i)("Nombre especialidad")
            especialidadesMedico.Add(New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, True))
        Next

        Return New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, localidadMedico, especialidadesMedico, True)


        ' Para obtener una lista de médicos:

        'Dim filas As DataRowCollection = datos.Rows
        'Dim listaMedicos As New List(Of Medico)
        'For i = 0 To datos.Rows.Count - 1
        '    Dim idMedico As Integer = filas(i)("ID Persona")
        '    Dim ciMedico As String = filas(i)("CI Persona")
        '    Dim nombreMedico As String = filas(i)("Nombre persona")
        '    Dim apellidoMedico As String = filas(i)("Apellido persona")
        '    Dim correoMedico As String = filas(i)("Correo persona")
        '    Dim idLocalidad As String = filas(i)("ID localidad")
        '    Dim nombreLocalidad As String = filas(i)("Nombre localidad")
        '    Dim idDepartamento As String = filas(i)("ID departamento")
        '    Dim nombreDepartamento As String = filas(i)("Nombre departamento")

        '    Dim departamentoLocalidad As New Departamento(idDepartamento, nombreDepartamento)
        '    Dim localidadMedico As New Localidad(idLocalidad, nombreLocalidad, departamentoLocalidad)

        '    Dim cantEspecialidades As Integer = 1
        '    Dim j As Integer = 1
        '    While i + j < filas.Count AndAlso filas(i + j)("ID Persona") = idMedico
        '        cantEspecialidades += 1
        '        j += 1
        '    End While

        '    Dim especialidadesMedico As New List(Of Especialidad)
        '    For j = 0 To cantEspecialidades - 1
        '        Dim idEspecialidad As String = filas(i + j)("ID especialidad")
        '        Dim nombreEspecialidad As String = filas(i + j)("Nombre especialidad")
        '        especialidadesMedico.Add(New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, True))
        '    Next

        '    listaMedicos.Add(New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, localidadMedico, especialidadesMedico, True))

        '    i += cantEspecialidades - 1
        'Next
    End Function

    Public Function ObtenerPacientePorCI(ci As String) As Paciente
        Dim comando As New MySqlCommand("SELECT * FROM ObtenerPacientes WHERE `CI Persona`=@CI;")
        comando.Parameters.AddWithValue("@CI", ci)
        Dim datos As DataTable = ConexionBD.EjecutarConsulta(comando)
        Dim filas As DataRowCollection = datos.Rows

        Dim idPaciente As Integer = filas(0)("ID Persona")
        Dim ciPaciente As String = filas(0)("CI Persona")
        Dim nombrePaciente As String = filas(0)("Nombre persona")
        Dim apellidoPaciente As String = filas(0)("Apellido persona")
        Dim correoPaciente As String = filas(0)("Correo persona")
        Dim telefonoMovilPaciente As String = filas(0)("Telefonomovil paciente")
        Dim telefonoFijoPaciente As String = filas(0)("Telefonofijo paciente")
        Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), filas(0)("Sexo paciente"))
        Dim fechaNacimientoPaciente As Date = CType(filas(0)("Fecha nacimiento paciente"), MySqlDateTime).Value
        Dim callePaciente As String = filas(0)("Calle paciente")
        Dim numeroPuertaPaciente As String = filas(0)("Numero puerta paciente")
        Dim apartamentoPaciente As String = If(TypeOf filas(0)("Apartamento paciente") IsNot DBNull, filas(0)("Apartamento paciente"), Nothing)
        Dim idLocalidad As Integer = filas(0)("ID localidad")
        Dim nombreLocalidad As String = filas(0)("Nombre localidad")
        Dim idDepartamento As Integer = filas(0)("ID departamento")
        Dim nombreDepartamento As String = filas(0)("Nombre departamento")

        Dim departamentoLocalidad As New Departamento(idDepartamento, nombreDepartamento)
        Dim localidadPaciente As New Localidad(idLocalidad, nombreLocalidad, departamentoLocalidad)
        Return New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, localidadPaciente, telefonoMovilPaciente,
                            telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente, callePaciente, numeroPuertaPaciente, apartamentoPaciente)
    End Function

    Public Function ObtenerAdministrativoPorCI(ci As String) As Administrativo
        Dim comando As New MySqlCommand("SELECT * FROM ObtenerAdministrativos WHERE `CI Persona`=@CI;")
        comando.Parameters.AddWithValue("@CI", ci)
        Dim datos As DataTable = ConexionBD.EjecutarConsulta(comando)
        Dim filas As DataRowCollection = datos.Rows

        Dim idAdministrativo As Integer = filas(0)("ID Persona")
        Dim ciAdministrativo As String = filas(0)("CI Persona")
        Dim nombreAdministrativo As String = filas(0)("Nombre persona")
        Dim apellidoAdministrativo As String = filas(0)("Apellido persona")
        Dim correoAdministrativo As String = filas(0)("Correo persona")
        Dim esEncargadoAdministrativo As Boolean = filas(0)("Encargado administrativo")
        Dim idLocalidad As Integer = filas(0)("ID localidad")
        Dim nombreLocalidad As String = filas(0)("Nombre localidad")
        Dim idDepartamento As Integer = filas(0)("ID departamento")
        Dim nombreDepartamento As String = filas(0)("Nombre departamento")

        Dim departamentoLocalidad As New Departamento(idDepartamento, nombreDepartamento)
        Dim localidadAdministrativo As New Localidad(idLocalidad, nombreLocalidad, departamentoLocalidad)
        Return New Administrativo(idAdministrativo, ciAdministrativo, nombreAdministrativo, apellidoAdministrativo, correoAdministrativo,
                                  localidadAdministrativo, esEncargadoAdministrativo, True)
    End Function

    Public Function TieneUsuarioRegistrado(persona As Persona) As Boolean
        Dim comando As New MySqlCommand("SELECT COUNT(*) FROM usuarios WHERE ID_PERSONA=@ID;")
        comando.Parameters.AddWithValue("@ID", persona.ID)
        Dim datos As DataTable = ConexionBD.EjecutarConsulta(comando)
        Dim cantidadUsuarios As Integer = datos.Rows(0)(0)
        Return cantidadUsuarios = 1
    End Function

    Public Function ObtenerUsuarioPorPersona(persona As Persona) As Usuario
        Dim comando As New MySqlCommand("SELECT * FROM ObtenerUsuario WHERE `ID usuario`=@ID;")
        comando.Parameters.AddWithValue("@ID", persona.ID)
        Dim datos As DataTable = ConexionBD.EjecutarConsulta(comando)
        Dim fila As DataRow = datos.Rows(0)
        Dim idUsuario As Integer = fila("ID usuario")
        Dim contrasenaUsuario As String = fila("Contraseña usuario")
        Return New Usuario(idUsuario, contrasenaUsuario, persona, True)
    End Function

    Public Function ObtenerDiagnosticosPrimariosPorPaciente(paciente As Paciente) As List(Of DiagnosticoPrimario)
        Dim ds As New DataSet
        Dim comando As New MySqlCommand("SELECT * FROM ObtenerDatosDiagnosticos WHERE `ID paciente`=@ID_PACIENTE;")
        comando.Parameters.AddWithValue("@ID_PACIENTE", paciente.ID)
        ds.Tables.Add(ConexionBD.EjecutarConsulta(comando, "Diagnosticos"))
        comando.CommandText = "SELECT * FROM ObtenerSintomasDeDiagnosticosPrimarios;"
        ds.Tables.Add(ConexionBD.EjecutarConsulta(comando, "SintomasEvaluados"))
        comando.CommandText = "SELECT * FROM ObtenerEnfermedadesDeDiagnosticosPrimarios;"
        ds.Tables.Add(ConexionBD.EjecutarConsulta(comando, "EnfermedadesDiagnosticadas"))

        ds.Relations.Add(New DataRelation("sintomasEvaluados",
                                          ds.Tables("Diagnosticos").Columns("ID diagnostico primario"),
                                          ds.Tables("SintomasEvaluados").Columns("ID diagnostico primario")))
        ds.Relations.Add(New DataRelation("enfermedadesDiagnosticadas",
                                          ds.Tables("Diagnosticos").Columns("ID diagnostico primario"),
                                          ds.Tables("EnfermedadesDiagnosticadas").Columns("ID diagnostico primario")))



        Dim listaDiagnosticosPrimarios As New List(Of DiagnosticoPrimario)

        For i = 0 To ds.Tables("Diagnosticos").Rows.Count - 1
            Dim fila As DataRow = ds.Tables("Diagnosticos").Rows(i)

            Dim idDiagnostico As Integer = fila("ID diagnostico primario")
            Dim fechaHoraDiagnostico As Date = CType(fila("Fecha hora diagnostico primario"), MySqlDateTime).Value
            Dim tipoDiagnostico As TiposDiagnosticosPrimarios = [Enum].Parse(GetType(TiposDiagnosticosPrimarios), fila("Tipo diagnostico primario"))
            Dim comentariosDiagnostico As String = If(TypeOf fila("Comentarios consulta") IsNot DBNull, fila("Comentarios consulta"), Nothing)

            'Dim idPaciente As Integer = fila("ID paciente")
            'Dim ciPaciente As String = fila("CI paciente")
            'Dim nombrePaciente As String = fila("Nombre paciente")
            'Dim apellidoPaciente As String = fila("Apellido paciente")
            'Dim correoPaciente As String = fila("Correo paciente")
            'Dim telefonoMovilPaciente As String = fila("Telefonomovil paciente")
            'Dim telefonoFijoPaciente As String = fila("Telefonofijo paciente")
            'Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), fila("Sexo paciente"))
            'Dim fechaNacimientoPaciente As Date = CType(fila("Fecha nacimiento paciente"), MySqlDateTime).Value
            'Dim callePaciente As String = fila("Calle paciente")
            'Dim numeroPuertaPaciente As String = fila("Numero puerta paciente")
            'Dim apartamentoPaciente As String = If(TypeOf fila("Apartamento paciente") IsNot DBNull, fila("Apartamento paciente"), Nothing)
            'Dim idLocalidadPaciente As Integer = fila("ID localidad paciente")
            'Dim nombreLocalidadPaciente As String = fila("Nombre localidad paciente")
            'Dim idDepartamentoPaciente As Integer = fila("ID departamento paciente")
            'Dim nombreDepartamentoPaciente As String = fila("Nombre departamento paciente")

            'Dim departamentoPaciente As New Departamento(idDepartamentoPaciente, nombreDepartamentoPaciente)
            'Dim localidadPaciente As New Localidad(idLocalidadPaciente, nombreLocalidadPaciente, departamentoPaciente)
            'Dim paciente As New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, localidadPaciente, telefonoMovilPaciente,
            '                             telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente, callePaciente, numeroPuertaPaciente,
            '                             apartamentoPaciente)

            Dim sintomas As New List(Of Sintoma)
            For Each filaSintoma As DataRow In fila.GetChildRows("sintomasEvaluados")
                Dim idSintoma As Integer = filaSintoma("ID Sintoma")
                Dim nombreSintoma As String = filaSintoma("Nombre Sintoma")
                Dim descripcionSintoma As String = filaSintoma("Descripcion Sintoma")
                Dim recomendacionesSintoma As String = filaSintoma("Recomendaciones Sintoma")
                Dim urgenciaSintoma As String = filaSintoma("Urgencia Sintoma")
                Dim habilitadoSintoma As Boolean = filaSintoma("Habilitado Sintoma")
                sintomas.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma, Nothing, habilitadoSintoma))
            Next

            Dim enfermedades As New List(Of Enfermedad)
            Dim probabilidades As New List(Of Decimal)
            For Each filaEnfermedad As DataRow In fila.GetChildRows("enfermedadesDiagnosticadas")
                Dim idEnfermedad As Integer = filaEnfermedad("ID enfermedad")
                Dim nombreEnfermedad As String = filaEnfermedad("Nombre enfermedad")
                Dim descripcionEnfermedad As String = filaEnfermedad("Descripcion enfermedad")
                Dim recomendacionesEnfermedad As String = filaEnfermedad("Recomendaciones enfermedad")
                Dim gravedadEnfermedad As Integer = filaEnfermedad("Gravedad enfermedad")
                Dim habilitadoEnfermedad As Boolean = filaEnfermedad("Habilitado enfermedad")
                Dim probabilidadEnfermedad As Double = filaEnfermedad("Probabilidad enfermedad")

                Dim idEspecialidad As Integer = filaEnfermedad("ID especialidad")
                Dim nombreEspecialidad As String = filaEnfermedad("Nombre especialidad")
                Dim habilitadoEspecialidad As Boolean = filaEnfermedad("Habilitado especialidad")
                Dim especialidadEnfermedad As New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad)

                enfermedades.Add(New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad, descripcionEnfermedad,
                                                     Nothing, especialidadEnfermedad, habilitadoEnfermedad))
                probabilidades.Add(probabilidadEnfermedad)
            Next
            Dim enfermedadesDiagnosticadas As New EnfermedadesDiagnosticadas(enfermedades, probabilidades)

            If tipoDiagnostico = TiposDiagnosticosPrimarios.Sin_Consulta Then
                listaDiagnosticosPrimarios.Add(New DiagnosticoPrimario(idDiagnostico, paciente, sintomas, enfermedadesDiagnosticadas, fechaHoraDiagnostico,
                                                                       tipoDiagnostico))
            Else
                Dim medico As Medico
                If TypeOf fila("ID medico") IsNot DBNull Then
                    Dim idMedico As Integer = fila("ID medico")
                    Dim ciMedico As String = fila("CI medico")
                    Dim nombreMedico As String = fila("Nombre medico")
                    Dim apellidoMedico As String = fila("Apellido medico")
                    Dim correoMedico As String = fila("Correo medico")
                    Dim habilitadoMedico As Boolean = fila("Habilitado medico")
                    Dim idLocalidad As String = fila("ID localidad medico")
                    Dim nombreLocalidad As String = fila("Nombre localidad medico")
                    Dim idDepartamento As String = fila("ID departamento medico")
                    Dim nombreDepartamento As String = fila("Nombre departamento medico")

                    Dim departamentoLocalidad As New Departamento(idDepartamento, nombreDepartamento)
                    Dim localidadMedico As New Localidad(idLocalidad, nombreLocalidad, departamentoLocalidad)
                    medico = New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, localidadMedico, Nothing, habilitadoMedico)
                Else
                    medico = Nothing
                End If

                listaDiagnosticosPrimarios.Add(New DiagnosticoPrimarioConConsulta(idDiagnostico, paciente, sintomas, enfermedadesDiagnosticadas,
                                                                                  fechaHoraDiagnostico, medico, comentariosDiagnostico))
            End If
        Next

        Return listaDiagnosticosPrimarios
    End Function

    Public Function ObtenerUltimosDiagnosticosPrimariosConConsultaPorMedico(medico As Medico, mesesHistorial As Integer) As List(Of DiagnosticoPrimarioConConsulta)
        Dim ds As New DataSet

        ' WHERE ID_MEDICO={0} AND FECHA_HORA > DATE_SUB(NOW(), INTERVAL {1} MONTH)


        Dim comando As New MySqlCommand("SELECT * FROM ObtenerDatosDiagnosticos WHERE `ID paciente`=@ID_PACIENTE;")
        comando.Parameters.AddWithValue("@ID_PACIENTE", Paciente.ID)
        ds.Tables.Add(ConexionBD.EjecutarConsulta(comando, "Diagnosticos"))
        comando.CommandText = "SELECT * FROM ObtenerSintomasDeDiagnosticosPrimarios;"
        ds.Tables.Add(ConexionBD.EjecutarConsulta(comando, "SintomasEvaluados"))
        comando.CommandText = "SELECT * FROM ObtenerEnfermedadesDeDiagnosticosPrimarios;"
        ds.Tables.Add(ConexionBD.EjecutarConsulta(comando, "EnfermedadesDiagnosticadas"))

        ds.Relations.Add(New DataRelation("sintomasEvaluados",
                                          ds.Tables("Diagnosticos").Columns("ID diagnostico primario"),
                                          ds.Tables("SintomasEvaluados").Columns("ID diagnostico primario")))
        ds.Relations.Add(New DataRelation("enfermedadesDiagnosticadas",
                                          ds.Tables("Diagnosticos").Columns("ID diagnostico primario"),
                                          ds.Tables("EnfermedadesDiagnosticadas").Columns("ID diagnostico primario")))



        Dim listaDiagnosticosPrimarios As New List(Of DiagnosticoPrimario)

        For i = 0 To ds.Tables("Diagnosticos").Rows.Count - 1
            Dim fila As DataRow = ds.Tables("Diagnosticos").Rows(i)

            Dim idDiagnostico As Integer = fila("ID diagnostico primario")
            Dim fechaHoraDiagnostico As Date = CType(fila("Fecha hora diagnostico primario"), MySqlDateTime).Value
            Dim tipoDiagnostico As TiposDiagnosticosPrimarios = [Enum].Parse(GetType(TiposDiagnosticosPrimarios), fila("Tipo diagnostico primario"))
            Dim comentariosDiagnostico As String = If(TypeOf fila("Comentarios consulta") IsNot DBNull, fila("Comentarios consulta"), Nothing)

            'Dim idPaciente As Integer = fila("ID paciente")
            'Dim ciPaciente As String = fila("CI paciente")
            'Dim nombrePaciente As String = fila("Nombre paciente")
            'Dim apellidoPaciente As String = fila("Apellido paciente")
            'Dim correoPaciente As String = fila("Correo paciente")
            'Dim telefonoMovilPaciente As String = fila("Telefonomovil paciente")
            'Dim telefonoFijoPaciente As String = fila("Telefonofijo paciente")
            'Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), fila("Sexo paciente"))
            'Dim fechaNacimientoPaciente As Date = CType(fila("Fecha nacimiento paciente"), MySqlDateTime).Value
            'Dim callePaciente As String = fila("Calle paciente")
            'Dim numeroPuertaPaciente As String = fila("Numero puerta paciente")
            'Dim apartamentoPaciente As String = If(TypeOf fila("Apartamento paciente") IsNot DBNull, fila("Apartamento paciente"), Nothing)
            'Dim idLocalidadPaciente As Integer = fila("ID localidad paciente")
            'Dim nombreLocalidadPaciente As String = fila("Nombre localidad paciente")
            'Dim idDepartamentoPaciente As Integer = fila("ID departamento paciente")
            'Dim nombreDepartamentoPaciente As String = fila("Nombre departamento paciente")

            'Dim departamentoPaciente As New Departamento(idDepartamentoPaciente, nombreDepartamentoPaciente)
            'Dim localidadPaciente As New Localidad(idLocalidadPaciente, nombreLocalidadPaciente, departamentoPaciente)
            'Dim paciente As New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, localidadPaciente, telefonoMovilPaciente,
            '                             telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente, callePaciente, numeroPuertaPaciente,
            '                             apartamentoPaciente)

            Dim sintomas As New List(Of Sintoma)
            For Each filaSintoma As DataRow In fila.GetChildRows("sintomasEvaluados")
                Dim idSintoma As Integer = filaSintoma("ID Sintoma")
                Dim nombreSintoma As String = filaSintoma("Nombre Sintoma")
                Dim descripcionSintoma As String = filaSintoma("Descripcion Sintoma")
                Dim recomendacionesSintoma As String = filaSintoma("Recomendaciones Sintoma")
                Dim urgenciaSintoma As String = filaSintoma("Urgencia Sintoma")
                Dim habilitadoSintoma As Boolean = filaSintoma("Habilitado Sintoma")
                sintomas.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma, Nothing, habilitadoSintoma))
            Next

            Dim enfermedades As New List(Of Enfermedad)
            Dim probabilidades As New List(Of Decimal)
            For Each filaEnfermedad As DataRow In fila.GetChildRows("enfermedadesDiagnosticadas")
                Dim idEnfermedad As Integer = filaEnfermedad("ID enfermedad")
                Dim nombreEnfermedad As String = filaEnfermedad("Nombre enfermedad")
                Dim descripcionEnfermedad As String = filaEnfermedad("Descripcion enfermedad")
                Dim recomendacionesEnfermedad As String = filaEnfermedad("Recomendaciones enfermedad")
                Dim gravedadEnfermedad As Integer = filaEnfermedad("Gravedad enfermedad")
                Dim habilitadoEnfermedad As Boolean = filaEnfermedad("Habilitado enfermedad")
                Dim probabilidadEnfermedad As Double = filaEnfermedad("Probabilidad enfermedad")

                Dim idEspecialidad As Integer = filaEnfermedad("ID especialidad")
                Dim nombreEspecialidad As String = filaEnfermedad("Nombre especialidad")
                Dim habilitadoEspecialidad As Boolean = filaEnfermedad("Habilitado especialidad")
                Dim especialidadEnfermedad As New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad)

                enfermedades.Add(New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad, descripcionEnfermedad,
                                                     Nothing, especialidadEnfermedad, habilitadoEnfermedad))
                probabilidades.Add(probabilidadEnfermedad)
            Next
            Dim enfermedadesDiagnosticadas As New EnfermedadesDiagnosticadas(enfermedades, probabilidades)

            If tipoDiagnostico = TiposDiagnosticosPrimarios.Sin_Consulta Then
                listaDiagnosticosPrimarios.Add(New DiagnosticoPrimario(idDiagnostico, Paciente, sintomas, enfermedadesDiagnosticadas, fechaHoraDiagnostico,
                                                                       tipoDiagnostico))
            Else
                Dim medico As Medico
                If TypeOf fila("ID medico") IsNot DBNull Then
                    Dim idMedico As Integer = fila("ID medico")
                    Dim ciMedico As String = fila("CI medico")
                    Dim nombreMedico As String = fila("Nombre medico")
                    Dim apellidoMedico As String = fila("Apellido medico")
                    Dim correoMedico As String = fila("Correo medico")
                    Dim habilitadoMedico As Boolean = fila("Habilitado medico")
                    Dim idLocalidad As String = fila("ID localidad medico")
                    Dim nombreLocalidad As String = fila("Nombre localidad medico")
                    Dim idDepartamento As String = fila("ID departamento medico")
                    Dim nombreDepartamento As String = fila("Nombre departamento medico")

                    Dim departamentoLocalidad As New Departamento(idDepartamento, nombreDepartamento)
                    Dim localidadMedico As New Localidad(idLocalidad, nombreLocalidad, departamentoLocalidad)
                    medico = New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, localidadMedico, Nothing, habilitadoMedico)
                Else
                    medico = Nothing
                End If

                listaDiagnosticosPrimarios.Add(New DiagnosticoPrimarioConConsulta(idDiagnostico, Paciente, sintomas, enfermedadesDiagnosticadas,
                                                                                  fechaHoraDiagnostico, medico, comentariosDiagnostico))
            End If
        Next

        Return listaDiagnosticosPrimarios




        'Dim lista As New List(Of DiagnosticoPrimarioConConsulta)
        'For Each rDiagnosticoPrimarioConConsulta As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM diagnosticos_primarios d1 JOIN diagnosticos_primarios_con_consulta d2 ON d1.ID=d2.ID_DIAGNOSTICO_PRIMARIO WHERE ID_MEDICO={0} AND FECHA_HORA > DATE_SUB(NOW(), INTERVAL {1} MONTH)", medico.ID, mesesHistorial), "diagnosticos_primarios_con_consulta").Rows
        '    Dim idDiagnosticoPrimarioConConsulta As Integer = rDiagnosticoPrimarioConConsulta("ID_DIAGNOSTICO_PRIMARIO")
        '    Dim comentariosAdicionalesDiagnosticoPrimarioConConsulta As String = rDiagnosticoPrimarioConConsulta("COMENTARIOS_ADICIONALES")
        '    Dim fechaHoraDiagnosticoPrimarioConConsulta As Date = CType(rDiagnosticoPrimarioConConsulta("FECHA_HORA"), MySqlDateTime).Value
        '    Dim tipoDiagnosticoPrimario As TiposDiagnosticosPrimarios = [Enum].Parse(GetType(TiposDiagnosticosPrimarios), rDiagnosticoPrimarioConConsulta("TIPO"))

        '    Dim sintomasDiagnosticoPrimarioConConsulta As New List(Of Sintoma)
        '    For Each rSistemaEvalua As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM sistema_evalua WHERE ID_DIAGNOSTICO_PRIMARIO={0}", idDiagnosticoPrimarioConConsulta), "diagnosticos_primarios").Rows
        '        Dim idSintoma As Integer = rSistemaEvalua("ID_SINTOMA")
        '        Dim rSintoma As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM sintomas WHERE ID={0}", idSintoma), "diagnosticos_primarios").Rows(0)
        '        Dim nombreSintoma As String = rSintoma("NOMBRE")
        '        Dim descripcionSintoma As String = rSintoma("DESCRIPCION")
        '        Dim recomendacionesSintoma As String = rSintoma("RECOMENDACIONES")
        '        Dim urgenciaSintoma As String = rSintoma("URGENCIA")
        '        Dim habilitadoSintoma As Boolean = rSintoma("HABILITADO")

        '        sintomasDiagnosticoPrimarioConConsulta.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma, Nothing, habilitadoSintoma))
        '    Next

        '    Dim enfermedadesDiagnosticoPrimarioConConsulta As New List(Of Enfermedad)
        '    Dim probabilidadesEnfermedadesConConsulta As New List(Of Decimal)
        '    For Each rSistemaDiagnostica As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM sistema_diagnostica WHERE ID_DIAGNOSTICO_PRIMARIO={0}", idDiagnosticoPrimarioConConsulta), "sistema_diagnostica").Rows
        '        Dim idEnfermedad As Integer = rSistemaDiagnostica("ID_ENFERMEDAD")
        '        Dim rEnfermedad As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM enfermedades WHERE ID={0}", idEnfermedad), "enfermedades").Rows(0)
        '        Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
        '        Dim recomendacionesEnfermedad As String = ""
        '        If TypeOf rEnfermedad("RECOMENDACIONES") IsNot DBNull Then
        '            recomendacionesEnfermedad = rEnfermedad("RECOMENDACIONES")
        '        End If
        '        Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
        '        Dim descripcionEnfermedad As String = ""
        '        If TypeOf rEnfermedad("DESCRIPCION") IsNot DBNull Then
        '            descripcionEnfermedad = rEnfermedad("DESCRIPCION")
        '        End If
        '        Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")
        '        Dim probabilidadEnfermedad As Decimal = rSistemaDiagnostica("PROBABILIDAD")

        '        Dim idEspecialidad As Integer = rEnfermedad("ID_ESPECIALIDAD")
        '        Dim rEspecialidad As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM especialidades WHERE ID={0}", idEspecialidad), "especialidades").Rows(0)
        '        Dim nombreEspecialidad As String = rEspecialidad("NOMBRE")
        '        Dim habilitadoEspecialidad As Boolean = rEspecialidad("HABILITADO")
        '        Dim especialidadEnfermedad As New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad)

        '        enfermedadesDiagnosticoPrimarioConConsulta.Add(New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad,
        '                                                            descripcionEnfermedad, Nothing, especialidadEnfermedad, habilitadoEnfermedad))
        '        probabilidadesEnfermedadesConConsulta.Add(rSistemaDiagnostica("PROBABILIDAD"))
        '    Next
        '    Dim enfermedadesDiagnosticadas As New EnfermedadesDiagnosticadas(enfermedadesDiagnosticoPrimarioConConsulta, probabilidadesEnfermedadesConConsulta)

        '    Dim idPaciente As Integer = rDiagnosticoPrimarioConConsulta("ID_PACIENTE")
        '    Dim rPaciente As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM pacientes WHERE ID_PERSONA={0}", idPaciente), "pacientes").Rows(0)
        '    Dim rPersona As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM personas WHERE ID={0}", idPaciente), "personas").Rows(0)
        '    Dim ciPaciente As String = rPersona("CI")
        '    Dim nombrePaciente As String = rPersona("NOMBRE")
        '    Dim apellidoPaciente As String = rPersona("APELLIDO")
        '    Dim correoPaciente As String = rPersona("CORREO")
        '    Dim telefonoMovilPaciente As String = rPaciente("TELEFONOMOVIL")
        '    Dim telefonoFijoPaciente As String = rPaciente("TELEFONOFIJO")
        '    Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), rPaciente("SEXO"))
        '    Dim fechaNacimientoPaciente As Date = CType(rPaciente("FECHANACIMIENTO"), MySqlDateTime).Value
        '    Dim callePaciente As String = rPaciente("CALLE")
        '    Dim numeroPuertaPaciente As String = rPaciente("NUMEROPUERTA")
        '    Dim apartamentoPaciente As String = ""
        '    If TypeOf rPaciente("APARTAMENTO") IsNot DBNull Then
        '        apartamentoPaciente = rPaciente("APARTAMENTO")
        '    End If

        '    Dim pacienteDiagnosticoPrimarioConConsulta As New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente,
        '                                                               Nothing, telefonoMovilPaciente, telefonoFijoPaciente, sexoPaciente,
        '                                                               fechaNacimientoPaciente, callePaciente, numeroPuertaPaciente, apartamentoPaciente)

        '    lista.Add(New DiagnosticoPrimarioConConsulta(idDiagnosticoPrimarioConConsulta, pacienteDiagnosticoPrimarioConConsulta,
        '                                                 sintomasDiagnosticoPrimarioConConsulta, enfermedadesDiagnosticadas,
        '                                                 fechaHoraDiagnosticoPrimarioConConsulta, medico, comentariosAdicionalesDiagnosticoPrimarioConConsulta))
        'Next
        'Return lista
    End Function

    Public Function ObtenerUltimosMensajesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta, cantidadARetornar As Integer) As List(Of Mensaje)
        Dim lista As New List(Of Mensaje)
        'Dim cantidadMensajes As Integer = ObtenerCantidadDiagnosticosDiferencialesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta)
        'Dim indicePrimerMensaje As Integer = cantidadMensajes - cantidadARetornar + 1
        'Dim comando As String = ""
        'If indicePrimerMensaje > 0 Then
        '    comando = String.Format("SELECT * FROM mensajes WHERE ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA={0} ORDER BY FECHAHORA ASC LIMIT {1},{2}", diagnosticoPrimarioConConsulta.ID, indicePrimerMensaje, indicePrimerMensaje + cantidadARetornar - 1)
        'Else
        '    comando = String.Format("SELECT * FROM mensajes WHERE ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA={0} ORDER BY FECHAHORA DESC LIMIT {1}", diagnosticoPrimarioConConsulta.ID, cantidadARetornar)
        'End If

        For Each rMensaje As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM mensajes WHERE ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA={0} ORDER BY FECHAHORA DESC LIMIT {1}", diagnosticoPrimarioConConsulta.ID, cantidadARetornar), "especialidades").Rows
            Dim idMensaje As Integer = rMensaje("ID")
            Dim fechaHoraMensaje As Date = CType(rMensaje("FECHAHORA"), MySqlDateTime).Value
            Dim formatoMensaje As FormatosMensajeAdmitidos = [Enum].Parse(GetType(FormatosMensajeAdmitidos), rMensaje("FORMATO"))
            Dim contenidoMensaje() As Byte = rMensaje("CONTENIDO")
            Dim remitenteMensaje As TiposRemitente = [Enum].Parse(GetType(TiposRemitente), rMensaje("REMITENTE"))

            lista.Add(New Mensaje(idMensaje, fechaHoraMensaje, formatoMensaje, contenidoMensaje, remitenteMensaje, diagnosticoPrimarioConConsulta))
        Next
        Return lista
    End Function

    Public Function ObtenerCantidadMensajesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta) As Integer
        Dim cantidad As Integer = ConexionBD.EjecutarConsulta(String.Format("SELECT COUNT(*) FROM mensajes WHERE ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA={0}",
                                                                            diagnosticoPrimarioConConsulta.ID), "mensajes").Rows(0)(0)
        Return cantidad
    End Function

    Public Function ObtenerCantidadDiagnosticosDiferencialesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta) As Integer
        Dim cantidad As Integer = ConexionBD.EjecutarConsulta(String.Format("SELECT COUNT(*) FROM diagnosticos_diferenciales WHERE ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA={0}",
                                                                            diagnosticoPrimarioConConsulta.ID), "mensajes").Rows(0)(0)
        Return cantidad
    End Function

    Public Function ObtenerDiagnosticosDiferencialesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta) As List(Of DiagnosticoDiferencial)
        Dim lista As New List(Of DiagnosticoDiferencial)
        For Each rDiagnosticoDiferencial As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM diagnosticos_diferenciales WHERE ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA={0} ORDER BY FECHAHORA DESC", diagnosticoPrimarioConConsulta.ID), "diagnosticos_diferenciales").Rows
            Dim idDiagnosticoDiferencial As Integer = rDiagnosticoDiferencial("ID")
            Dim conductaASeguirDiagnosticoDiferencial As String = rDiagnosticoDiferencial("CONDUCTA_A_SEGUIR")
            Dim fechaHoraDiagnosticoDiferencial As Date = CType(rDiagnosticoDiferencial("FECHAHORA"), MySqlDateTime).Value

            Dim idEnfermedad As Integer = rDiagnosticoDiferencial("ID_ENFERMEDAD")
            Dim rEnfermedad As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM enfermedades WHERE ID={0}", idEnfermedad), "enfermedades").Rows(0)
            Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
            Dim descripcionEnfermedad As String = rEnfermedad("DESCRIPCION")
            Dim recomendacionesEnfermedad As String = rEnfermedad("RECOMENDACIONES")
            Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
            Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")

            Dim idEspecialidad As Integer = rEnfermedad("ID_ESPECIALIDAD")
            Dim rEspecialidad As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM especialidades WHERE ID={0}", idEspecialidad), "especialidades").Rows(0)
            Dim nombreEspecialidad As String = rEspecialidad("NOMBRE")
            Dim habilitadoEspecialidad As Boolean = rEspecialidad("HABILITADO")
            Dim especialidadEnfermedad As New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad)

            Dim sintomasEnfermedad As New List(Of Sintoma)
            Dim frecuenciasSintomasEnfermedad As New List(Of Decimal)
            For Each rCuadroSintomatico As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM cuadro_sintomatico WHERE ID_ENFERMEDAD={0}", idEnfermedad), "cuadro_sintomatico").Rows
                Dim idSintoma As Integer = rCuadroSintomatico("ID_SINTOMA")
                Dim rSintoma As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM sintomas WHERE ID={0}", idSintoma), "sintomas").Rows(0)
                Dim nombreSintoma As String = rSintoma("NOMBRE")
                Dim descripcionSintoma As String = rSintoma("DESCRIPCION")
                Dim recomendacionesSintoma As String = rSintoma("RECOMENDACIONES")
                Dim urgenciaSintoma As Integer = rSintoma("URGENCIA")
                Dim habilitadoSintoma As Boolean = rSintoma("HABILITADO")
                Dim frecuenciaSintoma As Decimal = rCuadroSintomatico("FRECUENCIA")

                sintomasEnfermedad.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma, Nothing, habilitadoEnfermedad))
                frecuenciasSintomasEnfermedad.Add(frecuenciaSintoma)
            Next

            Dim sintomasAsociadosEnfermedad As New SintomasAsociados(sintomasEnfermedad, frecuenciasSintomasEnfermedad)

            Dim enfermedadDiagnosticoDiferencial As Enfermedad = New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad,
                                                                                    gravedadEnfermedad, descripcionEnfermedad, sintomasAsociadosEnfermedad,
                                                                                    especialidadEnfermedad, habilitadoEnfermedad)

            lista.Add(New DiagnosticoDiferencial(idDiagnosticoDiferencial, diagnosticoPrimarioConConsulta, enfermedadDiagnosticoDiferencial,
                                                 conductaASeguirDiagnosticoDiferencial, fechaHoraDiagnosticoDiferencial))
        Next
        Return lista
    End Function

    Public Function ObtenerConsultasSinAtender() As List(Of DiagnosticoPrimarioConConsulta)
        Dim lista As New List(Of DiagnosticoPrimarioConConsulta)
        For Each rDiagnosticoPrimarioConConsulta As DataRow In ConexionBD.EjecutarConsulta("SELECT * FROM diagnosticos_primarios_con_consulta WHERE ID_MEDICO IS NULL", "diagnosticos_primarios_con_consulta").Rows
            Dim idDiagnosticoPrimarioConConsulta As Integer = rDiagnosticoPrimarioConConsulta("ID_DIAGNOSTICO_PRIMARIO")
            Dim comentariosAdicionalesDiagnosticoPrimarioConConsulta As String = rDiagnosticoPrimarioConConsulta("COMENTARIOS_ADICIONALES")
            Dim rDiagnosticoPrimario As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM diagnosticos_primarios WHERE ID={0}", idDiagnosticoPrimarioConConsulta), "diagnosticos_primarios").Rows(0)
            Dim fechaHoraDiagnosticoPrimarioConConsulta As Date = CType(rDiagnosticoPrimario("FECHA_HORA"), MySqlDateTime).Value
            Dim tipoDiagnosticoPrimario As TiposDiagnosticosPrimarios = [Enum].Parse(GetType(TiposDiagnosticosPrimarios), rDiagnosticoPrimario("TIPO"))

            Dim sintomasDiagnosticoPrimarioConConsulta As New List(Of Sintoma)
            For Each rSistemaEvalua As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM sistema_evalua WHERE ID_DIAGNOSTICO_PRIMARIO={0}", idDiagnosticoPrimarioConConsulta), "diagnosticos_primarios").Rows
                Dim idSintoma As Integer = rSistemaEvalua("ID_SINTOMA")
                Dim rSintoma As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM sintomas WHERE ID={0}", idSintoma), "diagnosticos_primarios").Rows(0)
                Dim nombreSintoma As String = rSintoma("NOMBRE")
                Dim descripcionSintoma As String = rSintoma("DESCRIPCION")
                Dim recomendacionesSintoma As String = rSintoma("RECOMENDACIONES")
                Dim urgenciaSintoma As String = rSintoma("URGENCIA")
                Dim habilitadoSintoma As Boolean = rSintoma("HABILITADO")

                sintomasDiagnosticoPrimarioConConsulta.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma, Nothing, habilitadoSintoma))
            Next

            Dim enfermedadesDiagnosticoPrimarioConConsulta As New List(Of Enfermedad)
            Dim probabilidadesEnfermedadesConConsulta As New List(Of Decimal)
            For Each rSistemaDiagnostica As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM sistema_diagnostica WHERE ID_DIAGNOSTICO_PRIMARIO={0}", idDiagnosticoPrimarioConConsulta), "sistema_diagnostica").Rows
                Dim idEnfermedad As Integer = rSistemaDiagnostica("ID_ENFERMEDAD")
                Dim rEnfermedad As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM enfermedades WHERE ID={0}", idEnfermedad), "enfermedades").Rows(0)
                Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
                Dim recomendacionesEnfermedad As String = ""
                If TypeOf rEnfermedad("RECOMENDACIONES") IsNot DBNull Then
                    recomendacionesEnfermedad = rEnfermedad("RECOMENDACIONES")
                End If
                Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
                Dim descripcionEnfermedad As String = ""
                If TypeOf rEnfermedad("DESCRIPCION") IsNot DBNull Then
                    descripcionEnfermedad = rEnfermedad("DESCRIPCION")
                End If
                Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")
                Dim probabilidadEnfermedad As Decimal = rSistemaDiagnostica("PROBABILIDAD")

                Dim idEspecialidad As Integer = rEnfermedad("ID_ESPECIALIDAD")
                Dim rEspecialidad As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM especialidades WHERE ID={0}", idEspecialidad), "especialidades").Rows(0)
                Dim nombreEspecialidad As String = rEspecialidad("NOMBRE")
                Dim habilitadoEspecialidad As Boolean = rEspecialidad("HABILITADO")
                Dim especialidadEnfermedad As New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad)

                enfermedadesDiagnosticoPrimarioConConsulta.Add(New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad,
                                                                    descripcionEnfermedad, Nothing, especialidadEnfermedad, habilitadoEnfermedad))
                probabilidadesEnfermedadesConConsulta.Add(rSistemaDiagnostica("PROBABILIDAD"))
            Next
            Dim enfermedadesDiagnosticadas As New EnfermedadesDiagnosticadas(enfermedadesDiagnosticoPrimarioConConsulta, probabilidadesEnfermedadesConConsulta)

            Dim idPaciente As Integer = rDiagnosticoPrimario("ID_PACIENTE")
            Dim rPaciente As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM pacientes WHERE ID_PERSONA={0}", idPaciente), "pacientes").Rows(0)
            Dim rPersona As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM personas WHERE ID={0}", idPaciente), "personas").Rows(0)
            Dim ciPaciente As String = rPersona("CI")
            Dim nombrePaciente As String = rPersona("NOMBRE")
            Dim apellidoPaciente As String = rPersona("APELLIDO")
            Dim correoPaciente As String = rPersona("CORREO")
            Dim telefonoMovilPaciente As String = rPaciente("TELEFONOMOVIL")
            Dim telefonoFijoPaciente As String = rPaciente("TELEFONOFIJO")
            Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), rPaciente("SEXO"))
            Dim fechaNacimientoPaciente As Date = CType(rPaciente("FECHANACIMIENTO"), MySqlDateTime).Value
            Dim callePaciente As String = rPaciente("CALLE")
            Dim numeroPuertaPaciente As String = rPaciente("NUMEROPUERTA")
            Dim apartamentoPaciente As String = ""
            If TypeOf rPaciente("APARTAMENTO") IsNot DBNull Then
                apartamentoPaciente = rPaciente("APARTAMENTO")
            End If

            Dim pacienteDiagnosticoPrimarioConConsulta As New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente,
                                                                       Nothing, telefonoMovilPaciente, telefonoFijoPaciente, sexoPaciente,
                                                                       fechaNacimientoPaciente, callePaciente, numeroPuertaPaciente, apartamentoPaciente)

            lista.Add(New DiagnosticoPrimarioConConsulta(idDiagnosticoPrimarioConConsulta, pacienteDiagnosticoPrimarioConConsulta,
                                                         sintomasDiagnosticoPrimarioConConsulta, enfermedadesDiagnosticadas,
                                                         fechaHoraDiagnosticoPrimarioConConsulta, Nothing,
                                                         comentariosAdicionalesDiagnosticoPrimarioConConsulta))
        Next
        Return lista
    End Function

    Public Sub AsignarIDMedicoAConsulta(medico As Medico, consulta As DiagnosticoPrimarioConConsulta)
        ConexionBD.Conexion.Open()
        Dim comando As New MySqlCommand("UPDATE diagnosticos_primarios_con_consulta SET ID_MEDICO=@ID_MEDICO WHERE ID_DIAGNOSTICO_PRIMARIO=@ID_DIAGNOSTICO;")
        comando.Parameters.AddWithValue("@ID_MEDICO", consulta.Medico.ID)
        comando.Parameters.AddWithValue("@ID_DIAGNOSTICO", consulta.ID)
        ConexionBD.EjecutarTransaccion(comando)
        ConexionBD.Conexion.Close()
    End Sub

#Region "Código comentado"
    ' FALTA MANEJO DE ERRORES PARA GETTERS DE USUARIOS
    'Private Function ObtenerUsuarioMedicoPorCI(ci As String) As Usuario
    '    Dim rPersona As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM personas WHERE CI='{0}' AND TIPO='Funcionario'", ci), "personas").Rows(0)
    '    Dim idMedico As Integer = rPersona("ID")
    '    Dim ciMedico As String = rPersona("CI")
    '    Dim nombreMedico As String = rPersona("NOMBRE")
    '    Dim apellidoMedico As String = rPersona("APELLIDO")
    '    Dim correoMedico As String = rPersona("CORREO")

    '    Dim rFuncionario As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM funcionarios WHERE ID_PERSONA='{0}'", idMedico), "funcionarios").Rows(0)
    '    Dim habilitadoMedico As Boolean = rFuncionario("HABILITADO")

    '    Dim medicoUsuario As New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, Nothing, Nothing, habilitadoMedico)

    '    Dim rUsuario As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM usuarios WHERE ID_PERSONA='{0}'", idMedico), "usuarios").Rows(0)
    '    Dim idUsuario As Integer = rUsuario("ID")
    '    Dim contrasenaUsuario As String = rUsuario("CONTRASENIA")
    '    Dim tipoUsuario As TiposUsuario = [Enum].Parse(GetType(TiposUsuario), rUsuario("TIPO"))
    '    Dim habilitadoUsuario As Boolean = rUsuario("HABILITADO")

    '    Dim usuario As New Usuario(idUsuario, contrasenaUsuario, medicoUsuario, habilitadoUsuario)
    '    Return usuario
    'End Function

    'Private Function ObtenerUsuarioPacientePorCI(ci As String) As Usuario
    '    Dim rPersona As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM personas WHERE CI='{0}' AND TIPO='Paciente'", ci), "personas").Rows(0)
    '    Dim idPaciente As Integer = rPersona("ID")
    '    Dim ciPaciente As String = rPersona("CI")
    '    Dim nombrePaciente As String = rPersona("NOMBRE")
    '    Dim apellidoPaciente As String = rPersona("APELLIDO")
    '    Dim correoPaciente As String = rPersona("CORREO")
    '    Dim rPaciente As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM pacientes WHERE ID_PERSONA={0}", idPaciente), "pacientes").Rows(0)
    '    Dim telefonoMovilPaciente As String = rPaciente("TELEFONOMOVIL")
    '    Dim telefonoFijoPaciente As String = rPaciente("TELEFONOFIJO")
    '    Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), rPaciente("SEXO"))
    '    Dim fechaNacimientoPaciente As Date = CType(rPaciente("FECHANACIMIENTO"), MySqlDateTime).Value
    '    Dim callePaciente As String = rPaciente("CALLE")
    '    Dim numeroPuertaPaciente As String = rPaciente("NUMEROPUERTA")
    '    Dim apartamentoPaciente As String = ""
    '    If TypeOf rPaciente("APARTAMENTO") IsNot DBNull Then
    '        apartamentoPaciente = rPaciente("APARTAMENTO")
    '    End If

    '    Dim pacienteUsuario As New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, Nothing, telefonoMovilPaciente,
    '                                        telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente, callePaciente, numeroPuertaPaciente,
    '                                        apartamentoPaciente)

    '    Dim rUsuario As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM usuarios WHERE ID_PERSONA='{0}'", idPaciente), "usuarios").Rows(0)
    '    Dim idUsuario As Integer = rUsuario("ID")
    '    Dim contrasenaUsuario As String = rUsuario("CONTRASENIA")
    '    Dim tipoUsuario As TiposUsuario = [Enum].Parse(GetType(TiposUsuario), rUsuario("TIPO"))
    '    Dim habilitadoUsuario As Boolean = rUsuario("HABILITADO")

    '    Dim usuario As New Usuario(idUsuario, contrasenaUsuario, pacienteUsuario, habilitadoUsuario)
    '    Return usuario
    'End Function

    'Private Function ObtenerUsuarioAdministrativoPorCI(ci As String) As Usuario
    '    Dim rPersona As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM personas WHERE CI='{0}' AND TIPO='Funcionario'", ci), "personas").Rows(0)
    '    Dim idAdministrativo As Integer = rPersona("ID")
    '    Dim ciAdministrativo As String = rPersona("CI")
    '    Dim nombreAdministrativo As String = rPersona("NOMBRE")
    '    Dim apellidoAdministrativo As String = rPersona("APELLIDO")
    '    Dim correoAdministrativo As String = rPersona("CORREO")

    '    Dim rFuncionario As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM funcionarios WHERE ID_PERSONA='{0}'", idAdministrativo), "funcionarios").Rows(0)
    '    Dim habilitadoAdministrativo As Boolean = rFuncionario("HABILITADO")

    '    Dim rAdministrativo As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM administrativos WHERE ID_FUNCIONARIO='{0}'", idAdministrativo), "administrativos").Rows(0)
    '    Dim esEncargadoAdministrativo As Boolean = rAdministrativo("ES_ENCARGADO")

    '    Dim administrativoUsuario As New Administrativo(idAdministrativo, ciAdministrativo, nombreAdministrativo, apellidoAdministrativo,
    '                                                    correoAdministrativo, Nothing, esEncargadoAdministrativo, habilitadoAdministrativo)

    '    Dim rUsuario As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM usuarios WHERE ID_PERSONA='{0}'", idAdministrativo), "usuarios").Rows(0)
    '    Dim idUsuario As Integer = rUsuario("ID")
    '    Dim contrasenaUsuario As String = rUsuario("CONTRASENIA")
    '    Dim tipoUsuario As TiposUsuario = [Enum].Parse(GetType(TiposUsuario), rUsuario("TIPO"))
    '    Dim habilitadoUsuario As Boolean = rUsuario("HABILITADO")

    '    Dim usuario As New Usuario(idUsuario, contrasenaUsuario, administrativoUsuario, habilitadoUsuario)
    '    Return usuario
    'End Function

    'Private Function ObtenerPacientePorUsuario(usuario As Usuario) As Paciente
    '    Dim rPersona As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM personas WHERE ID={0}", usuario.Persona.ID), "personas").Rows(0)
    '    Dim idPaciente As Integer = rPersona("ID")
    '    Dim ciPaciente As String = rPersona("CI")
    '    Dim nombrePaciente As String = rPersona("NOMBRE")
    '    Dim apellidoPaciente As String = rPersona("APELLIDO")
    '    Dim correoPaciente As String = rPersona("CORREO")

    '    Dim rPaciente As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM pacientes WHERE ID_PERSONA={0}", idPaciente), "pacientes").Rows(0)
    '    Dim telefonoMovilPaciente As String = rPaciente("TELEFONOMOVIL")
    '    Dim telefonoFijoPaciente As String = rPaciente("TELEFONOFIJO")
    '    Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), rPaciente("SEXO"))
    '    Dim fechaNacimientoPaciente As Date = CType(rPaciente("FECHANACIMIENTO"), MySqlDateTime).Value
    '    Dim callePaciente As String = rPaciente("CALLE")
    '    Dim numeroPuertaPaciente As String = rPaciente("NUMEROPUERTA")
    '    Dim apartamentoPaciente As String = ""
    '    If TypeOf rPaciente("APARTAMENTO") IsNot DBNull Then
    '        apartamentoPaciente = rPaciente("APARTAMENTO")
    '    End If

    '    Dim paciente As New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, Nothing, telefonoMovilPaciente,
    '                                 telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente, callePaciente, numeroPuertaPaciente, apartamentoPaciente)

    '    Return paciente
    'End Function

    'Private Function TieneUsuario(persona As Persona) As Boolean
    '    Dim idPersona As String = persona.ID
    '    Dim cantidadUsuarios As Integer = ConexionBD.EjecutarConsulta(String.Format("SELECT COUNT(*) FROM usuarios WHERE ID_PERSONA={0} ", idPersona), "usuarios").Rows(0)(0)
    '    Return cantidadUsuarios > 0
    'End Function

    'Private Function ObtenerDiagnosticosPrimariosPorPaciente(paciente As Paciente) As List(Of DiagnosticoPrimario)
    '    Dim lista As New List(Of DiagnosticoPrimario)
    '    For Each rDiagnosticoPrimario As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM diagnosticos_primarios WHERE ID_PACIENTE={0}", paciente.ID), "diagnosticos_primarios").Rows
    '        Dim idDiagnosticoPrimario As Integer = rDiagnosticoPrimario("ID")
    '        Dim fechaHoraDiagnosticoPrimario As Date = CType(rDiagnosticoPrimario("FECHA_HORA"), MySqlDateTime).Value
    '        Dim tipoDiagnosticoPrimario As TiposDiagnosticosPrimarios = [Enum].Parse(GetType(TiposDiagnosticosPrimarios), rDiagnosticoPrimario("TIPO"))

    '        Dim enfermedadesDiagnosticoPrimario As New List(Of Enfermedad)
    '        Dim probabilidadesEnfermedades As New List(Of Decimal)
    '        For Each rSistemaDiagnostica As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM sistema_diagnostica WHERE ID_DIAGNOSTICO_PRIMARIO={0}", idDiagnosticoPrimario), "sistema_diagnostica").Rows
    '            Dim idEnfermedad As Integer = rSistemaDiagnostica("ID_ENFERMEDAD")
    '            Dim rEnfermedad As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM enfermedades WHERE ID={0}", idEnfermedad), "enfermedades").Rows(0)
    '            Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
    '            Dim recomendacionesEnfermedad As String = ""
    '            If TypeOf rEnfermedad("RECOMENDACIONES") IsNot DBNull Then
    '                recomendacionesEnfermedad = rEnfermedad("RECOMENDACIONES")
    '            End If
    '            Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
    '            Dim descripcionEnfermedad As String = ""
    '            If TypeOf rEnfermedad("DESCRIPCION") IsNot DBNull Then
    '                descripcionEnfermedad = rEnfermedad("DESCRIPCION")
    '            End If
    '            Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")
    '            Dim probabilidadEnfermedad As Decimal = rSistemaDiagnostica("PROBABILIDAD")

    '            Dim idEspecialidad As Integer = rEnfermedad("ID_ESPECIALIDAD")
    '            Dim rEspecialidad As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM especialidades WHERE ID={0}", idEspecialidad), "especialidades").Rows(0)
    '            Dim nombreEspecialidad As String = rEspecialidad("NOMBRE")
    '            Dim habilitadoEspecialidad As Boolean = rEspecialidad("HABILITADO")
    '            Dim especialidadEnfermedad As New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad)

    '            enfermedadesDiagnosticoPrimario.Add(New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad,
    '                                                                descripcionEnfermedad, Nothing, especialidadEnfermedad, habilitadoEnfermedad))
    '            probabilidadesEnfermedades.Add(rSistemaDiagnostica("PROBABILIDAD"))
    '        Next
    '        Dim enfermedadesDiagnosticadas As New EnfermedadesDiagnosticadas(enfermedadesDiagnosticoPrimario, probabilidadesEnfermedades)
    '        lista.Add(New DiagnosticoPrimario(idDiagnosticoPrimario, paciente, enfermedadesDiagnosticadas, fechaHoraDiagnosticoPrimario, tipoDiagnosticoPrimario))
    '    Next
    '    Return lista
    'End Function
#End Region
End Module
