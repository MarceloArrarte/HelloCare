Imports System.ComponentModel
Imports System.Globalization
Imports CapaLogica
Imports Clases

Public Class FrmMenuPrincipal
    Private Sub FrmMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblLogeado.Text = lblLogeado.Text.Replace("#", administrativoLogeado.ToString)
        If Not administrativoLogeado.EsEncargado Then
            btnConfiguracion.Visible = False
        End If
    End Sub

    Private Sub btnABMSintomas_Click(sender As Object, e As EventArgs) Handles btnABMSintomas.Click
        Dim frm As New FrmListadoSintomas
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnABMEnfermedades_Click(sender As Object, e As EventArgs) Handles btnABMEnfermedades.Click
        Dim frm As New FrmListadoEnfermedades
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    ' Pide confirmación al usuario antes de cerrar sesión
    Private Sub FrmMenuPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox("¿Confirma que desea cerrar su sesión?", MsgBoxStyle.YesNo, "Cerrar sesión") = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnConfiguracion_Click(sender As Object, e As EventArgs) Handles btnConfiguracion.Click
        Dim frm As New FrmConfiguracion
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        Dim nombreIdioma As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                idiomaSeleccionado = Idiomas.Ingles
                nombreIdioma = "en"
            Case Idiomas.Ingles
                idiomaSeleccionado = Idiomas.Espanol
                nombreIdioma = "es"
        End Select

        Dim crmIdioma As New ComponentResourceManager(GetType(FrmMenuPrincipal))
        For Each c As Control In Me.Controls
            crmIdioma.ApplyResources(c, c.Name, New CultureInfo(nombreIdioma))
        Next
    End Sub
End Class
