<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChatMedico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChatMedico))
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.txtMensaje = New System.Windows.Forms.RichTextBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.btnAdjuntar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNombrePaciente = New System.Windows.Forms.Label()
        Me.lstArchivos = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.expAdjuntar = New System.Windows.Forms.OpenFileDialog()
        Me.txtConversacion = New System.Windows.Forms.TextBox()
        Me.btnDiagnosticar = New System.Windows.Forms.Button()
        Me.tmrActualizaMensajes = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSalir.Location = New System.Drawing.Point(151, 552)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(161, 49)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'txtMensaje
        '
        Me.txtMensaje.Location = New System.Drawing.Point(512, 527)
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(545, 84)
        Me.txtMensaje.TabIndex = 4
        Me.txtMensaje.Text = ""
        '
        'btnEnviar
        '
        Me.btnEnviar.BackgroundImage = CType(resources.GetObject("btnEnviar.BackgroundImage"), System.Drawing.Image)
        Me.btnEnviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
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
        Me.btnAdjuntar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.btnAdjuntar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAdjuntar.Location = New System.Drawing.Point(1063, 572)
        Me.btnAdjuntar.Name = "btnAdjuntar"
        Me.btnAdjuntar.Size = New System.Drawing.Size(117, 39)
        Me.btnAdjuntar.TabIndex = 6
        Me.btnAdjuntar.Text = "Adjuntar"
        Me.btnAdjuntar.UseVisualStyleBackColor = True
        Me.btnAdjuntar.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label3.Location = New System.Drawing.Point(504, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(580, 42)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Usted se está comunicando con"
        '
        'lblNombrePaciente
        '
        Me.lblNombrePaciente.AutoSize = True
        Me.lblNombrePaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombrePaciente.Location = New System.Drawing.Point(505, 64)
        Me.lblNombrePaciente.Name = "lblNombrePaciente"
        Me.lblNombrePaciente.Size = New System.Drawing.Size(176, 37)
        Me.lblNombrePaciente.TabIndex = 11
        Me.lblNombrePaciente.Text = "@paciente"
        '
        'lstArchivos
        '
        Me.lstArchivos.FormattingEnabled = True
        Me.lstArchivos.Location = New System.Drawing.Point(45, 65)
        Me.lstArchivos.Name = "lstArchivos"
        Me.lstArchivos.Size = New System.Drawing.Size(381, 472)
        Me.lstArchivos.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Underline)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(166, 16)
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
        Me.txtConversacion.BackColor = System.Drawing.SystemColors.Control
        Me.txtConversacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConversacion.Font = New System.Drawing.Font("Lato", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConversacion.Location = New System.Drawing.Point(512, 136)
        Me.txtConversacion.Multiline = True
        Me.txtConversacion.Name = "txtConversacion"
        Me.txtConversacion.ReadOnly = True
        Me.txtConversacion.Size = New System.Drawing.Size(668, 385)
        Me.txtConversacion.TabIndex = 14
        '
        'btnDiagnosticar
        '
        Me.btnDiagnosticar.Location = New System.Drawing.Point(166, 386)
        Me.btnDiagnosticar.Name = "btnDiagnosticar"
        Me.btnDiagnosticar.Size = New System.Drawing.Size(75, 23)
        Me.btnDiagnosticar.TabIndex = 15
        Me.btnDiagnosticar.Text = "Diagnosticar"
        Me.btnDiagnosticar.UseVisualStyleBackColor = True
        '
        'tmrActualizaMensajes
        '
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.Location = New System.Drawing.Point(-80, 620)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(225, 43)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Traducir"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmChatMedico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1214, 681)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstArchivos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNombrePaciente)
        Me.Controls.Add(Me.btnDiagnosticar)
        Me.Controls.Add(Me.txtConversacion)
        Me.Controls.Add(Me.btnAdjuntar)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.txtMensaje)
        Me.Controls.Add(Me.btnSalir)
        Me.DoubleBuffered = True
        Me.Name = "FrmChatMedico"
        Me.Text = "ChatMedico"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Splitter1 As Windows.Forms.Splitter
    Friend WithEvents btnSalir As Windows.Forms.Button
    Friend WithEvents txtMensaje As Windows.Forms.RichTextBox
    Friend WithEvents btnEnviar As Windows.Forms.Button
    Friend WithEvents btnAdjuntar As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents lblNombrePaciente As Windows.Forms.Label
    Friend WithEvents lstArchivos As Windows.Forms.ListBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents expAdjuntar As Windows.Forms.OpenFileDialog
    Friend WithEvents txtConversacion As Windows.Forms.TextBox
    Friend WithEvents btnDiagnosticar As Button
    Friend WithEvents tmrActualizaMensajes As Timer
    Friend WithEvents Label1 As Label
End Class
