Imports DsEntry = System.DirectoryServices.DirectoryEntry
Public Class AddToGroup
    Private name_ As String
    Private AD As ActiveDirectory
    Private srcWnd As SourceWindow
    Private dstListView As ListView
    Private users As List(Of String) = New List(Of String)
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
            FilterButton.Show()
            name_ = Username

            users.AddRange(AD.UserList.Keys)

            For Each Principal As BuiltInPrincipal In pAD.BuiltInPrincipals
                If Principal.SID <> "S-1-5-32" Then
                    builtin.Add(Principal.Name)
                End If
            Next

            'Remove the objects already assigned to the group
            For Each Item As ListViewItem In pDstListView.Items
                users.Remove(Item.Text)
                builtin.Remove(Item.Text)
            Next

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

            InstructionLabel.Text = "Select the objects you wish to add:"
        Else
            FilterButton.Hide()
            name_ = Username

            For Each item As String In AD.GroupList
                list.Items.Add(item, item, 1)
            Next

            'Remove the groups already assigned to the user
            For Each Item As ListViewItem In pDstListView.Items
                list.Items.RemoveByKey(Item.Text)
            Next

            InstructionLabel.Text = "Select the groups you wish to assign the user to:"
        End If
        SelectButton.Enabled = False
        ShowDialog()

        'Perform "clean-up" (instead of calling Dispose() to mantain the size and position of the window)
        users.Clear()
        builtin.Clear()
        list.Items.Clear()
        filter_indicator.Hide()
    End Sub

    Private Sub SelectButtonClicked(sender As Object, e As EventArgs) Handles SelectButton.Click

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
                    ShowPermissionDeniedErr(Handle, AD.IsRemoteAD())
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
                    ShowPermissionDeniedErr(Handle, AD.IsRemoteAD())
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

#Region "Filter"

    Private Sub FilterButtonClicked(sender As Object, e As EventArgs) Handles FilterButton.Click
        FilterMenu.Show(FilterButton, 0, FilterButton.Height)
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
#End Region

#Region "List event handlers"

    Private Sub list_DoubleClick(sender As Object, e As EventArgs) Handles list.DoubleClick
        If SelectButton.Enabled Then SelectButtonClicked(Nothing, Nothing)
    End Sub

    Private Sub list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list.SelectedIndexChanged
        If list.SelectedIndices.Count > 0 Then
            SelectButton.Enabled = True
        Else : SelectButton.Enabled = False
        End If
    End Sub

    Private Sub list_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles list.ColumnWidthChanging
        e.NewWidth = list.Columns(0).Width
        e.Cancel = True
    End Sub

    Private Sub list_SizeChanged(sender As Object, e As EventArgs) Handles list.SizeChanged
        list.Columns(0).Width = list.Width - 4
    End Sub
#End Region
End Class