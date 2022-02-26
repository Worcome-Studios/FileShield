<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblCloseTip = New System.Windows.Forms.Label()
        Me.lblCountShieldedFiles = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnConfig = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnRename = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.lnklblGuide = New System.Windows.Forms.LinkLabel()
        Me.lnklblInformation = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(331, 38)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Protector de Archivos"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.ForeColor = System.Drawing.Color.Gray
        Me.lblVersion.Location = New System.Drawing.Point(16, 48)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(108, 17)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Version: 0.0.0.0"
        '
        'lblCloseTip
        '
        Me.lblCloseTip.AutoSize = True
        Me.lblCloseTip.ForeColor = System.Drawing.Color.Gray
        Me.lblCloseTip.Location = New System.Drawing.Point(648, 9)
        Me.lblCloseTip.Name = "lblCloseTip"
        Me.lblCloseTip.Size = New System.Drawing.Size(222, 17)
        Me.lblCloseTip.TabIndex = 2
        Me.lblCloseTip.Text = "Siempre cierrame con el boton /X\"
        '
        'lblCountShieldedFiles
        '
        Me.lblCountShieldedFiles.ForeColor = System.Drawing.Color.DimGray
        Me.lblCountShieldedFiles.Location = New System.Drawing.Point(651, 118)
        Me.lblCountShieldedFiles.Name = "lblCountShieldedFiles"
        Me.lblCountShieldedFiles.Size = New System.Drawing.Size(219, 20)
        Me.lblCountShieldedFiles.TabIndex = 3
        Me.lblCountShieldedFiles.Text = "Protegiendo: 0 Archivos"
        Me.lblCountShieldedFiles.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnConfig)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 141)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(164, 330)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones"
        '
        'btnConfig
        '
        Me.btnConfig.Location = New System.Drawing.Point(10, 32)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(144, 48)
        Me.btnConfig.TabIndex = 6
        Me.btnConfig.Text = "Configuracion"
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnRename)
        Me.GroupBox2.Controls.Add(Me.btnOpen)
        Me.GroupBox2.Controls.Add(Me.btnRemove)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.ListBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(182, 141)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(688, 330)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'btnRename
        '
        Me.btnRename.Enabled = False
        Me.btnRename.Location = New System.Drawing.Point(575, 193)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(107, 28)
        Me.btnRename.TabIndex = 4
        Me.btnRename.Text = "Renombrar"
        Me.btnRename.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Enabled = False
        Me.btnOpen.Location = New System.Drawing.Point(575, 159)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(107, 28)
        Me.btnOpen.TabIndex = 3
        Me.btnOpen.Text = "Abrir"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Enabled = False
        Me.btnRemove.Location = New System.Drawing.Point(575, 72)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(107, 34)
        Me.btnRemove.TabIndex = 2
        Me.btnRemove.Text = "Quitar"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(575, 32)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(107, 34)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Añadir"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(6, 32)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(563, 292)
        Me.ListBox1.TabIndex = 0
        '
        'lnklblGuide
        '
        Me.lnklblGuide.AutoSize = True
        Me.lnklblGuide.Location = New System.Drawing.Point(12, 474)
        Me.lnklblGuide.Name = "lnklblGuide"
        Me.lnklblGuide.Size = New System.Drawing.Size(38, 17)
        Me.lnklblGuide.TabIndex = 6
        Me.lnklblGuide.TabStop = True
        Me.lnklblGuide.Text = "Guia"
        '
        'lnklblInformation
        '
        Me.lnklblInformation.AutoSize = True
        Me.lnklblInformation.Location = New System.Drawing.Point(95, 474)
        Me.lnklblInformation.Name = "lnklblInformation"
        Me.lnklblInformation.Size = New System.Drawing.Size(81, 17)
        Me.lnklblInformation.TabIndex = 7
        Me.lnklblInformation.TabStop = True
        Me.lnklblInformation.Text = "Informacion"
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 503)
        Me.Controls.Add(Me.lnklblInformation)
        Me.Controls.Add(Me.lnklblGuide)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblCountShieldedFiles)
        Me.Controls.Add(Me.lblCloseTip)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wor FileShield"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblCloseTip As Label
    Friend WithEvents lblCountShieldedFiles As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnConfig As Button
    Friend WithEvents lnklblGuide As LinkLabel
    Friend WithEvents lnklblInformation As LinkLabel
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents btnRename As Button
    Friend WithEvents btnOpen As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnAdd As Button
End Class
