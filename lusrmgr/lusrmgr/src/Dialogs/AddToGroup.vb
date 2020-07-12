Imports DsEntry = System.DirectoryServices.DirectoryEntry
Public Class AddToGroup
    Private name_ As String
    Private AD As ActiveDirectory
    Private srcWnd As SourceWindow
    Private dstListView As ListView

    Private users As List(Of String) = New List(Of String)
    Private groups As List(Of String) = New List(Of String)
    Private builtin As List(Of String) = New List(Of String)

    Enum SourceWindow
        AddUser
        AddGroup
        EditUser
        EditGroup
    End Enum

    Public Sub New()
        InitializeComponent()
        FilterMenu.Renderer = New clsMenuRenderer
        list.SmallImageList = MainForm.ListIcons
    End Sub

    Shadows Sub Show(Username As String, pAD As ActiveDirectory, s As SourceWindow, ByRef pDstListView As ListView)
        srcWnd = s
        AD = pAD
        dstListView = pDstListView

        If s = SourceWindow.AddGroup OrElse s = SourceWindow.EditGroup Then
            Button3.Show()
            name_ = Username

            users.AddRange(AD.UserList.Keys)

            If builtin.Count = 0 Then
                For Each Principal As BuiltInPrincipal In pAD.BuiltInPrincipals
                    If Principal.SID <> "S-1-5-32" Then
                        builtin.Add(Principal.Name)
                    End If
                Next
            End If

            If s = SourceWindow.EditGroup Then
                For Each Item As ListViewItem In pDstListView.Items
                    users.Remove(Item.Text)
                    builtin.Remove(Item.Text)
                Next
            Else
                For Each Item As ListViewItem In pDstListView.Items
                    users.Remove(Item.Text)
                    builtin.Remove(Item.Text)
                Next
            End If

            If ShowUsers.Checked Then
                users.ForEach(Sub(item As String)
                                  list.Items.Add(item, 0)
                              End Sub)
            Else
                filter_indicator.Show()
            End If

            If ShowBuiltInPrincipals.Checked Then
                builtin.ForEach(Sub(item As String)
                                    list.Items.Add(item, 1)
                                End Sub)
            Else
                filter_indicator.Show()
            End If

            Label1.Text = "Select the objects you wish to add:"
        Else
            Button3.Hide()
            name_ = Username

            groups.AddRange(AD.GroupList)

            If s = SourceWindow.EditUser Then
                For Each Item As ListViewItem In pDstListView.Items
                    groups.Remove(Item.Text)
                Next
            Else
                For Each Item As ListViewItem In pDstListView.Items
                    groups.Remove(Item.Text)
                Next
            End If

            groups.ForEach(Sub(item As String)
                               list.Items.Add(item, 1)
                           End Sub)

            Label1.Text = "Select the groups you wish to assign the user to:"
        End If
        Button1.Enabled = False
        ShowDialog()

        'Perform "clean-up" (instead of calling Dispose() to mantain the size of the window)
        users.Clear()
        groups.Clear()
        list.Items.Clear()
        filter_indicator.Hide()
    End Sub

    Private Sub SelectButtonClicked(sender As Object, e As EventArgs) Handles Button1.Click
        For Each item As ListViewItem In list.SelectedItems

            If srcWnd = SourceWindow.EditGroup Then

                Dim group As DsEntry = AD.FindGroup(name_, Handle)

                If group Is Nothing OrElse Not AD.BuiltInPrincipalOrUserExists(item.Text, Handle) Then
                    Continue For
                End If

                Try
                    group.IADsG().Add(AD.GetPath(item.Text, True))
                    group.CommitChanges()

                    dstListView.Items.Add(item.Clone())

                Catch ex As UnauthorizedAccessException
                    ShowPermissionDeniedErr(Handle)
                    Return
                Catch ex As Runtime.InteropServices.COMException
                    If ShowCOMErr(ex.ErrorCode, Handle, ex.Message, item.Text) <> COMErrResult.LOOP_CONTINUE Then
                        Return
                    ElseIf list.SelectedItems.Count = 1 Then
                        Return
                    End If
                End Try

            ElseIf srcWnd = SourceWindow.EditUser Then

                Dim group As DsEntry = AD.FindGroup(item.Text, Handle)

                If group Is Nothing OrElse Not AD.UserExists(name_, Handle) Then
                    Continue For
                End If

                Try
                    group.IADsG().Add(AD.GetPath(name_, False))
                    group.CommitChanges()

                    dstListView.Items.Add(group.Name, 1)

                Catch ex As UnauthorizedAccessException
                    ShowPermissionDeniedErr(Handle)
                    Return
                Catch ex As Runtime.InteropServices.COMException
                    If ShowCOMErr(ex.ErrorCode, Handle, ex.Message, item.Text) <> COMErrResult.LOOP_CONTINUE Then
                        Return
                    ElseIf list.SelectedItems.Count = 1 Then
                        Return
                    End If
                End Try

            ElseIf srcWnd = SourceWindow.AddUser Then
                dstListView.Items.Add(item.Clone())
            ElseIf srcWnd = SourceWindow.AddGroup Then
                dstListView.Items.Add(item.Clone())
            End If
        Next

        Close()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles list.DoubleClick
        If Button1.Enabled Then SelectButtonClicked(Nothing, Nothing)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list.SelectedIndexChanged
        If list.SelectedIndices.Count > 0 Then
            Button1.Enabled = True
        Else : Button1.Enabled = False
        End If
    End Sub

    Private Sub ListView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles list.ColumnWidthChanging
        e.NewWidth = list.Columns(0).Width
        e.Cancel = True
    End Sub

    Private Sub ListView1_SizeChanged(sender As Object, e As EventArgs) Handles list.SizeChanged
        list.Columns(0).Width = list.Width - 4
    End Sub

    Private Sub FilterButtonClicked(sender As Object, e As EventArgs) Handles Button3.Click
        FilterMenu.Show(Button3, 0, Button3.Height)
    End Sub

    Private Sub FilterOptionsChanged(sender As Object, e As EventArgs) Handles ShowUsers.CheckedChanged, ShowBuiltInPrincipals.CheckedChanged
        list.Items.Clear()
        filter_indicator.Hide()

        If ShowUsers.Checked Then
            users.ForEach(Sub(item As String)
                              list.Items.Add(item, 0)
                          End Sub)
        Else
            filter_indicator.Show()
        End If

        If ShowBuiltInPrincipals.Checked Then
            builtin.ForEach(Sub(item As String)
                                list.Items.Add(item, 1)
                            End Sub)
        Else
            filter_indicator.Show()
        End If
    End Sub
End Class