﻿Imports System.ComponentModel
Imports System.Globalization
Imports CapaLogica
Imports Clases

Public Class FrmHistorialPacientes
    Private Sub FrmHistorialPacientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ultimasConsultas As List(Of DiagnosticoPrimarioConConsulta)
        Try
            ultimasConsultas = CargarConsultasMedico()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return
        End Try

        For Each d As DiagnosticoPrimarioConConsulta In ultimasConsultas
            tblUltimasConsultas.Rows.Add(d, d.Paciente, d.Enfermedades(d.IndiceEnfermedadMasProbable), d.FechaHora)
        Next
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub lblTraducir_Click(sender As Object, e As EventArgs) Handles lblTraducir.Click
        TraducirAplicacion()
    End Sub
End Class