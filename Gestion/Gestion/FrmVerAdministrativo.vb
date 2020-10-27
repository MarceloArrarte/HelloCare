Imports CapaLogica
Imports Clases
Public Class FrmVerAdministrativo

    Sub New(administrativo As Administrativo)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        txtCI.Text = administrativo.CI
        txtNombre.Text = administrativo.Nombre
        txtApellido.Text = administrativo.Apellido
        txtCorreo.Text = administrativo.Correo
        txtLocalidad.Text = administrativo.Localidad.ToString
        If administrativo.EsEncargado = True Then
            checkEncargado.Checked = True
        End If


        txtCI.ReadOnly = True
        txtNombre.ReadOnly = True
        txtApellido.ReadOnly = True
        txtCorreo.ReadOnly = True
        checkEncargado.Enabled = False
        txtLocalidad.ReadOnly = True

    End Sub


    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub FrmVerAdministrativo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class