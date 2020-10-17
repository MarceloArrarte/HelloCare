Imports System.ComponentModel
Imports System.Globalization
Imports CapaLogica
Imports Clases

Public Class FrmVerEnfermedades
    Sub New(enfermedad As Enfermedad)
        InitializeComponent()

        ' Muestra los datos de la enfermedad seleccionada en la ventana anterior
        txtNombre.Text = enfermedad.Nombre
        txtDescripcion.Text = enfermedad.Descripcion
        txtRecomendaciones.Text = enfermedad.Recomendaciones
        txtGravedad.Text = enfermedad.Gravedad

        For i = 0 To enfermedad.Sintomas.Count - 1
            tblSintomas.Rows.Add(enfermedad.Sintomas(i), enfermedad.Sintomas(i).Descripcion, enfermedad.FrecuenciaSintoma(i))
        Next
    End Sub

    ' Evita que algún control quede seleccionado y distraiga al usuario
    Private Sub FrmVerEnfermedades_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.ActiveControl = Nothing
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
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
