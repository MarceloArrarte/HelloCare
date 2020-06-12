Public Class Paciente

    Inherits Persona

    Private _TelefonoMovil As String
    Private _TelefonoFijo As String
    Private _Sexo As Char
    Private _FechaNacimiento As Date
    Private _Calle As String
    Private _NumeroPuerta As String
    Private _Apartamento As Integer
    Private _ListaDiagnosticosPrimarios As List(Of Diagnostico_Primario)

    Public Property TelefonoMovil As String
        Get
            Return _TelefonoMovil
        End Get
        Set(value As String)
            Try
                If value = Nothing Or value = "" Then
                    Throw New Exception("El telefono movil se encuentra vacío.")
                End If
                If value.Length > 9 Then
                    Throw New Exception("El largo del telefono no puede ser superior a 9 caracteres")
                End If
                _TelefonoMovil = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public Property TelefonoFijo As String
        Get
            Return _TelefonoFijo
        End Get
        Set(value As String)
            Try
                If value = Nothing Or value = "" Then
                    Throw New Exception("El telefono fijo se encuentra vacío.")
                End If
                If value.Length > 8 Then
                    Throw New Exception("El largo del telefono no puede ser superior a 8 caracteres")
                End If
                _TelefonoFijo = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try

        End Set
    End Property

    Public Property Sexo As Char
        Get
            Return _Sexo
        End Get
        Set(value As Char)
            Try
                If value = Nothing Or value = "" Then
                    Throw New Exception("El sexo se encuentra vacío.")
                End If
                If value <> "F" And value <> "M" And value <> "O" Then
                    Throw New Exception("El sexo no puede ser diferente de: Femenino(F), Masculino(M) u Otro(0)")
                End If
                _Sexo = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public Property FechaNacimiento As Date
        Get
            Return _FechaNacimiento
        End Get
        Set(value As Date)
            Try
                If _FechaNacimiento >= Now Then
                    Throw New Exception("La fecha de nacimiento debe ser previa a la fecha actual")
                End If
                _FechaNacimiento = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property


    Public Property Calle As String
        Get
            Return _Calle
        End Get
        Set(value As String)
            Try
                If value = Nothing Or value = "" Then
                    Throw New Exception("La calle se encuentra vacía.")
                End If
                If value >= 100 Then
                    Throw New Exception("La cantidad de caracteres debe ser menor a 100")
                End If
                _Calle = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property


    Public Property NumeroPuerta As String
        Get
            Return _NumeroPuerta
        End Get
        Set(value As String)
            Try
                If value = Nothing Or value = "" Then
                    Throw New Exception("El numero de puerta se encuentra vacío.")
                End If
                If value.Length >= 100 Then
                    Throw New Exception("El largo del numero de puerta no puede superar los 100 caracteres")
                End If
                _NumeroPuerta = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property


    Public Property Apartamento As Integer
        Get
            Return _Apartamento
        End Get
        Set(value As Integer)
            _Apartamento = value
        End Set
    End Property

    Public ReadOnly Property ListaDiagnosticoPrimario() As List(Of Diagnostico_Primario)
        Get
            Return _ListaDiagnosticosPrimarios
        End Get
    End Property

    Sub New()
        _ListaDiagnosticosPrimarios = New List(Of Diagnostico_Primario)
    End Sub

    Public Sub Diagnosticar(sintomas As List(Of Sintoma))

    End Sub
End Class
