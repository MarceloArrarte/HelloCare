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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDiagnosticosDiferenciales))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tblDiagnosticosDiferenciales = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.lblNombreMedico = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.tblDiagnosticosDiferenciales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Cosmic", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label1.Location = New System.Drawing.Point(561, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(556, 118)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Diagnósticos diferenciales"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label2.Location = New System.Drawing.Point(523, 233)
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
        Me.tblDiagnosticosDiferenciales.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Lato", 15.75!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblDiagnosticosDiferenciales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.tblDiagnosticosDiferenciales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblDiagnosticosDiferenciales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3, Me.Column1, Me.Column4})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblDiagnosticosDiferenciales.DefaultCellStyle = DataGridViewCellStyle4
        Me.tblDiagnosticosDiferenciales.Location = New System.Drawing.Point(523, 279)
        Me.tblDiagnosticosDiferenciales.Name = "tblDiagnosticosDiferenciales"
        Me.tblDiagnosticosDiferenciales.ReadOnly = True
        Me.tblDiagnosticosDiferenciales.RowHeadersVisible = False
        Me.tblDiagnosticosDiferenciales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tblDiagnosticosDiferenciales.Size = New System.Drawing.Size(580, 343)
        Me.tblDiagnosticosDiferenciales.TabIndex = 2
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
        'btnVolver
        '
        Me.btnVolver.BackgroundImage = CType(resources.GetObject("btnVolver.BackgroundImage"), System.Drawing.Image)
        Me.btnVolver.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnVolver.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnVolver.Location = New System.Drawing.Point(147, 573)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(161, 49)
        Me.btnVolver.TabIndex = 3
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'lblNombreMedico
        '
        Me.lblNombreMedico.AutoSize = True
        Me.lblNombreMedico.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreMedico.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.lblNombreMedico.Location = New System.Drawing.Point(522, 202)
        Me.lblNombreMedico.Name = "lblNombreMedico"
        Me.lblNombreMedico.Size = New System.Drawing.Size(212, 25)
        Me.lblNombreMedico.TabIndex = 4
        Me.lblNombreMedico.Text = "Nombre del médico: #"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Cosmic", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(103, 292)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(254, 86)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Bienvenido/a," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "#"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.Location = New System.Drawing.Point(-80, 620)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(225, 43)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Traducir"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmDiagnosticosDiferenciales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1214, 681)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNombreMedico)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.tblDiagnosticosDiferenciales)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
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
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
End Class
