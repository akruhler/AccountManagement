Imports System.Threading
Public Class Connect
    Private Delegate Sub dTextBox(text As String)
    Private thread As Thread

    Private Sub searchForHostName(addr As String)
        On Error Resume Next

        Dim t As String = Net.Dns.GetHostEntry(addr).HostName

        If TextBox2.InvokeRequired Then
            TextBox2.Invoke(New dTextBox(Sub(text As String)
                                             TextBox2.Text = text
                                         End Sub), t)
        Else
            TextBox2.Text = t
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If thread IsNot Nothing Then
            thread.Abort()
        End If

        TextBox2.Clear()

        If TextBox1.TextLength = 0 Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True

            thread = New Thread(Sub()
                                    searchForHostName(TextBox1.Text)
                                End Sub)
            thread.Start()
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
        thread.Abort()
    End Sub

    Private Sub Label2_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles TextBox2.HelpRequested, Label2.HelpRequested
        ToolTip1.ToolTipTitle = "Display name"
        ToolTip1.Show("A custom display name for the connected machine which will be used instead of the host address." & vbCrLf & "This is optional, as it will default to the computer's host address if not specified.", Me, PointToClient(hlpevent.MousePos), Int32.MaxValue)
    End Sub
End Class