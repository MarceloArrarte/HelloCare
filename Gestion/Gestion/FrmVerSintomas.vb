Imports System.ComponentModel
Imports System.Globalization
Imports CapaLogica
Imports Clases

Public Class FrmVerSintomas
    Sub New(sintoma As Sintoma)
        InitializeComponent()

        ' Muestra los datos del síntoma seleccionado en la ventana anterior
        txtNombre.Text = sintoma.Nombre
        txtDescripcion.Text = sintoma.Descripcion
        txtRecomendaciones.Text = sintoma.Recomendaciones
        txtUrgencia.Text = sintoma.Urgencia

        For i = 0 To sintoma.Enfermedades.Count - 1
            tblPatologias.Rows.Add(sintoma.Enfermedades(i), sintoma.Enfermedades(i).Descripcion, sintoma.FrecuenciaEnfermedad(i))
        Next
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    ' Evita que algún control quede seleccionado y distraiga al usuario
    Private Sub FrmVerSintomas_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.ActiveControl = Nothing
        tblPatologias.ClearSelection()
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

        Dim crmIdioma As New ComponentResourceManager(GetType(FrmVerEnfermedades))
        For Each c As Control In Me.Controls
            crmIdioma.ApplyResources(c, c.Name, New CultureInfo(nombreIdioma))
        Next
    End Sub
End Class
