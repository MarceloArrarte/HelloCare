Public Class Paciente

    Inherits Persona

    Private _TelefonoMovil As Integer
    Private _TelefonoFijo As Integer
    Private _Sexo As Char
    Private _FechaNacimiento As Date
    Private _Calle As String
    Private _NumeroPuerta As Integer
    Private _Apartamento As Integer
    Private _ListaDiagnosticosPrimarios As List(Of Diagnostico_Primario)

    Public Property TelefonoMovil As Integer
        Get
            Return _TelefonoMovil
        End Get
        Set(value As Integer)
            _TelefonoMovil = value
        End Set
    End Property

    Public Property TelefonoFijo As Integer
        Get
            Return _TelefonoFijo
        End Get
        Set(value As Integer)
            _TelefonoFijo = value
        End Set
    End Property

    Public Property Sexo As Char
        Get
            Return _Sexo
        End Get
        Set(value As Char)
            _Sexo = value
        End Set
    End Property

    Public Property FechaNacimiento As Date
        Get
            Return _FechaNacimiento
        End Get
        Set(value As Date)
            _FechaNacimiento = value
        End Set
    End Property


    Public Property Calle As String
        Get
            Return _Calle
        End Get
        Set(value As String)
            Try 
              If value >= 100 Then
              Throw New Exception("La cantidad de caracteres debe ser menor a 100")
                   End if 
             _Calle = value
              Catch ex As Exception
                 MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property


    Public Property NumeroPuerta As Integer
        Get
            Return _NumeroPuerta
        End Get
        Set(value As Integer)
            _NumeroPuerta = value
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
