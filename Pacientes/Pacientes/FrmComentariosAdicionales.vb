Imports CapaLogica
Imports Clases
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Globalization

Public Class FrmComentariosAdicionales
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ActiveControl = txtComentariosAdicionales
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnEnviarConsulta_Click(sender As Object, e As EventArgs) Handles btnEnviarConsulta.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs)
        Dim nombreIdioma As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                idiomaSeleccionado = Idiomas.Ingles
                nombreIdioma = "en"
            Case Idiomas.Ingles
                idiomaSeleccionado = Idiomas.Espanol
                nombreIdioma = "es"
        End Select

        Dim crmIdioma As New ComponentResourceManager(GetType(FrmComentariosAdicionales))
        For Each c As Control In Me.Controls
            crmIdioma.ApplyResources(c, c.Name, New CultureInfo(nombreIdioma))
        Next
    End Sub
End Class