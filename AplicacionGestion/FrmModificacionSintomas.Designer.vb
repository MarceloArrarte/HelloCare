<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificacionSintomas
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRecomendaciones = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.txtUrgencia = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tblAsociadas = New System.Windows.Forms.DataGridView()
        Me.colObjeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNomEnfermedad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFrecuencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tblPatologias = New System.Windows.Forms.DataGridView()
        Me.colObjeto2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatologia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnQuitarPatologia = New System.Windows.Forms.Button()
        Me.btnAgregarPatologia = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBuscarPatologia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.tblAsociadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblPatologias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(343, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bienvenido al modificar sintomas"
        '
        'txtRecomendaciones
        '
        Me.txtRecomendaciones.Location = New System.Drawing.Point(184, 191)
        Me.txtRecomendaciones.Multiline = True
        Me.txtRecomendaciones.Name = "txtRecomendaciones"
        Me.txtRecomendaciones.Size = New System.Drawing.Size(461, 99)
        Me.txtRecomendaciones.TabIndex = 3
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(184, 84)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(461, 72)
        Me.txtDescripcion.TabIndex = 1
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(184, 53)
        Me.txtNombre.Multiline = True
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(461, 25)
        Me.txtNombre.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Recomendaciones del sintoma:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(51, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Descripción del sintoma:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(69, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Nombre del sintoma:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 325)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Patologias asociadas:"
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Location = New System.Drawing.Point(536, 692)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirmar.TabIndex = 8
        Me.btnConfirmar.Text = "Confirmar"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnVolver.Location = New System.Drawing.Point(184, 692)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver.TabIndex = 7
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'txtUrgencia
        '
        Me.txtUrgencia.Location = New System.Drawing.Point(184, 164)
        Me.txtUrgencia.Multiline = True
        Me.txtUrgencia.Name = "txtUrgencia"
        Me.txtUrgencia.Size = New System.Drawing.Size(461, 21)
        Me.txtUrgencia.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(119, 167)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Urgencia:"
        '
        'tblAsociadas
        '
        Me.tblAsociadas.AllowUserToAddRows = False
        Me.tblAsociadas.AllowUserToDeleteRows = False
        Me.tblAsociadas.AllowUserToResizeColumns = False
        Me.tblAsociadas.AllowUserToResizeRows = False
        Me.tblAsociadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblAsociadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblAsociadas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObjeto, Me.colNomEnfermedad, Me.colFrecuencia})
        Me.tblAsociadas.Location = New System.Drawing.Point(12, 341)
        Me.tblAsociadas.Name = "tblAsociadas"
        Me.tblAsociadas.RowHeadersVisible = False
        Me.tblAsociadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblAsociadas.Size = New System.Drawing.Size(299, 334)
        Me.tblAsociadas.TabIndex = 27
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
        'tblPatologias
        '
        Me.tblPatologias.AllowUserToAddRows = False
        Me.tblPatologias.AllowUserToDeleteRows = False
        Me.tblPatologias.AllowUserToResizeColumns = False
        Me.tblPatologias.AllowUserToResizeRows = False
        Me.tblPatologias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblPatologias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPatologias.ColumnHeadersVisible = False
        Me.tblPatologias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObjeto2, Me.colPatologia})
        Me.tblPatologias.Location = New System.Drawing.Point(537, 348)
        Me.tblPatologias.Name = "tblPatologias"
        Me.tblPatologias.ReadOnly = True
        Me.tblPatologias.RowHeadersVisible = False
        Me.tblPatologias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblPatologias.Size = New System.Drawing.Size(299, 327)
        Me.tblPatologias.TabIndex = 33
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
        'btnQuitarPatologia
        '
        Me.btnQuitarPatologia.Location = New System.Drawing.Point(381, 548)
        Me.btnQuitarPatologia.Name = "btnQuitarPatologia"
        Me.btnQuitarPatologia.Size = New System.Drawing.Size(85, 23)
        Me.btnQuitarPatologia.TabIndex = 6
        Me.btnQuitarPatologia.Text = "Quitar"
        Me.btnQuitarPatologia.UseVisualStyleBackColor = True
        '
        'btnAgregarPatologia
        '
        Me.btnAgregarPatologia.Location = New System.Drawing.Point(381, 457)
        Me.btnAgregarPatologia.Name = "btnAgregarPatologia"
        Me.btnAgregarPatologia.Size = New System.Drawing.Size(85, 23)
        Me.btnAgregarPatologia.TabIndex = 5
        Me.btnAgregarPatologia.Text = "Agregar"
        Me.btnAgregarPatologia.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(534, 329)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Patologias:"
        '
        'txtBuscarPatologia
        '
        Me.txtBuscarPatologia.Location = New System.Drawing.Point(677, 325)
        Me.txtBuscarPatologia.Name = "txtBuscarPatologia"
        Me.txtBuscarPatologia.Size = New System.Drawing.Size(159, 20)
        Me.txtBuscarPatologia.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(628, 329)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Buscar:"
        '
        'FrmModificacionSintomas
        '
        Me.AcceptButton = Me.btnConfirmar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnVolver
        Me.ClientSize = New System.Drawing.Size(848, 730)
        Me.Controls.Add(Me.tblPatologias)
        Me.Controls.Add(Me.btnQuitarPatologia)
        Me.Controls.Add(Me.btnAgregarPatologia)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtBuscarPatologia)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tblAsociadas)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtUrgencia)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRecomendaciones)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmModificacionSintomas"
        Me.Text = "Form1"
        CType(Me.tblAsociadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblPatologias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtRecomendaciones As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents btnVolver As Button
    Friend WithEvents txtUrgencia As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tblAsociadas As DataGridView
    Friend WithEvents tblPatologias As DataGridView
    Friend WithEvents colObjeto2 As DataGridViewTextBoxColumn
    Friend WithEvents colPatologia As DataGridViewTextBoxColumn
    Friend WithEvents btnQuitarPatologia As Button
    Friend WithEvents btnAgregarPatologia As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtBuscarPatologia As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents colObjeto As DataGridViewTextBoxColumn
    Friend WithEvents colNomEnfermedad As DataGridViewTextBoxColumn
    Friend WithEvents colFrecuencia As DataGridViewTextBoxColumn
End Class
