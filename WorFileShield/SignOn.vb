Public Class SignOn
    Dim UserClose As Boolean = True
    Dim esRegistro As Boolean = False
    Dim esSesion As Boolean = False

    Private Sub SignOn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub SignOn_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If UserClose Then
            End
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> Nothing Or TextBox2.Text <> Nothing Then
            If (Not esRegistro) And (esSesion) Then 'Iniciar sesion
                If TextBox1.Text = userData(0) And TextBox2.Text = userData(1) Then
                    Continuar()
                Else
                    MsgBox("Los datos ingresados no coinciden con el registro", MsgBoxStyle.Critical, "Worcome Security")
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox1.Focus()
                End If
            ElseIf (Not esSesion) And (esRegistro) Then 'Registrarse
                userData(0) = TextBox1.Text
                userData(1) = TextBox2.Text
                SaveData()
                Continuar()
            End If
        Else
            MsgBox("Rellene con la informacion solicitada", MsgBoxStyle.Critical, "Worcome Security")
        End If
    End Sub

    Sub Continuar()
        Try
            Principal.Show()
            Principal.Focus()
            Me.Hide()
            Me.Dispose()
        Catch ex As Exception
            AddToLog("[Continuar@SignOn]Error: ", ex.Message, True)
        End Try
    End Sub
    Sub ModoSesion()
        Try
            Label1.Text = "Iniciar sesión"
            Button1.Text = "Iniciar sesión"
            esRegistro = False
            esSesion = True
        Catch ex As Exception
            AddToLog("[ModoSesion@SignOn]Error: ", ex.Message, True)
        End Try
    End Sub
    Sub ModoRegistro()
        Try
            Label1.Text = "Registro"
            Button1.Text = "Registrarme"
            esSesion = False
            esRegistro = True
        Catch ex As Exception
            AddToLog("[ModoRegistro@SignOn]Error: ", ex.Message, True)
        End Try
    End Sub
End Class