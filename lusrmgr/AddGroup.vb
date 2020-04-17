Imports DsEntry = System.DirectoryServices.DirectoryEntry
Public Class AddGroup
    Dim mForma As Form1

    Overloads Sub Show(mainForm As Form1)
        mForma = mainForm

        If mainForm.connectedADs.Count > 0 Then
            Text &= " on " & mainForm.currentAD().displayName
        End If

        ShowDialog()
        Dispose()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UserNameTextBox.KeyPress
        If Form1.disallowedChars.Contains(e.KeyChar) Then e.KeyChar = Nothing : ToolTip1.Show("The symbols / \ [ ] "" : ; | < > + = , ? * % @ cannot be used in group names.", UserNameTextBox, 3000)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddToGroup.Show(UserNameTextBox.Text, mForma, AddToGroup.SourceWindow.AddGroup)
    End Sub

    Private Sub ListView1_SizeChanged(sender As Object, e As EventArgs) Handles ListView1.SizeChanged
        ListView1.Columns(0).Width = ListView1.Width - 4
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each item As ListViewItem In ListView1.SelectedItems
            item.Remove()
        Next
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

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedIndices.Count > 0 Then
            Button2.Enabled = True
        Else : Button2.Enabled = False
        End If
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Delete AndAlso Button2.Enabled Then
            Button2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If mForma.currentAD().isLoading() Then
            TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Account database is still loading", "The account database on which you wish to create the new group is still being retrieved. Please try again in a few moments.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_WARNING_ICON, 0)
            Return
        End If

        Dim newg As DsEntry

        Try
            newg = mForma.currentAD().CreateGroup(UserNameTextBox.Text, Comment.Text)

        Catch ex As UnauthorizedAccessException
            TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Access denied", "You are not allowed to perform this operation. Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return
        Catch ex As Runtime.InteropServices.COMException
            If ShowCOMErr(ex.ErrorCode, Handle, ex.Message) Then
                mForma.currentAD().RefreshDS()
            End If

            Return
        Catch ex As Exception
            TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "An unkown error ocurred", ex.Message.Replace(vbNewLine, ""), TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return
        End Try

        Dim obj As DsEntry

        For Each Member As ListViewItem In ListView1.Items
            obj = mForma.currentAD().FindObject(Member.Text, Handle)
            If obj Is Nothing Then Continue For

            newg.IADsG().Add(obj.Path)
        Next
        newg.CommitChanges()

        mForma.currentAD().RefreshDS()
        mForma.refreshItemCount()
        Close()
    End Sub

    Private Sub ListView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles ListView1.ColumnWidthChanging
        e.NewWidth = ListView1.Columns(0).Width
        e.Cancel = True
    End Sub
End Class