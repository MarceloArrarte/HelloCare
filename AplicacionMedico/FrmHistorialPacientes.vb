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
End Class