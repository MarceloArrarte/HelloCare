<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificacionEnfermedades
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModificacionEnfermedades))
        Me.txtRecomendaciones = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtGravedad = New System.Windows.Forms.TextBox()
        Me.tblSintomas = New System.Windows.Forms.DataGridView()
        Me.colObjeto2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatologia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnQuitarSintoma = New System.Windows.Forms.Button()
        Me.btnAgregarSintoma = New System.Windows.Forms.Button()
        Me.txtBuscarSintoma = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tblAsociados = New System.Windows.Forms.DataGridView()
        Me.colObjeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNomEnfermedad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFrecuencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBuscarEspecialidades = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tblEspecialidades = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.tblSintomas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblAsociados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblEspecialidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRecomendaciones
        '
        Me.txtRecomendaciones.Font = New System.Drawing.Font("Lato", 12.75!)
        Me.txtRecomendaciones.Location = New System.Drawing.Point(34, 297)
        Me.txtRecomendaciones.Multiline = True
        Me.txtRecomendaciones.Name = "txtRecomendaciones"
        Me.txtRecomendaciones.Size = New System.Drawing.Size(427, 268)
        Me.txtRecomendaciones.TabIndex = 3
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Lato", 12.75!)
        Me.txtDescripcion.Location = New System.Drawing.Point(34, 138)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(427, 72)
        Me.txtDescripcion.TabIndex = 1
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Lato", 12.75!)
        Me.txtNombre.Location = New System.Drawing.Point(34, 82)
        Me.txtNombre.Multiline = True
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(427, 25)
        Me.txtNombre.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(29, 269)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(186, 25)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Recomendaciones:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(29, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 25)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Descripción:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(29, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 25)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Nombre:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Cosmic", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label1.Location = New System.Drawing.Point(543, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(519, 43)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Modificación de enfermedad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(29, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 25)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Gravedad:"
        '
        'txtGravedad
        '
        Me.txtGravedad.Font = New System.Drawing.Font("Lato", 12.75!)
        Me.txtGravedad.Location = New System.Drawing.Point(34, 241)
        Me.txtGravedad.Multiline = True
        Me.txtGravedad.Name = "txtGravedad"
        Me.txtGravedad.Size = New System.Drawing.Size(427, 25)
        Me.txtGravedad.TabIndex = 2
        '
        'tblSintomas
        '
        Me.tblSintomas.AllowUserToAddRows = False
        Me.tblSintomas.AllowUserToDeleteRows = False
        Me.tblSintomas.AllowUserToResizeColumns = False
        Me.tblSintomas.AllowUserToResizeRows = False
        Me.tblSintomas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblSintomas.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Lato", 12.75!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblSintomas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.tblSintomas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblSintomas.ColumnHeadersVisible = False
        Me.tblSintomas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObjeto2, Me.colPatologia})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Lato", 12.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tblSintomas.DefaultCellStyle = DataGridViewCellStyle2
        Me.tblSintomas.Location = New System.Drawing.Point(903, 336)
        Me.tblSintomas.Name = "tblSintomas"
        Me.tblSintomas.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Lato", 12.75!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblSintomas.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.tblSintomas.RowHeadersVisible = False
        Me.tblSintomas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblSintomas.Size = New System.Drawing.Size(299, 267)
        Me.tblSintomas.TabIndex = 50
        '
        'colObjeto2
        '
        Me.colObjeto2.HeaderText = "Objeto"
        Me.colObjeto2.Name = "colObjeto2"
        Me.colObjeto2.ReadOnly = True
        Me.colObjeto2.Visible = False
        '
        'colPatologia
        '
        Me.colPatologia.HeaderText = "Nombre"
        Me.colPatologia.Name = "colPatologia"
        Me.colPatologia.ReadOnly = True
        '
        'btnQuitarSintoma
        '
        Me.btnQuitarSintoma.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnQuitarSintoma.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnQuitarSintoma.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnQuitarSintoma.Location = New System.Drawing.Point(792, 506)
        Me.btnQuitarSintoma.Name = "btnQuitarSintoma"
        Me.btnQuitarSintoma.Size = New System.Drawing.Size(105, 37)
        Me.btnQuitarSintoma.TabIndex = 43
        Me.btnQuitarSintoma.Text = "Quitar"
        Me.btnQuitarSintoma.UseVisualStyleBackColor = False
        '
        'btnAgregarSintoma
        '
        Me.btnAgregarSintoma.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnAgregarSintoma.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnAgregarSintoma.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAgregarSintoma.Location = New System.Drawing.Point(792, 389)
        Me.btnAgregarSintoma.Name = "btnAgregarSintoma"
        Me.btnAgregarSintoma.Size = New System.Drawing.Size(105, 37)
        Me.btnAgregarSintoma.TabIndex = 42
        Me.btnAgregarSintoma.Text = "Agregar"
        Me.btnAgregarSintoma.UseVisualStyleBackColor = False
        '
        'txtBuscarSintoma
        '
        Me.txtBuscarSintoma.Font = New System.Drawing.Font("Lato", 12.75!)
        Me.txtBuscarSintoma.Location = New System.Drawing.Point(985, 306)
        Me.txtBuscarSintoma.Name = "txtBuscarSintoma"
        Me.txtBuscarSintoma.Size = New System.Drawing.Size(217, 28)
        Me.txtBuscarSintoma.TabIndex = 41
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label6.Location = New System.Drawing.Point(898, 305)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 25)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Buscar:"
        '
        'tblAsociados
        '
        Me.tblAsociados.AllowUserToAddRows = False
        Me.tblAsociados.AllowUserToDeleteRows = False
        Me.tblAsociados.AllowUserToResizeColumns = False
        Me.tblAsociados.AllowUserToResizeRows = False
        Me.tblAsociados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblAsociados.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Lato", 12.75!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblAsociados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.tblAsociados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblAsociados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObjeto, Me.colNomEnfermedad, Me.colFrecuencia})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Lato", 12.75!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tblAsociados.DefaultCellStyle = DataGridViewCellStyle5
        Me.tblAsociados.Location = New System.Drawing.Point(487, 333)
        Me.tblAsociados.Name = "tblAsociados"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Lato", 12.75!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblAsociados.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.tblAsociados.RowHeadersVisible = False
        Me.tblAsociados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblAsociados.Size = New System.Drawing.Size(299, 270)
        Me.tblAsociados.TabIndex = 47
        '
        'colObjeto
        '
        Me.colObjeto.HeaderText = "Objeto"
        Me.colObjeto.Name = "colObjeto"
        Me.colObjeto.Visible = False
        '
        'colNomEnfermedad
        '
        Me.colNomEnfermedad.FillWeight = 75.0!
        Me.colNomEnfermedad.HeaderText = "Nombre"
        Me.colNomEnfermedad.Name = "colNomEnfermedad"
        Me.colNomEnfermedad.ReadOnly = True
        '
        'colFrecuencia
        '
        Me.colFrecuencia.FillWeight = 25.0!
        Me.colFrecuencia.HeaderText = "Frecuencia"
        Me.colFrecuencia.Name = "colFrecuencia"
        '
        'btnVolver
        '
        Me.btnVolver.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnVolver.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnVolver.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnVolver.Location = New System.Drawing.Point(156, 571)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(179, 45)
        Me.btnVolver.TabIndex = 44
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'btnConfirmar
        '
        Me.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnConfirmar.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnConfirmar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnConfirmar.Location = New System.Drawing.Point(782, 622)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(128, 34)
        Me.btnConfirmar.TabIndex = 45
        Me.btnConfirmar.Text = "Confirmar"
        Me.btnConfirmar.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label8.Location = New System.Drawing.Point(482, 305)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(197, 25)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Síntomas asociados:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label9.Location = New System.Drawing.Point(499, 164)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 25)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "Especialidad:"
        '
        'txtBuscarEspecialidades
        '
        Me.txtBuscarEspecialidades.Location = New System.Drawing.Point(637, 138)
        Me.txtBuscarEspecialidades.Name = "txtBuscarEspecialidades"
        Me.txtBuscarEspecialidades.Size = New System.Drawing.Size(565, 20)
        Me.txtBuscarEspecialidades.TabIndex = 53
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label10.Location = New System.Drawing.Point(550, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 25)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Buscar:"
        '
        'tblEspecialidades
        '
        Me.tblEspecialidades.AllowUserToAddRows = False
        Me.tblEspecialidades.AllowUserToDeleteRows = False
        Me.tblEspecialidades.AllowUserToResizeColumns = False
        Me.tblEspecialidades.AllowUserToResizeRows = False
        Me.tblEspecialidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEspecialidades.ColumnHeadersVisible = False
        Me.tblEspecialidades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.tblEspecialidades.Location = New System.Drawing.Point(637, 164)
        Me.tblEspecialidades.MultiSelect = False
        Me.tblEspecialidades.Name = "tblEspecialidades"
        Me.tblEspecialidades.ReadOnly = True
        Me.tblEspecialidades.RowHeadersVisible = False
        Me.tblEspecialidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblEspecialidades.Size = New System.Drawing.Size(565, 130)
        Me.tblEspecialidades.TabIndex = 55
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Image = CType(resources.GetObject("Label7.Image"), System.Drawing.Image)
        Me.Label7.Location = New System.Drawing.Point(-82, 635)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(225, 43)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Traducir"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmModificacionEnfermedades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1214, 681)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tblEspecialidades)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtBuscarEspecialidades)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tblSintomas)
        Me.Controls.Add(Me.btnQuitarSintoma)
        Me.Controls.Add(Me.btnAgregarSintoma)
        Me.Controls.Add(Me.txtBuscarSintoma)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tblAsociados)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtGravedad)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRecomendaciones)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmModificacionEnfermedades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificación de enfermedades"
        CType(Me.tblSintomas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblAsociados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblEspecialidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRecomendaciones As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtGravedad As TextBox
    Friend WithEvents tblSintomas As DataGridView
    Friend WithEvents colObjeto2 As DataGridViewTextBoxColumn
    Friend WithEvents colPatologia As DataGridViewTextBoxColumn
    Friend WithEvents btnQuitarSintoma As Button
    Friend WithEvents btnAgregarSintoma As Button
    Friend WithEvents txtBuscarSintoma As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tblAsociados As DataGridView
    Friend WithEvents colObjeto As DataGridViewTextBoxColumn
    Friend WithEvents colNomEnfermedad As DataGridViewTextBoxColumn
    Friend WithEvents colFrecuencia As DataGridViewTextBoxColumn
    Friend WithEvents btnVolver As Button
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtBuscarEspecialidades As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents tblEspecialidades As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Label7 As Label
End Class
