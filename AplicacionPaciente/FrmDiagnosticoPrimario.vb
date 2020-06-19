Public Class FrmDiagnosticoPrimario

    Private Sub DiagnosticoPrimario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim frm As New FrmMenuPrincipal
        frm.Show()
        Me.Close()
    End Sub

    Private Sub lstSintomas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSintomas.SelectedIndexChanged

    End Sub

    Private Sub tblEnfermedadesDiagnosticadas_CellContentClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles tblEnfermedadesDiagnosticadas.CellContentClick

    End Sub

    Private Sub txtRecomendaciones_TextChanged(sender As Object, e As EventArgs) Handles txtRecomendaciones.TextChanged

    End Sub

End Class