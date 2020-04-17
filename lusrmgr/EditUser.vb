Imports DsEntry = System.DirectoryServices.DirectoryEntry
Imports ActiveDs

Public Class EditUser
    Dim dsUserp As DsEntry
    Dim userp As ActiveDs.IADsUser
    Dim oList As New List(Of sOption)()
    Dim mForma As Form1

    Function findByName(name As String) As Boolean
        If oList.Find(Function(s As sOption) As Boolean
                          If (s.cNew.Name = name) Then
                              Return True
                          End If
                          Return False
                      End Function) Then
            Return False
        End If
        Return True
    End Function

    Class sOption
        Public old As Object
        Public cNew As Control
        Public type As type_

        Public Enum type_
            Text = 1
            Check = 2
            Date_ = 3
            Combo_ = 4
        End Enum

        Public Sub update()
            Select Case type
                Case type_.Text
                    old = cNew.Text
                Case type_.Check
                    Dim c As CheckBox = cNew
                    old = c.Checked
                Case type_.Date_
                    Dim d As DateTimePicker = cNew
                    old = d.Value.ToShortDateString()
                Case type_.Combo_
                    Dim cb As ComboBox = cNew
                    old = cb.Text
            End Select
        End Sub

        Public Sub update(o As Object)
            old = o
        End Sub

        Public Shared Operator IsTrue(s As sOption) As Boolean
            Select Case s.type
                Case type_.Text
                    If s.cNew.Text = s.old Then Return True
                    Return False
                Case type_.Check
                    Dim c As CheckBox = s.cNew
                    If c.Checked = s.old Then Return True
                    Return False
                Case type_.Date_
                    Dim d As DateTimePicker = s.cNew
                    If d.Value.ToShortDateString() = s.old Then Return True
                    Return False
                Case type_.Combo_
                    Dim cb As ComboBox = s.cNew
                    If cb.Text = s.old Then Return True
                    Return False
            End Select

            Return False
        End Operator

        Public Shared Operator IsFalse(s As sOption) As Boolean
            Select Case s.type
                Case type_.Text
                    If s.cNew.Text = s.old Then Return False
                    Return True
                Case type_.Check
                    Dim c As CheckBox = s.cNew
                    If c.Checked = s.old Then Return False
                    Return True
                Case type_.Date_
                    Dim d As DateTimePicker = s.cNew
                    If d.Value.ToShortDateString() = s.old Then Return False
                    Return True
                Case type_.Combo_
                    Dim cb As ComboBox = s.cNew
                    If cb.Text = s.old Then Return False
                    Return True
            End Select

            Return True
        End Operator

        Public Sub New(t As TextBox)
            old = t.Text
            cNew = t
            type = type_.Text
        End Sub

        Public Sub New(c As CheckBox)
            old = c.Checked
            cNew = c
            type = type_.Check
        End Sub

        Public Sub New(d As DateTimePicker)
            old = d.Value.ToShortDateString()
            cNew = d
            type = type_.Date_
        End Sub

        Public Sub New(cb As ComboBox)
            old = cb.Text
            cNew = cb
            type = type_.Combo_
        End Sub
    End Class

    Public Sub New()
        InitializeComponent()
        ContextMenuStrip1.Renderer = New clsMenuRenderer()
    End Sub

    Overloads Function Show(Username As String, mainForm As Form1) As Boolean
        mForma = mainForm

        dsUserp = mForma.currentAD().FindUser(Username, Handle)
        If dsUserp Is Nothing Then
            Return False
        End If

        userp = dsUserp.IADsU()

        '//////////////// LOAD MAIN INFO ///////////////////
        If mainForm.connectedADs.Count = 0 Then
            UserLabel.Text = "User settings for " & Username
            Text = Username
        Else
            UserLabel.Text = "User settings for " & mainForm.currentAD().displayName & "/" & Username
            Text = mainForm.currentAD().displayName & "/" & Username
        End If

        UserNameTextBox.Text = Username
        FullName.Text = userp.FullName

        '//////////////// LOAD COMMENT ///////////////////
        Comment.Text = userp.Description


        '//////////////// LOAD SID ///////////////////
        SID.Text = userp.SID()

        '//////////////// LOAD DISABLED ///////////////////
        bDisabled.Checked = userp.AccountDisabled

        '//////////////// LOAD CAN CHGPW ///////////////////
        bCantChgPasswd.Checked = dsUserp.GetUserFlag(ActiveDs.ADS_USER_FLAG.ADS_UF_PASSWD_CANT_CHANGE)

        '//////////////// LOAD CAN PW EXPIRE ///////////////////
        bPNeverExp.Checked = dsUserp.GetUserFlag(ActiveDs.ADS_USER_FLAG.ADS_UF_DONT_EXPIRE_PASSWD)

        '//////////////// LOAD PWCHG AT NEXT LOGON ///////////////////
        If dsUserp.Properties("PasswordExpired").Value = 1 Then
            bChgPNextLogon.Checked = True
        End If

        '// Load other tabs
        Dim homedrv As String = dsUserp.InvokeGet("HomeDirDrive")

        If homedrv = "" Then
            homedirL.Text = userp.HomeDirectory

            RadioButton1.Checked = True
        Else
            homedirR.Text = userp.HomeDirectory
            homedrvR.SelectedItem = homedrv

            RadioButton2.Checked = True
        End If

        scriptpath.Text = userp.LoginScript

        bSmartcard.Checked = dsUserp.GetUserFlag(ActiveDs.ADS_USER_FLAG.ADS_UF_SMARTCARD_REQUIRED)
        pwrvencryption.Checked = dsUserp.GetUserFlag(ActiveDs.ADS_USER_FLAG.ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED)
        pwnotrequired.Checked = dsUserp.GetUserFlag(ActiveDs.ADS_USER_FLAG.ADS_UF_PASSWD_NOTREQD)

        unlockbtn.Enabled = userp.IsAccountLocked

        If userp.IsAccountLocked Then
            acclockoutdate.Text = "Account is locked out"
        Else
            acclockoutdate.Text = "Account is not locked out"
        End If

        Try
            accexpire.Value = userp.AccountExpirationDate.Date
        Catch ex As Runtime.InteropServices.COMException
            bAccNeverExp.Checked = True
            accexpire.Enabled = False
            accexpire.Value = Today.AddDays(1)
        End Try

        lastlogon.Text = dsUserp.Properties("LastLogin").Value
        If lastlogon.Text.Length = 0 Then
            lastlogon.Text = "User has never logged on"
        End If

        Dim pwAge As Double = dsUserp.Properties("PasswordAge").Value
        If pwAge < 1 Then
            If bChgPNextLogon.Checked Then
                lastpwchanged.Text = "Password expired"
            Else
                lastpwchanged.Text = "Password has never been changed"
            End If
        Else
            lastpwchanged.Text = Now.AddSeconds(-pwAge)
        End If

        failedtimes.Text = dsUserp.Properties("BadPasswordAttempts").Value

        UserLabel.Select()
        ApplyButton.Enabled = False

        oList.Add(New sOption(FullName))
        oList.Add(New sOption(Comment))

        oList.Add(New sOption(scriptpath))
        oList.Add(New sOption(bSmartcard))
        oList.Add(New sOption(bDisabled))

        oList.Add(New sOption(homedirL))
        oList.Add(New sOption(homedirR))
        oList.Add(New sOption(homedrvR))

        oList.Add(New sOption(bPNeverExp))
        oList.Add(New sOption(bChgPNextLogon))
        oList.Add(New sOption(bCantChgPasswd))
        oList.Add(New sOption(pwrvencryption))
        oList.Add(New sOption(pwnotrequired))

        oList.Add(New sOption(accexpire))
        oList.Add(New sOption(bAccNeverExp))

        ShowDialog()
        Dispose()

        Return True
    End Function

    Private Sub ChangePw_Click(sender As Object, e As EventArgs) Handles ChangePwButton.Click
        If ChangePw.Show(dsUserp, mForma) = Windows.Forms.DialogResult.OK Then

            dsUserp = mForma.currentAD().FindUser(dsUserp.Name, Handle)
            If dsUserp Is Nothing Then
                Close()
                mForma.refreshItemCount()
                Return
            End If
            userp = dsUserp.IADsU()

            If Not ApplyButton.Enabled Then
                If dsUserp.Properties("PasswordExpired").Value = 1 Then

                    oList.Find(Function(s As sOption) As Boolean
                                   If (s.cNew.Name = "bChgPNextLogon") Then
                                       Return True
                                   End If
                                   Return False
                               End Function).update(True)

                    bChgPNextLogon.Checked = True
                    lastpwchanged.Text = "Password expired"
                Else
                    oList.Find(Function(s As sOption) As Boolean
                                   If (s.cNew.Name = "bChgPNextLogon") Then
                                       Return True
                                   End If
                                   Return False
                               End Function).update(False)

                    bChgPNextLogon.Checked = False
                End If
            End If
        End If
    End Sub

    Private Sub ApplyButton_Click(sender As Object, e As EventArgs) Handles ApplyButton.Click, Apply2.Click, Apply3.Click, Apply4.Click

        If findByName("FullName") Then userp.FullName = FullName.Text
        If findByName("Comment") Then userp.Description = Comment.Text

        If findByName("scriptpath") Then userp.LoginScript = scriptpath.Text

        If RadioButton1.Checked Then
            If findByName("homedirL") Then userp.HomeDirectory = homedirL.Text
        End If

        If RadioButton2.Checked Then
            If findByName("homedrvR") Then dsUserp.InvokeSet("HomeDirDrive", homedrvR.Text)
            If findByName("homedirR") Then userp.HomeDirectory = homedirR.Text
        End If

        If findByName("bDisabled") Then
            userp.AccountDisabled = bDisabled.Checked
        End If

        If findByName("bCantChgPasswd") Then dsUserp.SetUserFlag(ADS_USER_FLAG.ADS_UF_PASSWD_CANT_CHANGE, bCantChgPasswd.Checked)
        If findByName("bPNeverExp") Then dsUserp.SetUserFlag(ADS_USER_FLAG.ADS_UF_DONT_EXPIRE_PASSWD, bPNeverExp.Checked)
        If findByName("pwrvencryption") Then dsUserp.SetUserFlag(ADS_USER_FLAG.ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED, pwrvencryption.Checked)
        If findByName("pwnotrequired") Then dsUserp.SetUserFlag(ADS_USER_FLAG.ADS_UF_PASSWD_NOTREQD, pwnotrequired.Checked)
        If findByName("bSmartcard") Then dsUserp.SetUserFlag(ADS_USER_FLAG.ADS_UF_SMARTCARD_REQUIRED, bSmartcard.Checked)

        If findByName("accexpire") OrElse findByName("bAccNeverExp") Then
            If bAccNeverExp.Checked Then
                userp.AccountExpirationDate = Nothing
            Else
                userp.AccountExpirationDate = accexpire.Value
            End If
        End If

        Try
            dsUserp.CommitChanges()
            If findByName("bChgPNextLogon") Then
                If bChgPNextLogon.Checked Then
                    dsUserp.ExpirePasswd()
                    lastpwchanged.Text = "Password expired"
                Else
                    dsUserp.RefreshExpiredPasswd()
                    lastpwchanged.Text = Now
                End If
                dsUserp.CommitChanges()
            End If
        Catch ex As Runtime.InteropServices.COMException

            Select Case ShowCOMErr(ex.ErrorCode, Handle, ex.Message, UserNameTextBox.Text)
                Case False
                    '//Again because some accounts can't have this option disabled ( Admins for instance )
                    If bCantChgPasswd.Checked Then
                        bCantChgPasswd.Checked = False
                        dsUserp.SetUserFlag(ADS_USER_FLAG.ADS_UF_PASSWD_CANT_CHANGE, False)
                    End If
                Case COMErrResult.REFRESH
                    mForma.currentAD().RefreshDS()
                    mForma.refreshItemCount()
                    Close()
                    Return
                Case COMErrResult.UNKOWN_ERR
                    mForma.currentAD().RefreshDS()
                    Close()
                    Return
            End Select

            Try
                dsUserp.CommitChanges()
                If findByName("bChgPNextLogon") Then
                    If bChgPNextLogon.Checked Then
                        dsUserp.ExpirePasswd()
                        lastpwchanged.Text = "Password expired"
                    Else
                        dsUserp.RefreshExpiredPasswd()
                        lastpwchanged.Text = Now
                    End If
                    dsUserp.CommitChanges()
                End If
            Catch exx As Runtime.InteropServices.COMException

                Select Case ShowCOMErr(exx.ErrorCode, Handle, exx.Message, UserNameTextBox.Text)
                    Case COMErrResult.REFRESH
                        mForma.currentAD().RefreshDS()
                        mForma.refreshItemCount()
                        Close()
                        Return
                    Case COMErrResult.UNKOWN_ERR
                        mForma.currentAD().RefreshDS()
                        Close()
                        Return
                End Select

                Return
            Catch exx As UnauthorizedAccessException
                TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Access denied", "You are not allowed to perform this operation." & vbCrLf & "Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                mForma.currentAD().RefreshDS()
                Return
            End Try
        Catch ex As UnauthorizedAccessException
            TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Access denied", "You are not allowed to perform this operation." & vbCrLf & "Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            mForma.currentAD().RefreshDS()
            Return
        End Try

        oList.ForEach(Sub(s As sOption)
                          s.update()
                      End Sub)

        mForma.currentAD().RefreshDS()
        UserLabel.Select()
        ApplyButton.Enabled = False
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click, OK3.Click, OkButton2.Click, OK4.Click, GroupOK.Click
        If ApplyButton.Enabled Then ApplyButton_Click(Nothing, Nothing)
        Close()
    End Sub

    Private Sub bPNeverExp_Changed(sender As Object, e As EventArgs) Handles bPNeverExp.CheckedChanged, bSmartcard.CheckedChanged
        If bPNeverExp.Checked OrElse bSmartcard.Checked Then
            bChgPNextLogon.Checked = False
            bChgPNextLogon.Enabled = False
            If cfgBool("HideDisabledFlagInfo") = 0 Then
                disabledImg.Show()
            End If
        Else
            bChgPNextLogon.Enabled = True
            disabledImg.Hide()
        End If
    End Sub

    Private Sub accneverexp_changed(sender As Object, e As EventArgs) Handles bAccNeverExp.CheckedChanged
        If bAccNeverExp.Checked Then
            accexpire.Enabled = False
        Else : accexpire.Enabled = True
        End If
    End Sub

    Private Sub any_changed(sender As Object, e As EventArgs) Handles Comment.TextChanged, FullName.TextChanged, homedirL.TextChanged, homedirR.TextChanged, bPNeverExp.CheckedChanged, accexpire.ValueChanged, bAccNeverExp.CheckedChanged, bCantChgPasswd.CheckedChanged, bChgPNextLogon.CheckedChanged, pwrvencryption.CheckedChanged, accexpire.ValueChanged, bDisabled.CheckedChanged, bSmartcard.CheckedChanged, scriptpath.TextChanged, homedrvR.SelectedIndexChanged, pwnotrequired.CheckedChanged

        ApplyButton.Enabled = False

        For i As Integer = 0 To oList.Count - 1
            If oList(i) Then
            Else
                ApplyButton.Enabled = True
                Return
            End If
        Next
    End Sub

    'Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UserNameTextBox.KeyPress
    '    If mForma.disallowedChars.Contains(e.KeyChar) Then e.KeyChar = Nothing : ToolTip1.Show("The symbols / \ [ ] "" : ; | < > + = , ? * % @ cannot be used in user names.", UserNameTextBox, 3000)
    'End Sub

    Private Sub TimesBtn_Click(sender As Object, e As EventArgs) Handles TimesBtn.Click
        If Times.Show(dsUserp) = Windows.Forms.DialogResult.Retry Then
            mForma.currentAD().RefreshDS()
            mForma.refreshItemCount()
            Close()
        End If
        Times.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles RmGroup.Click
        If ListView1.Items.Count = 0 Then Return

        For Each item As ListViewItem In ListView1.SelectedItems

            If ListView1.Items.Count = 1 AndAlso Not userp.AccountDisabled Then

                If cfgBool("HideUserWithNoGroupWarning") = 0 Then
                    Dim result As Integer
                    Dim verif As Boolean

                    Dim tdc As New TASKDIALOGCONFIG()
                    tdc.cbSize = sizeof(tdc)
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

            Dim group As DsEntry = mForma.currentAD().FindGroup(item.Text, Handle)

            If group Is Nothing Then
                Close()
                Return
            End If

            Try
                group.IADsG().Remove(dsUserp.Path)
                group.CommitChanges()
                item.Remove()
            Catch ex As UnauthorizedAccessException
                TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Access denied", "You are not allowed to perform this operation." & vbCrLf & "Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                Return
            Catch exx As Runtime.InteropServices.COMException
                If ShowCOMErr(exx.ErrorCode, Handle, exx.Message, UserNameTextBox.Text) = COMErrResult.REFRESH Then
                    mForma.currentAD().RefreshDS()
                    Close()
                    Return
                End If
            End Try

        Next
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedIndices.Count > 0 Then
            RmGroup.Enabled = True
        Else : RmGroup.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles AddToGrpBtn.Click
        AddToGroup.Show(userp.Name, mForma, AddToGroup.SourceWindow.EditUser)
    End Sub

    Private Sub ListView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles ListView1.ColumnWidthChanging
        e.NewWidth = ListView1.Columns(0).Width
        e.Cancel = True
    End Sub

    'Private Sub ListView1_SizeChanged(sender As Object, e As EventArgs)
    '    ListView1.Columns(0).Width = ListView1.Width - 4
    'End Sub

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        Select Case e.TabPageIndex
            Case 0
                AcceptButton = OkButton
                CancelButton = CancelBtn
            Case 1
                AcceptButton = OK4
                CancelButton = Cancel4

                Label8.Text = UserLabel.Text
            Case 2
                AcceptButton = OK3
                CancelButton = Cancel3

                Label14.Text = UserLabel.Text
            Case 3
                AcceptButton = OkButton2
                CancelButton = Cancel2

                Label6.Text = UserLabel.Text

                If RadioButton1.Checked Then
                    If homedirL.TextLength = 0 Then
                        RadioButton1.Checked = False
                    End If
                End If

                If RadioButton2.Checked Then
                    If homedirR.TextLength = 0 Then
                        RadioButton2.Checked = False
                    End If
                End If
            Case 4
                CancelButton = GroupOK
                Label5.Text = UserLabel.Text

                ListView1.Items.Clear()

                Try
                    For Each g As IADs In userp.Groups()
                        ListView1.Items.Add(g.Name, 0)
                    Next
                Catch exx As Runtime.InteropServices.COMException

                    Select Case ShowCOMErr(exx.ErrorCode, Handle, exx.Message, userp.Name)
                        Case COMErrResult.REFRESH
                            mForma.currentAD().RefreshDS()
                            mForma.refreshItemCount()
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

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Delete AndAlso RmGroup.Enabled Then
            Button2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub unlockbtn_Click(sender As Object, e As EventArgs) Handles unlockbtn.Click
        Try
            userp.IsAccountLocked = False
            dsUserp.CommitChanges()

            If userp.IsAccountLocked Then
                acclockoutdate.Text = "Account is locked out"
                unlockbtn.Enabled = True
            Else
                acclockoutdate.Text = "Account is not locked out"
                unlockbtn.Enabled = False
            End If
        Catch ex As UnauthorizedAccessException
            TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Access denied", "You are not allowed to perform this operation." & vbCrLf & "Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
        Catch exx As Runtime.InteropServices.COMException
            If ShowCOMErr(exx.ErrorCode, Handle, exx.Message, UserNameTextBox.Text) = COMErrResult.REFRESH Then
                mForma.currentAD().RefreshDS()
            End If
            Return
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles openbtn.Click
        Dim open As New OpenFileDialog
        open.FileName = ""
        open.Filter = "All files|*.*"
        open.Title = "Select logon script"

        If (open.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            scriptpath.Text = open.FileName
        End If
    End Sub

    Private Sub ApplyButton_EnabledChanged(sender As Object, e As EventArgs) Handles ApplyButton.EnabledChanged
        Apply2.Enabled = ApplyButton.Enabled
        Apply3.Enabled = ApplyButton.Enabled
        Apply4.Enabled = ApplyButton.Enabled
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
            Label16.Enabled = True
            Label17.Enabled = True
        Else
            homedirR.Enabled = False
            homedrvR.Enabled = False
            Label16.Enabled = False
            Label17.Enabled = False
        End If
    End Sub

    Private Sub disabledImg_MouseLeave(sender As Object, e As EventArgs) Handles disabledImg.MouseLeave
        ToolTip2.Hide(Me)
    End Sub

    Private Sub disabledImg_MouseEnter(sender As Object, e As EventArgs) Handles disabledImg.MouseEnter
        ToolTip2.Show("This option cannot be enabled when either the option" & vbCrLf & """Password never expires"" is enabled or a smartcard logon is forced.", Me, PointToClient(Cursor.Position).X + 40, PointToClient(Cursor.Position).Y + 3, Integer.MaxValue)
    End Sub

    Private Sub warnChanged(sender As Object, e As EventArgs) Handles bCantChgPasswd.CheckedChanged, bChgPNextLogon.CheckedChanged
        If cfgBool("HideWarningCantchgpasswd") = True Then Return

        If bCantChgPasswd.Checked AndAlso bChgPNextLogon.Checked Then
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

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Dim l As Label = ContextMenuStrip1.SourceControl
        Clipboard.SetText(l.Text)
    End Sub
End Class