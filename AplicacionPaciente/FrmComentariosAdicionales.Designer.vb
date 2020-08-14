<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmComentariosAdicionales
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtComentariosAdicionales = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEnviarConsulta = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(318, 43)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Si lo desea, puede agregar información extra antes de contactar al médico, con el" &
    " fin de mejorar la atención que le brindamos:"
        '
        'txtComentariosAdicionales
        '
        Me.txtComentariosAdicionales.Location = New System.Drawing.Point(16, 50)
        Me.txtComentariosAdicionales.Multiline = True
        Me.txtComentariosAdicionales.Name = "txtComentariosAdicionales"
        Me.txtComentariosAdicionales.Size = New System.Drawing.Size(315, 111)
        Me.txtComentariosAdicionales.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(16, 177)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(91, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEnviarConsulta
        '
        Me.btnEnviarConsulta.Location = New System.Drawing.Point(229, 177)
        Me.btnEnviarConsulta.Name = "btnEnviarConsulta"
        Me.btnEnviarConsulta.Size = New System.Drawing.Size(102, 23)
        Me.btnEnviarConsulta.TabIndex = 3
        Me.btnEnviarConsulta.Text = "Enviar consulta"
        Me.btnEnviarConsulta.UseVisualStyleBackColor = True
        '
        'FrmComentariosAdicionales
        '
        Me.AcceptButton = Me.btnEnviarConsulta
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(343, 212)
        Me.Controls.Add(Me.btnEnviarConsulta)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtComentariosAdicionales)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmComentariosAdicionales"
        Me.Text = "FrmComentariosAdicionales"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents txtComentariosAdicionales As Windows.Forms.TextBox
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents btnEnviarConsulta As Windows.Forms.Button
End Class
