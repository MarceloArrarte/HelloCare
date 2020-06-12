Public Class FrmListadoEnfermedades
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FrmMenuPrincipal.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmVerEnfermedades.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        FrmAltaEnfermedades.Show()
        Me.Hide()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        FrmModificacionEnfermedades.Show()
        Me.Hide()

    End Sub
End Class
