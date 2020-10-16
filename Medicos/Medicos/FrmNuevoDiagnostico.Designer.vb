<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNuevoDiagnostico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNuevoDiagnostico))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnEnviarDiagnostico = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtConductaASeguir = New System.Windows.Forms.TextBox()
        Me.tblEnfermedades = New System.Windows.Forms.DataGridView()
        Me.colObjeto2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblLogeado = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.tblEnfermedades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnEnviarDiagnostico
        '
        Me.btnEnviarDiagnostico.BackColor = System.Drawing.Color.Transparent
        Me.btnEnviarDiagnostico.BackgroundImage = CType(resources.GetObject("btnEnviarDiagnostico.BackgroundImage"), System.Drawing.Image)
        Me.btnEnviarDiagnostico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEnviarDiagnostico.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnviarDiagnostico.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnEnviarDiagnostico.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnEnviarDiagnostico.Location = New System.Drawing.Point(811, 560)
        Me.btnEnviarDiagnostico.Name = "btnEnviarDiagnostico"
        Me.btnEnviarDiagnostico.Size = New System.Drawing.Size(161, 80)
        Me.btnEnviarDiagnostico.TabIndex = 0
        Me.btnEnviarDiagnostico.Text = "Enviar diagnóstico"
        Me.btnEnviarDiagnostico.UseVisualStyleBackColor = False
        '
        'btnVolver
        '
        Me.btnVolver.BackgroundImage = CType(resources.GetObject("btnVolver.BackgroundImage"), System.Drawing.Image)
        Me.btnVolver.Font = New System.Drawing.Font("Cosmic", 15.75!)
        Me.btnVolver.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnVolver.Location = New System.Drawing.Point(147, 573)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(161, 49)
        Me.btnVolver.TabIndex = 2
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label1.Location = New System.Drawing.Point(679, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(504, 66)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Seleccione una enfermedad de la lista para diagnosticar al paciente."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Cosmic", 26.25!, System.Drawing.FontStyle.Underline)
        Me.Label2.Location = New System.Drawing.Point(677, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(349, 40)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Diagnóstico diferencial"
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.txtBuscar.Location = New System.Drawing.Point(766, 113)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(246, 33)
        Me.txtBuscar.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label3.Location = New System.Drawing.Point(679, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 25)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Buscar:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Lato", 15.75!)
        Me.Label4.Location = New System.Drawing.Point(679, 349)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(183, 25)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Conducta a seguir:"
        '
        'txtConductaASeguir
        '
        Me.txtConductaASeguir.Location = New System.Drawing.Point(684, 377)
        Me.txtConductaASeguir.Multiline = True
        Me.txtConductaASeguir.Name = "txtConductaASeguir"
        Me.txtConductaASeguir.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConductaASeguir.Size = New System.Drawing.Size(396, 177)
        Me.txtConductaASeguir.TabIndex = 7
        '
        'tblEnfermedades
        '
        Me.tblEnfermedades.AllowUserToAddRows = False
        Me.tblEnfermedades.AllowUserToDeleteRows = False
        Me.tblEnfermedades.AllowUserToResizeColumns = False
        Me.tblEnfermedades.AllowUserToResizeRows = False
        Me.tblEnfermedades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblEnfermedades.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Lato", 15.75!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblEnfermedades.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.tblEnfermedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEnfermedades.ColumnHeadersVisible = False
        Me.tblEnfermedades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObjeto2})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Lato", 15.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tblEnfermedades.DefaultCellStyle = DataGridViewCellStyle2
        Me.tblEnfermedades.GridColor = System.Drawing.Color.White
        Me.tblEnfermedades.Location = New System.Drawing.Point(684, 152)
        Me.tblEnfermedades.MultiSelect = False
        Me.tblEnfermedades.Name = "tblEnfermedades"
        Me.tblEnfermedades.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Lato", 15.75!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblEnfermedades.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.tblEnfermedades.RowHeadersVisible = False
        Me.tblEnfermedades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblEnfermedades.Size = New System.Drawing.Size(396, 194)
        Me.tblEnfermedades.TabIndex = 34
        '
        'colObjeto2
        '
        Me.colObjeto2.HeaderText = "Objeto"
        Me.colObjeto2.Name = "colObjeto2"
        Me.colObjeto2.ReadOnly = True
        '
        'lblLogeado
        '
        Me.lblLogeado.BackColor = System.Drawing.Color.Transparent
        Me.lblLogeado.Font = New System.Drawing.Font("Cosmic", 26.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblLogeado.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblLogeado.Location = New System.Drawing.Point(25, 264)
        Me.lblLogeado.Name = "lblLogeado"
        Me.lblLogeado.Size = New System.Drawing.Size(425, 148)
        Me.lblLogeado.TabIndex = 35
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
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Traducir"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmNuevoDiagnostico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1214, 681)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblLogeado)
        Me.Controls.Add(Me.tblEnfermedades)
        Me.Controls.Add(Me.txtConductaASeguir)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnEnviarDiagnostico)
        Me.DoubleBuffered = True
        Me.Name = "FrmNuevoDiagnostico"
        Me.Text = "FrmNuevoDiagnostico"
        CType(Me.tblEnfermedades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnEnviarDiagnostico As Button
    Friend WithEvents btnVolver As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtConductaASeguir As TextBox
    Friend WithEvents tblEnfermedades As DataGridView
    Friend WithEvents colObjeto2 As DataGridViewTextBoxColumn
    Friend WithEvents lblLogeado As Label
    Friend WithEvents Label5 As Label
End Class
