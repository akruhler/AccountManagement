Public Class Connect
    Public Sub New()
        InitializeComponent()

        If Not cfgBool("PromptAuth") Then
            promptAuth.Checked = False
        End If
    End Sub

    Private Sub Connect_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Config.SetVal("PromptAuth", Convert.ToInt32(promptAuth.Checked), Handle)
    End Sub

    Private Sub Connect_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not queryRunning() Then
            DnsQueryDelay.Stop()
            initQuery()
        End If
    End Sub

#Region "DNS"
    Private currentAsyncTask As Task(Of Net.IPHostEntry)

    Public Async Function waitForDns() As Task(Of String)
        'Only wait for DNS lookup if the user didn't specify a display name and lookup is still running
        If displayName.TextLength = 0 Then

            Dim timeout As Integer = 0

            While queryRunning()

                Await Task.Delay(100)
                timeout += 1

                'If there is no response after 7 seconds, leave
                If timeout > 70 Then
                    Return ""
                End If
            End While

            Return displayName.Text

        Else
            Return displayName.Text
        End If
    End Function

    Private Async Sub queryHostEntry(DnsTask As Task(Of Net.IPHostEntry))
        currentAsyncTask = DnsTask

        While Not DnsTask.IsCompleted
            If currentAsyncTask IsNot DnsTask Then 'Determine whether scan is no longer required, since a new input has been given or the scan was cancelled
                Return
            End If

            Await Task.Delay(100)
        End While

        Try
            displayName.Text = DnsTask.Result.HostName
        Catch ex As Exception
        End Try

        DnsTask.Dispose()
        currentAsyncTask = Nothing
    End Sub

    Public Function queryRunning() As Boolean
        'The task object is set to null as soon as it finishes its job or if it has been cancelled
        Return currentAsyncTask IsNot Nothing
    End Function

    Public Sub initQuery()
        Try
            queryHostEntry(Net.Dns.GetHostEntryAsync(hostAddress.Text))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DnsQueryDelay_Tick(sender As Object, e As EventArgs) Handles DnsQueryDelay.Tick
        DnsQueryDelay.Stop()
        initQuery()
    End Sub

    'Skip the query delay, since the focus is no longer on the host address field
    Private Sub hostAddress_Leave(sender As Object, e As EventArgs) Handles hostAddress.Leave
        If DnsQueryDelay.Enabled = True Then
            DnsQueryDelay.Stop()
            initQuery()
        End If
    End Sub
#End Region

#Region "UI"

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles hostAddress.TextChanged
        DnsQueryDelay.Stop()
        displayName.Clear()

        If hostAddress.TextLength = 0 Then
            Button1.Enabled = False
            'Setting this object to null cancels the active scan
            currentAsyncTask = Nothing
        Else
            Button1.Enabled = True
            DnsQueryDelay.Start()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles displayName.TextChanged
        currentAsyncTask = Nothing
        DnsQueryDelay.Stop()
    End Sub
#End Region

#Region "Help"

    Private Sub all_Click(sender As Object, e As EventArgs) Handles displayName.Click, PictureBox1.Click, Label6.Click, Label5.Click, Label4.Click, Label1.Click, promptAuth.Click, Button2.Click, Button1.Click, MyBase.Click, hostAddress.Click
        HelpTooltip.Hide(Me)
    End Sub

    Private Sub auth_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles promptAuth.HelpRequested
        HelpTooltip.ToolTipTitle = "Always prompt for authentication"
        HelpTooltip.Show("Always prompt for authentication, even if there are valid credentials available" & vbCrLf &
                      "(i.e. saved credentials or same credentials as the currently logged on user)." & vbCrLf &
                      "If you wish to specify different credentials regardless of their availability, you should activate this field.",
                      Me, PointToClient(hlpevent.MousePos), 50000)
    End Sub

    Private Sub addr_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Label1.HelpRequested, hostAddress.HelpRequested
        HelpTooltip.ToolTipTitle = "Host address"
        HelpTooltip.Show("Enter a host name (this can be a dynamic host name or the computer's name in the local workgroup)" & vbCrLf &
                      "or an IP address of a remote computer to connect.", Me, PointToClient(hlpevent.MousePos), 50000)
    End Sub

    Private Sub Label4_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles PictureBox1.HelpRequested, Label4.HelpRequested
        HelpTooltip.ToolTipTitle = "Connect to remote computer"
        HelpTooltip.Show("You can manage local users and groups on a remote computer by logging on with an administrator account.", Me, PointToClient(hlpevent.MousePos), 50000)
    End Sub

    Private Sub Label2_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles displayName.HelpRequested, Label2.HelpRequested
        HelpTooltip.ToolTipTitle = "Display name"
        HelpTooltip.Show("A custom display name for the connected machine which will be used instead of the host address." & vbCrLf &
                      "This is optional, as it will default to the computer's host address if not specified.", Me, PointToClient(hlpevent.MousePos), 50000)
    End Sub
#End Region
End Class