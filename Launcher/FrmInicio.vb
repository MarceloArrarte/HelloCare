Public Class FrmInicio
    Dim appGestion As AplicacionGestion.FrmLogin
    Dim appPacientes As AplicacionPacientes.FrmLogin
    Private Sub FrmInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CapaLogica.Principal.GenerarDatos()

        appGestion = New AplicacionGestion.FrmLogin
        appPacientes = New AplicacionPacientes.FrmLogin

        Me.CenterToScreen()
        picHelloCare.Image = Image.FromFile("..\..\logo_hellocare.jpg")
        picHelloCode.Image = Image.FromFile("..\..\logo_hellocode.jpg")
    End Sub

    Private Sub tmrSplashWindow_Tick(sender As Object, e As EventArgs) Handles tmrSplashWindow.Tick
        tmrSplashWindow.Enabled = False
        Me.Hide()
        appGestion.Show()
        appPacientes.Show()
    End Sub
End Class
