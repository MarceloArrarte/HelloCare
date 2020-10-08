<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmContrasenaOlvidada
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
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCedula = New System.Windows.Forms.TextBox()
        Me.btnEnviarCodigo = New System.Windows.Forms.Button()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(38, 9)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(188, 24)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Restaurar contraseña"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ingrese su cédula:"
        '
        'txtCedula
        '
        Me.txtCedula.Location = New System.Drawing.Point(112, 58)
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(139, 20)
        Me.txtCedula.TabIndex = 3
        '
        'btnEnviarCodigo
        '
        Me.btnEnviarCodigo.Location = New System.Drawing.Point(32, 95)
        Me.btnEnviarCodigo.Name = "btnEnviarCodigo"
        Me.btnEnviarCodigo.Size = New System.Drawing.Size(203, 23)
        Me.btnEnviarCodigo.TabIndex = 4
        Me.btnEnviarCodigo.Text = "Solicitar restauración de contraseña"
        Me.btnEnviarCodigo.UseVisualStyleBackColor = True
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(12, 154)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(97, 13)
        Me.lblCodigo.TabIndex = 5
        Me.lblCodigo.Text = "Código de borrado:"
        Me.lblCodigo.Visible = False
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(12, 177)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(239, 20)
        Me.txtCodigo.TabIndex = 6
        Me.txtCodigo.Visible = False
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Location = New System.Drawing.Point(32, 215)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(203, 23)
        Me.btnConfirmar.TabIndex = 7
        Me.btnConfirmar.Text = "Borrar contraseña"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        Me.btnConfirmar.Visible = False
        '
        'FrmContrasenaOlvidada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 250)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.btnEnviarCodigo)
        Me.Controls.Add(Me.txtCedula)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTitulo)
        Me.Name = "FrmContrasenaOlvidada"
        Me.Text = "FrmContrasenaOlvidada"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents txtCedula As Windows.Forms.TextBox
    Friend WithEvents btnEnviarCodigo As Windows.Forms.Button
    Friend WithEvents lblCodigo As Windows.Forms.Label
    Friend WithEvents txtCodigo As Windows.Forms.TextBox
    Friend WithEvents btnConfirmar As Windows.Forms.Button
End Class
