﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmModificacionPaciente
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModificacionPaciente))
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.tblLocalidad = New System.Windows.Forms.DataGridView()
        Me.colObjeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtApartamento = New System.Windows.Forms.TextBox()
        Me.txtNumeroPuerta = New System.Windows.Forms.TextBox()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.txtTelFijo = New System.Windows.Forms.TextBox()
        Me.txtTelMovil = New System.Windows.Forms.TextBox()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.txtApellido = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtCi = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbSexo = New System.Windows.Forms.ComboBox()
        Me.dtpFechaNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDefuncion = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaDefuncion = New System.Windows.Forms.Label()
        Me.cbHabilitarFD = New System.Windows.Forms.CheckBox()
        Me.lblTraducir = New System.Windows.Forms.Label()
        CType(Me.tblLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnVolver
        '
        Me.btnVolver.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        resources.ApplyResources(Me.btnVolver, "btnVolver")
        Me.btnVolver.ForeColor = System.Drawing.Color.Transparent
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.UseVisualStyleBackColor = False
        '
        'btnConfirmar
        '
        Me.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        resources.ApplyResources(Me.btnConfirmar, "btnConfirmar")
        Me.btnConfirmar.ForeColor = System.Drawing.Color.Transparent
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.UseVisualStyleBackColor = False
        '
        'tblLocalidad
        '
        Me.tblLocalidad.AllowUserToAddRows = False
        Me.tblLocalidad.AllowUserToDeleteRows = False
        Me.tblLocalidad.AllowUserToResizeColumns = False
        Me.tblLocalidad.AllowUserToResizeRows = False
        Me.tblLocalidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblLocalidad.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.tblLocalidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblLocalidad.ColumnHeadersVisible = False
        Me.tblLocalidad.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObjeto})
        resources.ApplyResources(Me.tblLocalidad, "tblLocalidad")
        Me.tblLocalidad.MultiSelect = False
        Me.tblLocalidad.Name = "tblLocalidad"
        Me.tblLocalidad.RowHeadersVisible = False
        Me.tblLocalidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'colObjeto
        '
        resources.ApplyResources(Me.colObjeto, "colObjeto")
        Me.colObjeto.Name = "colObjeto"
        '
        'txtApartamento
        '
        resources.ApplyResources(Me.txtApartamento, "txtApartamento")
        Me.txtApartamento.Name = "txtApartamento"
        '
        'txtNumeroPuerta
        '
        resources.ApplyResources(Me.txtNumeroPuerta, "txtNumeroPuerta")
        Me.txtNumeroPuerta.Name = "txtNumeroPuerta"
        '
        'txtCalle
        '
        resources.ApplyResources(Me.txtCalle, "txtCalle")
        Me.txtCalle.Name = "txtCalle"
        '
        'txtTelFijo
        '
        resources.ApplyResources(Me.txtTelFijo, "txtTelFijo")
        Me.txtTelFijo.Name = "txtTelFijo"
        '
        'txtTelMovil
        '
        resources.ApplyResources(Me.txtTelMovil, "txtTelMovil")
        Me.txtTelMovil.Name = "txtTelMovil"
        '
        'txtCorreo
        '
        resources.ApplyResources(Me.txtCorreo, "txtCorreo")
        Me.txtCorreo.Name = "txtCorreo"
        '
        'txtApellido
        '
        resources.ApplyResources(Me.txtApellido, "txtApellido")
        Me.txtApellido.Name = "txtApellido"
        '
        'txtNombre
        '
        resources.ApplyResources(Me.txtNombre, "txtNombre")
        Me.txtNombre.Name = "txtNombre"
        '
        'txtCi
        '
        resources.ApplyResources(Me.txtCi, "txtCi")
        Me.txtCi.Name = "txtCi"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Name = "Label13"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Name = "Label12"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Name = "Label11"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Name = "Label10"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Name = "Label9"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Name = "Label8"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Name = "Label7"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Name = "Label6"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Name = "Label5"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Name = "Label4"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Name = "Label3"
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
        'cmbDepartamento
        '
        Me.cmbDepartamento.FormattingEnabled = True
        resources.ApplyResources(Me.cmbDepartamento, "cmbDepartamento")
        Me.cmbDepartamento.Name = "cmbDepartamento"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Name = "Label14"
        '
        'cmbSexo
        '
        Me.cmbSexo.FormattingEnabled = True
        resources.ApplyResources(Me.cmbSexo, "cmbSexo")
        Me.cmbSexo.Name = "cmbSexo"
        '
        'dtpFechaNacimiento
        '
        resources.ApplyResources(Me.dtpFechaNacimiento, "dtpFechaNacimiento")
        Me.dtpFechaNacimiento.Name = "dtpFechaNacimiento"
        '
        'dtpFechaDefuncion
        '
        resources.ApplyResources(Me.dtpFechaDefuncion, "dtpFechaDefuncion")
        Me.dtpFechaDefuncion.Name = "dtpFechaDefuncion"
        '
        'lblFechaDefuncion
        '
        resources.ApplyResources(Me.lblFechaDefuncion, "lblFechaDefuncion")
        Me.lblFechaDefuncion.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaDefuncion.Name = "lblFechaDefuncion"
        '
        'cbHabilitarFD
        '
        resources.ApplyResources(Me.cbHabilitarFD, "cbHabilitarFD")
        Me.cbHabilitarFD.BackColor = System.Drawing.Color.Transparent
        Me.cbHabilitarFD.Name = "cbHabilitarFD"
        Me.cbHabilitarFD.UseVisualStyleBackColor = False
        '
        'lblTraducir
        '
        Me.lblTraducir.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.lblTraducir, "lblTraducir")
        Me.lblTraducir.ForeColor = System.Drawing.Color.White
        Me.lblTraducir.Name = "lblTraducir"
        '
        'FrmModificacionPaciente
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblTraducir)
        Me.Controls.Add(Me.cbHabilitarFD)
        Me.Controls.Add(Me.dtpFechaDefuncion)
        Me.Controls.Add(Me.lblFechaDefuncion)
        Me.Controls.Add(Me.dtpFechaNacimiento)
        Me.Controls.Add(Me.cmbSexo)
        Me.Controls.Add(Me.cmbDepartamento)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.tblLocalidad)
        Me.Controls.Add(Me.txtApartamento)
        Me.Controls.Add(Me.txtNumeroPuerta)
        Me.Controls.Add(Me.txtCalle)
        Me.Controls.Add(Me.txtTelFijo)
        Me.Controls.Add(Me.txtTelMovil)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.txtApellido)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtCi)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "FrmModificacionPaciente"
        CType(Me.tblLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnVolver As Button
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents tblLocalidad As DataGridView
    Friend WithEvents txtApartamento As TextBox
    Friend WithEvents txtNumeroPuerta As TextBox
    Friend WithEvents txtCalle As TextBox
    Friend WithEvents txtTelFijo As TextBox
    Friend WithEvents txtTelMovil As TextBox
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents txtApellido As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtCi As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbDepartamento As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbSexo As ComboBox
    Friend WithEvents dtpFechaNacimiento As DateTimePicker
    Friend WithEvents colObjeto As DataGridViewTextBoxColumn
    Friend WithEvents dtpFechaDefuncion As DateTimePicker
    Friend WithEvents lblFechaDefuncion As Label
    Friend WithEvents cbHabilitarFD As CheckBox
    Friend WithEvents lblTraducir As Label
End Class
