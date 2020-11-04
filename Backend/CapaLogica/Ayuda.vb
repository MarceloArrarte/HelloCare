Imports System.IO
Imports System.Windows.Forms
Imports Clases
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Module Ayuda
    Public Sub AbrirAyuda(tipoUsuario As TiposUsuario, form As Form)
        Dim primeraPagina, ultimaPagina As Integer
        Dim rangoPaginas As String = ""
        Select Case tipoUsuario
            Case TiposUsuario.Administrativo
                rangoPaginas = ObtenerRangoPaginasManualAdministrativo(form)
            Case TiposUsuario.Paciente
                rangoPaginas = ObtenerRangoPaginasManualPaciente(form)
            Case TiposUsuario.Medico
                rangoPaginas = ObtenerRangoPaginasManualMedico(form)
        End Select

        Dim limitesRango As String() = rangoPaginas.Split("-"c)
        primeraPagina = limitesRango(0)
        ultimaPagina = limitesRango(1)

        Select Case tipoUsuario
            Case TiposUsuario.Administrativo
                AbrirPDFAyuda(primeraPagina, ultimaPagina)
        End Select
    End Sub

    Private Function ObtenerRangoPaginasManualAdministrativo(form As Form) As String
        Dim nombreCompletoForm As String = form.GetType.ToString
        Dim nombreCortoForm As String = nombreCompletoForm.Substring(nombreCompletoForm.IndexOf("."c) + 1)
        Dim rangoPaginas As String = ""
        Select Case nombreCortoForm
            Case "FrmAltaAdministrativo"
                rangoPaginas = "27-28"
            Case "FrmAltaEnfermedades"
                rangoPaginas = "14-15"
            Case "FrmAltaMedico"
                rangoPaginas = "23-24"
            Case "FrmAltaPaciente"
                rangoPaginas = "19-20"
            Case "FrmAltaSintomas"
                rangoPaginas = "10-11"
            Case "FrmConfiguracion"
                rangoPaginas = "28-29"
            Case "FrmContrasenaOlvidada"
                rangoPaginas = "1-2"
            Case "FrmListadoAdministrativos"
                rangoPaginas = "24-28"
            Case "FrmListadoEnfermedades"
                rangoPaginas = "11-15"
            Case "FrmListadoMedicos"
                rangoPaginas = "20-24"
            Case "FrmListadoPacientes"
                rangoPaginas = "16-20"
            Case "FrmListadoSintomas"
                rangoPaginas = "7-11"
            Case "FrmLogin"
                rangoPaginas = "1-1"
            Case "FrmMenuPrincipal"
                rangoPaginas = "4-6"
            Case "FrmModificacionAdministrativo"
                rangoPaginas = "26-26"
            Case "FrmModificacionEnfermedades"
                rangoPaginas = "12-13"
            Case "FrmModificacionMedico"
                rangoPaginas = "22-22"
            Case "FrmModificacionPaciente"
                rangoPaginas = "18-18"
            Case "FrmModificacionSintomas"
                rangoPaginas = "8-9"
            Case "FrmRegistro"
                rangoPaginas = "2-3"
            Case "FrmTipoUsuario"
                rangoPaginas = "16-16"
            Case "FrmVerAdministrativo"
                rangoPaginas = "25-25"
            Case "FrmVerEnfermedades"
                rangoPaginas = "12-12"
            Case "FrmVerMedico"
                rangoPaginas = "21-21"
            Case "FrmVerPaciente"
                rangoPaginas = "17-17"
            Case "FrmVerSintomas"
                rangoPaginas = "7-8"
            Case Else
                Throw New Exception("No se encontró ayuda para esta ventana.")
        End Select
        Return rangoPaginas
    End Function

    Private Function ObtenerRangoPaginasManualPaciente(form As Form) As String
        Dim nombreCompletoForm As String = form.GetType.ToString
        Dim nombreCortoForm As String = nombreCompletoForm.Substring(nombreCompletoForm.IndexOf("."c) + 1)
        Dim rangoPaginas As String = ""
        Select Case nombreCortoForm
            Case "FrmChatPaciente"
                rangoPaginas = "9-9"
            Case "FrmComentariosAdicionales"
                rangoPaginas = "8-9"
            Case "FrmContrasenaOlvidada"
                rangoPaginas = "2-2"
            Case "FrmDiagnosticoPrimario"
                rangoPaginas = "5-7"
            Case "FrmDiagnosticosDiferenciales"
                rangoPaginas = "5-7"
            Case "FrmHistorialDiagnosticos"
                rangoPaginas = "5-7"
            Case "FrmIngresoSintoma"
                rangoPaginas = "4-5"
            Case "FrmLogin"
                rangoPaginas = "1-1"
            Case "FrmMenuPrincipal"
                rangoPaginas = "3-7"
            Case "FrmRegistro"
                rangoPaginas = "3-3"
            Case Else
                Throw New Exception("No se encontró ayuda para esta ventana.")
        End Select
        Return rangoPaginas
    End Function

    Private Function ObtenerRangoPaginasManualMedico(form As Form) As String
        Dim nombreCompletoForm As String = form.GetType.ToString
        Dim nombreCortoForm As String = nombreCompletoForm.Substring(nombreCompletoForm.IndexOf("."c) + 1)
        Dim rangoPaginas As String = ""
        Select Case nombreCortoForm
            Case "FrmChatMedico"
                rangoPaginas = "7-10"
            Case "FrmHistorialChats"
                rangoPaginas = "10-11"
            Case "FrmHistorialPacientes"
                rangoPaginas = "11-12"
            Case "FrmContrasenaOlvidada"
                rangoPaginas = "2-2"
            Case "FrmLogin"
                rangoPaginas = "1-1"
            Case "FrmMenuPrincipal"
                rangoPaginas = "3-7"
            Case "FrmNuevoDiagnostico"
                rangoPaginas = "9-10"
            Case "FrmPeticionesChat"
                rangoPaginas = "7-8"
            Case "FrmRegistro"
                rangoPaginas = "3-3"
            Case Else
                Throw New Exception("No se encontró ayuda para esta ventana.")
        End Select
        Return rangoPaginas
    End Function

    Private Sub AbrirPDFAyuda(primeraPagina As Integer, ultimaPagina As Integer)
        Dim rutaSalida As String = "Ayuda de HelloCare.pdf"

        If File.Exists(rutaSalida) Then
            Try
                File.Delete(rutaSalida)
            Catch ex As UnauthorizedAccessException
                Throw New Exception("Por favor, cierre la ventana de ayuda para abrir otra sección del manual.")
            End Try
        End If

        Dim os As Stream = New StreamWriter(rutaSalida).BaseStream
        Dim doc As New Document()
        Dim lector As PdfReader
        Try
            lector = New PdfReader("Manual.pdf")
        Catch ex As Exception
            Throw New Exception("No se encuentra el manual del sistema en la carpeta de la aplicación.")
        End Try
        Dim clonador As New PdfSmartCopy(doc, os)
        doc.Open()
        For i = primeraPagina To ultimaPagina
            Dim pagina As PdfImportedPage = clonador.GetImportedPage(lector, i)
            clonador.AddPage(pagina)
        Next
        doc.Close()
        lector.Close()

        Dim proceso As New Process
        proceso.StartInfo.FileName = rutaSalida
        proceso.Start()
    End Sub
End Module
