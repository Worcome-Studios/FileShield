Imports System.IO
Public Class Debugger
    Dim ArgumentLine As String
    Public IdiomaAPP As String = "English"
    Public UserName As String = Nothing
    Public Password As String = Nothing
    Public CryptoKey As String = Nothing
    Public Version As String = Nothing
    Public Origin As String = Nothing
    Public OnlyMe As String = Nothing
    Public MaxTrys As String = Nothing
    Public DeleteAtMaxTrys As String = Nothing
    Public StartLimit As String = Nothing
    Public StartLimitCounter As String = Nothing
    Public LockAtStartLimit As String = Nothing
    Public AutoLockStatus As String = Nothing
    Public AutoLockType As String = Nothing
    Public AutoLockTypeONE As String = Nothing
    Public AutoLockTypeONE_Hour As String = Nothing
    Public AutoLockTypeONE_Minute As String = Nothing
    Public AutoLockTypeONE_Second As String = Nothing
    Public AutoLockTypeTWO As String = Nothing
    Public AutoLockTypeTWO_Second As String = Nothing
    Public AccessKey As String = Nothing
    Public ThemeMode As String = Nothing
    Public SaveLogs As String = Nothing
    Public ShareMode As String = Nothing
    Public ReadyRegistered As String = "False"
    Dim ALStatus As String
    Dim ALType As String
    Dim ALKey As String
    Public AlreadyPassAsAccessKey As Boolean = False
    Public ArgsEncounter As Boolean = False
    Public RecoverSession As Boolean = False
    Public LogFileContent As String

    Private Sub Debugger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ArgumentLine = Microsoft.VisualBasic.Command
        If ArgumentLine = Nothing Then
        ElseIf ArgumentLine = "/Stub" Then
            End
        Else
            ArgsEncounter = True
            Dim txtArgumentLine As String = Main.Desencriptar(ArgumentLine)
            Dim CadenatxtArgumentLine As String() = txtArgumentLine.Split("/")
            ALStatus = CadenatxtArgumentLine(0)
            ALType = CadenatxtArgumentLine(1)
            ALKey = CadenatxtArgumentLine(2)
        End If
        Try
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\FileShield\FS.log") = False Then
                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Nothing, False)
            End If
        Catch ex As Exception
        End Try
        If My.Computer.FileSystem.DirectoryExists(Main.DIRFiles) = False Then
            My.Computer.FileSystem.CreateDirectory(Main.DIRFiles)
            Try
                Dim attribute As System.IO.FileAttributes = FileAttributes.Hidden
                File.SetAttributes(Main.DIRFiles, attribute)
            Catch ex As Exception
                Console.WriteLine("[Debugger@Debugger_Load:HiddeFolder]Error: " & ex.Message)
            End Try
        End If
        Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
        If myCurrentLanguage.Culture.EnglishName.Contains("Spanish") Then
            Idioma.Español.LANG_Español()
            IdiomaAPP = "Spanish"
        ElseIf myCurrentLanguage.Culture.EnglishName.Contains("English") Then
            Idioma.Ingles.LANG_English()
            IdiomaAPP = "English"
        Else
            Idioma.Ingles.LANG_English()
            IdiomaAPP = "English"
        End If
        If My.Computer.FileSystem.FileExists(Main.DIRFiles & "\FS_DB.ini") = True Then
            ReadyRegistered = True
            LoadDataBase()
            LoadFileList()
        Else
            ReadyRegistered = False
            Main.CreatePrivateKey()
            My.Computer.FileSystem.WriteAllText(Main.DIRFiles & "\FS_DB.ini", Main.Encriptar("#Worcome FileShield Login DataBase" &
                                                    vbCrLf & "UserName>" & "tmpUser" &
                                                    vbCrLf & "Password>" & "15243" &
                                                    vbCrLf & "CryptoKey>" & CryptoKey &
                                                    vbCrLf & "Version>" & My.Application.Info.Version.ToString &
                                                    vbCrLf & "Origin>" & Environment.UserName &
                                                    vbCrLf & "OnlyMe>" & "False" &
                                                    vbCrLf & "MaxTrys>" & "5" &
                                                    vbCrLf & "DeleteAtMaxTrys>" & "False" &
                                                    vbCrLf & "StartLimit>" & "10" &
                                                    vbCrLf & "StartLimitCounter>" & "0" &
                                                    vbCrLf & "LockAtStartLimit>" & "False" &
                                                    vbCrLf & "AutoLockStatus>" & "False" &
                                                    vbCrLf & "AutoLockType>" & "ONE" &
                                                    vbCrLf & "AutoLockTypeONE>" & "True" &
                                                    vbCrLf & "AutoLockTypeONE_Hour>" & "0" &
                                                    vbCrLf & "AutoLockTypeONE_Minute>" & "10" &
                                                    vbCrLf & "AutoLockTypeONE_Second>" & "25" &
                                                    vbCrLf & "AutoLockTypeTWO>" & "False" &
                                                    vbCrLf & "AutoLockTypeTWO_Second>" & "180" &
                                                    vbCrLf & "AccessKey>" & "Disabled/Start/None" &
                                                    vbCrLf & "ThemeMode>" & "Default" &
                                                    vbCrLf & "SaveLogs>" & "False" &
                                                    vbCrLf & "ShareMode>" & "False"), False)
            Threading.Thread.Sleep(150)
            LoadDataBase()
        End If
        If ArgumentLine = Nothing Then
            CommonStart()
        Else
            ArgsEncounter = True
            CheckArguments()
        End If
    End Sub

    Sub CheckArguments()
        Try
            'If ArgsEncounter = True Then
            Dim txtAccessKey As String = AccessKey
            Dim CadenaAccessKey As String() = txtAccessKey.Split("/")
            Dim Status As String = "Disabled"
            Dim Type As String
            Dim Key As String
            Status = CadenaAccessKey(0) 'Enabled / Disabled
            Type = CadenaAccessKey(1) 'Start / Jump
            Key = CadenaAccessKey(2) 'Key
            'If AccessKey.StartsWith("Disabled") Then
            '    If IdiomaAPP = "Spanish" Then
            '        MsgBox("La función de Llave de Acceso está desactivada.", MsgBoxStyle.Critical, "Worcome Security")
            '    ElseIf IdiomaAPP = "English" Then
            '        MsgBox("The Access Key function is disabled.", MsgBoxStyle.Critical, "Worcome Security")
            '    End If
            '    End
            'Else
            If Status = "Enabled" Then
                If ArgumentLine = Nothing Then
                    If IdiomaAPP = "Spanish" Then
                        MsgBox("FileShield necesita una Llave de Acceso para iniciar.", MsgBoxStyle.Critical, "Worcome Security")
                    ElseIf IdiomaAPP = "English" Then
                        MsgBox("FileShield needs an Access Key to start.", MsgBoxStyle.Critical, "Worcome Security")
                    End If
                    End
                Else
                    If ALStatus = "Enabled" Then
                        If Type = "Jump" Then ' Type = ALType (?
                            If ALType = "Jump" Then
                                If ALKey = Key Then
                                    AlreadyPassAsAccessKey = True
                                    LogInPassed()
                                Else
                                    If IdiomaAPP = "Spanish" Then
                                        MsgBox("La llave de la Llave de Acceso es incorrecta.", MsgBoxStyle.Critical, "Worcome Security")
                                    ElseIf IdiomaAPP = "English" Then
                                        MsgBox("The key of the Access Key is incorrect.", MsgBoxStyle.Critical, "Worcome Security")
                                    End If
                                    End
                                End If
                            ElseIf ALType = "Start" Then
                                If IdiomaAPP = "Spanish" Then
                                    MsgBox("El tipo de Llave de Acceso es incorrecta.", MsgBoxStyle.Critical, "Worcome Security")
                                ElseIf IdiomaAPP = "English" Then
                                    MsgBox("The type of Access Key is incorrect.", MsgBoxStyle.Critical, "Worcome Security")
                                End If
                                End
                            Else
                                If IdiomaAPP = "Spanish" Then
                                    MsgBox("No se logro identificar el tipo de Llave de Acceso.", MsgBoxStyle.Critical, "Worcome Security")
                                ElseIf IdiomaAPP = "English" Then
                                    MsgBox("Could not identify the type of Access Key.", MsgBoxStyle.Critical, "Worcome Security")
                                End If
                                End
                            End If
                        ElseIf Type = "Start" Then
                            If ALType = "Jump" Then
                                If IdiomaAPP = "Spanish" Then
                                    MsgBox("El tipo de Llave de Acceso es incorrecta.", MsgBoxStyle.Critical, "Worcome Security")
                                ElseIf IdiomaAPP = "English" Then
                                    MsgBox("The type of Access Key is incorrect.", MsgBoxStyle.Critical, "Worcome Security")
                                End If
                                End
                            ElseIf ALType = "Start" Then
                                If ALKey = Key Then
                                    AlreadyPassAsAccessKey = True
                                    CommonStart()
                                Else
                                    If IdiomaAPP = "Spanish" Then
                                        MsgBox("La llave de la Llave de Acceso es incorrecta.", MsgBoxStyle.Critical, "Worcome Security")
                                    ElseIf IdiomaAPP = "English" Then
                                        MsgBox("The key of the Access Key is incorrect.", MsgBoxStyle.Critical, "Worcome Security")
                                    End If
                                    End
                                End If
                            Else
                                If IdiomaAPP = "Spanish" Then
                                    MsgBox("No se logro identificar el tipo de Llave de Acceso", MsgBoxStyle.Critical, "Worcome Security")
                                ElseIf IdiomaAPP = "English" Then
                                    MsgBox("Could not identify the type of Access Key.", MsgBoxStyle.Critical, "Worcome Security")
                                End If
                                End
                            End If
                        Else
                            If IdiomaAPP = "Spanish" Then
                                MsgBox("No se logro identificar el tipo de Llave de Acceso.", MsgBoxStyle.Critical, "Worcome Security")
                            ElseIf IdiomaAPP = "English" Then
                                MsgBox("Could not identify the type of Access Key.", MsgBoxStyle.Critical, "Worcome Security")
                            End If
                            End
                        End If
                    Else
                        If IdiomaAPP = "Spanish" Then
                            MsgBox("La función de Llave de Acceso no está permitida.", MsgBoxStyle.Critical, "Worcome Security")
                        ElseIf IdiomaAPP = "English" Then
                            MsgBox("The Access Key function is not allowed.", MsgBoxStyle.Critical, "Worcome Security")
                        End If
                        End
                    End If
                End If
            Else
                If ArgumentLine = Nothing Then
                    AlreadyPassAsAccessKey = True
                    CommonStart()
                Else
                    If IdiomaAPP = "Spanish" Then
                        MsgBox("La función de Llave de Acceso no está permitida.", MsgBoxStyle.Critical, "Worcome Security")
                    ElseIf IdiomaAPP = "English" Then
                        MsgBox("The Access Key function is not allowed.", MsgBoxStyle.Critical, "Worcome Security")
                    End If
                    End
                End If
            End If
            'End If
            'End If
        Catch ex As Exception
            Console.WriteLine("ERROR4: " & ex.Message)
            End
        End Try
    End Sub

