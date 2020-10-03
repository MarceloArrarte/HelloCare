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
Imports System.Xml

Public Module AccesoDatos
    ' Dado un valor del enumerado Clases, devuelve una lista con los datos de todos los objetos de ese tipo almacenados en la BD.
    'Public Function ObtenerListadoCompleto(entidad As TiposObjeto) As List(Of Object)
    '    Dim tablasASeleccionar As New List(Of String)
    '    AnotarTablas(tablasASeleccionar, entidad)

    '    Dim datos As New DataSet
    '    For Each t As String In tablasASeleccionar
    '        datos.Tables.Add(SeleccionarTabla(t, TiposSeleccionBD.Habilitados))
    '    Next
    '    ConexionBD.AplicarClavesExternas(datos)

    '    Dim listaObjetos As New List(Of Object)
    '    PoblarLista(listaObjetos, entidad, datos)
    '    Return listaObjetos
    'End Function

    ' Agrega en la lista de String los nombres de las tablas que deben ser recorridas para completar los datos de cada clase.
    'Private Sub AnotarTablas(ByRef tablasASeleccionar As List(Of String), entidad As TiposObjeto)
    '    Select Case entidad
    '        Case TiposObjeto.DiagnosticoPrimario
    '            tablasASeleccionar.AddRange({"diagnosticos_primarios", "pacientes", "personas", "sistema_diagnostica",
    '                                        "enfermedades"})

    '        Case TiposObjeto.DiagnosticoDiferencial
    '            tablasASeleccionar.AddRange({"diagnosticos_diferenciales", "diagnosticos_primarios",
    '                                        "diagnosticos_primarios_con_consulta", "enfermedades"})

    '        Case TiposObjeto.Enfermedad
    '            tablasASeleccionar.AddRange({"enfermedades", "cuadro_sintomatico", "sintomas",
    '                                        "especialidades"})

    '        Case TiposObjeto.Especialidad
    '            tablasASeleccionar.AddRange({"especialidades", "especialidades_medicos", "medicos", "funcionarios",
    '                                        "personas", "enfermedades"})

    '        Case TiposObjeto.Departamento
    '            tablasASeleccionar.AddRange({"departamentos", "localidades"})

    '        Case TiposObjeto.Localidad
    '            tablasASeleccionar.AddRange({"localidades", "departamentos", "personas", "pacientes", "funcionarios",
    '                                        "medicos", "administrativos"})

    '        Case TiposObjeto.Sintoma
    '            tablasASeleccionar.AddRange({"sintomas", "cuadro_sintomatico", "enfermedades"})

    '        Case TiposObjeto.Usuario
    '            tablasASeleccionar.AddRange({"usuarios", "personas", "pacientes", "funcionarios", "medicos", "administrativos"})

    '        Case TiposObjeto.Mensaje
    '            tablasASeleccionar.AddRange({"mensajes", "diagnosticos_primarios", "diagnosticos_primarios_con_consulta"})

    '        Case TiposObjeto.Administrativo
    '            tablasASeleccionar.AddRange({"administrativos", "personas", "funcionarios", "localidades"})

    '        Case TiposObjeto.Paciente
    '            tablasASeleccionar.AddRange({"pacientes", "personas", "localidades", "diagnosticos_primarios"})

    '        Case TiposObjeto.Medico
    '            tablasASeleccionar.AddRange({"medicos", "personas", "funcionarios", "localidades", "especialidades_medicos",
    '                                        "especialidades", "diagnosticos_primarios_con_consulta", "diagnosticos_primarios"})

    '        Case TiposObjeto.DiagnosticoPrimarioConConsulta
    '            tablasASeleccionar.AddRange({"diagnosticos_primarios_con_consulta", "diagnosticos_primarios", "personas",
    '                                        "pacientes", "funcionarios", "medicos", "mensajes", "sistema_diagnostica",
    '                                        "enfermedades"})

    '    End Select
    'End Sub


    ' Llena una tabla con los datos de los registros de una tabla de la BD que cumplen con una condición.
    ' La condición pasada como argumento debe tener el siguiente formato: "columna""operador""valor"[, "columna2""operador2""valor"...]
    ' No incluir WHERE en este argumento
    'Private Function SeleccionarTabla(nombreTabla As String, tipoSeleccion As TiposSeleccionBD, Optional condicion As String = "") As DataTable
    '    Dim txtComando As String = String.Format("SELECT * FROM {0} ", nombreTabla)

    '    If condicion <> "" Then
    '        txtComando &= "WHERE " & condicion
    '    End If

    '    Select Case tipoSeleccion
    '        Case TiposSeleccionBD.Habilitados
    '            If {"funcionarios", "enfermedades", "sintomas", "especialidades", "usuarios"}.Contains(nombreTabla) Then
    '                If condicion <> "" Then
    '                    txtComando &= ", "
    '                Else
    '                    txtComando &= "WHERE "
    '                End If
    '                txtComando &= "HABILITADO=TRUE"
    '            End If

    '        Case TiposSeleccionBD.Deshabilitados
    '            If {"funcionarios", "enfermedades", "sintomas", "especialidades", "usuarios"}.Contains(nombreTabla) Then
    '                If condicion <> "" Then
    '                    txtComando &= ", "
    '                Else
    '                    txtComando &= "WHERE "
    '                End If
    '                txtComando &= "HABILITADO=FALSE"
    '            End If
    '    End Select

    '    Dim tabla As DataTable = ConexionBD.EjecutarConsulta(New MySqlCommand(txtComando), nombreTabla)
    '    Return tabla.Copy
    'End Function

    ' Llena una lista con el tipo de objeto especificado, extraído del DataSet con los datos de la consulta a la BD.
    'Private Sub PoblarLista(ByRef lista As List(Of Object), entidad As TiposObjeto, datos As DataSet)
    '    Select Case entidad
    '        Case TiposObjeto.DiagnosticoPrimario
    '            For Each rDiagnosticoPrimario As DataRow In datos.Tables("diagnosticos_primarios").Rows
    '                Dim idDiagnosticoPrimario As Integer = rDiagnosticoPrimario("ID")
    '                Dim fechaHoraDiagnosticoPrimario As Date = CType(rDiagnosticoPrimario("FECHA_HORA"), MySqlDateTime).Value
    '                Dim tipoDiagnosticoPrimario As TiposDiagnosticosPrimarios = [Enum].Parse(GetType(TiposDiagnosticosPrimarios), rDiagnosticoPrimario("TIPO"))

    '                Dim rPaciente As DataRow = rDiagnosticoPrimario.GetParentRow("diagnosticos_primarios_ibfk_1")
    '                Dim rPersona As DataRow = rPaciente.GetParentRow("pacientes_ibfk_1")

    '                Dim idPaciente As Integer = rPersona("ID")
    '                Dim ciPaciente As String = rPersona("CI")
    '                Dim nombrePaciente As String = rPersona("NOMBRE")
    '                Dim apellidoPaciente As String = rPersona("APELLIDO")
    '                Dim correoPaciente As String = rPersona("CORREO")
    '                Dim telefonoMovilPaciente As String = rPaciente("TELEFONOMOVIL")
    '                Dim telefonoFijoPaciente As String = rPaciente("TELEFONOFIJO")
    '                Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), rPaciente("SEXO"))
    '                Dim fechaNacimientoPaciente As Date = CType(rPaciente("FECHANACIMIENTO"), MySqlDateTime).Value
    '                Dim callePaciente As String = rPaciente("CALLE")
    '                Dim numeroPuertaPaciente As String = rPaciente("NUMEROPUERTA")
    '                Dim apartamentoPaciente As String = ""
    '                If TypeOf rPaciente("APARTAMENTO") IsNot DBNull Then
    '                    apartamentoPaciente = rPaciente("APARTAMENTO")
    '                End If

    '                Dim pacienteDiagnosticoPrimario As New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, Nothing,
    '                                                                telefonoMovilPaciente, telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente,
    '                                                                callePaciente, numeroPuertaPaciente, apartamentoPaciente)

    '                Dim sintomasDiagnosticoPrimario As New List(Of Sintoma)
    '                For Each rSistemaEvalua As DataRow In rDiagnosticoPrimario.GetChildRows("sistema_evalua_ibfk_1")
    '                    Dim rSintoma As DataRow = rSistemaEvalua.GetParentRow("sistema_evalua_ibfk_2")
    '                    Dim idSintoma As Integer = rSintoma("ID")
    '                    Dim nombreSintoma As String = rSintoma("NOMBRE")
    '                    Dim descripcionSintoma As String = rSintoma("DESCRIPCION")
    '                    Dim recomendacionesSintoma As String = rSintoma("RECOMENDACIONES")
    '                    Dim urgenciaSintoma As String = rSintoma("URGENCIA")
    '                    Dim habilitadoSintoma As Boolean = rSintoma("HABILITADO")

    '                    sintomasDiagnosticoPrimario.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma, Nothing, habilitadoSintoma))
    '                Next

    '                Dim enfermedadesDiagnosticoPrimario As New List(Of Enfermedad)
    '                Dim probabilidadesEnfermedadesDiagnosticoPrimario As New List(Of Decimal)
    '                For Each rSistemaDiagnostica As DataRow In rDiagnosticoPrimario.GetChildRows("sistema_diagnostica_ibfk_1")
    '                    Dim rEnfermedad As DataRow = rSistemaDiagnostica.GetParentRow("sistema_diagnostica_ibfk_2")

    '                    Dim idEnfermedad As Integer = rEnfermedad("ID")
    '                    Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
    '                    Dim recomendacionesEnfermedad As String = rEnfermedad("RECOMENDACIONES")
    '                    Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
    '                    Dim descripcionEnfermedad As String = rEnfermedad("DESCRIPCION")
    '                    Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")
    '                    Dim probabilidadEnfermedad As String = rSistemaDiagnostica("PROBABILIDAD")

    '                    enfermedadesDiagnosticoPrimario.Add(
    '                        New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad, descripcionEnfermedad,
    '                                       Nothing, Nothing, habilitadoEnfermedad))
    '                    probabilidadesEnfermedadesDiagnosticoPrimario.Add(probabilidadEnfermedad)
    '                Next
    '                Dim enfermedadesDiagnosticadasDiagnosticoPrimario As _
    '                    New EnfermedadesDiagnosticadas(enfermedadesDiagnosticoPrimario, probabilidadesEnfermedadesDiagnosticoPrimario)

    '                lista.Add(New DiagnosticoPrimario(idDiagnosticoPrimario, pacienteDiagnosticoPrimario, sintomasDiagnosticoPrimario,
    '                                                  enfermedadesDiagnosticadasDiagnosticoPrimario, fechaHoraDiagnosticoPrimario, tipoDiagnosticoPrimario))
    '            Next

    '        Case TiposObjeto.DiagnosticoDiferencial
    '            For Each rDiagnosticoDiferencial As DataRow In datos.Tables("diagnosticos_diferenciales").Rows
    '                Dim idDiagnosticoDiferencial As Integer = rDiagnosticoDiferencial("ID")
    '                Dim conductaASeguirDiagnosticoDiferencial As String = rDiagnosticoDiferencial("CONDUCTA_A_SEGUIR")
    '                Dim fechaHoraDiagnosticoDiferencial As Date = CType(rDiagnosticoDiferencial("FECHAHORA"), MySqlDateTime).Value

    '                Dim rEnfermedad As DataRow = rDiagnosticoDiferencial.GetParentRow("diagnosticos_diferenciales_ibfk_2")

    '                Dim idEnfermedad As Integer = rEnfermedad("ID")
    '                Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
    '                Dim descripcionEnfermedad As String = rEnfermedad("DESCRIPCION")
    '                Dim recomendacionesEnfermedad As String = rEnfermedad("RECOMENDACIONES")
    '                Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
    '                Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")

    '                Dim enfermedadDiagnosticoDiferencial As Enfermedad = New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad,
    '                                                                                    gravedadEnfermedad, descripcionEnfermedad, Nothing, Nothing,
    '                                                                                    habilitadoEnfermedad)

    '                Dim rDiagnosticoPrimarioConConsulta As DataRow = rDiagnosticoDiferencial.GetParentRow("diagnosticos_diferenciales_ibfk_3")
    '                Dim rDiagnosticoPrimario As DataRow = rDiagnosticoPrimarioConConsulta.GetParentRow("diagnosticos_primarios_con_consulta_ibfk_1")

    '                Dim idDiagnosticoPrimarioConConsulta As Integer = rDiagnosticoPrimario("ID")
    '                Dim fechaHoraDiagnosticoPrimarioConConsulta As Date = CType(rDiagnosticoPrimario("FECHA_HORA"), MySqlDateTime).Value
    '                Dim comentariosAdicionalesDiagnosticoPrimarioConConsulta As String = rDiagnosticoPrimarioConConsulta("COMENTARIOS_ADICIONALES")

    '                Dim diagnosticoPrimarioConConsultaDiagnosticoDiferencial As _
    '                    New DiagnosticoPrimarioConConsulta(idDiagnosticoPrimarioConConsulta, Nothing, Nothing, Nothing, fechaHoraDiagnosticoPrimarioConConsulta,
    '                                                       Nothing, comentariosAdicionalesDiagnosticoPrimarioConConsulta)

    '                lista.Add(New DiagnosticoDiferencial(idDiagnosticoDiferencial, diagnosticoPrimarioConConsultaDiagnosticoDiferencial,
    '                                                     enfermedadDiagnosticoDiferencial, conductaASeguirDiagnosticoDiferencial, fechaHoraDiagnosticoDiferencial))
    '            Next

    '        Case TiposObjeto.Enfermedad
    '            For Each rEnfermedad As DataRow In datos.Tables("enfermedades").Rows
    '                Dim idEnfermedad As Integer = rEnfermedad("ID")
    '                Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
    '                Dim recomendacionesEnfermedad As String = ""
    '                If TypeOf rEnfermedad("RECOMENDACIONES") IsNot DBNull Then
    '                    recomendacionesEnfermedad = rEnfermedad("RECOMENDACIONES")
    '                End If
    '                Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
    '                Dim descripcionEnfermedad As String = ""
    '                If TypeOf rEnfermedad("DESCRIPCION") IsNot DBNull Then
    '                    descripcionEnfermedad = rEnfermedad("DESCRIPCION")
    '                End If
    '                Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")

    '                Dim rEspecialidad As DataRow = rEnfermedad.GetParentRow("enfermedades_ibfk_1")

    '                Dim idEspecialidad As Integer = rEspecialidad("ID")
    '                Dim nombreEspecialidad As String = rEspecialidad("NOMBRE")
    '                Dim habilitadoEspecialidad As Boolean = rEspecialidad("HABILITADO")

    '                Dim especialidadEnfermedad As New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad)

    '                Dim sintomasEnfermedad As New List(Of Sintoma)
    '                Dim frecuenciasSintomasEnfermedad As New List(Of Decimal)
    '                For Each rCuadroSintomatico As DataRow In rEnfermedad.GetChildRows("cuadro_sintomatico_ibfk_2")
    '                    Dim rSintoma As DataRow = rCuadroSintomatico.GetParentRow("cuadro_sintomatico_ibfk_1")

    '                    Dim idSintoma As Integer = rSintoma("ID")
    '                    Dim nombreSintoma As String = rSintoma("NOMBRE")
    '                    Dim descripcionSintoma As String = rSintoma("DESCRIPCION")
    '                    Dim recomendacionesSintoma As String = rSintoma("RECOMENDACIONES")
    '                    Dim urgenciaSintoma As Integer = rSintoma("URGENCIA")
    '                    Dim habilitadoSintoma As Boolean = rSintoma("HABILITADO")
    '                    Dim frecuenciaSintoma As Decimal = rCuadroSintomatico("FRECUENCIA")

    '                    sintomasEnfermedad.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma,
    '                                                       Nothing, habilitadoSintoma))
    '                    frecuenciasSintomasEnfermedad.Add(frecuenciaSintoma)
    '                Next
    '                Dim sintomasAsociadosEnferemedad As New SintomasAsociados(sintomasEnfermedad, frecuenciasSintomasEnfermedad)

    '                lista.Add(New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad, descripcionEnfermedad,
    '                                         sintomasAsociadosEnferemedad, especialidadEnfermedad, habilitadoEnfermedad))
    '            Next

    '        Case TiposObjeto.Especialidad
    '            For Each rEspecialidad As DataRow In datos.Tables("especialidades").Rows
    '                Dim idEspecialidad As Integer = rEspecialidad("ID")
    '                Dim nombreEspecialidad As String = rEspecialidad("NOMBRE")
    '                Dim habilitadoEspecialidad As Boolean = rEspecialidad("HABILITADO")

    '                Dim listaMedicosEspecialidad As New List(Of Medico)
    '                For Each rEspecialidadesMedicos As DataRow In rEspecialidad.GetChildRows("especialidades_medicos_ibfk_1")
    '                    Dim rMedico As DataRow = rEspecialidadesMedicos.GetParentRow("especialidades_medicos_ibfk_2")
    '                    Dim rFuncionario As DataRow = rMedico.GetParentRow("medicos_ibfk_1")
    '                    Dim rPersona As DataRow = rFuncionario.GetParentRow("funcionarios_ibfk_1")

    '                    Dim idMedico As Integer = rPersona("ID")
    '                    Dim ciMedico As String = rPersona("CI")
    '                    Dim nombreMedico As String = rPersona("NOMBRE")
    '                    Dim apellidoMedico As String = rPersona("APELLIDO")
    '                    Dim correoMedico As String = rPersona("CORREO")
    '                    Dim habilitadoMedico As Boolean = rFuncionario("HABILITADO")

    '                    listaMedicosEspecialidad.Add(New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, Nothing, Nothing,
    '                                                            habilitadoMedico))
    '                Next

    '                lista.Add(New Especialidad(idEspecialidad, nombreEspecialidad, listaMedicosEspecialidad, habilitadoEspecialidad))
    '            Next

    '        Case TiposObjeto.Departamento
    '            For Each rDepartamento As DataRow In datos.Tables("departamentos").Rows
    '                Dim idDepartamento As Integer = rDepartamento("ID")
    '                Dim nombreDepartamento As String = rDepartamento("NOMBRE")
    '                lista.Add(New Departamento(idDepartamento, nombreDepartamento))
    '            Next

    '        Case TiposObjeto.Localidad
    '            For Each rLocalidad As DataRow In datos.Tables("localidades").Rows
    '                Dim idLocalidad As Integer = rLocalidad("ID")
    '                Dim nombreLocalidad As String = rLocalidad("NOMBRE")

    '                Dim rDepartamento As DataRow = rLocalidad.GetParentRow("localidades_ibfk_1")
    '                Dim idDepartamento As Integer = rDepartamento("ID")
    '                Dim nombreDepartamento As String = rDepartamento("NOMBRE")

    '                Dim departamentoLocalidad As New Departamento(idDepartamento, nombreDepartamento)
    '                lista.Add(New Localidad(idLocalidad, nombreLocalidad, departamentoLocalidad))
    '            Next

    '        Case TiposObjeto.Sintoma
    '            For Each rSintoma As DataRow In datos.Tables("sintomas").Rows
    '                Dim idSintoma As Integer = rSintoma("ID")
    '                Dim nombreSintoma As String = rSintoma("NOMBRE")
    '                Dim descripcionSintoma As String = ""
    '                If TypeOf rSintoma("DESCRIPCION") IsNot DBNull Then
    '                    descripcionSintoma = rSintoma("DESCRIPCION")
    '                End If
    '                Dim recomendacionesSintoma As String = ""
    '                If TypeOf rSintoma("RECOMENDACIONES") IsNot DBNull Then
    '                    recomendacionesSintoma = rSintoma("RECOMENDACIONES")
    '                End If
    '                Dim urgenciaSintoma As String = rSintoma("URGENCIA")
    '                Dim habilitadoSintoma As Boolean = rSintoma("HABILITADO")

    '                Dim enfermedadesSintoma As New List(Of Enfermedad)
    '                Dim frecuenciasEnfermedadesSintomas As New List(Of Decimal)
    '                For Each rCuadroSintomatico As DataRow In rSintoma.GetChildRows("cuadro_sintomatico_ibfk_1")
    '                    Dim rEnfermedad As DataRow = rCuadroSintomatico.GetParentRow("cuadro_sintomatico_ibfk_2")

    '                    Dim idEnfermedad As Integer = rEnfermedad("ID")
    '                    Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
    '                    Dim recomendacionesEnfermedad As String = ""
    '                    If TypeOf rEnfermedad("RECOMENDACIONES") IsNot DBNull Then
    '                        recomendacionesEnfermedad = rEnfermedad("RECOMENDACIONES")
    '                    End If
    '                    Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
    '                    Dim descripcionEnfermedad As String = ""
    '                    If TypeOf rEnfermedad("DESCRIPCION") IsNot DBNull Then
    '                        descripcionEnfermedad = rEnfermedad("DESCRIPCION")
    '                    End If
    '                    Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")
    '                    Dim frecuenciaEnfermedad As Decimal = rCuadroSintomatico("FRECUENCIA")

    '                    enfermedadesSintoma.Add(New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad,
    '                                                                descripcionEnfermedad, Nothing, Nothing, habilitadoEnfermedad))
    '                    frecuenciasEnfermedadesSintomas.Add(frecuenciaEnfermedad)
    '                Next
    '                Dim enfermedadesAsociadasSintoma As New EnfermedadesAsociadas(enfermedadesSintoma, frecuenciasEnfermedadesSintomas)

    '                lista.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma,
    '                                      enfermedadesAsociadasSintoma, habilitadoSintoma))
    '            Next

    '        Case TiposObjeto.Usuario
    '            For Each rUsuario As DataRow In datos.Tables("usuarios").Rows
    '                Dim idUsuario As Integer = rUsuario("ID")
    '                Dim contrasenaUsuario As String = rUsuario("CONTRASENIA")
    '                Dim tipoUsuario As TiposUsuario = [Enum].Parse(GetType(TiposUsuario), rUsuario("TIPO"))
    '                Dim habilitadoUsuario As Boolean = rUsuario("HABILITADO")

    '                Dim personaUsuario As Persona = Nothing
    '                Dim rPersona As DataRow = rUsuario.GetParentRow("usuarios_ibfk_1")
    '                Select Case tipoUsuario
    '                    Case TiposUsuario.Paciente
    '                        Dim rPaciente As DataRow = rPersona.GetChildRows("pacientes_ibfk_1").Single

    '                        Dim idPaciente As Integer = rPersona("ID")
    '                        Dim ciPaciente As String = rPersona("CI")
    '                        Dim nombrePaciente As String = rPersona("NOMBRE")
    '                        Dim apellidoPaciente As String = rPersona("APELLIDO")
    '                        Dim correoPaciente As String = rPersona("CORREO")
    '                        Dim telefonoMovilPaciente As String = rPaciente("TELEFONOMOVIL")
    '                        Dim telefonoFijoPaciente As String = rPaciente("TELEFONOFIJO")
    '                        Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), rPaciente("SEXO"))
    '                        Dim fechaNacimientoPaciente As Date = CType(rPaciente("FECHANACIMIENTO"), MySqlDateTime).Value
    '                        Dim callePaciente As String = rPaciente("CALLE")
    '                        Dim numeroPuertaPaciente As String = rPaciente("NUMEROPUERTA")
    '                        Dim apartamentoPaciente As String = ""
    '                        If TypeOf rPaciente("APARTAMENTO") IsNot DBNull Then
    '                            apartamentoPaciente = rPaciente("APARTAMENTO")
    '                        End If

    '                        personaUsuario = New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, Nothing,
    '                                                      telefonoMovilPaciente, telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente,
    '                                                      callePaciente, numeroPuertaPaciente, apartamentoPaciente)

    '                    Case Else
    '                        Dim rFuncionario As DataRow = rPersona.GetChildRows("funcionarios_ibfk_1").Single
    '                        Select Case [Enum].Parse(GetType(TiposFuncionario), rFuncionario("TIPO"))
    '                            Case TiposFuncionario.Administrativo
    '                                Dim rAdministrativo As DataRow = rFuncionario.GetChildRows("administrativos_ibfk_1").Single

    '                                Dim idAdministrativo As Integer = rPersona("ID")
    '                                Dim ciAdministrativo As String = rPersona("CI")
    '                                Dim nombreAdministrativo As String = rPersona("NOMBRE")
    '                                Dim apellidoAdministrativo As String = rPersona("APELLIDO")
    '                                Dim correoAdministrativo As String = rPersona("CORREO")
    '                                Dim esEncargadoAdministrativo As Boolean = rAdministrativo("ES_ENCARGADO")
    '                                Dim habilitadoAdministrativo As Boolean = rFuncionario("HABILITADO")

    '                                personaUsuario = New Administrativo(idAdministrativo, ciAdministrativo, nombreAdministrativo, apellidoAdministrativo,
    '                                                                    correoAdministrativo, Nothing, esEncargadoAdministrativo, habilitadoAdministrativo)

    '                            Case TiposFuncionario.Medico
    '                                Dim idMedico As Integer = rPersona("ID")
    '                                Dim ciMedico As String = rPersona("CI")
    '                                Dim nombreMedico As String = rPersona("NOMBRE")
    '                                Dim apellidoMedico As String = rPersona("APELLIDO")
    '                                Dim correoMedico As String = rPersona("CORREO")
    '                                Dim habilitadoMedico As Boolean = rFuncionario("HABILITADO")

    '                                personaUsuario = New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, Nothing, Nothing,
    '                                                            habilitadoMedico)
    '                        End Select
    '                End Select

    '                lista.Add(New Usuario(idUsuario, contrasenaUsuario, personaUsuario, habilitadoUsuario))
    '            Next

    '        Case TiposObjeto.Mensaje
    '            For Each rMensaje As DataRow In datos.Tables("mensajes").Rows
    '                Dim idMensaje As Integer = rMensaje("ID")
    '                Dim fechaHoraMensaje As Date = CType(rMensaje("FECHAHORA"), MySqlDateTime).Value
    '                Dim formatoMensaje As FormatosMensajeAdmitidos = [Enum].Parse(GetType(FormatosMensajeAdmitidos), rMensaje("FORMATO"))
    '                Dim contenidoMensaje() As Byte = rMensaje("CONTENIDO")
    '                Dim remitenteMensaje As TiposRemitente = [Enum].Parse(GetType(TiposRemitente), rMensaje("REMITENTE"))

    '                Dim rDiagnosticoPrimarioConConsulta As DataRow = rMensaje.GetParentRow("mensajes_ibfk_1")
    '                Dim rDiagnosticoPrimario As DataRow = rDiagnosticoPrimarioConConsulta.GetParentRow("diagnosticos_primarios_con_consulta_ibfk_1")

    '                Dim idDiagnosticoPrimarioConConsulta As Integer = rDiagnosticoPrimario("ID")
    '                Dim fechaHoraDiagnosticoPrimarioConConsulta As Date = CType(rDiagnosticoPrimario("FECHA_HORA"), MySqlDateTime).Value
    '                Dim comentariosAdicionalesDiagnosticoPrimarioConConsulta As String = rDiagnosticoPrimarioConConsulta("COMENTARIOS_ADICIONALES")

    '                Dim diagnosticoPrimarioConConsultaMensaje As _
    '                    New DiagnosticoPrimarioConConsulta(idDiagnosticoPrimarioConConsulta, Nothing, Nothing, Nothing, fechaHoraDiagnosticoPrimarioConConsulta,
    '                                                       Nothing, comentariosAdicionalesDiagnosticoPrimarioConConsulta)

    '                lista.Add(New Mensaje(idMensaje, fechaHoraMensaje, formatoMensaje, contenidoMensaje, remitenteMensaje,
    '                                      diagnosticoPrimarioConConsultaMensaje))
    '            Next

    '        Case TiposObjeto.Administrativo
    '            For Each rAdministrativo As DataRow In datos.Tables("administrativos").Rows
    '                Dim rFuncionario As DataRow = rAdministrativo.GetParentRow("administrativos_ibfk_1")
    '                Dim rPersona As DataRow = rFuncionario.GetParentRow("funcionarios_ibfk_1")

    '                Dim idAdministrativo As Integer = rPersona("ID")
    '                Dim ciAdministrativo As String = rPersona("CI")
    '                Dim nombreAdministrativo As String = rPersona("NOMBRE")
    '                Dim apellidoAdministrativo As String = rPersona("APELLIDO")
    '                Dim correoAdministrativo As String = rPersona("CORREO")
    '                Dim esEncargadoAdministrativo As Boolean = rAdministrativo("ES_ENCARGADO")
    '                Dim habilitadoAdministrativo As Boolean = rFuncionario("HABILITADO")

    '                Dim rLocalidad As DataRow = rPersona.GetParentRow("personas_ibfk_1")
    '                Dim idLocalidad As Integer = rLocalidad("ID")
    '                Dim nombreLocalidad As String = rLocalidad("NOMBRE")

    '                Dim localidadAdministrativo As New Localidad(idLocalidad, nombreLocalidad, Nothing)

    '                lista.Add(New Administrativo(idAdministrativo, ciAdministrativo, nombreAdministrativo, apellidoAdministrativo,
    '                                             correoAdministrativo, localidadAdministrativo, esEncargadoAdministrativo, habilitadoAdministrativo))
    '            Next

    '        Case TiposObjeto.Paciente
    '            For Each rPaciente As DataRow In datos.Tables("pacientes").Rows
    '                Dim rPersona As DataRow = rPaciente.GetParentRow("pacientes_ibfk_1")

    '                Dim idPaciente As Integer = rPersona("ID")
    '                Dim ciPaciente As String = rPersona("CI")
    '                Dim nombrePaciente As String = rPersona("NOMBRE")
    '                Dim apellidoPaciente As String = rPersona("APELLIDO")
    '                Dim correoPaciente As String = rPersona("CORREO")
    '                Dim telefonoMovilPaciente As String = rPaciente("TELEFONOMOVIL")
    '                Dim telefonoFijoPaciente As String = rPaciente("TELEFONOFIJO")
    '                Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), rPaciente("SEXO"))
    '                Dim fechaNacimientoPaciente As Date = CType(rPaciente("FECHANACIMIENTO"), MySqlDateTime).Value
    '                Dim callePaciente As String = rPaciente("CALLE")
    '                Dim numeroPuertaPaciente As String = rPaciente("NUMEROPUERTA")
    '                Dim apartamentoPaciente As String = ""
    '                If TypeOf rPaciente("APARTAMENTO") IsNot DBNull Then
    '                    apartamentoPaciente = rPaciente("APARTAMENTO")
    '                End If

    '                Dim rLocalidad As DataRow = rPersona.GetParentRow("personas_ibfk_1")
    '                Dim idLocalidad As Integer = rLocalidad("ID")
    '                Dim nombreLocalidad As String = rLocalidad("NOMBRE")

    '                Dim localidadPaciente As New Localidad(idLocalidad, nombreLocalidad, Nothing)

    '                lista.Add(New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, localidadPaciente,
    '                                       telefonoMovilPaciente, telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente,
    '                                       callePaciente, numeroPuertaPaciente, apartamentoPaciente))
    '            Next

    '        Case TiposObjeto.Medico
    '            For Each rMedico As DataRow In datos.Tables("medicos").Rows
    '                Dim rFuncionario As DataRow = rMedico.GetParentRow("medicos_ibfk_1")
    '                Dim rPersona As DataRow = rFuncionario.GetParentRow("funcionarios_ibfk_1")

    '                Dim idMedico As Integer = rPersona("ID")
    '                Dim ciMedico As String = rPersona("CI")
    '                Dim nombreMedico As String = rPersona("NOMBRE")
    '                Dim apellidoMedico As String = rPersona("APELLIDO")
    '                Dim correoMedico As String = rPersona("CORREO")
    '                Dim habilitadoMedico As Boolean = rFuncionario("HABILITADO")

    '                Dim rLocalidad As DataRow = rPersona.GetParentRow("personas_ibfk_1")
    '                Dim idLocalidad As Integer = rLocalidad("ID")
    '                Dim nombreLocalidad As String = rLocalidad("NOMBRE")

    '                Dim localidadMedico As New Localidad(idLocalidad, nombreLocalidad, Nothing)

    '                Dim listaEspecialidadesMedico As New List(Of Especialidad)
    '                For Each rEspecialidadesMedico As DataRow In rMedico.GetChildRows("especialidades_medicos_ibfk_2")
    '                    Dim rEspecialidad As DataRow = rEspecialidadesMedico.GetParentRow("especialidades_medicos_ibfk_1")

    '                    Dim idEspecialidad As Integer = rEspecialidad("ID")
    '                    Dim nombreEspecialidad As String = rEspecialidad("NOMBRE")
    '                    Dim habilitadoEspecialidad As Boolean = rEspecialidad("HABILITADO")

    '                    listaEspecialidadesMedico.Add(New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad))
    '                Next

    '                lista.Add(New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, localidadMedico, listaEspecialidadesMedico,
    '                                     habilitadoMedico))
    '            Next

    '        Case TiposObjeto.DiagnosticoPrimarioConConsulta
    '            For Each rDiagnosticoPrimarioConConsulta As DataRow In datos.Tables("diagnosticos_primarios_con_consulta").Rows
    '                Dim rDiagnosticoPrimario As DataRow = rDiagnosticoPrimarioConConsulta.GetParentRow("diagnosticos_primarios_con_consulta_ibfk_1")

    '                Dim idDiagnosticoPrimarioConConsulta As Integer = rDiagnosticoPrimario("ID")
    '                Dim fechaHoraDiagnosticoPrimarioConConsulta As Date = CType(rDiagnosticoPrimario("FECHA_HORA"), MySqlDateTime).Value
    '                Dim comentariosAdicionalesDiagnosticosPrimariosConConsulta As String = rDiagnosticoPrimarioConConsulta("COMENTARIOS_ADICIONALES")

    '                Dim rPaciente As DataRow = rDiagnosticoPrimario.GetParentRow("diagnosticos_primarios_ibfk_1")
    '                Dim rPersonaPaciente As DataRow = rPaciente.GetParentRow("pacientes_ibfk_1")

    '                Dim idPaciente As Integer = rPersonaPaciente("ID")
    '                Dim ciPaciente As String = rPersonaPaciente("CI")
    '                Dim nombrePaciente As String = rPersonaPaciente("NOMBRE")
    '                Dim apellidoPaciente As String = rPersonaPaciente("APELLIDO")
    '                Dim correoPaciente As String = rPersonaPaciente("CORREO")
    '                Dim telefonoMovilPaciente As String = rPaciente("TELEFONOMOVIL")
    '                Dim telefonoFijoPaciente As String = rPaciente("TELEFONOFIJO")
    '                Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), rPaciente("SEXO"))
    '                Dim fechaNacimientoPaciente As Date = CType(rPaciente("FECHANACIMIENTO"), MySqlDateTime).Value
    '                Dim callePaciente As String = rPaciente("CALLE")
    '                Dim numeroPuertaPaciente As String = rPaciente("NUMEROPUERTA")
    '                Dim apartamentoPaciente As String = ""
    '                If TypeOf rPaciente("APARTAMENTO") IsNot DBNull Then
    '                    apartamentoPaciente = rPaciente("APARTAMENTO")
    '                End If

    '                Dim pacienteDiagnosticoPrimarioConConsulta As _
    '                    New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, Nothing,
    '                                 telefonoMovilPaciente, telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente,
    '                                 callePaciente, numeroPuertaPaciente, apartamentoPaciente)

    '                Dim medicoDiagnosticoPrimarioConConsulta As Medico = Nothing
    '                If TypeOf rDiagnosticoPrimarioConConsulta("ID_MEDICO") IsNot DBNull Then
    '                    Dim rMedico As DataRow = rDiagnosticoPrimarioConConsulta.GetParentRow("diagnosticos_primarios_con_consulta_ibfk_2")
    '                    Dim rFuncionario As DataRow = rMedico.GetParentRow("medicos_ibfk_1")
    '                    Dim rPersonaMedico As DataRow = rFuncionario.GetParentRow("funcionarios_ibfk_1")

    '                    Dim idMedico As Integer = rPersonaMedico("ID")
    '                    Dim ciMedico As String = rPersonaMedico("CI")
    '                    Dim nombreMedico As String = rPersonaMedico("NOMBRE")
    '                    Dim apellidoMedico As String = rPersonaMedico("APELLIDO")
    '                    Dim correoMedico As String = rPersonaMedico("CORREO")
    '                    Dim habilitadoMedico As Boolean = rFuncionario("HABILITADO")

    '                    medicoDiagnosticoPrimarioConConsulta = New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, Nothing,
    '                                                                      Nothing, habilitadoMedico)
    '                End If

    '                Dim sintomasDiagnosticoPrimario As New List(Of Sintoma)
    '                For Each rSistemaEvalua As DataRow In rDiagnosticoPrimario.GetChildRows("sistema_evalua_ibfk_1")
    '                    Dim rSintoma As DataRow = rSistemaEvalua.GetParentRow("sistema_evalua_ibfk_2")
    '                    Dim idSintoma As Integer = rSintoma("ID")
    '                    Dim nombreSintoma As String = rSintoma("NOMBRE")
    '                    Dim descripcionSintoma As String = rSintoma("DESCRIPCION")
    '                    Dim recomendacionesSintoma As String = rSintoma("RECOMENDACIONES")
    '                    Dim urgenciaSintoma As String = rSintoma("URGENCIA")
    '                    Dim habilitadoSintoma As Boolean = rSintoma("HABILITADO")

    '                    sintomasDiagnosticoPrimario.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma, Nothing, habilitadoSintoma))
    '                Next

    '                Dim enfermedadesDiagnosticoPrimarioConConsulta As New List(Of Enfermedad)
    '                Dim probabilidadesEnfermedadesDiagnosticoPrimarioConConsulta As New List(Of Decimal)
    '                For Each rSistemaDiagnostica As DataRow In rDiagnosticoPrimario.GetChildRows("sistema_diagnostica_ibfk_1")
    '                    Dim rEnfermedad As DataRow = rSistemaDiagnostica.GetParentRow("sistema_diagnostica_ibfk_2")

    '                    Dim idEnfermedad As Integer = rEnfermedad("ID")
    '                    Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
    '                    Dim recomendacionesEnfermedad As String = rEnfermedad("RECOMENDACIONES")
    '                    Dim gravedadEnfermedad As Integer = rEnfermedad("GRAVEDAD")
    '                    Dim descripcionEnfermedad As String = rEnfermedad("DESCRIPCION")
    '                    Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")
    '                    Dim probabilidadEnfermedad As Decimal = rSistemaDiagnostica("PROBABILIDAD")

    '                    enfermedadesDiagnosticoPrimarioConConsulta.Add(
    '                        New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad,
    '                                       descripcionEnfermedad, Nothing, Nothing, habilitadoEnfermedad))
    '                    probabilidadesEnfermedadesDiagnosticoPrimarioConConsulta.Add(probabilidadEnfermedad)
    '                Next
    '                Dim enfermedadesDiagnosticadasDiagnosticoPrimarioConConsulta As _
    '                    New EnfermedadesDiagnosticadas(enfermedadesDiagnosticoPrimarioConConsulta, probabilidadesEnfermedadesDiagnosticoPrimarioConConsulta)

    '                If medicoDiagnosticoPrimarioConConsulta IsNot Nothing Then
    '                    lista.Add(New DiagnosticoPrimarioConConsulta(
    '                              idDiagnosticoPrimarioConConsulta, pacienteDiagnosticoPrimarioConConsulta, sintomasDiagnosticoPrimario,
    '                              enfermedadesDiagnosticadasDiagnosticoPrimarioConConsulta, fechaHoraDiagnosticoPrimarioConConsulta,
    '                              medicoDiagnosticoPrimarioConConsulta, comentariosAdicionalesDiagnosticosPrimariosConConsulta))
    '                Else
    '                    lista.Add(New DiagnosticoPrimarioConConsulta(
    '                              idDiagnosticoPrimarioConConsulta, pacienteDiagnosticoPrimarioConConsulta, sintomasDiagnosticoPrimario,
    '                              enfermedadesDiagnosticadasDiagnosticoPrimarioConConsulta, fechaHoraDiagnosticoPrimarioConConsulta,
    '                              Nothing, comentariosAdicionalesDiagnosticosPrimariosConConsulta))
    '                End If

    '            Next
    '    End Select
    'End Sub

    ' Inserta un objeto en las tablas correspondientes de acuerdo al parámetro "entidad" mediante sentencias SQL.
    ' Para el caso de los objetos que utilizan borrado lógico, se verifica previo a las sentencias INSERT si el registro a insertar
    ' ya existe y se encuentra deshabilitado, en cuyo caso es habilitado.
    ' Cuando la operación requiere más de un comando, dichos comandos se encuentran encapsulados por BEGIN, COMMIT y ROLLBACK en un bloque Try/Catch.
    Public Sub InsertarObjeto(objetoAInsertar As Object, entidad As TiposObjeto, Optional ByRef idAsignado As Integer = -1)
        Dim comando As New MySqlCommand("")

        Select Case entidad
            Case TiposObjeto.DiagnosticoPrimario
                Dim diagnosticoPrimario As DiagnosticoPrimario = objetoAInsertar
                comando.CommandText &= "INSERT INTO diagnosticos_primarios (ID_PACIENTE, FECHA_HORA, TIPO) VALUES (@ID_PACIENTE, @FECHA_HORA, @TIPO);"
                comando.Parameters.AddWithValue("@ID_PACIENTE", diagnosticoPrimario.Paciente.ID)
                comando.Parameters.AddWithValue("@FECHA_HORA", diagnosticoPrimario.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"))
                comando.Parameters.AddWithValue("@TIPO", diagnosticoPrimario.Tipo.ToString)
                ConexionBD.EjecutarTransaccion(comando)

                Dim idDiagnosticoPrimarioBD As Integer = ConexionBD.ObtenerUltimoIdInsertado
                idAsignado = idDiagnosticoPrimarioBD
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


            Case TiposObjeto.DiagnosticoDiferencial
                Dim diagnosticoDiferencial As DiagnosticoDiferencial = objetoAInsertar
                comando.CommandText &= "INSERT INTO diagnosticos_diferenciales (ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA, ID_ENFERMEDAD, CONDUCTA_A_SEGUIR, FECHAHORA) VALUES (@ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA, @ID_ENFERMEDAD, @CONDUCTA_A_SEGUIR, @FECHAHORA);"
                comando.Parameters.AddWithValue("@ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA", diagnosticoDiferencial.DiagnosticoPrimarioConConsulta.ID)
                comando.Parameters.AddWithValue("@ID_ENFERMEDAD", diagnosticoDiferencial.EnfermedadDiagnosticada.Id)
                comando.Parameters.AddWithValue("@CONDUCTA_A_SEGUIR", diagnosticoDiferencial.ConductaASeguir)
                comando.Parameters.AddWithValue("@FECHAHORA", diagnosticoDiferencial.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"))


            Case TiposObjeto.Enfermedad
                Dim enfermedad As Enfermedad = objetoAInsertar

                Dim estaDeshabilitado As Boolean = False
                For Each r As DataRow In ConexionBD.EjecutarConsulta(New MySqlCommand("SELECT * FROM enfermedades WHERE HABILITADO=FALSE;")).Rows
                    If r("NOMBRE") = enfermedad.Nombre Then
                        estaDeshabilitado = True
                        Exit For
                    End If
                Next

                If estaDeshabilitado Then       ' Existe, y se deshabilitó
                    comando.CommandText &= "UPDATE enfermedades SET HABILITADO=TRUE, DESCRIPCION=@DESCRIPCION, RECOMENDACIONES=@RECOMENDACIONES, GRAVEDAD=@GRAVEDAD, ID_ESPECIALIDAD=@ID_ESPECIALIDAD WHERE NOMBRE=@NOMBRE"
                    comando.Parameters.AddWithValue("@DESCRIPCION", enfermedad.Descripcion)
                    comando.Parameters.AddWithValue("@RECOMENDACIONES", enfermedad.Recomendaciones)
                    comando.Parameters.AddWithValue("@GRAVEDAD", enfermedad.Gravedad)
                    comando.Parameters.AddWithValue("@ID_ESPECIALIDAD", enfermedad.Especialidad.ID)
                    comando.Parameters.AddWithValue("@NOMBRE", enfermedad.Nombre)
                    ConexionBD.EjecutarTransaccion(comando)

                    Dim comandoBusquedaID As New MySqlCommand("SELECT ID FROM enfermedades WHERE NOMBRE=@NOMBRE;")
                    comandoBusquedaID.Parameters.AddWithValue("@NOMBRE", enfermedad.Nombre)
                    Dim idEnfermedadBD As Integer = ConexionBD.EjecutarConsulta(comandoBusquedaID).Rows(0)(0)
                    comando.CommandText = ""
                    comando.Parameters.Clear()
                    For i = 0 To enfermedad.Sintomas.Count - 1
                        comando.CommandText &= String.Format("INSERT INTO cuadro_sintomatico VALUES (@ID_SINTOMA{0}, @ID_ENFERMEDAD, @FRECUENCIA{0});", i)
                        comando.Parameters.AddWithValue("@ID_SINTOMA" & i, enfermedad.Sintomas(i).ID)
                        comando.Parameters.AddWithValue("@FRECUENCIA" & i, enfermedad.FrecuenciaSintoma(i).ToString.Replace(",", "."))
                    Next
                    comando.Parameters.AddWithValue("@ID_ENFERMEDAD", idEnfermedadBD)
                Else        ' Jamás existió
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
                        comando.Parameters.AddWithValue("@ID_SINTOMA" & i, enfermedad.Sintomas(i).ID)
                        comando.Parameters.AddWithValue("@FRECUENCIA" & i, enfermedad.FrecuenciaSintoma(i).ToString.Replace(",", "."))
                    Next
                    comando.Parameters.AddWithValue("@ID_ENFERMEDAD", idEnfermedadBD)
                End If


            Case TiposObjeto.Especialidad
                Dim especialidad As Especialidad = objetoAInsertar

                Dim estaDeshabilitado As Boolean = False
                For Each r As DataRow In ConexionBD.EjecutarConsulta(New MySqlCommand("SELECT * FROM especialidades WHERE HABILITADO=FALSE;")).Rows
                    If r("NOMBRE") = especialidad.Nombre Then
                        estaDeshabilitado = True
                        Exit For
                    End If
                Next

                If estaDeshabilitado Then
                    comando.CommandText &= ("UPDATE especialidades SET HABILITADO=TRUE WHERE NOMBRE=@NOMBRE;")
                    comando.Parameters.AddWithValue("@NOMBRE", especialidad.Nombre)
                Else
                    comando.CommandText &= ("INSERT INTO especialidades (NOMBRE) VALUES (@NOMBRE);")
                    comando.Parameters.AddWithValue("@NOMBRE", especialidad.Nombre)
                End If


            Case TiposObjeto.Departamento
                Dim departamento As Departamento = objetoAInsertar
                comando.CommandText &= "INSERT INTO departamentos (NOMBRE) VALUES (@NOMBRE);"
                comando.Parameters.AddWithValue("@NOMBRE", departamento.Nombre)


            Case TiposObjeto.Localidad
                Dim localidad As Localidad = objetoAInsertar
                comando.CommandText &= "INSERT INTO localidades (NOMBRE, ID_DEPARTAMENTO) VALUES (@NOMBRE, @ID_DEPARTAMENTO)"
                comando.Parameters.AddWithValue("@NOMBRE", localidad.Nombre)
                comando.Parameters.AddWithValue("@NOMBRE", localidad.Departamento.ID)



            Case TiposObjeto.Sintoma
                Dim sintoma As Sintoma = objetoAInsertar

                Dim estaDeshabilitado As Boolean = False
                For Each r As DataRow In ConexionBD.EjecutarConsulta(New MySqlCommand("SELECT * FROM sintomas WHERE HABILITADO=FALSE;")).Rows
                    If r("NOMBRE") = sintoma.Nombre Then
                        estaDeshabilitado = True
                        Exit For
                    End If
                Next

                If estaDeshabilitado Then
                    comando.CommandText &= "UPDATE sintomas SET HABILITADO=TRUE, DESCRIPCION=@DESCRIPCION, RECOMENDACIONES=@RECOMENDACIONES, URGENCIA=@URGENCIA WHERE NOMBRE=@NOMBRE;"
                    comando.Parameters.AddWithValue("@DESCRIPCION", sintoma.Descripcion)
                    comando.Parameters.AddWithValue("@RECOMENDACIONES", sintoma.Recomendaciones)
                    comando.Parameters.AddWithValue("@URGENCIA", sintoma.Urgencia)
                    comando.Parameters.AddWithValue("@NOMBRE", sintoma.Nombre)
                    ConexionBD.EjecutarTransaccion(comando)

                    Dim comandoBusquedaID As New MySqlCommand("SELECT ID FROM sintomas WHERE NOMBRE=@NOMBRE;")
                    comandoBusquedaID.Parameters.AddWithValue("@NOMBRE", sintoma.Nombre)
                    Dim idSintomaBD As Integer = ConexionBD.EjecutarConsulta(comandoBusquedaID).Rows(0)(0)
                    comando.CommandText = ""
                    comando.Parameters.Clear()
                    For i = 0 To sintoma.Enfermedades.Count - 1
                        comando.CommandText &= String.Format("INSERT INTO cuadro_sintomatico VALUES (@ID_SINTOMA, @ID_ENFERMEDAD{0}, @FRECUENCIA{0});", i)
                        comando.Parameters.AddWithValue("@ID_ENFERMEDAD" & i, sintoma.Enfermedades(i).Id)
                        comando.Parameters.AddWithValue("@FRECUENCIA" & i, sintoma.FrecuenciaEnfermedad(i).ToString.Replace(",", "."))
                    Next
                    comando.Parameters.AddWithValue("@ID_SINTOMA", idSintomaBD)

                Else
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
                End If


            Case TiposObjeto.Usuario
                Dim usuario As Usuario = objetoAInsertar
                comando.CommandText &= "INSERT INTO usuarios (CONTRASENIA, TIPO, ID_PERSONA) VALUES (@CONTRASENIA, @TIPO, @ID_PERSONA);"
                comando.Parameters.AddWithValue("@CONTRASENIA", usuario.Contrasena)
                comando.Parameters.AddWithValue("@TIPO", usuario.Tipo)
                comando.Parameters.AddWithValue("@ID_PERSONA", usuario.Persona.ID)


            Case TiposObjeto.Mensaje
                Dim mensaje As Mensaje = objetoAInsertar
                comando.CommandText &= "INSERT INTO mensajes (FECHAHORA, FORMATO, CONTENIDO, REMITENTE, ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA) VALUES (@FECHAHORA, @FORMATO, @CONTENIDO, @REMITENTE, @ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA);"
                comando.Parameters.AddWithValue("@FECHAHORA", mensaje.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"))
                comando.Parameters.AddWithValue("@FORMATO", mensaje.Formato)
                comando.Parameters.AddWithValue("@CONTENIDO", Encoding.UTF8.GetString(mensaje.Contenido))
                comando.Parameters.AddWithValue("@REMITENTE", mensaje.Remitente)
                comando.Parameters.AddWithValue("@ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA", mensaje.DiagnosticoPrimarioConConsulta.ID)


            Case TiposObjeto.Administrativo
                Dim administrativo As Administrativo = objetoAInsertar

                Dim estaDeshabilitado As Boolean = False
                Dim idAdministrativoBD As Integer = -1
                Dim tablaAdministrativos As DataTable = ConexionBD.EjecutarConsulta(New MySqlCommand("SELECT * FROM ObtenerListadoAdministrativos WHERE `Habilitado administrativo`=FALSE"))
                For Each filaAdministrativo As DataRow In tablaAdministrativos.Rows
                    If filaAdministrativo("CI administrativo") = administrativo.CI Then
                        estaDeshabilitado = True
                        idAdministrativoBD = filaAdministrativo("CI administrativo")
                    End If
                Next

                If estaDeshabilitado Then
                    comando.CommandText &= "UPDATE personas SET CI=@CI, NOMBRE=@NOMBRE, APELLIDO=@APELLIDO, CORREO=@CORREO, ID_LOCALIDAD=@ID_LOCALIDAD, TIPO=@TIPO WHERE ID=@ID;"
                    comando.CommandText &= "UPDATE funcionarios SET HABILITADO=TRUE WHERE ID_PERSONA=@ID;"
                    comando.CommandText &= "UPDATE administrativos SET ES_ENCARGADO=@ES_ENCARGADO WHERE ID_FUNCIONARIO=@ID;"
                    comando.Parameters.AddWithValue("@CI", administrativo.CI)
                    comando.Parameters.AddWithValue("@NOMBRE", administrativo.Nombre)
                    comando.Parameters.AddWithValue("@APELLIDO", administrativo.Apellido)
                    comando.Parameters.AddWithValue("@CORREO", administrativo.Correo)
                    comando.Parameters.AddWithValue("@ID_LOCALIDAD", administrativo.Localidad.ID)
                    comando.Parameters.AddWithValue("@TIPO", administrativo.Tipo)
                    comando.Parameters.AddWithValue("@ES_ENCARGADO", administrativo.EsEncargado)
                    comando.Parameters.AddWithValue("@ID", administrativo.ID)

                Else
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
                    comando.Parameters.AddWithValue("@ID", idAdministrativoBD)
                    comando.Parameters.AddWithValue("@TIPO", TiposFuncionario.Administrativo.ToString)
                    comando.Parameters.AddWithValue("@ES_ENCARGADO", administrativo.EsEncargado)
                End If


            Case TiposObjeto.Paciente
                Dim paciente As Paciente = objetoAInsertar
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


            Case TiposObjeto.Medico
                Dim medico As Medico = objetoAInsertar

                Dim estaDeshabilitado As Boolean = False
                Dim idMedicoBD As Integer = -1
                Dim tablaMedicos As DataTable = ConexionBD.EjecutarConsulta(New MySqlCommand("SELECT * FROM ObtenerListadoMedicos WHERE `Habilitado medico`=FALSE"))
                For Each filaMedico As DataRow In tablaMedicos.Rows
                    If filaMedico("CI medico") = medico.CI Then
                        estaDeshabilitado = True
                        idMedicoBD = filaMedico("ID medico")
                    End If
                Next

                If estaDeshabilitado Then
                    comando.CommandText &= "UPDATE personas SET CI=@CI, NOMBRE=@NOMBRE, APELLIDO=@APELLIDO, CORREO=@CORREO, ID_LOCALIDAD=@ID_LOCALIDAD, TIPO=@TIPO WHERE ID=@ID;"
                    comando.CommandText &= "UPDATE funcionarios SET HABILITADO=TRUE WHERE ID=@ID;"
                    comando.Parameters.AddWithValue("@CI", medico.CI)
                    comando.Parameters.AddWithValue("@NOMBRE", medico.Nombre)
                    comando.Parameters.AddWithValue("@APELLIDO", medico.Apellido)
                    comando.Parameters.AddWithValue("@CORREO", medico.Correo)
                    comando.Parameters.AddWithValue("@ID_LOCALIDAD", medico.Localidad.ID)
                    comando.Parameters.AddWithValue("@TIPO", medico.Tipo.ToString)
                    comando.Parameters.AddWithValue("@ID", idMedicoBD)

                Else
                    comando.CommandText &= "INSERT INTO personas (CI, NOMBRE, APELLIDO, CORREO, ID_LOCALIDAD, TIPO) VALUES (@CI, @NOMBRE, @APELLIDO, @CORREO, @ID_LOCALIDAD, @TIPO);"
                    comando.Parameters.AddWithValue("@CI", medico.CI)
                    comando.Parameters.AddWithValue("@NOMBRE", medico.Nombre)
                    comando.Parameters.AddWithValue("@APELLIDO", medico.Apellido)
                    comando.Parameters.AddWithValue("@CORREO", medico.Correo)
                    comando.Parameters.AddWithValue("@ID_LOCALIDAD", medico.Localidad.ID)
                    comando.Parameters.AddWithValue("@TIPO", medico.Tipo.ToString)
                    ConexionBD.EjecutarTransaccion(comando)

                    idMedicoBD = ConexionBD.ObtenerUltimoIdInsertado
                    comando.Parameters.Clear()
                    comando.CommandText = "INSERT INTO funcionarios VALUES (@ID, @TIPO);"
                    comando.CommandText &= "INSERT INTO medicos VALUES (@ID);"
                    comando.Parameters.AddWithValue("@ID", idMedicoBD)
                    comando.Parameters.AddWithValue("@TIPO", TiposFuncionario.Medico.ToString)
                End If


            Case TiposObjeto.DiagnosticoPrimarioConConsulta
                Dim diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta = objetoAInsertar
                comando.CommandText &= "INSERT INTO diagnosticos_primarios_con_consulta VALUES (@ID_DIAGNOSTICO, @ID_MEDICO, @COMENTARIOS_ADICIONALES);"
                comando.CommandText &= "UPDATE diagnosticos_primarios SET TIPO='Con_Consulta' WHERE ID=@ID_DIAGNOSTICO;"
                comando.Parameters.AddWithValue("@ID_DIAGNOSTICO", diagnosticoPrimarioConConsulta.ID)
                comando.Parameters.AddWithValue("@ID_MEDICO", DBNull.Value)
                comando.Parameters.AddWithValue("@COMENTARIOS_ADICIONALES", diagnosticoPrimarioConConsulta.ComentariosAdicionales)
        End Select

        Try
            ConexionBD.Conexion.Open()
            comando.CommandText = "BEGIN;" & comando.CommandText & "COMMIT;"
            ConexionBD.EjecutarTransaccion(comando)
        Catch ex As MySqlException
            ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
            Throw ex
        Finally
            If ConexionBD.Conexion.State = ConnectionState.Open Then
                ConexionBD.Conexion.Close()
            End If
        End Try
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
        Dim comando As New MySqlCommand("SELECT * FROM ObtenerUsuario WHERE `ID persona`=@ID_PERSONA;")
        comando.Parameters.AddWithValue("@ID_PERSONA", persona.ID)
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
                Dim comentariosDiagnostico As String = If(TypeOf fila("Comentarios consulta") IsNot DBNull, fila("Comentarios consulta"), Nothing)
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
        Dim comando As New MySqlCommand("SELECT * FROM ObtenerDatosConsultas WHERE `ID medico`=@ID_MEDICO AND `Fecha hora diagnostico primario`>DATE_SUB(NOW(), INTERVAL @MESES_HISTORIAL MONTH);")
        comando.Parameters.AddWithValue("@ID_MEDICO", medico.ID)
        comando.Parameters.AddWithValue("@MESES_HISTORIAL", mesesHistorial)
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


        Dim listaConsultas As New List(Of DiagnosticoPrimarioConConsulta)

        For i = 0 To ds.Tables("Diagnosticos").Rows.Count - 1
            Dim fila As DataRow = ds.Tables("Diagnosticos").Rows(i)

            Dim idDiagnostico As Integer = fila("ID diagnostico primario")
            Dim fechaHoraDiagnostico As Date = CType(fila("Fecha hora diagnostico primario"), MySqlDateTime).Value
            Dim tipoDiagnostico As TiposDiagnosticosPrimarios = TiposDiagnosticosPrimarios.Con_Consulta
            Dim comentariosDiagnostico As String = If(TypeOf fila("Comentarios consulta") IsNot DBNull, fila("Comentarios consulta"), Nothing)

            Dim idPaciente As Integer = fila("ID paciente")
            Dim ciPaciente As String = fila("CI paciente")
            Dim nombrePaciente As String = fila("Nombre paciente")
            Dim apellidoPaciente As String = fila("Apellido paciente")
            Dim correoPaciente As String = fila("Correo paciente")
            Dim telefonoMovilPaciente As String = fila("Telefonomovil paciente")
            Dim telefonoFijoPaciente As String = fila("Telefonofijo paciente")
            Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), fila("Sexo paciente"))
            Dim fechaNacimientoPaciente As Date = CType(fila("Fecha nacimiento paciente"), MySqlDateTime).Value
            Dim callePaciente As String = fila("Calle paciente")
            Dim numeroPuertaPaciente As String = fila("Numero puerta paciente")
            Dim apartamentoPaciente As String = If(TypeOf fila("Apartamento paciente") IsNot DBNull, fila("Apartamento paciente"), Nothing)
            Dim idLocalidadPaciente As Integer = fila("ID localidad paciente")
            Dim nombreLocalidadPaciente As String = fila("Nombre localidad paciente")
            Dim idDepartamentoPaciente As Integer = fila("ID departamento paciente")
            Dim nombreDepartamentoPaciente As String = fila("Nombre departamento paciente")

            Dim departamentoPaciente As New Departamento(idDepartamentoPaciente, nombreDepartamentoPaciente)
            Dim localidadPaciente As New Localidad(idLocalidadPaciente, nombreLocalidadPaciente, departamentoPaciente)
            Dim paciente As New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, localidadPaciente, telefonoMovilPaciente,
                                         telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente, callePaciente, numeroPuertaPaciente,
                                         apartamentoPaciente)

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

            listaConsultas.Add(New DiagnosticoPrimarioConConsulta(idDiagnostico, paciente, sintomas, enfermedadesDiagnosticadas, fechaHoraDiagnostico,
                                                                  medico, comentariosDiagnostico))
        Next

        Return listaConsultas
    End Function

    Public Function ObtenerUltimosMensajesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta, cantidadARetornar As Integer) As List(Of Mensaje)
        Dim comando As New MySqlCommand("SELECT * FROM ObtenerUltimosMensajesConsulta WHERE `ID diagnostico`=@ID_DIAGNOSTICO LIMIT @CANTIDAD_MENSAJES;")
        comando.Parameters.AddWithValue("@ID_DIAGNOSTICO", diagnosticoPrimarioConConsulta.ID)
        comando.Parameters.AddWithValue("@CANTIDAD_MENSAJES", cantidadARetornar)
        Dim datos As DataTable = ConexionBD.EjecutarConsulta(comando)

        Dim listaMensajes As New List(Of Mensaje)

        For i = 0 To datos.Rows.Count - 1
            Dim fila As DataRow = datos.Rows(i)
            Dim idMensaje As Integer = fila("ID mensaje")
            Dim fechaHoraMensaje As Date = CType(fila("Fecha hora mensaje"), MySqlDateTime).Value
            Dim formatoMensaje As FormatosMensajeAdmitidos = [Enum].Parse(GetType(FormatosMensajeAdmitidos), fila("Formato mensaje"))
            Dim contenidoMensaje() As Byte = fila("Contenido mensaje")
            Dim remitenteMensaje As TiposRemitente = [Enum].Parse(GetType(TiposRemitente), fila("Remitente mensaje"))
            listaMensajes.Add(New Mensaje(idMensaje, fechaHoraMensaje, formatoMensaje, contenidoMensaje, remitenteMensaje, diagnosticoPrimarioConConsulta))
        Next

        Return listaMensajes
    End Function

    Public Function ObtenerCantidadMensajesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta) As Integer
        Dim comando As New MySqlCommand("SELECT COUNT(*) FROM ObtenerUltimosMensajesConsulta WHERE `ID diagnostico`=@ID_DIAGNOSTICO;")
        comando.Parameters.AddWithValue("@ID_DIAGNOSTICO", diagnosticoPrimarioConConsulta.ID)
        Dim cantidad As Integer = ConexionBD.EjecutarConsulta(comando).Rows(0)(0)
        Return cantidad
    End Function

    Public Function ObtenerCantidadDiagnosticosDiferencialesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta) As Integer
        Dim comando As New MySqlCommand("SELECT COUNT(*) FROM diagnosticos_diferenciales WHERE ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA=@ID_DIAGNOSTICO")
        comando.Parameters.AddWithValue("@ID_DIAGNOSTICO", diagnosticoPrimarioConConsulta.ID)
        Dim cantidad As Integer = ConexionBD.EjecutarConsulta(comando).Rows(0)(0)
        Return cantidad
    End Function

    Public Function ObtenerDiagnosticosDiferencialesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta) As List(Of DiagnosticoDiferencial)
        Dim ds As New DataSet
        Dim comando As New MySqlCommand("SELECT * FROM ObtenerDiagnosticosDiferencialesPorConsulta WHERE `ID diagnostico primario`=@ID_DIAGNOSTICO_PRIMARIO;")
        comando.Parameters.AddWithValue("@ID_DIAGNOSTICO_PRIMARIO", diagnosticoPrimarioConConsulta.ID)
        ds.Tables.Add(ConexionBD.EjecutarConsulta(comando, "Diferenciales"))
        comando.CommandText = "SELECT * FROM ObtenerSintomasAsociados;"
        ds.Tables.Add(ConexionBD.EjecutarConsulta(comando, "SintomasAsociados"))

        Dim listaDiagnosticosDiferenciales As New List(Of DiagnosticoDiferencial)
        Dim diferenciales As DataTable = ds.Tables("Diferenciales")
        Dim sintomasAsociados As DataTable = ds.Tables("SintomasAsociados")

        For i = 0 To diferenciales.Rows.Count - 1
            Dim filaDiferencial As DataRow = diferenciales.Rows(i)
            Dim idDiferencial As Integer = filaDiferencial("ID diagnostico diferencial")
            Dim conductaASeguirDiferencial As String = filaDiferencial("Conducta a seguir diagnostico diferencial")
            Dim fechaHoraDiferencial As Date = CType(filaDiferencial("Fecha hora diagnostico diferencial"), MySqlDateTime).Value
            Dim idEnfermedad As Integer = filaDiferencial("ID enfermedad")
            Dim nombreEnfermedad As String = filaDiferencial("Nombre enfermedad")
            Dim descripcionEnfermedad As String = filaDiferencial("Descripcion enfermedad")
            Dim recomendacionesEnfermedad As String = filaDiferencial("Recomendaciones enfermedad")
            Dim gravedadEnfermedad As Integer = filaDiferencial("Gravedad enfermedad")
            Dim habilitadoEnfermedad As Boolean = filaDiferencial("Habilitado enfermedad")
            Dim idEspecialidad As Integer = filaDiferencial("ID especialidad")
            Dim nombreEspecialidad As String = filaDiferencial("Nombre especialidad")
            Dim habilitadoEspecialidad As Boolean = filaDiferencial("Habilitado especialidad")
            Dim especialidadEnfermedad As New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad)

            Dim listaSintomas As New List(Of Sintoma)
            Dim listaFrecuencias As New List(Of Decimal)
            For j = 0 To sintomasAsociados.Rows.Count - 1
                Dim filaSintoma As DataRow = sintomasAsociados.Rows(j)
                If filaSintoma("ID enfermedad") = filaDiferencial("ID enfermedad") Then
                    Dim idSintoma As Integer = filaSintoma("ID Sintoma")
                    Dim nombreSintoma As String = filaSintoma("Nombre Sintoma")
                    Dim descripcionSintoma As String = filaSintoma("Descripcion Sintoma")
                    Dim recomendacionesSintoma As String = filaSintoma("Recomendaciones Sintoma")
                    Dim urgenciaSintoma As Integer = filaSintoma("Urgencia Sintoma")
                    Dim habilitadoSintoma As Boolean = filaSintoma("Habilitado Sintoma")
                    Dim frecuenciaSintoma As Decimal = filaSintoma("Frecuencia cuadro sintomatico")
                    listaSintomas.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma, Nothing, habilitadoSintoma))
                    listaFrecuencias.Add(frecuenciaSintoma)
                End If
            Next
            Dim sintomasEnfermedad As New SintomasAsociados(listaSintomas, listaFrecuencias)
            Dim enfermedadDiferencial As New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad,
                                                        descripcionEnfermedad, sintomasEnfermedad, especialidadEnfermedad, habilitadoEnfermedad)

            listaDiagnosticosDiferenciales.Add(New DiagnosticoDiferencial(idDiferencial, Nothing, enfermedadDiferencial, conductaASeguirDiferencial,
                                                                          fechaHoraDiferencial))
        Next

        For Each d As DiagnosticoDiferencial In listaDiagnosticosDiferenciales
            MsgBox(String.Join(vbNewLine, {d.ConductaASeguir, d.FechaHora, d.EnfermedadDiagnosticada.Nombre, d.EnfermedadDiagnosticada.Especialidad.Nombre}) & vbNewLine & vbNewLine)
            Dim texto As New List(Of String)
            For Each s As Sintoma In d.EnfermedadDiagnosticada.Sintomas
                texto.Add(String.Format("{0} ({1}%)", s.Nombre, d.EnfermedadDiagnosticada.FrecuenciaSintoma(d.EnfermedadDiagnosticada.Sintomas.IndexOf(s))))
            Next
            MsgBox(String.Join(vbNewLine, texto))
        Next

        Return listaDiagnosticosDiferenciales
    End Function

    Public Function ObtenerConsultasSinAtender() As List(Of DiagnosticoPrimarioConConsulta)
        Dim ds As New DataSet
        Dim comando As New MySqlCommand("SELECT * FROM ObtenerDatosConsultas WHERE `ID medico` IS NULL;")
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


        Dim listaConsultas As New List(Of DiagnosticoPrimarioConConsulta)

        For i = 0 To ds.Tables("Diagnosticos").Rows.Count - 1
            Dim fila As DataRow = ds.Tables("Diagnosticos").Rows(i)

            Dim idDiagnostico As Integer = fila("ID diagnostico primario")
            Dim fechaHoraDiagnostico As Date = CType(fila("Fecha hora diagnostico primario"), MySqlDateTime).Value
            Dim tipoDiagnostico As TiposDiagnosticosPrimarios = TiposDiagnosticosPrimarios.Con_Consulta
            Dim comentariosDiagnostico As String = If(TypeOf fila("Comentarios consulta") IsNot DBNull, fila("Comentarios consulta"), Nothing)

            Dim idPaciente As Integer = fila("ID paciente")
            Dim ciPaciente As String = fila("CI paciente")
            Dim nombrePaciente As String = fila("Nombre paciente")
            Dim apellidoPaciente As String = fila("Apellido paciente")
            Dim correoPaciente As String = fila("Correo paciente")
            Dim telefonoMovilPaciente As String = fila("Telefonomovil paciente")
            Dim telefonoFijoPaciente As String = fila("Telefonofijo paciente")
            Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), fila("Sexo paciente"))
            Dim fechaNacimientoPaciente As Date = CType(fila("Fecha nacimiento paciente"), MySqlDateTime).Value
            Dim callePaciente As String = fila("Calle paciente")
            Dim numeroPuertaPaciente As String = fila("Numero puerta paciente")
            Dim apartamentoPaciente As String = If(TypeOf fila("Apartamento paciente") IsNot DBNull, fila("Apartamento paciente"), Nothing)
            Dim idLocalidadPaciente As Integer = fila("ID localidad paciente")
            Dim nombreLocalidadPaciente As String = fila("Nombre localidad paciente")
            Dim idDepartamentoPaciente As Integer = fila("ID departamento paciente")
            Dim nombreDepartamentoPaciente As String = fila("Nombre departamento paciente")

            Dim departamentoPaciente As New Departamento(idDepartamentoPaciente, nombreDepartamentoPaciente)
            Dim localidadPaciente As New Localidad(idLocalidadPaciente, nombreLocalidadPaciente, departamentoPaciente)
            Dim paciente As New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, localidadPaciente, telefonoMovilPaciente,
                                         telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente, callePaciente, numeroPuertaPaciente,
                                         apartamentoPaciente)

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

            listaConsultas.Add(New DiagnosticoPrimarioConConsulta(idDiagnostico, paciente, sintomas, enfermedadesDiagnosticadas, fechaHoraDiagnostico,
                                                                  Nothing, comentariosDiagnostico))
        Next

        Return listaConsultas
    End Function

    Public Sub AsignarIDMedicoAConsulta(medico As Medico, consulta As DiagnosticoPrimarioConConsulta)
        ConexionBD.Conexion.Open()
        Dim comando As New MySqlCommand("UPDATE diagnosticos_primarios_con_consulta SET ID_MEDICO=@ID_MEDICO WHERE ID_DIAGNOSTICO_PRIMARIO=@ID_DIAGNOSTICO;")
        comando.Parameters.AddWithValue("@ID_MEDICO", consulta.Medico.ID)
        comando.Parameters.AddWithValue("@ID_DIAGNOSTICO", consulta.ID)
        ConexionBD.EjecutarTransaccion(comando)
        ConexionBD.Conexion.Close()
    End Sub

    Public Function ObtenerListadoSintomas()
        Dim ds As New DataSet
        Dim comando As New MySqlCommand("SELECT * FROM sintomas WHERE HABILITADO=TRUE;")
        ds.Tables.Add(ConexionBD.EjecutarConsulta(comando, "Sintomas"))
        comando.CommandText = "SELECT * FROM ObtenerEnfermedadesAsociadas"
        ds.Tables.Add(ConexionBD.EjecutarConsulta(comando, "EnfermedadesAsociadas"))

        Dim tablaSintomas As DataTable = ds.Tables("Sintomas")
        Dim tablaEnfermedadesAsociadas As DataTable = ds.Tables("EnfermedadesAsociadas")

        Dim listadoSintomas As New List(Of Sintoma)

        For i = 0 To tablaSintomas.Rows.Count - 1
            Dim filaSintoma As DataRow = tablaSintomas.Rows(i)
            Dim idSintoma As Integer = filaSintoma("ID")
            Dim nombreSintoma As String = filaSintoma("NOMBRE")
            Dim descripcionSintoma As String = filaSintoma("DESCRIPCION")
            Dim recomendacionesSintoma As String = filaSintoma("RECOMENDACIONES")
            Dim urgenciaSintoma As Integer = filaSintoma("URGENCIA")

            Dim listaEnfermedades As New List(Of Enfermedad)
            Dim listaFrecuencias As New List(Of Decimal)
            For j = 0 To tablaEnfermedadesAsociadas.Rows.Count - 1
                Dim filaEnfermedad As DataRow = tablaEnfermedadesAsociadas.Rows(j)
                If filaEnfermedad("ID sintoma asociado") = filaSintoma("ID") Then
                    Dim idEnfermedad As Integer = filaEnfermedad("ID enfermedad")
                    Dim nombreEnfermedad As String = filaEnfermedad("Nombre enfermedad")
                    Dim descripcionEnfermedad As String = filaEnfermedad("Descripcion enfermedad")
                    Dim recomendacionesEnfermedad As String = filaEnfermedad("Recomendaciones enfermedad")
                    Dim gravedadEnfermedad As Integer = filaEnfermedad("Gravedad enfermedad")
                    Dim habilitadoEnfermedad As Boolean = filaEnfermedad("Habilitado enfermedad")
                    Dim idEspecialidad As Integer = filaEnfermedad("ID especialidad")
                    Dim nombreEspecialidad As String = filaEnfermedad("Nombre especialidad")
                    Dim habilitadoEspecialidad As Boolean = filaEnfermedad("Habilitado especialidad")
                    Dim especialidadEnfermedad As New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad)
                End If
            Next

            Dim enfermedadesAsociadas As New EnfermedadesAsociadas(listaEnfermedades, listaFrecuencias)
            listadoSintomas.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma, enfermedadesAsociadas, True))
        Next

        Return listadoSintomas
    End Function

    Public Function ObtenerListadoEnfermedades()
        Dim ds As New DataSet
        Dim comando As New MySqlCommand("SELECT * FROM ObtenerListadoEnfermedades WHERE `Habilitado enfermedad`=TRUE;")
        ds.Tables.Add(ConexionBD.EjecutarConsulta(comando, "Enfermedades"))
        comando.CommandText = "SELECT * FROM ObtenerSintomasAsociados"
        ds.Tables.Add(ConexionBD.EjecutarConsulta(comando, "SintomasAsociados"))

        Dim tablaEnfermedades As DataTable = ds.Tables("Enfermedades")
        Dim tablaSintomasAsociados As DataTable = ds.Tables("SintomasAsociados")

        Dim listadoEnfermedades As New List(Of Enfermedad)

        For i = 0 To tablaEnfermedades.Rows.Count - 1
            Dim filaEnfermedad As DataRow = tablaEnfermedades.Rows(i)
            Dim idEnfermedad As Integer = filaEnfermedad("ID enfermedad")
            Dim nombreEnfermedad As String = filaEnfermedad("Nombre enfermedad")
            Dim descripcionEnfermedad As String = filaEnfermedad("Descripcion enfermedad")
            Dim recomendacionesEnfermedad As String = filaEnfermedad("Recomendaciones enfermedad")
            Dim gravedadEnfermedad As Integer = filaEnfermedad("Gravedad enfermedad")
            Dim habilitadoEnfermedad As Boolean = filaEnfermedad("Habilitado enfermedad")
            Dim idEspecialidad As Integer = filaEnfermedad("ID especialidad")
            Dim nombreEspecialidad As String = filaEnfermedad("Nombre especialidad")
            Dim habilitadoEspecialidad As Boolean = filaEnfermedad("Habilitado especialidad")
            Dim especialidadEnfermedad As New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad)

            Dim listaSintomas As New List(Of Sintoma)
            Dim listaFrecuencias As New List(Of Decimal)
            For j = 0 To tablaSintomasAsociados.Rows.Count - 1
                Dim filaSintoma As DataRow = tablaSintomasAsociados.Rows(j)
                If filaSintoma("ID enfermedad") = filaEnfermedad("ID enfermedad") Then
                    Dim idSintoma As Integer = filaSintoma("ID Sintoma")
                    Dim nombreSintoma As String = filaSintoma("Nombre Sintoma")
                    Dim descripcionSintoma As String = filaSintoma("Descripcion Sintoma")
                    Dim recomendacionesSintoma As String = filaSintoma("Recomendaciones Sintoma")
                    Dim urgenciaSintoma As Integer = filaSintoma("Urgencia Sintoma")
                    Dim habilitadoSintoma As Boolean = filaSintoma("Habilitado Sintoma")
                    Dim frecuenciaSintoma As Decimal = filaSintoma("Frecuencia cuadro sintomatico")
                    listaSintomas.Add(New Sintoma(idSintoma, nombreSintoma, descripcionSintoma, recomendacionesSintoma, urgenciaSintoma, Nothing, habilitadoSintoma))
                    listaFrecuencias.Add(frecuenciaSintoma)
                End If
            Next

            Dim sintomasEnfermedad As New SintomasAsociados(listaSintomas, listaFrecuencias)
            listadoEnfermedades.Add(New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad,
                                                   descripcionEnfermedad, sintomasEnfermedad, especialidadEnfermedad, habilitadoEnfermedad))
        Next

        Return listadoEnfermedades
    End Function

    Public Function ObtenerListadoEspecialidades()
        Dim ds As New DataSet
        Dim comando As New MySqlCommand("SELECT * FROM especialidades WHERE HABILITADO=TRUE;")
        ds.Tables.Add(ConexionBD.EjecutarConsulta(comando, "Especialidades"))
        comando.CommandText = "SELECT * FROM ObtenerMedicosPorEspecialidad WHERE `Habilitado funcionario medico`=TRUE;"
        ds.Tables.Add(ConexionBD.EjecutarConsulta(comando, "Medicos"))

        Dim tablaEspecialidades As DataTable = ds.Tables("Especialidades")
        Dim tablaMedicos As DataTable = ds.Tables("Medicos")

        ds.Relations.Add("MedicosEspecialidad", tablaEspecialidades.Columns("ID"), tablaMedicos.Columns("ID especialidad"))

        Dim listadoEspecialidades As New List(Of Especialidad)

        For i = 0 To tablaEspecialidades.Rows.Count - 1
            Dim filaEspecialidad As DataRow = tablaEspecialidades.Rows(i)
            Dim idEspecialidad As Integer = filaEspecialidad("ID")
            Dim nombreEspecialidad As String = filaEspecialidad("NOMBRE")

            Dim listaMedicos As New List(Of Medico)
            For Each filaMedico As DataRow In filaEspecialidad.GetChildRows("MedicosEspecialidad")
                Dim idMedico As Integer = filaMedico("ID medico")
                Dim ciMedico As String = filaMedico("CI medico")
                Dim nombreMedico As String = filaMedico("Nombre medico")
                Dim apellidoMedico As String = filaMedico("Apellido medico")
                Dim correoMedico As String = filaMedico("Correo medico")
                Dim idLocalidad As String = filaMedico("ID localidad medico")
                Dim nombreLocalidad As String = filaMedico("Nombre localidad medico")
                Dim idDepartamento As String = filaMedico("ID departamento medico")
                Dim nombreDepartamento As String = filaMedico("Nombre departamento medico")

                Dim departamentoLocalidad As New Departamento(idDepartamento, nombreDepartamento)
                Dim localidadMedico As New Localidad(idLocalidad, nombreLocalidad, departamentoLocalidad)
                listaMedicos.Add(New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, localidadMedico, Nothing, True))
            Next

            listadoEspecialidades.Add(New Especialidad(idEspecialidad, nombreEspecialidad, listaMedicos, True))
        Next

        Return listadoEspecialidades
    End Function

    Public Sub InsertarEnfermedadesImportadas(lista As List(Of Enfermedad))
        Try
            ConexionBD.Conexion.Open()
            ConexionBD.EjecutarTransaccion(New MySqlCommand("BEGIN;"))

            For Each enfermedad As Enfermedad In lista
                Dim comando As New MySqlCommand("")

                Dim estaDeshabilitado As Boolean = False
                For Each r As DataRow In ConexionBD.EjecutarConsulta(New MySqlCommand("SELECT * FROM enfermedades WHERE HABILITADO=FALSE;")).Rows
                    If r("NOMBRE") = enfermedad.Nombre Then
                        estaDeshabilitado = True
                        Exit For
                    End If
                Next

                If estaDeshabilitado Then       ' Existe, y se deshabilitó
                    comando.CommandText &= "UPDATE enfermedades SET HABILITADO=TRUE, DESCRIPCION=@DESCRIPCION, RECOMENDACIONES=@RECOMENDACIONES, GRAVEDAD=@GRAVEDAD, ID_ESPECIALIDAD=@ID_ESPECIALIDAD WHERE NOMBRE=@NOMBRE"
                    comando.Parameters.AddWithValue("@DESCRIPCION", enfermedad.Descripcion)
                    comando.Parameters.AddWithValue("@RECOMENDACIONES", enfermedad.Recomendaciones)
                    comando.Parameters.AddWithValue("@GRAVEDAD", enfermedad.Gravedad)
                    comando.Parameters.AddWithValue("@ID_ESPECIALIDAD", enfermedad.Especialidad.ID)
                    comando.Parameters.AddWithValue("@NOMBRE", enfermedad.Nombre)
                    ConexionBD.EjecutarTransaccion(comando)

                    Dim comandoBusquedaID As New MySqlCommand("SELECT ID FROM enfermedades WHERE NOMBRE=@NOMBRE;")
                    comandoBusquedaID.Parameters.AddWithValue("@NOMBRE", enfermedad.Nombre)
                    Dim idEnfermedadBD As Integer = ConexionBD.EjecutarConsulta(comandoBusquedaID).Rows(0)(0)
                    comando.CommandText = ""
                    comando.Parameters.Clear()
                    For i = 0 To enfermedad.Sintomas.Count - 1
                        comando.CommandText &= String.Format("INSERT INTO cuadro_sintomatico VALUES (@ID_SINTOMA{0}, @ID_ENFERMEDAD, @FRECUENCIA{0});", i)
                        comando.Parameters.AddWithValue("@ID_SINTOMA" & i, enfermedad.Sintomas(i).ID)
                        comando.Parameters.AddWithValue("@FRECUENCIA" & i, enfermedad.FrecuenciaSintoma(i).ToString.Replace(",", "."))
                    Next
                    comando.Parameters.AddWithValue("@ID_ENFERMEDAD", idEnfermedadBD)
                Else        ' Jamás existió
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
                        comando.Parameters.AddWithValue("@ID_SINTOMA" & i, enfermedad.Sintomas(i).ID)
                        comando.Parameters.AddWithValue("@FRECUENCIA" & i, enfermedad.FrecuenciaSintoma(i).ToString.Replace(",", "."))
                    Next
                    comando.Parameters.AddWithValue("@ID_ENFERMEDAD", idEnfermedadBD)
                End If

                ConexionBD.EjecutarTransaccion(comando)
            Next

            ConexionBD.EjecutarTransaccion(New MySqlCommand("COMMIT;"))
        Catch ex As Exception
            ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
            Throw ex
        Finally
            If ConexionBD.Conexion.State = ConnectionState.Open Then
                ConexionBD.Conexion.Close()
            End If
        End Try
    End Sub

    Public Sub InsertarSintomasImportados(lista As List(Of Sintoma))
        Try
            ConexionBD.Conexion.Open()
            ConexionBD.EjecutarTransaccion(New MySqlCommand("BEGIN;"))

            For Each sintoma As Sintoma In lista
                Dim comando As New MySqlCommand("")

                Dim estaDeshabilitado As Boolean = False
                For Each r As DataRow In ConexionBD.EjecutarConsulta(New MySqlCommand("SELECT * FROM sintomas WHERE HABILITADO=FALSE;")).Rows
                    If r("NOMBRE") = sintoma.Nombre Then
                        estaDeshabilitado = True
                        Exit For
                    End If
                Next

                If estaDeshabilitado Then
                    comando.CommandText &= "UPDATE sintomas SET HABILITADO=TRUE, DESCRIPCION=@DESCRIPCION, RECOMENDACIONES=@RECOMENDACIONES, URGENCIA=@URGENCIA WHERE NOMBRE=@NOMBRE;"
                    comando.Parameters.AddWithValue("@DESCRIPCION", sintoma.Descripcion)
                    comando.Parameters.AddWithValue("@RECOMENDACIONES", sintoma.Recomendaciones)
                    comando.Parameters.AddWithValue("@URGENCIA", sintoma.Urgencia)
                    comando.Parameters.AddWithValue("@NOMBRE", sintoma.Nombre)
                    ConexionBD.EjecutarTransaccion(comando)

                    Dim comandoBusquedaID As New MySqlCommand("SELECT ID FROM sintomas WHERE NOMBRE=@NOMBRE;")
                    comandoBusquedaID.Parameters.AddWithValue("@NOMBRE", sintoma.Nombre)
                    Dim idSintomaBD As Integer = ConexionBD.EjecutarConsulta(comandoBusquedaID).Rows(0)(0)
                    comando.CommandText = ""
                    comando.Parameters.Clear()
                    For i = 0 To sintoma.Enfermedades.Count - 1
                        comando.CommandText &= String.Format("INSERT INTO cuadro_sintomatico VALUES (@ID_SINTOMA, @ID_ENFERMEDAD{0}, @FRECUENCIA{0});", i)
                        comando.Parameters.AddWithValue("@ID_ENFERMEDAD" & i, sintoma.Enfermedades(i).Id)
                        comando.Parameters.AddWithValue("@FRECUENCIA" & i, sintoma.FrecuenciaEnfermedad(i).ToString.Replace(",", "."))
                    Next
                    comando.Parameters.AddWithValue("@ID_SINTOMA", idSintomaBD)

                Else
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
                End If

                ConexionBD.EjecutarTransaccion(comando)
            Next

            ConexionBD.EjecutarTransaccion(New MySqlCommand("COMMIT;"))
        Catch ex As Exception
            ConexionBD.EjecutarTransaccion(New MySqlCommand("ROLLBACK;"))
            Throw ex
        Finally
            If ConexionBD.Conexion.State = ConnectionState.Open Then
                ConexionBD.Conexion.Close()
            End If
        End Try
    End Sub
End Module
