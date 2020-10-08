Imports System.CodeDom
Imports MySql.Data.MySqlClient
Public NotInheritable Class ConexionBD
    Private Shared _Conexion As MySqlConnection
    Private Shared Adaptador As MySqlDataAdapter

    Public Shared ReadOnly Property Conexion() As MySqlConnection
        Get
            ' Si no se inicializó la conexión, lo hace con los datos de login en la BD
            If _Conexion Is Nothing Then
                Dim url As String = "vdo.dyndns.org"
                Dim nombreBD As String = "hellocare"
                Dim usuario As String = "hellocare"
                Dim contrasena As String = "h3llocar3"

                Dim cadenaConexion As String = String.Format("server={0};database={1};userid={2};password={3};allowzerodatetime=True;convertzerodatetime=True;charset=utf8;",
                                                              url, nombreBD, usuario, contrasena)

                _Conexion = New MySqlConnection(cadenaConexion)
            End If

            Return _Conexion
        End Get
    End Property

    Public Shared Function EjecutarConsulta(comando As MySqlCommand) As DataTable
        Dim datos As New DataSet
        comando.Connection = Conexion
        Adaptador = New MySqlDataAdapter(comando)
        Adaptador.Fill(datos)
        Dim tabla As DataTable = datos.Tables(0)
        datos.Tables.Remove(tabla)
        Return tabla
    End Function

    Public Shared Function EjecutarConsulta(comando As MySqlCommand, nombreTabla As String) As DataTable
        Dim datos As New DataSet
        comando.Connection = Conexion
        Adaptador = New MySqlDataAdapter(comando)
        Adaptador.Fill(datos, nombreTabla)
        Adaptador.FillSchema(datos, SchemaType.Mapped, nombreTabla)
        Dim tabla As DataTable = datos.Tables(nombreTabla)
        datos.Tables.Remove(tabla)
        Return tabla
    End Function

    Public Shared Sub EjecutarTransaccion(comando As MySqlCommand)
        Try
            comando.Connection = Conexion
            comando.ExecuteNonQuery()
        Catch ex As MySqlException
            If ex.Number = 1042 Then
                Throw New Exception("No se puede establecer la conexión con la base de datos.")
            Else
                Throw ex
            End If
        End Try
    End Sub

    Public Shared Function ObtenerUltimoIdInsertado() As Integer
        Dim datos As DataTable = EjecutarConsulta(New MySqlCommand("SELECT LAST_INSERT_ID();"))
        Return datos.Rows(0)(0)
    End Function

    'Public Shared Sub AplicarClavesExternas(datos As DataSet)
    '    ActualizarClavesExternas()

    '    ' Crea una lista con los nombres de las tablas
    '    Dim nombresTablas As New List(Of String)
    '    For Each t As DataTable In datos.Tables
    '        nombresTablas.Add(t.TableName)
    '    Next

    '    ' Elimina las relaciones almacenadas en el DataSet para evitar duplicados
    '    datos.Relations.Clear()

    '    ' Para cada FK almacenada, se fija si la lista de los nombres de las tablas en el DataSet contiene los nombres de ambas tablas de la relación.
    '    ' En caso afirmativo, agrega la relación entre las dos tablas al DataSet.
    '    For Each relacion As RelacionBD In _Relaciones
    '        If nombresTablas.Contains(relacion.NombreTablaPrimaria) And nombresTablas.Contains(relacion.NombreTablaExterna) Then
    '            relacion.AgregarRelacionA(datos)
    '        End If
    '    Next
    'End Sub

    'Private Shared Sub ActualizarClavesExternas()
    '    _Relaciones.Clear()
    '    ' Llena un DataSet con los datos de las claves externas de la BD
    '    Dim tabla As DataTable = EjecutarConsulta("SELECT constraint_name, table_name, column_name, referenced_table_name, referenced_column_name
    '                                             FROM information_schema.key_column_usage
    '                                             WHERE table_schema='hellocare' AND referenced_table_name IS NOT NULL")
    '    'Dim datos As DataSet = EjecutarConsulta("SELECT constraint_name, table_name, column_name, referenced_table_name, referenced_column_name
    '    '                                         FROM information_schema.key_column_usage
    '    '                                         WHERE table_schema='hellocare' AND referenced_table_name IS NOT NULL", "key_column_usage")

    '    'Dim tabla As DataTable = datos.Tables("key_column_usage")

    '    ' Para cada fila de la tabla de FK, las agrega a la lista que es atributo de la clase
    '    For Each r As DataRow In tabla.Rows
    '        Dim nombre As String = r("constraint_name")
    '        'Dim nombreTablaPrimaria As String = r("table_name")
    '        'Dim nombreClavePrimaria As String = r("column_name")
    '        'Dim nombreTablaExterna As String = r("referenced_table_name")
    '        'Dim nombreClaveExterna As String = r("referenced_column_name")

    '        Dim nombreTablaPrimaria As String = r("referenced_table_name")
    '        Dim nombreClavePrimaria As String = r("referenced_column_name")
    '        Dim nombreTablaExterna As String = r("table_name")
    '        Dim nombreClaveExterna As String = r("column_name")

    '        _Relaciones.Add(New RelacionBD(nombre, nombreTablaPrimaria, nombreClavePrimaria, nombreTablaExterna, nombreClaveExterna))
    '    Next
    'End Sub
End Class
