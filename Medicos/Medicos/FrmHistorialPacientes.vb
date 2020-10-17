Imports System.ComponentModel
Imports System.Globalization
Imports CapaLogica
Imports Clases

Public Class FrmHistorialPacientes
    Private Sub FrmHistorialPacientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ultimasConsultas As List(Of DiagnosticoPrimarioConConsulta) = CargarConsultasMedico(1)
        For Each d As DiagnosticoPrimarioConConsulta In ultimasConsultas
            tblUltimasConsultas.Rows.Add(d, d.Paciente, d.Enfermedades(d.IndiceEnfermedadMasProbable), d.FechaHora)
        Next
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
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

        Dim crmIdioma As New ComponentResourceManager(GetType(FrmHistorialPacientes))
        For Each c As Control In Me.Controls
            crmIdioma.ApplyResources(c, c.Name, New CultureInfo(nombreIdioma))
        Next
    End Sub
End Class