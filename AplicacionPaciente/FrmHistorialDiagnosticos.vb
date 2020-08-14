Imports CapaLogica
Imports Clases

Public Class FrmHistorialDiagnosticos
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim diagnosticosPrimarios As List(Of DiagnosticoPrimario) = CargarDiagnosticosPrimariosDelPaciente(pacienteLogeado)
        For Each d As DiagnosticoPrimario In diagnosticosPrimarios
            tblDiagnosticos.Rows.Add(d, d.Enfermedades(0), d.Probabilidad(0) & "%", d.FechaHora)
        Next
    End Sub

    Private Sub btnVerDetalles_Click(sender As Object, e As EventArgs) Handles btnVerDetalles.Click
        If tblDiagnosticos.SelectedRows.Count = 1 Then
            Dim frm As New FrmDiagnosticoPrimario(CType(tblDiagnosticos.SelectedRows(0).Cells(0).Value, DiagnosticoPrimario))
            frm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        My.Forms.FrmMenuPrincipal.Show()
        Me.Close()
    End Sub
End Class