Public Class FrmInicio
    Dim appGestion As AplicacionGestion.FrmLogin
    Dim appPacientes As AplicacionPacientes.FrmLogin
    Dim appMedicos As AplicacionMedico.FrmLogin
    Private Sub FrmInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picHelloCare.Image = Image.FromFile("..\..\logo_hellocare.jpg")
        picHelloCode.Image = Image.FromFile("..\..\logo_hellocode.jpg")

        'GenerarDatos()

        'appGestion = New AplicacionGestion.FrmLogin
        'appPacientes = New AplicacionPacientes.FrmLogin
        appMedicos = New AplicacionMedico.FrmLogin
    End Sub

    Private Sub tmrSplashWindow_Tick(sender As Object, e As EventArgs) Handles tmrSplashWindow.Tick
        tmrSplashWindow.Enabled = False
        'appGestion.Show()
        'appPacientes.Show()
        appMedicos.Show()
        Me.Close()
    End Sub
End Class
