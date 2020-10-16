<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChatPaciente
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChatPaciente))
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.txtMensaje = New System.Windows.Forms.RichTextBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.btnAdjuntar = New System.Windows.Forms.Button()
        Me.lblMedico = New System.Windows.Forms.Label()
        Me.lstArchivos = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.expAdjuntar = New System.Windows.Forms.OpenFileDialog()
        Me.txtConversacion = New System.Windows.Forms.TextBox()
        Me.tmrActualizaMensajes = New System.Windows.Forms.Timer(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSalir.Location = New System.Drawing.Point(153, 581)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(161, 49)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Volver"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'txtMensaje
        '
        Me.txtMensaje.Location = New System.Drawing.Point(496, 527)
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(561, 84)
        Me.txtMensaje.TabIndex = 4
        Me.txtMensaje.Text = ""
        '
        'btnEnviar
        '
        Me.btnEnviar.BackgroundImage = CType(resources.GetObject("btnEnviar.BackgroundImage"), System.Drawing.Image)
        Me.btnEnviar.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnEnviar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnEnviar.Location = New System.Drawing.Point(1063, 527)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(117, 39)
        Me.btnEnviar.TabIndex = 5
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'btnAdjuntar
        '
        Me.btnAdjuntar.BackgroundImage = CType(resources.GetObject("btnAdjuntar.BackgroundImage"), System.Drawing.Image)
        Me.btnAdjuntar.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnAdjuntar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAdjuntar.Location = New System.Drawing.Point(1063, 572)
        Me.btnAdjuntar.Name = "btnAdjuntar"
        Me.btnAdjuntar.Size = New System.Drawing.Size(117, 39)
        Me.btnAdjuntar.TabIndex = 6
        Me.btnAdjuntar.Text = "Adjuntar"
        Me.btnAdjuntar.UseVisualStyleBackColor = True
        Me.btnAdjuntar.Visible = False
        '
        'lblMedico
        '
        Me.lblMedico.BackColor = System.Drawing.Color.Transparent
        Me.lblMedico.Font = New System.Drawing.Font("Cosmic", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblMedico.Location = New System.Drawing.Point(488, 28)
        Me.lblMedico.Name = "lblMedico"
        Me.lblMedico.Size = New System.Drawing.Size(608, 84)
        Me.lblMedico.TabIndex = 10
        Me.lblMedico.Text = "Usted se está comunicando con" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "#"
        Me.lblMedico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstArchivos
        '
        Me.lstArchivos.FormattingEnabled = True
        Me.lstArchivos.Location = New System.Drawing.Point(47, 94)
        Me.lstArchivos.Name = "lstArchivos"
        Me.lstArchivos.Size = New System.Drawing.Size(381, 472)
        Me.lstArchivos.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Cosmic", 21.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(168, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 33)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "ARCHIVOS"
        '
        'expAdjuntar
        '
        Me.expAdjuntar.FileName = "OpenFileDialog1"
        '
        'txtConversacion
        '
        Me.txtConversacion.AcceptsReturn = True
        Me.txtConversacion.AcceptsTab = True
        Me.txtConversacion.BackColor = System.Drawing.Color.White
        Me.txtConversacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConversacion.Font = New System.Drawing.Font("Lato", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConversacion.Location = New System.Drawing.Point(496, 132)
        Me.txtConversacion.Multiline = True
        Me.txtConversacion.Name = "txtConversacion"
        Me.txtConversacion.ReadOnly = True
        Me.txtConversacion.Size = New System.Drawing.Size(684, 387)
        Me.txtConversacion.TabIndex = 14
        '
        'tmrActualizaMensajes
        '
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
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Traducir"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmChatPaciente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1214, 681)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lstArchivos)
        Me.Controls.Add(Me.lblMedico)
        Me.Controls.Add(Me.txtConversacion)
        Me.Controls.Add(Me.btnAdjuntar)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.txtMensaje)
        Me.Controls.Add(Me.btnSalir)
        Me.DoubleBuffered = True
        Me.Name = "FrmChatPaciente"
        Me.Text = "ChatPaciente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Splitter1 As Windows.Forms.Splitter
    Friend WithEvents btnSalir As Windows.Forms.Button
    Friend WithEvents txtMensaje As Windows.Forms.RichTextBox
    Friend WithEvents btnEnviar As Windows.Forms.Button
    Friend WithEvents btnAdjuntar As Windows.Forms.Button
    Friend WithEvents lblMedico As Windows.Forms.Label
    Friend WithEvents lstArchivos As Windows.Forms.ListBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents expAdjuntar As Windows.Forms.OpenFileDialog
    Friend WithEvents txtConversacion As Windows.Forms.TextBox
    Friend WithEvents tmrActualizaMensajes As Windows.Forms.Timer
    Friend WithEvents Label5 As Windows.Forms.Label
End Class
