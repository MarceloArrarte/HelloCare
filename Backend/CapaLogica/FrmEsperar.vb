Imports Clases

Friend Class FrmEsperar
    Friend Sub New(msjES As String, msjEN As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Select Case idiomaSeleccionado
            Case Idiomas.Espanol
                lblMensaje.Text = msjES
            Case Idiomas.Ingles
                lblMensaje.Text = msjEN
        End Select
    End Sub
End Class