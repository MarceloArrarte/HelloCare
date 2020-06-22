Imports CapaLogica
Public Class FrmInicio
    Dim appGestion As AplicacionGestion.FrmLogin
    Dim appPacientes As AplicacionPacientes.FrmLogin
    Private Sub FrmInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerarDatos()

        appGestion = New AplicacionGestion.FrmLogin
        appPacientes = New AplicacionPacientes.FrmLogin

        picHelloCare.Image = Image.FromFile("..\..\logo_hellocare.jpg")
        picHelloCode.Image = Image.FromFile("..\..\logo_hellocode.jpg")
    End Sub

    Public Sub GenerarDatos()
        IngresarEnfermedad(New Enfermedad("Gripe leve", "Reposo", 40, "Tos y mocos"))
        IngresarEnfermedad(New Enfermedad("Hipertension", "Comer sin sal", 50, "Presion alta"))
        IngresarEnfermedad(New Enfermedad("Sobrepeso", "Hacer ejercicio", 20, "IMC mayor a 25"))

        IngresarSintoma(New Sintoma("Tos", "Es un mecanismo de defensa de nuestro organismo. Protege las vías respiratorias dejándolas limpias para respirar con normalidad.", "Mantenerse caliente y tomar miel", 10))
        IngresarSintoma(New Sintoma("Dolor de cabeza", "Dolor de muñeca", "Hielo en zona", 60))
        IngresarSintoma(New Sintoma("Resfriado", "Infección viral aguda del tracto respiratorio", "Mantenerse caliente y tomar té con miel", 20))

        IngresarAsociacionSintoma(New AsociacionSintoma("Gripe leve", "Tos", 80))
        IngresarAsociacionSintoma(New AsociacionSintoma("Gripe leve", "Dolor de cabeza", 57))
        IngresarAsociacionSintoma(New AsociacionSintoma("Hipertension", "Tos", 16))

        IngresarUsuarioPaciente(New Usuario_Paciente("51712272", "republica"))
        IngresarUsuarioPaciente(New Usuario_Paciente("50681129", "constelaciones"))
        IngresarUsuarioPaciente(New Usuario_Paciente("18727593", "informatica"))

        IngresarUsuarioAdministrativo(New Usuario_Administrativo("19174761", "nashe"))
        IngresarUsuarioAdministrativo(New Usuario_Administrativo("12071061", "televisor"))
        IngresarUsuarioAdministrativo(New Usuario_Administrativo("51593248", "teclado"))
    End Sub

    Private Sub tmrSplashWindow_Tick(sender As Object, e As EventArgs) Handles tmrSplashWindow.Tick
        tmrSplashWindow.Enabled = False
        Me.Hide()
        appGestion.Show()
        appPacientes.Show()
    End Sub
End Class
