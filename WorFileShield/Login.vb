Public Class Login
    Public UserClose As String = "True"

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Debugger.UserName = "tmpUser" And Debugger.Password = "15243" Then Label4.Visible = True
        If Button1.Text = "> > >" Then Label4.Visible = False
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Debugger.IdiomaAPP = "Spanish" Then
                If Button1.Text = "Iniciar sesión" Then
                    Login()
                ElseIf Button1.Text = "Registrarse" Then
                    SignIn()
                ElseIf Button1.Text = "> > >" Then
                    ReLogin(ChangeCryptoKey)
                End If
            ElseIf Debugger.IdiomaAPP = "English" Then
                If Button1.Text = "Log in" Then
                    Login()
                ElseIf Button1.Text = "Sign in" Then
                    SignIn()
                ElseIf Button1.Text = "> > >" Then
                    ReLogin(ChangeCryptoKey)
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Debugger.IdiomaAPP = "Spanish" Then
            If Button1.Text = "Iniciar sesión" Then
                Login()
            ElseIf Button1.Text = "Registrarse" Then
                SignIn()
            ElseIf Button1.Text = "> > >" Then
                ReLogin(ChangeCryptoKey)
            End If
        ElseIf Debugger.IdiomaAPP = "English" Then
            If Button1.Text = "Log in" Then
                Login()
            ElseIf Button1.Text = "Sign in" Then
                SignIn()
            ElseIf Button1.Text = "> > >" Then
                ReLogin(ChangeCryptoKey)
            End If
        End If
    End Sub

    Sub ReLogin(ByVal ToShow As Form)
        Try
            If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Then
                If Debugger.IdiomaAPP = "Spanish" Then
                    MsgBox("Rellene con la información solicitada.", MsgBoxStyle.Critical, "Worcome Security")
                ElseIf Debugger.IdiomaAPP = "English" Then
                    MsgBox("Fill with the requested information.", MsgBoxStyle.Critical, "Worcome Security")
                End If
            Else
                If TextBox1.Text = Debugger.UserName And TextBox2.Text = Debugger.Password Then
                    Me.Hide()
                    ToShow.ShowDialog()
                    UserClose = "ReFill"
                    Me.Close()
                Else
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox1.Focus()
                    If Debugger.IdiomaAPP = "Spanish" Then
                        MsgBox("Información de registro incorrecta.", MsgBoxStyle.Critical, "Worcome Security")
                    ElseIf Debugger.IdiomaAPP = "English" Then
                        MsgBox("Incorrect Registration Information.", MsgBoxStyle.Critical, "Worcome Security")
                    End If
                    UserClose = "ReFill"
                    Me.Close()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub SignIn()
        Try
            If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Then
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox1.Focus()
                If Debugger.IdiomaAPP = "Spanish" Then
                    MsgBox("Rellene con la información solicitada.", MsgBoxStyle.Critical, "Worcome Security")
                ElseIf Debugger.IdiomaAPP = "English" Then
                    MsgBox("Fill with the requested information.", MsgBoxStyle.Critical, "Worcome Security")
                End If
            Else
                Debugger.UserName = TextBox1.Text
                Debugger.Password = TextBox2.Text
                Debugger.SaveDataBase()
                If Debugger.IdiomaAPP = "Spanish" Then
                    MsgBox("Registrado correctamente." & vbCrLf & "Vuelva a iniciar la aplicación.", MsgBoxStyle.Information, "Worcome Security")
                ElseIf Debugger.IdiomaAPP = "English" Then
                    MsgBox("Registered Successfully!" & vbCrLf & "Start the application again.", MsgBoxStyle.Information, "Worcome Security")
                End If
                Debugger.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Dim TryCounter As Integer = 0
    Sub Login()
        Try
            If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Then
                If Debugger.IdiomaAPP = "Spanish" Then
                    MsgBox("Rellene con la información solicitada..", MsgBoxStyle.Critical, "Worcome Security")
                ElseIf Debugger.IdiomaAPP = "English" Then
                    MsgBox("Fill with the requested information.", MsgBoxStyle.Critical, "Worcome Security")
                End If
            Else
                If TextBox1.Text = Debugger.UserName And TextBox2.Text = Debugger.Password Then
                    Debugger.LogInPassed()
                Else
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox1.Focus()
                    TryCounter = TryCounter + 1
                    If Debugger.IdiomaAPP = "Spanish" Then
                        MsgBox("Información de registro incorrecta.", MsgBoxStyle.Critical, "Worcome Security")
                    ElseIf Debugger.IdiomaAPP = "English" Then
                        MsgBox("Incorrect Registration Information.", MsgBoxStyle.Critical, "Worcome Security")
                    End If
                    If TryCounter > Debugger.MaxTrys Then
                        If Debugger.DeleteAtMaxTrys = "True" Then
                            My.Computer.FileSystem.DeleteDirectory(Main.DIRFiles, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                        End If
                        If Debugger.IdiomaAPP = "Spanish" Then
                            MsgBox("Máximo de intentos alcanzados.", MsgBoxStyle.Critical, "Worcome Security")
                        ElseIf Debugger.IdiomaAPP = "English" Then
                            MsgBox("Maximum attempts reached.", MsgBoxStyle.Critical, "Worcome Security")
                        End If
                        Debugger.Close()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If UserClose = "True" Then
            Debugger.Close()
        ElseIf UserClose = "ReFill" Then
            e.Cancel = False
        Else
            End
        End If
    End Sub

    Private Sub LabelInformation_Click(sender As Object, e As EventArgs) Handles Label4.Click
        MsgBox("By default credentials are:" & vbCrLf & "User:tmpUser" & vbCrLf & "Password:15243" & vbCrLf & "You must change the default credentials!", MsgBoxStyle.Information, "Worcome Security")
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        If TextBox2.PasswordChar = "●" Then
            TextBox2.PasswordChar = Nothing
        Else
            TextBox2.PasswordChar = "●"
        End If
    End Sub
End Class