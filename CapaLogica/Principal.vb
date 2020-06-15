Module Principal
    Private ListaEnfermedades As New List(Of Enfermedad)
    Private ListaSintomas As New List(Of Sintoma)
    Private ListaUsuariosPacientes As New List(Of Usuario_Paciente)
    Private ListaUsuariosAdministrativos As New List(Of Usuario_Administrativo)

    Public Sub IngresarEnfermedad(enfermedad As Enfermedad)
        Try
            If enfermedad Is Nothing Then
                Throw New Exception("La enfermedad tiene un valor nulo.")
            End If
            For Each e As Enfermedad In ListaEnfermedades
                If enfermedad.Nombre = e.Nombre Then
                    Throw New Exception("Ya hay una enfermedad con este nombre.")
                End If
            Next

            ListaEnfermedades.Add(enfermedad)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ModificarEnfermedad(enfermedad As Enfermedad, indiceModificado As Integer)
        Try
            If enfermedad Is Nothing Then
                Throw New Exception("La enfermedad tiene un valor nulo.")
            End If
            If indiceModificado >= ListaEnfermedades.Count Then
                Throw New Exception("El índice indicado excede el tamaño de la colección.")
            End If
            For Each e As Enfermedad In ListaEnfermedades
                If enfermedad.Nombre = e.Nombre Then
                    Throw New Exception("Ya hay una enfermedad con este nombre.")
                End If
            Next

            Dim registro As Enfermedad = ListaEnfermedades(indiceModificado)
            registro.Nombre = enfermedad.Nombre
            registro.Descripcion = enfermedad.Descripcion
            registro.Recomendaciones = enfermedad.Recomendaciones
            registro.Gravedad = enfermedad.Gravedad
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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

    Public Sub EliminarEnfermedad(enfermedad As Enfermedad, indiceModificado As Integer)
        Try
            If indiceModificado >= ListaEnfermedades.Count Then
                Throw New Exception("El índice indicado excede el tamaño de la colección.")
            End If
            If indiceModificado < 0 Then
                Throw New Exception("El índice indicado es negativo.")
            End If

            ListaEnfermedades.RemoveAt(indiceModificado)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub IngresarSintoma(sintoma As Sintoma)
        Try
            If sintoma Is Nothing Then
                Throw New Exception("El síntoma tiene un valor nulo.")
            End If
            For Each s As Sintoma In ListaSintomas
                If sintoma.Nombre = s.Nombre Then
                    Throw New Exception("Ya hay un síntoma ingresado con este nombre.")
                End If
            Next

            ListaSintomas.Add(sintoma)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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
            registro.Nombre = sintoma.Nombre
            registro.Descripcion = sintoma.Descripcion
            registro.Recomendaciones = sintoma.Recomendaciones
            registro.Urgencia = sintoma.Urgencia
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

    Public Sub EliminarSintoma(sintoma As Sintoma, indiceModificado As Integer)
        Try
            If indiceModificado >= ListaEnfermedades.Count Then
                Throw New Exception("El índice indicado excede el tamaño de la colección.")
            End If
            If indiceModificado < 0 Then
                Throw New Exception("El índice indicado es negativo.")
            End If

            ListaEnfermedades.RemoveAt(indiceModificado)
        Catch ex As Exception

        End Try
    End Sub



    Public Sub ListaUsuariosPacientes(_UsuarioPaciente As Usuario_Paciente)
        Try
            If _UsuarioPaciente Is Nothing Then
                Throw New Exception("El usuario paciente tiene un valor nulo")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Public Sub GenerarDatos()
        Dim enfermedad1 As New Enfermedad("Nombre: Gripe leve", "Recomendacion: Reposo", 40, "Descripcion: Tos y mocos")
        Dim enfermedad2 As New Enfermedad("Nombre: Hipertension", "Recomendacion: Comer sin sal", 50, "Descripcion: Presion alta")
        Dim enfermedad3 As New Enfermedad("Nombre: Sobrepeso", "Recomendacion: Hacer ejercicio", 20, "Descripcion: IMC mayor a 25")

        Dim sintoma1 As New Sintoma("Nombre: Tos", "Descripcion: es un mecanismo de defensa de nuestro organismo. Protege las vías respiratorias dejándolas limpias para respirar con normalidad.", "Recomendaciones: mantenerse caliente y tomar miel", 10)
        Dim sintoma2 As New Sintoma("Nombre: Dolor de cabeza", "Descripcion: Dolor de muñeca", "Recomendaciones: hielo en zona", 60)
        Dim sintoma3 As New Sintoma("Nombre: Resfriado", "Descripcion: infección viral aguda del tracto respiratorio", "Recomendaciones: mantenerse caliente y tomar té con miel", 20)

        Dim usuarioPaciente1 As New Usuario_Paciente("51712282", "republica")
        Dim usuarioPaciente2 As New Usuario_Paciente("59273847", "constelaciones")
        Dim usuarioPaciente3 As New Usuario_Paciente("51273748", "informatica")

        Dim usuarioAdministrativo1 As New Usuario_Administrativo("52315584", "nashe")
        Dim usuarioAdministrativo2 As New Usuario_Administrativo("26715504", "televisor")
        Dim usuarioAdministrativo3 As New Usuario_Administrativo("52315504", "teclado")
    End Sub







End Module
