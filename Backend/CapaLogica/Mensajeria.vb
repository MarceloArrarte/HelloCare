Imports System.Net.Mail
Imports Clases
Imports CapaPersistencia
Imports System.IO

Public Module Mensajeria
    Friend Sub EnviarCorreoAlta(paciente As Paciente)
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

        Dim archivoCorreo As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                archivoCorreo = "MailAltaPacientesES.html"
            Case Idiomas.Ingles
                archivoCorreo = "MailAltaPacientesEN.html"
        End Select

        Dim cuerpoMensaje As String = My.Computer.FileSystem.ReadAllText(archivoCorreo)
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

    Friend Sub EnviarCorreoAlta(medico As Medico)
        Dim SmtpServer As New SmtpClient()
        SmtpServer.Credentials = New Net.NetworkCredential("hellocode.software@gmail.com", "2020HCSW")
        SmtpServer.Port = 587
        SmtpServer.Host = "smtp.gmail.com"
        SmtpServer.EnableSsl = True
        Dim mail As New MailMessage()
        mail.From = New MailAddress("hellocode.software@gmail.com")
        mail.To.Add(medico.Correo)
        mail.Subject = "Registro en Hellocare"

        Dim archivoCorreo As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                archivoCorreo = "MailAltaMedicosES.html"
            Case Idiomas.Ingles
                archivoCorreo = "MailAltaMedicosEN.html"
        End Select

        Dim cuerpoMensaje As String = My.Computer.FileSystem.ReadAllText(archivoCorreo)
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

    Friend Sub EnviarCorreoAlta(administrativo As Administrativo)
        Dim SmtpServer As New SmtpClient()
        SmtpServer.Credentials = New Net.NetworkCredential("hellocode.software@gmail.com", "2020HCSW")
        SmtpServer.Port = 587
        SmtpServer.Host = "smtp.gmail.com"
        SmtpServer.EnableSsl = True
        Dim mail As New MailMessage()
        mail.From = New MailAddress("hellocode.software@gmail.com")
        mail.To.Add(administrativo.Correo)
        mail.Subject = "Registro en Hellocare"

        Dim archivoCorreo As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                archivoCorreo = "MailAltaAdministrativosES.html"
            Case Idiomas.Ingles
                archivoCorreo = "MailAltaAdministrativosEN.html"
        End Select

        Dim cuerpoMensaje As String = My.Computer.FileSystem.ReadAllText(archivoCorreo)
        cuerpoMensaje = cuerpoMensaje.Replace("%CI%", administrativo.CI)
        cuerpoMensaje = cuerpoMensaje.Replace("%NOMBRE%", administrativo.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%APELLIDO%", administrativo.Apellido)
        cuerpoMensaje = cuerpoMensaje.Replace("%CORREO%", administrativo.Correo)
        cuerpoMensaje = cuerpoMensaje.Replace("%DEPARTAMENTO%", administrativo.Localidad.Departamento.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%LOCALIDAD%", administrativo.Localidad.Nombre)

        Dim nombreCargo As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                If administrativo.EsEncargado Then
                    nombreCargo = "Encargado"
                Else
                    nombreCargo = "Empleado"
                End If
            Case Idiomas.Ingles
                If administrativo.EsEncargado Then
                    nombreCargo = "Manager"
                Else
                    nombreCargo = "Employee"
                End If
        End Select
        cuerpoMensaje = cuerpoMensaje.Replace("%CARGO%", If(administrativo.EsEncargado, "Encargado", "Empleado"))
        mail.Body = cuerpoMensaje
        mail.IsBodyHtml = True
        SmtpServer.Send(mail)
    End Sub

    Friend Sub EnviarCorreoRegistro(persona As Persona, contrasena As String)
        Dim SmtpServer As New SmtpClient()
        SmtpServer.Credentials = New Net.NetworkCredential("hellocode.software@gmail.com", "2020HCSW")
        SmtpServer.Port = 587
        SmtpServer.Host = "smtp.gmail.com"
        SmtpServer.EnableSsl = True
        Dim mail As New MailMessage()
        mail.From = New MailAddress("hellocode.software@gmail.com")
        mail.To.Add(persona.Correo)
        mail.Subject = "Registro en HelloCare"

        Dim archivoCorreo As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                archivoCorreo = "MailRegistroUsuarioES.html"
            Case Idiomas.Ingles
                archivoCorreo = "MailRegistroUsuarioEN.html"
        End Select

        Dim cuerpoMensaje As String = My.Computer.FileSystem.ReadAllText(archivoCorreo)
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

        Dim archivoCorreo As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                archivoCorreo = "MailRestaurarContrasenaES.html"
            Case Idiomas.Ingles
                archivoCorreo = "MailRestaurarContrasenaEN.html"
        End Select

        Dim cuerpoMensaje As String = My.Computer.FileSystem.ReadAllText(archivoCorreo)
        cuerpoMensaje = cuerpoMensaje.Replace("%NOMBRE%", persona.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%APELLIDO%", persona.Apellido)
        cuerpoMensaje = cuerpoMensaje.Replace("%CIFRADO%", usuario.Contrasena)
        mail.Body = cuerpoMensaje
        mail.IsBodyHtml = True
        SmtpServer.Send(mail)
    End Sub

    Public Sub EnviarSesionChat(paciente As Paciente, diagnostico As DiagnosticoDiferencial, contenidoChat As String,
                                archivos As List(Of Mensaje))
        Dim SmtpServer As New SmtpClient()
        SmtpServer.Credentials = New Net.NetworkCredential("hellocode.software@gmail.com", "2020HCSW")
        SmtpServer.Port = 587
        SmtpServer.Host = "smtp.gmail.com"
        SmtpServer.EnableSsl = True
        Dim mail As New MailMessage()
        mail.From = New MailAddress("hellocode.software@gmail.com")
        mail.To.Add(paciente.Correo)
        mail.Subject = "Sesión de chat - HelloCare"

        Dim archivoCorreo As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                archivoCorreo = "MailSesionChatES.html"
            Case Idiomas.Ingles
                archivoCorreo = "MailSesionChatEN.html"
        End Select

        Dim cuerpoMensaje As String = My.Computer.FileSystem.ReadAllText(archivoCorreo)
        cuerpoMensaje = cuerpoMensaje.Replace("%NOMBRE_PACIENTE%", paciente.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%APELLIDO_PACIENTE%", paciente.Apellido)
        cuerpoMensaje = cuerpoMensaje.Replace("%NOMBRE_MEDICO%", diagnostico.DiagnosticoPrimarioConConsulta.Medico.Nombre)
        cuerpoMensaje = cuerpoMensaje.Replace("%APELLIDO_MEDICO%", diagnostico.DiagnosticoPrimarioConConsulta.Medico.Apellido)
        cuerpoMensaje = cuerpoMensaje.Replace("%ENFERMEDAD%", diagnostico.EnfermedadDiagnosticada.ToString)
        cuerpoMensaje = cuerpoMensaje.Replace("%DESCRIPCION%", diagnostico.EnfermedadDiagnosticada.Descripcion)
        cuerpoMensaje = cuerpoMensaje.Replace("%GRAVEDAD%", diagnostico.EnfermedadDiagnosticada.Gravedad)
        cuerpoMensaje = cuerpoMensaje.Replace("%FECHAHORA%", diagnostico.FechaHora.ToString("d \de MMMM \del yyyy a la\s HH:mm"))
        cuerpoMensaje = cuerpoMensaje.Replace("%RECOMENDACIONES%", diagnostico.EnfermedadDiagnosticada.Recomendaciones)
        cuerpoMensaje = cuerpoMensaje.Replace("%CONDUCTA%", diagnostico.ConductaASeguir)
        cuerpoMensaje = cuerpoMensaje.Replace("%ESPECIALIDAD%", diagnostico.EnfermedadDiagnosticada.Especialidad.ToString)
        cuerpoMensaje = cuerpoMensaje.Replace("%CHAT%", contenidoChat.Replace(vbNewLine, "<br/>"))

        Dim sintomasFormateados As String = ""
        For i = 0 To diagnostico.EnfermedadDiagnosticada.Sintomas.Count - 1
            sintomasFormateados &= "<tr><td style=""border: 1px solid black"">" & diagnostico.EnfermedadDiagnosticada.Sintomas(i).ToString & "</td><td style=""border: 1px solid black"">" & diagnostico.EnfermedadDiagnosticada.FrecuenciaSintoma(i) & "%</td></tr>"
        Next
        cuerpoMensaje = cuerpoMensaje.Replace("%SINTOMAS%", sintomasFormateados)

        For i = 0 To archivos.Count - 1
            Dim archivo As Mensaje = archivos(i)
            Dim stream As New MemoryStream(CargarContenidoArchivoPorID(archivo.ID))
            Dim adjunto As New Attachment(stream, archivo.NombreArchivo)
            mail.Attachments.Add(adjunto)
        Next

        mail.Body = cuerpoMensaje
        mail.IsBodyHtml = True
        SmtpServer.Send(mail)
    End Sub
End Module
