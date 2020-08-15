<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMenuPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuPrincipal))
        Me.btnPeticiones = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnHistorialPacientes = New System.Windows.Forms.Button()
        Me.btnHistorialChat = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPeticiones
        '
        Me.btnPeticiones.Font = New System.Drawing.Font("Lato", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPeticiones.Location = New System.Drawing.Point(6, 40)
        Me.btnPeticiones.Name = "btnPeticiones"
        Me.btnPeticiones.Size = New System.Drawing.Size(159, 51)
        Me.btnPeticiones.TabIndex = 0
        Me.btnPeticiones.Text = "Peticiones de chat"
        Me.btnPeticiones.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSalir)
        Me.GroupBox1.Controls.Add(Me.btnHistorialPacientes)
        Me.GroupBox1.Controls.Add(Me.btnHistorialChat)
        Me.GroupBox1.Controls.Add(Me.btnPeticiones)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 426)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Menú principal"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Lato", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(6, 360)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(159, 51)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnHistorialPacientes
        '
        Me.btnHistorialPacientes.Font = New System.Drawing.Font("Lato", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistorialPacientes.Location = New System.Drawing.Point(6, 194)
        Me.btnHistorialPacientes.Name = "btnHistorialPacientes"
        Me.btnHistorialPacientes.Size = New System.Drawing.Size(159, 51)
        Me.btnHistorialPacientes.TabIndex = 2
        Me.btnHistorialPacientes.Text = "Historial de pacientes"
        Me.btnHistorialPacientes.UseVisualStyleBackColor = True
        '
        'btnHistorialChat
        '
        Me.btnHistorialChat.Font = New System.Drawing.Font("Lato", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistorialChat.Location = New System.Drawing.Point(6, 120)
        Me.btnHistorialChat.Name = "btnHistorialChat"
        Me.btnHistorialChat.Size = New System.Drawing.Size(159, 51)
        Me.btnHistorialChat.TabIndex = 1
        Me.btnHistorialChat.Text = "Historial de chats"
        Me.btnHistorialChat.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(218, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(570, 431)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'FrmMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmMenuPrincipal"
        Me.Text = "FrmMenuMedico"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPeticiones As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnHistorialPacientes As Button
    Friend WithEvents btnHistorialChat As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
