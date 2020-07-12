Imports DsEntry = System.DirectoryServices.DirectoryEntry
Imports ActiveDs
Public Class EditGroup
    Private Commentch As String
    Private gp As DsEntry
    Private Igp As IADsGroup
    Private AD As ActiveDirectory

    Public Sub New()
        InitializeComponent()
        GroupMembers.SmallImageList = MainForm.ListIcons
    End Sub

    Public Sub GroupnameChanged(Group As String, newName As String)
        If gp.Name = Group Then
            gp = AD.FindGroup(newName, Handle)
            If gp Is Nothing Then
                Close()
            End If

            Igp = gp.IADsG()

            Text = AD.GetDisplayName() & "/" & newName
            GroupLabel.Text = "Group settings for " & Text

            GroupNameTextBox.Text = newName
        End If
    End Sub

    Private Sub ObjectDeleted(Group As String)
        If Group = gp.Name Then
            Close()
        End If
    End Sub

    Private Sub ChangeDisplayName(newName As String)
        Text = newName & "/" & gp.Name
        GroupLabel.Text = "Group settings for " & Text
    End Sub

    Overloads Function Show(Group As String, pAD As ActiveDirectory) As Boolean
        AD = pAD
        gp = pAD.FindGroup(Group, Handle)

        If gp Is Nothing Then
            Close()
            Return False
        End If

        Igp = gp.IADsG()

        'Check whether the same property window is already open
        If Not RegisterWindow(Me, pAD.GetSystemSID() & Igp.GetSID()) Then
            'If so, return, since the open window will be presented to the user
            Return True
        End If

        AddHandler pAD.OnDisconnect, AddressOf Me.Close
        AddHandler pAD.OnDeleteGroup, AddressOf ObjectDeleted
        AddHandler pAD.OnRenameGroup, AddressOf GroupnameChanged
        AddHandler pAD.OnDisplayNameChange, AddressOf ChangeDisplayName

        Text = pAD.GetDisplayName() & "/" & Group
        GroupLabel.Text = "Group settings for " & Text

        GroupNameTextBox.Text = Group
        GroupLabel.Select()

        For Each member As IADs In Igp.Members()
            If member.Class = "User" Then
                GroupMembers.Items.Add(member.Name, 0)
            Else
                Dim name As String = ""
                Dim Principal As BuiltInPrincipal = pAD.GetPrincipalBySID(member.GetSID())

                If Principal.isInvalid Then
                    name = member.Name
                Else
                    name = Principal.Name
                End If

                GroupMembers.Items.Add(name, 1)
            End If
        Next

        Comment.Text = Igp.Description
        SID.Text = Igp.GetSID()

        Commentch = Comment.Text
        ApplyButton.Enabled = False

        MyBase.Show()

        Return True
    End Function

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GroupMembers.SelectedIndexChanged
        If GroupMembers.SelectedIndices.Count > 0 Then
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
            ShowPermissionDeniedErr(Handle)
            Return
        Catch ex As Runtime.InteropServices.COMException
            If ShowCOMErr(ex.ErrorCode, Handle, ex.Message, GroupNameTextBox.Text) = COMErrResult.REFRESH Then
                AD.RefreshDS()
                Close()
            End If
            Return
        End Try

        GroupLabel.Select()
        ApplyButton.Enabled = False
    End Sub

    Private Sub GroupNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles GroupNameTextBox.TextChanged, Comment.TextChanged
        If Comment.Text = Commentch Then
            ApplyButton.Enabled = False
        Else : ApplyButton.Enabled = True
        End If
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GroupMembers.KeyDown
        If e.KeyCode = Keys.Delete AndAlso Button2.Enabled Then
            Button2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each item As ListViewItem In GroupMembers.SelectedItems

            If cfgBool("HideUserWithNoGroupWarning") = 0 AndAlso item.ImageIndex = 0 Then 'Is the warning enabled and the object a User? (ImgIndex==0)

                Dim count As Integer = 0

                Dim user As IADsUser = AD.FindUser(item.Text, Handle).IADsU()

                For Each g As ActiveDs.IADs In user.Groups()
                    If g.Class = "Group" Then
                        count += 1
                    End If
                Next

                If count = 1 AndAlso Not user.AccountDisabled Then
                    Dim result As Integer
                    Dim verif As Boolean

                    Dim tdc As New TASKDIALOGCONFIG()
                    tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)
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
                Igp.Remove(AD.GetPath(item.Text, True))
                gp.CommitChanges()
                item.Remove()
            Catch ex As UnauthorizedAccessException
                ShowPermissionDeniedErr(Handle)
                Return
            Catch ex As Runtime.InteropServices.COMException
                If ShowCOMErr(ex.ErrorCode, Handle, ex.Message, GroupNameTextBox.Text) = COMErrResult.REFRESH Then
                    AD.RefreshDS()
                    Close()
                    Return
                End If
            End Try
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddToGroup.Show(gp.Name, AD, AddToGroup.SourceWindow.EditGroup, GroupMembers)
    End Sub

    'Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GroupNameTextBox.KeyPress
    '    If isDisallowed(e.KeyChar) Then e.KeyChar = Nothing : ToolTip1.Show("The symbols / \ [ ] "" : ; | < > + = , ? * % @ cannot be used in group names.", GroupNameTextBox, 3000)
    'End Sub

    Private Sub ListView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles GroupMembers.ColumnWidthChanging
        e.NewWidth = GroupMembers.Columns(0).Width
        e.Cancel = True
    End Sub

    Private Sub ListView1_SizeChanged(sender As Object, e As EventArgs) Handles GroupMembers.SizeChanged
        GroupMembers.Columns(0).Width = GroupMembers.Width - 1
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
    End Sub

    Private Sub EditGroup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandler AD.OnDisconnect, AddressOf Me.Close
        RemoveHandler AD.OnDeleteGroup, AddressOf ObjectDeleted
        RemoveHandler AD.OnRenameGroup, AddressOf GroupnameChanged
        RemoveHandler AD.OnDisplayNameChange, AddressOf ChangeDisplayName
    End Sub
End Class