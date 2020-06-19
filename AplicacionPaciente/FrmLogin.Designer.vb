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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCedula = New System.Windows.Forms.TextBox()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.chkMostrarContrasena = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(148, 189)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(517, 42)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "INGRESE SU CONTRASEÑA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(196, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(409, 42)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "INGRESE SU CÉDULA"
        '
        'txtCedula
        '
        Me.txtCedula.Location = New System.Drawing.Point(251, 123)
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(301, 20)
        Me.txtCedula.TabIndex = 0
        '
        'txtContrasena
        '
        Me.txtContrasena.Location = New System.Drawing.Point(251, 243)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.Size = New System.Drawing.Size(301, 20)
        Me.txtContrasena.TabIndex = 1
        Me.txtContrasena.UseSystemPasswordChar = True
        '
        'btnIngresar
        '
        Me.btnIngresar.Location = New System.Drawing.Point(333, 332)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(149, 45)
        Me.btnIngresar.TabIndex = 3
        Me.btnIngresar.Text = "INGRESAR"
        Me.btnIngresar.UseVisualStyleBackColor = True
        '
        'chkMostrarContrasena
        '
        Me.chkMostrarContrasena.AutoSize = True
        Me.chkMostrarContrasena.Location = New System.Drawing.Point(347, 295)
        Me.chkMostrarContrasena.Name = "chkMostrarContrasena"
        Me.chkMostrarContrasena.Size = New System.Drawing.Size(118, 17)
        Me.chkMostrarContrasena.TabIndex = 2
        Me.chkMostrarContrasena.Text = "Mostrar Contraseña"
        Me.chkMostrarContrasena.UseVisualStyleBackColor = True
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.chkMostrarContrasena)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCedula)
        Me.Controls.Add(Me.txtContrasena)
        Me.Controls.Add(Me.btnIngresar)
        Me.Name = "FrmLogin"
        Me.Text = "frmPaciente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents txtCedula As Windows.Forms.TextBox
    Friend WithEvents txtContrasena As Windows.Forms.TextBox
    Friend WithEvents btnIngresar As Windows.Forms.Button
    Friend WithEvents chkMostrarContrasena As Windows.Forms.CheckBox
End Class
