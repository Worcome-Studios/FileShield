Public Class Config
    Public ConfigData As New ArrayList
    Public AccessKeys As String

    Private Sub Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadConfig()
    End Sub

    Private Sub BtnApplyAndSave_Click(sender As Object, e As EventArgs) Handles BtnApplyAndSave.Click
        SaveConfig()
    End Sub

    'Idea de config DB
    '   Para evitar guardar varios lineas en el archivo user.db usar un algoritmo tipo Base64 para generar una
    '   cadena unica que luego sea decodificada dentro del form para ver los valores, y asi aplicarlos.
    '   ready!. Funciona
    '           0 [26/02/2022 11:56 AM CHILE by Urfenox]
    Sub LoadConfig()
        Try
            ConfigData.Clear()
            Dim Config As String() = DecodeBase64(userData(4)).Split("|")
            For Each item As String In Config
                ConfigData.Add(item)
            Next

            If ConfigData.Count = 2 Then
                SaveConfig()
                Exit Sub
            Else
                Chb_General_ShareMode.Checked = ConfigData(0)
                Chb_General_NetworkMode.Checked = ConfigData(1)
                Chb_LogIn_AllowMaxTrys.Checked = ConfigData(2)
                Nud_LogIn_Trys.Value = ConfigData(3)
                Chb_LogIn_DeleteAtMaxTrys.Checked = ConfigData(4)
                Chb_LogIn_LimitStarts.Checked = ConfigData(5)
                Nud_LogIn_Starts.Value = ConfigData(6)
                Chb_LogIn_LockAtMaxStarts.Checked = ConfigData(7)
                AccessKeys = ConfigData(8)
                Chb_KeyAccess_AllowAccessKeys.Checked = ConfigData(9)
                Rb_KeyAccess_StartFS.Checked = ConfigData(10)
                Rb_KeyAccess_StartFSAndJumpSignON.Checked = ConfigData(11)
                Chb_Lock_AllowAutoLock.Checked = ConfigData(12)
                Rb_Lock_WithTime.Checked = ConfigData(13)
                Nud_Lock_HH.Value = ConfigData(14)
                Nud_Lock_MM.Value = ConfigData(15)
                Nud_Lock_SS.Value = ConfigData(16)
                Rb_Lock_WithAfk.Checked = ConfigData(17)
                Nud_Lock_AfkSS.Value = ConfigData(18)
            End If

            'Modo compartir (bloquea las configuraciones)
            If userData(2) <> Environment.UserName Then
                If Boolean.Parse(ConfigData(0)) Then
                    TabControl1.Enabled = False
                End If
            End If

        Catch ex As Exception
            AddToLog("[LoadConfig@Config]Error: ", ex.Message, True)
        End Try
    End Sub
    Sub SaveConfig()
        Try
            Dim Config As String = Nothing

            Config = Chb_General_ShareMode.Checked & "|" &
                Chb_General_NetworkMode.Checked & "|" &
                Chb_LogIn_AllowMaxTrys.Checked & "|" &
                Nud_LogIn_Trys.Value & "|" &
                Chb_LogIn_DeleteAtMaxTrys.Checked & "|" &
                Chb_LogIn_LimitStarts.Checked & "|" &
                Nud_LogIn_Starts.Value & "|" &
                Chb_LogIn_LockAtMaxStarts.Checked & "|" &
                AccessKeys & "|" & 'Guarda las llaves de acceso
                Chb_KeyAccess_AllowAccessKeys.Checked & "|" &
                Rb_KeyAccess_StartFS.Checked & "|" &
                Rb_KeyAccess_StartFSAndJumpSignON.Checked & "|" &
                Chb_Lock_AllowAutoLock.Checked & "|" &
                Rb_Lock_WithTime.Checked & "|" &
                Nud_Lock_HH.Value & "|" &
                Nud_Lock_MM.Value & "|" &
                Nud_Lock_SS.Value & "|" &
                Rb_Lock_WithAfk.Checked & "|" &
                Nud_Lock_AfkSS.Value

            userData(4) = EncodeBase64(Config)

            SaveData()
            LoadConfig()
        Catch ex As Exception
            AddToLog("[SaveConfig@Config]Error: ", ex.Message, True)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim keyUserTo = InputBox("Ingrese el nombre de usuario para vincular la llave", "Llave de Acceso", Environment.UserName)
        If keyUserTo <> Nothing Then
            Dim AccessKey As String = keyUserTo & ";" & DateTime.Now.ToString() & ";" & Rb_KeyAccess_StartFS.Checked & ";" & Rb_KeyAccess_StartFSAndJumpSignON.Checked
            Dim LnkFilePath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & keyUserTo & "_FileShield_Key.lnk"
            If My.Computer.FileSystem.FileExists(LnkFilePath) Then
                My.Computer.FileSystem.DeleteFile(LnkFilePath)
            End If
            Dim WSHShell As Object = CreateObject("WScript.Shell")
            Dim Shortcut As Object
            Shortcut = WSHShell.CreateShortcut(LnkFilePath)
            Shortcut.IconLocation = Application.ExecutablePath & ",0"
            Shortcut.TargetPath = Application.ExecutablePath
            If Not Rb_KeyAccess_StartFS.Checked Then
                Shortcut.Arguments = "KEY=" & EncodeBase64(AccessKey)
                Shortcut.Description = "Access key for " & keyUserTo
            End If
            Shortcut.WindowStyle = 1
            Shortcut.Save()
            AccessKeys &= AccessKey & "#"
        End If
    End Sub

    Private Sub Chb_KeyAccess_AllowAccessKeys_CheckedChanged(sender As Object, e As EventArgs) Handles Chb_KeyAccess_AllowAccessKeys.CheckedChanged
        Rb_KeyAccess_StartFS.Enabled = Chb_KeyAccess_AllowAccessKeys.Checked
        Rb_KeyAccess_StartFSAndJumpSignON.Enabled = Chb_KeyAccess_AllowAccessKeys.Checked
        Button1.Enabled = Chb_KeyAccess_AllowAccessKeys.Checked
    End Sub

    Private Sub Chb_Lock_AllowAutoLock_CheckedChanged(sender As Object, e As EventArgs) Handles Chb_Lock_AllowAutoLock.CheckedChanged
        Rb_Lock_WithTime.Enabled = Chb_Lock_AllowAutoLock.Checked
        Rb_Lock_WithAfk.Enabled = Chb_Lock_AllowAutoLock.Checked
    End Sub

    Private Sub Rb_Lock_WithTime_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_Lock_WithTime.CheckedChanged
        Label3.Enabled = Rb_Lock_WithTime.Checked
        Nud_Lock_HH.Enabled = Rb_Lock_WithTime.Checked
        Nud_Lock_MM.Enabled = Rb_Lock_WithTime.Checked
        Nud_Lock_SS.Enabled = Rb_Lock_WithTime.Checked
        Label4.Enabled = Rb_Lock_WithTime.Checked
    End Sub

    Private Sub Rb_Lock_WithAfk_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_Lock_WithAfk.CheckedChanged
        Label5.Enabled = Rb_Lock_WithAfk.Checked
        Nud_Lock_AfkSS.Enabled = Rb_Lock_WithAfk.Checked
    End Sub

    Private Sub Chb_General_ShareMode_CheckedChanged(sender As Object, e As EventArgs) Handles Chb_General_ShareMode.CheckedChanged
        ConfigData(0) = Chb_General_ShareMode.Checked
    End Sub

    Private Sub Chb_General_NetworkMode_CheckedChanged(sender As Object, e As EventArgs) Handles Chb_General_NetworkMode.CheckedChanged
        ConfigData(1) = Chb_General_NetworkMode.Checked
    End Sub
End Class