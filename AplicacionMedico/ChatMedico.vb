Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Text

Public Class ChatMedico

    Dim url As New List(Of String)
    Dim nombreArchivos As New List(Of String)
    Private Sub ChatMedico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As ComponentModel.CancelEventArgs)

    End Sub

    Private Sub OpenFileDialog1_FileOk_1(sender As Object, e As ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub btnArchivo_Click(sender As Object, e As EventArgs) Handles btnArchivo.Click
        Dim resultado As Windows.Forms.DialogResult = OpenFileDialog1.ShowDialog()
        If resultado = Windows.Forms.DialogResult.OK Then
            Dim ruta As String = OpenFileDialog1.FileName
            'agrega a la lista el nombre de los archivos subidos por el medico'
            Dim nombreArchivo As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
            nombreArchivos.Add(nombreArchivo)
            lstArchivos.Items.Add(nombreArchivo)
            url.Add(ruta)

        End If

    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim file As System.IO.StreamWriter
        Dim reader As String
        Dim mensaje As String = "MEDICO :" & txtBoxMensaje.Text
        file = My.Computer.FileSystem.OpenTextFileWriter("C:/Users\\AGUST\\Desktop\\mensajes\\mensajePaciente.txt", False)
        file.Write(txtBoxMensaje.Text)
        file.Close()
        txtBoxMensaje.Clear()
        file = My.Computer.FileSystem.OpenTextFileWriter("C:/Users\\AGUST\\Desktop\\mensajes\\mensajeChat.txt", True)
        file.WriteLine(mensaje)
        file.Close()
        reader = My.Computer.FileSystem.ReadAllText("C:/Users\\AGUST\\Desktop\\mensajes\\mensajeChat.txt", System.Text.Encoding.UTF32)
        txtBoxMensajes.Text = reader



    End Sub

    Private Sub lstArchivos_DoubleClick(sender As Object, e As EventArgs) Handles lstArchivos.DoubleClick

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblNombrePaciente.Click

    End Sub

    Private Sub btnDiagnosticar_Click(sender As Object, e As EventArgs) Handles btnDiagnosticar.Click
        Dim frm As New FrmNuevoDiagnostico
        Me.Dispose()
        frm.Show()
    End Sub
End Class