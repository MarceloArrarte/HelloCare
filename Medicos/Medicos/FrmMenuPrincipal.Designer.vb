<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMenuPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuPrincipal))
        Me.btnPeticiones = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnHistorialPacientes = New System.Windows.Forms.Button()
        Me.btnHistorialChat = New System.Windows.Forms.Button()
        Me.lblLogeado = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnPeticiones
        '
        Me.btnPeticiones.BackgroundImage = CType(resources.GetObject("btnPeticiones.BackgroundImage"), System.Drawing.Image)
        Me.btnPeticiones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPeticiones.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPeticiones.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnPeticiones.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnPeticiones.Location = New System.Drawing.Point(756, 230)
        Me.btnPeticiones.Name = "btnPeticiones"
        Me.btnPeticiones.Size = New System.Drawing.Size(234, 63)
        Me.btnPeticiones.TabIndex = 0
        Me.btnPeticiones.Text = "Peticiones de chat"
        Me.btnPeticiones.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSalir.Location = New System.Drawing.Point(147, 573)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(161, 49)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Volver"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnHistorialPacientes
        '
        Me.btnHistorialPacientes.BackgroundImage = CType(resources.GetObject("btnHistorialPacientes.BackgroundImage"), System.Drawing.Image)
        Me.btnHistorialPacientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnHistorialPacientes.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnHistorialPacientes.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnHistorialPacientes.Location = New System.Drawing.Point(756, 462)
        Me.btnHistorialPacientes.Name = "btnHistorialPacientes"
        Me.btnHistorialPacientes.Size = New System.Drawing.Size(234, 63)
        Me.btnHistorialPacientes.TabIndex = 2
        Me.btnHistorialPacientes.Text = "Historial de pacientes"
        Me.btnHistorialPacientes.UseVisualStyleBackColor = True
        '
        'btnHistorialChat
        '
        Me.btnHistorialChat.BackgroundImage = CType(resources.GetObject("btnHistorialChat.BackgroundImage"), System.Drawing.Image)
        Me.btnHistorialChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnHistorialChat.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnHistorialChat.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnHistorialChat.Location = New System.Drawing.Point(756, 344)
        Me.btnHistorialChat.Name = "btnHistorialChat"
        Me.btnHistorialChat.Size = New System.Drawing.Size(234, 63)
        Me.btnHistorialChat.TabIndex = 1
        Me.btnHistorialChat.Text = "Historial de chats"
        Me.btnHistorialChat.UseVisualStyleBackColor = True
        '
        'lblLogeado
        '
        Me.lblLogeado.BackColor = System.Drawing.Color.Transparent
        Me.lblLogeado.Font = New System.Drawing.Font("Cosmic", 26.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblLogeado.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblLogeado.Location = New System.Drawing.Point(25, 264)
        Me.lblLogeado.Name = "lblLogeado"
        Me.lblLogeado.Size = New System.Drawing.Size(425, 148)
        Me.lblLogeado.TabIndex = 4
        Me.lblLogeado.Text = "Bienvenido/a," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "#"
        Me.lblLogeado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.Location = New System.Drawing.Point(-80, 620)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(225, 43)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Traducir"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Cosmic", 26.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(749, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(241, 40)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Menú principal."
        '
        'FrmMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1214, 681)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnHistorialPacientes)
        Me.Controls.Add(Me.lblLogeado)
        Me.Controls.Add(Me.btnHistorialChat)
        Me.Controls.Add(Me.btnPeticiones)
        Me.DoubleBuffered = True
        Me.Name = "FrmMenuPrincipal"
        Me.Text = "FrmMenuMedico"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPeticiones As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnHistorialPacientes As Button
    Friend WithEvents btnHistorialChat As Button
    Friend WithEvents lblLogeado As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
End Class
