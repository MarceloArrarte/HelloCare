Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Clases
Imports CapaPersistencia

Public Module Autenticacion
    Friend Function CifrarClave(clave As String) As String
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
