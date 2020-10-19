Imports System.ComponentModel
Imports System.Globalization
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

        ' Precarga los datos de los síntomas asociados a la enfermedad
        For i = 0 To enfermedad.Sintomas.Count - 1
            tblAsociados.Rows.Add(enfermedad.Sintomas(i), enfermedad.Sintomas(i).Nombre, enfermedad.FrecuenciaSintoma(i) & "%")
        Next

        ' Almacena la enfermedad que se va a estar modificando
        enfermedadAModificar = enfermedad
        For Each sintoma As Sintoma In CargarTodosLosSintomas()
            tblSintomas.Rows.Add(sintoma, sintoma.Nombre)
        Next
        For Each especialidad As Especialidad In CargarTodasLasEspecialidades()
            tblEspecialidades.Rows.Add(especialidad)
        Next

        OcultarSintomasSeleccionadosOFiltrados()
    End Sub

    Private Sub FrmModificacionEnfermedades_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        tblEspecialidades.ClearSelection()
        For Each r As DataGridViewRow In tblEspecialidades.Rows
            If CType(r.Cells(0).Value, Especialidad).ID = enfermedadAModificar.Especialidad.ID Then
                r.Selected = True
            End If
        Next
    End Sub

    Private Sub txtBuscarSintoma_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarSintoma.TextChanged
        OcultarSintomasSeleccionadosOFiltrados()
    End Sub

    Private Sub txtBuscarEspecialidades_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarEspecialidades.TextChanged
        For Each r As DataGridViewRow In tblEspecialidades.Rows
            If r.Cells(0).Value.ToString.ToLower Like ("*" & txtBuscarEspecialidades.Text & "*").ToLower Then
                r.Visible = True
            Else
                If Not r.Selected Then
                    r.Visible = False
                End If
            End If
        Next
    End Sub

    Private Sub btnAgregarSintoma_Click(sender As Object, e As EventArgs) Handles btnAgregarSintoma.Click
        If tblSintomas.SelectedRows.Count > 0 Then
            For Each r As DataGridViewRow In tblSintomas.SelectedRows
                tblAsociados.Rows.Add(r.Cells(0).Value, r.Cells(1).Value, "")
            Next
            OcultarSintomasSeleccionadosOFiltrados()
        Else
            MostrarMensaje(MsgBoxStyle.Critical, "Debe seleccionar al menos uno de los síntomas disponibles.", "Error", "You must select at least one of the available symptoms.", "Error")
        End If
    End Sub

    Private Sub btnQuitarSintoma_Click(sender As Object, e As EventArgs) Handles btnQuitarSintoma.Click
        If tblAsociados.SelectedRows.Count > 0 Then
            For Each rAsociada As DataGridViewRow In tblAsociados.SelectedRows
                For Each rPatologia As DataGridViewRow In tblSintomas.Rows
                    If rPatologia.Cells(1).Value = rAsociada.Cells(1).Value Then
                        rPatologia.Visible = True
                    End If
                Next
                tblAsociados.Rows.Remove(rAsociada)
            Next
            OcultarSintomasSeleccionadosOFiltrados()
        Else
            MostrarMensaje(MsgBoxStyle.Critical, "Debe seleccionar al menos uno de los síntomas asociados.", "Error", "You must select at least one of the associated symptoms.", "Error")
        End If
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try
            For Each r As DataGridViewRow In tblAsociados.Rows
                If r.Cells(2).Value Is Nothing Then
                    Throw New Exception("No se ha ingresado la frecuencia del síntoma """ & r.Cells(0).Value.ToString & """.")
                End If
            Next
            Dim especialidad As Especialidad = tblEspecialidades.SelectedRows(0).Cells(0).Value
            Dim listaSintomas As New List(Of Sintoma)
            Dim listaFrecuencias As New List(Of Decimal)
            For Each r As DataGridViewRow In tblAsociados.Rows
                listaSintomas.Add(CType(r.Cells(0).Value, Sintoma))
                Try
                    listaFrecuencias.Add(r.Cells(2).Value.ToString.Replace("%", ""))
                Catch ex As Exception
                    Throw New Exception("Las frecuencias solo pueden ser valores numéricos.")
                End Try
            Next

            Dim gravedadParseado As Integer
            If Not Integer.TryParse(txtGravedad.Text, gravedadParseado) Then
                Throw New Exception("La gravedad debe ser un valor numérico entero.")
            End If

            ActualizarEnfermedad(enfermedadAModificar, txtNombre.Text, txtDescripcion.Text, txtRecomendaciones.Text, txtGravedad.Text,
                                 listaSintomas, listaFrecuencias, especialidad)

            MostrarMensaje(MsgBoxStyle.Information, "Modificación realizada con éxito", "Éxito", "Illness has been successfully modified.", "Success")
            requiereConfirmacionSalida = False
            Me.Close()
        Catch ex As Exception
            MostrarMensaje(MsgBoxStyle.Critical, ex.Message, "Error", ex.Message, "Error")
        End Try
    End Sub

    Private Sub OcultarSintomasSeleccionadosOFiltrados()
        ' Oculta por filtro de texto
        For Each r As DataGridViewRow In tblSintomas.Rows
            If r.Cells(1).Value.ToString.ToLower Like ("*" & txtBuscarSintoma.Text & "*").ToLower Then
                r.Visible = True
            Else
                r.Visible = False
            End If
        Next

        ' Oculta los síntomas ya seleccionadas
        For Each rAsociado As DataGridViewRow In tblAsociados.Rows
            For Each rSintoma As DataGridViewRow In tblSintomas.Rows
                If rAsociado.Cells(1).Value = rAsociado.Cells(1).Value Then
                    rSintoma.Visible = False
                End If
            Next
        Next
        DeseleccionarTablas()
    End Sub

    Private Sub DeseleccionarTablas()
        tblAsociados.ClearSelection()
        tblSintomas.ClearSelection()
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    ' Si intenta cerrar el formulario sin guardar cambios, solicita confirmación
    Private Sub FrmModificacionEnfermedades_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If requiereConfirmacionSalida Then
            If MostrarMensaje(MsgBoxStyle.YesNo, "Advertencia: no se guardaron los cambios." & vbNewLine & "¿Confirma que desea cerrar la ventana?", "Salir", "Warning: no changes have been saved." & vbNewLine & "Are you sure you wish to close the window?", "Exit") = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        Dim nombreIdioma As String = ""
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                idiomaSeleccionado = Idiomas.Ingles
                nombreIdioma = "en"
            Case Idiomas.Ingles
                idiomaSeleccionado = Idiomas.Espanol
                nombreIdioma = "es"
        End Select

        Dim crmIdioma As New ComponentResourceManager(GetType(FrmModificacionEnfermedades))
        For Each c As Control In Me.Controls
            crmIdioma.ApplyResources(c, c.Name, New CultureInfo(nombreIdioma))
        Next
    End Sub
End Class
