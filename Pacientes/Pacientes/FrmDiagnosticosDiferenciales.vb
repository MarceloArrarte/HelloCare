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
End Class