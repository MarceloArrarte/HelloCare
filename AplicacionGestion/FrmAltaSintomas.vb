Imports CapaLogica

Public Class FrmAltaSintomas
    ' Esta bandera se implementa para indicar al evento FormClosing 
    ' si el formulario se cierra para volver sin guardar o habiendo ingresado datos
    Private requiereConfirmacionSalida As Boolean = True
    Private Sub FrmAltaSintomas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each enfermedad As Enfermedad In BuscarEnfermedades("", True)
            tblPatologias.Rows.Add(enfermedad, False, enfermedad.Nombre, "")
        Next
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ' Determina si se asociaron patologías, si no se hizo mostrará una advertencia
        Dim hayPatologiasAsociadas As Boolean = False
        For Each r As DataGridViewRow In tblPatologias.Rows
            If r.Cells(1).Value = True Then
                hayPatologiasAsociadas = True
            End If
        Next

        ' Procede a insertar el nuevo síntoma si se ingresaron patologías o si se confirma que se desea insertarlo sin patologías asociadas
        If hayPatologiasAsociadas OrElse
           (Not hayPatologiasAsociadas And MsgBox("Advertencia: no se asoció el nuevo síntoma a ninguna patología del sistema." & vbNewLine &
                                                  "¿Desea continuar de todas formas?", MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes) Then

            Dim sintoma As Sintoma = Nothing
            Try
                ' Crea un nuevo objeto con los datos ingresados, capturando cualquier error, y lo ingresa en el sistema
                sintoma = New Sintoma(txtNombreSintoma.Text, txtInfoSintoma.Text, txtRecomendacionSintoma.Text, txtUrgencia.Text)
                IngresarSintoma(sintoma)
                ' Por cada fila cuya casilla de verificación está marcada, crea una nueva asociación y la ingresa en el sistema
                For Each r As DataGridViewRow In tblPatologias.Rows
                    If r.Cells(1).Value = True Then
                        Dim nuevaAsociacion As New AsociacionSintoma(CType(r.Cells(0).Value, Enfermedad).Nombre,
                                                                     sintoma.Nombre,
                                                                     r.Cells(3).Value.ToString.Replace(".", ","))
                        IngresarAsociacionSintoma(nuevaAsociacion)
                    End If
                Next
                requiereConfirmacionSalida = False      ' No hubo errores, por lo que el formulario se cierra sin consultar
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                If sintoma IsNot Nothing Then                   ' Si sintoma llego a almacenar un objeto, se asume que pueden quedar datos
                    EliminarAsociacionSintoma(sintoma)          ' residuales en el sistema. Se eliminan las asociaciones que pudieren existir
                    EliminarSintoma(sintoma)                    ' y se elimina finalmente el síntoma.
                End If
            End Try
        End If
    End Sub

    ' Si el formulario se cierra sin crear un síntoma, pide al usuario confirmación para abandonar la ventana.
    Private Sub FrmAltaSintomas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If requiereConfirmacionSalida Then
            If MsgBox("Advertencia: no se guardaron los cambios." & vbNewLine & "¿Confirma que desea cerrar la ventana?", MsgBoxStyle.YesNo, "Salir") =
                MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class
