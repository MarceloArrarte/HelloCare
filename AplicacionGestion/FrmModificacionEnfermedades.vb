Imports CapaLogica
Imports Clases

Public Class FrmModificacionEnfermedades
    ' Esta bandera se implementa para indicar al evento FormClosing 
    ' si el formulario se cierra para volver sin guardar o habiendo ingresado datos
    Private requiereConfirmacionSalida As Boolean = True

    Dim enfermedadAModificar As Enfermedad

    Sub New(enfermedad As Enfermedad)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' Precarga los datos de la enfermedad en los campos de texto correspondientes
        txtNombre.Text = enfermedad.Nombre
        txtDescripcion.Text = enfermedad.Descripcion
        txtGravedad.Text = enfermedad.Gravedad
        txtRecomendaciones.Text = enfermedad.Recomendaciones

        ' Almacena la enfermedad que se va a estar modificando
        enfermedadAModificar = enfermedad
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    ' Crea un objeto Enfermedad con los nuevos datos. Si no hay ningún error, sustituye en el sistema
    ' la enfermedad vieja por la nueva
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try
            Dim enfermedadNueva As New Enfermedad(txtNombre.Text, txtRecomendaciones.Text, txtGravedad.Text, txtDescripcion.Text)
            ModificarEnfermedad(enfermedadAModificar, enfermedadNueva)
            MsgBox("Modificación realizada con éxito.", MsgBoxStyle.OkOnly, "Éxito")
            requiereConfirmacionSalida = False          ' Si no hubo errores, permite que el formulario se cierre automáticamente
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ' Si intenta cerrar el formulario sin guardar cambios, solicita confirmación
    Private Sub FrmModificacionEnfermedades_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If requiereConfirmacionSalida Then
            If MsgBox("Advertencia: no se guardaron los cambios." & vbNewLine & "¿Confirma que desea cerrar la ventana?", MsgBoxStyle.YesNo, "Salir") =
                MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class
