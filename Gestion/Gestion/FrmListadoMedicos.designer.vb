<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListadoMedicos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListadoMedicos))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tblMedicos = New System.Windows.Forms.DataGridView()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTraducir = New System.Windows.Forms.Label()
        Me.colObjeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGravedad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.tblMedicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tblMedicos
        '
        resources.ApplyResources(Me.tblMedicos, "tblMedicos")
        Me.tblMedicos.AllowUserToAddRows = False
        Me.tblMedicos.AllowUserToDeleteRows = False
        Me.tblMedicos.AllowUserToResizeColumns = False
        Me.tblMedicos.AllowUserToResizeRows = False
        Me.tblMedicos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblMedicos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.tblMedicos.BackgroundColor = System.Drawing.Color.White
        Me.tblMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblMedicos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObjeto, Me.colNombre, Me.colDesc, Me.colGravedad, Me.colRec, Me.colLoc})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblMedicos.DefaultCellStyle = DataGridViewCellStyle2
        Me.tblMedicos.Name = "tblMedicos"
        Me.tblMedicos.ReadOnly = True
        Me.tblMedicos.RowHeadersVisible = False
        Me.tblMedicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblMedicos.TabStop = False
        '
        'btnModificar
        '
        resources.ApplyResources(Me.btnModificar, "btnModificar")
        Me.btnModificar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnModificar.ForeColor = System.Drawing.Color.Transparent
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.UseVisualStyleBackColor = False
        '
        'btnVolver
        '
        resources.ApplyResources(Me.btnVolver, "btnVolver")
        Me.btnVolver.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnVolver.ForeColor = System.Drawing.Color.Transparent
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'btnVer
        '
        resources.ApplyResources(Me.btnVer, "btnVer")
        Me.btnVer.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnVer.ForeColor = System.Drawing.Color.Transparent
        Me.btnVer.Name = "btnVer"
        Me.btnVer.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        resources.ApplyResources(Me.btnEliminar, "btnEliminar")
        Me.btnEliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnEliminar.ForeColor = System.Drawing.Color.Transparent
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        resources.ApplyResources(Me.btnAgregar, "btnAgregar")
        Me.btnAgregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnAgregar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Name = "Label1"
        '
        'lblTraducir
        '
        resources.ApplyResources(Me.lblTraducir, "lblTraducir")
        Me.lblTraducir.BackColor = System.Drawing.Color.Transparent
        Me.lblTraducir.ForeColor = System.Drawing.Color.White
        Me.lblTraducir.Name = "lblTraducir"
        '
        'colObjeto
        '
        resources.ApplyResources(Me.colObjeto, "colObjeto")
        Me.colObjeto.Name = "colObjeto"
        Me.colObjeto.ReadOnly = True
        '
        'colNombre
        '
        Me.colNombre.FillWeight = 42.45399!
        resources.ApplyResources(Me.colNombre, "colNombre")
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        Me.colNombre.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'colDesc
        '
        Me.colDesc.FillWeight = 49.34073!
        resources.ApplyResources(Me.colDesc, "colDesc")
        Me.colDesc.Name = "colDesc"
        Me.colDesc.ReadOnly = True
        Me.colDesc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'colGravedad
        '
        Me.colGravedad.FillWeight = 46.23014!
        resources.ApplyResources(Me.colGravedad, "colGravedad")
        Me.colGravedad.Name = "colGravedad"
        Me.colGravedad.ReadOnly = True
        Me.colGravedad.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'colRec
        '
        Me.colRec.FillWeight = 45.05631!
        resources.ApplyResources(Me.colRec, "colRec")
        Me.colRec.Name = "colRec"
        Me.colRec.ReadOnly = True
        Me.colRec.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'colLoc
        '
        Me.colLoc.FillWeight = 47.17264!
        resources.ApplyResources(Me.colLoc, "colLoc")
        Me.colLoc.Name = "colLoc"
        Me.colLoc.ReadOnly = True
        Me.colLoc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'FrmListadoMedicos
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblTraducir)
        Me.Controls.Add(Me.tblMedicos)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnVer)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Name = "FrmListadoMedicos"
        CType(Me.tblMedicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tblMedicos As DataGridView
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnVolver As Button
    Friend WithEvents btnVer As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTraducir As Label
    Friend WithEvents colObjeto As DataGridViewTextBoxColumn
    Friend WithEvents colNombre As DataGridViewTextBoxColumn
    Friend WithEvents colDesc As DataGridViewTextBoxColumn
    Friend WithEvents colGravedad As DataGridViewTextBoxColumn
    Friend WithEvents colRec As DataGridViewTextBoxColumn
    Friend WithEvents colLoc As DataGridViewTextBoxColumn
End Class
