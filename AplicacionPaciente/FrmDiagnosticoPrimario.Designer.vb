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
        CType(Me.tblEnfermedadesDiagnosticadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(201, 20)
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
        Me.lblDiagnostico.Location = New System.Drawing.Point(311, 71)
        Me.lblDiagnostico.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDiagnostico.Name = "lblDiagnostico"
        Me.lblDiagnostico.Size = New System.Drawing.Size(105, 13)
        Me.lblDiagnostico.TabIndex = 3
        Me.lblDiagnostico.Text = "Diagnóstico primario:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 240)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Recomendaciones:"
        '
        'txtRecomendaciones
        '
        Me.txtRecomendaciones.Location = New System.Drawing.Point(131, 237)
        Me.txtRecomendaciones.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRecomendaciones.Multiline = True
        Me.txtRecomendaciones.Name = "txtRecomendaciones"
        Me.txtRecomendaciones.Size = New System.Drawing.Size(495, 74)
        Me.txtRecomendaciones.TabIndex = 6
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(11, 350)
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
        Me.lstSintomas.Size = New System.Drawing.Size(251, 121)
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
        Me.tblEnfermedadesDiagnosticadas.Location = New System.Drawing.Point(314, 88)
        Me.tblEnfermedadesDiagnosticadas.Name = "tblEnfermedadesDiagnosticadas"
        Me.tblEnfermedadesDiagnosticadas.ReadOnly = True
        Me.tblEnfermedadesDiagnosticadas.RowHeadersVisible = False
        Me.tblEnfermedadesDiagnosticadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblEnfermedadesDiagnosticadas.Size = New System.Drawing.Size(312, 121)
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
        Me.colProbabilidad.FillWeight = 25.0!
        Me.colProbabilidad.HeaderText = "Coincidencia"
        Me.colProbabilidad.Name = "colProbabilidad"
        Me.colProbabilidad.ReadOnly = True
        '
        'colNombre
        '
        Me.colNombre.FillWeight = 75.0!
        Me.colNombre.HeaderText = "Enfermedad"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        '
        'FrmDiagnosticoPrimario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(638, 397)
        Me.Controls.Add(Me.tblEnfermedadesDiagnosticadas)
        Me.Controls.Add(Me.lstSintomas)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtRecomendaciones)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDiagnostico)
        Me.Controls.Add(Me.lblSintomas)
        Me.Controls.Add(Me.lblTitulo)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmDiagnosticoPrimario"
        Me.Text = "DiagnosticoPrimario"
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
    Friend WithEvents colObjeto As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProbabilidad As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As Windows.Forms.DataGridViewTextBoxColumn
End Class
