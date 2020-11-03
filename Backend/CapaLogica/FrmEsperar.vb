Imports Clases

Public Class FrmEsperar
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                lblMensaje.Text = "Por favor, espere un momento."
            Case Idiomas.Ingles
                lblMensaje.Text = "Please, wait a moment."
        End Select
    End Sub
End Class