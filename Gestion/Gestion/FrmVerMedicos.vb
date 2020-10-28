Imports CapaLogica

Imports Clases
Public Class FrmVerMedicos

    Sub New(medico As Medico)
        'Carga en los txt los datos del medico
        InitializeComponent()
        txtCI.Text = medico.CI
        txtNombre.Text = medico.Nombre
        txtApellido.Text = medico.Apellido
        txtCorreo.Text = medico.Correo
        txtLocalidad.Text = medico.Localidad.ToString

        'Vuelve los txt inmodificables
        txtCI.ReadOnly = True
        txtNombre.ReadOnly = True
        txtApellido.ReadOnly = True
        txtCorreo.ReadOnly = True
        txtLocalidad.ReadOnly = True


        For i = 0 To medico.Especialidades.Count - 1
            tblEspecialidades.Rows.Add(medico.Especialidades(i).Nombre)
        Next
    End Sub
    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        TraducirAplicacion()
    End Sub
End Class