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
                rangoPaginas = "26-27"
            Case "FrmAltaEnfermedades"
                rangoPaginas = "13-14"
            Case "FrmAltaMedico"
                rangoPaginas = "23-24"
            Case "FrmAltaPaciente"
                rangoPaginas = "18-19"
            Case "FrmAltaSintomas"
                rangoPaginas = "9-10"
            Case "FrmConfiguracion"
                rangoPaginas = "27-28"
            Case "FrmContrasenaOlvidada"
                '' FALTA
            Case "FrmListadoAdministrativos"
                rangoPaginas = "23-23"
            Case "FrmListadoEnfermedades"
                rangoPaginas = "10-10"
            Case "FrmListadoMedicos"
                rangoPaginas = "19-19"
            Case "FrmListadoPacientes"
                rangoPaginas = "15-15"
            Case "FrmListadoSintomas"
                rangoPaginas = "6-6"
            Case "FrmLogin"
                rangoPaginas = "1-1"
            Case "FrmMenuPrincipal"
                rangoPaginas = "3-5"
            Case "FrmModificacionAdministrativo"
                rangoPaginas = "25-25"
            Case "FrmModificacionEnfermedades"
                rangoPaginas = "11-12"
            Case "FrmModificacionMedico"
                rangoPaginas = "21-21"
            Case "FrmModificacionPaciente"
                rangoPaginas = "17-17"
            Case "FrmModificacionSintomas"
                rangoPaginas = "7-8"
            Case "FrmRegistro"
                rangoPaginas = "2-2"
            Case "FrmTipoUsuario"
                rangoPaginas = "15-15"
            Case "FrmVerAdministrativo"
                rangoPaginas = "24-24"
            Case "FrmVerEnfermedades"
                rangoPaginas = "11-11"
            Case "FrmVerMedico"
                rangoPaginas = "20-20"
            Case "FrmVerPaciente"
                rangoPaginas = "16-16"
            Case "FrmVerSintomas"
                rangoPaginas = "6-7"
            Case Else
                Throw New Exception("No se encontró ayuda para esta ventana.")
        End Select
        Return rangoPaginas
    End Function

    Private Sub AbrirPDFAyuda(primeraPagina As Integer, ultimaPagina As Integer)
        Dim rutaSalida As String = "Ayuda de HelloCare.pdf"
        If File.Exists(rutaSalida) Then
            File.Delete(rutaSalida)
        End If
        Dim os As Stream = New StreamWriter(rutaSalida).BaseStream
        Dim doc As New Document()
        Dim lector As PdfReader = New PdfReader("Manual.pdf")
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
