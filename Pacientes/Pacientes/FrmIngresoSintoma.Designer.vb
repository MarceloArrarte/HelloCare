<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngresoSintoma
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIngresoSintoma))
        Me.LblIngresarSintoma = New System.Windows.Forms.Label()
        Me.Titulo = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblSintomasSeleccionados = New System.Windows.Forms.Label()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tblDisponibles = New System.Windows.Forms.DataGridView()
        Me.colObjeto1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tblSeleccionados = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.tblDisponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblIngresarSintoma
        '
        Me.LblIngresarSintoma.AutoSize = True
        Me.LblIngresarSintoma.BackColor = System.Drawing.Color.Transparent
        Me.LblIngresarSintoma.Font = New System.Drawing.Font("Lato", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIngresarSintoma.Location = New System.Drawing.Point(518, 245)
        Me.LblIngresarSintoma.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblIngresarSintoma.Name = "LblIngresarSintoma"
        Me.LblIngresarSintoma.Size = New System.Drawing.Size(81, 25)
        Me.LblIngresarSintoma.TabIndex = 0
        Me.LblIngresarSintoma.Text = "Buscar:"
        '
        'Titulo
        '
        Me.Titulo.AutoSize = True
        Me.Titulo.BackColor = System.Drawing.Color.Transparent
        Me.Titulo.Font = New System.Drawing.Font("Cosmic", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Titulo.Location = New System.Drawing.Point(618, 9)
        Me.Titulo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Titulo.Name = "Titulo"
        Me.Titulo.Size = New System.Drawing.Size(374, 43)
        Me.Titulo.TabIndex = 1
        Me.Titulo.Text = "Ingreso de síntomas"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(601, 249)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(161, 20)
        Me.txtBuscar.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Lato", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(572, 64)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(472, 115)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Seleccione sus síntomas de la lista a su izquierda y a continuacion presione ""Agr" &
    "egar""." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Luego, presione ""Enviar"" para enviar sus síntomas al sistema y recibir u" &
    "n diagnóstico automático."
        '
        'btnAgregar
        '
        Me.btnAgregar.BackgroundImage = CType(resources.GetObject("btnAgregar.BackgroundImage"), System.Drawing.Image)
        Me.btnAgregar.Font = New System.Drawing.Font("Cosmic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAgregar.Location = New System.Drawing.Point(780, 339)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(100, 38)
        Me.btnAgregar.TabIndex = 1
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.BackgroundImage = CType(resources.GetObject("btnQuitar.BackgroundImage"), System.Drawing.Image)
        Me.btnQuitar.Font = New System.Drawing.Font("Cosmic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnQuitar.Location = New System.Drawing.Point(780, 471)
        Me.btnQuitar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(100, 32)
        Me.btnQuitar.TabIndex = 2
        Me.btnQuitar.Text = "Quitar"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), System.Drawing.Image)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Font = New System.Drawing.Font("Cosmic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Location = New System.Drawing.Point(147, 573)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(161, 49)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Volver"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'lblSintomasSeleccionados
        '
        Me.lblSintomasSeleccionados.AutoSize = True
        Me.lblSintomasSeleccionados.BackColor = System.Drawing.Color.Transparent
        Me.lblSintomasSeleccionados.Font = New System.Drawing.Font("Cosmic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSintomasSeleccionados.Location = New System.Drawing.Point(897, 221)
        Me.lblSintomasSeleccionados.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSintomasSeleccionados.Name = "lblSintomasSeleccionados"
        Me.lblSintomasSeleccionados.Size = New System.Drawing.Size(243, 24)
        Me.lblSintomasSeleccionados.TabIndex = 10
        Me.lblSintomasSeleccionados.Text = "Síntomas seleccionados:"
        '
        'btnEnviar
        '
        Me.btnEnviar.BackgroundImage = CType(resources.GetObject("btnEnviar.BackgroundImage"), System.Drawing.Image)
        Me.btnEnviar.Font = New System.Drawing.Font("Cosmic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviar.ForeColor = System.Drawing.Color.White
        Me.btnEnviar.Location = New System.Drawing.Point(918, 580)
        Me.btnEnviar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(197, 60)
        Me.btnEnviar.TabIndex = 4
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.Label1.Location = New System.Drawing.Point(533, 221)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 24)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Síntomas disponibles:"
        '
        'tblDisponibles
        '
        Me.tblDisponibles.AllowUserToAddRows = False
        Me.tblDisponibles.AllowUserToDeleteRows = False
        Me.tblDisponibles.AllowUserToResizeColumns = False
        Me.tblDisponibles.AllowUserToResizeRows = False
        Me.tblDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblDisponibles.ColumnHeadersVisible = False
        Me.tblDisponibles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObjeto1, Me.colNombre1})
        Me.tblDisponibles.Location = New System.Drawing.Point(522, 274)
        Me.tblDisponibles.Name = "tblDisponibles"
        Me.tblDisponibles.ReadOnly = True
        Me.tblDisponibles.RowHeadersVisible = False
        Me.tblDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblDisponibles.Size = New System.Drawing.Size(240, 275)
        Me.tblDisponibles.TabIndex = 13
        Me.tblDisponibles.TabStop = False
        '
        'colObjeto1
        '
        Me.colObjeto1.HeaderText = "Objeto"
        Me.colObjeto1.Name = "colObjeto1"
        Me.colObjeto1.ReadOnly = True
        Me.colObjeto1.Visible = False
        '
        'colNombre1
        '
        Me.colNombre1.HeaderText = "Nombre"
        Me.colNombre1.Name = "colNombre1"
        Me.colNombre1.ReadOnly = True
        '
        'tblSeleccionados
        '
        Me.tblSeleccionados.AllowUserToAddRows = False
        Me.tblSeleccionados.AllowUserToDeleteRows = False
        Me.tblSeleccionados.AllowUserToResizeColumns = False
        Me.tblSeleccionados.AllowUserToResizeRows = False
        Me.tblSeleccionados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblSeleccionados.ColumnHeadersVisible = False
        Me.tblSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.tblSeleccionados.Location = New System.Drawing.Point(901, 274)
        Me.tblSeleccionados.Name = "tblSeleccionados"
        Me.tblSeleccionados.ReadOnly = True
        Me.tblSeleccionados.RowHeadersVisible = False
        Me.tblSeleccionados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblSeleccionados.Size = New System.Drawing.Size(239, 275)
        Me.tblSeleccionados.TabIndex = 14
        Me.tblSeleccionados.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Objeto"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
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
        Me.Label3.TabIndex = 16
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
        'FrmIngresoSintoma
        '
        Me.AcceptButton = Me.btnEnviar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(1214, 681)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tblSeleccionados)
        Me.Controls.Add(Me.tblDisponibles)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.lblSintomasSeleccionados)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.Titulo)
        Me.Controls.Add(Me.LblIngresarSintoma)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "FrmIngresoSintoma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de síntomas"
        CType(Me.tblDisponibles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblIngresarSintoma As Windows.Forms.Label
    Friend WithEvents Titulo As Windows.Forms.Label
    Friend WithEvents txtBuscar As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents btnAgregar As Windows.Forms.Button
    Friend WithEvents btnQuitar As Windows.Forms.Button
    Friend WithEvents btnSalir As Windows.Forms.Button
    Friend WithEvents lblSintomasSeleccionados As Windows.Forms.Label
    Friend WithEvents btnEnviar As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents tblDisponibles As Windows.Forms.DataGridView
    Friend WithEvents tblSeleccionados As Windows.Forms.DataGridView
    Friend WithEvents colObjeto1 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre1 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
End Class
