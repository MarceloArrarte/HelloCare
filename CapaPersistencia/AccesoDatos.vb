Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Runtime.Remoting.Channels
Imports MySql.Data.MySqlClient
Imports MySql.Data.Types
Imports Clases

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
            datos.Tables.Add(SeleccionarTabla(t, TiposSeleccionBD.Ambos))
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


#Region "Código comentado"
    ' Dado un valor del enumerado Clases y una condicion con un ID, retorna el objeto de ese tipo que contiene el ID deseado
    'Public Function ObtenerObjetoPorID(entidad As Clases, condicion As String) As Object
    '    ' Registra en una lista los nombres de las tablas a seleccionar
    '    Dim tablasASeleccionar As New List(Of String)
    '    AnotarTablas(tablasASeleccionar, entidad)

    '    ' Inicializa un DataSet vacío
    '    Dim datos As New DataSet
    '    ' Realiza la primer consulta sobre la tabla primaria según el ID especificado.
    '    ' Las demás tablas no requieren condiciones, ya que se navega por el DataSet usando las relaciones entre los datos de las claves externas.
    '    If condicion <> "" Then
    '        datos.Tables.Add(SeleccionarTabla(tablasASeleccionar(0), TiposSeleccionBD.Ambos, condicion))
    '        tablasASeleccionar.RemoveAt(0)      ' Elimina la tabla ya seleccionada
    '    End If

    '    For Each t As String In tablasASeleccionar
    '        datos.Tables.Add(SeleccionarTabla(t, TiposSeleccionBD.Ambos))
    '    Next
    '    ConexionBD.AplicarClavesExternas(datos)

    '    Dim listaObjetos As New List(Of Object)
    '    PoblarLista(listaObjetos, entidad, datos)
    '    Return listaObjetos
    'End Function

    ' Llena una tabla con los datos de todos los registros de una tabla de la BD.
    'Private Function SeleccionarTabla(nombreTabla As String, tipoSeleccion As TiposSeleccionBD) As DataTable
    '    Dim comando As String = String.Format("SELECT * FROM {0}", nombreTabla)

    '    Select Case tipoSeleccion
    '        Case TiposSeleccionBD.Habilitados
    '            If {"funcionarios", "enfermedades", "sintomas", "especialidades", "usuarios"}.Contains(nombreTabla) Then
    '                comando &= " WHERE HABILITADO=TRUE"
    '            End If

    '        Case TiposSeleccionBD.Deshabilitados
    '            If {"funcionarios", "enfermedades", "sintomas", "especialidades", "usuarios"}.Contains(nombreTabla) Then
    '                comando &= " WHERE HABILITADO=FALSE"
    '            End If
    '    End Select

    '    Dim datos As DataSet = ConexionBD.EjecutarConsulta(comando, nombreTabla)
    '    Dim tabla As DataTable = datos.Tables(nombreTabla)
    '    Return tabla
    'End Function
