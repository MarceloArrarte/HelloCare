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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmComentariosAdicionales))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtComentariosAdicionales = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEnviarConsulta = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label1.Location = New System.Drawing.Point(566, 195)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(594, 62)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Si lo desea, puede agregar información extra antes de contactar al médico, con el" &
    " fin de mejorar la atención que le brindamos:"
        '
        'txtComentariosAdicionales
        '
        Me.txtComentariosAdicionales.Location = New System.Drawing.Point(571, 269)
        Me.txtComentariosAdicionales.Multiline = True
        Me.txtComentariosAdicionales.Name = "txtComentariosAdicionales"
        Me.txtComentariosAdicionales.Size = New System.Drawing.Size(566, 273)
        Me.txtComentariosAdicionales.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.BackgroundImage = CType(resources.GetObject("btnCancelar.BackgroundImage"), System.Drawing.Image)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnCancelar.Location = New System.Drawing.Point(147, 573)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(161, 49)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnEnviarConsulta
        '
        Me.btnEnviarConsulta.BackColor = System.Drawing.Color.Transparent
        Me.btnEnviarConsulta.BackgroundImage = CType(resources.GetObject("btnEnviarConsulta.BackgroundImage"), System.Drawing.Image)
        Me.btnEnviarConsulta.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnEnviarConsulta.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnEnviarConsulta.Location = New System.Drawing.Point(786, 573)
        Me.btnEnviarConsulta.Name = "btnEnviarConsulta"
        Me.btnEnviarConsulta.Size = New System.Drawing.Size(161, 49)
        Me.btnEnviarConsulta.TabIndex = 3
        Me.btnEnviarConsulta.Text = "Enviar consulta"
        Me.btnEnviarConsulta.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Cosmic", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(103, 292)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(254, 86)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Bienvenido/a," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "#"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Cosmic", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(633, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(450, 43)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Comentarios adicionales"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.Location = New System.Drawing.Point(-80, 620)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(225, 43)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Traducir"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmComentariosAdicionales
        '
        Me.AcceptButton = Me.btnEnviarConsulta
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(1214, 681)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnEnviarConsulta)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtComentariosAdicionales)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Name = "FrmComentariosAdicionales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmComentariosAdicionales"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents txtComentariosAdicionales As Windows.Forms.TextBox
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents btnEnviarConsulta As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
End Class
