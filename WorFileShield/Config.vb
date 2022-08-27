Public Class Config
    Dim SavedButtonClicked As Boolean = False

    Private Sub Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Debugger.Origin = Environment.UserName Then
            'Label13.Visible = True
            'CheckBox7.Visible = True
            CheckBox8.Visible = True
        End If
        If Debugger.IdiomaAPP = "Spanish" Then
            Idioma.Español.LANG_Español()
        ElseIf Debugger.IdiomaAPP = "English" Then
            Idioma.Ingles.LANG_English()
        End If
        Try
            If Debugger.ThemeMode = "Default" Then
                CheckBox6.CheckState = CheckState.Unchecked
            Else
                CheckBox6.CheckState = CheckState.Checked
            End If
            Try
                NumericUpDown1.Value = Val(Debugger.AutoLockTypeONE_Hour)
                NumericUpDown2.Value = Val(Debugger.AutoLockTypeONE_Minute)
                NumericUpDown3.Value = Val(Debugger.AutoLockTypeONE_Second)
                NumericUpDown4.Value = Val(Debugger.StartLimit)
                NumericUpDown5.Value = Val(Debugger.AutoLockTypeTWO_Second)
                NumericUpDown6.Value = Val(Debugger.MaxTrys)
            Catch ex As Exception
                Console.WriteLine("LA VIDA ES UNA PORONGA: " & ex.Message)
            End Try
            If Debugger.OnlyMe = "True" Then
                CheckBox3.CheckState = CheckState.Checked
            ElseIf Debugger.OnlyMe = "False" Then
                CheckBox3.CheckState = CheckState.Unchecked
            End If
            If Debugger.DeleteAtMaxTrys = "False" Then
                CheckBox1.CheckState = CheckState.Unchecked
            ElseIf Debugger.DeleteAtMaxTrys = "True" Then
                CheckBox1.CheckState = CheckState.Checked
                RadioButton1.Enabled = True
                RadioButton2.Enabled = True
                If Debugger.AutoLockType = "ONE" Then
                    RadioButton1.Checked = True
                    RadioButton2.Checked = False
                ElseIf Debugger.AutoLockType = "TWO" Then
                    RadioButton2.Checked = True
                    RadioButton1.Checked = False
                End If
                NumericUpDown1.Enabled = True
                NumericUpDown2.Enabled = True
                NumericUpDown3.Enabled = True
                NumericUpDown5.Enabled = True
            End If
            If Debugger.LockAtStartLimit = "True" Then
                CheckBox4.CheckState = CheckState.Checked
            ElseIf Debugger.LockAtStartLimit = "False" Then
                CheckBox4.CheckState = CheckState.Unchecked
            End If
            If Debugger.AutoLockStatus = "False" Then
                CheckBox2.CheckState = CheckState.Unchecked
                RadioButton1.Enabled = False
                RadioButton2.Enabled = False
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                NumericUpDown1.Enabled = False
                NumericUpDown2.Enabled = False
                NumericUpDown3.Enabled = False
                NumericUpDown5.Enabled = False
            ElseIf Debugger.AutoLockStatus = "True" Then
                CheckBox2.CheckState = CheckState.Checked
            End If
            If Debugger.AccessKey.StartsWith("Disabled") Then
                CheckBox5.CheckState = CheckState.Unchecked
                RadioButton3.Enabled = False
                RadioButton4.Enabled = False
                Button2.Enabled = False
            ElseIf Debugger.AccessKey.Contains("Start") Then
                CheckBox5.CheckState = CheckState.Checked
                RadioButton3.Enabled = True
                RadioButton4.Enabled = True
                RadioButton3.Checked = True
                Button2.Enabled = True
            ElseIf Debugger.AccessKey.Contains("Jump") Then
                CheckBox5.CheckState = CheckState.Checked
                RadioButton3.Enabled = True
                RadioButton4.Enabled = True
                RadioButton4.Checked = True
                Button2.Enabled = True
            ElseIf Debugger.AccessKey.StartsWith("Enabled") Then
                CheckBox5.CheckState = CheckState.Checked
                RadioButton3.Enabled = True
                RadioButton4.Enabled = True
                RadioButton3.Checked = True
                Button2.Enabled = True
            End If
            If Debugger.AutoLockType = "ONE" Then
                RadioButton1.Checked = True
                RadioButton2.Checked = False
            ElseIf Debugger.AutoLockType = "TWO" Then
                RadioButton2.Checked = True
                RadioButton1.Checked = False
            End If
            If Debugger.SaveLogs = "True" Then
                CheckBox7.CheckState = CheckState.Checked
            ElseIf Debugger.SaveLogs = "False" Then
                CheckBox7.CheckState = CheckState.Unchecked
            End If
            If Debugger.ShareMode = "True" Then
                CheckBox8.CheckState = CheckState.Checked
            ElseIf Debugger.ShareMode = "False" Then
                CheckBox8.CheckState = CheckState.Unchecked
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = CheckState.Checked Then
            RadioButton1.Enabled = True
            RadioButton2.Enabled = True
            If Debugger.AutoLockType = "ONE" Then
                RadioButton1.Checked = True
                RadioButton2.Checked = False
            ElseIf Debugger.AutoLockType = "TWO" Then
                RadioButton2.Checked = True
                RadioButton1.Checked = False
            End If
            NumericUpDown1.Enabled = True
            NumericUpDown2.Enabled = True
            NumericUpDown3.Enabled = True
            NumericUpDown5.Enabled = True
            Debugger.SaveDataBase()
        ElseIf CheckBox2.CheckState = CheckState.Unchecked Then
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            NumericUpDown1.Enabled = False
            NumericUpDown2.Enabled = False
            NumericUpDown3.Enabled = False
            NumericUpDown5.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            SavedButtonClicked = True
            Debugger.AutoLockTypeONE_Hour = NumericUpDown1.Value
            Debugger.AutoLockTypeONE_Minute = NumericUpDown2.Value
            Debugger.AutoLockTypeONE_Second = NumericUpDown3.Value
            Debugger.StartLimit = NumericUpDown4.Value
            Debugger.AutoLockTypeTWO_Second = NumericUpDown5.Value
            Debugger.MaxTrys = NumericUpDown6.Value
            If CheckBox1.CheckState = CheckState.Unchecked Then
                Debugger.DeleteAtMaxTrys = "False"
            ElseIf CheckBox1.CheckState = CheckState.Checked Then
                Debugger.DeleteAtMaxTrys = "True"
            End If
            If CheckBox4.CheckState = CheckState.Unchecked Then
                Debugger.LockAtStartLimit = "False"
            ElseIf CheckBox4.CheckState = CheckState.Checked Then
                Debugger.LockAtStartLimit = "True"
            End If
            If CheckBox2.CheckState = CheckState.Unchecked Then
                Debugger.AutoLockStatus = "False"
                Main.Timer_AutoLock.Enabled = False
                Main.Timer_Inactividad.Enabled = False
            ElseIf CheckBox2.CheckState = CheckState.Checked Then
                Debugger.AutoLockStatus = "True"
                If RadioButton1.Checked = True Then
                    Debugger.AutoLockType = "ONE"
                    Main.Timer_AutoLock.Enabled = True
                    Main.Timer_Inactividad.Enabled = False
                    RadioButton2.Checked = False
                ElseIf RadioButton2.Checked = True Then
                    Debugger.AutoLockType = "TWO"
                    Main.Timer_Inactividad.Enabled = True
                    Main.Timer_AutoLock.Enabled = False
                    RadioButton1.Checked = True
                End If
            End If
            If CheckBox5.CheckState = CheckState.Unchecked Then
                Debugger.AccessKey = "Disabled/Start/None"
            End If
            Debugger.SaveDataBase()
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.CheckState = CheckState.Checked Then
            Debugger.OnlyMe = "True"
        ElseIf CheckBox3.CheckState = CheckState.Unchecked Then
            Debugger.OnlyMe = "False"
        End If
        Debugger.SaveDataBase()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        If Debugger.IdiomaAPP = "Spanish" Then
            MsgBox("Evita que se haga un ataque de contraseñas al Login" & vbCrLf & "Al llegar al maximo de intentos FileShield se cerrara, tambien puedes hacer que se eliminen todos los datos", MsgBoxStyle.Information, "Worcome Security")
        ElseIf Debugger.IdiomaAPP = "English" Then
            MsgBox("Prevents a password attack on Login" & vbCrLf & "When maximum attempts are made FileShield will close, you can also have all data deleted", MsgBoxStyle.Information, "Worcome Security")
        End If
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        If Debugger.IdiomaAPP = "Spanish" Then
            MsgBox("Limita la cantidad de veces que se inicia el programa" & vbCrLf & "Si FileShield se inicia mas de " & NumericUpDown4.Value & " este se bloqueara y no iniciara hasta toparse con el PC de origen." & vbCrLf & vbCrLf & "Inicios contados: " & Debugger.StartLimitStats, MsgBoxStyle.Information, "Worcome Security")
        ElseIf Debugger.IdiomaAPP = "English" Then
            MsgBox("Limit the number of times the program starts" & vbCrLf & "If FileShield starts more than " & NumericUpDown4.Value & " it crashes and does not start until it encounters the source PC." & vbCrLf & vbCrLf & "Beginnings counted: " & Debugger.StartLimitStats, MsgBoxStyle.Information, "Worcome Security")
        End If
    End Sub

    Dim DeleteAtMaxTrys As String = Nothing
    Dim LockAtStartLimit As String = Nothing
    Dim AutoLockStatus As String = Nothing
    Dim AutoLockType As String = Nothing
    Dim OnlyMe As String = Nothing
    Dim AutoLockTypeONE As String = Nothing
    Dim AutoLockTypeTWO As String = Nothing

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RefreshDataBase()
    End Sub

    Sub RefreshDataBase()
        Try
            If CheckBox1.CheckState = CheckState.Unchecked Then
                DeleteAtMaxTrys = "False"
            ElseIf CheckBox1.CheckState = CheckState.Checked Then
                DeleteAtMaxTrys = "True"
            End If
            If CheckBox4.CheckState = CheckState.Unchecked Then
                LockAtStartLimit = "False"
            ElseIf CheckBox4.CheckState = CheckState.Checked Then
                LockAtStartLimit = "True"
            End If
            If CheckBox2.CheckState = CheckState.Unchecked Then
                AutoLockStatus = "False"
            ElseIf CheckBox2.CheckState = CheckState.Checked Then
                AutoLockStatus = "True"
            End If
            If RadioButton1.Checked = True Then
                AutoLockType = "ONE"
                AutoLockTypeONE = "True"
                AutoLockTypeTWO = "False"
            ElseIf RadioButton2.Checked = True Then
                AutoLockType = "TWO"
                AutoLockTypeTWO = "True"
                AutoLockTypeONE = "False"
            End If
            If CheckBox3.CheckState = CheckState.Checked Then
                OnlyMe = "True"
            ElseIf CheckBox3.CheckState = CheckState.Unchecked Then
                OnlyMe = "False"
            End If
            If My.Computer.FileSystem.FileExists(Main.DIRFiles & "\FS_DB.ini") = True Then
                My.Computer.FileSystem.DeleteFile(Main.DIRFiles & "\FS_DB.ini")
            End If
            My.Computer.FileSystem.WriteAllText(Main.DIRFiles & "\FS_DB.ini", Main.Encriptar("#Worcome FileShield Login DataBase" &
                                                vbCrLf & "UserName>" & Debugger.UserName &
                                                vbCrLf & "Password>" & Debugger.Password &
                                                vbCrLf & "CryptoKey>" & Debugger.CryptoKey &
                                                vbCrLf & "Version>" & My.Application.Info.Version.ToString &
                                                vbCrLf & "Origin>" & Environment.UserName &
                                                vbCrLf & "OnlyMe>" & OnlyMe &
                                                vbCrLf & "MaxTrys>" & Val(NumericUpDown6.Value) &
                                                vbCrLf & "DeleteAtMaxTrys>" & DeleteAtMaxTrys &
                                                vbCrLf & "StartLimit>" & Val(NumericUpDown4.Value) &
                                                vbCrLf & "StartLimitCounter>" & Debugger.StartLimitCounter &
                                                vbCrLf & "LockAtStartLimit>" & LockAtStartLimit &
                                                vbCrLf & "AutoLockStatus>" & AutoLockStatus &
                                                vbCrLf & "AutoLockType>" & AutoLockType &
                                                vbCrLf & "AutoLockTypeONE>" & AutoLockTypeONE &
                                                vbCrLf & "AutoLockTypeONE_Hour>" & Val(NumericUpDown1.Value) &
                                                vbCrLf & "AutoLockTypeONE_Minute>" & Val(NumericUpDown2.Value) &
                                                vbCrLf & "AutoLockTypeONE_Second>" & Val(NumericUpDown3.Value) &
                                                vbCrLf & "AutoLockTypeTWO>" & AutoLockTypeTWO &
                                                vbCrLf & "AutoLockTypeTWO_Second>" & Val(NumericUpDown5.Value) &
                                                vbCrLf & "AccessKey>" & "Disabled/Start/None" &
                                                vbCrLf & "ThemeMode>" & "Default" &
                                                vbCrLf & "SaveLogs>" & Debugger.SaveLogs &
                                                vbCrLf & "ShareMode>" & Debugger.ShareMode), False)
            CheckBox5.CheckState = CheckState.Unchecked
            RadioButton3.Checked = True
            Debugger.LoadDataBase()
            If Debugger.IdiomaAPP = "Spanish" Then
                MsgBox("La base de datos fue actualizada.", MsgBoxStyle.Information, "Worcome Security")
            ElseIf Debugger.IdiomaAPP = "English" Then
                MsgBox("The database was updated.", MsgBoxStyle.Information, "Worcome Security")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If RadioButton3.Checked = True Then
                Debugger.AccessKey = "Enabled/Start/" & Debugger.CryptoKey
            ElseIf RadioButton4.Checked = True Then
                Debugger.AccessKey = "Enabled/Jump/" & Debugger.CryptoKey
            End If
            Dim WSHShell As Object = CreateObject("WScript.Shell")
            Dim Shortcut As Object = WSHShell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\[" & Environment.UserName & "_AccessKey]FileShield.lnk")
            Shortcut.IconLocation = Application.ExecutablePath
            Shortcut.TargetPath = Application.ExecutablePath
            Shortcut.Arguments = Main.Encriptar(Debugger.AccessKey)
            Shortcut.WindowStyle = 1
            If Debugger.IdiomaAPP = "Spanish" Then
                Shortcut.Description = "Llave de Acceso para FileShield de " & Environment.UserName
            ElseIf Debugger.IdiomaAPP = "English" Then
                Shortcut.Description = "Access key for FileShield of " & Environment.UserName
            End If
            Shortcut.Save()
            Debugger.SaveDataBase()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.CheckState = CheckState.Checked Then
            Debugger.ThemeModeAP("Dark")
            Debugger.ThemeMode = "Dark"
        Else
            Debugger.ThemeModeAP("Default")
            Debugger.ThemeMode = "Default"
        End If
        Debugger.SaveDataBase()
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.CheckState = CheckState.Checked Then
            Debugger.SaveLogs = "True"
        Else
            Debugger.SaveLogs = "False"
        End If
        Debugger.SaveDataBase()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Loggs.Show()
        Loggs.Focus()
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Process.Start("http://worcomestudios.comule.com/")
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.CheckState = CheckState.Checked Then
            Debugger.ShareMode = "True"
        ElseIf CheckBox8.CheckState = CheckState.Unchecked Then
            Debugger.ShareMode = "False"
        End If
        Debugger.SaveDataBase()
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.CheckState = CheckState.Checked Then
            RadioButton3.Enabled = True
            RadioButton4.Enabled = True
            RadioButton3.Checked = True
            Button2.Enabled = True
        Else
            RadioButton3.Enabled = False
            RadioButton4.Enabled = False
            Button2.Enabled = False
        End If
    End Sub

    Private Sub Config_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If SavedButtonClicked = False Then
            If Debugger.IdiomaAPP = "Spanish" Then
                If MessageBox.Show("¿Desea salir de Configuraciones?" & vbCrLf & "Podrían haber cambios sin guardar!", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Else
                    e.Cancel = True
                End If
            ElseIf Debugger.IdiomaAPP = "English" Then
                If MessageBox.Show("Do you want to exit Settings?" & vbCrLf & "There could be unsaved changes!", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub Config_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Me.HelpRequested
        MsgBox("Wor: FileShield " & My.Application.Info.Version.ToString & vbCrLf & vbCrLf & "Creado por Worcome Studios." & vbCrLf & "Compilado el 30/07/2020" & vbCrLf & vbCrLf & "Para mas informacion visite http://WorcomeStudios.comule.com/", MsgBoxStyle.Information, "Worcome Security")
    End Sub
End Class