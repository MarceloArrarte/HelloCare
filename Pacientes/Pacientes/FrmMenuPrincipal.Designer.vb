<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMenuPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuPrincipal))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnIngresoSintoma = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnHistorialDiagnosticos = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblLogeado = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(701, 36)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 42)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Menú principal"
        '
        'btnIngresoSintoma
        '
        Me.btnIngresoSintoma.BackColor = System.Drawing.Color.Transparent
        Me.btnIngresoSintoma.BackgroundImage = CType(resources.GetObject("btnIngresoSintoma.BackgroundImage"), System.Drawing.Image)
        Me.btnIngresoSintoma.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresoSintoma.ForeColor = System.Drawing.Color.White
        Me.btnIngresoSintoma.Location = New System.Drawing.Point(560, 152)
        Me.btnIngresoSintoma.Margin = New System.Windows.Forms.Padding(2)
        Me.btnIngresoSintoma.Name = "btnIngresoSintoma"
        Me.btnIngresoSintoma.Size = New System.Drawing.Size(198, 61)
        Me.btnIngresoSintoma.TabIndex = 0
        Me.btnIngresoSintoma.Text = "Ingresar un síntoma"
        Me.btnIngresoSintoma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIngresoSintoma.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.Label2.Location = New System.Drawing.Point(807, 152)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(323, 90)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ingrese sus síntomas y obtenga un diagnóstico automático del sistema."
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Transparent
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(147, 573)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(161, 49)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.Text = "Volver"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnHistorialDiagnosticos
        '
        Me.btnHistorialDiagnosticos.BackColor = System.Drawing.Color.Transparent
        Me.btnHistorialDiagnosticos.BackgroundImage = CType(resources.GetObject("btnHistorialDiagnosticos.BackgroundImage"), System.Drawing.Image)
        Me.btnHistorialDiagnosticos.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistorialDiagnosticos.ForeColor = System.Drawing.Color.White
        Me.btnHistorialDiagnosticos.Location = New System.Drawing.Point(560, 268)
        Me.btnHistorialDiagnosticos.Margin = New System.Windows.Forms.Padding(2)
        Me.btnHistorialDiagnosticos.Name = "btnHistorialDiagnosticos"
        Me.btnHistorialDiagnosticos.Size = New System.Drawing.Size(198, 60)
        Me.btnHistorialDiagnosticos.TabIndex = 3
        Me.btnHistorialDiagnosticos.Text = "Historial de diagnósticos"
        Me.btnHistorialDiagnosticos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnHistorialDiagnosticos.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(807, 268)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(323, 77)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Vea los diagnósticos recibidos por el sistema y médicos."
        '
        'lblLogeado
        '
        Me.lblLogeado.AutoSize = True
        Me.lblLogeado.BackColor = System.Drawing.Color.Transparent
        Me.lblLogeado.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblLogeado.ForeColor = System.Drawing.Color.White
        Me.lblLogeado.Location = New System.Drawing.Point(103, 292)
        Me.lblLogeado.Name = "lblLogeado"
        Me.lblLogeado.Size = New System.Drawing.Size(258, 84)
        Me.lblLogeado.TabIndex = 5
        Me.lblLogeado.Text = "Bienvenido/a," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "#"
        Me.lblLogeado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.Location = New System.Drawing.Point(-80, 620)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(225, 43)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Traducir"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(1213, 681)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblLogeado)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnHistorialDiagnosticos)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnIngresoSintoma)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "FrmMenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú principal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents btnIngresoSintoma As Windows.Forms.Button
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents btnSalir As Windows.Forms.Button
    Friend WithEvents btnHistorialDiagnosticos As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents lblLogeado As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
End Class
