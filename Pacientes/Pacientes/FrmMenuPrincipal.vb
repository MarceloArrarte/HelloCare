Imports System.Windows.Forms

Public Class FrmMenuPrincipal
    ' Esta bandera se implementa para indicar al evento FormClosing 
    ' si el formulario se cierra para salir al login, o para abrir la siguiente ventana
    Private cierraSesion As Boolean = True
    Private Sub btnIngresoSintoma_Click(sender As Object, e As EventArgs) Handles btnIngresoSintoma.Click
        cierraSesion = False
        Dim frm As New FrmIngresoSintoma
        frm.Show()
        Me.Close()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMenuPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If cierraSesion Then
            ' Si el usuario quiere cerrar sesión, pide confirmación
            If MsgBox("¿Confirma que desea cerrar su sesión?", MsgBoxStyle.YesNo, "Cerrar sesión") = MsgBoxResult.Yes Then
                Dim frm As New FrmLogin
                frm.Show()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btnHistorialDiagnosticos_Click(sender As Object, e As EventArgs) Handles btnHistorialDiagnosticos.Click
        Dim frm As New FrmHistorialDiagnosticos
        frm.Show()
        Me.Hide()
    End Sub
End Class