#Region "BaseDeDatos"

    Sub SaveDataBase()
        Try
            If My.Computer.FileSystem.FileExists(Main.DIRFiles & "\FS_DB.ini") = True Then
                My.Computer.FileSystem.DeleteFile(Main.DIRFiles & "\FS_DB.ini")
            End If
            My.Computer.FileSystem.WriteAllText(Main.DIRFiles & "\FS_DB.ini", Main.Encriptar("#Worcome FileShield Login DataBase" &
                                                vbCrLf & "UserName>" & UserName &
                                                vbCrLf & "Password>" & Password &
                                                vbCrLf & "CryptoKey>" & CryptoKey &
                                                vbCrLf & "Version>" & My.Application.Info.Version.ToString &
                                                vbCrLf & "Origin>" & Origin &
                                                vbCrLf & "OnlyMe>" & OnlyMe &
                                                vbCrLf & "MaxTrys>" & MaxTrys &
                                                vbCrLf & "DeleteAtMaxTrys>" & DeleteAtMaxTrys &
                                                vbCrLf & "StartLimit>" & StartLimit &
                                                vbCrLf & "StartLimitCounter>" & StartLimitCounter &
                                                vbCrLf & "LockAtStartLimit>" & LockAtStartLimit &
                                                vbCrLf & "AutoLockStatus>" & AutoLockStatus &
                                                vbCrLf & "AutoLockType>" & AutoLockType &
                                                vbCrLf & "AutoLockTypeONE>" & AutoLockTypeONE &
                                                vbCrLf & "AutoLockTypeONE_Hour>" & AutoLockTypeONE_Hour &
                                                vbCrLf & "AutoLockTypeONE_Minute>" & AutoLockTypeONE_Minute &
                                                vbCrLf & "AutoLockTypeONE_Second>" & AutoLockTypeONE_Second &
                                                vbCrLf & "AutoLockTypeTWO>" & AutoLockTypeTWO &
                                                vbCrLf & "AutoLockTypeTWO_Second>" & AutoLockTypeTWO_Second &
                                                vbCrLf & "AccessKey>" & AccessKey &
                                                vbCrLf & "ThemeMode>" & ThemeMode &
                                                vbCrLf & "SaveLogs>" & SaveLogs &
                                                vbCrLf & "ShareMode>" & ShareMode), False)
            LoadDataBase()
        Catch ex As Exception
        End Try
    End Sub
    Sub LoadDataBase()
        Try
            Dim TXBXVR As New TextBox
            TXBXVR.Text = Main.Desencriptar(My.Computer.FileSystem.ReadAllText(Main.DIRFiles & "\FS_DB.ini"))
            Dim Lineas = TXBXVR.Lines
            Try
                UserName = Lineas(1).Split(">"c)(1).Trim()
                Password = Lineas(2).Split(">"c)(1).Trim()
                CryptoKey = Lineas(3).Split(">"c)(1).Trim()
                Version = Lineas(4).Split(">"c)(1).Trim()
                Origin = Lineas(5).Split(">"c)(1).Trim()
                OnlyMe = Lineas(6).Split(">"c)(1).Trim()
            Catch ex As Exception
                If IdiomaAPP = "Spanish" Then
                    MsgBox("La base de datos esta corrupta." & vbCrLf & "Lamentablemente los archivos no se pueden recuperar.", MsgBoxStyle.Critical, "Worcome Security")
                ElseIf IdiomaAPP = "English" Then
                    MsgBox("The database Is corrupt." & vbCrLf & "Unfortunately the files cannot be recovered.", MsgBoxStyle.Critical, "Worcome Security")
                End If
            End Try
            Try
                MaxTrys = Lineas(7).Split(">"c)(1).Trim()
                DeleteAtMaxTrys = Lineas(8).Split(">"c)(1).Trim()
                StartLimit = Lineas(9).Split(">"c)(1).Trim()
                StartLimitCounter = Lineas(10).Split(">"c)(1).Trim()
                LockAtStartLimit = Lineas(11).Split(">"c)(1).Trim()
                AutoLockStatus = Lineas(12).Split(">"c)(1).Trim()
                AutoLockType = Lineas(13).Split(">"c)(1).Trim()
                AutoLockTypeONE = Lineas(14).Split(">"c)(1).Trim()
                AutoLockTypeONE_Hour = Lineas(15).Split(">"c)(1).Trim()
                AutoLockTypeONE_Minute = Lineas(16).Split(">"c)(1).Trim()
                AutoLockTypeONE_Second = Lineas(17).Split(">"c)(1).Trim()
                AutoLockTypeTWO = Lineas(18).Split(">"c)(1).Trim()
                AutoLockTypeTWO_Second = Lineas(19).Split(">"c)(1).Trim()
                Try
                    AccessKey = Lineas(20).Split(">"c)(1).Trim()
                    ThemeMode = Lineas(21).Split(">"c)(1).Trim()
                Catch ex As Exception
                    AccessKey = "Disabled/Start/None"
                    ThemeMode = "Default"
                End Try
                Try
                    SaveLogs = Lineas(22).Split(">"c)(1).Trim()
                    ShareMode = Lineas(23).Split(">"c)(1).Trim()
                Catch ex As Exception
                End Try
            Catch ex As Exception
            End Try
            If Version = My.Application.Info.Version.ToString Then
            Else
                Config.RefreshDataBase()
                If OnlyMe = "True" Then
                    If IdiomaAPP = "Spanish" Then
                        MsgBox("La version anterior tiene 'OnlyMe' activado.", MsgBoxStyle.Critical, "Worcome Security")
                    ElseIf IdiomaAPP = "English" Then
                        MsgBox("The previous version has 'OnlyMe' activated.", MsgBoxStyle.Critical, "Worcome Security")
                    End If
                    End
                End If
            End If
            If ThemeMode = "Dark" Then
                ThemeModeAP("Dark")
            End If
        Catch ex As Exception
            Console.WriteLine("ERROR5: " & ex.Message)
            If IdiomaAPP = "Spanish" Then
                MsgBox("Vuelva a iniciar el programa.", MsgBoxStyle.Information, "Worcome Security")
            Else
                MsgBox("Start the program again.", MsgBoxStyle.Information, "Worcome Security")
            End If
            Console.WriteLine("[Debugger@LoadDataBase]Error: " & ex.Message)
            End
        End Try
    End Sub

    Sub SaveFileList()
        Try
            If My.Computer.FileSystem.FileExists(Main.DIRFiles & "\FS_Files.lst") = True Then
                My.Computer.FileSystem.DeleteFile(Main.DIRFiles & "\FS_Files.lst")
            End If
            Dim tempString As String = Nothing
            For Each File As Object In Main.MemoryFile
                tempString = tempString & File & vbCrLf
            Next
            My.Computer.FileSystem.WriteAllText(Main.DIRFiles & "\FS_Files.lst", Main.Encriptar(tempString), False)
            LoadFileList()
        Catch ex As Exception
        End Try
    End Sub
    Sub LoadFileList()
        Try
            Main.MemoryFile.Clear()
            Main.lstArchivos.Items.Clear()
            Main.MemoryFileNames.Clear()
            Dim TXBXVR As New TextBox
            TXBXVR.Text = Main.Desencriptar(My.Computer.FileSystem.ReadAllText(Main.DIRFiles & "\FS_Files.lst"))
            For Each Item As String In TXBXVR.Lines
                Main.MemoryFile.Add(Item)
            Next
            Main.MemoryFile.Remove("") 'Limpieza de archivos "fantasma"
            Main.MemoryFile.Remove(" ")
            Main.MemoryFile.Remove("  ")
            Main.MemoryFile.Remove("   ")
        Catch ex As Exception
        End Try
    End Sub
