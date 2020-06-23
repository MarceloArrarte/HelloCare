<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAltaSintomas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAltaSintomas))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNombreSintoma = New System.Windows.Forms.TextBox()
        Me.txtInfoSintoma = New System.Windows.Forms.TextBox()
        Me.txtRecomendacionSintoma = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.lblUrgenciaSintoma = New System.Windows.Forms.Label()
        Me.txtUrgencia = New System.Windows.Forms.TextBox()
        Me.tblPatologias = New System.Windows.Forms.DataGridView()
        Me.colObjeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAsociacion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colEnfermedades = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFrecuencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.tblPatologias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!)
        Me.Label1.Location = New System.Drawing.Point(231, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Alta de síntomas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(78, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre del sintoma:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Informacion del sintoma:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Recomendaciones del sintoma:"
        '
        'txtNombreSintoma
        '
        Me.txtNombreSintoma.Location = New System.Drawing.Point(193, 54)
        Me.txtNombreSintoma.Multiline = True
        Me.txtNombreSintoma.Name = "txtNombreSintoma"
        Me.txtNombreSintoma.Size = New System.Drawing.Size(427, 25)
        Me.txtNombreSintoma.TabIndex = 0
        '
        'txtInfoSintoma
        '
        Me.txtInfoSintoma.Location = New System.Drawing.Point(193, 95)
        Me.txtInfoSintoma.Multiline = True
        Me.txtInfoSintoma.Name = "txtInfoSintoma"
        Me.txtInfoSintoma.Size = New System.Drawing.Size(427, 72)
        Me.txtInfoSintoma.TabIndex = 1
        '
        'txtRecomendacionSintoma
        '
        Me.txtRecomendacionSintoma.Location = New System.Drawing.Point(193, 233)
        Me.txtRecomendacionSintoma.Multiline = True
        Me.txtRecomendacionSintoma.Name = "txtRecomendacionSintoma"
        Me.txtRecomendacionSintoma.Size = New System.Drawing.Size(427, 127)
        Me.txtRecomendacionSintoma.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 377)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Patologias a asociar"
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(545, 621)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 5
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnVolver
        '
        Me.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnVolver.Location = New System.Drawing.Point(12, 621)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver.TabIndex = 4
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'lblUrgenciaSintoma
        '
        Me.lblUrgenciaSintoma.AutoSize = True
        Me.lblUrgenciaSintoma.Location = New System.Drawing.Point(127, 191)
        Me.lblUrgenciaSintoma.Name = "lblUrgenciaSintoma"
        Me.lblUrgenciaSintoma.Size = New System.Drawing.Size(53, 13)
        Me.lblUrgenciaSintoma.TabIndex = 14
        Me.lblUrgenciaSintoma.Text = "Urgencia:"
        '
        'txtUrgencia
        '
        Me.txtUrgencia.Location = New System.Drawing.Point(192, 188)
        Me.txtUrgencia.Multiline = True
        Me.txtUrgencia.Name = "txtUrgencia"
        Me.txtUrgencia.Size = New System.Drawing.Size(427, 25)
        Me.txtUrgencia.TabIndex = 2
        '
        'tblPatologias
        '
        Me.tblPatologias.AllowUserToAddRows = False
        Me.tblPatologias.AllowUserToDeleteRows = False
        Me.tblPatologias.AllowUserToResizeColumns = False
        Me.tblPatologias.AllowUserToResizeRows = False
        Me.tblPatologias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblPatologias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPatologias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObjeto, Me.colAsociacion, Me.colEnfermedades, Me.colFrecuencia})
        Me.tblPatologias.Location = New System.Drawing.Point(12, 411)
        Me.tblPatologias.Name = "tblPatologias"
        Me.tblPatologias.RowHeadersVisible = False
        Me.tblPatologias.Size = New System.Drawing.Size(608, 188)
        Me.tblPatologias.TabIndex = 15
        Me.tblPatologias.TabStop = False
        '
        'colObjeto
        '
        Me.colObjeto.HeaderText = "Objeto"
        Me.colObjeto.Name = "colObjeto"
        Me.colObjeto.Visible = False
        '
        'colAsociacion
        '
        Me.colAsociacion.FillWeight = 15.0!
        Me.colAsociacion.HeaderText = "Asociación"
        Me.colAsociacion.Name = "colAsociacion"
        Me.colAsociacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colAsociacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colEnfermedades
        '
        Me.colEnfermedades.FillWeight = 70.0!
        Me.colEnfermedades.HeaderText = "Enfermedades"
        Me.colEnfermedades.Name = "colEnfermedades"
        Me.colEnfermedades.ReadOnly = True
        '
        'colFrecuencia
        '
        Me.colFrecuencia.FillWeight = 15.0!
        Me.colFrecuencia.HeaderText = "Frecuencia"
        Me.colFrecuencia.Name = "colFrecuencia"
        '
        'FrmAltaSintomas
        '
        Me.AcceptButton = Me.btnAgregar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnVolver
        Me.ClientSize = New System.Drawing.Size(640, 656)
        Me.Controls.Add(Me.tblPatologias)
        Me.Controls.Add(Me.lblUrgenciaSintoma)
        Me.Controls.Add(Me.txtUrgencia)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRecomendacionSintoma)
        Me.Controls.Add(Me.txtInfoSintoma)
        Me.Controls.Add(Me.txtNombreSintoma)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmAltaSintomas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta de síntomas"
        CType(Me.tblPatologias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNombreSintoma As TextBox
    Friend WithEvents txtInfoSintoma As TextBox
    Friend WithEvents txtRecomendacionSintoma As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnVolver As Button
    Friend WithEvents lblUrgenciaSintoma As Label
    Friend WithEvents txtUrgencia As TextBox
    Friend WithEvents tblPatologias As DataGridView
    Friend WithEvents colObjeto As DataGridViewTextBoxColumn
    Friend WithEvents colAsociacion As DataGridViewCheckBoxColumn
    Friend WithEvents colEnfermedades As DataGridViewTextBoxColumn
    Friend WithEvents colFrecuencia As DataGridViewTextBoxColumn
End Class
