Public Class Connect
    Private currentAsyncResult As IAsyncResult

    Private Async Sub queueHostEntry(result As IAsyncResult)
        'This prevents multiple searches at a time by stopping all current searches
        currentAsyncResult = result

        While Not result.IsCompleted
            If currentAsyncResult IsNot result Then 'Determine whether scan is no longer required, since a new input has been given
                Return
            End If

            Await Task.Delay(100)
        End While

        Try
            TextBox2.Text = Net.Dns.EndGetHostEntry(result).HostName
        Catch ex As Exception
        End Try

        currentAsyncResult = Nothing
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        TextBox2.Clear()

        If TextBox1.TextLength = 0 Then
            Button1.Enabled = False
            currentAsyncResult = Nothing 'Cancel current DNS lookup
        Else
            Button1.Enabled = True
            queueHostEntry(Net.Dns.BeginGetHostEntry(TextBox1.Text, Nothing, Nothing))
        End If
    End Sub

    Private Sub auth_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles promptAuth.HelpRequested
        ToolTip1.ToolTipTitle = "Authentication"
        ToolTip1.Show("To login to a remote computer, enter the credentials of an administrator account." & vbCrLf &
                      "If you use the same credentials of the current account logged on to this computer" & vbCrLf &
                      "or if you use cached credentials to logon, you can deactivate this field.",
                      Me, PointToClient(hlpevent.MousePos), Int32.MaxValue)
    End Sub

    Private Sub addr_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles TextBox1.HelpRequested, Label1.HelpRequested
        ToolTip1.ToolTipTitle = "Host address"
        ToolTip1.Show("Enter a host name (this can be a dynamic host name or the computer's name in the local workgroup)" & vbCrLf &
                      "or an IP address of a remote computer to connect.", Me, PointToClient(hlpevent.MousePos), Int32.MaxValue)
    End Sub

    Private Sub all_Click(sender As Object, e As EventArgs) Handles TextBox1.Click, PictureBox1.Click, Label6.Click, Label5.Click, Label4.Click, Label1.Click, promptAuth.Click, Button2.Click, Button1.Click, MyBase.Click
        ToolTip1.Hide(Me)
    End Sub

    Private Sub Label4_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles PictureBox1.HelpRequested, Label4.HelpRequested
        ToolTip1.ToolTipTitle = "Connect to remote computer"
        ToolTip1.Show("You can manage local users and groups on a remote computer by logging on with an administrator account.", Me, PointToClient(hlpevent.MousePos), Int32.MaxValue)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        currentAsyncResult = Nothing 'Cancel current DNS lookup
    End Sub

    Private Sub Label2_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles TextBox2.HelpRequested, Label2.HelpRequested
        ToolTip1.ToolTipTitle = "Display name"
        ToolTip1.Show("A custom display name for the connected machine which will be used instead of the host address." & vbCrLf & "This is optional, as it will default to the computer's host address if not specified.", Me, PointToClient(hlpevent.MousePos), Int32.MaxValue)
    End Sub
End Class