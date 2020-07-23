Imports MySql.Data.MySqlClient
Public NotInheritable Class ConexionBD
    Private Shared _Conexion As MySqlConnection
    Private Shared _Adaptador As MySqlDataAdapter

    Public Shared ReadOnly Property Conexion() As MySqlConnection
        Get
            If _Conexion Is Nothing Then
                Dim url As String = "hellocode.dynns.com"
                Dim nombreBD As String = "hellocare"
                Dim usuario As String = "root"
                Dim contrasena As String = "rootmariadb"

                Dim cadenaConexion As String = String.Format("server={0};database={1};userid={2};password={3}", url, nombreBD, usuario, contrasena)

                _Conexion = New MySqlConnection(cadenaConexion)
            End If

            Return _Conexion
        End Get
    End Property

    Public Shared Property Adaptador() As MySqlDataAdapter
        Get
            Return _Adaptador
        End Get
        Set(value As MySqlDataAdapter)
            _Adaptador = value
        End Set
    End Property

    Public Function EjecutarConsulta(comando As String, nombreTabla As String) As DataSet
        Dim datos As New DataSet
        Adaptador = New MySqlDataAdapter(comando, Conexion)
        Adaptador.Fill(datos, nombreTabla)
        Return datos
    End Function
End Class
