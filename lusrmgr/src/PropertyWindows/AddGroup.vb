Imports DsEntry = System.DirectoryServices.DirectoryEntry
Public Class AddGroup
    Private AD As ActiveDirectory

    Public Sub New()
        InitializeComponent()
        list.SmallImageList = MainForm.ListIcons
    End Sub

    Private Sub ChangeDisplayName(newName As String)
        GroupLabel.Text = "Create new group on " & newName
    End Sub

    Shadows Sub Show(pAD As ActiveDirectory)
        AD = pAD
        AddHandler pAD.OnDisconnect, AddressOf Me.Close
        AddHandler pAD.OnDisplayNameChange, AddressOf ChangeDisplayName

        GroupLabel.Text &= pAD.GetDisplayName()
        MyBase.Show()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GroupNameTextBox.KeyPress
        If isDisallowed(e.KeyChar) Then e.KeyChar = Nothing : SymbolDisallowedTooltip.Show("The symbols / \ [ ] "" : ; | < > + = , ? * % @ cannot be used in group names.", GroupNameTextBox, 3000)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        AddToGroup.Show(GroupNameTextBox.Text, AD, AddToGroup.SourceWindow.AddGroup, list)
    End Sub

    Private Sub ListView1_SizeChanged(sender As Object, e As EventArgs) Handles list.SizeChanged
        list.Columns(0).Width = list.Width - 4
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles RmBtn.Click
        For Each item As ListViewItem In list.SelectedItems
            item.Remove()
        Next
    End Sub

    Private Sub UserNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles GroupNameTextBox.TextChanged
        If GroupNameTextBox.Text = Nothing Then
            OkButton.Enabled = False
        Else
            For Each c As Char In GroupNameTextBox.Text.ToCharArray()
                If Not c = " "c Then
                    OkButton.Enabled = True
                    Return
                End If
            Next
            OkButton.Enabled = False
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list.SelectedIndexChanged
        If list.SelectedIndices.Count > 0 Then
            RmBtn.Enabled = True
        Else : RmBtn.Enabled = False
        End If
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles list.KeyDown
        If e.KeyCode = Keys.Delete AndAlso RmBtn.Enabled Then
            Button2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Dim newg As DsEntry

        Try
            newg = AD.CreateGroup(GroupNameTextBox.Text, Comment.Text)
        Catch ex As UnauthorizedAccessException
            ShowPermissionDeniedErr(Handle, AD.IsRemoteAD())
            Return
        Catch ex As Runtime.InteropServices.COMException
            ShowCOMErr(ex.ErrorCode, Handle, ex.Message)
            Return
        Catch ex As Exception
            TaskDialog(Handle, "Local users and groups", "An unkown error occurred", ex.Message.Replace(vbCrLf, ""), TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return
        End Try

        Try
            For Each Member As ListViewItem In list.Items
                If Not AD.BuiltInPrincipalOrUserExists(Member.Text, Handle) Then Continue For

                newg.IADsG().Add(AD.GetPath(Member.Text, True))
            Next
        Catch ex As UnauthorizedAccessException
            ShowPermissionDeniedErr(Handle, AD.IsRemoteAD())
            Return
        Catch ex As Runtime.InteropServices.COMException
            If ShowCOMErr(ex.ErrorCode, Handle, ex.Message) = COMErrResult.REFRESH Then
                AD.RefreshDS()
            End If
            Return
        Catch ex As Exception
            TaskDialog(Handle, "Local users and groups", "An unkown error occurred", ex.Message.Replace(vbCrLf, ""), TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return
        End Try

        Try
            newg.CommitChanges()
        Catch ex As UnauthorizedAccessException
            ShowPermissionDeniedErr(Handle, AD.IsRemoteAD())
            Return
        Catch ex As Runtime.InteropServices.COMException
            If ShowCOMErr(ex.ErrorCode, Handle, ex.Message) = COMErrResult.REFRESH Then
                AD.RefreshDS()
            End If
            Return
        Catch ex As Exception
            TaskDialog(Handle, "Local users and groups", "An unkown error occurred", ex.Message.Replace(vbCrLf, ""), TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return
        End Try

        Close()
    End Sub

    Private Sub ListView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles list.ColumnWidthChanging
        e.NewWidth = list.Columns(0).Width
        e.Cancel = True
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
    End Sub

    Private Sub AddGroup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler AD.OnDisconnect, AddressOf Close
        RemoveHandler AD.OnDisplayNameChange, AddressOf ChangeDisplayName
    End Sub
End Class