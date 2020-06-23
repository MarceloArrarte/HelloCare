Imports CapaLogica

Public Class FrmVerEnfermedades
    Sub New(enfermedad As Enfermedad)
        InitializeComponent()

        ' Muestra los datos de la enfermedad seleccionada en la ventana anterior
        txtNombre.Text = enfermedad.Nombre
        txtDescripcion.Text = enfermedad.Descripcion
        txtRecomendaciones.Text = enfermedad.Recomendaciones
        txtGravedad.Text = enfermedad.Gravedad
    End Sub

    ' Evita que algún control quede seleccionado y distraiga al usuario
    Private Sub FrmVerEnfermedades_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.ActiveControl = Nothing
    End Sub
End Class
