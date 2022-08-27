Public Class Loggs
    Dim theLOGString As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\FileShield\FS.log")

    Private Sub Log_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadTheFile()
    End Sub

    Sub AddLog(ByVal MSG As String)
        Try



        Catch ex As Exception

        End Try
    End Sub

    Sub ReadTheFile()
        Try
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\FileShield\FS.log") = True Then
                Debugger.LogFileContent = Main.Desencriptar(theLOGString)
                RichTextBox1.AppendText(Debugger.LogFileContent)
            Else
                RichTextBox1.Text = "No se encontraron registros."
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Debugger.SaveLogs = "True" Then
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\FileShield\FS.log") = True Then
                    My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\FileShield\FS.log")
                End If
                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\FileShield\FS.log", Nothing, False)
                RichTextBox1.Clear()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
'cifrar el log, esto es dificil pues tenemos las putas lineas.
'   Hacerlo por sesiones y no por parte
'       mandar los logs a un SUB para que los almacena hasta finalizar la sesion
'   Leer por lineas y no por completo