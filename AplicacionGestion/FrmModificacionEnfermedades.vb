Public Class FrmModificacionEnfermedades

    Dim enfermedadAModificar As CapaLogica.Enfermedad

    Sub New(enfermedad As CapaLogica.Enfermedad)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtNombre.Text = enfermedad.Nombre
        txtDescripcion.Text = enfermedad.Descripcion
        txtGravedad.Text = enfermedad.Gravedad
        txtRecomendaciones.Text = enfermedad.Recomendaciones

        enfermedadAModificar = enfermedad
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()

    End Sub

    Private Sub FrmModificacionEnfermedades_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

        Try
            If txtNombre.Text = "" Then
                Throw New Exception("El nombre de la enfermedad no puede estar vacio")
            End If
            If txtGravedad.Text = "" Then
                Throw New Exception("La gravedad de la enfermedad no puede estar vacia")
            End If

            Dim enfermedadNueva As New CapaLogica.Enfermedad(txtNombre.Text, txtDescripcion.Text, Integer.Parse(txtGravedad.Text), txtRecomendaciones.Text)
            CapaLogica.ModificarEnfermedad(enfermedadAModificar, enfermedadNueva)
            MsgBox("Modificación realizada con éxito")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
End Class
