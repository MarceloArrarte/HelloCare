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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblListado = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblSintomasSeleccionados = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LblIngresarSintoma
        '
        Me.LblIngresarSintoma.AutoSize = True
        Me.LblIngresarSintoma.Location = New System.Drawing.Point(43, 42)
        Me.LblIngresarSintoma.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblIngresarSintoma.Name = "LblIngresarSintoma"
        Me.LblIngresarSintoma.Size = New System.Drawing.Size(97, 13)
        Me.LblIngresarSintoma.TabIndex = 0
        Me.LblIngresarSintoma.Text = "Ingrese su Sintoma"
        '
        'Titulo
        '
        Me.Titulo.AutoSize = True
        Me.Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titulo.Location = New System.Drawing.Point(225, 7)
        Me.Titulo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Titulo.Name = "Titulo"
        Me.Titulo.Size = New System.Drawing.Size(182, 24)
        Me.Titulo.TabIndex = 1
        Me.Titulo.Text = "Ingreso de Sintomas"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(157, 42)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(118, 20)
        Me.TextBox1.TabIndex = 2
        '
        'lblListado
        '
        Me.lblListado.AutoSize = True
        Me.lblListado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListado.Location = New System.Drawing.Point(42, 74)
        Me.lblListado.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblListado.Name = "lblListado"
        Me.lblListado.Size = New System.Drawing.Size(54, 17)
        Me.lblListado.TabIndex = 4
        Me.lblListado.Text = "Listado"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(45, 127)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(132, 108)
        Me.ListBox1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 101)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(267, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Seleccione de la lista su sintoma y presiona una opción"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Location = New System.Drawing.Point(45, 247)
        Me.BtnAgregar.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(107, 28)
        Me.BtnAgregar.TabIndex = 7
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(544, 247)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(96, 27)
        Me.btnEliminar.TabIndex = 8
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(206, 303)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(91, 32)
        Me.btnSalir.TabIndex = 9
        Me.btnSalir.Text = "Volver"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblSintomasSeleccionados
        '
        Me.lblSintomasSeleccionados.AutoSize = True
        Me.lblSintomasSeleccionados.Location = New System.Drawing.Point(389, 101)
        Me.lblSintomasSeleccionados.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSintomasSeleccionados.Name = "lblSintomasSeleccionados"
        Me.lblSintomasSeleccionados.Size = New System.Drawing.Size(123, 13)
        Me.lblSintomasSeleccionados.TabIndex = 10
        Me.lblSintomasSeleccionados.Text = "Sintomas Seleccionados"
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(544, 127)
        Me.ListBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(121, 108)
        Me.ListBox2.TabIndex = 11
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(544, 303)
        Me.btnEnviar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(96, 28)
        Me.btnEnviar.TabIndex = 12
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'FrmIngresoSintoma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 366)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.lblSintomasSeleccionados)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.lblListado)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Titulo)
        Me.Controls.Add(Me.LblIngresarSintoma)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmIngresoSintoma"
        Me.Text = "MenuPrincipalPaciente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblIngresarSintoma As Windows.Forms.Label
    Friend WithEvents Titulo As Windows.Forms.Label
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents lblListado As Windows.Forms.Label
    Friend WithEvents ListBox1 As Windows.Forms.ListBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents BtnAgregar As Windows.Forms.Button
    Friend WithEvents btnEliminar As Windows.Forms.Button
    Friend WithEvents btnSalir As Windows.Forms.Button
    Friend WithEvents lblSintomasSeleccionados As Windows.Forms.Label
    Friend WithEvents ListBox2 As Windows.Forms.ListBox
    Friend WithEvents btnEnviar As Windows.Forms.Button
End Class
