Public Class Config
    Public ConfigData As New ArrayList

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
            Dim Config As String() = DecodeBase64(userData(3)).Split("|")
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
                Chb_KeyAccess_AllowAccessKeys.Checked = ConfigData(8)
                Rb_KeyAccess_StartFS.Checked = ConfigData(9)
                Rb_KeyAccess_StartFSAndJumpSignON.Checked = ConfigData(10)
                Chb_Lock_AllowAutoLock.Checked = ConfigData(11)
                Rb_Lock_WithTime.Checked = ConfigData(12)
                Nud_Lock_HH.Value = ConfigData(13)
                Nud_Lock_MM.Value = ConfigData(14)
                Nud_Lock_SS.Value = ConfigData(15)
                Rb_Lock_WithAfk.Checked = ConfigData(16)
                Nud_Lock_AfkSS.Value = ConfigData(17)
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

            userData(3) = EncodeBase64(Config)

            SaveData()
            LoadConfig()
        Catch ex As Exception
            AddToLog("[SaveConfig@Config]Error: ", ex.Message, True)
        End Try
    End Sub
End Class