Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Public Class Main
    Public DIRCommons As String = Application.StartupPath
    Public DIRFiles As String = DIRCommons & "\FileShield"
    Public DefaultCryptoKey As String = "5jBdlQ1DUMcTJjE9Vx2zfiADvw1xNtc2ZkM"
    Public Shared des As New TripleDESCryptoServiceProvider
    Public Shared hashmd5 As New MD5CryptoServiceProvider
    Public MemoryFile As New ArrayList
    Public MemoryFileNames As New ArrayList
    Public MemoryFileNamesCount As Integer = -1
    Public MemoryFileCount As Integer = -1
    Public UserClose As Boolean = True
    Public myCryptoKey As String
    Dim ExeName As String = Application.ExecutablePath
    Private Declare Function GetLastInputInfo Lib "user32" (ByRef plii As LASTINPUTINFO) As Boolean
    Structure LASTINPUTINFO
        Public cbSize As Integer
        Public dwTime As Integer
    End Structure
    Dim INPUT As New LASTINPUTINFO()

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox(DIRCommons)
        myCryptoKey = Debugger.CryptoKey
        ExeName = ExeName.Remove(0, ExeName.LastIndexOf("\") + 1)
        If Debugger.IdiomaAPP = "Spanish" Then
            Idioma.Español.LANG_Español()
        ElseIf Debugger.IdiomaAPP = "English" Then
            Idioma.Ingles.LANG_English()
        End If
        If Debugger.ShareMode = "True" Then
            If Environment.UserName = Debugger.Origin Then
            Else
                Button1.Enabled = False
                Button2.Enabled = False
                Button3.Enabled = False
                Label5.Visible = True
            End If
        End If
        My.Computer.FileSystem.WriteAllText(DIRFiles & "\Session.ses", Nothing, False)
        If Debugger.Version = My.Application.Info.Version.ToString Then
        Else
            Debugger.SaveDataBase()
            If Debugger.IdiomaAPP = "Spanish" Then
                MsgBox("Se actualizo la Base de Datos con la nueva version", MsgBoxStyle.Information, "Worcome Security")
            ElseIf Debugger.IdiomaAPP = "English" Then
                MsgBox("The Database was updated with the new version", MsgBoxStyle.Information, "Worcome Security")
            End If
        End If
        Label2.Text = "Version: " & My.Application.Info.Version.ToString
        DesencriptarFicheros()
        If Debugger.UserName = "tmpUser" Or Debugger.Password = "15243" Then
            Login.TopMost = False
            If Debugger.IdiomaAPP = "Spanish" Then
                MsgBox("Recomendamos cambiar las credenciales de fábrica!" & vbCrLf & "Las credenciales de fabrica solo estan para acceder a FileShield en su primer arranque.", MsgBoxStyle.Information, "Worcome Security")
                Dim TXBVR_User = InputBox("Ingrese un nuevo nombre de usuario", "Worcome Security")
                If TXBVR_User = Nothing Then
                    MsgBox("Te recomendamos cambiar las credenciales de fábrica", MsgBoxStyle.Exclamation, "Worcome Security")
                Else
                    Dim TXBVR_Password = InputBox("Ingrese una nueva contraseña", "Worcome Security")
                    Debugger.UserName = TXBVR_User
                    Debugger.Password = TXBVR_Password
                    Debugger.SaveDataBase()
                End If
            ElseIf Debugger.IdiomaAPP = "English" Then
                MsgBox("We recommend changing factory credentials!" & vbCrLf & "Factory credentials are only to access FileShield on its first boot", MsgBoxStyle.Information, "Worcome Security")
                Dim TXBVR_User = InputBox("Enter a new username", "Worcome Security")
                If TXBVR_User = Nothing Then
                    MsgBox("We recommend changing the factory credentials", MsgBoxStyle.Exclamation, "Worcome Security")
                Else
                    Dim TXBVR_Password = InputBox("Enter a new password", "Worcome Security")
                    Debugger.UserName = TXBVR_User
                    Debugger.Password = TXBVR_Password
                    Debugger.SaveDataBase()
                End If
            End If
        End If
        If Debugger.AutoLockStatus = "True" Then
            If Debugger.AutoLockType = "ONE" Then
                Timer_AutoLock.Enabled = True
                Timer_Inactividad.Enabled = False
            ElseIf Debugger.AutoLockType = "TWO" Then
                Try
                    INPUT.cbSize = Marshal.SizeOf(INPUT)
                    Timer_Inactividad.Enabled = True
                    Timer_AutoLock.Enabled = False
                Catch ex As Exception
                End Try
            End If
        End If
        If Debugger.IdiomaAPP = "Spanish" Then
            Label4.Text = "Protegiendo: " & lstArchivos.Items.Count & " Archivos"
        ElseIf Debugger.IdiomaAPP = "English" Then
            Label4.Text = "Protecting: " & lstArchivos.Items.Count & " Files"
        End If
        Me.Text = "Wor: FileShield | " & Debugger.UserName
        IndexFilesToList()
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        EncriptarFicheros()
        If UserClose = True Then
            Debugger.Close()
        End If
    End Sub

#Region "Crypto"
    Sub CreatePrivateKey()
        Try
            Dim obj As New Random()
            Dim posibles As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
            Dim longitud As Integer = posibles.Length
            Dim letra As Char
            Dim longitudnuevacadena As Integer = 30
            Dim nuevacadena As String = Nothing
            For i As Integer = 0 To longitudnuevacadena - 1
                letra = posibles(obj.[Next](longitud))
                nuevacadena += letra.ToString()
            Next
            Debugger.CryptoKey = nuevacadena
            myCryptoKey = nuevacadena
            Debugger.SaveDataBase()
        Catch ex As Exception
        End Try
    End Sub

    Function Encriptar(ByVal texto As String) As String
        If Trim(texto) = "" Then
            Encriptar = ""
        Else
            des.Key = hashmd5.ComputeHash((New UnicodeEncoding).GetBytes(DefaultCryptoKey))
            des.Mode = CipherMode.ECB
            Dim encrypt As ICryptoTransform = des.CreateEncryptor()
            Dim buff() As Byte = UnicodeEncoding.ASCII.GetBytes(texto)
            Encriptar = Convert.ToBase64String(encrypt.TransformFinalBlock(buff, 0, buff.Length))
        End If
        Return Encriptar
    End Function
    Function Desencriptar(ByVal texto As String) As String
        If Trim(texto) = "" Then
            Desencriptar = ""
        Else
            des.Key = hashmd5.ComputeHash((New UnicodeEncoding).GetBytes(DefaultCryptoKey))
            des.Mode = CipherMode.ECB
            Dim desencrypta As ICryptoTransform = des.CreateDecryptor()
            Dim buff() As Byte = Convert.FromBase64String(texto)
            Desencriptar = UnicodeEncoding.ASCII.GetString(desencrypta.TransformFinalBlock(buff, 0, buff.Length))
        End If
        Return Desencriptar
    End Function

    Sub CallEncrypt(ByVal FileIN As String, ByVal FileOUT As String)
        Try
            Dim buffer As Byte()
            Using fs As New FileStream(FileIN, FileMode.Open, FileAccess.Read)
                Using ms As New MemoryStream()
                    Encrypt(fs, ms, myCryptoKey)
                    buffer = ms.ToArray()
                End Using
            End Using
            Using fs As New FileStream(FileOUT, FileMode.CreateNew, FileAccess.Write)
                fs.Write(buffer, 0, buffer.Length)
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Sub CallDecrypt(ByVal FileIN As String, ByVal FileOUT As String)
        Try
            Dim buffer As Byte() = Nothing
            Using fs As New FileStream(FileIN, FileMode.Open, FileAccess.Read)
                Using ms As New MemoryStream()
                    Decrypt(fs, ms, myCryptoKey)
                    buffer = ms.ToArray()
                End Using
            End Using
            Using fs As New FileStream(FileOUT, FileMode.CreateNew, FileAccess.Write)
                fs.Write(buffer, 0, buffer.Length)
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Friend Shared Sub Decrypt(inStream As Stream, outStream As Stream, pwd As String)
        Try
            Dim aes As New AesCryptoServiceProvider()
            aes.Mode = CipherMode.CFB
            aes.Key() = GetDeriveBytes(pwd, 32)
            aes.IV = GetDeriveBytes(pwd, 16)
            Dim stream As New CryptoStream(inStream, aes.CreateDecryptor(), CryptoStreamMode.Read)
            Dim length As Integer = 2048
            Dim buffer As Byte() = New Byte(length - 1) {}
            Try
                Dim i As Integer = stream.Read(buffer, 0, length)
                Do While (i > 0)
                    outStream.Write(buffer, 0, i)
                    i = stream.Read(buffer, 0, length)
                Loop
            Finally
                aes.Dispose()
                buffer = Nothing
            End Try
        Catch ex As Exception
        End Try
    End Sub
    Friend Shared Sub Encrypt(inStream As Stream, outStream As Stream, pwd As String)
        Try
            Dim aes As New AesCryptoServiceProvider()
            aes.Mode = CipherMode.CFB
            aes.Key() = GetDeriveBytes(pwd, 32)
            aes.IV = GetDeriveBytes(pwd, 16)
            Dim stream As New CryptoStream(outStream, aes.CreateEncryptor(), CryptoStreamMode.Write)
            Dim length As Integer = 2048
            Dim buffer As Byte() = New Byte(length - 1) {}
            Try
                Dim i As Integer = inStream.Read(buffer, 0, length)
                Do While (i > 0)
                    stream.Write(buffer, 0, i)
                    i = inStream.Read(buffer, 0, length)
                Loop
            Finally
                stream.FlushFinalBlock()
                aes.Dispose()
                buffer = Nothing
            End Try
        Catch ex As Exception
        End Try
    End Sub
    Friend Shared Function GetDeriveBytes(password As String, size As Integer) As Byte()
        If ((String.IsNullOrWhiteSpace(password)) OrElse (password.Length < 8)) Then
            MsgBox("Error en el Modulo 'GetDeriveBytes'" & vbCrLf & "La llave criptografica debe tener mas de 8 caracteres", MsgBoxStyle.Critical, "SystemTrail Modules")
        End If
        If ((size < 1) OrElse (size > 128)) Then
            MsgBox("Error en el Modulo 'GetDeriveBytes'" & vbCrLf & "El tamaño tiene que estar comprendido entre 1 y 128.", MsgBoxStyle.Critical, "SystemTrail Modules")
        End If
        Dim pwd As Byte() = UTF8Encoding.UTF8.GetBytes(password)
        Dim salt As Byte() = UTF8Encoding.UTF8.GetBytes(Convert.ToBase64String(pwd))
        Using bytes As New Rfc2898DeriveBytes(pwd, salt, 1000)
            Return bytes.GetBytes(size)
        End Using
    End Function
#End Region

#Region "CommonSubs"
    Dim Progresssss As Integer = 0
    Dim WithEvents BackGroundCIPHER As New BackgroundWorker
    Dim WithEvents BackGroundDESCIPHER As New BackgroundWorker
    Dim WithEvents Taimer As New Timer
    Sub IndexFilesToList()
        Button3.Focus()
        Try
            lstArchivos.Items.Clear()
            MemoryFileNames.Clear()
            Dim tempString As String = Nothing
            For Each Item As Object In MemoryFile
                'tempString = Item.ToString
                'tempString = tempString.Remove(0, tempString.LastIndexOf(">") + 1)
                Dim SelectedFile As String = Item
                Dim Cadena As String() = SelectedFile.Split(">")
                Dim Archivo As String = Nothing
                Archivo = Cadena(1)
                lstArchivos.Items.Add(Archivo)
                MemoryFileNames.Add(Archivo)
            Next
            If Debugger.IdiomaAPP = "Spanish" Then
                Label4.Text = "Protegiendo: " & lstArchivos.Items.Count & " Archivos"
            ElseIf Debugger.IdiomaAPP = "English" Then
                Label4.Text = "Protecting: " & lstArchivos.Items.Count & " Files"
            End If
            If Debugger.SaveLogs = "True" Then
                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Cargados: " & MemoryFile.Count & " ficheros."), True)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Function CreateRandomName(ByVal RandomName As String)
        Dim obj As New Random()
        Dim posibles As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim longitud As Integer = posibles.Length
        Dim letra As Char
        Dim longitudnuevacadena As Integer = RandomName.Length
        Dim nuevacadena As String = Nothing
        For i As Integer = 0 To longitudnuevacadena - 1
            letra = posibles(obj.[Next](longitud))
            nuevacadena += letra.ToString()
        Next
        RandomName = nuevacadena
        Return RandomName
        nuevacadena = Nothing
        RandomName = Nothing
    End Function

    Sub EncriptarFicheros()
        'ProcessInformationBackground(True, "Encriptando ficheros...")
        'BackGroundCIPHER.RunWorkerAsync()
        Try
            For Each Fichero As Object In MemoryFile
                'Dim tempString As String = Nothing
                Dim NombreAleatorio As String = Fichero.ToString
                Dim Cadena As String() = NombreAleatorio.Split(">")
                Dim RandomName As String = Nothing
                Dim OriginalName As String = Nothing
                RandomName = Cadena(0) '65FUYG78t5R.exe
                OriginalName = Cadena(1) '"Nombre.exe"
                'tempString = Fichero.ToString
                'tempString = tempString.Remove(0, tempString.LastIndexOf("\") + 1)
                CallEncrypt(DIRCommons & "\" & OriginalName, DIRFiles & "\" & RandomName)
                For Each Archivo As String In My.Computer.FileSystem.GetFiles(DIRCommons)
                    Dim tmpString As String = Nothing
                    tmpString = Archivo.ToString
                    tmpString = tmpString.Remove(0, tmpString.LastIndexOf("\") + 1)
                    If OriginalName = tmpString Then
                        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\" & OriginalName)
                    End If
                Next
            Next
            If Debugger.SaveLogs = "True" Then
                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Cifrados: " & MemoryFile.Count & " ficheros."), True)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub DesencriptarFicheros()
        'ProcessInformationBackground(True, "Desencriptando ficheros...")
        'BackGroundDESCIPHER.RunWorkerAsync()
        Try
            For Each Fichero As String In My.Computer.FileSystem.GetFiles(DIRFiles) 'para otra update hacer que pasen solo archivos protegidos :)
                Dim tempString As String = Nothing
                tempString = Fichero.ToString
                tempString = tempString.Remove(0, tempString.LastIndexOf("\") + 1)
                If tempString = "FS_DB.ini" Or tempString = "FS_Files.lst" Or tempString = "Session.ses" Or tempString = "FS.log" Then
                Else
                    For Each Archivo As String In MemoryFile
                        Dim NombreAleatorio As String = Archivo
                        Dim Cadena As String() = NombreAleatorio.Split(">")
                        Dim RandomName As String = Nothing
                        Dim OriginalName As String = Nothing
                        RandomName = Cadena(0)
                        OriginalName = Cadena(1)
                        CallDecrypt(DIRFiles & "\" & RandomName, DIRCommons & "\" & OriginalName)
                    Next
                End If
            Next
            Dim VerifyFiles As String = Nothing
            For Each Archivo As String In My.Computer.FileSystem.GetFiles(DIRFiles)
                VerifyFiles = Archivo.ToString
                VerifyFiles = VerifyFiles.Remove(0, VerifyFiles.LastIndexOf("\") + 1)
                If VerifyFiles = "FS_DB.ini" Or VerifyFiles = "FS_Files.lst" Or VerifyFiles = "Session.ses" Or VerifyFiles = "FS.log" Then
                Else
                    My.Computer.FileSystem.DeleteFile(Archivo)
                End If
            Next
            If Debugger.SaveLogs = "True" Then
                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Descifrados: " & MemoryFile.Count & " ficheros."), True)
            End If
        Catch ex As Exception
        End Try
        Button3.Focus()
    End Sub

    Sub ProcessInformationBackground(ByVal Status As Boolean, ByVal text As String)
        If Status = True Then
            Panel1.Dock = DockStyle.Fill
            Panel1.Visible = True
            ProgressBar1.Maximum = MemoryFile.Count 'por el elemento vacio en la lista
            ProgressBar1.Style = ProgressBarStyle.Blocks
            Taimer.Start()
        Else
            Panel1.Dock = DockStyle.None
            Panel1.Visible = False
            Taimer.Stop()
            ProgressBar1.Style = ProgressBarStyle.Marquee
            Progresssss = 0
            ProgressBar1.Value = 0
        End If
        Label6.Text = text
    End Sub
#End Region

#Region "Objects"
    Private Sub btnAddFile_Click(sender As Object, e As EventArgs) Handles btnAddFile.Click
        btnAdd()
    End Sub

    Sub btnAdd()
        Try
            Dim OpenFile As New OpenFileDialog
            If Debugger.IdiomaAPP = "Spanish" Then
                OpenFile.Title = "Abrir archivo..."
                OpenFile.Filter = "Todos los Archivos|*.*"
            ElseIf Debugger.IdiomaAPP = "English" Then
                OpenFile.Title = "Open file..."
                OpenFile.Filter = "All file types|*.*"
            End If
            OpenFile.Multiselect = True
            OpenFile.InitialDirectory = DIRCommons
            OpenFile.FileName = Nothing
            Dim OpenFileNames() As String
            Dim FileDir As New ArrayList
            If OpenFile.ShowDialog = DialogResult.OK Then
                Try
                    OpenFileNames = OpenFile.FileNames
                    For i = 0 To OpenFileNames.Length - 1
                        Dim tmpString As String = Nothing
                        Try
                            tmpString = OpenFileNames(i).ToString
                            tmpString = tmpString.Remove(0, tmpString.LastIndexOf("\") + 1)
                            My.Computer.FileSystem.CopyFile(OpenFileNames(i).ToString, DIRCommons & "\" & tmpString)
                        Catch ex As Exception
                        End Try
                        FileDir.Add(DIRCommons & "\" & tmpString)
                    Next
                    For Each Fichero As String In FileDir
                        If Fichero.Contains("WorFileShield.exe") Or Fichero.Contains("FileShield.exe") Or Fichero.Contains(ExeName) Then
                        Else
                            Dim tempString As String = Nothing
                            Dim Extencion As String = IO.Path.GetExtension(Fichero)
                            tempString = Fichero.ToString
                            tempString = tempString.Remove(0, tempString.LastIndexOf("\") + 1)
                            Dim RandomName As String = Nothing
                            RandomName = CreateRandomName(tempString)
                            Threading.Thread.Sleep(150)
                            'MemoryFile.Add(RandomName & Extencion & ">" & Fichero)
                            MemoryFile.Add(RandomName & Extencion & ">" & tempString)
                            lstArchivos.Items.Add(tempString)
                            MemoryFileNames.Add(tempString)
                            RandomName = Nothing
                            If Debugger.SaveLogs = "True" Then
                                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Se agrego: " & tempString & " a la proteccion."), True)
                            End If
                        End If
                    Next
                    Debugger.SaveFileList()
                    IndexFilesToList()
                    If Debugger.SaveLogs = "True" Then
                        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Agregados a proteccion: " & FileDir.Count & " ficheros."), True)
                    End If
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lstArchivos_DragDrop(sender As Object, e As DragEventArgs) Handles lstArchivos.DragDrop
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim strRutaArchivos() As String
                Dim i As Integer
                Dim FileDir As New ArrayList
                strRutaArchivos = e.Data.GetData(DataFormats.FileDrop)
                Try
                    For i = 0 To strRutaArchivos.Length - 1
                        Dim tmpString As String = Nothing
                        Try
                            tmpString = strRutaArchivos(i).ToString
                            tmpString = tmpString.Remove(0, tmpString.LastIndexOf("\") + 1)
                            My.Computer.FileSystem.CopyFile(strRutaArchivos(i), DIRCommons & "\" & tmpString)
                        Catch ex As Exception
                        End Try
                        FileDir.Add(DIRCommons & "\" & tmpString)
                    Next
                    For Each Fichero As String In FileDir
                        If Fichero.Contains("WorFileShield.exe") Or Fichero.Contains("FileShield.exe") Or Fichero.Contains(ExeName) Then
                        Else
                            Dim tempString As String = Nothing
                            Dim Extencion As String = IO.Path.GetExtension(Fichero)
                            tempString = Fichero.ToString
                            tempString = tempString.Remove(0, tempString.LastIndexOf("\") + 1)
                            Dim RandomName As String = Nothing
                            RandomName = CreateRandomName(tempString)
                            Threading.Thread.Sleep(555)
                            MemoryFile.Add(RandomName & Extencion & ">" & tempString)
                            lstArchivos.Items.Add(tempString)
                            MemoryFileNames.Add(tempString)
                            RandomName = Nothing
                            If Debugger.SaveLogs = "True" Then
                                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Se agrego: " & tempString & " a la proteccion."), True)
                            End If
                        End If
                    Next
                Catch ex As Exception
                End Try
                Debugger.SaveFileList()
                IndexFilesToList()
                If Debugger.SaveLogs = "True" Then
                    My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Agregados a proteccion: " & FileDir.Count & " ficheros."), True)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Debugger.SignIn()
    End Sub

    Private Sub btnRemoveFile_Click(sender As Object, e As EventArgs) Handles btnRemoveFile.Click
        btnRemove()
    End Sub

    Sub btnRemove()
        Try
            If Debugger.SaveLogs = "True" Then
                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Se removio: " & lstArchivos.SelectedItem & " de la proteccion."), True)
            End If
            MemoryFile.RemoveAt(MemoryFileCount)
            lstArchivos.Items.RemoveAt(lstArchivos.SelectedIndex)
            Debugger.SaveFileList()
            IndexFilesToList()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lstArchivos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstArchivos.SelectedIndexChanged
        Try
            MemoryFileCount = lstArchivos.SelectedIndex
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://worcomestudios.comule.com/Recursos/AppHelper/" & My.Application.Info.AssemblyName & ".html")
    End Sub

    Private Sub btnEditFile_Click(sender As Object, e As EventArgs) Handles btnEditFile.Click
        btnOpenFile()
    End Sub

    Sub btnOpenFile()
        Try
            MemoryFileCount = lstArchivos.SelectedIndex
            Dim SelectedFile As String = MemoryFile(MemoryFileCount)
            Dim Cadena As String() = SelectedFile.Split(">")
            Dim Archivo As String = Nothing
            Archivo = Cadena(1)
            If Debugger.SaveLogs = "True" Then
                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Se abrio el fichero: " & Archivo & "."), True)
            End If
            Process.Start(DIRCommons & "\" & Archivo)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lstArchivos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstArchivos.MouseDoubleClick
        Try
            MemoryFileCount = lstArchivos.SelectedIndex
            Dim SelectedFile As String = MemoryFile(MemoryFileCount)
            Dim Cadena As String() = SelectedFile.Split(">")
            Dim Archivo As String = Nothing
            Archivo = Cadena(1)
            If Debugger.SaveLogs = "True" Then
                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Se abrio el fichero: " & Archivo & "."), True)
            End If
            Process.Start(DIRCommons & "\" & Archivo)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCryptoKey_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Login.Button1.Text = "> > >"
        Login.Label4.Visible = False
        Login.UserClose = "ReFill"
        Login.TextBox1.Clear()
        Login.TextBox2.Clear()
        If Debugger.IdiomaAPP = "Spanish" Then
            Login.Label1.Text = "Confirmar"
            Login.Label2.Text = "Nombre de usuario"
            Login.Label3.Text = "Contraseña"
        ElseIf Debugger.IdiomaAPP = "English" Then
            Login.Label1.Text = "Confirm"
            Login.Label2.Text = "User name"
            Login.Label3.Text = "Password"
        End If
        Login.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("http://worcomestudios.comule.com/Recursos/InfoData/WhatsNew/WhatsNew_" & My.Application.Info.AssemblyName & ".txt")
    End Sub

    Private Sub lstArchivos_DragEnter(sender As Object, e As DragEventArgs) Handles lstArchivos.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Config.Show()
        Config.Focus()
    End Sub

    Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles Button4.Click
        btnRename()
    End Sub

    Sub btnRename()
        Try
            Dim NombreAleatorio As String = MemoryFile(lstArchivos.SelectedIndex)
            Dim Cadena As String() = NombreAleatorio.Split(">")
            Dim RandomName As String = Nothing
            Dim OriginalName As String = Nothing
            RandomName = Cadena(0)
            OriginalName = Cadena(1)
            If Debugger.IdiomaAPP = "Spanish" Then
                Dim TextBoxName As String = InputBox("Ingrese el nuevo nombre para el archivo '" & lstArchivos.SelectedItem & "'" & vbCrLf & "No olvide escribir la extencion del archivo", "Worcome Security", lstArchivos.SelectedItem)
                If TextBoxName = Nothing Then
                Else
                    MemoryFile.RemoveAt(lstArchivos.SelectedIndex)
                    MemoryFileNames.RemoveAt(lstArchivos.SelectedIndex)
                    lstArchivos.Items.RemoveAt(lstArchivos.SelectedIndex)
                    My.Computer.FileSystem.RenameFile(DIRCommons & "\" & OriginalName, TextBoxName)
                    MemoryFile.Add(RandomName & ">" & TextBoxName)
                    MemoryFileNames.Add(TextBoxName)
                    Debugger.SaveFileList()
                    IndexFilesToList()
                    If Debugger.SaveLogs = "True" Then
                        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Se renombro el fichero: " & OriginalName & " por " & TextBoxName & "."), True)
                    End If
                    MsgBox("Nombre cambiado correctamente", MsgBoxStyle.Information, "Worcome Security")
                End If
            ElseIf Debugger.IdiomaAPP = "English" Then
                Dim TextBoxName As String = InputBox("Enter the new name for the file: '" & lstArchivos.SelectedItem & "'" & vbCrLf & "Don't forget to write the file extension", "Worcome Security", lstArchivos.SelectedItem)
                If TextBoxName = Nothing Then
                Else
                    MemoryFile.RemoveAt(lstArchivos.SelectedIndex)
                    MemoryFileNames.RemoveAt(lstArchivos.SelectedIndex)
                    lstArchivos.Items.RemoveAt(lstArchivos.SelectedIndex)
                    My.Computer.FileSystem.RenameFile(DIRCommons & "\" & OriginalName, TextBoxName)
                    MemoryFile.Add(RandomName & ">" & TextBoxName)
                    MemoryFileNames.Add(TextBoxName)
                    Debugger.SaveFileList()
                    IndexFilesToList()
                    If Debugger.SaveLogs = "True" Then
                        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Encriptar(vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Se renombro el fichero: " & OriginalName & " por " & TextBoxName & "."), True)
                    End If
                    MsgBox("Name changed successfully", MsgBoxStyle.Information, "Worcome Security")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        btnOpenFile()
    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click
        btnRename()
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        btnRemove()
    End Sub

    Private Sub ViewInExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewInExplorerToolStripMenuItem.Click
        MemoryFileCount = lstArchivos.SelectedIndex
        Dim SelectedFile As String = MemoryFile(MemoryFileCount)
        Dim Cadena As String() = SelectedFile.Split(">")
        Dim Archivo As String = Nothing
        Archivo = Cadena(1)
        If Debugger.SaveLogs = "True" Then
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", vbCrLf & "[" & Environment.UserName & " " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "]Se indico el fichero: " & Archivo & " en el explorador de archivos.", True)
        End If
        Process.Start("explorer.exe", "/select, " & DIRCommons & "\" & Archivo)
    End Sub

    Private Sub Main_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Me.HelpRequested
        Process.Start("http://worcomestudios.comule.com/Recursos/AppHelper/" & My.Application.Info.AssemblyName & ".html")
    End Sub
#End Region

#Region "AutoLock"
    Private Hora As Integer = 0
    Private Minuto As Integer = 0
    Private Segundo As Integer = 0

    Sub MostrarTiempo()
        Config.Label9.Text = Hora.ToString.PadLeft(2, "0") & ":"
        Config.Label9.Text &= Minuto.ToString.PadLeft(2, "0") & ":"
        Config.Label9.Text &= Segundo.ToString.PadLeft(2, "0")
    End Sub

    Private Sub Timer_AutoLock_Tick(sender As Object, e As EventArgs) Handles Timer_AutoLock.Tick
        Try
            Segundo += 1
            If Segundo = 59 Then
                Segundo = 0
                Minuto += 1
                If Minuto = 59 Then
                    Minuto += 1
                    Hora += 1
                End If
            End If
            MostrarTiempo()
        Catch ex As Exception
        End Try
        Try
            If Val(Debugger.AutoLockTypeONE_Hour) = Val(Hora) And Val(Debugger.AutoLockTypeONE_Minute) = Val(Minuto) And Val(Debugger.AutoLockTypeONE_Second) = Val(Segundo) Then
                EncriptarFicheros()
                Debugger.Close()
            End If
        Catch ex As Exception
            Timer_AutoLock.Enabled = False
        End Try
    End Sub

    Private Sub Timer_Inactividad_Tick(sender As Object, e As EventArgs) Handles Timer_Inactividad.Tick
        Try
            GetLastInputInfo(INPUT)
            Dim TOTAL As Integer = Environment.TickCount
            Dim ULTIMO As Integer = INPUT.dwTime
            Dim INTERVALO As Integer = (TOTAL - ULTIMO) / 1000
            If INTERVALO >= Debugger.AutoLockTypeTWO_Second Then
                EncriptarFicheros()
                Debugger.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
End Class