Public Module Principal
    ' Listas que almacenan en memoria la información ingresada en el sistema
    Friend ListaEnfermedades As New List(Of Enfermedad)
    Friend ListaSintomas As New List(Of Sintoma)
    Friend ListaAsociacionesSintomas As New List(Of AsociacionSintoma)
    Friend ListaUsuariosPacientes As New List(Of Usuario_Paciente)
    Friend ListaUsuariosAdministrativos As New List(Of Usuario_Administrativo)

    Sub Main()

    End Sub

    ' Ingresa una enfermedad en el sistema
    Public Sub IngresarEnfermedad(enfermedad As Enfermedad)
        ' Manejo de errores de argumentos
        ' enfermedad tiene un valor nulo
        If enfermedad Is Nothing Then
            Throw New ArgumentNullException("enfermedad", "La enfermedad tiene un valor nulo.")
        End If

        ' Se intenta insertar una enfermedad con un nombre duplicado
        For Each e As Enfermedad In ListaEnfermedades
            If enfermedad.Nombre = e.Nombre Then
                Throw New ArgumentException("Ya hay una enfermedad con este nombre.")
            End If
        Next

        ListaEnfermedades.Add(enfermedad)
    End Sub

    ' Sustituye la enfermedad del índice especificado por la ingresada
    Public Sub ModificarEnfermedad(enfermedad As Enfermedad, indice As Integer)
        ' Manejo de errores de argumentos
        ' enfermedad tiene un valor nulo
        If enfermedad Is Nothing Then
            Throw New ArgumentNullException("enfermedad", "La enfermedad tiene un valor nulo.")
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
        ModificarEnfermedad(registro, enfermedad)
    End Sub

    ' Sustituye enfermedadVieja por enfermedadNueva en el sistema
    Public Sub ModificarEnfermedad(enfermedadVieja As Enfermedad, enfermedadNueva As Enfermedad)
        ' Manejo de errores de argumentos
        ' enfermedadVieja tiene un valor nulo
        If enfermedadVieja Is Nothing Then
            Throw New ArgumentNullException("enfermedadVieja", "La enfermedad original tiene un valor nulo")
        End If

        ' enfermedadNueva tiene un valor nulo
        If enfermedadNueva Is Nothing Then
            Throw New ArgumentNullException("enfermedadNueva", "La enfermedad a guardar tiene un valor nulo")
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

        ListaEnfermedades.Remove(enfermedadVieja)
        For Each asociacionVieja As AsociacionSintoma In BuscarAsociacionesSintomas(enfermedadVieja).ToList
            Dim asociacionModificada As New AsociacionSintoma(enfermedadNueva.Nombre, asociacionVieja.NombreSintoma, asociacionVieja.Frecuencia)
            ModificarAsociacionSintoma(asociacionVieja, asociacionModificada)
        Next
        ListaEnfermedades.Insert(indice, enfermedadNueva)
    End Sub

    ' Retorna una lista con las enfermedades cuyo nombre coincide con un filtro de texto.
    ' Alternativamente, permite buscar también en las descripciones de las enfermedades almacenadas.
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

    ' Elimina una enfermedad de la lista
    Public Sub EliminarEnfermedad(enfermedad As Enfermedad)
        ' Manejo de errores de argumentos
        ' enfermedad tiene un valor nulo
        If enfermedad Is Nothing Then
            Throw New ArgumentNullException("enfermedad", "La enfermedad tiene un valor nulo.")
        End If

        ' La enfermedad a eliminar no esta almacenada
        If Not ListaEnfermedades.Contains(enfermedad) Then
            Throw New ArgumentException("Esta enfermedad no está almacenada.")
        End If

        ListaEnfermedades.Remove(enfermedad)
    End Sub

    ' Elimina la enfermedad en el índice especificado de la lista
    Public Sub EliminarEnfermedad(indice As Integer)
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
    End Sub

    ' Ingresa un nuevo síntoma en el sistema
    Public Sub IngresarSintoma(sintoma As Sintoma)
        ' Manejo de errores de argumentos
        ' sintoma tiene un valor nulo
        If sintoma Is Nothing Then
            Throw New ArgumentNullException("sintoma", "El síntoma tiene un valor nulo.")
        End If

        ' El nombre del nuevo síntoma entra en conflicto con el de otro
        For Each s As Sintoma In ListaSintomas
            If sintoma.Nombre = s.Nombre Then
                Throw New Exception("Ya hay un síntoma ingresado con este nombre.")
            End If
        Next

        ListaSintomas.Add(sintoma)
    End Sub

    ' Sustituye el síntoma del índice especificado por el ingresado
    Public Sub ModificarSintoma(sintoma As Sintoma, indice As Integer)
        ' Manejo de errores de argumentos
        ' sintoma tiene un valor nulo
        If sintoma Is Nothing Then
            Throw New ArgumentNullException("sintoma", "El síntoma tiene un valor nulo.")
        End If

        ' El índice excede el tamaño de la colección
        If indice >= ListaSintomas.Count Then
            Throw New IndexOutOfRangeException("El índice indicado excede el tamaño de la colección.")
        End If

        ' El índice es negativo
        If indice < 0 Then
            Throw New IndexOutOfRangeException("El índice indicado es negativo.")
        End If

        ' El nombre del nuevo síntoma entra en conflicto con el de otro
        For Each s As Sintoma In ListaSintomas
            If sintoma.Nombre = s.Nombre Then
                Throw New ArgumentException("Ya hay un síntoma con este nombre.")
            End If
        Next

        Dim registro As Sintoma = ListaSintomas(indice)
        ModificarSintoma(registro, sintoma)
    End Sub

    ' Sustituye sintomaViejo por sintomaNuevo en el sistema
    Public Sub ModificarSintoma(sintomaViejo As Sintoma, sintomaNuevo As Sintoma)
        ' Manejo de errores de argumentos
        ' sintomaViejo tiene un valor nulo
        If sintomaViejo Is Nothing Then
            Throw New ArgumentNullException("sintomaViejo", "El síntoma original tiene un valor nulo.")
        End If

        ' sintomaNuevo tiene un valor nulo
        If sintomaNuevo Is Nothing Then
            Throw New ArgumentNullException("sintomaNuevo", "El síntoma a guardar tiene un valor nulo.")
        End If

        ' El síntoma a modificar no existe en la colección
        Dim indice As Integer = -1
        For Each s As Sintoma In ListaSintomas
            If s.Nombre = sintomaViejo.Nombre Then
                indice = ListaSintomas.IndexOf(s)
            End If
        Next
        If indice = -1 Then
            Throw New ArgumentException("El síntoma original no está almacenado.")
        End If

        ' El nombre del nuevo síntoma entra en conflicto con el de otro
        Dim cantidadNombresIguales As Integer = 0
        Dim mantieneElNombre As Boolean = sintomaViejo.Nombre = sintomaNuevo.Nombre
        For Each s As Sintoma In ListaSintomas
            If sintomaNuevo.Nombre = s.Nombre Then
                cantidadNombresIguales += 1
            End If
        Next
        If (cantidadNombresIguales > 1 And mantieneElNombre) Or (cantidadNombresIguales > 0 And Not mantieneElNombre) Then
            Throw New ArgumentException("Ya existe un síntoma con este nombre.")
        End If

        ListaSintomas.Remove(sintomaViejo)
        ListaSintomas.Insert(indice, sintomaNuevo)
    End Sub

    ' Retorna una lista con los síntomas cuyo nombre coincide con un filtro de texto.
    ' Alternativamente, permite buscar también en las descripciones de los síntomas almacenados.
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

    ' Elimina un síntoma de la lista
    Public Sub EliminarSintoma(sintoma As Sintoma)
        ' Manejo de errores de argumentos
        ' sintoma tiene un valor nulo
        If sintoma Is Nothing Then
            Throw New ArgumentNullException("sintoma", "El síntoma tiene un valor nulo.")
        End If

        ' El síntoma no existe en la colección
        If Not ListaSintomas.Contains(sintoma) Then
            Throw New ArgumentException("Este síntoma no está almacenado.")
        End If

        ListaSintomas.Remove(sintoma)
    End Sub

    ' Elimina el síntoma en el índice especificado de la lista
    Public Sub EliminarSintoma(indice As Integer)
        ' Manejo de errores de argumentos
        ' El índice excede el tamaño de la colección
        If indice >= ListaSintomas.Count Then
            Throw New IndexOutOfRangeException("El índice indicado excede el tamaño de la colección.")
        End If

        ' El índice es negativo
        If indice < 0 Then
            Throw New IndexOutOfRangeException("El índice indicado es negativo.")
        End If

        ListaSintomas.RemoveAt(indice)
    End Sub

    ' Ingresa una asociación entre un síntoma y una enfermedad en el sistema
    Public Sub IngresarAsociacionSintoma(asociacion As AsociacionSintoma)
        ' Manejo de errores de argumentos
        ' asociacion tiene un valor nulo
        If asociacion Is Nothing Then
            Throw New ArgumentNullException("asociacion", "El valor de la asociación es nulo.")
        End If

        ' Ya existe una asociación similar
        For Each a As AsociacionSintoma In ListaAsociacionesSintomas
            If a.NombreEnfermedad = asociacion.NombreEnfermedad And a.NombreSintoma = asociacion.NombreSintoma Then
                Throw New ArgumentException("El síntoma y la enfermedad indicados ya se encuentran asociados.")
            End If
        Next

        ListaAsociacionesSintomas.Add(asociacion)
    End Sub

    ' Sustituye la asociación del índice especificado por la ingresada
    Public Sub ModificarAsociacionSintoma(asociacion As AsociacionSintoma, indice As Integer)
        ' Manejo de errores de argumentos
        ' asociacion tiene un valor nulo
        If asociacion Is Nothing Then
            Throw New ArgumentNullException("asociacion", "El valor de la asociación es nulo.")
        End If

        ' El índice excede el tamaño de la colección
        If indice >= ListaAsociacionesSintomas.Count Then
            Throw New IndexOutOfRangeException("El índice indicado excede el tamaño de la colección.")
        End If

        ' El índice es negativo
        If indice < 0 Then
            Throw New IndexOutOfRangeException("El índice especificado es negativo.")
        End If

        ' Ya existe una asociación similar
        For Each a As AsociacionSintoma In ListaAsociacionesSintomas
            If a.NombreEnfermedad = asociacion.NombreEnfermedad And a.NombreSintoma = asociacion.NombreSintoma Then
                Throw New ArgumentException("El síntoma y la enfermedad indicados ya se encuentran asociados.")
            End If
        Next

        Dim registro As AsociacionSintoma = ListaAsociacionesSintomas(indice)
        ModificarAsociacionSintoma(registro, asociacion)
    End Sub

    ' Sustituye asociacionVieja por asociacionNueva en el sistema
    Public Sub ModificarAsociacionSintoma(asociacionVieja As AsociacionSintoma, asociacionNueva As AsociacionSintoma)
        ' Manejo de errores de argumentos
        ' asociacionVieja tiene un valor nulo
        If asociacionVieja Is Nothing Then
            Throw New ArgumentNullException("asociacionVieja", "La asociación de síntoma original tiene un valor nulo")
        End If

        ' asociacionNueva tiene un valor nulo
        If asociacionNueva Is Nothing Then
            Throw New ArgumentNullException("asociacionNueva", "La asociación de síntoma a guardar tiene un valor nulo")
        End If

        ' La asociación a modificar no existe
        Dim indice As Integer = -1
        For Each a As AsociacionSintoma In ListaAsociacionesSintomas
            If a.NombreEnfermedad = asociacionVieja.NombreEnfermedad And a.NombreSintoma = asociacionVieja.NombreSintoma Then
                indice = ListaAsociacionesSintomas.IndexOf(a)
            End If
        Next
        If indice = -1 Then
            Throw New ArgumentException("La asociación de síntoma original no está almacenada.")
        End If

        ' Ya existe una asociación similar
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
    End Sub

    ' Retorna una lista con las asociaciones que involucran a un síntoma determinado
    Public Function BuscarAsociacionesSintomas(sintoma As Sintoma) As List(Of AsociacionSintoma)
        Dim listaResultados As New List(Of AsociacionSintoma)

        For Each a As AsociacionSintoma In ListaAsociacionesSintomas
            If a.NombreSintoma = sintoma.Nombre Then
                listaResultados.Add(a)
            End If
        Next

        Return listaResultados
    End Function

    ' Retorna una lista con las asociaciones que involucran a una enfermedad determinada
    Public Function BuscarAsociacionesSintomas(enfermedad As Enfermedad) As List(Of AsociacionSintoma)
        Dim listaResultados As New List(Of AsociacionSintoma)

        For Each a As AsociacionSintoma In ListaAsociacionesSintomas
            If a.NombreEnfermedad = enfermedad.Nombre Then
                listaResultados.Add(a)
            End If
        Next

        Return listaResultados
    End Function

    ' Indica la frecuencia con la que un síntoma determinado se presenta en una enfermedad determinada
    Public Function ObtenerFrecuencia(e As Enfermedad, s As Sintoma) As Decimal
        'Manejo de errores de argumentos
        ' e tiene un valor nulo
        If e Is Nothing Then
            Throw New ArgumentNullException("e", "La enfermedad tiene un valor nulo.")
        End If

        ' s tiene un valor nulo
        If s Is Nothing Then
            Throw New ArgumentNullException("s", "El síntoma tiene un valor nulo.")
        End If

        Dim frecuencia As Decimal = Nothing
        For Each a As AsociacionSintoma In ListaAsociacionesSintomas
            If a.NombreEnfermedad = e.Nombre And a.NombreSintoma = s.Nombre Then
                frecuencia = a.Frecuencia
            End If
        Next

        ' No se encontró una asociación entre el síntoma y la enfermedad especificados
        If frecuencia = Nothing Then
            Throw New ArgumentException("No existe ninguna asociación entre el síntoma y la enfermedad especificados.")
        End If

        Return frecuencia
    End Function

    ' Elimina una asociación de la lista
    Public Sub EliminarAsociacionSintoma(asociacion As AsociacionSintoma)
        ' Manejo de errores de argumentos
        ' asociacion tiene un valor nulo
        If asociacion Is Nothing Then
            Throw New ArgumentNullException("asociacion", "La asociación tiene un valor nulo.")
        End If

        For Each a As AsociacionSintoma In ListaAsociacionesSintomas.ToList
            If a.NombreEnfermedad = asociacion.NombreEnfermedad And a.NombreSintoma = asociacion.NombreSintoma Then
                ListaAsociacionesSintomas.Remove(asociacion)
            End If
        Next
    End Sub

    ' Desvincula un síntoma determinado de todas las enfermedades con las que pudiera tener una asociación
    Public Sub EliminarAsociacionSintoma(sintoma As Sintoma)
        ' Manejo de errores de argumentos
        ' sintoma tiene un valor nulo
        If sintoma Is Nothing Then
            Throw New ArgumentNullException("sintoma", "El síntoma tiene un valor nulo.")
        End If

        For Each a As AsociacionSintoma In ListaAsociacionesSintomas.ToList
            If a.NombreSintoma = sintoma.Nombre Then
                ListaAsociacionesSintomas.Remove(a)
            End If
        Next
    End Sub

    ' Desvincula una enfermedad determinada de todos los síntomas con los que pudiera tener una asociación
    Public Sub EliminarAsociacionSintoma(enfermedad As Enfermedad)
        ' Manejo de errores de argumentos
        ' enfermedad tiene un valor nulo
        If enfermedad Is Nothing Then
            Throw New ArgumentNullException("enfermedad", "La enfermedad tiene un valor nulo.")
        End If

        For Each a As AsociacionSintoma In ListaAsociacionesSintomas.ToList
            If a.NombreEnfermedad = enfermedad.Nombre Then
                ListaAsociacionesSintomas.Remove(a)
            End If
        Next
    End Sub

    ' Ingresa un nuevo usuario de paciente en el sistema
    Public Sub IngresarUsuarioPaciente(usuarioPaciente As Usuario_Paciente)
        ' Manejo de errores de argumentos
        ' usuarioPaciente tiene un valor nulo
        If usuarioPaciente Is Nothing Then
            Throw New ArgumentNullException("usuarioPaciente", "El usuario de paciente tiene un valor nulo.")
        End If

        ' El usuario ya existe
        For Each u As Usuario_Paciente In ListaUsuariosPacientes
            If usuarioPaciente.CI_Paciente = u.CI_Paciente Then
                Throw New ArgumentException("Ya hay un usuario de paciente con esta cédula.")
            End If
        Next

        ListaUsuariosPacientes.Add(usuarioPaciente)
    End Sub

    ' Sustituye el usuario de paciente del índice especificado por el ingresado
    Public Sub ModificarUsuarioPaciente(usuarioPaciente As Usuario_Paciente, indiceModificado As Integer)
        ' Manejo de errores de argumentos
        ' usuarioPaciente tiene un valor nulo
        If usuarioPaciente Is Nothing Then
            Throw New ArgumentNullException("usuarioPaciente", "El usuario de paciente tiene un valor nulo.")
        End If

        ' El índice excede el tamaño de la colección
        If indiceModificado >= ListaUsuariosPacientes.Count Then
            Throw New IndexOutOfRangeException("El índice indicado excede el tamaño de la colección.")
        End If

        ' El índice es negativo
        If indiceModificado < 0 Then
            Throw New IndexOutOfRangeException("El índice especificado es negativo.")
        End If

        ' Ya existe un usuario para esta cédula
        For Each u As Usuario_Paciente In ListaUsuariosPacientes
            If usuarioPaciente.CI_Paciente = u.CI_Paciente Then
                Throw New ArgumentException("Ya hay un usuario de paciente con esta cédula.")
            End If
        Next

        Dim registro As Usuario_Paciente = ListaUsuariosPacientes(indiceModificado)
        ModificarUsuarioPaciente(registro, usuarioPaciente)
    End Sub

    ' Sustituye usuarioPacienteViejo por usuarioPacienteNuevo en el sistema
    Public Sub ModificarUsuarioPaciente(usuarioPacienteViejo As Usuario_Paciente, usuarioPacienteNuevo As Usuario_Paciente)
        ' Manejo de errores de argumentos
        ' usuarioPacienteViejo tiene un valor nulo
        If usuarioPacienteViejo Is Nothing Then
            Throw New ArgumentNullException("usuarioPaciente", "El usuario de paciente original tiene un valor nulo")
        End If

        ' usuarioPacienteNuevo tiene un valor nulo
        If usuarioPacienteViejo Is Nothing Then
            Throw New ArgumentNullException("usuarioPaciente", "El usuario de paciente a guardar tiene un valor nulo")
        End If

        ' El usuario a modificar no existe
        Dim indice As Integer = -1
        For Each u As Usuario_Paciente In ListaUsuariosPacientes
            If u.CI_Paciente = usuarioPacienteViejo.CI_Paciente Then
                indice = ListaUsuariosPacientes.IndexOf(u)
            End If
        Next
        If indice = -1 Then
            Throw New ArgumentException("El usuario de paciente original no está almacenada.")
        End If

        ' Ya existe un usuario con la nueva cédula
        Dim cantidadCedulasIguales As Integer = 0
        Dim mantieneLaCedula As Boolean = usuarioPacienteViejo.CI_Paciente = usuarioPacienteNuevo.CI_Paciente
        For Each u As Usuario_Paciente In ListaUsuariosPacientes
            If usuarioPacienteNuevo.CI_Paciente = u.CI_Paciente Then
                cantidadCedulasIguales += 1
            End If
        Next
        If (cantidadCedulasIguales > 1 And mantieneLaCedula) Or (cantidadCedulasIguales > 0 And Not mantieneLaCedula) Then
            Throw New ArgumentException("Ya existe un usuario de paciente con esta cédula.")
        End If

        ListaUsuariosPacientes.Remove(usuarioPacienteViejo)
        ListaUsuariosPacientes.Insert(indice, usuarioPacienteNuevo)
    End Sub

    ' Retorna una lista de todos los usuarios de pacientes cuya cédula coincide con un filtro de texto
    Public Function BuscarUsuariosPacientes(busqueda As String) As List(Of Usuario_Paciente)
        Dim listaResultados As New List(Of Usuario_Paciente)

        For Each u As Usuario_Paciente In ListaUsuariosPacientes
            If u.CI_Paciente Like ("*" & busqueda & "*") Then
                listaResultados.Add(u)
            End If
        Next

        Return listaResultados
    End Function

    ' Elimina un usuario de paciente de la lista
    Public Sub EliminarUsuarioPaciente(usuarioPaciente As Usuario_Paciente)
        ' Manejo de errores de argumentos
        ' usuarioPaciente tiene un valor nulo
        If usuarioPaciente Is Nothing Then
            Throw New ArgumentNullException("usuarioPaciente", "El usuario de paciente tiene un valor nulo.")
        End If

        ' El usuario no existe
        If Not ListaUsuariosPacientes.Contains(usuarioPaciente) Then
            Throw New ArgumentException("Este usuario de paciente no está almacenado.")
        End If

        ListaUsuariosPacientes.Remove(usuarioPaciente)
    End Sub

    ' Elimina el usuario de paciente en el índice especificado de la lista
    Public Sub EliminarUsuarioPaciente(indice As Integer)
        ' Manejo de errores de argumentos
        ' El índice excede el tamaño de la colección
        If indice >= ListaUsuariosPacientes.Count Then
            Throw New IndexOutOfRangeException("El índice indicado excede el tamaño de la colección.")
        End If

        ' El índice es negativo
        If indice < 0 Then
            Throw New IndexOutOfRangeException("El índice indicado es negativo.")
        End If

        ListaUsuariosPacientes.RemoveAt(indice)
    End Sub

    ' Ingresa un nuevo usuario de administrativo en el sistema
    Public Sub IngresarUsuarioAdministrativo(usuarioAdministrativo As Usuario_Administrativo)
        ' Manejo de errores de argumentos
        ' usuarioAdministrativo tiene un valor nulo
        If usuarioAdministrativo Is Nothing Then
            Throw New ArgumentNullException("usuarioAdministrativo", "El usuario de administrativo tiene un valor nulo.")
        End If

        ' Ya existe un usuario para esta cédula
        For Each u As Usuario_Administrativo In ListaUsuariosAdministrativos
            If usuarioAdministrativo.CI_Administrativo = u.CI_Administrativo Then
                Throw New ArgumentException("Ya hay un usuario de administrativo con esta cédula.")
            End If
        Next

        ListaUsuariosAdministrativos.Add(usuarioAdministrativo)
    End Sub

    ' Sustituye el usuario de administrativo del índice especificado por el ingresado
    Public Sub ModificarUsuarioAdministrativo(usuarioAdministrativo As Usuario_Administrativo, indiceModificado As Integer)
        ' Manejo de errores de argumentos
        ' usuarioAdministrativo tiene un valor nulo
        If usuarioAdministrativo Is Nothing Then
            Throw New ArgumentNullException("usuarioAdministrativo", "El usuario de administrativo tiene un valor nulo.")
        End If

        ' El índice excede el tamaño de la colección
        If indiceModificado >= ListaUsuariosAdministrativos.Count Then
            Throw New IndexOutOfRangeException("El índice indicado excede el tamaño de la colección.")
        End If

        ' El índice es negativo
        If indiceModificado < 0 Then
            Throw New IndexOutOfRangeException("El índice indicado es negativo.")
        End If

        ' Ya existe un usuario con esta cédula
        For Each u As Usuario_Administrativo In ListaUsuariosAdministrativos
            If usuarioAdministrativo.CI_Administrativo = u.CI_Administrativo Then
                Throw New ArgumentException("Ya hay un usuario de administrativo con esta cédula.")
            End If
        Next

        Dim registro As Usuario_Administrativo = ListaUsuariosAdministrativos(indiceModificado)
        ModificarUsuarioAdministrativo(registro, usuarioAdministrativo)
    End Sub

    ' Sustituye usuarioAdministrativoViejo por usuarioAdministrativoNuevo en el sistema
    Public Sub ModificarUsuarioAdministrativo(usuarioAdministrativoViejo As Usuario_Administrativo, usuarioAdministrativoNuevo As Usuario_Administrativo)
        'Manejo de errores de argumentos
        ' usuarioAdministrativoViejo tiene un valor nulo
        If usuarioAdministrativoViejo Is Nothing Then
            Throw New ArgumentNullException("usuarioAdministrativo", "El usuario administrativo original tiene un valor nulo")
        End If

        ' usuarioAdministrativoNuevo tiene un valor nulo
        If usuarioAdministrativoNuevo Is Nothing Then
            Throw New ArgumentNullException("usuarioAdministrativo", "El usuario administrativo a guardar tiene un valor nulo")
        End If

        ' El usuario a modificar no está almacenado
        Dim indice As Integer = -1
        For Each u As Usuario_Administrativo In ListaUsuariosAdministrativos
            If u.CI_Administrativo = usuarioAdministrativoViejo.CI_Administrativo Then
                indice = ListaUsuariosAdministrativos.IndexOf(u)
            End If
        Next
        If indice = -1 Then
            Throw New ArgumentException("El usuario administrativo original no está almacenado.")
        End If

        ' La nueva cédula del usuario entra en conflicto con la de otro usuario
        Dim cantidadCedulasIguales As Integer = 0
        Dim mantieneLaCedula As Boolean = usuarioAdministrativoViejo.CI_Administrativo = usuarioAdministrativoNuevo.CI_Administrativo
        For Each u As Usuario_Administrativo In ListaUsuariosAdministrativos
            If usuarioAdministrativoNuevo.CI_Administrativo = u.CI_Administrativo Then
                cantidadCedulasIguales += 1
            End If
        Next
        If (cantidadCedulasIguales > 1 And mantieneLaCedula) Or (cantidadCedulasIguales > 0 And Not mantieneLaCedula) Then
            Throw New ArgumentException("Ya existe un usuario administrativo con esta cédula.")
        End If

        ListaUsuariosAdministrativos.Remove(usuarioAdministrativoViejo)
        ListaUsuariosAdministrativos.Insert(indice, usuarioAdministrativoNuevo)
    End Sub

    ' Retorna una lista de todos los usuarios de administrativos cuya cédula coincide con un filtro de texto
    Public Function BuscarUsuariosAdministrativos(busqueda As String) As List(Of Usuario_Administrativo)
        Dim listaResultados As New List(Of Usuario_Administrativo)

        For Each u As Usuario_Administrativo In ListaUsuariosAdministrativos
            If u.CI_Administrativo Like ("*" & busqueda & "*") Then
                listaResultados.Add(u)
            End If
        Next

        Return listaResultados
    End Function

    ' Elimina un usuario de administrativo de la lista
    Public Sub EliminarUsuarioAdministrativo(usuarioAdministrativo As Usuario_Administrativo)
        ' Manejo de errores de argumentos
        ' usuarioAdministrativo tiene un valor nulo
        If usuarioAdministrativo Is Nothing Then
            Throw New ArgumentNullException("usuarioAdministrativo", "El usuario de administrativo tiene un valor nulo.")
        End If

        ' El usuario a eliminar no existe
        If Not ListaUsuariosAdministrativos.Contains(usuarioAdministrativo) Then
            Throw New ArgumentException("Este usuario de administrativo no está almacenado.")
        End If

        ListaUsuariosAdministrativos.Remove(usuarioAdministrativo)
    End Sub

    ' Elimina el usuario de administrativo en el índice especificado de la lista
    Public Sub EliminarUsuarioAdministrativo(indice As Integer)
        ' Manejo de errores de argumentos
        ' El índice excede el tamaño de la colección
        If indice >= ListaUsuariosAdministrativos.Count Then
            Throw New Exception("El índice indicado excede el tamaño de la colección.")
        End If

        ' El índice es negativo
        If indice < 0 Then
            Throw New Exception("El índice indicado es negativo.")
        End If

        ListaUsuariosAdministrativos.RemoveAt(indice)
    End Sub
End Module
