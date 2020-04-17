Public Class Auth
    Public Function Authenticate() As Credentials
        ShowDialog()
        If DialogResult = Windows.Forms.DialogResult.OK Then
            Return New Credentials(TextBox1.Text, TextBox2.Text)
        Else
            Return Nothing
        End If
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.TextLength = 0 Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub
End Class

Public Structure Credentials
    Public Username, Password As String

    Public Sub New(user As String, pass As String)
        Username = user
        Password = pass
    End Sub
End Structure