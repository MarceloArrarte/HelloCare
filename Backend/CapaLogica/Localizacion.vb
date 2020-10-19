Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Forms
Imports Clases

Public Module Localizacion
    Public Sub TraducirFormulario(formulario As Form)
        Dim idioma As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                idioma = "es"
            Case Idiomas.Ingles
                idioma = "en"
            Case Else
                Throw New Exception("Error de idioma seleccionado.")
        End Select

        Dim tipoForm As Type = formulario.GetType
        Dim crmLang As New ComponentResourceManager(tipoForm)
        For Each c As Control In formulario.Controls
            crmLang.ApplyResources(c, c.Name, New CultureInfo(idioma))
        Next
    End Sub

    Private Function MostrarMensaje(tipoMensaje As MsgBoxStyle, textoES As String, tituloES As String, textoEN As String, tituloEN As String) As DialogResult
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                Return MsgBox(textoES, tipoMensaje, tituloES)
            Case Idiomas.Ingles
                Return MsgBox(textoEN, tipoMensaje, tituloEN)
            Case Else
                Throw New Exception("Error de idioma seleccionado.")
        End Select
    End Function
End Module
