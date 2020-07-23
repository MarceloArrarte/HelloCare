Imports CapaLogica
Imports Clases

Public Class FrmAltaEnfermedades
    ' Esta bandera se implementa para indicar al evento FormClosing 
    ' si el formulario se cierra para volver sin guardar o habiendo ingresado datos
    Private requiereConfirmacionSalida As Boolean = True
    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    ' Intenta crear un nuevo objeto y atrapa cualquier error que se produzca.
    ' Si no hay ningún error informa al usuario que la creación fue exitosa y cierra la ventana.
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim enfermedad As New Enfermedad(txtNombre.Text, txtRecomendacionesSintoma.Text, txtGravedad.Text, txtDescripcion.Text)
            IngresarEnfermedad(enfermedad)
            MsgBox("Enfermedad agregada con éxito.", MsgBoxStyle.OkOnly, "Éxito")
            requiereConfirmacionSalida = False
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ' Si el formulario se cierra sin crear una enfermedad, pide al usuario confirmación para abandonar la ventana.
    Private Sub FrmAltaEnfermedades_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If requiereConfirmacionSalida Then
            If MsgBox("Advertencia: no se guardaron los cambios." & vbNewLine & "¿Confirma que desea cerrar la ventana?", MsgBoxStyle.YesNo, "Salir") =
                MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class
