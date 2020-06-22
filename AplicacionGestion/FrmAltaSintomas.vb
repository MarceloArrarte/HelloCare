Imports CapaLogica

Public Class FrmAltaSintomas

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
                'If txtNombreSintoma.Text = "" Then
                '    Throw New Exception("El nombre del síntoma se encuentra vacío.")
                'End If
                'If txtUrgencia.Text = "" Then
                '    Throw New Exception("La urgencia del síntoma se encuentra vacía.")
                'End If
                sintoma = New Sintoma(txtNombreSintoma.Text, txtInfoSintoma.Text, txtRecomendacionSintoma.Text, txtUrgencia.Text)
                IngresarSintoma(sintoma)
                For Each r As DataGridViewRow In tblPatologias.Rows
                    If r.Cells(1).Value = True Then
                        Dim nuevaAsociacion As New AsociacionSintoma(CType(r.Cells(0).Value, Enfermedad).Nombre,
                                                                     sintoma.Nombre,
                                                                     r.Cells(3).Value.ToString.Replace(".", ","))
                        IngresarAsociacionSintoma(nuevaAsociacion)
                    End If
                Next
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                If sintoma IsNot Nothing Then
                    EliminarAsociacionSintoma(sintoma)
                    EliminarSintoma(sintoma)
                End If
            End Try
        End If
    End Sub

    Private Sub FrmAltaSintomas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each enfermedad As Enfermedad In BuscarEnfermedades("", True)
            tblPatologias.Rows.Add(enfermedad, False, enfermedad.Nombre, "")
        Next
    End Sub
End Class
