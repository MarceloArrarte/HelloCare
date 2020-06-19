Public Module Principal
    Friend ListaEnfermedades As New List(Of Enfermedad)
    Friend ListaSintomas As New List(Of Sintoma)
    Friend ListaAsociacionesSintomas As New List(Of AsociacionSintoma)
    Friend ListaUsuariosPacientes As New List(Of Usuario_Paciente)
    Friend ListaUsuariosAdministrativos As New List(Of Usuario_Administrativo)

    Public Sub Main()

    End Sub

    Public Sub IngresarEnfermedad(enfermedad As Enfermedad)
        'Try
        ' Manejo de errores de argumentos
        ' enfermedad tiene un valor nulo
        If enfermedad Is Nothing Then
            Throw New ArgumentNullException("La enfermedad tiene un valor nulo.")
        End If

        ' Se intenta insertar una enfermedad con un nombre duplicado
        For Each e As Enfermedad In ListaEnfermedades
            If enfermedad.Nombre = e.Nombre Then
                Throw New ArgumentException("Ya hay una enfermedad con este nombre.")
            End If
        Next

        ListaEnfermedades.Add(enfermedad)
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
    End Sub

    Public Sub ModificarEnfermedad(enfermedad As Enfermedad, indice As Integer)
        'Try
        ' Manejo de errores de argumentos
        ' enfermedad tiene un valor nulo
        If enfermedad Is Nothing Then
            Throw New ArgumentNullException("La enfermedad tiene un valor nulo.")
        End If

        ' El índice está fuera del rango de la colección
        If indice >= ListaEnfermedades.Count Then
            Throw New IndexOutOfRangeException("El índice indicado excede el tamaño de la colección.")
        End If

        ' Idem
        If indice < 0 Then
            Throw New IndexOutOfRangeException("El índice indicado es negativo.")
        End If

        ' Se intenta modificar una enfermedad, y su nombre entra en conflicto con el de otra
        For Each e As Enfermedad In ListaEnfermedades
            If enfermedad.Nombre = e.Nombre Then
                Throw New ArgumentException("Ya hay una enfermedad con este nombre.")
            End If
        Next

        Dim registro As Enfermedad = ListaEnfermedades(indice)
        'Dim nuevaEnfermedad As New Enfermedad(enfermedad.Nombre, enfermedad.Recomendaciones, enfermedad.Gravedad, enfermedad.Descripcion)
        ModificarEnfermedad(registro, enfermedad)
        'registro.Nombre = enfermedad.Nombre
        'registro.Descripcion = enfermedad.Descripcion
        'registro.Recomendaciones = enfermedad.Recomendaciones
        'registro.Gravedad = enfermedad.Gravedad
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
    End Sub

    Public Sub ModificarEnfermedad(enfermedadVieja As Enfermedad, enfermedadNueva As Enfermedad)
        'Try
        ' Manejo de errores de argumentos
        ' enfermedadVieja tiene un valor nulo
        If enfermedadVieja Is Nothing Then
            Throw New ArgumentNullException("La enfermedad original tiene un valor nulo")
        End If

        ' enfermedadNueva tiene un valor nulo
        If enfermedadNueva Is Nothing Then
            Throw New ArgumentNullException("La enfermedad a guardar tiene un valor nulo")
        End If

        ' La enfermedad a modificar no existe en la colección
        Dim indice As Integer = -1
        For Each e As Enfermedad In ListaEnfermedades
            If e.Nombre = enfermedadVieja.Nombre Then
                indice = ListaEnfermedades.IndexOf(e)
            End If
        Next
        If indice = -1 Then
            Throw New ArgumentException("La enfermedad original no está almacenada.")
        End If

        ' El nombre de la enfermedad modificada entra en conflicto con otra ya existente
        Dim cantidadNombresIguales As Integer = 0
        Dim mantieneElNombre As Boolean = (enfermedadVieja.Nombre = enfermedadNueva.Nombre)
        For Each e As Enfermedad In ListaEnfermedades
            If enfermedadNueva.Nombre = e.Nombre Then
                cantidadNombresIguales += 1
            End If
        Next
        If (cantidadNombresIguales > 1 And mantieneElNombre) Or (cantidadNombresIguales > 0 And Not mantieneElNombre) Then
            Throw New ArgumentException("Ya existe una enfermedad con este nombre.")
        End If
        'For Each e As Enfermedad In ListaEnfermedades
        '    If enfermedadNueva.Nombre = e.Nombre Then
        '        Throw New Exception("Ya hay una enfermedad con este nombre.")
        '    End If
        'Next

        ListaEnfermedades.Remove(enfermedadVieja)
        ListaEnfermedades.Insert(indice, enfermedadNueva)
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
    End Sub

    Public Function BuscarEnfermedades(busqueda As String, buscaSoloPorNombre As Boolean) As List(Of Enfermedad)
        Dim listaResultados As New List(Of Enfermedad)

        For Each e As Enfermedad In ListaEnfermedades
            If e.Nombre Like ("*" & busqueda & "*") Then
                listaResultados.Add(e)
            End If
            If Not buscaSoloPorNombre Then
                If e.Descripcion Like ("*" & busqueda & "*") Then
                    listaResultados.Add(e)
                End If
            End If
        Next

        Return listaResultados
    End Function

    Public Sub EliminarEnfermedad(enfermedad As Enfermedad)
        'Try
        ' Manejo de errores de argumentos
        ' enfermedad tiene un valor nulo
        If enfermedad Is Nothing Then
            Throw New ArgumentNullException("La enfermedad tiene un valor nulo.")
        End If

        ' La enfermedad a eliminar no esta almacenada
        If Not ListaEnfermedades.Contains(enfermedad) Then
            Throw New ArgumentException("Esta enfermedad no está almacenada.")
        End If

        ListaEnfermedades.Remove(enfermedad)
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
    End Sub

    Public Sub EliminarEnfermedad(indice As Integer)
        'Try
        ' Manejo de errores de argumentos
        ' El índice excede el tamaño de la colección
        If indice >= ListaEnfermedades.Count Then
            Throw New IndexOutOfRangeException("El índice indicado excede el tamaño de la colección.")
        End If

        ' El índice es negativo
        If indice < 0 Then
            Throw New IndexOutOfRangeException("El índice indicado es negativo.")
        End If

        ListaEnfermedades.RemoveAt(indice)
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
    End Sub

    Public Sub IngresarSintoma(sintoma As Sintoma)
        'Try
        ' Manejo de errores de argumentos
        ' sintoma tiene un valor nulo
        If sintoma Is Nothing Then
            Throw New ArgumentNullException("El síntoma tiene un valor nulo.")
        End If

        ' El nombre del nuevo síntoma entra en conflicto con el de otro
        For Each s As Sintoma In ListaSintomas
            If sintoma.Nombre = s.Nombre Then
                Throw New Exception("Ya hay un síntoma ingresado con este nombre.")
            End If
        Next

        ListaSintomas.Add(sintoma)
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
    End Sub

    Public Sub ModificarSintoma(sintoma As Sintoma, indiceModificado As Integer)
        Try
            If sintoma Is Nothing Then
                Throw New Exception("El síntoma tiene un valor nulo.")
            End If
            If indiceModificado >= ListaSintomas.Count Then
                Throw New Exception("El índice indicado excede el tamaño de la colección.")
            End If
            For Each s As Sintoma In ListaSintomas
                If sintoma.Nombre = s.Nombre Then
                    Throw New Exception("Ya hay un síntoma con este nombre.")
                End If
            Next

            Dim registro As Sintoma = ListaSintomas(indiceModificado)
            ModificarSintoma(registro, sintoma)
            'registro.Nombre = sintoma.Nombre
            'registro.Descripcion = sintoma.Descripcion
            'registro.Recomendaciones = sintoma.Recomendaciones
            'registro.Urgencia = sintoma.Urgencia
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ModificarSintoma(sintomaViejo As Sintoma, sintomaNuevo As Sintoma)
        Try
            If sintomaViejo Is Nothing Then
                Throw New Exception("El síntoma original tiene un valor nulo.")
            End If
            If sintomaNuevo Is Nothing Then
                Throw New Exception("El síntoma a guardar tiene un valor nulo.")
            End If
            Dim indice As Integer = -1
            For Each s As Sintoma In ListaSintomas
                If s.Nombre = sintomaViejo.Nombre Then
                    indice = ListaSintomas.IndexOf(s)
                End If
            Next
            If indice = -1 Then
                Throw New Exception("El síntoma original no está almacenado.")
            End If
            Dim cantidadNombresIguales As Integer = 0
            Dim mantieneElNombre As Boolean = sintomaViejo.Nombre = sintomaNuevo.Nombre
            For Each s As Sintoma In ListaSintomas
                If sintomaNuevo.Nombre = s.Nombre Then
                    cantidadNombresIguales += 1
                End If
            Next
            If (cantidadNombresIguales > 1 And mantieneElNombre) Or (cantidadNombresIguales > 0 And Not mantieneElNombre) Then
                Throw New Exception("Ya existe un síntoma con este nombre.")
            End If

            ListaSintomas.Remove(sintomaViejo)
            ListaSintomas.Insert(indice, sintomaNuevo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Function BuscarSintomas(busqueda As String, buscaSoloPorNombre As Boolean) As List(Of Sintoma)
        Dim listaResultados As New List(Of Sintoma)

        For Each s As Sintoma In ListaSintomas
            If s.Nombre Like ("*" & busqueda & "*") Then
                listaResultados.Add(s)
            End If
            If Not buscaSoloPorNombre Then
                If s.Descripcion Like ("*" & busqueda & "*") Then
                    listaResultados.Add(s)
                End If
            End If
        Next

        Return listaResultados
    End Function

    Public Sub EliminarSintoma(sintoma As Sintoma)
        Try
            If sintoma Is Nothing Then
                Throw New Exception("El síntoma tiene un valor nulo.")
            End If
            If Not ListaSintomas.Contains(sintoma) Then
                Throw New Exception("Este síntoma no está almacenado.")
            End If

            ListaSintomas.Remove(sintoma)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub EliminarSintoma(indice As Integer)
        Try
            If indice >= ListaSintomas.Count Then
                Throw New Exception("El índice indicado excede el tamaño de la colección.")
            End If
            If indice < 0 Then
                Throw New Exception("El índice indicado es negativo.")
            End If

            ListaSintomas.RemoveAt(indice)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub IngresarAsociacionSintoma(asociacion As AsociacionSintoma)
        Try
            If asociacion Is Nothing Then
                Throw New Exception("El valor de la asociación es nulo.")
            End If
            For Each a As AsociacionSintoma In ListaAsociacionesSintomas
                If a.NombreEnfermedad = asociacion.NombreEnfermedad And a.NombreSintoma = asociacion.NombreSintoma Then
                    Throw New Exception("El síntoma y la enfermedad indicados ya se encuentran asociados.")
                End If
            Next

            ListaAsociacionesSintomas.Add(asociacion)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ModificarAsociacionSintoma(asociacion As AsociacionSintoma, indice As Integer)
        Try
            If asociacion Is Nothing Then
                Throw New Exception("El valor de la asociación es nulo.")
            End If
            If indice >= ListaAsociacionesSintomas.Count Then
                Throw New Exception("El índice indicado excede el tamaño de la colección.")
            End If
            For Each a As AsociacionSintoma In ListaAsociacionesSintomas
                If a.NombreEnfermedad = asociacion.NombreEnfermedad And a.NombreSintoma = asociacion.NombreSintoma Then
                    Throw New Exception("El síntoma y la enfermedad indicados ya se encuentran asociados.")
                End If
            Next

            Dim registro As AsociacionSintoma = ListaAsociacionesSintomas(indice)
            ModificarAsociacionSintoma(registro, asociacion)
            'registro.NombreEnfermedad = asociacion.NombreEnfermedad
            'registro.NombreSintoma = asociacion.NombreSintoma
            'registro.Frecuencia = asociacion.Frecuencia
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ModificarAsociacionSintoma(asociacionVieja As AsociacionSintoma, asociacionNueva As AsociacionSintoma)
        Try
            If asociacionVieja Is Nothing Then
                Throw New Exception("La asociación de síntoma original tiene un valor nulo")
            End If
            If asociacionVieja Is Nothing Then
                Throw New Exception("La asociación de síntoma a guardar tiene un valor nulo")
            End If
            Dim indice As Integer = -1
            For Each a As AsociacionSintoma In ListaAsociacionesSintomas
                If a.NombreEnfermedad = asociacionVieja.NombreEnfermedad And a.NombreSintoma = asociacionVieja.NombreSintoma Then
                    indice = ListaAsociacionesSintomas.IndexOf(a)
                End If
            Next
            If indice = -1 Then
                Throw New Exception("La asociación de síntoma original no está almacenada.")
            End If
            Dim cantidadAsociacionesIguales As Integer = 0
            Dim mantieneLaAsociacion As Boolean = (asociacionVieja.NombreEnfermedad = asociacionNueva.NombreEnfermedad And asociacionVieja.NombreSintoma = asociacionNueva.NombreSintoma)
            For Each a As AsociacionSintoma In ListaAsociacionesSintomas
                If asociacionNueva.NombreEnfermedad = a.NombreEnfermedad And asociacionNueva.NombreSintoma = a.NombreSintoma Then
                    cantidadAsociacionesIguales += 1
                End If
            Next
            If (cantidadAsociacionesIguales > 1 And mantieneLaAsociacion) Or (cantidadAsociacionesIguales > 0 And Not mantieneLaAsociacion) Then
                Throw New Exception("Ya existe una asociación entre este síntoma y esta enfermedad.")
            End If

            ListaAsociacionesSintomas.Remove(asociacionVieja)
            ListaAsociacionesSintomas.Insert(indice, asociacionNueva)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Function BuscarAsociacionesSintomas(sintoma As Sintoma) As List(Of AsociacionSintoma)
        Dim listaResultados As New List(Of AsociacionSintoma)

        For Each a As AsociacionSintoma In ListaAsociacionesSintomas
            If a.NombreSintoma = sintoma.Nombre Then
                listaResultados.Add(a)
            End If
        Next

        Return listaResultados
    End Function

    Public Function BuscarAsociacionesSintomas(enfermedad As Enfermedad) As List(Of AsociacionSintoma)
        Dim listaResultados As New List(Of AsociacionSintoma)

        For Each a As AsociacionSintoma In ListaAsociacionesSintomas
            If a.NombreEnfermedad = enfermedad.Nombre Then
                listaResultados.Add(a)
            End If
        Next

        Return listaResultados
    End Function

    Public Sub EliminarAsociacionSintoma(asociacion As AsociacionSintoma)
        For Each a As AsociacionSintoma In ListaAsociacionesSintomas.ToList
            If a.NombreEnfermedad = asociacion.NombreEnfermedad And a.NombreSintoma = asociacion.NombreSintoma Then
                ListaAsociacionesSintomas.Remove(asociacion)
            End If
        Next
    End Sub

    Public Sub EliminarAsociacionSintoma(sintoma As Sintoma)
        For Each a As AsociacionSintoma In ListaAsociacionesSintomas.ToList
            If a.NombreSintoma = sintoma.Nombre Then
                ListaAsociacionesSintomas.Remove(a)
            End If
        Next
    End Sub

    Public Sub EliminarAsociacionSintoma(enfermedad As Enfermedad)
        For Each a As AsociacionSintoma In ListaAsociacionesSintomas.ToList
            If a.NombreEnfermedad = enfermedad.Nombre Then
                ListaAsociacionesSintomas.Remove(a)
            End If
        Next
    End Sub

    Public Sub IngresarUsuarioPaciente(usuarioPaciente As Usuario_Paciente)
        Try
            If usuarioPaciente Is Nothing Then
                Throw New Exception("El usuario de paciente tiene un valor nulo.")
            End If
            For Each u As Usuario_Paciente In ListaUsuariosPacientes
                If usuarioPaciente.CI_Paciente = u.CI_Paciente Then
                    Throw New Exception("Ya hay un usuario de paciente con esta cédula.")
                End If
            Next

            ListaUsuariosPacientes.Add(usuarioPaciente)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ModificarUsuarioPaciente(usuarioPaciente As Usuario_Paciente, indiceModificado As Integer)
        Try
            If usuarioPaciente Is Nothing Then
                Throw New Exception("El usuario de paciente tiene un valor nulo.")
            End If
            If indiceModificado >= ListaUsuariosPacientes.Count Then
                Throw New Exception("El índice indicado excede el tamaño de la colección.")
            End If
            For Each u As Usuario_Paciente In ListaUsuariosPacientes
                If usuarioPaciente.CI_Paciente = u.CI_Paciente Then
                    Throw New Exception("Ya hay un usuario de paciente con esta cédula.")
                End If
            Next

            Dim registro As Usuario_Paciente = ListaUsuariosPacientes(indiceModificado)
            ModificarUsuarioPaciente(registro, usuarioPaciente)
            'registro.CI_Paciente = usuarioPaciente.CI_Paciente
            'registro.Contrasena = usuarioPaciente.Contrasena
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ModificarUsuarioPaciente(usuarioPacienteViejo As Usuario_Paciente, usuarioPacienteNuevo As Usuario_Paciente)
        Try
            If usuarioPacienteViejo Is Nothing Then
                Throw New Exception("El usuario de paciente original tiene un valor nulo")
            End If
            If usuarioPacienteViejo Is Nothing Then
                Throw New Exception("El usuario de paciente a guardar tiene un valor nulo")
            End If
            Dim indice As Integer = -1
            For Each u As Usuario_Paciente In ListaUsuariosPacientes
                If u.CI_Paciente = usuarioPacienteViejo.CI_Paciente Then
                    indice = ListaUsuariosPacientes.IndexOf(u)
                End If
            Next
            If indice = -1 Then
                Throw New Exception("El usuario de paciente original no está almacenada.")
            End If
            Dim cantidadCedulasIguales As Integer = 0
            Dim mantieneLaCedula As Boolean = usuarioPacienteViejo.CI_Paciente = usuarioPacienteNuevo.CI_Paciente
            For Each u As Usuario_Paciente In ListaUsuariosPacientes
                If usuarioPacienteNuevo.CI_Paciente = u.CI_Paciente Then
                    cantidadCedulasIguales += 1
                End If
            Next
            If (cantidadCedulasIguales > 1 And mantieneLaCedula) Or (cantidadCedulasIguales > 0 And Not mantieneLaCedula) Then
                Throw New Exception("Ya existe un usuario de paciente con esta cédula.")
            End If
            'For Each e As Enfermedad In ListaEnfermedades
            '    If enfermedadNueva.Nombre = e.Nombre Then
            '        Throw New Exception("Ya hay una enfermedad con este nombre.")
            '    End If
            'Next

            ListaUsuariosPacientes.Remove(usuarioPacienteViejo)
            ListaUsuariosPacientes.Insert(indice, usuarioPacienteNuevo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Function BuscarUsuariosPacientes(busqueda As String) As List(Of Usuario_Paciente)
        Dim listaResultados As New List(Of Usuario_Paciente)

        For Each u As Usuario_Paciente In ListaUsuariosPacientes
            If u.CI_Paciente Like ("*" & busqueda & "*") Then
                listaResultados.Add(u)
            End If
        Next

        Return listaResultados
    End Function

    Public Sub EliminarUsuarioPaciente(usuarioPaciente As Usuario_Paciente)
        Try
            If usuarioPaciente Is Nothing Then
                Throw New Exception("El usuario de paciente tiene un valor nulo.")
            End If
            If Not ListaUsuariosPacientes.Contains(usuarioPaciente) Then
                Throw New Exception("Este usuario de paciente no está almacenado.")
            End If

            ListaUsuariosPacientes.Remove(usuarioPaciente)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub EliminarUsuarioPaciente(indice As Integer)
        Try
            If indice >= ListaUsuariosPacientes.Count Then
                Throw New Exception("El índice indicado excede el tamaño de la colección.")
            End If
            If indice < 0 Then
                Throw New Exception("El índice indicado es negativo.")
            End If

            ListaUsuariosPacientes.RemoveAt(indice)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub IngresarUsuarioAdministrativo(usuarioAdministrativo As Usuario_Administrativo)
        Try
            If usuarioAdministrativo Is Nothing Then
                Throw New Exception("El usuario de administrativo tiene un valor nulo.")
            End If
            For Each u As Usuario_Administrativo In ListaUsuariosAdministrativos
                If usuarioAdministrativo.CI_Administrativo = u.CI_Administrativo Then
                    Throw New Exception("Ya hay un usuario de administrativo con esta cédula.")
                End If
            Next

            ListaUsuariosAdministrativos.Add(usuarioAdministrativo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ModificarUsuarioAdministrativo(usuarioAdministrativo As Usuario_Administrativo, indiceModificado As Integer)
        Try
            If usuarioAdministrativo Is Nothing Then
                Throw New Exception("El usuario de administrativo tiene un valor nulo.")
            End If
            If indiceModificado >= ListaUsuariosAdministrativos.Count Then
                Throw New Exception("El índice indicado excede el tamaño de la colección.")
            End If
            For Each u As Usuario_Administrativo In ListaUsuariosAdministrativos
                If usuarioAdministrativo.CI_Administrativo = u.CI_Administrativo Then
                    Throw New Exception("Ya hay un usuario de administrativo con esta cédula.")
                End If
            Next

            Dim registro As Usuario_Administrativo = ListaUsuariosAdministrativos(indiceModificado)
            'Dim nuevoUsuarioAdministrativo As New Usuario_Administrativo(Usuario)
            ModificarUsuarioAdministrativo(registro, usuarioAdministrativo)
            'registro.CI_Administrativo = usuarioAdministrativo.CI_Administrativo
            'registro.Contrasena = usuarioAdministrativo.Contrasena
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ModificarUsuarioAdministrativo(usuarioAdministrativoViejo As Usuario_Administrativo, usuarioAdministrativoNuevo As Usuario_Administrativo)
        Try
            If usuarioAdministrativoViejo Is Nothing Then
                Throw New Exception("El usuario administrativo original tiene un valor nulo")
            End If
            If usuarioAdministrativoViejo Is Nothing Then
                Throw New Exception("El usuario administrativo a guardar tiene un valor nulo")
            End If
            Dim indice As Integer = -1
            For Each u As Usuario_Administrativo In ListaUsuariosAdministrativos
                If u.CI_Administrativo = usuarioAdministrativoViejo.CI_Administrativo Then
                    indice = ListaUsuariosAdministrativos.IndexOf(u)
                End If
            Next
            If indice = -1 Then
                Throw New Exception("El usuario administrativo original no está almacenada.")
            End If
            Dim cantidadCedulasIguales As Integer = 0
            Dim mantieneLaCedula As Boolean = usuarioAdministrativoViejo.CI_Administrativo = usuarioAdministrativoNuevo.CI_Administrativo
            For Each u As Usuario_Administrativo In ListaUsuariosAdministrativos
                If usuarioAdministrativoNuevo.CI_Administrativo = u.CI_Administrativo Then
                    cantidadCedulasIguales += 1
                End If
            Next
            If (cantidadCedulasIguales > 1 And mantieneLaCedula) Or (cantidadCedulasIguales > 0 And Not mantieneLaCedula) Then
                Throw New Exception("Ya existe un usuario administrativo con esta cédula.")
            End If
            'For Each e As Enfermedad In ListaEnfermedades
            '    If enfermedadNueva.Nombre = e.Nombre Then
            '        Throw New Exception("Ya hay una enfermedad con este nombre.")
            '    End If
            'Next

            ListaUsuariosAdministrativos.Remove(usuarioAdministrativoViejo)
            ListaUsuariosAdministrativos.Insert(indice, usuarioAdministrativoNuevo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Function BuscarUsuariosAdministrativos(busqueda As String) As List(Of Usuario_Administrativo)
        Dim listaResultados As New List(Of Usuario_Administrativo)

        For Each u As Usuario_Administrativo In ListaUsuariosAdministrativos
            If u.CI_Administrativo Like ("*" & busqueda & "*") Then
                listaResultados.Add(u)
            End If
        Next

        Return listaResultados
    End Function

    Public Sub EliminarUsuarioAdministrativo(usuarioAdministrativo As Usuario_Administrativo)
        Try
            If usuarioAdministrativo Is Nothing Then
                Throw New Exception("El usuario de administrativo tiene un valor nulo.")
            End If
            If Not ListaUsuariosAdministrativos.Contains(usuarioAdministrativo) Then
                Throw New Exception("Este usuario de administrativo no está almacenado.")
            End If

            ListaUsuariosAdministrativos.Remove(usuarioAdministrativo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub EliminarUsuarioAdministrativo(indice As Integer)
        Try
            If indice >= ListaUsuariosAdministrativos.Count Then
                Throw New Exception("El índice indicado excede el tamaño de la colección.")
            End If
            If indice < 0 Then
                Throw New Exception("El índice indicado es negativo.")
            End If

            ListaUsuariosAdministrativos.RemoveAt(indice)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub GenerarDatos()
        ListaEnfermedades.Add(New Enfermedad("Gripe leve", "Reposo", 40, "Tos y mocos"))
        ListaEnfermedades.Add(New Enfermedad("Hipertension", "Comer sin sal", 50, "Presion alta"))
        ListaEnfermedades.Add(New Enfermedad("Sobrepeso", "Hacer ejercicio", 20, "IMC mayor a 25"))

        ListaSintomas.Add(New Sintoma("Tos", "Es un mecanismo de defensa de nuestro organismo. Protege las vías respiratorias dejándolas limpias para respirar con normalidad.", "Mantenerse caliente y tomar miel", 10))
        ListaSintomas.Add(New Sintoma("Dolor de cabeza", "Dolor de muñeca", "Hielo en zona", 60))
        ListaSintomas.Add(New Sintoma("Resfriado", "Infección viral aguda del tracto respiratorio", "Mantenerse caliente y tomar té con miel", 20))

        ListaAsociacionesSintomas.Add(New AsociacionSintoma("Gripe leve", "Tos", 50))

        ListaUsuariosPacientes.Add(New Usuario_Paciente("51712272", "republica"))
        ListaUsuariosPacientes.Add(New Usuario_Paciente("50681129", "constelaciones"))
        ListaUsuariosPacientes.Add(New Usuario_Paciente("18727593", "informatica"))

        ListaUsuariosAdministrativos.Add(New Usuario_Administrativo("19174761", "nashe"))
        ListaUsuariosAdministrativos.Add(New Usuario_Administrativo("12071061", "televisor"))
        ListaUsuariosAdministrativos.Add(New Usuario_Administrativo("51593248", "teclado"))
    End Sub
End Module
