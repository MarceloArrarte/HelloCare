Public Class FrmInicio
    Dim appGestion As FrmLogin
    Private Sub FrmInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picHelloCare.Image = Image.FromFile("..\..\logo_hellocare.jpg")
        picHelloCode.Image = Image.FromFile("..\..\logo_hellocode.jpg")
        appGestion = New FrmLogin
    End Sub

    Private Sub tmrSplashWindow_Tick(sender As Object, e As EventArgs) Handles tmrSplashWindow.Tick
        tmrSplashWindow.Enabled = False
        appGestion.Show()
        Me.Close()
    End Sub
End Class
