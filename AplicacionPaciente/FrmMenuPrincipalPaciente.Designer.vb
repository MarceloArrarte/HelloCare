<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuPrincipalPaciente
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
        Me.btnIngresoSintoma = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label1.Location = New System.Drawing.Point(264, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(273, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Menu Principal Paciente"
        '
        'btnIngresoSintoma
        '
        Me.btnIngresoSintoma.Location = New System.Drawing.Point(72, 125)
        Me.btnIngresoSintoma.Name = "btnIngresoSintoma"
        Me.btnIngresoSintoma.Size = New System.Drawing.Size(220, 70)
        Me.btnIngresoSintoma.TabIndex = 1
        Me.btnIngresoSintoma.Text = "Ingreso Sintoma"
        Me.btnIngresoSintoma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIngresoSintoma.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(314, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(359, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ingrese sus sintomas y obtenga un diagnostico primario"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(72, 335)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(142, 54)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'FrmMenuPrincipalPaciente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnIngresoSintoma)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmMenuPrincipalPaciente"
        Me.Text = "FrmMenuPrincipalPaciente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents btnIngresoSintoma As Windows.Forms.Button
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents btnSalir As Windows.Forms.Button
End Class
