<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChatMedico
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
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.txtBoxMensaje = New System.Windows.Forms.RichTextBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.btnArchivo = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNombrePaciente = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstArchivos = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtBoxMensajes = New System.Windows.Forms.TextBox()
        Me.btnDiagnosticar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(92, 400)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'txtBoxMensaje
        '
        Me.txtBoxMensaje.Location = New System.Drawing.Point(249, 388)
        Me.txtBoxMensaje.Name = "txtBoxMensaje"
        Me.txtBoxMensaje.Size = New System.Drawing.Size(452, 50)
        Me.txtBoxMensaje.TabIndex = 4
        Me.txtBoxMensaje.Text = ""
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(713, 357)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(75, 23)
        Me.btnEnviar.TabIndex = 5
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'btnArchivo
        '
        Me.btnArchivo.Location = New System.Drawing.Point(713, 386)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(75, 23)
        Me.btnArchivo.TabIndex = 6
        Me.btnArchivo.Text = "Adjuntar"
        Me.btnArchivo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Lato", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(223, 18)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Usted se está comunicando con"
        '
        'lblNombrePaciente
        '
        Me.lblNombrePaciente.AutoSize = True
        Me.lblNombrePaciente.Font = New System.Drawing.Font("Lato", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombrePaciente.Location = New System.Drawing.Point(77, 43)
        Me.lblNombrePaciente.Name = "lblNombrePaciente"
        Me.lblNombrePaciente.Size = New System.Drawing.Size(78, 18)
        Me.lblNombrePaciente.TabIndex = 11
        Me.lblNombrePaciente.Text = "@paciente"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblNombrePaciente)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(231, 77)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstArchivos)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 95)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(231, 299)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'lstArchivos
        '
        Me.lstArchivos.FormattingEnabled = True
        Me.lstArchivos.Location = New System.Drawing.Point(7, 50)
        Me.lstArchivos.Name = "lstArchivos"
        Me.lstArchivos.Size = New System.Drawing.Size(218, 238)
        Me.lstArchivos.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Lato", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(68, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 18)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "ARCHIVOS"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtBoxMensajes
        '
        Me.txtBoxMensajes.AcceptsReturn = True
        Me.txtBoxMensajes.AcceptsTab = True
        Me.txtBoxMensajes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxMensajes.Font = New System.Drawing.Font("Lato", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxMensajes.Location = New System.Drawing.Point(249, 26)
        Me.txtBoxMensajes.Multiline = True
        Me.txtBoxMensajes.Name = "txtBoxMensajes"
        Me.txtBoxMensajes.ReadOnly = True
        Me.txtBoxMensajes.Size = New System.Drawing.Size(452, 356)
        Me.txtBoxMensajes.TabIndex = 14
        '
        'btnDiagnosticar
        '
        Me.btnDiagnosticar.Location = New System.Drawing.Point(713, 415)
        Me.btnDiagnosticar.Name = "btnDiagnosticar"
        Me.btnDiagnosticar.Size = New System.Drawing.Size(75, 23)
        Me.btnDiagnosticar.TabIndex = 15
        Me.btnDiagnosticar.Text = "Diagnosticar"
        Me.btnDiagnosticar.UseVisualStyleBackColor = True
        '
        'ChatMedico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnDiagnosticar)
        Me.Controls.Add(Me.txtBoxMensajes)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnArchivo)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.txtBoxMensaje)
        Me.Controls.Add(Me.btnSalir)
        Me.Name = "ChatMedico"
        Me.Text = "ChatPaciente"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Splitter1 As Windows.Forms.Splitter
    Friend WithEvents btnSalir As Windows.Forms.Button
    Friend WithEvents txtBoxMensaje As Windows.Forms.RichTextBox
    Friend WithEvents btnEnviar As Windows.Forms.Button
    Friend WithEvents btnArchivo As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents lblNombrePaciente As Windows.Forms.Label
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents lstArchivos As Windows.Forms.ListBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
    Friend WithEvents txtBoxMensajes As Windows.Forms.TextBox
    Friend WithEvents btnDiagnosticar As Button
End Class
