Imports DsEntry = System.DirectoryServices.DirectoryEntry
Public Class AddUser
    Dim logontimes As Byte()
    Dim mForma As Form1

    Overloads Sub Show(mainForm As Form1)
        mForma = mainForm

        If mainForm.showAdvanced Then
            MoreOption_Click(Nothing, Nothing)
        End If

        If mainForm.connectedADs.Count > 0 Then
            Text &= " on " & mainForm.currentAD().displayName
        End If

        logontimes = New Byte(20) {}

        For i As Integer = 0 To 20
            logontimes(i) = 255
        Next

        accexpireD.Value = Today.AddDays(1)

        addUserGroup()

        ShowDialog()
        Dispose()
    End Sub

    Private Async Sub addUserGroup()
        While True
            'Didn't find the user's group
            If mForma.currentAD().NoUserGroup Then
                errimg.Image = SystemIcons.Error.ToBitmap()
                errmsg.Text = "An unkown error occurred whilst retrieving" & vbCrLf & "the users group. You'll have to assign" & vbCrLf & "group membership manually if the user" & vbCrLf & "should be able to log on to Windows."
                errmsg.Show()
                errimg.Show()
                Button8.Enabled = True
                Exit While
            End If

            'Successfully found the user's group
            If Not mForma.currentAD().NoUserGroup AndAlso mForma.currentAD().UserGroup IsNot Nothing Then
                ListView1.Items.Add(mForma.currentAD().UserGroup.Name, 0)
                errmsg.Hide()
                errimg.Hide()
                Button8.Enabled = True
                Return
            End If

            'Still buffering
            If mForma.currentAD().UserGroup Is Nothing AndAlso Not mForma.currentAD().NoUserGroup Then
                errimg.Image = SystemIcons.Warning.ToBitmap()
                errmsg.Show()
                errimg.Show()
                Button8.Enabled = False
            End If

            Await Task.Delay(600)
        End While

        While ListView1.Items.Count = 0
            Await Task.Delay(600)
        End While
        errmsg.Hide()
        errimg.Hide()
    End Sub

    Private Sub UserNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles UserNameTextBox.TextChanged
        If UserNameTextBox.Text = Nothing Then
            OkButton.Enabled = False
        Else
            For Each c As Char In UserNameTextBox.Text.ToCharArray()
                If Not c = " "c Then
                    OkButton.Enabled = True
                    Return
                End If
            Next
            OkButton.Enabled = False
        End If
    End Sub

    Private Sub MoreOption_Click(sender As Object, e As EventArgs) Handles MoreOptions.Click
        If MoreOptions.Text = "<< Advanced" Then
            Width -= 415
            Left += 415 / 2

            FlowLayoutPanel1.Width = 0

            mForma.showAdvanced = False
            MoreOptions.Text = "Advanced >>"
        Else
            Width += 415
            Left -= 415 / 2

            FlowLayoutPanel1.Width = 415

            mForma.showAdvanced = True
            MoreOptions.Text = "<< Advanced"
        End If
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If Not TextBox4.Text = TextBox3.Text Then
            TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Passwords do not match", "The passwords do not match each other.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return
        End If

        If mForma.currentAD().isLoading() Then
            TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Account database is still loading", "The account database on which you wish to create the new user is still being retrieved. Please try again in a few moments.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_WARNING_ICON, 0)
            Return
        End If

        Dim newUser As DsEntry
        Try
            Dim homedir As String = ""
            Dim homedrv As String = ""

            If RadioButton1.Checked Then
                homedir = homedirL.Text
            ElseIf RadioButton2.Checked Then
                homedir = homedirR.Text
                homedrv = homedrvR.Text
            End If

            newUser = mForma.currentAD().CreateUser(
                UserNameTextBox.Text,
                TextBox4.Text,
                FullName.Text,
                Comment.Text,
                accdisabled.Checked,
                pwchangenextlogon.Checked,
                pwcantchange.Checked,
                pwneverex.Checked,
                pwrevencryption.Checked,
                pwnotrequired.Checked,
                smartcardreq.Checked,
                homedir,
                homedrv,
                accexpireD.Value,
                accexpireC.Checked,
                logonscript.Text,
                logontimes)

        Catch ex As UnauthorizedAccessException
            TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Access denied", "You are not allowed to perform this operation. Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return
        Catch ex As Runtime.InteropServices.COMException
            ShowCOMErr(ex.ErrorCode, Handle, ex.Message)
            Return
        Catch ex As Exception
            TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "An unkown error ocurred", ex.Message.Replace(vbNewLine, ""), TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return
        End Try

        If ListView1.Items.Count > 0 Then

            For Each Group As ListViewItem In ListView1.Items
                Dim g As DsEntry = mForma.currentAD().FindGroup(Group.Text, Handle)
                If g Is Nothing Then Continue For

                g.IADsG().Add(newUser.Path)
                g.CommitChanges()
            Next

        Else

            If Not mForma.currentAD().NoUserGroup Then

                If mForma.currentAD().UserGroup Is Nothing Then

                    If cfgBool("HideUserWithNoGroupWarning") = 0 Then
                        Dim result As Integer
                        Dim verif As Boolean

                        Dim tdc As New TASKDIALOGCONFIG()
                        tdc.cbSize = sizeof(tdc)
                        tdc.hwndParent = Handle

                        tdc.pszWindowTitle = "Group error"
                        tdc.pszMainInstruction = "Users group could not be retrieved"
                        tdc.pszContent = "An unknown error occurred, the Users group could not be retrieved." & vbCrLf & "The user you create will not be assigned to any group. If you keep getting this message, Please contact the developer."

                        tdc.dwCommonButtons = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON
                        tdc.pszVerificationText = "Do not show this warning again"
                        tdc.pszMainIcon = TD_ERROR_ICON

                        TaskDialogIndirect(tdc, result, Nothing, verif)

                        If verif Then
                            Config.SetVal("HideUserWithNoGroupWarning", 1, Handle)
                        End If

                        If result = TASKDIALOG_RESULT.IDCANCEL Then Return
                    End If

                Else
                    If Not isAwareOfNoGroup Then
                        'Try
                        mForma.currentAD().UserGroup.IADsG().Add(newUser.Path)
                        mForma.currentAD().UserGroup.CommitChanges()
                        'Catch ex As Exception
                        'End Try
                    End If
                End If
            Else
                If Not mForma.showAdvanced Then

                    If cfgBool("HideUserWithNoGroupWarning") = 0 Then
                        Dim result As Integer
                        Dim verif As Boolean

                        Dim tdc As New TASKDIALOGCONFIG()
                        tdc.cbSize = sizeof(tdc)
                        tdc.hwndParent = Handle

                        tdc.pszWindowTitle = "Group error"
                        tdc.pszMainInstruction = "Users group could not be retrieved"
                        tdc.pszContent = "An unknown error occurred, the Users group could not be retrieved." & vbCrLf & "The user you create will not be assigned to any group. If you keep getting this message, Please contact the developer."

                        tdc.dwCommonButtons = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON
                        tdc.pszVerificationText = "Do not show this warning again"
                        tdc.pszMainIcon = TD_ERROR_ICON

                        TaskDialogIndirect(tdc, result, Nothing, verif)

                        If verif Then
                            Config.SetVal("HideUserWithNoGroupWarning", 1, Handle)
                        End If

                        If result = TASKDIALOG_RESULT.IDCANCEL Then Return
                    End If
                End If
            End If

        End If

        mForma.currentAD().RefreshDS()
        mForma.refreshItemCount()
        Close()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UserNameTextBox.KeyPress
        If Form1.disallowedChars.Contains(e.KeyChar) Then e.KeyChar = Nothing : ToolTip1.Show("The symbols / \ [ ] "" : ; | < > + = , ? * % @ cannot be used in user names.", UserNameTextBox, 3000)
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Delete AndAlso Button7.Enabled Then
            Button7_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles ListView1.ColumnWidthChanging
        e.NewWidth = ListView1.Columns(0).Width
        e.Cancel = True
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles pwneverex.CheckedChanged, smartcardreq.CheckedChanged
        If pwneverex.Checked Or smartcardreq.Checked Then
            pwchangenextlogon.Checked = False
            pwchangenextlogon.Enabled = False
        Else
            pwchangenextlogon.Enabled = True
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            homedirL.Enabled = True
        Else
            homedirL.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            homedirR.Enabled = True
            homedrvR.Enabled = True
            Label6.Enabled = True
            Label7.Enabled = True
        Else
            homedirR.Enabled = False
            homedrvR.Enabled = False
            Label6.Enabled = False
            Label7.Enabled = False
        End If
    End Sub

    Private Sub accneverexp_changed(sender As Object, e As EventArgs) Handles accexpireC.CheckedChanged
        If accexpireC.Checked Then
            accexpireD.Enabled = False
        Else : accexpireD.Enabled = True
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Times.Show(logontimes)
        logontimes = Times.uArr
        Times.Dispose()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim open As New OpenFileDialog
        open.FileName = ""
        open.Filter = "All files|*.*"
        open.Title = "Select logon script"

        If (open.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            logonscript.Text = open.FileName
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        AddToGroup.Show(Nothing, mForma, AddToGroup.SourceWindow.AddUser)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedIndices.Count > 0 Then
            Button7.Enabled = True
        Else : Button7.Enabled = False
        End If
    End Sub

    Dim isAwareOfNoGroup As Boolean

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If ListView1.Items.Count = 0 Then Return

        For Each item As ListViewItem In ListView1.SelectedItems

            If ListView1.Items.Count = 1 Then
                If cfgBool("HideUserWithNoGroupWarning") = 0 Then
                    Dim result As Integer
                    Dim verif As Boolean

                    Dim tdc As New TASKDIALOGCONFIG()
                    tdc.cbSize = sizeof(tdc)
                    tdc.hwndParent = Handle

                    tdc.pszWindowTitle = "Inaccessible account"

                    If OkButton.Enabled = False Then
                        tdc.pszMainInstruction = "No group membership specified"
                        tdc.pszContent = "If no group membership is specified, the user won't be able to log on to Windows. Continue?"
                    Else
                        tdc.pszMainInstruction = "No group membership specified for " & UserNameTextBox.Text
                        tdc.pszContent = "If no group membership is specified, " & UserNameTextBox.Text & " won't be able to log on to Windows. Continue?"
                    End If

                    tdc.dwCommonButtons = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON Or TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_CANCEL_BUTTON
                    tdc.pszVerificationText = "Do not show this warning again"
                    tdc.pszMainIcon = TD_WARNING

                    TaskDialogIndirect(tdc, result, Nothing, verif)

                    If verif Then
                        Config.SetVal("HideUserWithNoGroupWarning", 1, Handle)
                    End If

                    If result = TASKDIALOG_RESULT.IDCANCEL Then Return
                End If

                isAwareOfNoGroup = True
            End If

            item.Remove()
            FlowLayoutPanel1.AutoScrollPosition = New Point(0, 9999)
        Next
    End Sub

    Private Sub warnChanged(sender As Object, e As EventArgs) Handles pwcantchange.CheckedChanged, pwchangenextlogon.CheckedChanged
        If cfgBool("HideWarningCantchgpasswd") = True Then Return

        If pwcantchange.Checked AndAlso pwchangenextlogon.Checked Then
            warnImg.Show()
        Else
            warnImg.Hide()
        End If
    End Sub

    Private Sub warnImg_Click(sender As Object, e As EventArgs) Handles warnImg.Click
        Dim tdc As New TASKDIALOGCONFIG()
        tdc.cbSize = sizeof(tdc)
        tdc.hwndParent = Handle


        tdc.pszWindowTitle = "Inaccessible account"
        tdc.pszMainInstruction = "User won't be able to log on"
        tdc.pszContent = "The user's permission to change its password is not granted, but the user must change it before logging in the next time." & vbCrLf & "This will result in an inaccessible account."

        tdc.dwCommonButtons = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON
        tdc.pszVerificationText = "Hide this warning"
        tdc.pszMainIcon = TD_WARNING

        Dim verif As Boolean

        TaskDialogIndirect(tdc, 0, 0, verif)

        If verif Then
            Config.SetVal("HideWarningCantchgpasswd", 1, Handle)
            warnImg.Hide()
        End If
    End Sub

    'Private Sub AddUser_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged

    'End Sub
End Class