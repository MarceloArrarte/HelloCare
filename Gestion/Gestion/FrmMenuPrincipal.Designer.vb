<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuPrincipal))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnABMSintomas = New System.Windows.Forms.Button()
        Me.btnABMEnfermedades = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblLogeado = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnConfiguracion = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label1.Location = New System.Drawing.Point(720, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 42)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Menú principal"
        '
        'btnABMSintomas
        '
        Me.btnABMSintomas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnABMSintomas.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.btnABMSintomas.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnABMSintomas.Location = New System.Drawing.Point(556, 174)
        Me.btnABMSintomas.Name = "btnABMSintomas"
        Me.btnABMSintomas.Size = New System.Drawing.Size(210, 45)
        Me.btnABMSintomas.TabIndex = 0
        Me.btnABMSintomas.Text = "ABM síntomas"
        Me.btnABMSintomas.UseVisualStyleBackColor = False
        '
        'btnABMEnfermedades
        '
        Me.btnABMEnfermedades.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnABMEnfermedades.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.btnABMEnfermedades.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnABMEnfermedades.Location = New System.Drawing.Point(556, 247)
        Me.btnABMEnfermedades.Name = "btnABMEnfermedades"
        Me.btnABMEnfermedades.Size = New System.Drawing.Size(210, 45)
        Me.btnABMEnfermedades.TabIndex = 1
        Me.btnABMEnfermedades.Text = "ABM enfermedades"
        Me.btnABMEnfermedades.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSalir.Location = New System.Drawing.Point(156, 571)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(179, 45)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'lblLogeado
        '
        Me.lblLogeado.AutoSize = True
        Me.lblLogeado.BackColor = System.Drawing.Color.Transparent
        Me.lblLogeado.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogeado.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblLogeado.Location = New System.Drawing.Point(82, 236)
        Me.lblLogeado.Name = "lblLogeado"
        Me.lblLogeado.Size = New System.Drawing.Size(315, 110)
        Me.lblLogeado.TabIndex = 3
        Me.lblLogeado.Text = "Bienvenido/a," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "#"
        Me.lblLogeado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Image = CType(resources.GetObject("Label6.Image"), System.Drawing.Image)
        Me.Label6.Location = New System.Drawing.Point(-82, 635)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(225, 43)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Traducir"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnConfiguracion
        '
        Me.btnConfiguracion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnConfiguracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.btnConfiguracion.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnConfiguracion.Location = New System.Drawing.Point(905, 553)
        Me.btnConfiguracion.Name = "btnConfiguracion"
        Me.btnConfiguracion.Size = New System.Drawing.Size(210, 63)
        Me.btnConfiguracion.TabIndex = 53
        Me.btnConfiguracion.Text = "Configuración del sistema"
        Me.btnConfiguracion.UseVisualStyleBackColor = False
        '
        'FrmMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1214, 681)
        Me.Controls.Add(Me.btnConfiguracion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblLogeado)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnABMEnfermedades)
        Me.Controls.Add(Me.btnABMSintomas)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmMenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú principal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnABMSintomas As Button
    Friend WithEvents btnABMEnfermedades As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents lblLogeado As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnConfiguracion As Button
End Class
