Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Text
Module General
    'Public DIRRoot As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Worcome_Studios\Commons"
    'Public DIRCommons As String = DIRRoot & "\Apps\" & My.Application.Info.AssemblyName
    Public DIRRoot As String = Application.StartupPath
    Public DIRCommons As String = DIRRoot & "\" & My.Application.Info.ProductName

    Sub AddToLog(ByVal Header As String, ByVal content As String, Optional ByVal flag As Boolean = False)
        Try
            Dim Overwrite As Boolean = False
            If My.Computer.FileSystem.FileExists(DIRCommons & "\" & My.Application.Info.AssemblyName & ".log") Then
                Overwrite = True
            End If
            Dim LogContent As String = "(" & DateTime.Now.ToString("hh:mm:ss tt dd/MM/yyyy") & ")"
            If flag = True Then
                LogContent &= "[!!!] " & Header & content
            Else
                LogContent &= Header & content
            End If
            Console.WriteLine(LogContent)
            My.Computer.FileSystem.WriteAllText(DIRCommons & "\" & My.Application.Info.AssemblyName & ".log", LogContent & vbCrLf, Overwrite)
        Catch ex As Exception
            Console.WriteLine("[" & Header & "@AddToLog]Error: " & ex.Message)
        End Try
    End Sub

    <DllImport("kernel32")>
    Private Function GetPrivateProfileString(ByVal section As String, ByVal key As String, ByVal def As String, ByVal retVal As StringBuilder, ByVal size As Integer, ByVal filePath As String) As Integer
        'Use GetIniValue("KEY_HERE", "SubKEY_HERE", "filepath")
    End Function
    Public Function GetIniValue(ByVal section As String, ByVal key As String, ByVal filename As String, Optional ByVal defaultValue As String = Nothing) As String
        Dim sb As New StringBuilder(500)
        If GetPrivateProfileString(section, key, defaultValue, sb, sb.Capacity, filename) > 0 Then
            Return sb.ToString
        Else
            Return defaultValue
        End If
    End Function
End Module
Module StartUp

    Sub Init()
        Try
            CommonActions()
            If isAlreadySetSignOn() Then
                SignOn.Show()
                SignOn.Focus()
                SignOn.ModoSesion()
            Else
                SignOn.Show()
                SignOn.Focus()
                SignOn.ModoRegistro()
            End If
        Catch ex As Exception
            AddToLog("[Init@StartUp]Error: ", ex.Message, True)
        End Try
    End Sub

    Sub CommonActions()
        Try
            If Not My.Computer.FileSystem.DirectoryExists(DIRCommons) Then
                My.Computer.FileSystem.CreateDirectory(DIRCommons)
            End If
        Catch ex As Exception
            AddToLog("[CommonActions@StartUp]Error: ", ex.Message, True)
        End Try
    End Sub

    Function isAlreadySetSignOn() As Boolean
        Try
            If My.Computer.FileSystem.FileExists(DB_userFile) Then
                'Ya registrado
                LoadData()
                Return True
            Else
                'Sin registrar
                userData.Add("tmpUser")
                userData.Add("15243")
                userData.Add(CreatePrivateKey())
                Threading.Thread.Sleep(1500)
                appData.Add(CreatePrivateKey())
                Threading.Thread.Sleep(1500)
                appData.Add(CreatePrivateKey())
                SaveData()
                Return False
            End If
        Catch ex As Exception
            AddToLog("[CheckSignOn@StartUp]Error: ", ex.Message, True)
        End Try
        Return False
    End Function
End Module
Module Memory
    Public DB_userFile As String = DIRCommons & "\user.db"
    Public DB_appFile As String = DIRCommons & "\app.db"

    Public userData As New ArrayList
    Public appData As New ArrayList

    Sub LoadData()
        'Testeado! funciona.
        Try
            appData.Clear()
            userData.Clear()
            For Each appItem As String In IO.File.ReadLines(DB_appFile)
                If Not appItem.StartsWith("#") Then
                    appData.Add(Desencriptar(appItem, DefaultCryptoKey))
                End If
            Next
            For Each userItem As String In IO.File.ReadLines(DB_userFile)
                If Not userItem.StartsWith("#") Then
                    userData.Add(Desencriptar(userItem, appData(1)))
                End If
            Next
        Catch ex As Exception
            AddToLog("[LoadData@Memory]Error: ", ex.Message, True)
        End Try
    End Sub
    Sub SaveData()
        'Testeado! funciona.
        Try
            If My.Computer.FileSystem.FileExists(DB_userFile) Then
                My.Computer.FileSystem.DeleteFile(DB_userFile)
            End If
            If My.Computer.FileSystem.FileExists(DB_appFile) Then
                My.Computer.FileSystem.DeleteFile(DB_appFile)
            End If
            Dim userDataContent As String = Nothing
            Dim appDataContent As String = Nothing
            For Each item As String In userData
                userDataContent &= Encriptar(item, appData(1)) & vbCrLf
            Next
            For Each item As String In appData
                appDataContent &= Encriptar(item, DefaultCryptoKey) & vbCrLf
            Next
            Dim userDBFile As String = "# FileShield user DB" &
                vbCrLf & userDataContent
            Dim appDBFile As String = "# FileShield app DB" &
                vbCrLf & appDataContent
            My.Computer.FileSystem.WriteAllText(DB_userFile, userDBFile, False)
            My.Computer.FileSystem.WriteAllText(DB_appFile, appDBFile, False)
            LoadData()
        Catch ex As Exception
            AddToLog("[SaveData@Memory]Error: ", ex.Message, True)
        End Try
    End Sub
End Module
Module FileShield
    Dim DB_filesFile As String = DIRCommons & "\files.db"
    Public filesShielded As New ArrayList

    Sub Iniciando()
        Try
            CargarItems()
            DescifrarItems()
            ListarItems()
        Catch ex As Exception
            AddToLog("[Iniciando@FileShield]Error: ", ex.Message, True)
        End Try
    End Sub
    Sub Terminando()
        Try
            CifrarItems()
            GuardarItems()
        Catch ex As Exception
            AddToLog("[Terminando@FileShield]Error: ", ex.Message, True)
        End Try
    End Sub

    Sub ListarItems()
        Try
            Principal.ListBox1.Items.Clear()
            If My.Computer.FileSystem.FileExists(DB_filesFile) Then
                For Each item As String In filesShielded
                    Dim fichero As String = item
                    Dim partes() As String = fichero.Split("|")
                    Principal.ListBox1.Items.Add(partes(1))
                Next
            End If
        Catch ex As Exception
            AddToLog("[ListarItems@FileShield]Error: ", ex.Message, True)
        End Try
    End Sub

    Sub AgregarItems(ByVal file As String)
        Try
            Dim fileName As String = IO.Path.GetFileName(file)
            Dim fileRandom As String = CreateRandomString(IO.Path.GetFileNameWithoutExtension(file).Length)
            filesShielded.Add(fileRandom & "|" & fileName)
        Catch ex As Exception
            AddToLog("[AgregarItems@FileShield]Error: ", ex.Message, True)
        End Try
    End Sub

    Sub GuardarItems()
        Try
            If My.Computer.FileSystem.FileExists(DB_filesFile) Then
                My.Computer.FileSystem.DeleteFile(DB_filesFile)
            End If
            Dim items As String = Nothing
            For Each item As String In filesShielded
                items &= Encriptar(item, userData(2)) & vbCrLf
            Next
            My.Computer.FileSystem.WriteAllText(DB_filesFile, items, False)
        Catch ex As Exception
            AddToLog("[GuardarItems@FileShield]Error: ", ex.Message, True)
        End Try
    End Sub
    Sub CargarItems()
        Try
            If My.Computer.FileSystem.FileExists(DB_filesFile) Then
                filesShielded.Clear()
                For Each item As String In IO.File.ReadLines(DB_filesFile)
                    filesShielded.Add(Desencriptar(item, userData(2)))
                Next
            End If
        Catch ex As Exception
            AddToLog("[CargarItems@FileShield]Error: ", ex.Message, True)
        End Try
    End Sub

    Sub CifrarItems()
        'Testeado! funciona.
        Try
            For Each item As String In filesShielded
                Dim fileName As String = item.Split("|")(1)
                Dim fileNameRand As String = item.Split("|")(0)
                Dim itemEntrante As String = DIRRoot & "\" & fileName
                Dim itemSaliente As String = DIRCommons & "\" & fileNameRand
                If My.Computer.FileSystem.FileExists(itemSaliente) Then
                    My.Computer.FileSystem.DeleteFile(itemSaliente)
                End If
                CallEncrypt(itemEntrante, itemSaliente, userData(2))
                My.Computer.FileSystem.DeleteFile(itemEntrante)
            Next
        Catch ex As Exception
            AddToLog("[CifrarItems@FileShield]Error: ", ex.Message, True)
        End Try
    End Sub
    Sub DescifrarItems()
        'Testeado! funciona.
        Try
            For Each item As String In filesShielded
                Dim fileName As String = item.Split("|")(1)
                Dim fileNameRand As String = item.Split("|")(0)
                Dim itemEntrante As String = DIRCommons & "\" & fileNameRand
                Dim itemSaliente As String = DIRRoot & "\" & fileName
                If My.Computer.FileSystem.FileExists(itemSaliente) Then
                    My.Computer.FileSystem.DeleteFile(itemSaliente)
                End If
                CallDecrypt(itemEntrante, itemSaliente, userData(2))
                My.Computer.FileSystem.DeleteFile(itemEntrante)
            Next
        Catch ex As Exception
            AddToLog("[DescifrarItems@FileShield]Error: ", ex.Message, True)
        End Try
    End Sub
End Module