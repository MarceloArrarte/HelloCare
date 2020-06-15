Public Class FrmIngresoSintoma
    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        FrmDiagnosticoPrimario.Show()
        Me.Hide()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        FrmMenuPrincipalPaciente.Show()
        Me.Hide()
    End Sub

    'Agregar sintomas a la tabla izquierda'
    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Dim list As New List(Of Object)
        For Each item As Object In ListBox1.SelectedItems
            list.Add(item)
        Next
        For Each item As String In list
            ListBox2.Items.Add(item)
            ListBox1.Items.Remove(item)
        Next
    End Sub

    'Refrescar la lista de sintomas a seleccionar'
    Private Sub FrmIngresoSintoma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.Items.Add("tos")
        ListBox1.Items.Add("Tendinitis")
        ListBox1.Items.Add("Picor de ojos")
    End Sub

    'Elimina sintomas previamente seleccionados'
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim list As New List(Of Object)
        For Each item As Object In ListBox2.SelectedItems
            list.Add(item)
        Next
        For Each item As String In list
            ListBox1.Items.Add(item)
            ListBox2.Items.Remove(item)

        Next
    End Sub
End Class