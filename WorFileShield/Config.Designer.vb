<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Config
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnApplyAndSave = New System.Windows.Forms.Button()
        Me.Chb_General_NetworkMode = New System.Windows.Forms.CheckBox()
        Me.Chb_General_ShareMode = New System.Windows.Forms.CheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Chb_LogIn_AllowMaxTrys = New System.Windows.Forms.CheckBox()
        Me.Chb_LogIn_LockAtMaxStarts = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Chb_LogIn_LimitStarts = New System.Windows.Forms.CheckBox()
        Me.Nud_LogIn_Trys = New System.Windows.Forms.NumericUpDown()
        Me.Nud_LogIn_Starts = New System.Windows.Forms.NumericUpDown()
        Me.Chb_LogIn_DeleteAtMaxTrys = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Rb_KeyAccess_StartFSAndJumpSignON = New System.Windows.Forms.RadioButton()
        Me.Rb_KeyAccess_StartFS = New System.Windows.Forms.RadioButton()
        Me.Chb_KeyAccess_AllowAccessKeys = New System.Windows.Forms.CheckBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Nud_Lock_AfkSS = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Nud_Lock_SS = New System.Windows.Forms.NumericUpDown()
        Me.Nud_Lock_MM = New System.Windows.Forms.NumericUpDown()
        Me.Nud_Lock_HH = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Rb_Lock_WithAfk = New System.Windows.Forms.RadioButton()
        Me.Rb_Lock_WithTime = New System.Windows.Forms.RadioButton()
        Me.Chb_Lock_AllowAutoLock = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Nud_LogIn_Trys, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_LogIn_Starts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Nud_Lock_AfkSS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_Lock_SS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_Lock_MM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_Lock_HH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(562, 344)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(554, 318)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BtnApplyAndSave)
        Me.GroupBox4.Controls.Add(Me.Chb_General_NetworkMode)
        Me.GroupBox4.Controls.Add(Me.Chb_General_ShareMode)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(542, 306)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'BtnApplyAndSave
        '
        Me.BtnApplyAndSave.Location = New System.Drawing.Point(407, 248)
        Me.BtnApplyAndSave.Name = "BtnApplyAndSave"
        Me.BtnApplyAndSave.Size = New System.Drawing.Size(129, 52)
        Me.BtnApplyAndSave.TabIndex = 2
        Me.BtnApplyAndSave.Text = "Aplicar y Guardar"
        Me.BtnApplyAndSave.UseVisualStyleBackColor = True
        '
        'Chb_General_NetworkMode
        '
        Me.Chb_General_NetworkMode.AutoSize = True
        Me.Chb_General_NetworkMode.Location = New System.Drawing.Point(6, 283)
        Me.Chb_General_NetworkMode.Name = "Chb_General_NetworkMode"
        Me.Chb_General_NetworkMode.Size = New System.Drawing.Size(135, 17)
        Me.Chb_General_NetworkMode.TabIndex = 1
        Me.Chb_General_NetworkMode.Text = "Modo ubicacion de red"
        Me.Chb_General_NetworkMode.UseVisualStyleBackColor = True
        '
        'Chb_General_ShareMode
        '
        Me.Chb_General_ShareMode.AutoSize = True
        Me.Chb_General_ShareMode.Location = New System.Drawing.Point(6, 260)
        Me.Chb_General_ShareMode.Name = "Chb_General_ShareMode"
        Me.Chb_General_ShareMode.Size = New System.Drawing.Size(99, 17)
        Me.Chb_General_ShareMode.TabIndex = 0
        Me.Chb_General_ShareMode.Text = "Modo compartir"
        Me.Chb_General_ShareMode.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(554, 318)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Inicio de sesion"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Chb_LogIn_AllowMaxTrys)
        Me.GroupBox1.Controls.Add(Me.Chb_LogIn_LockAtMaxStarts)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Chb_LogIn_LimitStarts)
        Me.GroupBox1.Controls.Add(Me.Nud_LogIn_Trys)
        Me.GroupBox1.Controls.Add(Me.Nud_LogIn_Starts)
        Me.GroupBox1.Controls.Add(Me.Chb_LogIn_DeleteAtMaxTrys)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(265, 162)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Chb_LogIn_AllowMaxTrys
        '
        Me.Chb_LogIn_AllowMaxTrys.AutoSize = True
        Me.Chb_LogIn_AllowMaxTrys.Location = New System.Drawing.Point(6, 19)
        Me.Chb_LogIn_AllowMaxTrys.Name = "Chb_LogIn_AllowMaxTrys"
        Me.Chb_LogIn_AllowMaxTrys.Size = New System.Drawing.Size(107, 17)
        Me.Chb_LogIn_AllowMaxTrys.TabIndex = 2
        Me.Chb_LogIn_AllowMaxTrys.Text = "Intentos maximos"
        Me.Chb_LogIn_AllowMaxTrys.UseVisualStyleBackColor = True
        '
        'Chb_LogIn_LockAtMaxStarts
        '
        Me.Chb_LogIn_LockAtMaxStarts.AutoSize = True
        Me.Chb_LogIn_LockAtMaxStarts.Location = New System.Drawing.Point(25, 139)
        Me.Chb_LogIn_LockAtMaxStarts.Name = "Chb_LogIn_LockAtMaxStarts"
        Me.Chb_LogIn_LockAtMaxStarts.Size = New System.Drawing.Size(156, 17)
        Me.Chb_LogIn_LockAtMaxStarts.TabIndex = 7
        Me.Chb_LogIn_LockAtMaxStarts.Text = "Bloquear al llegar al maximo"
        Me.Chb_LogIn_LockAtMaxStarts.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Intentos: "
        '
        'Chb_LogIn_LimitStarts
        '
        Me.Chb_LogIn_LimitStarts.AutoSize = True
        Me.Chb_LogIn_LimitStarts.Location = New System.Drawing.Point(6, 95)
        Me.Chb_LogIn_LimitStarts.Name = "Chb_LogIn_LimitStarts"
        Me.Chb_LogIn_LimitStarts.Size = New System.Drawing.Size(88, 17)
        Me.Chb_LogIn_LimitStarts.TabIndex = 6
        Me.Chb_LogIn_LimitStarts.Text = "Limitar inicios"
        Me.Chb_LogIn_LimitStarts.UseVisualStyleBackColor = True
        '
        'Nud_LogIn_Trys
        '
        Me.Nud_LogIn_Trys.Location = New System.Drawing.Point(79, 37)
        Me.Nud_LogIn_Trys.Name = "Nud_LogIn_Trys"
        Me.Nud_LogIn_Trys.Size = New System.Drawing.Size(40, 20)
        Me.Nud_LogIn_Trys.TabIndex = 1
        Me.Nud_LogIn_Trys.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Nud_LogIn_Starts
        '
        Me.Nud_LogIn_Starts.Location = New System.Drawing.Point(79, 113)
        Me.Nud_LogIn_Starts.Name = "Nud_LogIn_Starts"
        Me.Nud_LogIn_Starts.Size = New System.Drawing.Size(40, 20)
        Me.Nud_LogIn_Starts.TabIndex = 10
        Me.Nud_LogIn_Starts.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Chb_LogIn_DeleteAtMaxTrys
        '
        Me.Chb_LogIn_DeleteAtMaxTrys.AutoSize = True
        Me.Chb_LogIn_DeleteAtMaxTrys.Location = New System.Drawing.Point(25, 63)
        Me.Chb_LogIn_DeleteAtMaxTrys.Name = "Chb_LogIn_DeleteAtMaxTrys"
        Me.Chb_LogIn_DeleteAtMaxTrys.Size = New System.Drawing.Size(189, 17)
        Me.Chb_LogIn_DeleteAtMaxTrys.TabIndex = 3
        Me.Chb_LogIn_DeleteAtMaxTrys.Text = "Eliminar todo al alcanzar el maximo"
        Me.Chb_LogIn_DeleteAtMaxTrys.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Inicios: "
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(554, 318)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "Llaves de acceso"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Rb_KeyAccess_StartFSAndJumpSignON)
        Me.GroupBox2.Controls.Add(Me.Rb_KeyAccess_StartFS)
        Me.GroupBox2.Controls.Add(Me.Chb_KeyAccess_AllowAccessKeys)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(265, 162)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(85, 102)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 33)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Crear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Rb_KeyAccess_StartFSAndJumpSignON
        '
        Me.Rb_KeyAccess_StartFSAndJumpSignON.AutoSize = True
        Me.Rb_KeyAccess_StartFSAndJumpSignON.Enabled = False
        Me.Rb_KeyAccess_StartFSAndJumpSignON.Location = New System.Drawing.Point(25, 65)
        Me.Rb_KeyAccess_StartFSAndJumpSignON.Name = "Rb_KeyAccess_StartFSAndJumpSignON"
        Me.Rb_KeyAccess_StartFSAndJumpSignON.Size = New System.Drawing.Size(177, 17)
        Me.Rb_KeyAccess_StartFSAndJumpSignON.TabIndex = 2
        Me.Rb_KeyAccess_StartFSAndJumpSignON.TabStop = True
        Me.Rb_KeyAccess_StartFSAndJumpSignON.Text = "Iniciar FileShield y saltar SignON" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Rb_KeyAccess_StartFSAndJumpSignON.UseVisualStyleBackColor = True
        '
        'Rb_KeyAccess_StartFS
        '
        Me.Rb_KeyAccess_StartFS.AutoSize = True
        Me.Rb_KeyAccess_StartFS.Enabled = False
        Me.Rb_KeyAccess_StartFS.Location = New System.Drawing.Point(25, 42)
        Me.Rb_KeyAccess_StartFS.Name = "Rb_KeyAccess_StartFS"
        Me.Rb_KeyAccess_StartFS.Size = New System.Drawing.Size(101, 17)
        Me.Rb_KeyAccess_StartFS.TabIndex = 1
        Me.Rb_KeyAccess_StartFS.TabStop = True
        Me.Rb_KeyAccess_StartFS.Text = "Iniciar FileShield"
        Me.Rb_KeyAccess_StartFS.UseVisualStyleBackColor = True
        '
        'Chb_KeyAccess_AllowAccessKeys
        '
        Me.Chb_KeyAccess_AllowAccessKeys.AutoSize = True
        Me.Chb_KeyAccess_AllowAccessKeys.Location = New System.Drawing.Point(6, 19)
        Me.Chb_KeyAccess_AllowAccessKeys.Name = "Chb_KeyAccess_AllowAccessKeys"
        Me.Chb_KeyAccess_AllowAccessKeys.Size = New System.Drawing.Size(143, 17)
        Me.Chb_KeyAccess_AllowAccessKeys.TabIndex = 0
        Me.Chb_KeyAccess_AllowAccessKeys.Text = "Permitir llaves de acceso"
        Me.Chb_KeyAccess_AllowAccessKeys.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(554, 318)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Bloqueo"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Nud_Lock_AfkSS)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Nud_Lock_SS)
        Me.GroupBox3.Controls.Add(Me.Nud_Lock_MM)
        Me.GroupBox3.Controls.Add(Me.Nud_Lock_HH)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Rb_Lock_WithAfk)
        Me.GroupBox3.Controls.Add(Me.Rb_Lock_WithTime)
        Me.GroupBox3.Controls.Add(Me.Chb_Lock_AllowAutoLock)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(401, 309)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'Nud_Lock_AfkSS
        '
        Me.Nud_Lock_AfkSS.Enabled = False
        Me.Nud_Lock_AfkSS.Location = New System.Drawing.Point(131, 164)
        Me.Nud_Lock_AfkSS.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.Nud_Lock_AfkSS.Name = "Nud_Lock_AfkSS"
        Me.Nud_Lock_AfkSS.Size = New System.Drawing.Size(46, 20)
        Me.Nud_Lock_AfkSS.TabIndex = 10
        Me.Nud_Lock_AfkSS.Value = New Decimal(New Integer() {120, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(46, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(191, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Si esta inactivo:                    segundos."
        '
        'Label4
        '
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(49, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(171, 22)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "0:0:0"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Nud_Lock_SS
        '
        Me.Nud_Lock_SS.Enabled = False
        Me.Nud_Lock_SS.Location = New System.Drawing.Point(167, 78)
        Me.Nud_Lock_SS.Name = "Nud_Lock_SS"
        Me.Nud_Lock_SS.Size = New System.Drawing.Size(53, 20)
        Me.Nud_Lock_SS.TabIndex = 7
        '
        'Nud_Lock_MM
        '
        Me.Nud_Lock_MM.Enabled = False
        Me.Nud_Lock_MM.Location = New System.Drawing.Point(108, 78)
        Me.Nud_Lock_MM.Name = "Nud_Lock_MM"
        Me.Nud_Lock_MM.Size = New System.Drawing.Size(53, 20)
        Me.Nud_Lock_MM.TabIndex = 6
        Me.Nud_Lock_MM.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Nud_Lock_HH
        '
        Me.Nud_Lock_HH.Enabled = False
        Me.Nud_Lock_HH.Location = New System.Drawing.Point(49, 78)
        Me.Nud_Lock_HH.Name = "Nud_Lock_HH"
        Me.Nud_Lock_HH.Size = New System.Drawing.Size(53, 20)
        Me.Nud_Lock_HH.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(46, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "HH               MM             SS"
        '
        'Rb_Lock_WithAfk
        '
        Me.Rb_Lock_WithAfk.AutoSize = True
        Me.Rb_Lock_WithAfk.Enabled = False
        Me.Rb_Lock_WithAfk.Location = New System.Drawing.Point(25, 146)
        Me.Rb_Lock_WithAfk.Name = "Rb_Lock_WithAfk"
        Me.Rb_Lock_WithAfk.Size = New System.Drawing.Size(98, 17)
        Me.Rb_Lock_WithAfk.TabIndex = 3
        Me.Rb_Lock_WithAfk.Text = "Con inactividad"
        Me.Rb_Lock_WithAfk.UseVisualStyleBackColor = True
        '
        'Rb_Lock_WithTime
        '
        Me.Rb_Lock_WithTime.AutoSize = True
        Me.Rb_Lock_WithTime.Checked = True
        Me.Rb_Lock_WithTime.Enabled = False
        Me.Rb_Lock_WithTime.Location = New System.Drawing.Point(25, 42)
        Me.Rb_Lock_WithTime.Name = "Rb_Lock_WithTime"
        Me.Rb_Lock_WithTime.Size = New System.Drawing.Size(107, 17)
        Me.Rb_Lock_WithTime.TabIndex = 2
        Me.Rb_Lock_WithTime.TabStop = True
        Me.Rb_Lock_WithTime.Text = "Con temporizador"
        Me.Rb_Lock_WithTime.UseVisualStyleBackColor = True
        '
        'Chb_Lock_AllowAutoLock
        '
        Me.Chb_Lock_AllowAutoLock.AutoSize = True
        Me.Chb_Lock_AllowAutoLock.Location = New System.Drawing.Point(6, 19)
        Me.Chb_Lock_AllowAutoLock.Name = "Chb_Lock_AllowAutoLock"
        Me.Chb_Lock_AllowAutoLock.Size = New System.Drawing.Size(155, 17)
        Me.Chb_Lock_AllowAutoLock.TabIndex = 1
        Me.Chb_Lock_AllowAutoLock.Text = "Activar bloqueo automatico"
        Me.Chb_Lock_AllowAutoLock.UseVisualStyleBackColor = True
        '
        'Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 368)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "Config"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FileShield Configuration"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Nud_LogIn_Trys, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_LogIn_Starts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Nud_Lock_AfkSS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_Lock_SS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_Lock_MM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_Lock_HH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Chb_LogIn_AllowMaxTrys As CheckBox
    Friend WithEvents Nud_LogIn_Trys As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Chb_LogIn_DeleteAtMaxTrys As CheckBox
    Friend WithEvents Chb_LogIn_LockAtMaxStarts As CheckBox
    Friend WithEvents Chb_LogIn_LimitStarts As CheckBox
    Friend WithEvents Nud_LogIn_Starts As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Chb_KeyAccess_AllowAccessKeys As CheckBox
    Friend WithEvents Rb_KeyAccess_StartFS As RadioButton
    Friend WithEvents Rb_KeyAccess_StartFSAndJumpSignON As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Rb_Lock_WithAfk As RadioButton
    Friend WithEvents Rb_Lock_WithTime As RadioButton
    Friend WithEvents Chb_Lock_AllowAutoLock As CheckBox
    Friend WithEvents Nud_Lock_HH As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Nud_Lock_SS As NumericUpDown
    Friend WithEvents Nud_Lock_MM As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Nud_Lock_AfkSS As NumericUpDown
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Chb_General_NetworkMode As CheckBox
    Friend WithEvents Chb_General_ShareMode As CheckBox
    Friend WithEvents BtnApplyAndSave As Button
End Class
