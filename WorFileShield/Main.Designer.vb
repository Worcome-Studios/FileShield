<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnEditFile = New System.Windows.Forms.Button()
        Me.btnRemoveFile = New System.Windows.Forms.Button()
        Me.btnAddFile = New System.Windows.Forms.Button()
        Me.lstArchivos = New System.Windows.Forms.ListBox()
        Me.listBoxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewInExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer_AutoLock = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Inactividad = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.listBoxMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Protector de Archivos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(146, 317)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Aplicacion"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(6, 283)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(134, 28)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Opciones"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(6, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(134, 40)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Cambiar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CryptoKey"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(6, 65)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 40)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Cambiar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Registro"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 30)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Caracteristicas bloqueadas."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label5.Visible = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel2.Location = New System.Drawing.Point(22, 407)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(58, 13)
        Me.LinkLabel2.TabIndex = 9
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Changelog"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.Location = New System.Drawing.Point(86, 407)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(72, 13)
        Me.LinkLabel1.TabIndex = 10
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Guia de uso"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.btnEditFile)
        Me.GroupBox2.Controls.Add(Me.btnRemoveFile)
        Me.GroupBox2.Controls.Add(Me.btnAddFile)
        Me.GroupBox2.Controls.Add(Me.lstArchivos)
        Me.GroupBox2.Location = New System.Drawing.Point(164, 82)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(558, 343)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(472, 48)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 23)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "Rename"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'btnEditFile
        '
        Me.btnEditFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditFile.Location = New System.Drawing.Point(472, 19)
        Me.btnEditFile.Name = "btnEditFile"
        Me.btnEditFile.Size = New System.Drawing.Size(80, 23)
        Me.btnEditFile.TabIndex = 1
        Me.btnEditFile.Text = "Open"
        Me.btnEditFile.UseVisualStyleBackColor = True
        '
        'btnRemoveFile
        '
        Me.btnRemoveFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveFile.Location = New System.Drawing.Point(472, 116)
        Me.btnRemoveFile.Name = "btnRemoveFile"
        Me.btnRemoveFile.Size = New System.Drawing.Size(80, 23)
        Me.btnRemoveFile.TabIndex = 4
        Me.btnRemoveFile.Text = "Remove"
        Me.btnRemoveFile.UseVisualStyleBackColor = True
        '
        'btnAddFile
        '
        Me.btnAddFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddFile.Location = New System.Drawing.Point(472, 87)
        Me.btnAddFile.Name = "btnAddFile"
        Me.btnAddFile.Size = New System.Drawing.Size(80, 23)
        Me.btnAddFile.TabIndex = 3
        Me.btnAddFile.Text = "Add"
        Me.btnAddFile.UseVisualStyleBackColor = True
        '
        'lstArchivos
        '
        Me.lstArchivos.AllowDrop = True
        Me.lstArchivos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstArchivos.BackColor = System.Drawing.Color.White
        Me.lstArchivos.ContextMenuStrip = Me.listBoxMenu
        Me.lstArchivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstArchivos.FormattingEnabled = True
        Me.lstArchivos.ItemHeight = 18
        Me.lstArchivos.Location = New System.Drawing.Point(6, 19)
        Me.lstArchivos.Name = "lstArchivos"
        Me.lstArchivos.Size = New System.Drawing.Size(460, 310)
        Me.lstArchivos.TabIndex = 5
        '
        'listBoxMenu
        '
        Me.listBoxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.RenameToolStripMenuItem, Me.ToolStripMenuItem1, Me.RemoveToolStripMenuItem, Me.ViewInExplorerToolStripMenuItem})
        Me.listBoxMenu.Name = "listBoxMenu"
        Me.listBoxMenu.Size = New System.Drawing.Size(159, 98)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(155, 6)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'ViewInExplorerToolStripMenuItem
        '
        Me.ViewInExplorerToolStripMenuItem.Name = "ViewInExplorerToolStripMenuItem"
        Me.ViewInExplorerToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ViewInExplorerToolStripMenuItem.Text = "View in explorer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(18, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Version: 0.0.0.0"
        '
        'Timer_AutoLock
        '
        Me.Timer_AutoLock.Interval = 1000
        '
        'Timer_Inactividad
        '
        Me.Timer_Inactividad.Interval = 1000
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label3.Location = New System.Drawing.Point(522, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(204, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Cierra siempre presionando el boton (X) /\"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.LightGray
        Me.Label4.Location = New System.Drawing.Point(531, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(191, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Protegiendo: 00 Archivos"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(525, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(197, 10)
        Me.Panel1.TabIndex = 11
        Me.Panel1.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(5, 387)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(701, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(196, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 0)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Protegiendo archivos..."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 437)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(530, 365)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wor: FileShield"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.listBoxMenu.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lstArchivos As ListBox
    Friend WithEvents btnEditFile As Button
    Friend WithEvents btnRemoveFile As Button
    Friend WithEvents btnAddFile As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Button3 As Button
    Friend WithEvents Timer_AutoLock As Timer
    Friend WithEvents Timer_Inactividad As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents listBoxMenu As ContextMenuStrip
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RenameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewInExplorerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label6 As Label
End Class
