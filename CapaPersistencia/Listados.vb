Imports Clases

Module Listados
    Public Function SelectSimple(entidad As Enumerados.Clases) As DataTable

        Dim nombreTabla As String
        SeleccionarTabla(nombreTabla, entidad)
        Dim comando As String = String.Format("SELECT * FROM {0}", nombreTabla)
        Dim datos As DataSet = ConexionBD.EjecutarConsulta(comando, nombreTabla)

        Dim lista As New List(Of Object)
        Dim tabla As DataTable = datos.Tables(nombreTabla)
        Return tabla
        'PoblarLista(lista, entidad, tabla)

    End Function

    Private Sub SeleccionarTabla(ByRef nombreTabla As String, entidad As Enumerados.Clases)
        Select Case entidad
            Case Enumerados.Clases.DiagnosticoPrimario
                nombreTabla = "diagnosticos_primarios"

            Case Enumerados.Clases.DiagnosticoDiferencial
                nombreTabla = "diagnoticos_diferenciales"

            Case Enumerados.Clases.Enfermedad
                nombreTabla = "enfermedades"

            Case Enumerados.Clases.Especialidad
                nombreTabla = "especialidades"

            Case Enumerados.Clases.Localidad
                nombreTabla = "localidades"

            Case Enumerados.Clases.Sintoma
                nombreTabla = "sintomas"

            Case Enumerados.Clases.Usuario
                nombreTabla = "usuarios"

            Case Enumerados.Clases.Chat
                nombreTabla = "chats"

            Case Enumerados.Clases.Mensaje
                nombreTabla = "mensajes"
        End Select
    End Sub

    Private Sub PoblarLista(ByRef lista As List(Of Object), entidad As Enumerados.Clases, tabla As DataTable)
        Select Case entidad
            Case Enumerados.Clases.DiagnosticoPrimario
                For Each r As DataRow In tabla.Rows
                    Dim id As Integer = r("ID")
                    Dim ci_paciente As String = r("CI_PACIENTE")
                    Dim fechaHora As Date = r("FECHA_HORA")
                    Dim tipo As TiposDiagnosticosPrimarios = r("TIPO")

                    lista.Add(New DiagnosticoPrimario(id, ci_paciente, fechaHora, tipo))
                Next

            Case Enumerados.Clases.Enfermedad
                For Each r As DataRow In tabla.Rows
                    Dim id As Integer = r("ID")
                    Dim nombre As String = r("NOMBRE")
                    Dim recomendaciones As String = r("RECOMENDACIONES")
                    Dim gravedad As Integer = r("GRAVEDAD")
                    Dim descripcion As String = r("DESCRIPCION")
                    Dim idEspecialidad As Integer = r("ID_ESPECIALIDAD")

                    lista.Add(New Enfermedad(id, nombre, recomendaciones, gravedad, descripcion, idEspecialidad))
                Next

            Case Enumerados.Clases.Especialidad
                For Each r As DataRow In tabla.Rows
                    Dim id As Integer = r("ID")
                    Dim nombre As String = r("NOMBRE")

                    lista.Add(New Especialidad(id, nombre))
                Next

            Case Enumerados.Clases.Localidad
                For Each r As DataRow In tabla.Rows
                    Dim id As Integer = r("ID")
                    Dim nombre As String = r("NOMBRE")
                    Dim idDepartamento As Integer = r("ID_DEPARTAMENTO")

                    lista.Add(New Localidad(id, nombre, idDepartamento))
                Next

            Case Enumerados.Clases.Sintoma
                For Each r As DataRow In tabla.Rows
                    Dim id As Integer = r("ID")
                    Dim nombre As String = r("NOMBRE")
                    Dim descripcion As String = r("DESCRIPCION")
                    Dim recomendaciones As String = r("RECOMENDACIONES")
                    Dim urgencia As Integer = r("URGENCIA")

                    lista.Add(New Sintoma(id, nombre, descripcion, recomendaciones, urgencia))
                Next

            Case Enumerados.Clases.Usuario
                For Each r As DataRow In tabla.Rows
                    Dim id As Integer = r("ID")
                    Dim ciPaciente As String = r("CI_PACIENTE")
                    Dim contrasena As String = r("CONTRASENIA")
                    Dim tipo As TiposUsuarios = r("TIPO")

                    lista.Add(New Usuario(id, ciPaciente, contrasena, tipo))
                Next
        End Select
    End Sub

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
