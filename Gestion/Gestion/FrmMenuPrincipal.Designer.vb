﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMenuPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuPrincipal))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnABMSintomas = New System.Windows.Forms.Button()
        Me.btnABMEnfermedades = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblLogeado = New System.Windows.Forms.Label()
        Me.btnConfiguracion = New System.Windows.Forms.Button()
        Me.lblTraducir = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Name = "Label1"
        '
        'btnABMSintomas
        '
        resources.ApplyResources(Me.btnABMSintomas, "btnABMSintomas")
        Me.btnABMSintomas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnABMSintomas.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnABMSintomas.Name = "btnABMSintomas"
        Me.btnABMSintomas.UseVisualStyleBackColor = False
        '
        'btnABMEnfermedades
        '
        resources.ApplyResources(Me.btnABMEnfermedades, "btnABMEnfermedades")
        Me.btnABMEnfermedades.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnABMEnfermedades.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnABMEnfermedades.Name = "btnABMEnfermedades"
        Me.btnABMEnfermedades.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        resources.ApplyResources(Me.btnSalir, "btnSalir")
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'lblLogeado
        '
        resources.ApplyResources(Me.lblLogeado, "lblLogeado")
        Me.lblLogeado.BackColor = System.Drawing.Color.Transparent
        Me.lblLogeado.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblLogeado.Name = "lblLogeado"
        '
        'btnConfiguracion
        '
        resources.ApplyResources(Me.btnConfiguracion, "btnConfiguracion")
        Me.btnConfiguracion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnConfiguracion.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnConfiguracion.Name = "btnConfiguracion"
        Me.btnConfiguracion.UseVisualStyleBackColor = False
        '
        'lblTraducir
        '
        resources.ApplyResources(Me.lblTraducir, "lblTraducir")
        Me.lblTraducir.BackColor = System.Drawing.Color.Transparent
        Me.lblTraducir.ForeColor = System.Drawing.Color.White
        Me.lblTraducir.Name = "lblTraducir"
        '
        'FrmMenuPrincipal
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblTraducir)
        Me.Controls.Add(Me.btnConfiguracion)
        Me.Controls.Add(Me.lblLogeado)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnABMEnfermedades)
        Me.Controls.Add(Me.btnABMSintomas)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.Name = "FrmMenuPrincipal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnABMSintomas As Button
    Friend WithEvents btnABMEnfermedades As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents lblLogeado As Label
    Friend WithEvents btnConfiguracion As Button
    Friend WithEvents lblTraducir As Label
End Class
