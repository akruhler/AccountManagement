Imports DsEntry = System.DirectoryServices.DirectoryEntry
Public Class AddToGroup
    Dim name_ As String
    Dim mForma As Form1
    Dim srcWnd As SourceWindow

    Dim users As List(Of String) = New List(Of String)
    Dim groups As List(Of String) = New List(Of String)
    Dim builtin As List(Of String) = New List(Of String)

    Enum SourceWindow
        AddUser
        AddGroup
        EditUser
        EditGroup
    End Enum

    Overloads Sub Show(Username As String, mainForm As Form1, s As SourceWindow)
        ContextMenuStrip1.Renderer = New clsMenuRenderer

        srcWnd = s
        mForma = mainForm

        If s = SourceWindow.AddGroup OrElse s = SourceWindow.EditGroup Then
            name_ = Username

            users.AddRange(mForma.currentAD().UserList.Keys)
            builtin.AddRange(mForma.currentAD().BuiltInSecurityPrincipals.Values)

            If s = SourceWindow.EditGroup Then
                For Each Item As ListViewItem In EditGroup.ListView1.Items
                    users.Remove(Item.Text)
                    builtin.Remove(Item.Text)
                Next
            Else
                For Each Item As ListViewItem In AddGroup.ListView1.Items
                    users.Remove(Item.Text)
                    builtin.Remove(Item.Text)
                Next
            End If

            users.ForEach(Sub(item As String)
                              ListView1.Items.Add(item, 0)
                          End Sub)

            builtin.ForEach(Sub(item As String)
                                ListView1.Items.Add(item, 1)
                            End Sub)

            Label1.Text = "Select the objects you wish to add:"
        Else
            Button3.Hide()

            name_ = Username

            groups.AddRange(mForma.currentAD().GroupList)

            If s = SourceWindow.EditUser Then
                For Each Item As ListViewItem In EditUser.ListView1.Items
                    groups.Remove(Item.Text)
                Next
            Else
                For Each Item As ListViewItem In AddUser.ListView1.Items
                    groups.Remove(Item.Text)
                Next
            End If

            groups.ForEach(Sub(item As String)
                               ListView1.Items.Add(item, 1)
                           End Sub)

            Label1.Text = "Select the groups you would like to assign the user to:"
        End If
        Button1.Enabled = False
        ShowDialog()
        Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each item As ListViewItem In ListView1.SelectedItems

            If srcWnd = SourceWindow.EditGroup Then

                Dim group As DsEntry = mForma.currentAD().FindGroup(name_, Handle)
                Dim entry As DsEntry = mForma.currentAD().FindObject(item.Text, Handle)

                If entry Is Nothing Or group Is Nothing Then
                    Close()
                    Return
                End If

                Try
                    group.IADsG().Add(entry.Path)
                    group.CommitChanges()

                    EditGroup.ListView1.Items.Add(item.Clone())

                Catch ex As UnauthorizedAccessException
                    TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Access denied", "You are not allowed to perform this operation." & vbCrLf & "Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                    Return
                Catch ex As Runtime.InteropServices.COMException
                    ShowCOMErr(ex.ErrorCode, Handle, ex.Message)
                    Return
                End Try

            ElseIf srcWnd = SourceWindow.EditUser Then

                Dim group As DsEntry = mForma.currentAD().FindGroup(item.Text, Handle)
                Dim entry As DsEntry = mForma.currentAD().FindUser(name_, Handle)

                If entry Is Nothing Or group Is Nothing Then
                    Close()
                    Return
                End If

                Try
                    group.IADsG().Add(entry.Path)
                    group.CommitChanges()

                    EditUser.ListView1.Items.Add(group.Name, 0)

                Catch ex As UnauthorizedAccessException
                    TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Access denied", "You are not allowed to perform this operation." & vbCrLf & "Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                    Return
                Catch ex As Runtime.InteropServices.COMException
                    ShowCOMErr(ex.ErrorCode, Handle, ex.Message)
                    Return
                End Try

            ElseIf srcWnd = SourceWindow.AddUser Then : AddUser.ListView1.Items.Add(item.Text, 0)
            ElseIf srcWnd = SourceWindow.AddGroup Then : AddGroup.ListView1.Items.Add(item.Clone())
            End If

        Next

        Close()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If Button1.Enabled Then Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedIndices.Count > 0 Then
            Button1.Enabled = True
        Else : Button1.Enabled = False
        End If
    End Sub

    Private Sub ListView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles ListView1.ColumnWidthChanging
        e.NewWidth = ListView1.Columns(0).Width
        e.Cancel = True
    End Sub

    Private Sub ListView1_SizeChanged(sender As Object, e As EventArgs) Handles ListView1.SizeChanged
        ListView1.Columns(0).Width = ListView1.Width - 4
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ContextMenuStrip1.Show(Button3, 0, Button3.Height)
    End Sub

    Private Sub ShowUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowUsersToolStripMenuItem.CheckedChanged, ShowToolStripMenuItem.CheckedChanged
        ListView1.Items.Clear()

        If ShowUsersToolStripMenuItem.Checked Then
            users.ForEach(Sub(item As String)
                              ListView1.Items.Add(item, 0)
                          End Sub)
        End If

        If ShowToolStripMenuItem.Checked Then
            builtin.ForEach(Sub(item As String)
                                ListView1.Items.Add(item, 1)
                            End Sub)
        End If
    End Sub
End Class