Public Class FrmTipoUsuario
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnPaciente.Click
        Dim frm As New FrmListadoPacientes
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnMedico.Click
        Dim frm As New FrmListadoMedicos
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnAdministrador_Click(sender As Object, e As EventArgs) Handles btnAdministrador.Click
        Dim frm As New FrmListadoAdministrativos
        Me.Hide()
        frm.ShowDialog()
        Me.Show()
    End Sub
End Class