#End Region

    Sub CommonStart()
        Try
            If ReadyRegistered = "True" Then
                If SaveLogs = "True" Then
                    My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Main.Encriptar(vbCrLf & "FileShield iniciado! En: " & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & ". Idioma: " & IdiomaAPP), True)
                End If
                If Environment.UserName = Origin Then
                    StartLimitCounter = StartLimitCounter + 1
                    SaveDataBase()
                Else
                    If StartLimitCounter >= StartLimit Then
                        If LockAtStartLimit = "True" Then
                            If IdiomaAPP = "Spanish" Then
                                MsgBox("FileShield está bloqueado.", MsgBoxStyle.Critical, "Worcome Security")
                            ElseIf IdiomaAPP = "English" Then
                                MsgBox("FileShield is blocked.", MsgBoxStyle.Critical, "Worcome Security")
                            End If
                            End
                        End If
                    End If
                    StartLimitCounter = StartLimitCounter + 1
                    SaveDataBase()
                End If
                If My.Computer.FileSystem.FileExists(Main.DIRFiles & "\Session.ses") = True Then
                    If SaveLogs = "True" Then
                        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Main.Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Sesion anterior corrupta."), True)
                    End If
                    'If IdiomaAPP = "Spanish" Then
                    '    MsgBox("FileShield no se cerró correctamente la última vez." & vbCrLf & "Se intentara recuperar la sesion, pero es posible que los ficheros de pierdan.", MsgBoxStyle.Exclamation, "Worcome Studios")
                    'ElseIf IdiomaAPP = "English" Then
                    '    MsgBox("FileShield did not close correctly the last time." & vbCrLf & "An attempt will be made to recover the session, but the files may be lost.", MsgBoxStyle.Exclamation, "Worcome Studios")
                    'End If
                    RecoverSession = True
                    RestoreSession()
                Else
                    Login.Show()
                End If
            Else
                Login.Show()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub RestoreSession()
        Try
            Main.myCryptoKey = CryptoKey
            Main.EncriptarFicheros()
            Login.Show()
        Catch ex As Exception
        End Try
    End Sub

    Public StartLimitStats As String = Nothing
    Sub LogInPassed()
        If SaveLogs = "True" Then
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Main.Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Sesion iniciada!"), True)
        End If
        If Environment.UserName = Origin Then
            StartLimitStats = StartLimitCounter
            StartLimitCounter = 0
            SaveDataBase()
        End If
        Main.Show()
        Login.Hide()
    End Sub

    Sub SignIn()
        SaveFileList()
        'Main.UserClose = False
        'Main.EncriptarFicheros()
        'Main.Hide()
        Login.TextBox1.Clear()
        Login.TextBox2.Clear()
        Login.UserClose = "ReFill"
        If IdiomaAPP = "Spanish" Then
            Login.Button1.Text = "Registrarse"
            Login.Label1.Text = "Registrate"
        ElseIf IdiomaAPP = "English" Then
            Login.Button1.Text = "Sign in"
            Login.Label1.Text = "Sign up"
        End If
        Login.Show()
    End Sub

    Private Sub Debugger_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If SaveLogs = "True" Then
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Main.Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Sesion finalizada."), True)
        End If
        SaveFileList()
        SaveDataBase()
        Try
            My.Computer.FileSystem.DeleteFile(Main.DIRFiles & "\Session.ses")
        Catch ex As Exception
        End Try
    End Sub

    Sub ThemeModeAP(ByVal Theme As String)
        Try
            If Theme = "Dark" Then
                Login.BackColor = Color.FromArgb(50, 50, 50)
                Login.Label1.ForeColor = Color.LimeGreen
                Login.Label2.ForeColor = Color.LimeGreen
                Login.Label3.ForeColor = Color.LimeGreen
                Login.Button1.ForeColor = Color.LimeGreen

                Config.BackColor = Color.FromArgb(50, 50, 50)
                Config.Label1.ForeColor = Color.LimeGreen
                Config.Label2.ForeColor = Color.LimeGreen
                Config.Label3.ForeColor = Color.LimeGreen
                Config.Label4.ForeColor = Color.LimeGreen
                Config.Label5.ForeColor = Color.LimeGreen
                Config.Label6.ForeColor = Color.LimeGreen
                Config.Label7.ForeColor = Color.LimeGreen
                Config.Label8.ForeColor = Color.LimeGreen
                Config.Label9.ForeColor = Color.LimeGreen
                Config.Label10.ForeColor = Color.LimeGreen
                Config.Label11.ForeColor = Color.LimeGreen
                Config.Label12.ForeColor = Color.LimeGreen
                Config.CheckBox1.ForeColor = Color.LimeGreen
                Config.CheckBox2.ForeColor = Color.LimeGreen
                Config.CheckBox3.ForeColor = Color.LimeGreen
                Config.CheckBox4.ForeColor = Color.LimeGreen
                Config.CheckBox5.ForeColor = Color.LimeGreen
                Config.CheckBox6.ForeColor = Color.LimeGreen
                Config.RadioButton1.ForeColor = Color.LimeGreen
                Config.RadioButton2.ForeColor = Color.LimeGreen
                Config.RadioButton3.ForeColor = Color.LimeGreen
                Config.RadioButton4.ForeColor = Color.LimeGreen
                Config.Button1.ForeColor = Color.LimeGreen
                Config.Button2.ForeColor = Color.LimeGreen
                Config.Button3.ForeColor = Color.LimeGreen

                ChangeCryptoKey.BackColor = Color.FromArgb(50, 50, 50)
                ChangeCryptoKey.Label1.ForeColor = Color.LimeGreen
                ChangeCryptoKey.Label2.ForeColor = Color.LimeGreen
                ChangeCryptoKey.Label3.ForeColor = Color.LimeGreen
                ChangeCryptoKey.Button1.ForeColor = Color.LimeGreen
                ChangeCryptoKey.Button2.ForeColor = Color.LimeGreen
                ChangeCryptoKey.Button3.ForeColor = Color.LimeGreen

                Main.BackColor = Color.FromArgb(50, 50, 50)
                Main.Label1.ForeColor = Color.LimeGreen
                Main.GroupBox1.ForeColor = Color.LimeGreen
                Main.GroupBox2.ForeColor = Color.LimeGreen
                Main.Button1.ForeColor = Color.LimeGreen
                Main.Button2.ForeColor = Color.LimeGreen
                Main.Button3.ForeColor = Color.LimeGreen
                Main.Button4.ForeColor = Color.LimeGreen
                Main.Button4.ForeColor = Color.LimeGreen
                Main.lstArchivos.BackColor = Color.FromArgb(50, 50, 50)
                Main.lstArchivos.ForeColor = Color.LimeGreen
            ElseIf Theme = "Default" Then
                Login.BackColor = DefaultBackColor
                Login.Label1.ForeColor = DefaultForeColor
                Login.Label2.ForeColor = DefaultForeColor
                Login.Label3.ForeColor = DefaultForeColor
                Login.Button1.ForeColor = DefaultForeColor

                Config.BackColor = DefaultBackColor
                Config.Label1.ForeColor = DefaultForeColor
                Config.Label2.ForeColor = DefaultForeColor
                Config.Label3.ForeColor = DefaultForeColor
                Config.Label4.ForeColor = DefaultForeColor
                Config.Label5.ForeColor = DefaultForeColor
                Config.Label6.ForeColor = DefaultForeColor
                Config.Label7.ForeColor = DefaultForeColor
                Config.Label8.ForeColor = DefaultForeColor
                Config.Label9.ForeColor = DefaultForeColor
                Config.Label10.ForeColor = DefaultForeColor
                Config.Label11.ForeColor = DefaultForeColor
                Config.Label12.ForeColor = DefaultForeColor
                Config.CheckBox1.ForeColor = DefaultForeColor
                Config.CheckBox2.ForeColor = DefaultForeColor
                Config.CheckBox3.ForeColor = DefaultForeColor
                Config.CheckBox4.ForeColor = DefaultForeColor
                Config.CheckBox5.ForeColor = DefaultForeColor
                Config.CheckBox6.ForeColor = DefaultForeColor
                Config.RadioButton1.ForeColor = DefaultForeColor
                Config.RadioButton2.ForeColor = DefaultForeColor
                Config.RadioButton3.ForeColor = DefaultForeColor
                Config.RadioButton4.ForeColor = DefaultForeColor
                Config.Button1.ForeColor = DefaultForeColor
                Config.Button2.ForeColor = DefaultForeColor
                Config.Button3.ForeColor = DefaultForeColor

                ChangeCryptoKey.BackColor = DefaultBackColor
                ChangeCryptoKey.Label1.ForeColor = DefaultForeColor
                ChangeCryptoKey.Label2.ForeColor = DefaultForeColor
                ChangeCryptoKey.Label3.ForeColor = DefaultForeColor
                ChangeCryptoKey.Button1.ForeColor = DefaultForeColor
                ChangeCryptoKey.Button2.ForeColor = DefaultForeColor
                ChangeCryptoKey.Button3.ForeColor = DefaultForeColor

                Main.BackColor = DefaultBackColor
                Main.Label1.ForeColor = DefaultForeColor
                Main.GroupBox1.ForeColor = DefaultForeColor
                Main.GroupBox2.ForeColor = DefaultForeColor
                Main.Button1.ForeColor = DefaultForeColor
                Main.Button2.ForeColor = DefaultForeColor
                Main.Button3.ForeColor = DefaultForeColor
                Main.Button4.ForeColor = DefaultForeColor
                Main.lstArchivos.BackColor = DefaultBackColor
                Main.lstArchivos.ForeColor = DefaultForeColor
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
'CAMBIOS
'   Sistema de LOG (no aplicado)
'   Ahora la carpeta raiz de FileShield podra moverse sin generar errores.
'   Se soluciono un problema con las Llaves de Acceso
'   Se agregaro una funcion para poder compartir FileShield