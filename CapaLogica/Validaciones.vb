Public Class Validaciones
    Public Shared Function Cedula(ci As String) As Boolean
        Try
            ' Manejo de errores de formato
            ' Valor nulo o cadena vacía
            If ci = Nothing Or ci = "" Then
                Throw New Exception("La cédula no ha sido ingresada.")
            End If

            ' La cédula posee más de 8 caracteres
            If ci.Length > 8 Then
                Throw New Exception("La cédula no puede poseer más de 8 caracteres.")
            End If

            ' Algún dígito no es un valor numérico (0-9)
            For Each c As Char In ci.ToCharArray
                Dim valorASCII As Integer = Asc(c)
                If valorASCII < 48 Or valorASCII > 57 Then
                    Throw New Exception("El dígito " & c & "no es válido.")
                End If
            Next

            ' Completa la cédula con ceros a la izquierda en caso de que tenga menos de 8 dígitos
            While ci.Length < 8
                ci = "0" & ci
            End While

            ' Calcula el dígito verificador a través de los dígitos numéricos, y lo compara con el ingresado
            Dim constantesVerificacion() As Integer = {2, 9, 8, 7, 6, 3, 4}
            Dim suma As Integer = 0
            For i = 0 To constantesVerificacion.Length - 1
                suma += (Val(ci(i)) * constantesVerificacion(i)) Mod 10
            Next
            Dim digitoVerificador As Integer = 10 - (suma Mod 10)

            ' Si el digito verificador calculado coincide con el ingresado, retorna True, sino retorna False
            If digitoVerificador = Integer.Parse(ci.ToCharArray.Last()) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Shared Function CorreoElectronico(correo As String)
        ' Manejo de errores de formato
        ' Valor nulo o cadena vacía
        If correo = Nothing Or correo = "" Then
            Throw New Exception("El correo no ha sido ingresada.")
        End If

        ' El correo posee más de 100 caracteres
        If correo.Length > 100 Then
            Throw New Exception("El correo no puede poseer más de 100 caracteres.")
        End If

        ' Si la cadena tiene un formato adecuado, retorna True, sino retorna False
        If correo Like "*@*.*" Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
