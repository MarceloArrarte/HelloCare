<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListadoAdministrativos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListadoAdministrativos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tblAdministrativo = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTraducir = New System.Windows.Forms.Label()
        Me.colObjeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGravedad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEncargado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.tblAdministrativo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAgregar
        '
        resources.ApplyResources(Me.btnAgregar, "btnAgregar")
        Me.btnAgregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        resources.ApplyResources(Me.btnEliminar, "btnEliminar")
        Me.btnEliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnModificar
        '
        resources.ApplyResources(Me.btnModificar, "btnModificar")
        Me.btnModificar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnModificar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.UseVisualStyleBackColor = False
        '
        'btnVer
        '
        resources.ApplyResources(Me.btnVer, "btnVer")
        Me.btnVer.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnVer.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnVer.Name = "btnVer"
        Me.btnVer.UseVisualStyleBackColor = False
        '
        'btnVolver
        '
        resources.ApplyResources(Me.btnVolver, "btnVolver")
        Me.btnVolver.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnVolver.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Name = "Label1"
        '
        'tblAdministrativo
        '
        resources.ApplyResources(Me.tblAdministrativo, "tblAdministrativo")
        Me.tblAdministrativo.AllowUserToAddRows = False
        Me.tblAdministrativo.AllowUserToDeleteRows = False
        Me.tblAdministrativo.AllowUserToResizeColumns = False
        Me.tblAdministrativo.AllowUserToResizeRows = False
        Me.tblAdministrativo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblAdministrativo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.tblAdministrativo.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.tblAdministrativo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblAdministrativo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObjeto, Me.colNombre, Me.colDesc, Me.colGravedad, Me.colRec, Me.colLocalidad, Me.colEncargado})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblAdministrativo.DefaultCellStyle = DataGridViewCellStyle1
        Me.tblAdministrativo.Name = "tblAdministrativo"
        Me.tblAdministrativo.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Lato", 15.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblAdministrativo.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.tblAdministrativo.RowHeadersVisible = False
        Me.tblAdministrativo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblAdministrativo.TabStop = False
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Name = "Label2"
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
        Me.colNombre.FillWeight = 65.27477!
        resources.ApplyResources(Me.colNombre, "colNombre")
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        Me.colNombre.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'colDesc
        '
        Me.colDesc.FillWeight = 44.68057!
        resources.ApplyResources(Me.colDesc, "colDesc")
        Me.colDesc.Name = "colDesc"
        Me.colDesc.ReadOnly = True
        Me.colDesc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'colGravedad
        '
        Me.colGravedad.FillWeight = 49.4206!
        resources.ApplyResources(Me.colGravedad, "colGravedad")
        Me.colGravedad.Name = "colGravedad"
        Me.colGravedad.ReadOnly = True
        Me.colGravedad.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'colRec
        '
        Me.colRec.FillWeight = 54.73695!
        resources.ApplyResources(Me.colRec, "colRec")
        Me.colRec.Name = "colRec"
        Me.colRec.ReadOnly = True
        Me.colRec.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'colLocalidad
        '
        Me.colLocalidad.FillWeight = 61.50316!
        resources.ApplyResources(Me.colLocalidad, "colLocalidad")
        Me.colLocalidad.Name = "colLocalidad"
        Me.colLocalidad.ReadOnly = True
        Me.colLocalidad.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'colEncargado
        '
        resources.ApplyResources(Me.colEncargado, "colEncargado")
        Me.colEncargado.Name = "colEncargado"
        Me.colEncargado.ReadOnly = True
        Me.colEncargado.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'FrmListadoAdministrativos
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblTraducir)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnVer)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tblAdministrativo)
        Me.Controls.Add(Me.Label2)
        Me.DoubleBuffered = True
        Me.Name = "FrmListadoAdministrativos"
        CType(Me.tblAdministrativo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnVer As Button
    Friend WithEvents btnVolver As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents tblAdministrativo As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTraducir As Label
    Friend WithEvents colObjeto As DataGridViewTextBoxColumn
    Friend WithEvents colNombre As DataGridViewTextBoxColumn
    Friend WithEvents colDesc As DataGridViewTextBoxColumn
    Friend WithEvents colGravedad As DataGridViewTextBoxColumn
    Friend WithEvents colRec As DataGridViewTextBoxColumn
    Friend WithEvents colLocalidad As DataGridViewTextBoxColumn
    Friend WithEvents colEncargado As DataGridViewTextBoxColumn
End Class
