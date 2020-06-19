Imports CapaLogica

Public Class FrmAltaSintomas

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If txtNombreSintoma.Text = "" Then
                Throw New Exception("El nombre del síntoma se encuentra vacío.")
            End If
            If txtUrgencia.Text = "" Then
                Throw New Exception("La urgencia del síntoma se encuentra vacía.")
            End If

            Dim nuevoSintoma As New Sintoma(txtNombreSintoma.Text, txtInfoSintoma.Text, txtRecomendacionSintoma.Text, txtUrgencia.Text)
            IngresarSintoma(nuevoSintoma)
            For Each r As DataGridViewRow In tblPatologias.Rows
                If r.Cells(1).Value = True Then
                    Dim nuevaAsociacion As New AsociacionSintoma(CType(r.Cells(0).Value, Enfermedad).Nombre, nuevoSintoma.Nombre, r.Cells(3).Value)
                End If
            Next
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try


    End Sub

    Private Sub FrmAltaSintomas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each enfermedad As Enfermedad In BuscarEnfermedades("", True)
            tblPatologias.Rows.Add(enfermedad, False, enfermedad.Nombre, "")
        Next
    End Sub
End Class
