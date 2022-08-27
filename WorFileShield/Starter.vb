Public Class Starter
    Dim PassInit As Boolean = False

    Private Sub Init_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        ReadParameters(Command())
        If Not PassInit Then
            Init()
        End If
    End Sub

    Sub ReadParameters(ByVal parametros As String)
        Try
            If parametros <> Nothing Then
                If isAlreadySetSignOn() Then
                    If parametros.StartsWith("KEY=") Then
                        Config.LoadConfig()
                        Dim inKey As String = parametros.Replace("KEY=", Nothing)
                        Dim inKeyDecode As String = DecodeBase64(inKey)
                        Dim Keys As String() = Config.AccessKeys.Split("#")
                        For Each llave As String In Keys
                            If inKeyDecode = llave Then
                                Dim ArgKeyIn As String() = inKeyDecode.Split(";")
                                Dim ArgKeys As String() = llave.Split(";")
                                If ArgKeyIn(0) = ArgKeys(0) Then
                                    Principal.Show()
                                    Principal.Focus()
                                    PassInit = True
                                End If
                            End If
                        Next
                        'Dim result = Keys.ToArray().Any(Function(x) x.ToString().Contains(DecodeBase64(inKey)))
                        'If result Then
                        '    Principal.Show()
                        '    Principal.Focus()
                        'End If
                    End If
                End If
            End If
        Catch ex As Exception
            AddToLog("[ReadParameters@Init]Error: ", ex.Message, True)
        End Try
    End Sub
End Class