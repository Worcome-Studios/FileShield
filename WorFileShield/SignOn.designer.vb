<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignOn
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
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.tbUser = New System.Windows.Forms.TextBox()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.btnSignOn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(207, 38)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Iniciar sesion"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(127, 96)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(129, 17)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Nombre de usuario"
        '
        'tbUser
        '
        Me.tbUser.Location = New System.Drawing.Point(44, 120)
        Me.tbUser.Name = "tbUser"
        Me.tbUser.Size = New System.Drawing.Size(295, 22)
        Me.tbUser.TabIndex = 0
        Me.tbUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(44, 193)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.tbPassword.Size = New System.Drawing.Size(295, 22)
        Me.tbPassword.TabIndex = 1
        Me.tbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(151, 169)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(81, 17)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "Contraseña"
        '
        'btnSignOn
        '
        Me.btnSignOn.Location = New System.Drawing.Point(118, 256)
        Me.btnSignOn.Name = "btnSignOn"
        Me.btnSignOn.Size = New System.Drawing.Size(147, 40)
        Me.btnSignOn.TabIndex = 2
        Me.btnSignOn.Text = "Iniciar sesion"
        Me.btnSignOn.UseVisualStyleBackColor = True
        '
        'SignOn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 308)
        Me.Controls.Add(Me.btnSignOn)
        Me.Controls.Add(Me.tbPassword)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.tbUser)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SignOn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wor FileShield"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents tbUser As TextBox
    Friend WithEvents tbPassword As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents btnSignOn As Button
End Class
