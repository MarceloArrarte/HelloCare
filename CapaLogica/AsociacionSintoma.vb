Public Class AsociacionSintoma
    Private _NombreEnfermedad As String
    Private _NombreSintoma As String
    Private _Frecuencia As Decimal

    Public Property NombreEnfermedad() As String
        Get
            Return _NombreEnfermedad
        End Get
        Set(value As String)
            Try
                Dim existeEnfermedad As Boolean = False
                For Each e As Enfermedad In ListaEnfermedades
                    If e.Nombre = value Then
                        existeEnfermedad = True
                    End If
                Next
                If Not existeEnfermedad Then
                    Throw New Exception("La enfermedad a la que se intenta asociar el síntoma no existe.")
                End If

                _NombreEnfermedad = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public Property NombreSintoma() As String
        Get
            Return _NombreSintoma
        End Get
        Set(value As String)
            Try
                Dim existeSintoma As Boolean = False
                For Each s As Sintoma In ListaSintomas
                    If s.Nombre = value Then
                        existeSintoma = True
                    End If
                Next
                If Not existeSintoma Then
                    Throw New Exception("El síntoma que se intenta asociar no existe.")
                End If

                _NombreSintoma = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public Property Frecuencia() As Decimal
        Get
            Return _Frecuencia
        End Get
        Set(value As Decimal)
            Try
                If value < 0 Or value > 100 Then
                    Throw New Exception("La frecuencia de un síntoma en una enfermedad debe ser un valor entre 0 y 100.")
                End If

                _Frecuencia = value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Set
    End Property

    Public Sub New(nombreEnfermedad As String, nombreSintoma As String, frecuencia As Decimal)
        Me.NombreEnfermedad = nombreEnfermedad
        Me.NombreSintoma = nombreSintoma
        Me.Frecuencia = frecuencia
    End Sub
End Class
