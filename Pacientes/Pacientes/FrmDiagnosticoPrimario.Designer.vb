<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDiagnosticoPrimario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDiagnosticoPrimario))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblSintomas = New System.Windows.Forms.Label()
        Me.lblDiagnostico = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRecomendaciones = New System.Windows.Forms.TextBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lstSintomas = New System.Windows.Forms.ListBox()
        Me.tblEnfermedadesDiagnosticadas = New System.Windows.Forms.DataGridView()
        Me.colObjeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProbabilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.btnRealizarConsulta = New System.Windows.Forms.Button()
        Me.lblDiagnosticosDiferenciales = New System.Windows.Forms.Label()
        Me.btnDiagnosticosDiferenciales = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.tblEnfermedadesDiagnosticadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSintomas
        '
        Me.lblSintomas.AutoSize = True
        Me.lblSintomas.BackColor = System.Drawing.Color.Transparent
        Me.lblSintomas.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.lblSintomas.Location = New System.Drawing.Point(507, 137)
        Me.lblSintomas.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSintomas.Name = "lblSintomas"
        Me.lblSintomas.Size = New System.Drawing.Size(206, 25)
        Me.lblSintomas.TabIndex = 1
        Me.lblSintomas.Text = "Síntomas ingresados:"
        '
        'lblDiagnostico
        '
        Me.lblDiagnostico.AutoSize = True
        Me.lblDiagnostico.BackColor = System.Drawing.Color.Transparent
        Me.lblDiagnostico.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.lblDiagnostico.Location = New System.Drawing.Point(751, 138)
        Me.lblDiagnostico.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDiagnostico.Name = "lblDiagnostico"
        Me.lblDiagnostico.Size = New System.Drawing.Size(229, 25)
        Me.lblDiagnostico.TabIndex = 3
        Me.lblDiagnostico.Text = "Posibles enfermedades:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label1.Location = New System.Drawing.Point(509, 452)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 50)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Recomendaciones" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "para sus síntomas:"
        '
        'txtRecomendaciones
        '
        Me.txtRecomendaciones.Location = New System.Drawing.Point(707, 439)
        Me.txtRecomendaciones.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRecomendaciones.Multiline = True
        Me.txtRecomendaciones.Name = "txtRecomendaciones"
        Me.txtRecomendaciones.ReadOnly = True
        Me.txtRecomendaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRecomendaciones.Size = New System.Drawing.Size(461, 92)
        Me.txtRecomendaciones.TabIndex = 6
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSalir.Location = New System.Drawing.Point(147, 573)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(161, 49)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "Volver"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lstSintomas
        '
        Me.lstSintomas.Font = New System.Drawing.Font("Lato", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSintomas.FormattingEnabled = True
        Me.lstSintomas.ItemHeight = 25
        Me.lstSintomas.Location = New System.Drawing.Point(509, 166)
        Me.lstSintomas.Name = "lstSintomas"
        Me.lstSintomas.Size = New System.Drawing.Size(201, 204)
        Me.lstSintomas.TabIndex = 8
        '
        'tblEnfermedadesDiagnosticadas
        '
        Me.tblEnfermedadesDiagnosticadas.AllowUserToAddRows = False
        Me.tblEnfermedadesDiagnosticadas.AllowUserToDeleteRows = False
        Me.tblEnfermedadesDiagnosticadas.AllowUserToResizeColumns = False
        Me.tblEnfermedadesDiagnosticadas.AllowUserToResizeRows = False
        Me.tblEnfermedadesDiagnosticadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Lato", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblEnfermedadesDiagnosticadas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.tblEnfermedadesDiagnosticadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEnfermedadesDiagnosticadas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObjeto, Me.colProbabilidad, Me.colNombre})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Lato", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tblEnfermedadesDiagnosticadas.DefaultCellStyle = DataGridViewCellStyle2
        Me.tblEnfermedadesDiagnosticadas.Location = New System.Drawing.Point(756, 166)
        Me.tblEnfermedadesDiagnosticadas.Name = "tblEnfermedadesDiagnosticadas"
        Me.tblEnfermedadesDiagnosticadas.ReadOnly = True
        Me.tblEnfermedadesDiagnosticadas.RowHeadersVisible = False
        Me.tblEnfermedadesDiagnosticadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblEnfermedadesDiagnosticadas.Size = New System.Drawing.Size(412, 212)
        Me.tblEnfermedadesDiagnosticadas.TabIndex = 9
        '
        'colObjeto
        '
        Me.colObjeto.HeaderText = "Objeto"
        Me.colObjeto.Name = "colObjeto"
        Me.colObjeto.ReadOnly = True
        Me.colObjeto.Visible = False
        '
        'colProbabilidad
        '
        Me.colProbabilidad.FillWeight = 20.0!
        Me.colProbabilidad.HeaderText = "Probabilidad"
        Me.colProbabilidad.Name = "colProbabilidad"
        Me.colProbabilidad.ReadOnly = True
        '
        'colNombre
        '
        Me.colNombre.FillWeight = 60.0!
        Me.colNombre.HeaderText = "Enfermedad"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        '
        'lblResultado
        '
        Me.lblResultado.BackColor = System.Drawing.Color.Transparent
        Me.lblResultado.Font = New System.Drawing.Font("Lato", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResultado.Location = New System.Drawing.Point(509, 389)
        Me.lblResultado.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(659, 37)
        Me.lblResultado.TabIndex = 10
        Me.lblResultado.Text = "Resultado del diagnóstico"
        Me.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRealizarConsulta
        '
        Me.btnRealizarConsulta.BackgroundImage = CType(resources.GetObject("btnRealizarConsulta.BackgroundImage"), System.Drawing.Image)
        Me.btnRealizarConsulta.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRealizarConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.btnRealizarConsulta.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnRealizarConsulta.Location = New System.Drawing.Point(967, 585)
        Me.btnRealizarConsulta.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRealizarConsulta.Name = "btnRealizarConsulta"
        Me.btnRealizarConsulta.Size = New System.Drawing.Size(161, 61)
        Me.btnRealizarConsulta.TabIndex = 11
        Me.btnRealizarConsulta.Text = "Realizar consulta"
        Me.btnRealizarConsulta.UseVisualStyleBackColor = True
        '
        'lblDiagnosticosDiferenciales
        '
        Me.lblDiagnosticosDiferenciales.AutoSize = True
        Me.lblDiagnosticosDiferenciales.BackColor = System.Drawing.Color.Transparent
        Me.lblDiagnosticosDiferenciales.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.lblDiagnosticosDiferenciales.Location = New System.Drawing.Point(476, 558)
        Me.lblDiagnosticosDiferenciales.Name = "lblDiagnosticosDiferenciales"
        Me.lblDiagnosticosDiferenciales.Size = New System.Drawing.Size(274, 25)
        Me.lblDiagnosticosDiferenciales.TabIndex = 12
        Me.lblDiagnosticosDiferenciales.Text = "Diagnósticos diferenciales: #"
        '
        'btnDiagnosticosDiferenciales
        '
        Me.btnDiagnosticosDiferenciales.BackgroundImage = CType(resources.GetObject("btnDiagnosticosDiferenciales.BackgroundImage"), System.Drawing.Image)
        Me.btnDiagnosticosDiferenciales.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDiagnosticosDiferenciales.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.btnDiagnosticosDiferenciales.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnDiagnosticosDiferenciales.Location = New System.Drawing.Point(529, 585)
        Me.btnDiagnosticosDiferenciales.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDiagnosticosDiferenciales.Name = "btnDiagnosticosDiferenciales"
        Me.btnDiagnosticosDiferenciales.Size = New System.Drawing.Size(161, 61)
        Me.btnDiagnosticosDiferenciales.TabIndex = 13
        Me.btnDiagnosticosDiferenciales.Text = "Ver diagnósticos diferenciales"
        Me.btnDiagnosticosDiferenciales.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblTitulo.Location = New System.Drawing.Point(664, 36)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(377, 42)
        Me.lblTitulo.TabIndex = 14
        Me.lblTitulo.Text = "Diagnóstico primario"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(103, 292)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(258, 84)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Bienvenido/a," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "#"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'FrmDiagnosticoPrimario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(1214, 681)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnDiagnosticosDiferenciales)
        Me.Controls.Add(Me.lblDiagnosticosDiferenciales)
        Me.Controls.Add(Me.btnRealizarConsulta)
        Me.Controls.Add(Me.lblResultado)
        Me.Controls.Add(Me.tblEnfermedadesDiagnosticadas)
        Me.Controls.Add(Me.lstSintomas)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtRecomendaciones)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDiagnostico)
        Me.Controls.Add(Me.lblSintomas)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "FrmDiagnosticoPrimario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Diagnóstico primario"
        CType(Me.tblEnfermedadesDiagnosticadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSintomas As Windows.Forms.Label
    Friend WithEvents lblDiagnostico As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents txtRecomendaciones As Windows.Forms.TextBox
    Friend WithEvents btnSalir As Windows.Forms.Button
    Friend WithEvents lstSintomas As Windows.Forms.ListBox
    Friend WithEvents tblEnfermedadesDiagnosticadas As Windows.Forms.DataGridView
    Friend WithEvents lblResultado As Windows.Forms.Label
    Friend WithEvents colObjeto As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProbabilidad As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnRealizarConsulta As Windows.Forms.Button
    Friend WithEvents lblDiagnosticosDiferenciales As Windows.Forms.Label
    Friend WithEvents btnDiagnosticosDiferenciales As Windows.Forms.Button
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
End Class
