Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Forms
Imports CapaLogica
Imports Clases

Public Class FrmDiagnosticosDiferenciales
    Public Sub New(diagnosticoPrimario As DiagnosticoPrimarioConConsulta)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim diagnosticosDiferenciales As List(Of DiagnosticoDiferencial) = CargarDiagnosticosDiferenciales(diagnosticoPrimario)
        For i = 0 To diagnosticosDiferenciales.Count - 1
            tblDiagnosticosDiferenciales.Rows.Add(i + 1, diagnosticosDiferenciales(i).EnfermedadDiagnosticada, diagnosticosDiferenciales(i).ConductaASeguir,
                                                  diagnosticosDiferenciales(i).FechaHora)
        Next

        lblNombreMedico.Text = lblNombreMedico.Text.Replace("#", diagnosticoPrimario.Medico.ToString)
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
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

        Dim crmIdioma As New ComponentResourceManager(GetType(FrmDiagnosticosDiferenciales))
        For Each c As Control In Me.Controls
            crmIdioma.ApplyResources(c, c.Name, New CultureInfo(nombreIdioma))
        Next
    End Sub
End Class