Public Class Principal
    Dim UserClose As Boolean = True

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Iniciando()
        lblVersion.Text = "Version: " & My.Application.Info.Version.ToString & " (" & Application.ProductVersion & ")"
        lblCountShieldedFiles.Text = "Protegiendo: " & ListBox1.Items.Count & " Archivos"
    End Sub
    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If UserClose Then
            Terminando()
            End
        End If
    End Sub

    Private Sub BtnConfiguracion_Click(sender As Object, e As EventArgs) Handles btnConfig.Click
        Config.Show()
        Config.Focus()
    End Sub

    Private Sub BtnAñadir_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Testeado! funciona.
        Dim openFile As New OpenFileDialog
        openFile.Filter = "Todos los archivos (*.*)|*.*"
        openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        openFile.Multiselect = True
        openFile.Title = "Abrir archivo/s..."
        If openFile.ShowDialog() = DialogResult.OK Then
            For Each fichero As String In openFile.FileNames
                Dim rutaDestino As String = DIRRoot & "\" & IO.Path.GetFileName(fichero)
                My.Computer.FileSystem.CopyFile(fichero, rutaDestino, True)
                ListBox1.Items.Add(IO.Path.GetFileName(fichero))
                AgregarItems(fichero)
            Next
        End If
    End Sub

    Private Sub BtnQuitar_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            'Testeado! funciona.
            Dim fileName As String = filesShielded(ListBox1.SelectedIndex).ToString.Split("|")(1)
            Dim fileNameRand As String = filesShielded(ListBox1.SelectedIndex).ToString.Split("|")(0)
            If MessageBox.Show("¿Seguro que desea quitar la proteccion al archivo '" & fileName & "'?", "Remover", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                'My.Computer.FileSystem.DeleteFile(DIRRoot & "\" & fileName)
                filesShielded.RemoveAt(ListBox1.SelectedIndex)
                ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
                ListarItems()
            End If
        Catch ex As Exception
            AddToLog("[BtnQuitar_Click@Principal]Error: ", ex.Message, True)
        End Try
    End Sub

    Private Sub BtnAbrir_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Try
            'Testeado! funciona.
            Dim itemToRun As String = DIRRoot & "\" & filesShielded(ListBox1.SelectedIndex).ToString.Split("|")(1).Trim()
            Process.Start(itemToRun)
        Catch ex As Exception
            AddToLog("[BtnAbrir_Click@Principal]Error: ", ex.Message, True)
        End Try
    End Sub

    Private Sub BtnRenombrar_Click(sender As Object, e As EventArgs) Handles btnRename.Click
        Try
            'Testeado! funciona.
            Dim fileName As String = filesShielded(ListBox1.SelectedIndex).ToString.Split("|")(1)
            Dim newName = InputBox("Ingrese el nuevo nombre", "Renombrar", fileName)
            filesShielded(ListBox1.SelectedIndex) = filesShielded(ListBox1.SelectedIndex).ToString.Split("|")(0) & "|" & newName
            My.Computer.FileSystem.RenameFile(DIRRoot & "\" & fileName, newName)
            ListarItems()
        Catch ex As Exception
            AddToLog("[BtnRenombrar_Click@Principal]Error: ", ex.Message, True)
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblGuide.LinkClicked
        Process.Start("http://worcomestudios.comule.com/WSS_Structure/AppHelper/AboutApps/WorFileShield.html")
    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblInformation.LinkClicked
        Process.Start("http://worcomestudios.comule.com/WSS_Structure/AppHelper/WorFileShield.html")
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        btnRemove.Enabled = True
        btnOpen.Enabled = True
        btnRename.Enabled = True
    End Sub
End Class