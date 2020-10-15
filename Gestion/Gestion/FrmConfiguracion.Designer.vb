<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfiguracion
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.btnAgregarDepartamento = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAgregarDepartamento = New System.Windows.Forms.TextBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.txtNuevoNombreDepartamento = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnModificarDepartamento = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNombreDepartamentoAModificar = New System.Windows.Forms.TextBox()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.btnEliminarDepartamento = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEliminarDepartamento = New System.Windows.Forms.TextBox()
        Me.grdDepartamentos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBuscarDepartamento = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cbxDepartamentos = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TabControl3 = New System.Windows.Forms.TabControl()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.cbxDepartamentoDeNuevaLocalidad = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnAgregarLocalidad = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAgregarLocalidad = New System.Windows.Forms.TextBox()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.txtNuevoNombreLocalidad = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnModificarLocalidad = New System.Windows.Forms.Button()
        Me.Localidad = New System.Windows.Forms.Label()
        Me.txtNombreLocalidadAModificar = New System.Windows.Forms.TextBox()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnCambiarDepartamentoDeLocalidad = New System.Windows.Forms.Button()
        Me.txtDepartamentoActual = New System.Windows.Forms.TextBox()
        Me.cbxNuevoDepartamentoDeLocalidad = New System.Windows.Forms.ComboBox()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.btnEliminarLocalidad = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtEliminarLocalidad = New System.Windows.Forms.TextBox()
        Me.grdLocalidades = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBuscarLocalidades = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabControl4 = New System.Windows.Forms.TabControl()
        Me.TabPage11 = New System.Windows.Forms.TabPage()
        Me.btnAgregarEspecialidad = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtAgregarEspecialidad = New System.Windows.Forms.TextBox()
        Me.TabPage12 = New System.Windows.Forms.TabPage()
        Me.txtNuevoNombreEspecialidad = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnModificarEspecialidad = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNombreEspecialidadAModificar = New System.Windows.Forms.TextBox()
        Me.TabPage13 = New System.Windows.Forms.TabPage()
        Me.btnEliminarEspecialidad = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtEliminarEspecialidad = New System.Windows.Forms.TextBox()
        Me.grdEspecialidades = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtBuscarEspecialidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtLocalidadParaCambiarDepartamento = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        CType(Me.grdDepartamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.TabPage10.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        CType(Me.grdLocalidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TabControl4.SuspendLayout()
        Me.TabPage11.SuspendLayout()
        Me.TabPage12.SuspendLayout()
        Me.TabPage13.SuspendLayout()
        CType(Me.grdEspecialidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 55)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(316, 407)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TabControl2)
        Me.TabPage1.Controls.Add(Me.grdDepartamentos)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtBuscarDepartamento)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(308, 381)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Departamentos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Controls.Add(Me.TabPage6)
        Me.TabControl2.Location = New System.Drawing.Point(20, 204)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(266, 158)
        Me.TabControl2.TabIndex = 4
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.btnAgregarDepartamento)
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Controls.Add(Me.txtAgregarDepartamento)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(258, 132)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "Agregar"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'btnAgregarDepartamento
        '
        Me.btnAgregarDepartamento.Location = New System.Drawing.Point(20, 96)
        Me.btnAgregarDepartamento.Name = "btnAgregarDepartamento"
        Me.btnAgregarDepartamento.Size = New System.Drawing.Size(222, 23)
        Me.btnAgregarDepartamento.TabIndex = 2
        Me.btnAgregarDepartamento.Text = "Agregar departamento"
        Me.btnAgregarDepartamento.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Nuevo departamento:"
        '
        'txtAgregarDepartamento
        '
        Me.txtAgregarDepartamento.Location = New System.Drawing.Point(138, 19)
        Me.txtAgregarDepartamento.Name = "txtAgregarDepartamento"
        Me.txtAgregarDepartamento.Size = New System.Drawing.Size(104, 20)
        Me.txtAgregarDepartamento.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.txtNuevoNombreDepartamento)
        Me.TabPage5.Controls.Add(Me.Label5)
        Me.TabPage5.Controls.Add(Me.btnModificarDepartamento)
        Me.TabPage5.Controls.Add(Me.Label4)
        Me.TabPage5.Controls.Add(Me.txtNombreDepartamentoAModificar)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(258, 132)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "Modificar"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'txtNuevoNombreDepartamento
        '
        Me.txtNuevoNombreDepartamento.Location = New System.Drawing.Point(117, 55)
        Me.txtNuevoNombreDepartamento.Name = "txtNuevoNombreDepartamento"
        Me.txtNuevoNombreDepartamento.Size = New System.Drawing.Size(125, 20)
        Me.txtNuevoNombreDepartamento.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Nuevo nombre:"
        '
        'btnModificarDepartamento
        '
        Me.btnModificarDepartamento.Location = New System.Drawing.Point(20, 93)
        Me.btnModificarDepartamento.Name = "btnModificarDepartamento"
        Me.btnModificarDepartamento.Size = New System.Drawing.Size(222, 23)
        Me.btnModificarDepartamento.TabIndex = 5
        Me.btnModificarDepartamento.Text = "Modificar departamento"
        Me.btnModificarDepartamento.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Departamento:"
        '
        'txtNombreDepartamentoAModificar
        '
        Me.txtNombreDepartamentoAModificar.Location = New System.Drawing.Point(117, 16)
        Me.txtNombreDepartamentoAModificar.Name = "txtNombreDepartamentoAModificar"
        Me.txtNombreDepartamentoAModificar.ReadOnly = True
        Me.txtNombreDepartamentoAModificar.Size = New System.Drawing.Size(125, 20)
        Me.txtNombreDepartamentoAModificar.TabIndex = 3
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.btnEliminarDepartamento)
        Me.TabPage6.Controls.Add(Me.Label6)
        Me.TabPage6.Controls.Add(Me.txtEliminarDepartamento)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(258, 132)
        Me.TabPage6.TabIndex = 2
        Me.TabPage6.Text = "Eliminar"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'btnEliminarDepartamento
        '
        Me.btnEliminarDepartamento.Location = New System.Drawing.Point(20, 93)
        Me.btnEliminarDepartamento.Name = "btnEliminarDepartamento"
        Me.btnEliminarDepartamento.Size = New System.Drawing.Size(222, 23)
        Me.btnEliminarDepartamento.TabIndex = 8
        Me.btnEliminarDepartamento.Text = "Eliminar departamento"
        Me.btnEliminarDepartamento.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Departamento:"
        '
        'txtEliminarDepartamento
        '
        Me.txtEliminarDepartamento.Location = New System.Drawing.Point(117, 16)
        Me.txtEliminarDepartamento.Name = "txtEliminarDepartamento"
        Me.txtEliminarDepartamento.ReadOnly = True
        Me.txtEliminarDepartamento.Size = New System.Drawing.Size(125, 20)
        Me.txtEliminarDepartamento.TabIndex = 6
        '
        'grdDepartamentos
        '
        Me.grdDepartamentos.AllowUserToAddRows = False
        Me.grdDepartamentos.AllowUserToDeleteRows = False
        Me.grdDepartamentos.AllowUserToResizeColumns = False
        Me.grdDepartamentos.AllowUserToResizeRows = False
        Me.grdDepartamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDepartamentos.ColumnHeadersVisible = False
        Me.grdDepartamentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDepartamentos.DefaultCellStyle = DataGridViewCellStyle1
        Me.grdDepartamentos.Location = New System.Drawing.Point(20, 41)
        Me.grdDepartamentos.MultiSelect = False
        Me.grdDepartamentos.Name = "grdDepartamentos"
        Me.grdDepartamentos.ReadOnly = True
        Me.grdDepartamentos.RowHeadersVisible = False
        Me.grdDepartamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdDepartamentos.Size = New System.Drawing.Size(266, 150)
        Me.grdDepartamentos.TabIndex = 3
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Buscar departamento:"
        '
        'txtBuscarDepartamento
        '
        Me.txtBuscarDepartamento.Location = New System.Drawing.Point(141, 15)
        Me.txtBuscarDepartamento.Name = "txtBuscarDepartamento"
        Me.txtBuscarDepartamento.Size = New System.Drawing.Size(145, 20)
        Me.txtBuscarDepartamento.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cbxDepartamentos)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.TabControl3)
        Me.TabPage2.Controls.Add(Me.grdLocalidades)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.txtBuscarLocalidades)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(308, 381)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Localidades"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cbxDepartamentos
        '
        Me.cbxDepartamentos.FormattingEnabled = True
        Me.cbxDepartamentos.Location = New System.Drawing.Point(165, 13)
        Me.cbxDepartamentos.Name = "cbxDepartamentos"
        Me.cbxDepartamentos.Size = New System.Drawing.Size(124, 21)
        Me.cbxDepartamentos.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(20, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(134, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Seleccionar departamento:"
        '
        'TabControl3
        '
        Me.TabControl3.Controls.Add(Me.TabPage7)
        Me.TabControl3.Controls.Add(Me.TabPage8)
        Me.TabControl3.Controls.Add(Me.TabPage10)
        Me.TabControl3.Controls.Add(Me.TabPage9)
        Me.TabControl3.Location = New System.Drawing.Point(23, 206)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(266, 158)
        Me.TabControl3.TabIndex = 8
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.cbxDepartamentoDeNuevaLocalidad)
        Me.TabPage7.Controls.Add(Me.Label13)
        Me.TabPage7.Controls.Add(Me.btnAgregarLocalidad)
        Me.TabPage7.Controls.Add(Me.Label7)
        Me.TabPage7.Controls.Add(Me.txtAgregarLocalidad)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(258, 132)
        Me.TabPage7.TabIndex = 0
        Me.TabPage7.Text = "Agregar"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'cbxDepartamentoDeNuevaLocalidad
        '
        Me.cbxDepartamentoDeNuevaLocalidad.FormattingEnabled = True
        Me.cbxDepartamentoDeNuevaLocalidad.Location = New System.Drawing.Point(123, 17)
        Me.cbxDepartamentoDeNuevaLocalidad.Name = "cbxDepartamentoDeNuevaLocalidad"
        Me.cbxDepartamentoDeNuevaLocalidad.Size = New System.Drawing.Size(119, 21)
        Me.cbxDepartamentoDeNuevaLocalidad.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Departamento:"
        '
        'btnAgregarLocalidad
        '
        Me.btnAgregarLocalidad.Location = New System.Drawing.Point(20, 96)
        Me.btnAgregarLocalidad.Name = "btnAgregarLocalidad"
        Me.btnAgregarLocalidad.Size = New System.Drawing.Size(222, 23)
        Me.btnAgregarLocalidad.TabIndex = 2
        Me.btnAgregarLocalidad.Text = "Agregar localidad"
        Me.btnAgregarLocalidad.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Nueva localidad:"
        '
        'txtAgregarLocalidad
        '
        Me.txtAgregarLocalidad.Location = New System.Drawing.Point(123, 56)
        Me.txtAgregarLocalidad.Name = "txtAgregarLocalidad"
        Me.txtAgregarLocalidad.Size = New System.Drawing.Size(119, 20)
        Me.txtAgregarLocalidad.TabIndex = 0
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.txtNuevoNombreLocalidad)
        Me.TabPage8.Controls.Add(Me.Label8)
        Me.TabPage8.Controls.Add(Me.btnModificarLocalidad)
        Me.TabPage8.Controls.Add(Me.Localidad)
        Me.TabPage8.Controls.Add(Me.txtNombreLocalidadAModificar)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(258, 132)
        Me.TabPage8.TabIndex = 1
        Me.TabPage8.Text = "Modificar"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'txtNuevoNombreLocalidad
        '
        Me.txtNuevoNombreLocalidad.Location = New System.Drawing.Point(117, 55)
        Me.txtNuevoNombreLocalidad.Name = "txtNuevoNombreLocalidad"
        Me.txtNuevoNombreLocalidad.Size = New System.Drawing.Size(125, 20)
        Me.txtNuevoNombreLocalidad.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Nuevo nombre:"
        '
        'btnModificarLocalidad
        '
        Me.btnModificarLocalidad.Location = New System.Drawing.Point(20, 93)
        Me.btnModificarLocalidad.Name = "btnModificarLocalidad"
        Me.btnModificarLocalidad.Size = New System.Drawing.Size(222, 23)
        Me.btnModificarLocalidad.TabIndex = 5
        Me.btnModificarLocalidad.Text = "Modificar localidad"
        Me.btnModificarLocalidad.UseVisualStyleBackColor = True
        '
        'Localidad
        '
        Me.Localidad.AutoSize = True
        Me.Localidad.Location = New System.Drawing.Point(17, 19)
        Me.Localidad.Name = "Localidad"
        Me.Localidad.Size = New System.Drawing.Size(56, 13)
        Me.Localidad.TabIndex = 4
        Me.Localidad.Text = "Localidad:"
        '
        'txtNombreLocalidadAModificar
        '
        Me.txtNombreLocalidadAModificar.Location = New System.Drawing.Point(117, 16)
        Me.txtNombreLocalidadAModificar.Name = "txtNombreLocalidadAModificar"
        Me.txtNombreLocalidadAModificar.ReadOnly = True
        Me.txtNombreLocalidadAModificar.Size = New System.Drawing.Size(125, 20)
        Me.txtNombreLocalidadAModificar.TabIndex = 3
        '
        'TabPage10
        '
        Me.TabPage10.Controls.Add(Me.txtLocalidadParaCambiarDepartamento)
        Me.TabPage10.Controls.Add(Me.Label20)
        Me.TabPage10.Controls.Add(Me.Label14)
        Me.TabPage10.Controls.Add(Me.Label9)
        Me.TabPage10.Controls.Add(Me.btnCambiarDepartamentoDeLocalidad)
        Me.TabPage10.Controls.Add(Me.txtDepartamentoActual)
        Me.TabPage10.Controls.Add(Me.cbxNuevoDepartamentoDeLocalidad)
        Me.TabPage10.Location = New System.Drawing.Point(4, 22)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Size = New System.Drawing.Size(258, 132)
        Me.TabPage10.TabIndex = 3
        Me.TabPage10.Text = "Cambiar departamento"
        Me.TabPage10.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 72)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(110, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Nuevo departamento:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Departamento actual:"
        '
        'btnCambiarDepartamentoDeLocalidad
        '
        Me.btnCambiarDepartamentoDeLocalidad.Location = New System.Drawing.Point(17, 96)
        Me.btnCambiarDepartamentoDeLocalidad.Name = "btnCambiarDepartamentoDeLocalidad"
        Me.btnCambiarDepartamentoDeLocalidad.Size = New System.Drawing.Size(226, 23)
        Me.btnCambiarDepartamentoDeLocalidad.TabIndex = 2
        Me.btnCambiarDepartamentoDeLocalidad.Text = "Cambiar departamento de la localidad"
        Me.btnCambiarDepartamentoDeLocalidad.UseVisualStyleBackColor = True
        '
        'txtDepartamentoActual
        '
        Me.txtDepartamentoActual.Location = New System.Drawing.Point(129, 42)
        Me.txtDepartamentoActual.Name = "txtDepartamentoActual"
        Me.txtDepartamentoActual.Size = New System.Drawing.Size(114, 20)
        Me.txtDepartamentoActual.TabIndex = 1
        '
        'cbxNuevoDepartamentoDeLocalidad
        '
        Me.cbxNuevoDepartamentoDeLocalidad.FormattingEnabled = True
        Me.cbxNuevoDepartamentoDeLocalidad.Location = New System.Drawing.Point(129, 69)
        Me.cbxNuevoDepartamentoDeLocalidad.Name = "cbxNuevoDepartamentoDeLocalidad"
        Me.cbxNuevoDepartamentoDeLocalidad.Size = New System.Drawing.Size(114, 21)
        Me.cbxNuevoDepartamentoDeLocalidad.TabIndex = 0
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.btnEliminarLocalidad)
        Me.TabPage9.Controls.Add(Me.Label10)
        Me.TabPage9.Controls.Add(Me.txtEliminarLocalidad)
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(258, 132)
        Me.TabPage9.TabIndex = 2
        Me.TabPage9.Text = "Eliminar"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'btnEliminarLocalidad
        '
        Me.btnEliminarLocalidad.Location = New System.Drawing.Point(20, 93)
        Me.btnEliminarLocalidad.Name = "btnEliminarLocalidad"
        Me.btnEliminarLocalidad.Size = New System.Drawing.Size(222, 23)
        Me.btnEliminarLocalidad.TabIndex = 8
        Me.btnEliminarLocalidad.Text = "Eliminar localidad"
        Me.btnEliminarLocalidad.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Localidad:"
        '
        'txtEliminarLocalidad
        '
        Me.txtEliminarLocalidad.Location = New System.Drawing.Point(117, 16)
        Me.txtEliminarLocalidad.Name = "txtEliminarLocalidad"
        Me.txtEliminarLocalidad.ReadOnly = True
        Me.txtEliminarLocalidad.Size = New System.Drawing.Size(125, 20)
        Me.txtEliminarLocalidad.TabIndex = 6
        '
        'grdLocalidades
        '
        Me.grdLocalidades.AllowUserToAddRows = False
        Me.grdLocalidades.AllowUserToDeleteRows = False
        Me.grdLocalidades.AllowUserToResizeColumns = False
        Me.grdLocalidades.AllowUserToResizeRows = False
        Me.grdLocalidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdLocalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdLocalidades.ColumnHeadersVisible = False
        Me.grdLocalidades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdLocalidades.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdLocalidades.Location = New System.Drawing.Point(23, 72)
        Me.grdLocalidades.MultiSelect = False
        Me.grdLocalidades.Name = "grdLocalidades"
        Me.grdLocalidades.ReadOnly = True
        Me.grdLocalidades.RowHeadersVisible = False
        Me.grdLocalidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdLocalidades.Size = New System.Drawing.Size(266, 121)
        Me.grdLocalidades.TabIndex = 7
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Column1"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Buscar localidad:"
        '
        'txtBuscarLocalidades
        '
        Me.txtBuscarLocalidades.Location = New System.Drawing.Point(165, 41)
        Me.txtBuscarLocalidades.Name = "txtBuscarLocalidades"
        Me.txtBuscarLocalidades.Size = New System.Drawing.Size(124, 20)
        Me.txtBuscarLocalidades.TabIndex = 5
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TabControl4)
        Me.TabPage3.Controls.Add(Me.grdEspecialidades)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.txtBuscarEspecialidad)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(308, 381)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Especialidades"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabControl4
        '
        Me.TabControl4.Controls.Add(Me.TabPage11)
        Me.TabControl4.Controls.Add(Me.TabPage12)
        Me.TabControl4.Controls.Add(Me.TabPage13)
        Me.TabControl4.Location = New System.Drawing.Point(23, 206)
        Me.TabControl4.Name = "TabControl4"
        Me.TabControl4.SelectedIndex = 0
        Me.TabControl4.Size = New System.Drawing.Size(266, 158)
        Me.TabControl4.TabIndex = 8
        '
        'TabPage11
        '
        Me.TabPage11.Controls.Add(Me.btnAgregarEspecialidad)
        Me.TabPage11.Controls.Add(Me.Label15)
        Me.TabPage11.Controls.Add(Me.txtAgregarEspecialidad)
        Me.TabPage11.Location = New System.Drawing.Point(4, 22)
        Me.TabPage11.Name = "TabPage11"
        Me.TabPage11.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage11.Size = New System.Drawing.Size(258, 132)
        Me.TabPage11.TabIndex = 0
        Me.TabPage11.Text = "Agregar"
        Me.TabPage11.UseVisualStyleBackColor = True
        '
        'btnAgregarEspecialidad
        '
        Me.btnAgregarEspecialidad.Location = New System.Drawing.Point(20, 96)
        Me.btnAgregarEspecialidad.Name = "btnAgregarEspecialidad"
        Me.btnAgregarEspecialidad.Size = New System.Drawing.Size(222, 23)
        Me.btnAgregarEspecialidad.TabIndex = 2
        Me.btnAgregarEspecialidad.Text = "Agregar especialidad"
        Me.btnAgregarEspecialidad.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(17, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Nueva especialidad:"
        '
        'txtAgregarEspecialidad
        '
        Me.txtAgregarEspecialidad.Location = New System.Drawing.Point(138, 19)
        Me.txtAgregarEspecialidad.Name = "txtAgregarEspecialidad"
        Me.txtAgregarEspecialidad.Size = New System.Drawing.Size(104, 20)
        Me.txtAgregarEspecialidad.TabIndex = 0
        '
        'TabPage12
        '
        Me.TabPage12.Controls.Add(Me.txtNuevoNombreEspecialidad)
        Me.TabPage12.Controls.Add(Me.Label16)
        Me.TabPage12.Controls.Add(Me.btnModificarEspecialidad)
        Me.TabPage12.Controls.Add(Me.Label17)
        Me.TabPage12.Controls.Add(Me.txtNombreEspecialidadAModificar)
        Me.TabPage12.Location = New System.Drawing.Point(4, 22)
        Me.TabPage12.Name = "TabPage12"
        Me.TabPage12.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage12.Size = New System.Drawing.Size(258, 132)
        Me.TabPage12.TabIndex = 1
        Me.TabPage12.Text = "Modificar"
        Me.TabPage12.UseVisualStyleBackColor = True
        '
        'txtNuevoNombreEspecialidad
        '
        Me.txtNuevoNombreEspecialidad.Location = New System.Drawing.Point(117, 55)
        Me.txtNuevoNombreEspecialidad.Name = "txtNuevoNombreEspecialidad"
        Me.txtNuevoNombreEspecialidad.Size = New System.Drawing.Size(125, 20)
        Me.txtNuevoNombreEspecialidad.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(17, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Nuevo nombre:"
        '
        'btnModificarEspecialidad
        '
        Me.btnModificarEspecialidad.Location = New System.Drawing.Point(20, 93)
        Me.btnModificarEspecialidad.Name = "btnModificarEspecialidad"
        Me.btnModificarEspecialidad.Size = New System.Drawing.Size(222, 23)
        Me.btnModificarEspecialidad.TabIndex = 5
        Me.btnModificarEspecialidad.Text = "Modificar especialidad"
        Me.btnModificarEspecialidad.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(17, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Especialidad:"
        '
        'txtNombreEspecialidadAModificar
        '
        Me.txtNombreEspecialidadAModificar.Location = New System.Drawing.Point(117, 16)
        Me.txtNombreEspecialidadAModificar.Name = "txtNombreEspecialidadAModificar"
        Me.txtNombreEspecialidadAModificar.ReadOnly = True
        Me.txtNombreEspecialidadAModificar.Size = New System.Drawing.Size(125, 20)
        Me.txtNombreEspecialidadAModificar.TabIndex = 3
        '
        'TabPage13
        '
        Me.TabPage13.Controls.Add(Me.btnEliminarEspecialidad)
        Me.TabPage13.Controls.Add(Me.Label18)
        Me.TabPage13.Controls.Add(Me.txtEliminarEspecialidad)
        Me.TabPage13.Location = New System.Drawing.Point(4, 22)
        Me.TabPage13.Name = "TabPage13"
        Me.TabPage13.Size = New System.Drawing.Size(258, 132)
        Me.TabPage13.TabIndex = 2
        Me.TabPage13.Text = "Eliminar"
        Me.TabPage13.UseVisualStyleBackColor = True
        '
        'btnEliminarEspecialidad
        '
        Me.btnEliminarEspecialidad.Location = New System.Drawing.Point(20, 93)
        Me.btnEliminarEspecialidad.Name = "btnEliminarEspecialidad"
        Me.btnEliminarEspecialidad.Size = New System.Drawing.Size(222, 23)
        Me.btnEliminarEspecialidad.TabIndex = 8
        Me.btnEliminarEspecialidad.Text = "Eliminar especialidad"
        Me.btnEliminarEspecialidad.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(17, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 13)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "Especialidad:"
        '
        'txtEliminarEspecialidad
        '
        Me.txtEliminarEspecialidad.Location = New System.Drawing.Point(117, 16)
        Me.txtEliminarEspecialidad.Name = "txtEliminarEspecialidad"
        Me.txtEliminarEspecialidad.ReadOnly = True
        Me.txtEliminarEspecialidad.Size = New System.Drawing.Size(125, 20)
        Me.txtEliminarEspecialidad.TabIndex = 6
        '
        'grdEspecialidades
        '
        Me.grdEspecialidades.AllowUserToAddRows = False
        Me.grdEspecialidades.AllowUserToDeleteRows = False
        Me.grdEspecialidades.AllowUserToResizeColumns = False
        Me.grdEspecialidades.AllowUserToResizeRows = False
        Me.grdEspecialidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdEspecialidades.ColumnHeadersVisible = False
        Me.grdEspecialidades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdEspecialidades.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdEspecialidades.Location = New System.Drawing.Point(23, 43)
        Me.grdEspecialidades.MultiSelect = False
        Me.grdEspecialidades.Name = "grdEspecialidades"
        Me.grdEspecialidades.ReadOnly = True
        Me.grdEspecialidades.RowHeadersVisible = False
        Me.grdEspecialidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdEspecialidades.Size = New System.Drawing.Size(266, 150)
        Me.grdEspecialidades.TabIndex = 7
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Column1"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(20, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(105, 13)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "Buscar especialidad:"
        '
        'txtBuscarEspecialidad
        '
        Me.txtBuscarEspecialidad.Location = New System.Drawing.Point(144, 17)
        Me.txtBuscarEspecialidad.Name = "txtBuscarEspecialidad"
        Me.txtBuscarEspecialidad.Size = New System.Drawing.Size(145, 20)
        Me.txtBuscarEspecialidad.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Configuración del sistema"
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(113, 468)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(101, 23)
        Me.btnVolver.TabIndex = 4
        Me.btnVolver.Text = "Cancelar"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(15, 19)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 13)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Localidad:"
        '
        'txtLocalidadParaCambiarDepartamento
        '
        Me.txtLocalidadParaCambiarDepartamento.Location = New System.Drawing.Point(129, 16)
        Me.txtLocalidadParaCambiarDepartamento.Name = "txtLocalidadParaCambiarDepartamento"
        Me.txtLocalidadParaCambiarDepartamento.Size = New System.Drawing.Size(114, 20)
        Me.txtLocalidadParaCambiarDepartamento.TabIndex = 6
        '
        'FrmConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 503)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmConfiguracion"
        Me.Text = "FrmConfiguracion"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        CType(Me.grdDepartamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        Me.TabPage10.ResumeLayout(False)
        Me.TabPage10.PerformLayout()
        Me.TabPage9.ResumeLayout(False)
        Me.TabPage9.PerformLayout()
        CType(Me.grdLocalidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabControl4.ResumeLayout(False)
        Me.TabPage11.ResumeLayout(False)
        Me.TabPage11.PerformLayout()
        Me.TabPage12.ResumeLayout(False)
        Me.TabPage12.PerformLayout()
        Me.TabPage13.ResumeLayout(False)
        Me.TabPage13.PerformLayout()
        CType(Me.grdEspecialidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents btnAgregarDepartamento As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtAgregarDepartamento As TextBox
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents txtNuevoNombreDepartamento As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnModificarDepartamento As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNombreDepartamentoAModificar As TextBox
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents btnEliminarDepartamento As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEliminarDepartamento As TextBox
    Friend WithEvents grdDepartamentos As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBuscarDepartamento As TextBox
    Friend WithEvents cbxDepartamentos As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TabControl3 As TabControl
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents cbxDepartamentoDeNuevaLocalidad As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btnAgregarLocalidad As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtAgregarLocalidad As TextBox
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents txtNuevoNombreLocalidad As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnModificarLocalidad As Button
    Friend WithEvents Localidad As Label
    Friend WithEvents txtNombreLocalidadAModificar As TextBox
    Friend WithEvents TabPage10 As TabPage
    Friend WithEvents Label14 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnCambiarDepartamentoDeLocalidad As Button
    Friend WithEvents txtDepartamentoActual As TextBox
    Friend WithEvents cbxNuevoDepartamentoDeLocalidad As ComboBox
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents btnEliminarLocalidad As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents txtEliminarLocalidad As TextBox
    Friend WithEvents grdLocalidades As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Label11 As Label
    Friend WithEvents txtBuscarLocalidades As TextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabControl4 As TabControl
    Friend WithEvents TabPage11 As TabPage
    Friend WithEvents btnAgregarEspecialidad As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents txtAgregarEspecialidad As TextBox
    Friend WithEvents TabPage12 As TabPage
    Friend WithEvents txtNuevoNombreEspecialidad As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents btnModificarEspecialidad As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents txtNombreEspecialidadAModificar As TextBox
    Friend WithEvents TabPage13 As TabPage
    Friend WithEvents btnEliminarEspecialidad As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents txtEliminarEspecialidad As TextBox
    Friend WithEvents grdEspecialidades As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Label19 As Label
    Friend WithEvents txtBuscarEspecialidad As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnVolver As Button
    Friend WithEvents txtLocalidadParaCambiarDepartamento As TextBox
    Friend WithEvents Label20 As Label
End Class
