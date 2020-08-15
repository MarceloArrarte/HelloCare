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
        CType(Me.tblPeticiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptarConsulta
        '
        Me.btnAceptarConsulta.Location = New System.Drawing.Point(547, 345)
        Me.btnAceptarConsulta.Name = "btnAceptarConsulta"
        Me.btnAceptarConsulta.Size = New System.Drawing.Size(108, 23)
        Me.btnAceptarConsulta.TabIndex = 0
        Me.btnAceptarConsulta.Text = "Aceptar consulta"
        Me.btnAceptarConsulta.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(643, 42)
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
        Me.tblPeticiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPeticiones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column5, Me.Column4})
        Me.tblPeticiones.Location = New System.Drawing.Point(12, 96)
        Me.tblPeticiones.MultiSelect = False
        Me.tblPeticiones.Name = "tblPeticiones"
        Me.tblPeticiones.ReadOnly = True
        Me.tblPeticiones.RowHeadersVisible = False
        Me.tblPeticiones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tblPeticiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblPeticiones.Size = New System.Drawing.Size(643, 232)
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
        Me.btnVolver.Location = New System.Drawing.Point(12, 345)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver.TabIndex = 3
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(201, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(265, 24)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Peticiones de chat disponibles"
        '
        'FrmPeticionesChat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 380)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.tblPeticiones)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAceptarConsulta)
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
End Class
