Public Class FrmInicio
    Private Sub FrmInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim inicioPacientes As New AplicacionPacientes.FrmMenuPrincipal
        Dim inicioGestion As New AplicacionGestion.FrmMenuPrincipal

        inicioPacientes.Show()
        inicioGestion.Show()
    End Sub
End Class