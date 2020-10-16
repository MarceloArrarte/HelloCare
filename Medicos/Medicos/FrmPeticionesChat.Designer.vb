<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPeticionesChat
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPeticionesChat))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnAceptarConsulta = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tblPeticiones = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLogeado = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.tblPeticiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptarConsulta
        '
        Me.btnAceptarConsulta.BackgroundImage = CType(resources.GetObject("btnAceptarConsulta.BackgroundImage"), System.Drawing.Image)
        Me.btnAceptarConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAceptarConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptarConsulta.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnAceptarConsulta.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAceptarConsulta.Location = New System.Drawing.Point(813, 613)
        Me.btnAceptarConsulta.Name = "btnAceptarConsulta"
        Me.btnAceptarConsulta.Size = New System.Drawing.Size(161, 57)
        Me.btnAceptarConsulta.TabIndex = 0
        Me.btnAceptarConsulta.Text = "Aceptar consulta"
        Me.btnAceptarConsulta.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label1.Location = New System.Drawing.Point(541, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(592, 90)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "A continuación se muestran las peticiones de chat que han solicitado una consulta" &
    " médica. Seleccione una y presione ""Aceptar consulta"" para iniciar un chat."
        '
        'tblPeticiones
        '
        Me.tblPeticiones.AllowUserToAddRows = False
        Me.tblPeticiones.AllowUserToDeleteRows = False
        Me.tblPeticiones.AllowUserToResizeColumns = False
        Me.tblPeticiones.AllowUserToResizeRows = False
        Me.tblPeticiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblPeticiones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Lato", 15.75!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblPeticiones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.tblPeticiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPeticiones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column5, Me.Column4})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Lato", 15.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tblPeticiones.DefaultCellStyle = DataGridViewCellStyle2
        Me.tblPeticiones.Location = New System.Drawing.Point(500, 161)
        Me.tblPeticiones.MultiSelect = False
        Me.tblPeticiones.Name = "tblPeticiones"
        Me.tblPeticiones.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Lato", 15.75!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblPeticiones.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.tblPeticiones.RowHeadersVisible = False
        Me.tblPeticiones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tblPeticiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblPeticiones.Size = New System.Drawing.Size(702, 446)
        Me.tblPeticiones.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.HeaderText = "Objeto"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.FillWeight = 25.0!
        Me.Column2.HeaderText = "Paciente"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.FillWeight = 20.0!
        Me.Column3.HeaderText = "Diagnóstico primario"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.FillWeight = 30.0!
        Me.Column5.HeaderText = "Información adicional"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.FillWeight = 20.0!
        Me.Column4.HeaderText = "Fecha y hora"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'btnVolver
        '
        Me.btnVolver.BackgroundImage = CType(resources.GetObject("btnVolver.BackgroundImage"), System.Drawing.Image)
        Me.btnVolver.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnVolver.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnVolver.Location = New System.Drawing.Point(147, 573)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(161, 49)
        Me.btnVolver.TabIndex = 3
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Cosmic", 26.25!, System.Drawing.FontStyle.Underline)
        Me.Label2.Location = New System.Drawing.Point(539, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(469, 40)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Peticiones de chat disponibles"
        '
        'lblLogeado
        '
        Me.lblLogeado.BackColor = System.Drawing.Color.Transparent
        Me.lblLogeado.Font = New System.Drawing.Font("Cosmic", 26.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblLogeado.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblLogeado.Location = New System.Drawing.Point(25, 264)
        Me.lblLogeado.Name = "lblLogeado"
        Me.lblLogeado.Size = New System.Drawing.Size(425, 148)
        Me.lblLogeado.TabIndex = 36
        Me.lblLogeado.Text = "Bienvenido/a," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "#"
        Me.lblLogeado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Traducir"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmPeticionesChat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1214, 681)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblLogeado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.tblPeticiones)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAceptarConsulta)
        Me.DoubleBuffered = True
        Me.Name = "FrmPeticionesChat"
        Me.Text = "PeticionesChat"
        CType(Me.tblPeticiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAceptarConsulta As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents tblPeticiones As DataGridView
    Friend WithEvents btnVolver As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents lblLogeado As Label
    Friend WithEvents Label5 As Label
End Class
