Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Forms
Imports Clases

Public Module Localizacion
    Public Sub TraducirFormulario(formulario As Form)
        Dim idioma As String
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                idiomaSeleccionado = Idiomas.Ingles
                idioma = "en"
            Case Idiomas.Ingles
                idiomaSeleccionado = Idiomas.Espanol
                idioma = "es"
            Case Else
                Throw New Exception("Error de idioma seleccionado.")
        End Select

        Dim tipoForm As Type = formulario.GetType
        Dim crmLang As New ComponentResourceManager(tipoForm)
        For Each c As Control In ObtenerControles(formulario)
            crmLang.ApplyResources(c, c.Name, New CultureInfo(idioma))
        Next
    End Sub

    Private Function ObtenerControles(control As Control) As List(Of Control)
        Dim lista As New List(Of Control)
        For Each c As Control In control.Controls
            lista.Add(c)
            If c.Controls.Count > 0 Then
                lista.AddRange(ObtenerControles(c))
            End If
        Next
        Return lista
    End Function

    Public Function MostrarMensaje(tipoMensaje As MsgBoxStyle, textoES As String, tituloES As String, textoEN As String, tituloEN As String) As DialogResult
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
