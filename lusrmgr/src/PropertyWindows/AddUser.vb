Imports DsEntry = System.DirectoryServices.DirectoryEntry
Imports ActiveDs

Public Class AddUser
    Private logontimes As Byte()
    Private AD As ActiveDirectory

    Public Shared showAdvanced As Boolean

    Public Sub New()
        InitializeComponent()
        GroupMembership.SmallImageList = MainForm.ListIcons
    End Sub

    Private Sub ChangeDisplayName(newName As String)
        UserLabel.Text = "Create new user on " & newName
    End Sub

    Shadows Sub Show(pAD As ActiveDirectory)
        AD = pAD
        AddHandler pAD.OnDisconnect, AddressOf Me.Close
        AddHandler pAD.OnDisplayNameChange, AddressOf ChangeDisplayName

        If showAdvanced Then
            MoreOption_Click(Nothing, Nothing)
        End If

        UserLabel.Text &= pAD.GetDisplayName()

        'Set all bits to true in the logontimes array, since all times are allowed by default
        logontimes = New Byte(20) {}
        For i As Integer = 0 To 20
            logontimes(i) = 255
        Next

        AccountExpDate.Value = Today.AddDays(1)
        AccountExpTime.Value = Now

        'Add the default user group
        If Not AD.UserGroupUnavailable() AndAlso AD.UserGroup IsNot Nothing Then
            GroupMembership.Items.Add(AD.UserGroup.Name, 1)
        End If

        MyBase.Show()
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

            showAdvanced = False
            MoreOptions.Text = "Advanced >>"
        Else
            Width += 415
            Left -= 415 / 2

            FlowLayoutPanel1.Width = 415

            showAdvanced = True
            MoreOptions.Text = "<< Advanced"
        End If
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If Not Password.Text = PasswordConfirm.Text Then
            TaskDialog(Handle, "Local users and groups", "Passwords do not match", "The passwords do not match.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return
        End If

        Dim newUser As DsEntry
        Try
            newUser = AD.CreateUser(UserNameTextBox.Text, FullName.Text)
            Dim INewUser As IADsUser = newUser.IADsU()

            INewUser.Description = Comment.Text

            'User flags
            Dim UserFlags As Integer = newUser.Properties("UserFlags").Value

            SetUserFlag(UserFlags, ADS_USER_FLAG.ADS_UF_ACCOUNTDISABLE, AccountDisabled.Checked)
            SetUserFlag(UserFlags, ADS_USER_FLAG.ADS_UF_SMARTCARD_REQUIRED, SmartcardRequired.Checked)
            SetUserFlag(UserFlags, ADS_USER_FLAG.ADS_UF_PASSWD_CANT_CHANGE, UserCantChangePw.Checked)
            SetUserFlag(UserFlags, ADS_USER_FLAG.ADS_UF_DONT_EXPIRE_PASSWD, PwNeverExpires.Checked)
            SetUserFlag(UserFlags, ADS_USER_FLAG.ADS_UF_PASSWD_NOTREQD, PwNotRequired.Checked)

            newUser.Properties("UserFlags").Value = UserFlags

            'Profile
            Dim homedir As String = ""
            Dim homedrv As String = ""

            If HomeLocalPath.Checked Then
                homedir = homedirL.Text
            ElseIf HomeRemotePath.Checked Then
                homedir = homedirR.Text
                homedrv = homedrvR.Text
            End If

            INewUser.HomeDirectory = homedir
            newUser.Properties("HomeDirDrive").Value = homedrv
            INewUser.Profile = ProfilePath.Text
            INewUser.LoginScript = ScriptPath.Text

            INewUser.LoginHours = logontimes

            If Not AccountNeverExpires.Checked Then
                INewUser.AccountExpirationDate = AccountExpDate.Value.AddTicks(AccountExpTime.Value.TimeOfDay.Ticks)
            End If

            newUser.CommitChanges()

            INewUser.SetPassword(Password.Text)

            If UserMustChangePwOnNextLogon.Checked Then
                newUser.ExpirePasswd()
            End If

            newUser.CommitChanges()

        Catch ex As UnauthorizedAccessException
            ShowPermissionDeniedErr(Handle)
            Return
        Catch ex As Runtime.InteropServices.COMException
            If ex.ErrorCode = COMErrorCodes.PW_POLICY Then
                If Password.TextLength > 0 Then
                    Dim body As String
                    If SmartcardRequired.Checked OrElse PwNeverExpires.Checked Then
                        body = "The password you entered does not meet the password policy requirements and could therefore not be applied." &
                               vbCrLf & "No password is assigned to the user."
                    Else
                        body = "The password you entered does not meet the password policy requirements and could therefore not be applied." &
                              vbCrLf & "The user will be prompted to set a password the first time they log on."
                    End If
                    TaskDialog(Handle, "Account password", "Password does not meet requirements", body, TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_WARNING_ICON, 0)
                End If
                If Not SmartcardRequired.Checked AndAlso Not PwNeverExpires.Checked Then
                    newUser.ExpirePasswd()
                    newUser.CommitChanges()
                End If
            Else
                ShowCOMErr(ex.ErrorCode, Handle, ex.Message)
                Return
            End If
        Catch ex As Exception
            TaskDialog(Handle, "Local users and groups", "An unkown error occurred", ex.Message.Replace(vbCrLf, ""), TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return
        End Try

        If GroupMembership.Items.Count > 0 Then
            Try
                For Each Group As ListViewItem In GroupMembership.Items
                    Dim g As DsEntry = AD.FindGroup(Group.Text, Handle)
                    If g Is Nothing Then Continue For

                    g.IADsG().Add(AD.GetPath(UserNameTextBox.Text, False))
                    g.CommitChanges()
                Next
            Catch ex As UnauthorizedAccessException
                ShowPermissionDeniedErr(Handle)
                Return
            Catch ex As Runtime.InteropServices.COMException
                If ShowCOMErr(ex.ErrorCode, Handle, ex.Message) = COMErrResult.REFRESH Then
                    AD.RefreshDS()
                End If
                Return
            Catch ex As Exception
                ShowUnknownErr(Handle, ex.Message, "Issue occurred at: AddNewUser")
                Return
            End Try

        Else

            If Not AD.UserGroupUnavailable() Then

                If AD.UserGroup Is Nothing Then

                    If cfgBool("HideUserWithNoGroupWarning") = 0 Then
                        Dim result As Integer
                        Dim verif As Boolean

                        Dim tdc As New TASKDIALOGCONFIG()
                        tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)
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
                        Try
                            AD.UserGroup.IADsG().Add(newUser.Path)
                            AD.UserGroup.CommitChanges()
                        Catch ex As Exception
                        End Try
                    End If
                End If
            Else
                If Not showAdvanced Then

                    If cfgBool("HideUserWithNoGroupWarning") = 0 Then
                        Dim result As Integer
                        Dim verif As Boolean

                        Dim tdc As New TASKDIALOGCONFIG()
                        tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)
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

        Close()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UserNameTextBox.KeyPress
        If isDisallowed(e.KeyChar) Then e.KeyChar = Nothing : SymbolDisallowedTooltip.Show("The symbols / \ [ ] "" : ; | < > + = , ? * % @ cannot be used in user names.", UserNameTextBox, 3000)
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GroupMembership.KeyDown
        If e.KeyCode = Keys.Delete AndAlso RmGroup.Enabled Then
            RmGroup_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles GroupMembership.ColumnWidthChanging
        e.NewWidth = GroupMembership.Columns(0).Width
        e.Cancel = True
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles PwNeverExpires.CheckedChanged, SmartcardRequired.CheckedChanged
        If PwNeverExpires.Checked Or SmartcardRequired.Checked Then
            UserMustChangePwOnNextLogon.Checked = False
            UserMustChangePwOnNextLogon.Enabled = False
        Else
            UserMustChangePwOnNextLogon.Enabled = True
        End If
    End Sub

    Private Sub HomeLocalPath_CheckedChanged(sender As Object, e As EventArgs) Handles HomeLocalPath.CheckedChanged
        homedirL.Enabled = HomeLocalPath.Checked
    End Sub

    Private Sub HomeRemotePath_CheckedChanged(sender As Object, e As EventArgs) Handles HomeRemotePath.CheckedChanged
        If HomeRemotePath.Checked Then
            homedirR.Enabled = True
            homedrvR.Enabled = True
            Label16.Enabled = True
            Label17.Enabled = True
        Else
            homedirR.Enabled = False
            homedrvR.Enabled = False
            Label16.Enabled = False
            Label17.Enabled = False
        End If
    End Sub

    Private Sub AccountNeverExpires_CheckedChanged(sender As Object, e As EventArgs) Handles AccountNeverExpires.CheckedChanged
        If AccountNeverExpires.Checked Then
            AccountExpDate.Enabled = False
            AccountExpTime.Enabled = False
        Else
            AccountExpDate.Enabled = True
            AccountExpTime.Enabled = True
        End If
    End Sub

    Private Sub TimesBtn_Click(sender As Object, e As EventArgs) Handles TimesBtn.Click
        Using TimesDialog As New Times
            logontimes = TimesDialog.GetTimes(logontimes)
        End Using
    End Sub

    Private Sub AddToGrpBtn_Click(sender As Object, e As EventArgs) Handles AddToGrpBtn.Click
        AddToGroup.Show(Nothing, AD, AddToGroup.SourceWindow.AddUser, GroupMembership)
    End Sub

    Private Sub GroupMembership_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GroupMembership.SelectedIndexChanged
        If GroupMembership.SelectedIndices.Count > 0 Then
            RmGroup.Enabled = True
        Else : RmGroup.Enabled = False
        End If
    End Sub

    Dim isAwareOfNoGroup As Boolean

    Private Sub RmGroup_Click(sender As Object, e As EventArgs) Handles RmGroup.Click
        If GroupMembership.Items.Count = 0 Then Return

        For Each item As ListViewItem In GroupMembership.SelectedItems

            If GroupMembership.Items.Count = 1 AndAlso Not AccountDisabled.Checked Then
                If cfgBool("HideUserWithNoGroupWarning") = 0 Then
                    Dim result As Integer
                    Dim verif As Boolean

                    Dim tdc As New TASKDIALOGCONFIG()
                    tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)
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

    Private Sub warnChanged(sender As Object, e As EventArgs) Handles UserCantChangePw.CheckedChanged, UserMustChangePwOnNextLogon.CheckedChanged
        If cfgBool("HideWarningCantchgpasswd") = True Then Return

        If UserCantChangePw.Checked AndAlso UserMustChangePwOnNextLogon.Checked Then
            warnImg.Show()
        Else
            warnImg.Hide()
        End If
    End Sub

    Private Sub warnImg_Click(sender As Object, e As EventArgs) Handles warnImg.Click
        Dim tdc As New TASKDIALOGCONFIG()
        tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)
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

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
    End Sub

    Private Sub AddUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandler AD.OnDisconnect, AddressOf Close
        RemoveHandler AD.OnDisplayNameChange, AddressOf ChangeDisplayName
    End Sub
End Class