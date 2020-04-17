Imports DsEntry = System.DirectoryServices.DirectoryEntry
Imports ActiveDs
Public Class EditGroup
    Dim Commentch As String
    Dim gp As DsEntry
    Dim Igp As IADsGroup
    Dim mForma As Form1

    Overloads Function Show(Group As String, mainForm As Form1) As Boolean
        mForma = mainForm
        gp = mForma.currentAD().FindGroup(Group, Handle)

        If gp Is Nothing Then
            Close()
            Return False
        End If

        If mainForm.connectedADs.Count = 0 Then
            GroupLabel.Text = "Group settings for " & Group
            Text = Group
        Else
            GroupLabel.Text = "Group settings for " & mainForm.currentAD().displayName & "/" & Group
            Text = mainForm.currentAD().displayName & "/" & Group
        End If

        GroupNameTextBox.Text = Group
        GroupLabel.Select()

        Igp = gp.IADsG()

        For Each member As IADs In Igp.Members()
            If member.Class = "User" Then
                ListView1.Items.Add(member.Name, 0)
            Else
                Dim name As String = ""

                If Not mainForm.currentAD().BuiltInSecurityPrincipals.TryGetValue(member.SID(), name) Then
                    name = member.Name
                End If

                ListView1.Items.Add(name, 1)
            End If
        Next

        Comment.Text = Igp.Description
        SID.Text = Igp.SID()

        Commentch = Comment.Text
        ApplyButton.Enabled = False
        ShowDialog()
        Dispose()

        Return True
    End Function

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedIndices.Count > 0 Then
            Button2.Enabled = True
        Else : Button2.Enabled = False
        End If
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If ApplyButton.Enabled Then ApplyButton_Click(Nothing, Nothing)
        Close()
    End Sub

    Private Sub ApplyButton_Click(sender As Object, e As EventArgs) Handles ApplyButton.Click
        'If Not Namech = GroupNameTextBox.Text Then
        '    gp.SamAccountName = GroupNameTextBox.Text

        '    Namech = GroupNameTextBox.Text
        '    GroupLabel.Text = "Group settings for " & GroupNameTextBox.Text
        '    Text = GroupNameTextBox.Text
        'End If
        If Not Commentch = Comment.Text Then
            Igp.Description = Comment.Text
            Commentch = Comment.Text
        End If

        Try
            gp.CommitChanges()
        Catch ex As UnauthorizedAccessException
            TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Access denied", "You are not allowed to perform this operation." & vbCrLf & "Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            mForma.currentAD().RefreshDS()
            Return
        Catch ex As Runtime.InteropServices.COMException
            ShowCOMErr(ex.ErrorCode, Handle, ex.Message, GroupNameTextBox.Text)
            mForma.currentAD().RefreshDS()
            Close()
            Return
        End Try

        mForma.currentAD().RefreshDS()
        GroupLabel.Select()
        ApplyButton.Enabled = False
    End Sub

    Private Sub GroupNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles GroupNameTextBox.TextChanged, Comment.TextChanged
        If Comment.Text = Commentch Then
            ApplyButton.Enabled = False
        Else : ApplyButton.Enabled = True
        End If
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Delete AndAlso Button2.Enabled Then
            Button2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each item As ListViewItem In ListView1.SelectedItems

            Dim entry As DsEntry = mForma.currentAD().FindObject(item.Text, Handle)
            If entry Is Nothing Then
                Close()
                Return
            End If

            If cfgBool("HideUserWithNoGroupWarning") = 0 AndAlso item.ImageIndex = 0 Then 'Is the warning enabled and the object a User? (ImgIndex==0)

                Dim count As Integer = 0

                'Thus, a safe cast to COM IADsU is possible
                Dim user As IADsUser = entry.IADsU()

                For Each g As ActiveDs.IADs In user.Groups()
                    If g.Class = "Group" Then
                        count += 1
                    End If
                Next

                If count = 1 AndAlso Not user.AccountDisabled Then
                    Dim result As Integer
                    Dim verif As Boolean

                    Dim tdc As New TASKDIALOGCONFIG()
                    tdc.cbSize = sizeof(tdc)
                    tdc.hwndParent = Handle

                    tdc.pszWindowTitle = "Inaccessible account"
                    tdc.pszMainInstruction = "No group membership specified for " & item.Text
                    tdc.pszContent = "If no group membership is specified, " & item.Text & " won't be able to log on to Windows anymore. Continue?"

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

            Try
                Igp.Remove(entry.Path)
                gp.CommitChanges()
                item.Remove()
            Catch ex As UnauthorizedAccessException
                TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Access denied", "You are not allowed to perform this operation." & vbCrLf & "Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                Return
            Catch ex As Runtime.InteropServices.COMException
                If ShowCOMErr(ex.ErrorCode, Handle, ex.Message, GroupNameTextBox.Text) = COMErrResult.REFRESH Then
                    mForma.currentAD().RefreshDS()
                    Close()
                    Return
                End If
            End Try
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddToGroup.Show(gp.Name, mForma, AddToGroup.SourceWindow.EditGroup)
    End Sub

    'Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GroupNameTextBox.KeyPress
    '    If mForma.disallowedChars.Contains(e.KeyChar) Then e.KeyChar = Nothing : ToolTip1.Show("The symbols / \ [ ] "" : ; | < > + = , ? * % @ cannot be used in group names.", GroupNameTextBox, 3000)
    'End Sub

    Private Sub ListView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles ListView1.ColumnWidthChanging
        e.NewWidth = ListView1.Columns(0).Width
        e.Cancel = True
    End Sub

    Private Sub ListView1_SizeChanged(sender As Object, e As EventArgs) Handles ListView1.SizeChanged
        ListView1.Columns(0).Width = ListView1.Width - 4
    End Sub
End Class