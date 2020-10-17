Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Forms
Imports CapaLogica
Imports Clases

Public Class FrmMenuPrincipal

    Private Sub FrmMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblLogeado.Text = lblLogeado.Text.Replace("#", pacienteLogeado.ToString)
    End Sub

    Private Sub btnIngresoSintoma_Click(sender As Object, e As EventArgs) Handles btnIngresoSintoma.Click
        Dim frm As New FrmIngresoSintoma
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        ' Si el usuario quiere cerrar sesión, pide confirmación
        If MsgBox("¿Confirma que desea cerrar su sesión?", MsgBoxStyle.YesNo, "Cerrar sesión") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnHistorialDiagnosticos_Click(sender As Object, e As EventArgs) Handles btnHistorialDiagnosticos.Click
        Dim frm As New FrmHistorialDiagnosticos
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

        Dim crmIdioma As New ComponentResourceManager(GetType(FrmHistorialDiagnosticos))
        For Each c As Control In Me.Controls
            crmIdioma.ApplyResources(c, c.Name, New CultureInfo(nombreIdioma))
        Next
    End Sub
End Class