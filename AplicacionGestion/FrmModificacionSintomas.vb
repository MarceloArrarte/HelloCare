Imports CapaLogica

Public Class FrmModificacionSintomas
    Private sintomaAModificar As Sintoma
    Sub New(sintoma As Sintoma)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtNombre.Text = sintoma.Nombre
        txtDescripcion.Text = sintoma.Descripcion
        txtUrgencia.Text = sintoma.Urgencia
        txtRecomendaciones.Text = sintoma.Recomendaciones

        Dim asociacionesConEnfermedades As List(Of AsociacionSintoma) = BuscarAsociacionesSintomas(sintoma)
        Dim enfermedadesAsociadas As New List(Of Enfermedad)
        For i = 0 To asociacionesConEnfermedades.Count - 1
            enfermedadesAsociadas.Add(BuscarEnfermedades(asociacionesConEnfermedades(i).NombreEnfermedad, True).Single)
        Next

        For i = 0 To enfermedadesAsociadas.Count - 1
            Dim valoresFila As New List(Of Object)
            valoresFila.Add(enfermedadesAsociadas(i))
            valoresFila.Add(enfermedadesAsociadas(i).Nombre)
            valoresFila.Add(asociacionesConEnfermedades(i).Frecuencia & "%")
            tblAsociadas.Rows.Add(valoresFila.ToArray)
        Next

        'Dim enfermedadesAsociadas As List(Of Enfermedad) = BuscarEnfermedades(sintoma)

        'For Each e As Enfermedad In enfermedadesAsociadas
        '    Dim valoresFila As New List(Of Object)
        '    valoresFila.Add(e)
        '    valoresFila.Add(e.Nombre)

        '    Dim frecuencia As String = ""
        '    For Each s As Sintoma In e.ListaSintomas
        '        If s.Nombre = sintoma.Nombre Then
        '            frecuencia = s.Frecuencia & "%"
        '        End If
        '    Next
        '    valoresFila.Add(frecuencia)

        '    tblAsociadas.Rows.Add(valoresFila.ToArray)
        'Next

        sintomaAModificar = sintoma
    End Sub

    Private Sub FrmModificacionSintomas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each enfermedad As Enfermedad In BuscarEnfermedades("", True)
            tblPatologias.Rows.Add(enfermedad, enfermedad.Nombre)
        Next

        tblAsociadas.ClearSelection()
        tblPatologias.ClearSelection()

        OcultarPatologiasSeleccionadasOFiltradas()
        'OcultarYaSeleccionado()
    End Sub

    Private Sub OcultarPatologiasSeleccionadasOFiltradas()
        For Each r As DataGridViewRow In tblPatologias.Rows
            If r.Cells(1).Value.ToString.ToLower Like ("*" & txtBuscarPatologia.Text & "*").ToLower Then
                r.Visible = True
            Else
                r.Visible = False
            End If
        Next

        For Each rSeleccionado As DataGridViewRow In tblAsociadas.Rows
            For Each rPatologia As DataGridViewRow In tblPatologias.Rows
                If rSeleccionado.Cells(1).Value = rPatologia.Cells(1).Value Then
                    rPatologia.Visible = False
                End If
            Next
        Next
        tblPatologias.ClearSelection()
    End Sub

    Private Sub txtBuscarPatologia_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarPatologia.TextChanged
        OcultarPatologiasSeleccionadasOFiltradas()
        'OcultarSegunFiltro()
        'OcultarYaSeleccionado()
    End Sub

    'Private Sub OcultarSegunFiltro()
    '    For Each r As DataGridViewRow In tblPatologias.Rows
    '        If r.Cells(1).Value.ToString.ToLower Like ("*" & txtBuscarPatologia.Text & "*").ToLower Then
    '            r.Visible = True
    '        Else
    '            r.Visible = False
    '        End If
    '    Next
    'End Sub

    'Private Sub OcultarYaSeleccionado()
    '    For Each rSeleccionado As DataGridViewRow In tblAsociadas.Rows
    '        For Each rPatologia As DataGridViewRow In tblPatologias.Rows
    '            If rSeleccionado.Cells(1).Value = rPatologia.Cells(1).Value Then
    '                rPatologia.Visible = False
    '            End If
    '        Next
    '    Next
    '    tblPatologias.ClearSelection()
    'End Sub

    Private Sub btnAgregarPatologia_Click(sender As Object, e As EventArgs) Handles btnAgregarPatologia.Click
        Try
            If tblPatologias.SelectedRows.Count = 0 Then
                Throw New Exception("Debe seleccionar al menos una de las patologías disponibles.")
            End If

            For Each r As DataGridViewRow In tblPatologias.SelectedRows
                tblAsociadas.Rows.Add(r.Cells(0).Value, r.Cells(1).Value, "%")
                r.Visible = False
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnQuitarPatologia_Click(sender As Object, e As EventArgs) Handles btnQuitarPatologia.Click
        Try
            If tblAsociadas.SelectedRows.Count = 0 Then
                Throw New Exception("Debe seleccionar al menos una de las patologías asociadas.")
            End If

            For i = tblAsociadas.Rows.Count - 1 To 0 Step -1
                Dim fila As DataGridViewRow = tblAsociadas.Rows(i)
                If tblAsociadas.SelectedRows.Contains(fila) Then
                    For Each r As DataGridViewRow In tblPatologias.Rows
                        If r.Cells(1).Value = fila.Cells(1).Value Then
                            r.Visible = True
                        End If
                    Next
                    tblAsociadas.Rows.Remove(fila)
                End If
            Next
            OcultarPatologiasSeleccionadasOFiltradas()
            'OcultarSegunFiltro()
            'OcultarYaSeleccionado()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        'For Each r As DataGridViewRow In tblAsociadas.Rows
        '    For Each s As Sintoma In CType(r.Cells(0).Value, Enfermedad).ListaSintomas
        '        If s.Nombre = sintomaAModificar.Nombre Then
        '            s.Frecuencia = r.Cells(2).Value.ToString.Replace("%", "")
        '        End If
        '    Next
        'Next

        For Each asociacion As AsociacionSintoma In BuscarAsociacionesSintomas(sintomaAModificar).ToList
            EliminarAsociacionSintoma(asociacion)
        Next

        Dim sintomaNuevo As New Sintoma(txtNombre.Text, txtDescripcion.Text, txtRecomendaciones.Text, txtUrgencia.Text)

        For Each s As Sintoma In BuscarSintomas("", True)
            If s.Nombre = sintomaAModificar.Nombre Then
                ModificarSintoma(sintomaAModificar, sintomaNuevo)
            End If
        Next

        For Each r As DataGridViewRow In tblAsociadas.Rows
            Dim asociacion As New AsociacionSintoma(r.Cells(1).Value, sintomaNuevo.Nombre, r.Cells(2).Value.ToString.Replace("%", ""))
            IngresarAsociacionSintoma(asociacion)
        Next

        'Dim sintomaNuevo As New Sintoma(txtNombre.Text, txtDescripcion.Text, txtRecomendaciones.Text, txtUrgencia.Text)

        'For Each enfermedad In BuscarEnfermedades(sintomaAModificar)
        '    Dim indiceSintoma As Integer
        '    For Each s As Sintoma In enfermedad.ListaSintomas.ToList
        '        If s.Nombre = sintomaAModificar.Nombre Then
        '            indiceSintoma = enfermedad.ListaSintomas.IndexOf(s)
        '            enfermedad.ListaSintomas.Remove(s)

        '            Dim frecuencia As Integer
        '            For Each r As DataGridViewRow In tblAsociadas.Rows
        '                If r.Cells(1).Value = enfermedad.Nombre Then
        '                    frecuencia = r.Cells(2).Value.ToString.Replace("%", "")
        '                End If
        '            Next
        '            sintomaNuevo.Frecuencia = frecuencia

        '            enfermedad.ListaSintomas.Insert(indiceSintoma, sintomaNuevo)
        '        End If
        '    Next
        'Next

        Me.Close()
    End Sub
End Class
