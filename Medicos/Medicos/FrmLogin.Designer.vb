<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.txtCedula = New System.Windows.Forms.TextBox()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.chkMostrarContrasena = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtCedula
        '
        Me.txtCedula.BackColor = System.Drawing.Color.DarkGray
        Me.txtCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!)
        Me.txtCedula.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.txtCedula.Location = New System.Drawing.Point(757, 209)
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(314, 44)
        Me.txtCedula.TabIndex = 0
        Me.txtCedula.Text = "Cédula"
        Me.txtCedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtContrasena
        '
        Me.txtContrasena.BackColor = System.Drawing.Color.DarkGray
        Me.txtContrasena.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!)
        Me.txtContrasena.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.txtContrasena.Location = New System.Drawing.Point(760, 348)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.Size = New System.Drawing.Size(314, 44)
        Me.txtContrasena.TabIndex = 1
        Me.txtContrasena.Text = "Contraseña"
        Me.txtContrasena.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnIngresar
        '
        Me.btnIngresar.BackgroundImage = CType(resources.GetObject("btnIngresar.BackgroundImage"), System.Drawing.Image)
        Me.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnIngresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.btnIngresar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnIngresar.Location = New System.Drawing.Point(806, 487)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(181, 45)
        Me.btnIngresar.TabIndex = 3
        Me.btnIngresar.Text = "INGRESAR"
        Me.btnIngresar.UseVisualStyleBackColor = True
        '
        'chkMostrarContrasena
        '
        Me.chkMostrarContrasena.BackColor = System.Drawing.Color.Transparent
        Me.chkMostrarContrasena.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.chkMostrarContrasena.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkMostrarContrasena.Location = New System.Drawing.Point(826, 421)
        Me.chkMostrarContrasena.Name = "chkMostrarContrasena"
        Me.chkMostrarContrasena.Size = New System.Drawing.Size(161, 22)
        Me.chkMostrarContrasena.TabIndex = 2
        Me.chkMostrarContrasena.Text = "Mostrar Contraseña"
        Me.chkMostrarContrasena.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Underline)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.Location = New System.Drawing.Point(708, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(399, 55)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "INICIAR SESIÓN"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(99, 330)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 37)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Médicos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(12, 263)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(320, 55)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "BIENVENIDO"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.Location = New System.Drawing.Point(697, 209)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 44)
        Me.Label1.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.Location = New System.Drawing.Point(697, 348)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 44)
        Me.Label2.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(729, 548)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(345, 37)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "¿Contraseña olvidada?"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Image = CType(resources.GetObject("Label7.Image"), System.Drawing.Image)
        Me.Label7.Location = New System.Drawing.Point(-80, 620)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(225, 43)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Traducir"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1214, 681)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkMostrarContrasena)
        Me.Controls.Add(Me.txtCedula)
        Me.Controls.Add(Me.txtContrasena)
        Me.Controls.Add(Me.btnIngresar)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login de médicos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCedula As Windows.Forms.TextBox
    Friend WithEvents txtContrasena As Windows.Forms.TextBox
    Friend WithEvents btnIngresar As Windows.Forms.Button
    Friend WithEvents chkMostrarContrasena As Windows.Forms.CheckBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class
