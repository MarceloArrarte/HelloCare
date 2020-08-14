<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDiagnosticosDiferenciales
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tblDiagnosticosDiferenciales = New System.Windows.Forms.DataGridView()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.lblNombreMedico = New System.Windows.Forms.Label()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.tblDiagnosticosDiferenciales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!)
        Me.Label1.Location = New System.Drawing.Point(172, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(228, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Diagnósticos diferenciales"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(580, 43)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Aquí se muestran todos los diagnósticos diferenciales realizados por su médico, d" &
    "e acuerdo al diagnóstico primario realizado por el sistema."
        '
        'tblDiagnosticosDiferenciales
        '
        Me.tblDiagnosticosDiferenciales.AllowUserToAddRows = False
        Me.tblDiagnosticosDiferenciales.AllowUserToDeleteRows = False
        Me.tblDiagnosticosDiferenciales.AllowUserToResizeColumns = False
        Me.tblDiagnosticosDiferenciales.AllowUserToResizeRows = False
        Me.tblDiagnosticosDiferenciales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblDiagnosticosDiferenciales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.tblDiagnosticosDiferenciales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblDiagnosticosDiferenciales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3, Me.Column1, Me.Column4})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblDiagnosticosDiferenciales.DefaultCellStyle = DataGridViewCellStyle1
        Me.tblDiagnosticosDiferenciales.Location = New System.Drawing.Point(13, 125)
        Me.tblDiagnosticosDiferenciales.Name = "tblDiagnosticosDiferenciales"
        Me.tblDiagnosticosDiferenciales.ReadOnly = True
        Me.tblDiagnosticosDiferenciales.RowHeadersVisible = False
        Me.tblDiagnosticosDiferenciales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tblDiagnosticosDiferenciales.Size = New System.Drawing.Size(580, 279)
        Me.tblDiagnosticosDiferenciales.TabIndex = 2
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(266, 415)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver.TabIndex = 3
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'lblNombreMedico
        '
        Me.lblNombreMedico.AutoSize = True
        Me.lblNombreMedico.Location = New System.Drawing.Point(12, 48)
        Me.lblNombreMedico.Name = "lblNombreMedico"
        Me.lblNombreMedico.Size = New System.Drawing.Size(111, 13)
        Me.lblNombreMedico.TabIndex = 4
        Me.lblNombreMedico.Text = "Nombre del médico: #"
        '
        'Column2
        '
        Me.Column2.FillWeight = 10.0!
        Me.Column2.HeaderText = "N°"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.FillWeight = 25.0!
        Me.Column3.HeaderText = "Enfermedad"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.FillWeight = 50.0!
        Me.Column1.HeaderText = "Conducta a seguir"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.FillWeight = 25.0!
        Me.Column4.HeaderText = "Fecha y hora"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'FrmDiagnosticosDiferenciales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 450)
        Me.Controls.Add(Me.lblNombreMedico)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.tblDiagnosticosDiferenciales)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmDiagnosticosDiferenciales"
        Me.Text = "FrmDiagnosticosDiferenciales"
        CType(Me.tblDiagnosticosDiferenciales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents tblDiagnosticosDiferenciales As Windows.Forms.DataGridView
    Friend WithEvents btnVolver As Windows.Forms.Button
    Friend WithEvents lblNombreMedico As Windows.Forms.Label
    Friend WithEvents Column2 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As Windows.Forms.DataGridViewTextBoxColumn
End Class
