Public Class Starter

    Private Sub Init_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        ReadParameters()
        Init()
    End Sub

    Sub ReadParameters()
        Try

        Catch ex As Exception
            AddToLog("[ReadParameters@Init]Error: ", ex.Message, True)
        End Try
    End Sub
End Class