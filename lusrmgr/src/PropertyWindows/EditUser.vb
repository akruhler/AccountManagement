Imports DsEntry = System.DirectoryServices.DirectoryEntry
Imports ActiveDs

Public Class EditUser
    Private dsUserp As DsEntry
    Private userp As ActiveDs.IADsUser
    Private AD As ActiveDirectory

    Public Sub New()
        InitializeComponent()
        CopyContextMenu.Renderer = New clsMenuRenderer()
        OkButton.Top = 365
        CancelBtn.Top = 365
        ApplyButton.Top = 365
        GroupMembership.SmallImageList = MainForm.ListIcons
    End Sub

#Region "AD event handlers"

    Private Sub ObjectDeleted(User As String)
        If User = dsUserp.Name Then
            Close()
        End If
    End Sub

    Private Sub UsernameChanged(User As String, newName As String)
        If dsUserp.Name = User Then
            dsUserp = AD.FindUser(newName, Handle)
            If dsUserp Is Nothing Then
                Close()
            End If

            userp = dsUserp.IADsU()

            Text = AD.GetDisplayName() & "/" & newName
            UserLabel.Text = "User settings for " & Text

            UserNameTextBox.Text = newName
        End If
    End Sub

    Private Sub ChangeDisplayName(newName As String)
        Text = newName & "/" & dsUserp.Name
        UserLabel.Text = "User settings for " & Text
    End Sub
#End Region

