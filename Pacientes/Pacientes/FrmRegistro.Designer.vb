<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRegistro
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.txtRepetir = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkMostrarContrasena = New System.Windows.Forms.CheckBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtContrasena
        '
        Me.txtContrasena.Location = New System.Drawing.Point(166, 61)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.Size = New System.Drawing.Size(142, 20)
        Me.txtContrasena.TabIndex = 1
        Me.txtContrasena.UseSystemPasswordChar = True
        '
        'txtRepetir
        '
        Me.txtRepetir.Location = New System.Drawing.Point(166, 96)
        Me.txtRepetir.Name = "txtRepetir"
        Me.txtRepetir.Size = New System.Drawing.Size(142, 20)
        Me.txtRepetir.TabIndex = 2
        Me.txtRepetir.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ingrese su nueva contraseña:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Repita su contraseña:"
        '
        'chkMostrarContrasena
        '
        Me.chkMostrarContrasena.AutoSize = True
        Me.chkMostrarContrasena.Location = New System.Drawing.Point(103, 132)
        Me.chkMostrarContrasena.Name = "chkMostrarContrasena"
        Me.chkMostrarContrasena.Size = New System.Drawing.Size(117, 17)
        Me.chkMostrarContrasena.TabIndex = 5
        Me.chkMostrarContrasena.Text = "Mostrar contraseña"
        Me.chkMostrarContrasena.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(91, 173)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(129, 23)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "Guardar contraseña"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(47, 9)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(231, 24)
        Me.lblTitulo.TabIndex = 7
        Me.lblTitulo.Text = "Registro de nuevo usuario"
        '
        'FrmRegistro
        '
        Me.AcceptButton = Me.btnGuardar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 208)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.chkMostrarContrasena)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRepetir)
        Me.Controls.Add(Me.txtContrasena)
        Me.Name = "FrmRegistro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmRegistro"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtContrasena As Windows.Forms.TextBox
    Friend WithEvents txtRepetir As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents chkMostrarContrasena As Windows.Forms.CheckBox
    Friend WithEvents btnGuardar As Windows.Forms.Button
    Friend WithEvents lblTitulo As Windows.Forms.Label
End Class
