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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnABMSintomas = New System.Windows.Forms.Button()
        Me.btnABMEnfermedades = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bienvenido al Sistema de Gestion"
        '
        'btnABMSintomas
        '
        Me.btnABMSintomas.Location = New System.Drawing.Point(60, 55)
        Me.btnABMSintomas.Name = "btnABMSintomas"
        Me.btnABMSintomas.Size = New System.Drawing.Size(122, 23)
        Me.btnABMSintomas.TabIndex = 0
        Me.btnABMSintomas.Text = "ABM síntomas"
        Me.btnABMSintomas.UseVisualStyleBackColor = True
        '
        'btnABMEnfermedades
        '
        Me.btnABMEnfermedades.Location = New System.Drawing.Point(60, 106)
        Me.btnABMEnfermedades.Name = "btnABMEnfermedades"
        Me.btnABMEnfermedades.Size = New System.Drawing.Size(122, 23)
        Me.btnABMEnfermedades.TabIndex = 1
        Me.btnABMEnfermedades.Text = "ABM enfermedades"
        Me.btnABMEnfermedades.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(60, 222)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(122, 23)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'FrmMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(247, 276)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnABMEnfermedades)
        Me.Controls.Add(Me.btnABMSintomas)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmMenuPrincipal"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnABMSintomas As Button
    Friend WithEvents btnABMEnfermedades As Button
    Friend WithEvents btnSalir As Button
End Class
