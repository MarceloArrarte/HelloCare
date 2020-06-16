<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAltaEnfermedades
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtRecomendacionesSintoma = New System.Windows.Forms.TextBox()
        Me.txtDescripcionSintoma = New System.Windows.Forms.TextBox()
        Me.txtNombreEnfermedad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtGravedadSintoma = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(220, 454)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Volver"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(571, 454)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Agregar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtRecomendacionesSintoma
        '
        Me.txtRecomendacionesSintoma.Location = New System.Drawing.Point(220, 232)
        Me.txtRecomendacionesSintoma.Multiline = True
        Me.txtRecomendacionesSintoma.Name = "txtRecomendacionesSintoma"
        Me.txtRecomendacionesSintoma.Size = New System.Drawing.Size(426, 189)
        Me.txtRecomendacionesSintoma.TabIndex = 17
        '
        'txtDescripcionSintoma
        '
        Me.txtDescripcionSintoma.Location = New System.Drawing.Point(219, 89)
        Me.txtDescripcionSintoma.Multiline = True
        Me.txtDescripcionSintoma.Name = "txtDescripcionSintoma"
        Me.txtDescripcionSintoma.Size = New System.Drawing.Size(427, 72)
        Me.txtDescripcionSintoma.TabIndex = 16
        '
        'txtNombreEnfermedad
        '
        Me.txtNombreEnfermedad.Location = New System.Drawing.Point(219, 48)
        Me.txtNombreEnfermedad.Multiline = True
        Me.txtNombreEnfermedad.Name = "txtNombreEnfermedad"
        Me.txtNombreEnfermedad.Size = New System.Drawing.Size(427, 25)
        Me.txtNombreEnfermedad.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(52, 235)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Recomendaciones:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(86, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Descripcion:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(104, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Nombre:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(340, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Bienvenido al agregar enfermedades"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(86, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Gravedad:"
        '
        'txtGravedadSintoma
        '
        Me.txtGravedadSintoma.Location = New System.Drawing.Point(219, 170)
        Me.txtGravedadSintoma.Multiline = True
        Me.txtGravedadSintoma.Name = "txtGravedadSintoma"
        Me.txtGravedadSintoma.Size = New System.Drawing.Size(427, 46)
        Me.txtGravedadSintoma.TabIndex = 23
        '
        'FrmAltaEnfermedades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 510)
        Me.Controls.Add(Me.txtGravedadSintoma)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtRecomendacionesSintoma)
        Me.Controls.Add(Me.txtDescripcionSintoma)
        Me.Controls.Add(Me.txtNombreEnfermedad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmAltaEnfermedades"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents txtRecomendacionesSintoma As TextBox
    Friend WithEvents txtDescripcionSintoma As TextBox
    Friend WithEvents txtNombreEnfermedad As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtGravedadSintoma As TextBox
End Class