#End Region

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

                    lista.Add(New DiagnosticoPrimario(idDiagnosticoPrimario, pacienteDiagnosticoPrimario, enfermedadesDiagnosticadasDiagnosticoPrimario,
                                                      fechaHoraDiagnosticoPrimario, tipoDiagnosticoPrimario))
                Next

            Case TiposObjeto.DiagnosticoDiferencial
                For Each rDiagnosticoDiferencial As DataRow In datos.Tables("diagnosticos_diferenciales").Rows
                    Dim idDiagnosticoDiferencial As Integer = rDiagnosticoDiferencial("ID")
                    Dim conductaASeguirDiagnosticoDiferencial As String = rDiagnosticoDiferencial("CONDUCTA_A_SEGUIR")

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
                        New DiagnosticoPrimarioConConsulta(idDiagnosticoPrimarioConConsulta, Nothing, Nothing, fechaHoraDiagnosticoPrimarioConConsulta,
                                                           Nothing, comentariosAdicionalesDiagnosticoPrimarioConConsulta)

                    lista.Add(New DiagnosticoDiferencial(idDiagnosticoDiferencial, diagnosticoPrimarioConConsultaDiagnosticoDiferencial,
                                                         enfermedadDiagnosticoDiferencial, conductaASeguirDiagnosticoDiferencial))
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

                    'Dim listaEnfermedadesEspecialidad As New List(Of Enfermedad)
                    'For Each rEnfermedad As DataRow In rEspecialidad.GetParentRows("enfermedades_ibfk_1")
                    '    Dim idEnfermedad As Integer = rEnfermedad("ID")
                    '    Dim nombreEnfermedad As String = rEnfermedad("NOMBRE")
                    '    Dim recomendacionesEnfermedad As String = rEnfermedad("RECOMENDACIONES")
                    '    Dim gravedadEnfermedad As String = rEnfermedad("GRAVEDAD")
                    '    Dim descripcionEnfermedad As String = rEnfermedad("DESCRIPCION")
                    '    Dim habilitadoEnfermedad As Boolean = rEnfermedad("HABILITADO")

                    '    listaEnfermedadesEspecialidad.Add(New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad,
                    '                                                     descripcionEnfermedad, Nothing, Nothing, Nothing, habilitadoEnfermedad))
                    'Next

                    lista.Add(New Especialidad(idEspecialidad, nombreEspecialidad, listaMedicosEspecialidad, habilitadoEspecialidad))
                Next

            Case TiposObjeto.Departamento
                For Each rDepartamento As DataRow In datos.Tables("departamentos").Rows
                    Dim idDepartamento As Integer = rDepartamento("ID")
                    Dim nombreDepartamento As String = rDepartamento("NOMBRE")

                    'Dim listaLocalidadesDepartamento As New List(Of Localidad)
                    'For Each rLocalidad As DataRow In datos.Tables("localidades").Rows
                    '    If rLocalidad.GetChildRows("localidades_ibfk_1").Single Is rDepartamento Then
                    '        Dim idLocalidad As Integer = rLocalidad("ID")
                    '        Dim nombreLocalidad As String = rLocalidad("NOMBRE")

                    '        listaLocalidadesDepartamento.Add(New Localidad(idLocalidad, nombreLocalidad, Nothing))
                    '    End If
                    'Next

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

                    'Dim listaPersonasLocalidad As New List(Of Persona)
                    'For Each rPersona As DataRow In rLocalidad.GetParentRows("personas_ibfk_1")
                    '    Select Case [Enum].Parse(GetType(Enumerados.TiposPersona), rPersona("TIPO"))
                    '        Case TiposPersona.Paciente
                    '            Dim rPaciente As DataRow = rPersona.GetParentRow("pacientes_ibfk_1")

                    '            Dim idPaciente As Integer = rPersona("ID")
                    '            Dim ciPaciente As String = rPersona("CI")
                    '            Dim nombrePaciente As String = rPersona("NOMBRE")
                    '            Dim apellidoPaciente As String = rPersona("APELLIDO")
                    '            Dim correoPaciente As String = rPersona("CORREO")
                    '            Dim telefonoMovilPaciente As String = rPaciente("TELEFONOMOVIL")
                    '            Dim telefonoFijoPaciente As String = rPaciente("TELEFONOFIJO")
                    '            Dim sexoPaciente As TiposSexo = [Enum].Parse(GetType(TiposSexo), rPaciente("SEXO"))
                    '            Dim fechaNacimientoPaciente As Date = CType(rPaciente("FECHANACIMIENTO"), MySqlDateTime).Value
                    '            Dim callePaciente As String = rPaciente("CALLE")
                    '            Dim numeroPuertaPaciente As String = rPaciente("NUMEROPUERTA")
                    '            Dim apartamentoPaciente As String = ""
                    '            If TypeOf rPaciente("APARTAMENTO") IsNot DBNull Then
                    '                apartamentoPaciente = rPaciente("APARTAMENTO")
                    '            End If

                    '            listaPersonasLocalidad.Add(New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, Nothing,
                    '                                           telefonoMovilPaciente, telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente,
                    '                                           callePaciente, numeroPuertaPaciente, apartamentoPaciente))

                    '        Case TiposPersona.Funcionario
                    '            Dim rFuncionario As DataRow = rPersona.GetParentRow("funcionarios_ibfk_1")
                    '            Select Case [Enum].Parse(GetType(Enumerados.TiposFuncionario), rFuncionario("TIPO"))
                    '                Case TiposFuncionario.Administrativo
                    '                    Dim rAdministrativo As DataRow = rFuncionario.GetParentRow("administrativos_ibfk_1")

                    '                    Dim idAdministrativo As Integer = rPersona("ID")
                    '                    Dim ciAdministrativo As String = rPersona("CI")
                    '                    Dim nombreAdministrativo As String = rPersona("NOMBRE")
                    '                    Dim apellidoAdministrativo As String = rPersona("APELLIDO")
                    '                    Dim correoAdministrativo As String = rPersona("CORREO")
                    '                    Dim esEncargadoAdministrativo As Boolean = rAdministrativo("ES_ENCARGADO")
                    '                    Dim habilitadoAdministrativo As Boolean = rFuncionario("HABILITADO")

                    '                    listaPersonasLocalidad.Add(New Administrativo(idAdministrativo, ciAdministrativo, nombreAdministrativo,
                    '                                                                  apellidoAdministrativo, correoAdministrativo, Nothing,
                    '                                                                  esEncargadoAdministrativo, habilitadoAdministrativo))

                    '                Case TiposFuncionario.Medico
                    '                    Dim idMedico As Integer = rPersona("ID")
                    '                    Dim ciMedico As String = rPersona("CI")
                    '                    Dim nombreMedico As String = rPersona("NOMBRE")
                    '                    Dim apellidoMedico As String = rPersona("APELLIDO")
                    '                    Dim correoMedico As String = rPersona("CORREO")
                    '                    Dim habilitadoMedico As Boolean = rFuncionario("HABILITADO")

                    '                    listaPersonasLocalidad.Add(New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico,
                    '                                                          Nothing, Nothing, habilitadoMedico))
                    '            End Select
                    '    End Select
                    'Next

                    lista.Add(New Localidad(idLocalidad, nombreLocalidad, departamentoLocalidad))
                Next

            Case TiposObjeto.Sintoma
                For Each rSintoma As DataRow In datos.Tables("sintomas").Rows
                    Dim idSintoma As Integer = rSintoma("ID")
                    Dim nombreSintoma As String = rSintoma("NOMBRE")
                    Dim descripcionSintoma As String = rSintoma("DESCRIPCION")
                    Dim recomendacionesSintoma As String = rSintoma("RECOMENDACIONES")
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
                        New DiagnosticoPrimarioConConsulta(idDiagnosticoPrimarioConConsulta, Nothing, Nothing, fechaHoraDiagnosticoPrimarioConConsulta,
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

                    'Dim listaDiagnosticosPrimariosPaciente As New List(Of DiagnosticoPrimario)
                    'For Each rDiagnosticoPrimario As DataRow In datos.Tables("diagnosticos_primarios").Rows
                    '    If rDiagnosticoPrimario.GetChildRows("diagnosticos_primarios_ibfk_1").Single Is rPaciente Then
                    '        Dim idDiagnosticoPrimario As Integer = rDiagnosticoPrimario("ID")
                    '        Dim fechaHoraDiagnosticoPrimario As Date = CType(rDiagnosticoPrimario("FECHA_HORA"), MySqlDateTime).Value
                    '        Dim tipoDiagnosticoPrimario As TiposDiagnosticosPrimarios = [Enum].Parse(GetType(TiposDiagnosticosPrimarios), rDiagnosticoPrimario("TIPO"))

                    '        listaDiagnosticosPrimariosPaciente.Add(New DiagnosticoPrimario(idDiagnosticoPrimario, Nothing, Nothing,
                    '                                                                       fechaHoraDiagnosticoPrimario, tipoDiagnosticoPrimario))
                    '    End If
                    'Next

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

                    'Dim listaDiagnosticosAtendidosMedico As New List(Of DiagnosticoPrimarioConConsulta)
                    'For Each rDiagnosticoPrimarioConConsulta As DataRow In rMedico.GetParentRows("diagnosticos_primarios_con_consulta_ibfk_2")
                    '    Dim rDiagnosticoPrimario As DataRow = rDiagnosticoPrimarioConConsulta.GetChildRows("diagnosticos_primarios_con_consulta_ibfk_1").Single

                    '    Dim idDiagnosticoPrimarioConConsulta As Integer = rDiagnosticoPrimario("ID")
                    '    Dim fechaHoraDiagnosticoPrimarioConConsulta As Date = CType(rDiagnosticoPrimario("FECHA_HORA"), MySqlDateTime).Value
                    '    Dim comentariosAdicionalesDiagnosticosPrimariosConConsulta As String = rDiagnosticoPrimarioConConsulta("COMENTARIOS_ADICIONALES")

                    '    listaDiagnosticosAtendidosMedico.Add(
                    '        New DiagnosticoPrimarioConConsulta(idDiagnosticoPrimarioConConsulta, Nothing, Nothing, fechaHoraDiagnosticoPrimarioConConsulta,
                    '                                           Nothing, comentariosAdicionalesDiagnosticosPrimariosConConsulta))
                    'Next

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

                    Dim rMedico As DataRow = rDiagnosticoPrimarioConConsulta.GetParentRow("diagnosticos_primarios_con_consulta_ibfk_2")
                    Dim rFuncionario As DataRow = rMedico.GetParentRow("medicos_ibfk_1")
                    Dim rPersonaMedico As DataRow = rFuncionario.GetParentRow("funcionarios_ibfk_1")

                    Dim idMedico As Integer = rPersonaMedico("ID")
                    Dim ciMedico As String = rPersonaMedico("CI")
                    Dim nombreMedico As String = rPersonaMedico("NOMBRE")
                    Dim apellidoMedico As String = rPersonaMedico("APELLIDO")
                    Dim correoMedico As String = rPersonaMedico("CORREO")
                    Dim habilitadoMedico As Boolean = rFuncionario("HABILITADO")

                    Dim medicoDiagnosticoPrimarioConConsulta As _
                        New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, Nothing, Nothing, habilitadoMedico)

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

                    'Dim diagnosticosDiferencialesDiagnosticoPrimarioConConsulta As New List(Of DiagnosticoDiferencial)
                    'For Each rDiagnosticoDiferencial As DataRow In rDiagnosticoPrimarioConConsulta.GetParentRows("diagnosticos_diferenciales_ibfk_3")
                    '    Dim idDiagnosticoDiferencial As Integer = rDiagnosticoDiferencial("ID")
                    '    Dim conductaASeguirDiagnosticoDiferencial As String = rDiagnosticoDiferencial("CONDUCTA_A_SEGUIR")

                    '    diagnosticosDiferencialesDiagnosticoPrimarioConConsulta.Add(
                    '        New DiagnosticoDiferencial(idDiagnosticoDiferencial, Nothing, Nothing,
                    '                                   conductaASeguirDiagnosticoDiferencial))
                    'Next

                    'Dim mensajesDiagnosticoPrimarioConConsulta As New List(Of Mensaje)
                    'For Each rMensaje As DataRow In rDiagnosticoPrimarioConConsulta.GetParentRows("mensajes_ibfk_1")
                    '    Dim idMensaje As Integer = rMensaje("ID")
                    '    Dim fechaHoraMensaje As Date = CType(rMensaje("FECHAHORA"), MySqlDateTime).Value
                    '    Dim formatoMensaje As FormatosMensajeAdmitidos = [Enum].Parse(GetType(FormatosMensajeAdmitidos), rMensaje("TIPO"))
                    '    Dim contenidoMensaje() As Byte = rMensaje("CONTENIDO")
                    '    Dim remitenteMensaje As TiposRemitente = [Enum].Parse(GetType(TiposRemitente), rMensaje("REMITENTE"))

                    '    mensajesDiagnosticoPrimarioConConsulta.Add(
                    '        New Mensaje(idMensaje, fechaHoraMensaje, formatoMensaje, contenidoMensaje, remitenteMensaje, Nothing))
                    'Next

                    lista.Add(New DiagnosticoPrimarioConConsulta(
                              idDiagnosticoPrimarioConConsulta, pacienteDiagnosticoPrimarioConConsulta,
                              enfermedadesDiagnosticadasDiagnosticoPrimarioConConsulta, fechaHoraDiagnosticoPrimarioConConsulta,
                              medicoDiagnosticoPrimarioConConsulta, comentariosAdicionalesDiagnosticosPrimariosConConsulta))
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
                    Dim comando As String = "BEGIN;" & vbNewLine

                    comando &= String.Format("INSERT INTO diagnosticos_primarios (ID_PACIENTE, FECHA_HORA, TIPO) VALUES ({0},'{1}','{2}');" & vbNewLine,
                                             diagnosticoPrimario.Paciente.ID, diagnosticoPrimario.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"), diagnosticoPrimario.Tipo.ToString)
                    ConexionBD.EjecutarTransaccion(comando)
                    Dim idDiagnosticoPrimarioBD As Integer = ConexionBD.ObtenerUltimoIdInsertado

                    comando = ""
                    For i = 0 To diagnosticoPrimario.Enfermedades.Count - 1
                        comando &= String.Format("INSERT INTO sistema_diagnostica VALUES ({0},{1},{2});" & vbNewLine, idDiagnosticoPrimarioBD,
                                                 diagnosticoPrimario.Enfermedad(i).Id,
                                                 diagnosticoPrimario.Probabilidad(i).ToString.Replace(",", "."))
                    Next

                    'For Each e As Enfermedad In diagnosticoPrimario.Enfermedades
                    '    comando &= String.Format("INSERT INTO sistema_diagnostica VALUES ({0},{1},{2});" & vbNewLine,
                    '                              idDiagnosticoPrimarioBD, e.Id, e.Probabilidad.ToString.Replace(",", "."))
                    'Next

                    comando &= "COMMIT;"
                    ConexionBD.EjecutarTransaccion(comando)
                Catch ex As Exception
                    ConexionBD.EjecutarTransaccion("ROLLBACK;")
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.DiagnosticoDiferencial
                Dim diagnosticoDiferencial As DiagnosticoDiferencial = objetoAInsertar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("INSERT INTO diagnosticos_diferenciales (ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA, ID_ENFERMEDAD, CONDUCTA_A_SEGUIR) VALUES ({0},{1},'{2}');",
                                                       diagnosticoDiferencial.DiagnosticoPrimarioConConsulta.ID,
                                                       diagnosticoDiferencial.EnfermedadDiagnosticada.Id,
                                                       diagnosticoDiferencial.ConductaASeguir)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


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
                        Dim comando As String = String.Format("UPDATE enfermedades SET HABILITADO=TRUE, DESCRIPCION='{0}', RECOMENDACIONES='{1}', GRAVEDAD={2}, ID_ESPECIALIDAD={3} WHERE NOMBRE='{4}'",
                                                              enfermedad.Descripcion, enfermedad.Recomendaciones, enfermedad.Gravedad,
                                                              enfermedad.Especialidad.ID, enfermedad.Nombre)
                        ConexionBD.EjecutarTransaccion(comando)
                    Else        ' Jamás existió
                        Dim comando As String = "BEGIN;" & vbNewLine

                        comando &= String.Format("INSERT INTO enfermedades (NOMBRE, DESCRIPCION, RECOMENDACIONES, GRAVEDAD, ID_ESPECIALIDAD) VALUES ('{0}','{1}','{2}',{3},{4});",
                                                              enfermedad.Nombre, enfermedad.Descripcion, enfermedad.Recomendaciones, enfermedad.Gravedad,
                                                              enfermedad.Especialidad.ID)

                        ConexionBD.EjecutarTransaccion(comando)
                        Dim idEnfermedadBD As Integer = ConexionBD.ObtenerUltimoIdInsertado

                        comando = ""


                        'For Each s As Sintoma In enfermedad.ListaSintomas
                        '    comando &= String.Format("INSERT INTO cuadro_sintomatico VALUES ({0},{1},{2});" & vbNewLine,
                        '                             s.ID, idEnfermedadBD, s.Frecuencia.ToString.Replace(",", "."))
                        'Next
                        comando &= "COMMIT;"
                        ConexionBD.EjecutarTransaccion(comando)
                    End If

                Catch ex As Exception
                    ConexionBD.EjecutarTransaccion("ROLLBACK;")
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Especialidad
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
                    Dim comando As String = String.Format("UPDATE especialidades SET HABILITADO=TRUE WHERE NOMBRE='{0}'", especialidad.Nombre)
                    ConexionBD.EjecutarTransaccion(comando)
                Else
                    Dim comando As String = String.Format("INSERT INTO especialidades (NOMBRE) VALUES ('{0}');", especialidad.Nombre)
                    ConexionBD.EjecutarTransaccion(comando)
                End If
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Departamento
                Dim departamento As Departamento = objetoAInsertar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("INSERT INTO departamentos (NOMBRE) VALUES ('{0}');", departamento.Nombre)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Localidad
                Dim localidad As Localidad = objetoAInsertar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("INSERT INTO localidades (NOMBRE, ID_DEPARTAMENTO) VALUES ('{0}',{1})",
                                                      localidad.Nombre, localidad.Departamento.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Sintoma
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
                    Dim comando As String = String.Format("UPDATE sintomas SET HABILITADO=TRUE, DESCRIPCION='{0}', RECOMENDACIONES='{1}', URGENCIA={2} WHERE NOMBRE='{3}'",
                                                          sintoma.Descripcion, sintoma.Recomendaciones, sintoma.Urgencia, sintoma.Nombre)
                    ConexionBD.EjecutarTransaccion(comando)
                Else
                    Dim comando As String = String.Format("INSERT INTO sintomas (NOMBRE, DESCRIPCION, RECOMENDACIONES, URGENCIA) VALUES ('{0}','{1}','{2}',{3});",
                                                       sintoma.Nombre, sintoma.Descripcion, sintoma.Recomendaciones, sintoma.Urgencia)
                    ConexionBD.EjecutarTransaccion(comando)
                End If
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Usuario
                Dim usuario As Usuario = objetoAInsertar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("INSERT INTO usuarios (CONTRASENIA, TIPO, ID_PERSONA) VALUES ('{0}','{1}',{2});",
                                                       usuario.Contrasena, usuario.Tipo.ToString, usuario.Persona.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Mensaje
                Dim mensaje As Mensaje = objetoAInsertar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("INSERT INTO mensajes (FECHAHORA, FORMATO, CONTENIDO, REMITENTE, ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA) VALUES ('{0}','{1}','{2}','{3}',{4});",
                                                       mensaje.FechaHora, mensaje.Formato, mensaje.Contenido, mensaje.Remitente,
                                                       mensaje.DiagnosticoPrimarioConConsulta.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Administrativo
                Try
                    Dim administrativo As Administrativo = objetoAInsertar
                    ConexionBD.Conexion.Open()

                    Dim estaDeshabilitado As Boolean = False
                    For Each a As Administrativo In ObtenerListadoCompleto(TiposObjeto.Administrativo)
                        If a.CI = administrativo.CI And a.Habilitado = False Then
                            estaDeshabilitado = True
                        End If
                    Next

                    If estaDeshabilitado Then
                        Dim comando As String = "BEGIN;" & vbNewLine
                        comando &= String.Format("UPDATE personas SET CI='{0}', NOMBRE='{1}', APELLIDO='{2}', CORREO='{3}', ID_LOCALIDAD={4}, TIPO='{5}' WHERE ID={6};" & vbNewLine,
                                                  administrativo.CI, administrativo.Nombre, administrativo.Apellido, administrativo.Correo,
                                                  administrativo.Localidad.ID, administrativo.Tipo, administrativo.ID)
                        comando &= String.Format("UPDATE funcionarios SET HABILITADO=TRUE WHERE ID_PERSONA={0};" & vbNewLine, administrativo.ID)
                        comando &= String.Format("UPDATE administrativos SET ES_ENCARGADO={0};", administrativo.EsEncargado)
                        comando &= "COMMIT;"
                        ConexionBD.EjecutarTransaccion(comando)
                    Else
                        Dim comando As String = "BEGIN;" & vbNewLine
                        comando = String.Format("INSERT INTO personas (CI, NOMBRE, APELLIDO, CORREO, ID_LOCALIDAD, TIPO) VALUES ('{0}','{1}','{2}','{3}',{4},'{5}');",
                                                administrativo.CI, administrativo.Nombre, administrativo.Apellido, administrativo.Correo,
                                                administrativo.Localidad.ID, administrativo.Tipo.ToString)
                        ConexionBD.EjecutarTransaccion(comando)
                        Dim idAdministrativoBD As Integer = ConexionBD.ObtenerUltimoIdInsertado

                        comando = String.Format("INSERT INTO funcionarios VALUES ({0},'{1}');", idAdministrativoBD, TiposFuncionario.Administrativo.ToString)
                        ConexionBD.EjecutarTransaccion(comando)

                        comando = String.Format("INSERT INTO administrativos VALUES ({0},{1});", idAdministrativoBD, administrativo.EsEncargado)
                        comando &= "COMMIT;"
                        ConexionBD.EjecutarTransaccion(comando)
                    End If

                Catch ex As Exception
                    ConexionBD.EjecutarTransaccion("ROLLBACK;")
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Paciente
                Try
                    Dim paciente As Paciente = objetoAInsertar
                    ConexionBD.Conexion.Open()
                    Dim comando As String = "BEGIN;" & vbNewLine
                    comando = String.Format("INSERT INTO personas (CI, NOMBRE, APELLIDO, CORREO, ID_LOCALIDAD, TIPO) VALUES ('{0}','{1}','{2}','{3}',{4},'{5}');",
                                            paciente.CI, paciente.Nombre, paciente.Apellido, paciente.Correo, paciente.Localidad.ID, paciente.Tipo.ToString)
                    ConexionBD.EjecutarTransaccion(comando)
                    Dim idPacienteBD As Integer = ConexionBD.ObtenerUltimoIdInsertado

                    comando = String.Format("INSERT INTO pacientes VALUES ({0},'{1}','{2}','{3}','{4}','{5}','{6}',{7});",
                                            idPacienteBD, paciente.TelefonoMovil, paciente.TelefonoFijo, paciente.Sexo.ToString,
                                            paciente.FechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss"), paciente.Calle, paciente.NumeroPuerta,
                                            paciente.Apartamento)
                    comando &= "COMMIT;"
                    ConexionBD.EjecutarTransaccion(comando)
                Catch ex As Exception
                    ConexionBD.EjecutarTransaccion("ROLLBACK;")
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
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
                        Dim comando As String = "BEGIN;" & vbNewLine
                        comando &= String.Format("UPDATE personas SET CI='{0}', NOMBRE='{1}', APELLIDO='{2}', CORREO='{3}', ID_LOCALIDAD={4}, TIPO='{5}' WHERE ID={6};" & vbNewLine,
                                                  medico.CI, medico.Nombre, medico.Apellido, medico.Correo, medico.Localidad.ID, medico.Tipo, medico.ID)
                        comando &= String.Format("UPDATE funciontaios SET HABILITADO=TRUE WHERE ID={0};" & vbNewLine, medico.ID)
                        ConexionBD.EjecutarTransaccion(comando)
                    Else
                        Dim comando As String = "BEGIN;" & vbNewLine
                        comando = String.Format("INSERT INTO personas (CI, NOMBRE, APELLIDO, CORREO, ID_LOCALIDAD, TIPO) VALUES ('{0}','{1}','{2}','{3}',{4},'{5}');",
                                                medico.CI, medico.Nombre, medico.Apellido, medico.Correo, medico.Localidad.ID, medico.Tipo.ToString)
                        ConexionBD.EjecutarTransaccion(comando)
                        Dim idMedicoBD As Integer = ConexionBD.ObtenerUltimoIdInsertado

                        comando = String.Format("INSERT INTO funcionarios VALUES ({0},'{1}');", idMedicoBD, TiposFuncionario.Medico.ToString)
                        ConexionBD.EjecutarTransaccion(comando)

                        comando = String.Format("INSERT INTO medicos VALUES ({0});", idMedicoBD)
                        comando &= "COMMIT;"
                        ConexionBD.EjecutarTransaccion(comando)
                    End If

                Catch ex As Exception
                    ConexionBD.EjecutarTransaccion("ROLLBACK;")
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.DiagnosticoPrimarioConConsulta
                Try
                    Dim diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta = objetoAInsertar
                    ConexionBD.Conexion.Open()
                    Dim comando As String = "BEGIN;" & vbNewLine
                    comando = String.Format("INSERT INTO diagnosticos_primarios_con_consulta VALUES ({0},{1},'{2}');",
                                             diagnosticoPrimarioConConsulta.ID, diagnosticoPrimarioConConsulta.Medico.ID,
                                             diagnosticoPrimarioConConsulta.ComentariosAdicionales)
                    ConexionBD.EjecutarTransaccion(comando)

                    comando = String.Format("UPDATE diagnosticos_primarios SET TIPO='Con_Consulta' WHERE ID={0};", diagnosticoPrimarioConConsulta.ID)
                    comando &= "COMMIT;"
                    ConexionBD.EjecutarTransaccion(comando)
                Catch ex As Exception
                    ConexionBD.EjecutarTransaccion("ROLLBACK;")
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
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
    Private Sub EliminarObjeto(objetoAEliminar As Object, entidad As TiposObjeto)
        Select Case entidad
            Case TiposObjeto.Enfermedad
                Dim enfermedad As Enfermedad = objetoAEliminar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("UPDATE enfermedades SET HABILITADO=FALSE WHERE ID={0}", enfermedad.Id)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Especialidad
                Dim especialidad As Especialidad = objetoAEliminar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("UPDATE especialidades SET HABILITADO=FALSE WHERE ID={0}", especialidad.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Departamento
                Dim departamento As Departamento = objetoAEliminar
                Try
                    ConexionBD.Conexion.Open()
                    Dim comando As String = String.Format("DELETE FROM departamentos WHERE ID={0}", departamento.ID)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Localidad
                Dim localidad As Localidad = objetoAEliminar
                Try
                    ConexionBD.Conexion.Open()
                    Dim comando As String = String.Format("DELETE FROM localidades WHERE ID={0}", localidad.ID)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Sintoma
                Dim sintoma As Sintoma = objetoAEliminar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("UPDATE sintomas SET HABILITADO=FALSE WHERE ID={0}", sintoma.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Usuario
                Dim usuario As Usuario = objetoAEliminar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("UPDATE usuarios SET HABILITADO=FALSE WHERE ID={0}", usuario.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Administrativo
                Dim administrativo As Administrativo = objetoAEliminar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("UPDATE funcionarios SET HABILITADO=FALSE WHERE ID_PERSONA={0}", administrativo.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Paciente
                Try
                    Dim paciente As Paciente = objetoAEliminar
                    ConexionBD.Conexion.Open()
                    Dim comando As String = "BEGIN;" & vbNewLine                                                ' Se considera una transacción porque la BD
                    comando = String.Format("DELETE FROM personas WHERE ID={0};" & vbNewLine, paciente.ID)      ' se configura para permitir que los datos
                    comando &= "COMMIT;"                                                                        ' relacionados se eliminen en cascada
                    ConexionBD.EjecutarTransaccion(comando)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Medico
                Dim medico As Medico = objetoAEliminar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("UPDATE funcionarios SET HABILITADO=FALSE WHERE ID_PERSONA={0}", medico.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()
        End Select
    End Sub

    ' Modifica un objeto en las tablas correspondientes de acuerdo al parámetro "entidad" mediante sentencias SQL.
    ' Cuando la operación requiere más de un comando, dichos comandos se encuentran encapsulados por BEGIN, COMMIT y ROLLBACK en un bloque Try/Catch.
    Private Sub ModificarObjeto(objetoAModificar As Object, entidad As TiposObjeto)
        Select Case entidad
            Case TiposObjeto.Enfermedad
                Try
                    Dim enfermedad As Enfermedad = objetoAModificar
                    ConexionBD.Conexion.Open()
                    Dim comando As String = "BEGIN;" & vbNewLine
                    comando &= String.Format("UPDATE enfermedades SET NOMBRE='{0}' DESCRIPCION='{1}', RECOMENDACIONES='{2}', GRAVEDAD={3}, ID_ESPECIALIDAD={4} WHERE ID={5};",
                                              enfermedad.Nombre, enfermedad.Descripcion, enfermedad.Recomendaciones, enfermedad.Gravedad,
                                              enfermedad.Especialidad.ID, enfermedad.Id)
                    ConexionBD.EjecutarTransaccion(comando)

                    comando = String.Format("DELETE FROM cuadro_sintomatico WHERE ID_ENFERMEDAD={0};", enfermedad.Id)
                    ConexionBD.EjecutarTransaccion(comando)

                    comando = ""
                    For i = 0 To enfermedad.Sintomas.Count - 1
                        comando &= String.Format("INSERT INTO cuadro_sintomatico VALUES ({0},{1},{2});" & vbNewLine,
                                                 enfermedad.Sintomas(i).ID, enfermedad.Id, enfermedad.FrecuenciaSintoma(i).ToString.Replace(",", "."))
                    Next
                    comando &= "COMMIT;"
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As Exception
                    ConexionBD.EjecutarTransaccion("ROLLBACK;")
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Especialidad
                Dim especialidad As Especialidad = objetoAModificar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("UPDATE especialidades SET NOMBRE='{0}' WHERE ID={1}", especialidad.Nombre, especialidad.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Departamento
                Dim departamento As Departamento = objetoAModificar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("UPDATE departamentos SET NOMBRE='{0}' WHERE ID={1}", departamento.Nombre, departamento.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Localidad
                Dim localidad As Localidad = objetoAModificar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("UPDATE localidades SET NOMBRE='{0}', ID_DEPARTAMENTO={1} WHERE ID={2}",
                                                      localidad.Nombre, localidad.Departamento.ID, localidad.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()


            Case TiposObjeto.Sintoma
                Try
                    Dim sintoma As Sintoma = objetoAModificar
                    ConexionBD.Conexion.Open()
                    Dim comando As String = String.Format("UPDATE sintomas SET NOMBRE='{0}', DESCRIPCION='{1}', RECOMENDACIONES='{2}', URGENCIA={3} WHERE ID={4}",
                                                          sintoma.Nombre, sintoma.Descripcion, sintoma.Recomendaciones, sintoma.Urgencia, sintoma.ID)
                    ConexionBD.EjecutarTransaccion(comando)

                    comando = String.Format("DELETE FROM cuadro_sintomatico WHERE ID_SINTOMA={0};", sintoma.ID)
                    ConexionBD.EjecutarTransaccion(comando)

                    comando = ""
                    For i = 0 To sintoma.Enfermedades.Count - 1
                        comando &= String.Format("INSERT INTO cuadro_sintomatico VALUES ({0},{1},{2});" & vbNewLine,
                                                 sintoma.ID, sintoma.Enfermedades(i).Id, sintoma.FrecuenciaEnfermedad(i).ToString.Replace(",", "."))
                    Next
                    comando &= "COMMIT;"
                    ConexionBD.EjecutarTransaccion(comando)
                Catch ex As Exception
                    ConexionBD.EjecutarTransaccion("ROLLBACK;")
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Administrativo
                Try
                    Dim administrativo As Administrativo = objetoAModificar
                    ConexionBD.Conexion.Open()

                    Dim comando As String = "BEGIN;" & vbNewLine
                    comando &= String.Format("UPDATE personas SET CI='{0}', NOMBRE='{1}', APELLIDO='{2}', CORREO='{3}', ID_LOCALIDAD={4}, TIPO='{5}', WHERE ID={6};" & vbNewLine,
                                             administrativo.CI, administrativo.Nombre, administrativo.Apellido, administrativo.Correo,
                                             administrativo.Localidad.ID, administrativo.Tipo, administrativo.ID)
                    comando &= String.Format("UPDATE administrativos SET ES_ENCARGADO={0} WHERE ID_FUNCIONARIO={1};",
                                            administrativo.EsEncargado, administrativo.ID)
                    comando &= "COMMIT;"
                    ConexionBD.EjecutarTransaccion(comando)

                Catch ex As Exception
                    ConexionBD.EjecutarTransaccion("ROLLBACK;")
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Paciente
                Try
                    Dim paciente As Paciente = objetoAModificar
                    ConexionBD.Conexion.Open()
                    Dim comando As String = "BEGIN;" & vbNewLine
                    comando &= String.Format("UPDATE personas SET CI='{0}', NOMBRE='{1}', APELLIDO='{2}', CORREO='{3}', ID_LOCALIDAD={4}, TIPO='{5}', WHERE ID={6};" & vbNewLine,
                                              paciente.CI, paciente.Nombre, paciente.Apellido, paciente.Correo, paciente.Localidad.ID, paciente.Tipo,
                                              paciente.ID)
                    comando &= String.Format("UPDATE pacientes SET TELEFONOMOVIL='{0}', TELEFONOFIJO='{1}', SEXO='{2}', FECHANACIMIENTO='{3}', CALLE='{4}', NUMEROPUERTA='{5}', APARTAMENTO={6} WHERE ID_PERSONA={7};",
                                              paciente.TelefonoMovil, paciente.TelefonoFijo, paciente.Sexo.ToString,
                                              paciente.FechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss"), paciente.Calle, paciente.NumeroPuerta,
                                              paciente.Apartamento, paciente.ID)
                    comando &= "COMMIT;"
                    ConexionBD.EjecutarTransaccion(comando)
                Catch ex As Exception
                    ConexionBD.EjecutarTransaccion("ROLLBACK;")
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
                Finally
                    If ConexionBD.Conexion.State = ConnectionState.Open Then
                        ConexionBD.Conexion.Close()
                    End If
                End Try


            Case TiposObjeto.Medico
                Dim medico As Medico = objetoAModificar
                ConexionBD.Conexion.Open()
                Dim comando As String = String.Format("UPDATE personas SET CI='{0}', NOMBRE='{1}', APELLIDO='{2}', CORREO='{3}', ID_LOCALIDAD={4}, TIPO='{5}', WHERE ID={6};" & vbNewLine,
                                                       medico.CI, medico.Nombre, medico.Apellido, medico.Correo, medico.Localidad.ID, medico.Tipo, medico.ID)
                ConexionBD.EjecutarTransaccion(comando)
                ConexionBD.Conexion.Close()
        End Select
    End Sub

    Public Function TienePersonaRegistrada(ci As String, tipo As TiposPersona) As Boolean
        Dim cantidadUsuarios As Integer = ConexionBD.EjecutarConsulta(String.Format("SELECT COUNT(*) FROM personas WHERE CI='{0}' AND TIPO='{1}'", ci, tipo.ToString), "usuarios").Rows(0)(0)
        Return cantidadUsuarios = 1
    End Function

    Public Function ObtenerMedicoPorCI(ci As String) As Medico
        Dim rPersona As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM personas WHERE CI='{0}' AND TIPO='Funcionario'", ci), "personas").Rows(0)
        Dim idMedico As Integer = rPersona("ID")
        Dim ciMedico As String = rPersona("CI")
        Dim nombreMedico As String = rPersona("NOMBRE")
        Dim apellidoMedico As String = rPersona("APELLIDO")
        Dim correoMedico As String = rPersona("CORREO")

        Dim rFuncionario As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM funcionarios WHERE ID_PERSONA={0}", idMedico), "funcionarios").Rows(0)
        Dim habilitadoMedico As Boolean = rFuncionario("HABILITADO")

        Dim rLocalidad As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM localidades WHERE ID={0}", rPersona("ID_LOCALIDAD")), "localidades").Rows(0)
        Dim idLocalidad As Integer = rLocalidad("ID")
        Dim nombreLocalidad As String = rLocalidad("NOMBRE")

        Dim rDepartamento As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM departamentos WHERE ID={0}", rLocalidad("ID_DEPARTAMENTO")), "departamentos").Rows(0)
        Dim idDepartamento As Integer = rDepartamento("ID")
        Dim nombreDepartamento As String = rDepartamento("NOMBRE")
        Dim departamentoLocalidad As New Departamento(idDepartamento, nombreDepartamento)

        Dim localidadMedico As New Localidad(idLocalidad, nombreLocalidad, departamentoLocalidad)

        Dim especialidadesMedico As New List(Of Especialidad)
        For Each rEspecialidadesMedico As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM especialidades_medicos WHERE ID_MEDICO={0}", idMedico), "especialidades_medicos").Rows
            Dim idEspecialidad As Integer = rEspecialidadesMedico("ID_ESPECIALIDAD")
            Dim rEspecialidad As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM especialidades WHERE ID={0}", idEspecialidad), "especialidades").Rows(0)
            Dim nombreEspecialidad As String = rEspecialidad("NOMBRE")
            Dim habilitadoEspecialidad As Boolean = rEspecialidad("HABILITADO")

            especialidadesMedico.Add(New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad))
        Next

        Dim medico As New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, localidadMedico, especialidadesMedico, habilitadoMedico)
        Return medico
    End Function

    Public Function ObtenerPacientePorCI(ci As String) As Paciente
        Dim rPersona As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM personas WHERE CI='{0}' AND TIPO='Paciente'", ci), "personas").Rows(0)
        Dim idPaciente As Integer = rPersona("ID")
        Dim ciPaciente As String = rPersona("CI")
        Dim nombrePaciente As String = rPersona("NOMBRE")
        Dim apellidoPaciente As String = rPersona("APELLIDO")
        Dim correoPaciente As String = rPersona("CORREO")

        Dim rPaciente As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM pacientes WHERE ID_PERSONA={0}", idPaciente), "pacientes").Rows(0)
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

        Dim rLocalidad As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM localidades WHERE ID={0}", rPersona("ID_LOCALIDAD")), "localidades").Rows(0)
        Dim idLocalidad As Integer = rLocalidad("ID")
        Dim nombreLocalidad As String = rLocalidad("NOMBRE")

        Dim rDepartamento As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM departamentos WHERE ID={0}", rLocalidad("ID_DEPARTAMENTO")), "departamentos").Rows(0)
        Dim idDepartamento As Integer = rDepartamento("ID")
        Dim nombreDepartamento As String = rDepartamento("NOMBRE")
        Dim departamentoLocalidad As New Departamento(idDepartamento, nombreDepartamento)

        Dim localidadPaciente As New Localidad(idLocalidad, nombreLocalidad, departamentoLocalidad)

        Dim paciente As New Paciente(idPaciente, ciPaciente, nombrePaciente, apellidoPaciente, correoPaciente, localidadPaciente,
                                            telefonoMovilPaciente, telefonoFijoPaciente, sexoPaciente, fechaNacimientoPaciente, callePaciente,
                                            numeroPuertaPaciente, apartamentoPaciente)

        Return paciente
    End Function

    Public Function ObtenerAdministrativoPorCI(ci As String) As Administrativo
        Dim rPersona As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM personas WHERE CI='{0}' AND TIPO='Funcionario'", ci), "personas").Rows(0)
        Dim idAdministrativo As Integer = rPersona("ID")
        Dim ciAdministrativo As String = rPersona("CI")
        Dim nombreAdministrativo As String = rPersona("NOMBRE")
        Dim apellidoAdministrativo As String = rPersona("APELLIDO")
        Dim correoAdministrativo As String = rPersona("CORREO")

        Dim rFuncionario As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM funcionarios WHERE ID_PERSONA='{0}'", idAdministrativo), "funcionarios").Rows(0)
        Dim habilitadoAdministrativo As Boolean = rFuncionario("HABILITADO")

        Dim rAdministrativo As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM administrativos WHERE ID_FUNCIONARIO='{0}'", idAdministrativo), "administrativos").Rows(0)
        Dim esEncargadoAdministrativo As Boolean = rAdministrativo("ES_ENCARGADO")

        Dim rLocalidad As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM localidades WHERE ID={0}", rPersona("ID_LOCALIDAD")), "localidades").Rows(0)
        Dim idLocalidad As Integer = rLocalidad("ID")
        Dim nombreLocalidad As String = rLocalidad("NOMBRE")

        Dim rDepartamento As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM departamentos WHERE ID={0}", rLocalidad("ID_DEPARTAMENTO")), "departamentos").Rows(0)
        Dim idDepartamento As Integer = rDepartamento("ID")
        Dim nombreDepartamento As String = rDepartamento("NOMBRE")
        Dim departamentoLocalidad As New Departamento(idDepartamento, nombreDepartamento)

        Dim localidadAdministrativo As New Localidad(idLocalidad, nombreLocalidad, departamentoLocalidad)

        Dim administrativo As New Administrativo(idAdministrativo, ciAdministrativo, nombreAdministrativo, apellidoAdministrativo,
                                                        correoAdministrativo, localidadAdministrativo, esEncargadoAdministrativo, habilitadoAdministrativo)

        Return administrativo
    End Function

    Public Function TieneUsuarioRegistrado(persona As Persona) As Boolean
        Dim cantidadUsuarios As Integer = ConexionBD.EjecutarConsulta(String.Format("SELECT COUNT(*) FROM usuarios WHERE ID_PERSONA={0} ", persona.ID), "usuarios").Rows(0)(0)
        Return cantidadUsuarios = 1
    End Function

    Public Function ObtenerUsuarioPorPersona(persona As Persona) As Usuario
        Dim rUsuario As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM usuarios WHERE ID_PERSONA='{0}'", persona.ID), "usuarios").Rows(0)
        Dim idUsuario As Integer = rUsuario("ID")
        Dim contrasenaUsuario As String = rUsuario("CONTRASENIA")
        Dim habilitadoUsuario As Boolean = rUsuario("HABILITADO")
        Dim usuario As New Usuario(idUsuario, contrasenaUsuario, persona, habilitadoUsuario)
        Return usuario
    End Function

    Public Function ObtenerDiagnosticosPrimariosPorPaciente(paciente As Paciente) As List(Of DiagnosticoPrimario)
        Dim lista As New List(Of DiagnosticoPrimario)
        For Each rDiagnosticoPrimario As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM diagnosticos_primarios WHERE ID_PACIENTE={0}", paciente.ID), "diagnosticos_primarios").Rows
            Dim idDiagnosticoPrimario As Integer = rDiagnosticoPrimario("ID")
            Dim fechaHoraDiagnosticoPrimario As Date = CType(rDiagnosticoPrimario("FECHA_HORA"), MySqlDateTime).Value
            Dim tipoDiagnosticoPrimario As TiposDiagnosticosPrimarios = [Enum].Parse(GetType(TiposDiagnosticosPrimarios), rDiagnosticoPrimario("TIPO"))

            Dim enfermedadesDiagnosticoPrimario As New List(Of Enfermedad)
            Dim probabilidadesEnfermedades As New List(Of Decimal)
            For Each rSistemaDiagnostica As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM sistema_diagnostica WHERE ID_DIAGNOSTICO_PRIMARIO={0}", idDiagnosticoPrimario), "sistema_diagnostica").Rows
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

                enfermedadesDiagnosticoPrimario.Add(New Enfermedad(idEnfermedad, nombreEnfermedad, recomendacionesEnfermedad, gravedadEnfermedad,
                                                                    descripcionEnfermedad, Nothing, especialidadEnfermedad, habilitadoEnfermedad))
                probabilidadesEnfermedades.Add(rSistemaDiagnostica("PROBABILIDAD"))
            Next
            Dim enfermedadesDiagnosticadas As New EnfermedadesDiagnosticadas(enfermedadesDiagnosticoPrimario, probabilidadesEnfermedades)

            Select Case tipoDiagnosticoPrimario
                Case TiposDiagnosticosPrimarios.Sin_Consulta
                    lista.Add(New DiagnosticoPrimario(idDiagnosticoPrimario, paciente, enfermedadesDiagnosticadas, fechaHoraDiagnosticoPrimario, tipoDiagnosticoPrimario))

                Case TiposDiagnosticosPrimarios.Con_Consulta
                    Dim rDiagnosticoPrimarioConConsulta As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM diagnosticos_primarios_con_consulta WHERE ID_DIAGNOSTICO_PRIMARIO={0}", idDiagnosticoPrimario), "diagnosticos_primarios_con_consulta").Rows(0)
                    Dim comentariosAdicionalesDiagnosticoPrimarioConConsulta As String = rDiagnosticoPrimarioConConsulta("COMENTARIOS_ADICIONALES")
                    Dim idMedico As Integer = rDiagnosticoPrimarioConConsulta("ID_MEDICO")
                    Dim rMedico As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM medicos WHERE ID_FUNCIONARIO={0}", idDiagnosticoPrimario), "medicos").Rows(0)

                    Dim especialidadesMedico As New List(Of Especialidad)
                    For Each rEspecialidadesMedico As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM especialidades_medicos WHERE ID_MEDICO={0}", idMedico), "especialidades_medicos").Rows
                        Dim idEspecialidad As Integer = rEspecialidadesMedico("ID_ESPECIALIDAD")
                        Dim rEspecialidad As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM especialidades WHERE ID={0}", idEspecialidad), "especialidades").Rows(0)
                        Dim nombreEspecialidad As String = rEspecialidad("NOMBRE")
                        Dim habilitadoEspecialidad As Boolean = rEspecialidad("HABILITADO")

                        especialidadesMedico.Add(New Especialidad(idEspecialidad, nombreEspecialidad, Nothing, habilitadoEspecialidad))
                    Next

                    Dim rFuncionario As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM funcionarios WHERE ID_PERSONA={0}", idMedico), "funcionarios").Rows(0)
                    Dim habilitadoMedico As Boolean = rFuncionario("HABILITADO")

                    Dim rPersona As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM personas WHERE ID={0}", idMedico), "personas").Rows(0)
                    Dim ciMedico As String = rPersona("CI")
                    Dim nombreMedico As String = rPersona("NOMBRE")
                    Dim apellidoMedico As String = rPersona("APELLIDO")
                    Dim correoMedico As String = rPersona("CORREO")

                    Dim medicoDiagnosticoPrimarioConConsulta As New Medico(idMedico, ciMedico, nombreMedico, apellidoMedico, correoMedico, Nothing,
                                                                           especialidadesMedico, habilitadoMedico)

                    lista.Add(New DiagnosticoPrimarioConConsulta(idDiagnosticoPrimario, paciente, enfermedadesDiagnosticadas, fechaHoraDiagnosticoPrimario,
                                                                 medicoDiagnosticoPrimarioConConsulta, comentariosAdicionalesDiagnosticoPrimarioConConsulta))
            End Select
        Next
        Return lista
    End Function

    Public Function ObtenerDiagnosticosPrimariosConConsultaPorMedico(medico As Medico) As List(Of DiagnosticoPrimarioConConsulta)
        Dim lista As New List(Of DiagnosticoPrimarioConConsulta)
        For Each rDiagnosticoPrimarioConConsulta As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM diagnosticos_primarios_con_consulta WHERE ID_MEDICO={0}", medico.ID), "diagnosticos_primarios_con_consulta").Rows
            Dim idDiagnosticoPrimarioConConsulta As Integer = rDiagnosticoPrimarioConConsulta("ID_DIAGNOSTICO_PRIMARIO")
            Dim comentariosAdicionalesDiagnosticoPrimarioConConsulta As String = rDiagnosticoPrimarioConConsulta("COMENTARIOS_ADICIONALES")
            Dim rDiagnosticoPrimario As DataRow = ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM diagnosticos_primarios WHERE ID={0}", idDiagnosticoPrimarioConConsulta), "diagnosticos_primarios").Rows(0)
            Dim fechaHoraDiagnosticoPrimarioConConsulta As Date = CType(rDiagnosticoPrimario("FECHA_HORA"), MySqlDateTime).Value
            Dim tipoDiagnosticoPrimario As TiposDiagnosticosPrimarios = [Enum].Parse(GetType(TiposDiagnosticosPrimarios), rDiagnosticoPrimario("TIPO"))

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
                                                         enfermedadesDiagnosticadas, fechaHoraDiagnosticoPrimarioConConsulta, medico,
                                                         comentariosAdicionalesDiagnosticoPrimarioConConsulta))
        Next
        Return lista
    End Function

    Public Function ObtenerUltimosMensajesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta, cantidad As Integer) As List(Of Mensaje)
        Dim lista As New List(Of Mensaje)
        For Each rMensaje As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM mensajes WHERE ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA={0} ORDER BY FECHAHORA DESC LIMIT {1}", diagnosticoPrimarioConConsulta.ID, cantidad), "especialidades").Rows
            Dim idMensaje As Integer = rMensaje("ID")
            Dim fechaHoraMensaje As Date = CType(rMensaje("FECHAHORA"), MySqlDateTime).Value
            Dim formatoMensaje As FormatosMensajeAdmitidos = [Enum].Parse(GetType(FormatosMensajeAdmitidos), rMensaje("FORMATO"))
            Dim contenidoMensaje() As Byte = rMensaje("CONTENIDO")
            Dim remitenteMensaje As TiposRemitente = [Enum].Parse(GetType(TiposRemitente), rMensaje("REMITENTE"))

            lista.Add(New Mensaje(idMensaje, fechaHoraMensaje, formatoMensaje, contenidoMensaje, remitenteMensaje, diagnosticoPrimarioConConsulta))
        Next
        Return lista
    End Function

    Public Function ObtenerDiagnosticosDiferencialesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta) As List(Of DiagnosticoDiferencial)
        Dim lista As New List(Of DiagnosticoDiferencial)
        For Each rDiagnosticoDiferencial As DataRow In ConexionBD.EjecutarConsulta(String.Format("SELECT * FROM diagnosticos_diferenciales WHERE ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA={0}", diagnosticoPrimarioConConsulta.ID), "diagnosticos_diferenciales").Rows
            Dim idDiagnosticoDiferencial As Integer = rDiagnosticoDiferencial("ID")
            Dim conductaASeguirDiagnosticoDiferencial As String = rDiagnosticoDiferencial("CONDUCTA_A_SEGUIR")

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
                                                 conductaASeguirDiagnosticoDiferencial))
        Next
        Return lista
    End Function

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
