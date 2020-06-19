Public MustInherit Class Persona
    Private _CI As String
    Private _Nombre As String
    Private _Apellido As String
    Private _Correo As String
    Private _Localidad As Localidad

    Protected Property CI As String
        Get
            Return _CI
        End Get
        Set(value As String)
            Try
                If Validaciones.Cedula(value) Then
                    _CI = value
                Else
                    Throw New Exception("El número de cédula ingresado no corresponde con el dígito verificador.")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
            _CI = value
        End Set
    End Property

    Protected Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            Try
                If value = Nothing Or value = "" Then
                    Throw New Exception("El nombre se encuentra vacío.")
                End If
                If value.Length >= 100 Then
                    Throw New Exception("El largo del nombre no debe superar los 100 caracteres.")
                End If
                _Nombre = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try

        End Set
    End Property

    Protected Property Apellido As String
        Get
            Return _Apellido
        End Get
        Set(value As String)
            Try
                If value = Nothing Or value = "" Then
                    Throw New Exception("El apellido se encuentra vacío.")
                End If
                If value.Length >= 100 Then
                    Throw New Exception("El largo del apellido no debe superar los 100 caracteres.")
                End If
                _Apellido = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Protected Property Correo As String
        Get
            Return _Correo
        End Get
        Set(value As String)
            Try
                If Validaciones.CorreoElectronico(value) Then
                    _Correo = value
                Else
                    Throw New Exception("El correo no tiene un formato válido.")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Protected Property Localidad As Localidad
        Get
            Return _Localidad
        End Get
        Set(value As Localidad)
            Try
                If value Is Nothing Then
                    Throw New Exception("La localidad se encuentra vacío.")
                End If
                _Localidad = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Sub New()
    End Sub

    Protected Sub New(ci As String, nombre As String, apellido As String, correo As String, localidad As Localidad)
        Me.CI = ci
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Correo = correo
        Me.Localidad = localidad
    End Sub


End Class