#Region "Window events"
    ''' <summary>
    ''' Shows the properties window.
    ''' Returns false if the user object cannot be found.
    ''' </summary>
    ''' <param name="Username"></param>
    ''' <param name="pAD"></param>
    ''' <returns></returns>
    Overloads Function Show(Username As String, pAD As ActiveDirectory) As Boolean
        AD = pAD

        dsUserp = pAD.FindUser(Username, Handle)
        If dsUserp Is Nothing Then
            Return False
        End If

        userp = dsUserp.IADsU()

        'Check whether the same properties window is already open
        If Not RegisterWindow(Me, userp.GetSID()) Then
            'If so, return, since the open window will be presented to the user
            Return True
        End If

        'Subscribe to AD events
        AddHandler pAD.OnDisconnect, AddressOf Me.Close
        AddHandler pAD.OnDeleteUser, AddressOf ObjectDeleted
        AddHandler pAD.OnRenameUser, AddressOf UsernameChanged
        AddHandler pAD.OnDisplayNameChange, AddressOf ChangeDisplayName

        'Load main info
        Text = pAD.GetDisplayName() & "/" & Username
        UserLabel.Text = "User settings for " & Text

        UserNameTextBox.Text = Username
        FullName.Text = userp.FullName
        Comment.Text = userp.Description
        SID.Text = userp.GetSID()

        'Load account flags
        AccountDisabled.Checked = userp.AccountDisabled
        unlockbtn.Enabled = userp.IsAccountLocked
        SmartcardRequired.Checked = dsUserp.GetUserFlag(ActiveDs.ADS_USER_FLAG.ADS_UF_SMARTCARD_REQUIRED)

        'Load password flags
        UserCantChangePw.Checked = dsUserp.GetUserFlag(ActiveDs.ADS_USER_FLAG.ADS_UF_PASSWD_CANT_CHANGE)
        PwNeverExpires.Checked = dsUserp.GetUserFlag(ActiveDs.ADS_USER_FLAG.ADS_UF_DONT_EXPIRE_PASSWD)
        PwNotRequired.Checked = dsUserp.GetUserFlag(ActiveDs.ADS_USER_FLAG.ADS_UF_PASSWD_NOTREQD)
        If dsUserp.PasswordExpired() Then
            UserMustChangePwOnNextLogon.Checked = True
        End If

        'Load password last changed
        Dim pwAge As Double = dsUserp.Properties("PasswordAge").Value
        If pwAge < 1 Then
            If UserMustChangePwOnNextLogon.Checked Then
                PwLastChanged.Text = "Password expired"
            Else
                PwLastChanged.Text = "Password has never been changed"
            End If
        Else
            PwLastChanged.Text = Now.AddSeconds(-pwAge)
        End If

        'Load password expiration date
        If UserMustChangePwOnNextLogon.Checked Then
            PwExpDate.Text = "Password expired"
        Else
            If Not PwNeverExpires.Checked Then
                Try
                    PwExpDate.Text = userp.PasswordExpirationDate
                Catch ex As Exception
                    PwExpDate.Text = "Never"
                End Try
            Else
                PwExpDate.Text = "Never"
            End If
        End If

        'Load account expiration date
        Try
            AccountExpDate.Value = userp.AccountExpirationDate.Date
            AccountExpTime.Value = userp.AccountExpirationDate
        Catch ex As Exception
            AccountNeverExpires.Checked = True
            AccountExpDate.Value = Today.AddDays(1)
            AccountExpTime.Value = Now
        End Try

        'Load last logon
        lastlogon.Text = dsUserp.Properties("LastLogin").Value
        If lastlogon.Text.Length = 0 Then
            lastlogon.Text = "User has never logged on"
        End If
        failedtimes.Text = dsUserp.Properties("BadPasswordAttempts").Value

        'Load profile tab
        Dim homedrv As String = dsUserp.Properties("HomeDirDrive").Value
        If homedrv = "" Then
            homedirL.Text = userp.HomeDirectory

            HomeLocalPath.Checked = True
        Else
            homedirR.Text = userp.HomeDirectory
            homedrvR.SelectedItem = homedrv

            HomeRemotePath.Checked = True
        End If
        ProfilePath.Text = userp.Profile
        ScriptPath.Text = userp.LoginScript

        UserLabel.Select()
        ApplyButton.Enabled = False

        MyBase.Show()
        Return True
    End Function

    Private Sub EditUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandler AD.OnDisconnect, AddressOf Me.Close
        RemoveHandler AD.OnDeleteUser, AddressOf ObjectDeleted
        RemoveHandler AD.OnRenameUser, AddressOf UsernameChanged
        RemoveHandler AD.OnDisplayNameChange, AddressOf ChangeDisplayName
    End Sub
#End Region

#Region "Main buttons"

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles GroupOK.Click, OkButton.Click
        If ApplyButton.Enabled Then ApplyButton_Click(Nothing, Nothing)
        Close()
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Close()
    End Sub

    Private Sub any_changed(sender As Object, e As EventArgs) Handles Comment.TextChanged, FullName.TextChanged, homedirL.TextChanged, homedirR.TextChanged, PwNeverExpires.CheckedChanged, AccountExpDate.ValueChanged, UserCantChangePw.CheckedChanged, UserMustChangePwOnNextLogon.CheckedChanged, AccountExpDate.ValueChanged, AccountDisabled.CheckedChanged, SmartcardRequired.CheckedChanged, homedrvR.SelectedIndexChanged, PwNotRequired.CheckedChanged, AccountNeverExpires.CheckedChanged, AccountExpTime.ValueChanged, ProfilePath.TextChanged, HomeLocalPath.CheckedChanged, HomeRemotePath.CheckedChanged, ScriptPath.TextChanged
        ApplyButton.Enabled = True
    End Sub

    Private Sub ApplyButton_Click(sender As Object, e As EventArgs) Handles ApplyButton.Click

        Dim FullNameChanged As Boolean = False

        If userp.FullName <> FullName.Text Then
            FullNameChanged = True
            userp.FullName = FullName.Text
        End If

        userp.Description = Comment.Text

        'Flags
        userp.AccountDisabled = AccountDisabled.Checked
        dsUserp.SetUserFlag(ADS_USER_FLAG.ADS_UF_SMARTCARD_REQUIRED, SmartcardRequired.Checked)
        dsUserp.SetUserFlag(ADS_USER_FLAG.ADS_UF_PASSWD_CANT_CHANGE, UserCantChangePw.Checked)
        dsUserp.SetUserFlag(ADS_USER_FLAG.ADS_UF_DONT_EXPIRE_PASSWD, PwNeverExpires.Checked)
        dsUserp.SetUserFlag(ADS_USER_FLAG.ADS_UF_PASSWD_NOTREQD, PwNotRequired.Checked)

        'Profile tab
        userp.Profile = ProfilePath.Text
        userp.LoginScript = ScriptPath.Text

        If HomeLocalPath.Checked Then
            userp.HomeDirectory = homedirL.Text
        End If

        If HomeRemotePath.Checked Then
            dsUserp.Properties("HomeDirDrive").Value = homedrvR.Text
            userp.HomeDirectory = homedirR.Text
        End If

        'Account expiration
        If AccountNeverExpires.Checked Then
            userp.AccountExpirationDate = Nothing
        Else
            userp.AccountExpirationDate = AccountExpDate.Value.AddTicks(AccountExpTime.Value.TimeOfDay.Ticks)
        End If

        If dsUserp.PasswordExpired() <> UserMustChangePwOnNextLogon.Checked Then
            If UserMustChangePwOnNextLogon.Checked Then
                dsUserp.ExpirePasswd()
                PwLastChanged.Text = "Password expired"
            Else
                dsUserp.RefreshExpiredPasswd()
                PwLastChanged.Text = Now
            End If
        End If

        Try
            dsUserp.CommitChanges()
            If FullNameChanged Then
                AD.UserFullNameChanged(dsUserp.Name, FullName.Text)
            End If
            dsUserp.RefreshCache()
        Catch ex As Runtime.InteropServices.COMException

            Select Case ShowCOMErr(ex.ErrorCode, Handle, ex.Message, UserNameTextBox.Text)
                Case False
                    'Administrator accounts cannot have the UserCantChangePw option disabled
                    If UserCantChangePw.Checked Then
                        UserCantChangePw.Checked = False
                        dsUserp.SetUserFlag(ADS_USER_FLAG.ADS_UF_PASSWD_CANT_CHANGE, False)
                    End If
                    'Try applying the remaining changes
                    Try
                        dsUserp.CommitChanges()
                        If FullNameChanged Then
                            AD.UserFullNameChanged(dsUserp.Name, FullName.Text)
                        End If
                        dsUserp.RefreshCache()
                    Catch exx As Runtime.InteropServices.COMException
                        Select Case ShowCOMErr(ex.ErrorCode, Handle, ex.Message, UserNameTextBox.Text)
                            Case COMErrResult.REFRESH, COMErrResult.UNKOWN_ERR
                                AD.RefreshDS()
                                Close()
                                Return
                        End Select
                    Catch exx As UnauthorizedAccessException
                        ShowPermissionDeniedErr(Handle)
                        Return
                    End Try
                Case COMErrResult.REFRESH, COMErrResult.UNKOWN_ERR
                    AD.RefreshDS()
                    Close()
                    Return
            End Select

        Catch ex As UnauthorizedAccessException
            ShowPermissionDeniedErr(Handle)
            Return
        End Try

        'Refresh the password expiration date field
        If UserMustChangePwOnNextLogon.Checked Then
            PwExpDate.Text = "Password expired"
        Else
            If Not PwNeverExpires.Checked Then
                Try
                    PwExpDate.Text = userp.PasswordExpirationDate
                Catch ex As Exception
                    PwExpDate.Text = "Never"
                End Try
            Else
                PwExpDate.Text = "Never"
            End If
        End If

        UserLabel.Select()
        ApplyButton.Enabled = False
    End Sub
#End Region

#Region "Dialog buttons"

    Private Sub ChangePw_Click(sender As Object, e As EventArgs) Handles SetPwButton.Click
        Using ChangePw As New SetPw
            If ChangePw.Show(dsUserp, AD) = Windows.Forms.DialogResult.OK Then

                dsUserp.RefreshCache()

                Dim ApplyEnabled As Boolean = ApplyButton.Enabled

                If dsUserp.PasswordExpired() Then
                    UserMustChangePwOnNextLogon.Checked = True
                    PwLastChanged.Text = "Password expired"
                    PwExpDate.Text = "Password expired"
                Else
                    UserMustChangePwOnNextLogon.Checked = False
                    'Load pw last changed
                    Dim pwAge As Double = dsUserp.Properties("PasswordAge").Value
                    PwLastChanged.Text = Now.AddSeconds(-pwAge)

                    'Refresh the password expiration date field
                    If Not PwNeverExpires.Checked Then
                        Try
                            PwExpDate.Text = userp.PasswordExpirationDate
                        Catch ex As Exception
                            PwExpDate.Text = "Never"
                        End Try
                    Else
                        PwExpDate.Text = "Never"
                    End If
                End If

                If Not ApplyEnabled Then
                    ApplyButton.Enabled = False
                End If
            End If
        End Using
    End Sub

    Private Sub TimesBtn_Click(sender As Object, e As EventArgs) Handles TimesBtn.Click
        Using TimesDialog As New Times
            If TimesDialog.EditTimes(dsUserp) = Windows.Forms.DialogResult.Retry Then
                AD.RefreshDS()
                Close()
            End If
        End Using
    End Sub
#End Region

#Region "UI handlers"

    Private Sub AccountNeverExpires_CheckedChanged(sender As Object, e As EventArgs) Handles AccountNeverExpires.CheckedChanged
        If AccountNeverExpires.Checked Then
            AccountExpDate.Enabled = False
            AccountExpTime.Enabled = False
        Else
            AccountExpDate.Enabled = True
            AccountExpTime.Enabled = True
        End If
    End Sub

    Private Sub PwNeverExp_Changed(sender As Object, e As EventArgs) Handles PwNeverExpires.CheckedChanged, SmartcardRequired.CheckedChanged
        If PwNeverExpires.Checked OrElse SmartcardRequired.Checked Then
            UserMustChangePwOnNextLogon.Checked = False
            UserMustChangePwOnNextLogon.Enabled = False
            If cfgBool("HideDisabledFlagInfo") = 0 Then
                disabledImg.Show()
            End If
        Else
            UserMustChangePwOnNextLogon.Enabled = True
            disabledImg.Hide()
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Dim l As Label = CopyContextMenu.SourceControl
        Clipboard.SetText(l.Text)
    End Sub

    Private Sub TabChanging(sender As Object, e As TabControlCancelEventArgs) Handles Tabs.Selecting

        UserIcon.Parent = e.TabPage
        UserLabel.Parent = e.TabPage

        If e.TabPageIndex <> 4 Then
            OkButton.Parent = e.TabPage
            CancelBtn.Parent = e.TabPage
            ApplyButton.Parent = e.TabPage

            AcceptButton = OkButton
            CancelButton = CancelBtn
        End If

        Select Case e.TabPageIndex
            Case 3
                Dim ApplyEnabled As Boolean = ApplyButton.Enabled

                If HomeLocalPath.Checked Then
                    If homedirL.TextLength = 0 Then
                        HomeLocalPath.Checked = False
                        If Not ApplyEnabled Then ApplyButton.Enabled = False
                    End If
                End If

                If HomeRemotePath.Checked Then
                    If homedirR.TextLength = 0 Then
                        HomeRemotePath.Checked = False
                        If Not ApplyEnabled Then ApplyButton.Enabled = False
                    End If
                End If
            Case 4
                GroupMembership.Items.Clear()
                AcceptButton = GroupOK

                Try
                    For Each g As IADs In userp.Groups()
                        GroupMembership.Items.Add(g.Name, 1)
                    Next
                Catch ex As Runtime.InteropServices.COMException

                    Select Case ShowCOMErr(ex.ErrorCode, Handle, ex.Message, userp.Name)
                        Case COMErrResult.REFRESH
                            AD.RefreshDS()
                            Close()
                        Case COMErrResult.UNKOWN_ERR
                            Close()
                    End Select
                    Return
                Catch ex As Exception
                    ShowUnknownErr(Handle, ex.Message)
                    Close()
                End Try
        End Select
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
#End Region

#Region "Group tab"

    Private Sub RmGroup_Click(sender As Object, e As EventArgs) Handles RmGroup.Click
        If GroupMembership.Items.Count = 0 Then Return

        'Show the "unable to logon due to no group membership" warning
        If GroupMembership.Items.Count - GroupMembership.SelectedItems.Count = 0 AndAlso Not userp.AccountDisabled Then

            If cfgBool("HideUserWithNoGroupWarning") = 0 Then
                Dim result As Integer
                Dim verif As Boolean

                Dim tdc As New TASKDIALOGCONFIG()
                tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)
                tdc.hwndParent = Handle

                tdc.pszWindowTitle = "Inaccessible account"
                tdc.pszMainInstruction = "No group membership specified for " & UserNameTextBox.Text
                tdc.pszContent = "If no group membership is specified, " & UserNameTextBox.Text & " won't be able to log on to Windows anymore. Continue?"

                tdc.dwCommonButtons = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON Or TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_CANCEL_BUTTON
                tdc.pszVerificationText = "Do not show this warning again"
                tdc.pszMainIcon = TD_WARNING

                TaskDialogIndirect(tdc, result, Nothing, verif)

                If verif Then
                    Config.SetVal("HideUserWithNoGroupWarning", 1, Handle)
                End If

                If result = TASKDIALOG_RESULT.IDCANCEL Then Return
            End If
        End If

        For Each item As ListViewItem In GroupMembership.SelectedItems

            Dim group As DsEntry = AD.FindGroup(item.Text, Handle)

            If group Is Nothing Then
                Close()
                Return
            End If

            Try
                group.IADsG().Remove(AD.GetPath(UserNameTextBox.Text, False))
                group.CommitChanges()
                item.Remove()
            Catch ex As UnauthorizedAccessException
                ShowPermissionDeniedErr(Handle)
                Return
            Catch ex As Runtime.InteropServices.COMException
                If ShowCOMErr(ex.ErrorCode, Handle, ex.Message, UserNameTextBox.Text) = COMErrResult.REFRESH Then
                    AD.RefreshDS()
                    Close()
                    Return
                End If
            End Try
        Next
    End Sub

    Private Sub GroupList_KeyDown(sender As Object, e As KeyEventArgs) Handles GroupMembership.KeyDown
        If e.KeyCode = Keys.Delete AndAlso RmGroup.Enabled Then
            RmGroup_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub GroupList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GroupMembership.SelectedIndexChanged
        If GroupMembership.SelectedIndices.Count > 0 Then
            RmGroup.Enabled = True
        Else : RmGroup.Enabled = False
        End If
    End Sub

    Private Sub AddToGrpBtn_Click(sender As Object, e As EventArgs) Handles AddToGrpBtn.Click
        AddToGroup.Show(userp.Name, AD, AddToGroup.SourceWindow.EditUser, GroupMembership)
    End Sub

    Private Sub ListView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles GroupMembership.ColumnWidthChanging
        e.NewWidth = GroupMembership.Columns(0).Width
        e.Cancel = True
    End Sub
#End Region

    Private Sub unlockbtn_Click(sender As Object, e As EventArgs) Handles unlockbtn.Click
        Try
            userp.IsAccountLocked = False
            dsUserp.CommitChanges()
            unlockbtn.Enabled = userp.IsAccountLocked
        Catch ex As UnauthorizedAccessException
            ShowPermissionDeniedErr(Handle)
        Catch exx As Runtime.InteropServices.COMException
            If ShowCOMErr(exx.ErrorCode, Handle, exx.Message, UserNameTextBox.Text) = COMErrResult.REFRESH Then
                AD.RefreshDS()
            End If
        End Try
    End Sub

#Region "Help and information"

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
#End Region
End Class