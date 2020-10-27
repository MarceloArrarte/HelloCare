Imports CapaLogica
Imports Clases
Public Class FrmVerPaciente
    Sub New(paciente As Paciente)
        InitializeComponent()

        ' Muestra los datos del paciente seleccionado en la ventana anterior
        txtCi.Text = paciente.CI
        txtNombre.Text = paciente.Nombre
        txtApellido.Text = paciente.Apellido
        txtCorreo.Text = paciente.Correo
        txtTelMovil.Text = paciente.TelefonoMovil
        txtTelFijo.Text = paciente.TelefonoFijo
        txtSexo.Text = paciente.Sexo.ToString
        txtFechaNacimiento.Text = paciente.FechaNacimiento.ToString("dd-MM-yyyy")

        If paciente.FechaDefuncion = Nothing Then
            txtFechaDefuncion.Text = Nothing
        Else
            txtFechaDefuncion.Text = paciente.FechaDefuncion.ToString("dd-MM-yyyy")
        End If



        txtCalle.Text = paciente.Calle
        txtNumeroPuerta.Text = paciente.NumeroPuerta
        txtApartamento.Text = paciente.Apartamento
        txtLocalidad.Text = paciente.Localidad.ToString
        txtDepartamento.Text = paciente.Localidad.Departamento.ToString




        txtCi.ReadOnly = True
        txtNombre.ReadOnly = True
        txtApellido.ReadOnly = True
        txtCorreo.ReadOnly = True
        txtTelMovil.ReadOnly = True
        txtTelFijo.ReadOnly = True
        txtSexo.ReadOnly = True
        txtFechaNacimiento.ReadOnly = True
        txtCalle.ReadOnly = True
        txtNumeroPuerta.ReadOnly = True
        txtApartamento.ReadOnly = True
        txtLocalidad.ReadOnly = True
        txtDepartamento.ReadOnly = True
        txtFechaDefuncion.ReadOnly = True

    End Sub
    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub



    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    ' Evita que algún control quede seleccionado 
    Private Sub FrmVerPaciente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ActiveControl = Nothing
    End Sub

    Private Sub txtFechaDefuncion_TextChanged(sender As Object, e As EventArgs) Handles txtFechaDefuncion.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class