Public Class ChangeCryptoKey

    Private Sub ChangeCryptoKey_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Debugger.IdiomaAPP = "Spanish" Then
            Idioma.Español.LANG_Español()
        ElseIf Debugger.IdiomaAPP = "English" Then
            Idioma.Ingles.LANG_English()
        End If
    End Sub

    Private Sub btnShowCryptoKey_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = Nothing Then
            TextBox1.Text = Debugger.CryptoKey
            If Debugger.IdiomaAPP = "Spanish" Then
                Button1.Text = "Ocultar"
            ElseIf Debugger.IdiomaAPP = "English" Then
                Button1.Text = "Hide"
            End If
        Else
            TextBox1.Text = Nothing
            If Debugger.IdiomaAPP = "Spanish" Then
                Button1.Text = "Mostrar"
            ElseIf Debugger.IdiomaAPP = "English" Then
                Button1.Text = "Show"
            End If
        End If
    End Sub

    Private Sub btnGenerateCryptoKey_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Main.CreatePrivateKey()
        Threading.Thread.Sleep(150)
        If Debugger.IdiomaAPP = "Spanish" Then
            MsgBox("Llave Criptografica Creada", MsgBoxStyle.Information, "Worcome Security")
        ElseIf Debugger.IdiomaAPP = "English" Then
            MsgBox("Cryptographic Key Created", MsgBoxStyle.Information, "Worcome Security")
        End If
    End Sub

    Private Sub btnWriteCryptoKey_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim TextBoxVirtual = InputBox("Ingrese una Llave Criptografica" & vbCrLf & "Enter a Cryptographic Key", "Worcome Security")
        If TextBoxVirtual = Nothing Then
            If Debugger.IdiomaAPP = "Spanish" Then
                MsgBox("Rellene con la Informacion Solicitada", MsgBoxStyle.Critical, "Worcome Security")
            ElseIf Debugger.IdiomaAPP = "English" Then
                MsgBox("Fill in the requested information", MsgBoxStyle.Critical, "Worcome Security")
            End If
            Me.Close()
        Else
            Debugger.CryptoKey = TextBoxVirtual
            Main.myCryptoKey = TextBoxVirtual
            Debugger.SaveDataBase()
            Threading.Thread.Sleep(50)
            If Debugger.IdiomaAPP = "Spanish" Then
                MsgBox("Llave Criptografica Agregada Correctamente!", MsgBoxStyle.Information, "Worcome Security")
            ElseIf Debugger.IdiomaAPP = "English" Then
                MsgBox("Cryptographic Key Added Correctly!", MsgBoxStyle.Information, "Worcome Security")
            End If
            Me.Close()
        End If
    End Sub
End Class