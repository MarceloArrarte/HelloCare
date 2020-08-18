Imports Clases
Imports CapaPersistencia
Imports System.CodeDom
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Module Principal
    Public Function AutenticarUsuarioPaciente(ci As String, contrasena As String) As ResultadosLogin
        If Not TienePersonaRegistrada(ci, TiposPersona.Paciente) Then
            Return ResultadosLogin.Error
        End If

        Dim paciente As Paciente = ObtenerPacientePorCI(ci)
        If Not TieneUsuarioRegistrado(paciente) Then
            Return ResultadosLogin.SinUsuario
        End If

        Dim usuarioPaciente As Usuario = ObtenerUsuarioPorPersona(paciente)
        If contrasena = usuarioPaciente.Contrasena Then
            pacienteLogeado = paciente
            Return ResultadosLogin.OK
        Else
            Return ResultadosLogin.Error
        End If
    End Function

    Public Function AutenticarUsuarioMedico(ci As String, contrasena As String) As ResultadosLogin
        If Not TienePersonaRegistrada(ci, TiposPersona.Funcionario) Then
            Return ResultadosLogin.Error
        End If

        Dim medico As Medico = ObtenerMedicoPorCI(ci)

        If Not TieneUsuarioRegistrado(medico) Then
            Return ResultadosLogin.SinUsuario
        End If

        Dim usuarioMedico As Usuario = ObtenerUsuarioPorPersona(medico)
        If contrasena = usuarioMedico.Contrasena Then
            medicoLogeado = medico
            Return ResultadosLogin.OK
        Else
            Return ResultadosLogin.Error
        End If
    End Function

    Public Function AutenticarUsuarioAdministrativo(ci As String, contrasena As String) As ResultadosLogin
        If Not TienePersonaRegistrada(ci, TiposPersona.Funcionario) Then
            Return ResultadosLogin.Error
        End If

        Dim administrativo As Administrativo = ObtenerAdministrativoPorCI(ci)

        If Not TieneUsuarioRegistrado(administrativo) Then
            Return ResultadosLogin.SinUsuario
        End If

        Dim usuarioAdministrativo As Usuario = ObtenerUsuarioPorPersona(administrativo)
        If contrasena = usuarioAdministrativo.Contrasena Then
            administrativoLogeado = administrativo
            Return ResultadosLogin.OK
        Else
            Return ResultadosLogin.Error
        End If
    End Function

    Public Function CargarTodosLosSintomas() As List(Of Sintoma)
        Dim listaBase As List(Of Object) = ObtenerListadoCompleto(TiposObjeto.Sintoma)
        Dim listaConvertida As New List(Of Sintoma)
        For Each s As Sintoma In listaBase
            listaConvertida.Add(s)
        Next
        Return listaConvertida
    End Function

    Public Function CargarTodasLasEnfermedades() As List(Of Enfermedad)
        Dim listaBase As List(Of Object) = ObtenerListadoCompleto(TiposObjeto.Enfermedad)
        Dim listaConvertida As New List(Of Enfermedad)
        For Each e As Enfermedad In listaBase
            listaConvertida.Add(e)
        Next
        Return listaConvertida
    End Function

    Public Function CargarTodasLasEspecialidades() As List(Of Especialidad)
        Dim listaBase As List(Of Object) = ObtenerListadoCompleto(TiposObjeto.Especialidad)
        Dim listaConvertida As New List(Of Especialidad)
        For Each e As Especialidad In listaBase
            listaConvertida.Add(e)
        Next
        Return listaConvertida
    End Function

    Public Function DuplicarFila(filaADuplicar As DataGridViewRow) As DataGridViewRow
        Dim nuevaFila As DataGridViewRow = filaADuplicar.Clone
        For i = 0 To filaADuplicar.Cells.Count - 1
            nuevaFila.Cells(i).Value = filaADuplicar.Cells(0).Value
        Next
        Return nuevaFila
    End Function

    Public Function RealizarDiagnostico(sintomasIngresados As List(Of Sintoma), ByRef enfermedadesDiagnosticadas As EnfermedadesDiagnosticadas,
                                        ByRef certeza As Decimal) As Enfermedad

        Dim listaEnfermedadesPosibles As New List(Of Enfermedad)
        Dim listaProbabilidades As New List(Of Decimal)
        Dim enfermedadMasProbable As Enfermedad = Nothing

        For Each e As Enfermedad In CargarTodasLasEnfermedades()
            'Dim porcentajeSintomasCoincidentes As Decimal
            Dim porcentajeProbabilidad As Decimal = DeterminarProbabilidadEnfermedad(sintomasIngresados, e)

            'Dim cantidadSintomasExistentes As Integer = e.Sintomas.Count
            'Dim cantidadSintomasCoincidentes As Integer = 0
            'Dim listaFrecuencias As New List(Of Decimal)
            'For i = 0 To cantidadSintomasExistentes
            '    If sintomasIngresados.Contains(e.Sintomas(i)) Then
            '        cantidadSintomasCoincidentes += 1
            '        listaFrecuencias.Add(e.FrecuenciaSintoma(i))
            '    Else
            '        listaFrecuencias.Add(0)
            '    End If
            'Next

            'Dim porcentajeSintomasCoincidentes As Double = (Double.Parse(cantidadSintomasCoincidentes) / Double.Parse(cantidadSintomasExistentes)) * 100

            If porcentajeProbabilidad > 0 Then
                listaEnfermedadesPosibles.Add(e)
                listaProbabilidades.Add(porcentajeProbabilidad)

                If porcentajeProbabilidad > certeza Then
                    certeza = porcentajeProbabilidad
                    enfermedadMasProbable = e
                End If
            End If
        Next

        enfermedadesDiagnosticadas = New EnfermedadesDiagnosticadas(listaEnfermedadesPosibles, listaProbabilidades)
        Return enfermedadMasProbable
    End Function

    Public Function DeterminarProbabilidadEnfermedad(sintomas As List(Of Sintoma), enfermedad As Enfermedad) As Decimal
        Dim cantidadSintomasExistentes As Integer = enfermedad.Sintomas.Count
        Dim cantidadSintomasCoincidentes As Integer = 0
        Dim listaFrecuencias As New List(Of Decimal)
        For i = 0 To cantidadSintomasExistentes - 1
            If sintomas.Contains(enfermedad.Sintomas(i)) Then
                cantidadSintomasCoincidentes += 1
                listaFrecuencias.Add(enfermedad.FrecuenciaSintoma(i))
            Else
                listaFrecuencias.Add(0)
            End If
        Next

        Dim porcentajeProbabilidad As Double = 0
        For Each frecuencia As Decimal In listaFrecuencias
            porcentajeProbabilidad += frecuencia
        Next
        porcentajeProbabilidad /= cantidadSintomasExistentes
        Return porcentajeProbabilidad
    End Function

    Public Function CargarUltimosMensajesDiagnostico(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta, cantidad As Integer) As List(Of Mensaje)
        Dim mensajes As List(Of Mensaje) = ObtenerUltimosMensajesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta, cantidad)
        mensajes.Reverse()
        Return mensajes
    End Function

    Public Function ContarMensajes(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta) As Integer
        Return ObtenerCantidadMensajesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta)
    End Function

    Public Function ContarDiagnosticosDiferenciales(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta) As Integer
        Return ObtenerCantidadDiagnosticosDiferencialesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta)
    End Function

    Public Function CargarDiagnosticosDiferenciales(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta) As List(Of DiagnosticoDiferencial)
        Return ObtenerDiagnosticosDiferencialesPorDiagnosticoPrimarioConConsulta(diagnosticoPrimarioConConsulta)
    End Function

    Public Function CargarUltimoDiagnosticoDiferencialConsulta(diagnosticoPrimarioConConsulta As DiagnosticoPrimarioConConsulta) As DiagnosticoDiferencial
        Dim todosLosDiferenciales As List(Of DiagnosticoDiferencial) = CargarDiagnosticosDiferenciales(diagnosticoPrimarioConConsulta)
        Dim ultimaFecha As Date = Date.MinValue
        Dim indiceUltimaFecha As Integer = Integer.MinValue
        For i = 0 To todosLosDiferenciales.Count - 1
            If todosLosDiferenciales(i).FechaHora > ultimaFecha Then
                ultimaFecha = todosLosDiferenciales(i).FechaHora
                indiceUltimaFecha = i
            End If
        Next
        Return todosLosDiferenciales(indiceUltimaFecha)
    End Function

    Public Function CargarDiagnosticosPrimariosDelPaciente(paciente As Paciente) As List(Of DiagnosticoPrimario)
        Return ObtenerDiagnosticosPrimariosPorPaciente(paciente)
    End Function

    Public Function CargarConsultasSinAtenderParaMedicoLogeado() As List(Of DiagnosticoPrimarioConConsulta)
        Dim consultasSinAtender As List(Of DiagnosticoPrimarioConConsulta) = ObtenerConsultasSinAtender()
        Dim consultasFiltradasPorEspecialidad As New List(Of DiagnosticoPrimarioConConsulta)
        For Each d As DiagnosticoPrimarioConConsulta In consultasSinAtender
            Dim enfermedad As Enfermedad = d.Enfermedades(d.IndiceEnfermedadMasProbable)
            For Each e As Especialidad In medicoLogeado.Especialidades
                If e.ID = enfermedad.Especialidad.ID Then
                    consultasFiltradasPorEspecialidad.Add(d)
                End If
            Next
        Next
        Return consultasFiltradasPorEspecialidad
    End Function

    Public Function AsignarMedicoLogeadoAConsulta(consulta As DiagnosticoPrimarioConConsulta) As DiagnosticoPrimarioConConsulta
        Dim consultaConMedico As New DiagnosticoPrimarioConConsulta(consulta.ID, consulta.Paciente, consulta.Sintomas,
                                                                    consulta.EnfermedadesDiagnosticadas, consulta.FechaHora, medicoLogeado,
                                                                    consulta.ComentariosAdicionales)

        AsignarIDMedicoAConsulta(medicoLogeado, consulta)
        Return consultaConMedico
    End Function

    Public Function CargarConsultasMedico(mesesHistorial As Integer) As List(Of DiagnosticoPrimarioConConsulta)
        Return ObtenerUltimosDiagnosticosPrimariosConConsultaPorMedico(medicoLogeado, mesesHistorial)
    End Function

    Public Sub CrearSintoma(nombre As String, descripcion As String, recomendaciones As String, urgencia As String,
                              listaEnfermedades As List(Of Enfermedad), listaFrecuencias As List(Of Decimal))

        Dim nuevoSintoma As New Sintoma(nombre, descripcion, recomendaciones, urgencia, New EnfermedadesAsociadas(listaEnfermedades, listaFrecuencias))
        Try
            InsertarObjeto(nuevoSintoma, TiposObjeto.Sintoma)
        Catch ex As MySqlException
            Select Case ex.Number
                Case 1062
                    Throw New Exception("Ya existe un síntoma con ese nombre.")
                Case Else
                    Throw ex
            End Select
        End Try
    End Sub

    Public Sub CrearEnfermedad(nombre As String, descripcion As String, recomendaciones As String, gravedad As Integer,
                               listaSintomas As List(Of Sintoma), listaFrecuencias As List(Of Decimal), especialidad As Especialidad)

        Dim nuevaEnfermedad As New Enfermedad(nombre, recomendaciones, gravedad, descripcion,
                                              New SintomasAsociados(listaSintomas, listaFrecuencias), especialidad)

        Try
            InsertarObjeto(nuevaEnfermedad, TiposObjeto.Enfermedad)
        Catch ex As MySqlException
            Select Case ex.Number
                Case 1062
                    Throw New Exception("Ya existe una enfermedad con ese nombre.")
                Case Else
                    Throw ex
            End Select
        End Try
    End Sub

    Public Function CrearDiagnosticoPrimario(paciente As Paciente, sintomas As List(Of Sintoma), enfermedadesDiagnosticadas As EnfermedadesDiagnosticadas) As DiagnosticoPrimario
        Dim nuevoDiagnostico As New DiagnosticoPrimario(paciente, sintomas, enfermedadesDiagnosticadas, Now, TiposDiagnosticosPrimarios.Sin_Consulta)

        InsertarObjeto(nuevoDiagnostico, TiposObjeto.DiagnosticoPrimario)

        Return nuevoDiagnostico
    End Function

    Public Sub CrearDiagnosticoDiferencial(consulta As DiagnosticoPrimarioConConsulta, enfermedadDiagnosticada As Enfermedad, conductaASeguir As String)
        Dim nuevoDiagnostico As New DiagnosticoDiferencial(consulta, enfermedadDiagnosticada, conductaASeguir, Now)

        InsertarObjeto(nuevoDiagnostico, TiposObjeto.DiagnosticoDiferencial)
    End Sub

    Public Function AgregarConsultaADiagnostico(diagnosticoPrimario As DiagnosticoPrimario, comentariosAdicionales As String) As DiagnosticoPrimarioConConsulta
        Dim nuevoDiagnosticoConConsulta As New DiagnosticoPrimarioConConsulta(diagnosticoPrimario, comentariosAdicionales)

        InsertarObjeto(nuevoDiagnosticoConConsulta, TiposObjeto.DiagnosticoPrimarioConConsulta)

        Return nuevoDiagnosticoConConsulta
    End Function

    Public Function EnviarMensaje(formatoMensaje As FormatosMensajeAdmitidos, contenido As Byte(), remitente As TiposRemitente,
                             diagnosticoEnCurso As DiagnosticoPrimarioConConsulta) As Mensaje

        Dim nuevoMensaje As New Mensaje(Now, formatoMensaje, contenido, remitente, diagnosticoEnCurso)

        InsertarObjeto(nuevoMensaje, TiposObjeto.Mensaje)

        Return nuevoMensaje
    End Function

    Public Sub ActualizarSintoma(sintomaViejo As Sintoma, nombre As String, descripcion As String, recomendaciones As String, urgencia As Integer,
                                 listaEnfermedades As List(Of Enfermedad), listaFrecuencias As List(Of Decimal))

        Dim nuevoSintoma As New Sintoma(sintomaViejo.ID, nombre, descripcion, recomendaciones, urgencia,
                                        New EnfermedadesAsociadas(listaEnfermedades, listaFrecuencias), sintomaViejo.Habilitado)
        ModificarObjeto(nuevoSintoma, TiposObjeto.Sintoma)
    End Sub

    Public Sub ActualizarEnfermedad(enfermedadVieja As Enfermedad, nombre As String, descripcion As String, recomendaciones As String, gravedad As Integer,
                                    listaSintomas As List(Of Sintoma), listaFrecuencias As List(Of Decimal), especialidad As Especialidad)

        Dim nuevaEnfermedad As New Enfermedad(enfermedadVieja.Id, nombre, recomendaciones, gravedad, descripcion,
                                              New SintomasAsociados(listaSintomas, listaFrecuencias), especialidad, enfermedadVieja.Habilitada)
        ModificarObjeto(nuevaEnfermedad, TiposObjeto.Enfermedad)
    End Sub

    Public Sub EliminarSintoma(sintoma As Sintoma)
        EliminarObjeto(sintoma, TiposObjeto.Sintoma)
    End Sub

    Public Sub EliminarEnfermedad(enfermedad As Enfermedad)
        EliminarObjeto(enfermedad, TiposObjeto.Enfermedad)
    End Sub
End Module
