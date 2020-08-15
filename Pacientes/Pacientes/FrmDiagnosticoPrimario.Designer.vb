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
        Me.lblTitulo = New System.Windows.Forms.Label()
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
        CType(Me.tblEnfermedadesDiagnosticadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(227, 9)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(181, 24)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Diagnóstico primario"
        '
        'lblSintomas
        '
        Me.lblSintomas.AutoSize = True
        Me.lblSintomas.Location = New System.Drawing.Point(11, 71)
        Me.lblSintomas.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSintomas.Name = "lblSintomas"
        Me.lblSintomas.Size = New System.Drawing.Size(109, 13)
        Me.lblSintomas.TabIndex = 1
        Me.lblSintomas.Text = "Síntomas ingresados:"
        '
        'lblDiagnostico
        '
        Me.lblDiagnostico.AutoSize = True
        Me.lblDiagnostico.Location = New System.Drawing.Point(255, 72)
        Me.lblDiagnostico.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDiagnostico.Name = "lblDiagnostico"
        Me.lblDiagnostico.Size = New System.Drawing.Size(119, 13)
        Me.lblDiagnostico.TabIndex = 3
        Me.lblDiagnostico.Text = "Posibles enfermedades:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 273)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 26)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Recomendaciones" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "para sus síntomas:"
        '
        'txtRecomendaciones
        '
        Me.txtRecomendaciones.Location = New System.Drawing.Point(132, 273)
        Me.txtRecomendaciones.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRecomendaciones.Multiline = True
        Me.txtRecomendaciones.Name = "txtRecomendaciones"
        Me.txtRecomendaciones.ReadOnly = True
        Me.txtRecomendaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRecomendaciones.Size = New System.Drawing.Size(538, 74)
        Me.txtRecomendaciones.TabIndex = 6
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(11, 390)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(99, 36)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lstSintomas
        '
        Me.lstSintomas.FormattingEnabled = True
        Me.lstSintomas.Location = New System.Drawing.Point(11, 88)
        Me.lstSintomas.Name = "lstSintomas"
        Me.lstSintomas.Size = New System.Drawing.Size(201, 121)
        Me.lstSintomas.TabIndex = 8
        '
        'tblEnfermedadesDiagnosticadas
        '
        Me.tblEnfermedadesDiagnosticadas.AllowUserToAddRows = False
        Me.tblEnfermedadesDiagnosticadas.AllowUserToDeleteRows = False
        Me.tblEnfermedadesDiagnosticadas.AllowUserToResizeColumns = False
        Me.tblEnfermedadesDiagnosticadas.AllowUserToResizeRows = False
        Me.tblEnfermedadesDiagnosticadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblEnfermedadesDiagnosticadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEnfermedadesDiagnosticadas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObjeto, Me.colProbabilidad, Me.colNombre})
        Me.tblEnfermedadesDiagnosticadas.Location = New System.Drawing.Point(258, 88)
        Me.tblEnfermedadesDiagnosticadas.Name = "tblEnfermedadesDiagnosticadas"
        Me.tblEnfermedadesDiagnosticadas.ReadOnly = True
        Me.tblEnfermedadesDiagnosticadas.RowHeadersVisible = False
        Me.tblEnfermedadesDiagnosticadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblEnfermedadesDiagnosticadas.Size = New System.Drawing.Size(412, 121)
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
        Me.lblResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResultado.Location = New System.Drawing.Point(11, 223)
        Me.lblResultado.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(659, 48)
        Me.lblResultado.TabIndex = 10
        Me.lblResultado.Text = "Resultado del diagnóstico"
        '
        'btnRealizarConsulta
        '
        Me.btnRealizarConsulta.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRealizarConsulta.Location = New System.Drawing.Point(572, 390)
        Me.btnRealizarConsulta.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRealizarConsulta.Name = "btnRealizarConsulta"
        Me.btnRealizarConsulta.Size = New System.Drawing.Size(99, 36)
        Me.btnRealizarConsulta.TabIndex = 11
        Me.btnRealizarConsulta.Text = "Realizar consulta"
        Me.btnRealizarConsulta.UseVisualStyleBackColor = True
        '
        'lblDiagnosticosDiferenciales
        '
        Me.lblDiagnosticosDiferenciales.AutoSize = True
        Me.lblDiagnosticosDiferenciales.Location = New System.Drawing.Point(277, 367)
        Me.lblDiagnosticosDiferenciales.Name = "lblDiagnosticosDiferenciales"
        Me.lblDiagnosticosDiferenciales.Size = New System.Drawing.Size(143, 13)
        Me.lblDiagnosticosDiferenciales.TabIndex = 12
        Me.lblDiagnosticosDiferenciales.Text = "Diagnósticos diferenciales: #"
        '
        'btnDiagnosticosDiferenciales
        '
        Me.btnDiagnosticosDiferenciales.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDiagnosticosDiferenciales.Location = New System.Drawing.Point(268, 390)
        Me.btnDiagnosticosDiferenciales.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDiagnosticosDiferenciales.Name = "btnDiagnosticosDiferenciales"
        Me.btnDiagnosticosDiferenciales.Size = New System.Drawing.Size(165, 36)
        Me.btnDiagnosticosDiferenciales.TabIndex = 13
        Me.btnDiagnosticosDiferenciales.Text = "Ver diagnósticos diferenciales"
        Me.btnDiagnosticosDiferenciales.UseVisualStyleBackColor = True
        '
        'FrmDiagnosticoPrimario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(682, 437)
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
        Me.Controls.Add(Me.lblTitulo)
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

    Friend WithEvents lblTitulo As Windows.Forms.Label
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
End Class
