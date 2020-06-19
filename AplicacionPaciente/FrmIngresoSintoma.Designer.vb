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
        Me.tblSeleccionados = New System.Windows.Forms.DataGridView()
        Me.colObjeto1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.tblDisponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblIngresarSintoma
        '
        Me.LblIngresarSintoma.AutoSize = True
        Me.LblIngresarSintoma.Location = New System.Drawing.Point(40, 151)
        Me.LblIngresarSintoma.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblIngresarSintoma.Name = "LblIngresarSintoma"
        Me.LblIngresarSintoma.Size = New System.Drawing.Size(43, 13)
        Me.LblIngresarSintoma.TabIndex = 0
        Me.LblIngresarSintoma.Text = "Buscar:"
        '
        'Titulo
        '
        Me.Titulo.AutoSize = True
        Me.Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titulo.Location = New System.Drawing.Point(225, 7)
        Me.Titulo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Titulo.Name = "Titulo"
        Me.Titulo.Size = New System.Drawing.Size(179, 24)
        Me.Titulo.TabIndex = 1
        Me.Titulo.Text = "Ingreso de síntomas"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(104, 148)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(139, 20)
        Me.txtBuscar.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 64)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(465, 26)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Seleccione sus síntomas de la lista a su izquierda y a continuacion presione ""Agr" &
    "egar""." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Luego, presione ""Enviar"" para enviar sus síntomas al sistema y recibir u" &
    "n diagnóstico automático."
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(302, 228)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(81, 28)
        Me.btnAgregar.TabIndex = 1
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.Location = New System.Drawing.Point(302, 289)
        Me.btnQuitar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(81, 27)
        Me.btnQuitar.TabIndex = 2
        Me.btnQuitar.Text = "Quitar"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(45, 394)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(91, 32)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Volver"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblSintomasSeleccionados
        '
        Me.lblSintomasSeleccionados.AutoSize = True
        Me.lblSintomasSeleccionados.Location = New System.Drawing.Point(401, 124)
        Me.lblSintomasSeleccionados.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSintomasSeleccionados.Name = "lblSintomasSeleccionados"
        Me.lblSintomasSeleccionados.Size = New System.Drawing.Size(123, 13)
        Me.lblSintomasSeleccionados.TabIndex = 10
        Me.lblSintomasSeleccionados.Text = "Síntomas seleccionados"
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(548, 394)
        Me.btnEnviar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(96, 32)
        Me.btnEnviar.TabIndex = 4
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 124)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Síntomas disponibles"
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
        Me.tblDisponibles.Location = New System.Drawing.Point(45, 185)
        Me.tblDisponibles.Name = "tblDisponibles"
        Me.tblDisponibles.ReadOnly = True
        Me.tblDisponibles.RowHeadersVisible = False
        Me.tblDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblDisponibles.Size = New System.Drawing.Size(240, 185)
        Me.tblDisponibles.TabIndex = 13
        Me.tblDisponibles.TabStop = False
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
        Me.tblSeleccionados.Location = New System.Drawing.Point(404, 185)
        Me.tblSeleccionados.Name = "tblSeleccionados"
        Me.tblSeleccionados.ReadOnly = True
        Me.tblSeleccionados.RowHeadersVisible = False
        Me.tblSeleccionados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblSeleccionados.Size = New System.Drawing.Size(240, 185)
        Me.tblSeleccionados.TabIndex = 14
        Me.tblSeleccionados.TabStop = False
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
        'FrmIngresoSintoma
        '
        Me.AcceptButton = Me.btnEnviar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(684, 461)
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
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmIngresoSintoma"
        Me.Text = "MenuPrincipalPaciente"
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
End Class
