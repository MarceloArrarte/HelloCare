Imports System.IO
Imports Clases

Public Module Config
    Public idiomaSeleccionado As Idiomas = Idiomas.Espanol
    Public pacienteLogeado As Paciente
    Public medicoLogeado As Medico
    Public administrativoLogeado As Administrativo
    'Public rutaRecursos As String

    Public Sub InicializarConfig(tipoUsuario As TiposUsuario)
        'CargarRutaRecursos()
    End Sub



    'Private Sub CargarRutaRecursos()
    '    If File.Exists("hellocare.ini") Then
    '        Dim lineaRuta As String = (From s As String In File.ReadAllLines("hellocare.ini") Where s.StartsWith("recursos=") Select s).SingleOrDefault
    '        If lineaRuta IsNot Nothing Then
    '            Dim indiceValor As Integer = lineaRuta.IndexOf("="c)
    '            rutaRecursos = lineaRuta.Substring(indiceValor, lineaRuta.Length - indiceValor)
    '        Else
    '            rutaRecursos = "../../"
    '        End If
    '    End If
    'End Sub
End Module
