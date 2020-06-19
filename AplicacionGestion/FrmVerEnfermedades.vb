Imports CapaLogica

Public Class FrmVerEnfermedades
    Sub New(enfermedad As Enfermedad)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txtNombre.Text = enfermedad.Nombre
        txtDescripcion.Text = enfermedad.Descripcion
        txtRecomendaciones.Text = enfermedad.Recomendaciones
        txtGravedad.Text = enfermedad.Gravedad
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        FrmListadoEnfermedades.Show()
        Me.Hide()

    End Sub

    Private Sub FrmVerEnfermedades_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.ActiveControl = Nothing
    End Sub
End Class
