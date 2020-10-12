Imports Clases
Imports CapaPersistencia
Imports System.CodeDom
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports System.Security.Cryptography
Imports System.Net.Mail

Public Module Principal
    Public Function AutenticarUsuarioPaciente(ci As String, contrasena As String) As ResultadosLogin
        If Not TienePersonaRegistrada(ci, TiposPersona.Paciente) Then
            Return ResultadosLogin.PersonaNoExiste
        End If

        Dim paciente As Paciente = ObtenerPacientePorCI(ci)
        If Not TieneUsuarioRegistrado(paciente) Then
            pacienteLogeado = paciente
            Return ResultadosLogin.SinUsuario
        End If

        Dim usuarioPaciente As Usuario = ObtenerUsuarioPorPersona(paciente)
        If CifrarClave(contrasena) = usuarioPaciente.Contrasena Then
            pacienteLogeado = paciente
            Return ResultadosLogin.OK
        Else
            Return ResultadosLogin.ContrasenaIncorrecta
        End If
    End Function

    Public Function CargarPacientePorCI(ci As String)
        Return ObtenerPacientePorCI(ci)
    End Function

    Public Function AutenticarUsuarioMedico(ci As String, contrasena As String) As ResultadosLogin
        If Not TienePersonaRegistrada(ci, TiposPersona.Funcionario) Then
            Return ResultadosLogin.PersonaNoExiste
        End If

        Dim medico As Medico = ObtenerMedicoPorCI(ci)

        If Not TieneUsuarioRegistrado(medico) Then
            medicoLogeado = medico
            Return ResultadosLogin.SinUsuario
        End If

        Dim usuarioMedico As Usuario = ObtenerUsuarioPorPersona(medico)
        If CifrarClave(contrasena) = usuarioMedico.Contrasena Then
            medicoLogeado = medico
            Return ResultadosLogin.OK
        Else
            Return ResultadosLogin.ContrasenaIncorrecta
        End If
    End Function

    Public Function CargarMedicoPorCI(ci As String)
        Return ObtenerMedicoPorCI(ci)
    End Function

    Public Function AutenticarUsuarioAdministrativo(ci As String, contrasena As String) As ResultadosLogin
        If Not TienePersonaRegistrada(ci, TiposPersona.Funcionario) Then
            Return ResultadosLogin.PersonaNoExiste
        End If

        Dim administrativo As Administrativo = ObtenerAdministrativoPorCI(ci)
        If Not TieneUsuarioRegistrado(administrativo) Then
            administrativoLogeado = administrativo
            Return ResultadosLogin.SinUsuario
        End If

        Dim usuarioAdministrativo As Usuario = ObtenerUsuarioPorPersona(administrativo)
        If CifrarClave(contrasena) = usuarioAdministrativo.Contrasena Then
            administrativoLogeado = administrativo
            Return ResultadosLogin.OK
        Else
            Return ResultadosLogin.ContrasenaIncorrecta
        End If
    End Function

    Public Function CargarAdministrativoPorCI(ci As String)
        Return ObtenerAdministrativoPorCI(ci)
    End Function

    Public Function CargarTodosLosSintomas() As List(Of Sintoma)
        Return ObtenerListadoSintomas()
    End Function

    Public Function CargarTodasLasEnfermedades() As List(Of Enfermedad)
        Return ObtenerListadoEnfermedades()
    End Function

    Public Function CargarTodasLasEspecialidades() As List(Of Especialidad)
        Return ObtenerListadoEspecialidades()
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

    Private Function DeterminarProbabilidadEnfermedad(sintomasIngresados As List(Of Sintoma), enfermedad As Enfermedad) As Decimal
        Dim cantidadSintomasExistentes As Integer = enfermedad.Sintomas.Count
        Dim cantidadSintomasCoincidentes As Integer = 0
        Dim listaFrecuencias As New List(Of Decimal)
        For i = 0 To cantidadSintomasExistentes - 1
            For Each sintomaIngresado As Sintoma In sintomasIngresados
                If sintomaIngresado.ID = enfermedad.Sintomas(i).ID Then
                    cantidadSintomasCoincidentes += 1
                    listaFrecuencias.Add(enfermedad.FrecuenciaSintoma(i))
                Else
                    listaFrecuencias.Add(0)
                End If
            Next
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

        Dim consultasRecientes, consultasAtrasadas As New List(Of DiagnosticoPrimarioConConsulta)
        For i = 0 To consultasFiltradasPorEspecialidad.Count - 1
            Dim consulta As DiagnosticoPrimarioConConsulta = consultasFiltradasPorEspecialidad(i)
            If consulta.FechaHora.AddDays(1) < Now Then
                consultasAtrasadas.Add(consulta)
            Else
                consultasRecientes.Add(consulta)
            End If
        Next

        Return consultasFiltradasPorEspecialidad

        'Dim listaOrdenada As New List(Of DiagnosticoPrimarioConConsulta)

        'If consultasAtrasadas.Count > 0 Then
        '    Dim consultasAtrasadasSegunGravedad As New List(Of DiagnosticoPrimarioConConsulta)
        '    For i = 0 To consultasAtrasadas.Count - 1
        '        Dim consultaMasGrave As DiagnosticoPrimarioConConsulta = consultasAtrasadas(0)
        '        For j = 0 To consultasAtrasadas.Count - 1
        '            Dim consulta As DiagnosticoPrimarioConConsulta = consultasAtrasadas(j)
        '            If consulta.Enfermedades(consulta.IndiceEnfermedadMasProbable).Gravedad > consultaMasGrave.Enfermedades(consulta.IndiceEnfermedadMasProbable).Gravedad Then
        '                consultaMasGrave = consulta
        '            End If
        '        Next
        '        consultasAtrasadasSegunGravedad.Add(consultaMasGrave)
        '    Next
        '    listaOrdenada.AddRange(consultasAtrasadasSegunGravedad)
        'End If

        'If consultasRecientes.Count > 0 Then
        '    Dim consultasRecientesSegunGravedad As New List(Of DiagnosticoPrimarioConConsulta)
        '    For i = 0 To consultasRecientes.Count - 1
        '        Dim consultaMasGrave As DiagnosticoPrimarioConConsulta = consultasRecientes(0)
        '        For j = 0 To consultasRecientes.Count - 1
        '            Dim consulta As DiagnosticoPrimarioConConsulta = consultasRecientes(j)
        '            If consulta.Enfermedades(consulta.IndiceEnfermedadMasProbable).Gravedad > consultaMasGrave.Enfermedades(consulta.IndiceEnfermedadMasProbable).Gravedad Then
        '                consultaMasGrave = consulta
        '            End If
        '        Next
        '        consultasRecientesSegunGravedad.Add(consultaMasGrave)
        '    Next
        '    listaOrdenada.AddRange(consultasRecientesSegunGravedad)
        'End If

        'Return listaOrdenada
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

    Public Sub CrearSintoma(nombre As String, descripcion As String, recomendaciones As String, urgencia As Integer,
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
        Dim fechaHoraDiagnostico As Date = Now
        Dim nuevoDiagnostico As New DiagnosticoPrimario(paciente, sintomas, enfermedadesDiagnosticadas, fechaHoraDiagnostico,
                                                        TiposDiagnosticosPrimarios.Sin_Consulta)

        Dim idAsignado As Integer
        InsertarObjeto(nuevoDiagnostico, TiposObjeto.DiagnosticoPrimario, idAsignado)
        Dim diagnosticoInsertado As New DiagnosticoPrimario(idAsignado, paciente, sintomas, enfermedadesDiagnosticadas, fechaHoraDiagnostico,
                                                            TiposDiagnosticosPrimarios.Sin_Consulta)

        Return diagnosticoInsertado
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
                             diagnosticoEnCurso As DiagnosticoPrimarioConConsulta, Optional nombreArchivo As String = Nothing) As Mensaje

        Dim nuevoMensaje As New Mensaje(Now, formatoMensaje, contenido, nombreArchivo, remitente, diagnosticoEnCurso)
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

    Public Sub ImportarEnfermedades(nombreArchivo As String)
        Dim filasParseadas As New List(Of String())
        Dim parser As New TextFieldParser(nombreArchivo, Encoding.UTF8)
        parser.TextFieldType = FieldType.Delimited
        parser.SetDelimiters(",")
        While Not parser.EndOfData
            filasParseadas.Add(parser.ReadFields)
        End While

        If filasParseadas.Count Mod 3 <> 0 Then
            Throw New Exception("Error de formato en el archivo importado. La cantidad de filas debe ser múltiplo de 3.")
        End If

        Dim especialidadesCargadas As List(Of Especialidad) = CargarTodasLasEspecialidades()
        Dim sintomasCargados As List(Of Sintoma) = CargarTodosLosSintomas()
        Dim listaEnfermedadesImportadas As New List(Of Enfermedad)

        For i = 0 To filasParseadas.Count - 1 Step 3
            Dim datosEnfermedad As String() = filasParseadas(i)
            Dim nombre As String = datosEnfermedad(0)
            Dim descripcion As String = datosEnfermedad(1)
            Dim recomendaciones As String = datosEnfermedad(2)
            Dim gravedad As Integer = datosEnfermedad(3)
            Dim especialidad As Especialidad = Nothing

            Dim nombreEspecialidad As String = datosEnfermedad(4)
            For Each e As Especialidad In especialidadesCargadas
                If e.Nombre = nombreEspecialidad Then
                    especialidad = e
                End If
            Next
            If especialidad Is Nothing Then
                Throw New Exception(String.Format("La especialidad indicada para la enfermedad ""{0}"" ({1}) no se encuentra registrada en el sistema.",
                                                  nombre, nombreEspecialidad))
            End If

            Dim j As Integer = 0
            While j < filasParseadas(i + 2).Length AndAlso filasParseadas(i + 2)(j) <> ""
                Dim valor As String = filasParseadas(i + 2)(j)
                Dim valorConvertido As Decimal
                If Decimal.TryParse(valor, valorConvertido) = False Then
                    Throw New Exception(String.Format("Error de formato: las frecuencias de los síntomas de la enfermedad ""{0}"" no tienen un formato válido.",
                                                      nombre))
                End If
                j += 1
            End While

            Dim cantSintomas As Integer = j
            Dim nombresSintomas As String() = filasParseadas(i + 1).Take(cantSintomas).ToArray
            Dim frecuenciasSintomas As String() = filasParseadas(i + 2).Take(cantSintomas).ToArray

            Dim listaSintomas As New List(Of Sintoma)
            Dim listaFrecuencias As New List(Of Decimal)

            For j = 0 To nombresSintomas.Length - 1
                Dim sintoma As Sintoma = Nothing
                For Each s In sintomasCargados
                    If nombresSintomas(j) = s.Nombre Then
                        sintoma = s
                    End If
                Next
                If sintoma Is Nothing Then
                    Throw New Exception(String.Format("El síntoma ""{0}"" de la enfermedad ""{1}"" no se encuentra registrado en el sistema.",
                                                       nombresSintomas(j), nombre))
                Else
                    listaSintomas.Add(sintoma)
                    listaFrecuencias.Add(CDec(frecuenciasSintomas(j)))
                End If
            Next

            Dim sintomasAsociados As New SintomasAsociados(listaSintomas, listaFrecuencias)
            listaEnfermedadesImportadas.Add(New Enfermedad(nombre, recomendaciones, gravedad, descripcion, sintomasAsociados, especialidad))
        Next

        InsertarEnfermedadesImportadas(listaEnfermedadesImportadas)
    End Sub

    Public Sub ImportarSintomas(nombreArchivo As String)
        Dim filasParseadas As New List(Of String())
        Dim parser As New TextFieldParser(nombreArchivo, Encoding.UTF8)
        parser.TextFieldType = FieldType.Delimited
        parser.SetDelimiters(",")
        While Not parser.EndOfData
            filasParseadas.Add(parser.ReadFields)
        End While

        If filasParseadas.Count Mod 3 <> 0 Then
            Throw New Exception("Error de formato en el archivo importado. La cantidad de filas debe ser múltiplo de 3.")
        End If

        Dim enfermedadesCargadas As List(Of Enfermedad) = CargarTodasLasEnfermedades()
        Dim listaSintomasImportados As New List(Of Sintoma)

        For i = 0 To filasParseadas.Count - 1 Step 3
            Dim datosSintoma As String() = filasParseadas(i)
            Dim nombre As String = datosSintoma(0)
            Dim descripcion As String = datosSintoma(1)
            Dim recomendaciones As String = datosSintoma(2)
            Dim urgencia As Integer = datosSintoma(3)

            Dim j As Integer = 0
            While j < filasParseadas(i + 2).Length AndAlso filasParseadas(i + 2)(j) <> ""
                Dim valor As String = filasParseadas(i + 2)(j)
                Dim valorConvertido As Decimal
                If Decimal.TryParse(valor, valorConvertido) = False Then
                    Throw New Exception(String.Format("Error de formato: las frecuencias de las enfermedades del síntoma ""{0}"" no tienen un formato válido.",
                                                      nombre))
                End If
                j += 1
            End While

            Dim cantEnfermedades As Integer = j
            Dim nombresEnfermedades As String() = filasParseadas(i + 1).Take(cantEnfermedades).ToArray
            Dim frecuenciasEnfermedades As String() = filasParseadas(i + 2).Take(cantEnfermedades).ToArray

            Dim listaEnfermedades As New List(Of Enfermedad)
            Dim listaFrecuencias As New List(Of Decimal)

            For j = 0 To nombresEnfermedades.Length - 1
                Dim enfermedad As Enfermedad = Nothing
                For Each e In enfermedadesCargadas
                    If nombresEnfermedades(j) = e.Nombre Then
                        enfermedad = e
                    End If
                Next
                If enfermedad Is Nothing Then
                    Throw New Exception(String.Format("La enfermedad ""{0}"" del síntoma ""{1}"" no se encuentra registrada en el sistema.",
                                                       nombresEnfermedades(j), nombre))
                Else
                    listaEnfermedades.Add(enfermedad)
                    listaFrecuencias.Add(frecuenciasEnfermedades(j))
                End If
            Next

            Dim enfermedadesAsociadas As New EnfermedadesAsociadas(listaEnfermedades, listaFrecuencias)
            listaSintomasImportados.Add(New Sintoma(nombre, descripcion, recomendaciones, urgencia, enfermedadesAsociadas))
        Next

        InsertarSintomasImportados(listaSintomasImportados)
    End Sub

    Public Sub RegistrarUsuario(persona As Persona, contrasena As String)
        Dim nuevoUsuario As New Usuario(CifrarClave(contrasena), persona)
        InsertarObjeto(nuevoUsuario, TiposObjeto.Usuario)
        EnviarCorreoRegistro(persona, contrasena)
    End Sub

    Private Function CifrarClave(clave As String) As String
        Dim tDES As New TripleDESCryptoServiceProvider
        tDES.Key = TruncarHash(clave, tDES.KeySize / 8)
        tDES.IV = TruncarHash("20201001115839", tDES.BlockSize / 8)

        Dim bytesTexto() As Byte = Encoding.Unicode.GetBytes(clave)

        Dim streamMemoria As New MemoryStream
        Dim streamCodificador As New CryptoStream(streamMemoria, tDES.CreateEncryptor(), CryptoStreamMode.Write)

        streamCodificador.Write(bytesTexto, 0, bytesTexto.Length)
        streamCodificador.FlushFinalBlock()

        Dim cadenaResultante As String = Convert.ToBase64String(streamMemoria.ToArray)
        Return cadenaResultante
    End Function

    Private Function TruncarHash(clave As String, largo As Integer) As Byte()
        Dim sha As New SHA1CryptoServiceProvider
        Dim bytesClave() As Byte = Encoding.Unicode.GetBytes(clave)
        Dim hash() As Byte = sha.ComputeHash(bytesClave)
        ReDim Preserve hash(largo - 1)
        Return hash
    End Function

    Private Sub EnviarCorreoAlta(paciente As Paciente, contrasena As String)
        Dim SmtpServer As New SmtpClient()
        SmtpServer.Credentials = New Net.NetworkCredential("hellocode.software@gmail.com", "2020HCSW")
        SmtpServer.Port = 587
        SmtpServer.Host = "smtp.gmail.com"
        SmtpServer.EnableSsl = True
        Dim mail As New MailMessage()
        mail.From = New MailAddress("hellocode.software@gmail.com")
        mail.To.Add(paciente.Correo)
        If paciente.Sexo = TiposSexo.F Then
            mail.Subject = "¡Bienvenida a HelloCare!"
        Else
            mail.Subject = "¡Bienvenido a HelloCare!"
        End If

        Dim cuerpoMensaje As String = My.Computer.FileSystem.ReadAllText("../../MailAltaPacientes.html")
        cuerpoMensaje = cuerpoMensaje.Replace("%o/a%", If(paciente.Sexo = TiposSexo.F, "a", "o"))
        cuerpoMensaje = cuerpoMensaje.Replace("%CI%", paciente.CI)
        cuerpoMensaje = cuerpoMensaje.Replace("%NOMBRE%", paciente.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%APELLIDO%", paciente.Apellido)
        Select Case paciente.Sexo
            Case TiposSexo.M
                cuerpoMensaje = cuerpoMensaje.Replace("%SEXO%", "Masculino")
            Case TiposSexo.F
                cuerpoMensaje = cuerpoMensaje.Replace("%SEXO%", "Femenino")
            Case TiposSexo.O
                cuerpoMensaje = cuerpoMensaje.Replace("%SEXO%", "Otro")
        End Select
        cuerpoMensaje = cuerpoMensaje.Replace("%DIRECCION%", paciente.Calle & " " & paciente.NumeroPuerta & If(paciente.Apartamento <> Nothing, " Apto. " & paciente.Apartamento, ""))
        cuerpoMensaje = cuerpoMensaje.Replace("%CORREO%", paciente.Correo)
        cuerpoMensaje = cuerpoMensaje.Replace("%FECHANACIMIENTO%", paciente.FechaNacimiento)
        cuerpoMensaje = cuerpoMensaje.Replace("%DEPARTAMENTO%", paciente.Localidad.Departamento.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%LOCALIDAD%", paciente.Localidad.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%MOVIL%", paciente.TelefonoMovil)
        cuerpoMensaje = cuerpoMensaje.Replace("%FIJO%", paciente.TelefonoFijo)
        mail.Body = cuerpoMensaje
        mail.IsBodyHtml = True
        SmtpServer.Send(mail)
    End Sub

    Private Sub EnviarCorreoAlta(medico As Medico, contrasena As String)
        Dim SmtpServer As New SmtpClient()
        SmtpServer.Credentials = New Net.NetworkCredential("hellocode.software@gmail.com", "2020HCSW")
        SmtpServer.Port = 587
        SmtpServer.Host = "smtp.gmail.com"
        SmtpServer.EnableSsl = True
        Dim mail As New MailMessage()
        mail.From = New MailAddress("hellocode.software@gmail.com")
        mail.To.Add(medico.Correo)
        mail.Subject = "Registro en Hellocare"

        Dim cuerpoMensaje As String = My.Computer.FileSystem.ReadAllText("../../MailAltaMedicos.html")
        cuerpoMensaje = cuerpoMensaje.Replace("%CI%", medico.CI)
        cuerpoMensaje = cuerpoMensaje.Replace("%NOMBRE%", medico.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%APELLIDO%", medico.Apellido)
        cuerpoMensaje = cuerpoMensaje.Replace("%CORREO%", medico.Correo)
        cuerpoMensaje = cuerpoMensaje.Replace("%DEPARTAMENTO%", medico.Localidad.Departamento.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%LOCALIDAD%", medico.Localidad.Nombre)
        Dim nombresEspecialidades As New List(Of String)
        For i = 0 To medico.Especialidades.Count - 1
            nombresEspecialidades.Add(medico.Especialidades(i).Nombre)
        Next
        cuerpoMensaje = cuerpoMensaje.Replace("%ESPECIALIDADES%", String.Join(", ", nombresEspecialidades))
        mail.Body = cuerpoMensaje
        mail.IsBodyHtml = True
        SmtpServer.Send(mail)
    End Sub

    Private Sub EnviarCorreoAlta(administrativo As Administrativo, contrasena As String)
        Dim SmtpServer As New SmtpClient()
        SmtpServer.Credentials = New Net.NetworkCredential("hellocode.software@gmail.com", "2020HCSW")
        SmtpServer.Port = 587
        SmtpServer.Host = "smtp.gmail.com"
        SmtpServer.EnableSsl = True
        Dim mail As New MailMessage()
        mail.From = New MailAddress("hellocode.software@gmail.com")
        mail.To.Add(administrativo.Correo)
        mail.Subject = "Registro en Hellocare"

        Dim cuerpoMensaje As String = My.Computer.FileSystem.ReadAllText("../../MailAltaAdministrativos.html")
        cuerpoMensaje = cuerpoMensaje.Replace("%CI%", administrativo.CI)
        cuerpoMensaje = cuerpoMensaje.Replace("%NOMBRE%", administrativo.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%APELLIDO%", administrativo.Apellido)
        cuerpoMensaje = cuerpoMensaje.Replace("%CORREO%", administrativo.Correo)
        cuerpoMensaje = cuerpoMensaje.Replace("%DEPARTAMENTO%", administrativo.Localidad.Departamento.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%LOCALIDAD%", administrativo.Localidad.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%CARGO%", If(administrativo.EsEncargado, "Encargado", "Empleado"))
        mail.Body = cuerpoMensaje
        mail.IsBodyHtml = True
        SmtpServer.Send(mail)
    End Sub

    Private Sub EnviarCorreoRegistro(persona As Persona, contrasena As String)
        Dim SmtpServer As New SmtpClient()
        SmtpServer.Credentials = New Net.NetworkCredential("hellocode.software@gmail.com", "2020HCSW")
        SmtpServer.Port = 587
        SmtpServer.Host = "smtp.gmail.com"
        SmtpServer.EnableSsl = True
        Dim mail As New MailMessage()
        mail.From = New MailAddress("hellocode.software@gmail.com")
        mail.To.Add(persona.Correo)
        mail.Subject = "Registro en HelloCare"

        Dim cuerpoMensaje As String = My.Computer.FileSystem.ReadAllText("../../MailRegistroUsuario.html")
        cuerpoMensaje = cuerpoMensaje.Replace("%CEDULA%", persona.CI)
        cuerpoMensaje = cuerpoMensaje.Replace("%NOMBRE%", persona.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%APELLIDO%", persona.Apellido)
        cuerpoMensaje = cuerpoMensaje.Replace("%CONTRASEÑA%", contrasena)
        mail.Body = cuerpoMensaje
        mail.IsBodyHtml = True
        SmtpServer.Send(mail)
    End Sub

    Public Sub EnviarCorreoRestauracionContrasena(persona As Persona)
        Dim usuario As Usuario = ObtenerUsuarioPorPersona(persona)

        Dim SmtpServer As New SmtpClient()
        SmtpServer.Credentials = New Net.NetworkCredential("hellocode.software@gmail.com", "2020HCSW")
        SmtpServer.Port = 587
        SmtpServer.Host = "smtp.gmail.com"
        SmtpServer.EnableSsl = True
        Dim mail As New MailMessage()
        mail.From = New MailAddress("hellocode.software@gmail.com")
        mail.To.Add(persona.Correo)
        mail.Subject = "Restaurar contraseña"

        Dim cuerpoMensaje As String = My.Computer.FileSystem.ReadAllText("../../MailRestaurarContrasena.html")
        cuerpoMensaje = cuerpoMensaje.Replace("%NOMBRE%", persona.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%APELLIDO%", persona.Apellido)
        cuerpoMensaje = cuerpoMensaje.Replace("%CIFRADO%", usuario.Contrasena)
        mail.Body = cuerpoMensaje
        mail.IsBodyHtml = True
        SmtpServer.Send(mail)
    End Sub

    Public Sub EliminarUsuarioConCodigo(ci As String, tipo As TiposUsuario, hash As String)
        Select Case tipo
            Case TiposUsuario.Administrativo
                Dim administrativo As Administrativo = ObtenerAdministrativoPorCI(ci)
                Dim usuario As Usuario = ObtenerUsuarioPorPersona(administrativo)
                If usuario.Contrasena = hash Then
                    EliminarObjeto(usuario, TiposObjeto.Usuario)
                Else
                    Throw New Exception("El código de borrado no es correcto. Verifique que haya sido ingresado correctamente y reintente.")
                End If

            Case TiposUsuario.Medico
                Dim medico As Medico = ObtenerMedicoPorCI(ci)
                Dim usuario As Usuario = ObtenerUsuarioPorPersona(medico)
                If usuario.Contrasena = hash Then
                    EliminarObjeto(usuario, TiposObjeto.Usuario)
                Else
                    Throw New Exception("El código de borrado no es correcto. Verifique que haya sido ingresado correctamente y reintente.")
                End If

            Case TiposUsuario.Paciente
                Dim paciente As Paciente = ObtenerPacientePorCI(ci)
                Dim usuario As Usuario = ObtenerUsuarioPorPersona(paciente)
                If usuario.Contrasena = hash Then
                    EliminarObjeto(usuario, TiposObjeto.Usuario)
                Else
                    Throw New Exception("El código de borrado no es correcto. Verifique que haya sido ingresado correctamente y reintente.")
                End If
        End Select
    End Sub
End Module
