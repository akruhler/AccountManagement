Imports DsEntry = System.DirectoryServices.DirectoryEntry
Public Class Search
    Private currentADObjCount, totalObjCount As UInteger
    Private mainF As MainForm

    Public Sub New(mainForm As MainForm)
        mainF = mainForm
        InitializeComponent()
        ContextMenuS.Renderer = New clsMenuRenderer
        SearchOptionsVisible = False
        Height -= 50

        list.SmallImageList = New ImageList()
        list.SmallImageList.ColorDepth = ColorDepth.Depth32Bit
        list.SmallImageList.ImageSize = New Size(19, 19)
        list.SmallImageList.Images.Add(mainForm.ListIcons.Images(0))
        list.SmallImageList.Images.Add(mainForm.ListIcons.Images(1))
        list.SmallImageList.Images.Add(mainForm.ListIcons.Images(1))

        AddHandler mainForm.ADHandler.CurrentADChanged, Sub()
                                                            If Not NoAutoRefresh.Checked AndAlso SRangeCurrent.Checked Then
                                                                currentADObjCount = mainF.ADHandler.currentAD.UserList.Count + mainF.ADHandler.currentAD.GroupList.Count + mainF.ADHandler.currentAD.BuiltInPrincipals.Count
                                                                SearchConditionsChanged(Nothing, Nothing)
                                                            End If
                                                        End Sub
    End Sub

    Private Property OnlyLocal As Boolean
        Get
            Return Not GroupBox2.Enabled
        End Get
        Set(value As Boolean)
            GroupBox2.Enabled = Not value
            If value Then SRangeCurrent.Checked = value
        End Set
    End Property

    Private Property SearchOptionsVisible As Boolean
        Get
            Return GroupBox1.Visible
        End Get
        Set(value As Boolean)
            GroupBox1.Visible = value
            GroupBox2.Visible = value

            If value Then
                SearchOptionsExpander.Text = "Hide search options"

                list.Top = 221
                list.Height -= 121

                PictureBox1.Top += 65
                NoResultsLabel.Top += 65
                Label2.Top += 65
                SeperatorLabel.Top = 205
            Else
                SearchOptionsExpander.Text = "Show search options"

                list.Top = 100
                list.Height += 121

                PictureBox1.Top -= 65
                NoResultsLabel.Top -= 65
                Label2.Top -= 65
                SeperatorLabel.Top = 84
            End If
        End Set
    End Property

    Shadows Sub Show()
        'Is the window already open?
        If Visible Then
            If WindowState = FormWindowState.Minimized Then
                WindowState = FormWindowState.Normal
            End If
            BringToFront()
        Else
            InitSearch()
            MyBase.Show()
        End If
    End Sub

    ''' <summary>
    ''' Reinitialise search.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitSearch()
        'Determine whether there are any machines connected
        If mainF.ADHandler.areADsConnected() = False Then
            OnlyLocal = True
        Else
            If OnlyLocal Then
                SRangeAll.Checked = True
            End If
            OnlyLocal = False
            list.Groups.Clear()
            totalObjCount = 0
            'Count the total number of elements to be searched and add a group for each machine
            For Each node As TreeNode In mainF.tw.Nodes
                Dim AD As ActiveDirectory = DirectCast(node.Tag, ActiveDirectory)
                totalObjCount += AD.UserList.Count + AD.GroupList.Count + AD.BuiltInPrincipals.Count
                list.Groups.Add(AD.GetID(), AD.GetDisplayName())
            Next
        End If

        currentADObjCount = mainF.ADHandler.currentAD.UserList.Count + mainF.ADHandler.currentAD.GroupList.Count + mainF.ADHandler.currentAD.BuiltInPrincipals.Count

        SearchConditionsChanged(Nothing, Nothing)
    End Sub

    ''' <summary>
    ''' Fills the list with search results from the given AD object according to the search term.
    ''' </summary>
    ''' <param name="AD"></param>
    ''' <remarks></remarks>
    Private Sub Search(AD As ActiveDirectory)

        If SearchUsers.Checked Then
            For Each user As KeyValuePair(Of String, String) In AD.UserList
                If user.Key.ToLower().Contains(SearchBox.Text.ToLower()) OrElse user.Value.ToLower().Contains(SearchBox.Text.ToLower()) Then
                    'If a match has been found, add the item and set its "Tag" property to its AD object
                    list.Items.Add(New ListViewItem(New String() {user.Key, AD.GetDisplayName()}, 0, list.Groups(AD.GetID()))).Tag = AD
                    Continue For
                End If
            Next
        End If

        If SearchGroups.Checked Then
            For Each group As String In AD.GroupList
                If group.ToLower().Contains(SearchBox.Text.ToLower()) Then
                    list.Items.Add(New ListViewItem(New String() {group, AD.GetDisplayName()}, 1, list.Groups(AD.GetID()))).Tag = AD
                End If
            Next
        End If

        If SearchBuiltin.Checked Then
            For Each principal As BuiltInPrincipal In AD.BuiltInPrincipals
                If principal.Name.ToLower().Contains(SearchBox.Text.ToLower()) OrElse principal.SID.ToLower().Contains(SearchBox.Text.ToLower()) Then
                    list.Items.Add(New ListViewItem(New String() {principal.Name, AD.GetDisplayName()}, 2, list.Groups(AD.GetID()))).Tag = AD
                End If
            Next
        End If
    End Sub

    Private Sub SearchAll()
        For Each node As TreeNode In mainF.tw.Nodes
            Search(node.Tag)
        Next
    End Sub

    Private Sub GoToElementTS_Click(sender As Object, e As EventArgs) Handles cJumpTo.Click
        If list.SelectedItems.Count <> 1 Then Return

        Dim AD As ActiveDirectory = list.SelectedItems(0).Tag
        Dim wasFound As Boolean = False

        'Select the TreeView node
        For Each node As TreeNode In mainF.tw.Nodes
            If DirectCast(node.Tag, ActiveDirectory) Is AD Then
                mainF.tw.SelectedNode = node.Nodes(list.SelectedItems(0).ImageIndex)
                wasFound = True
            End If
        Next

        If Not wasFound Then
            InitSearch()
            Return
        End If

        mainF.QuickSearch.ClearQuickSearch()

        mainF.list.SelectedItems.Clear()
        'Select the ListView item
        Dim targetItem As ListViewItem = mainF.list.Items(list.SelectedItems(0).Text)
        mainF.list.EnsureVisible(targetItem.Index)
        targetItem.Selected = True
        mainF.list.Select()
    End Sub

    Private Sub UpdateResultCounter()
        If list.Items.Count = 0 Then
            NoResultsLabel.Show()
        Else
            NoResultsLabel.Hide()
        End If

        If list.Items.Count = 1 Then
            list.Columns(0).Text = "Search results - " & list.Items.Count & " item"
        Else
            list.Columns(0).Text = "Search results - " & list.Items.Count & " items"
        End If
    End Sub

    ''' <summary>
    ''' Indicates whether a short delay should be used between typing, since more than 300 objects are being enqueried
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UseInterval() As Boolean
        If SRangeAll.Checked Then
            If totalObjCount > 600 Then
                Return True
            Else
                Return False
            End If
        Else
            If currentADObjCount > 400 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub DelayTimer_Tick(sender As Object, e As EventArgs) Handles SearchInterval.Tick
        SearchInterval.Stop()

        If SRangeAll.Checked Then
            SearchAll()
        Else
            Search(mainF.ADHandler.currentAD)
        End If

        PictureBox1.Hide()
        Label2.Hide()
        UpdateResultCounter()
    End Sub

    Private Sub SearchConditionsChanged(sender As Object, e As EventArgs) Handles SearchBox.TextChanged, SearchUsers.CheckedChanged, SearchGroups.CheckedChanged, SearchBuiltin.CheckedChanged, SRangeAll.CheckedChanged, SRangeCurrent.CheckedChanged, NoAutoRefresh.CheckedChanged
        list.Items.Clear()

        If SearchBox.TextLength = 0 Then
            SearchInterval.Stop()
            PictureBox1.Hide()
            Label2.Hide()
            NoResultsLabel.Hide()
            If list.Columns.Count <> 0 Then
                list.Columns(0).Text = "Search results"
            End If
            Return
        End If

        If UseInterval() Then
            SearchInterval.Stop()
            SearchInterval.Start()
            PictureBox1.Show()
            Label2.Show()
            Return
        End If

        If SRangeAll.Checked Then
            SearchAll()
        Else
            Search(mainF.ADHandler.currentAD)
        End If

        UpdateResultCounter()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles list.DoubleClick, cEdit.Click, cShowBuiltInDetails.Click
        If list.SelectedIndices.Count <> 1 Then Return

        Dim item As ListViewItem = list.SelectedItems(0)

        'Determine if the selected object is a user or a group
        If item.ImageIndex = 0 Then
            Dim newPropertyWindow As New EditUser

            If Not newPropertyWindow.Show(item.Text, item.Tag) Then
                'Since a false return value indicates something went wrong, reinit
                InitSearch()
            End If
        ElseIf item.ImageIndex = 1 Then
            Dim newPropertyWindow As New EditGroup

            If Not newPropertyWindow.Show(item.Text, item.Tag) Then
                'Since a false return value indicates something went wrong, reinit
                InitSearch()
            End If
        ElseIf item.ImageIndex = 2 Then
            Dim Principal As BuiltInPrincipal = DirectCast(item.Tag, ActiveDirectory).GetPrincipalByName(item.Text)
            TaskDialog(Handle, "Built-in principal information", Principal.Name & vbCrLf & Principal.SID, Principal.Description, TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_CLOSE_BUTTON, My.Resources.usercpl_1.Handle, 0, True, True)
        End If
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles list.KeyDown
        If e.KeyCode = Keys.Return Then ListView1_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub ContextMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuS.Opening
        If list.SelectedIndices.Count = 0 Then
            e.Cancel = True
        ElseIf list.SelectedIndices.Count = 1 Then
            cCopyName.Visible = True
            cJumpTo.Visible = True
            cRename.Visible = True
            cEdit.Visible = True
            cSeperator.Visible = True
        Else
            cCopyName.Visible = False
            cJumpTo.Visible = False
            cRename.Visible = False
            cEdit.Visible = False
            cSeperator.Visible = False
        End If

        cDelete.Visible = True
        cShowBuiltInDetails.Visible = False
        cCopySID.Visible = False

        For Each element As ListViewItem In list.SelectedItems
            If element.ImageIndex = 2 Then
                If list.SelectedIndices.Count <> 1 Then
                    e.Cancel = True
                    Exit For
                End If
                cRename.Visible = False
                cEdit.Visible = False
                cDelete.Visible = False
                cShowBuiltInDetails.Visible = True
                cCopySID.Visible = True
                Exit For
            End If
        Next
    End Sub

    Private Sub ListView1_SizeChanged(sender As Object, e As EventArgs) Handles list.SizeChanged
        ColumnHeader1.Width = list.Width - 4
    End Sub

    Private Sub ListView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles list.ColumnWidthChanging
        e.NewWidth = list.Columns(0).Width
        e.Cancel = True
    End Sub

    Private Sub SearchOptionsExpander_Click(sender As Object, e As EventArgs) Handles SearchOptionsExpander.Click
        If SearchOptionsVisible Then
            SearchOptionsVisible = False
        Else
            SearchOptionsVisible = True
        End If
    End Sub

    Private Sub cRename_Click(sender As Object, e As EventArgs) Handles cRename.Click
        list.SelectedItems(0).BeginEdit()
    End Sub

    Private Sub ListView1_BeforeLabelEdit(sender As Object, e As LabelEditEventArgs) Handles list.BeforeLabelEdit
        If list.SelectedItems.Count <> 1 OrElse list.SelectedItems(0).ImageIndex = 2 Then
            e.CancelEdit = True
        End If
    End Sub

    Private Sub ListView1_AfterLabelEdit(sender As Object, e As LabelEditEventArgs) Handles list.AfterLabelEdit
        e.CancelEdit = True
        If e.Label Is Nothing OrElse e.Label = "" Then Return

        If ADHandler_C.RenameInitiated(list.Items(e.Item).Text, e.Label, list.SelectedItems(0).ImageIndex, list.SelectedItems(0).Tag, Handle) Then
            SearchConditionsChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub cCopyName_Click(sender As Object, e As EventArgs) Handles cCopyName.Click
        If list.SelectedItems.Count <> 1 Then Return
        Clipboard.SetText(list.SelectedItems(0).Text)
    End Sub

    Private Sub cCopySID_Click(sender As Object, e As EventArgs) Handles cCopySID.Click
        If list.SelectedItems.Count <> 1 OrElse list.SelectedItems(0).ImageIndex <> 2 Then Return
        Clipboard.SetText(DirectCast(list.SelectedItems(0).Tag, ActiveDirectory).GetPrincipalByName(list.SelectedItems(0).Text).SID)
    End Sub

    Private Sub UpdateAutoRefreshCheckBox(sender As Object, e As EventArgs) Handles SRangeCurrent.CheckedChanged
        NoAutoRefresh.Enabled = SRangeCurrent.Checked
    End Sub

    Private Sub cDelete_Click(sender As Object, e As EventArgs) Handles cDelete.Click
        For Each element As ListViewItem In list.SelectedItems
            'If there are built-in principals among the selected items, return
            If element.ImageIndex = 2 Then
                Return
            End If
        Next

        mainF.ADHandler.ShowDeleteDialog("object", "objects", Sub(item As ListViewItem)
                                                                  Dim AD As ActiveDirectory = DirectCast(item.Tag, ActiveDirectory)

                                                                  If item.ImageIndex = 0 Then
                                                                      If AD.UserExists(item.Text, Handle) Then
                                                                          AD.DeleteUser(item.Text, Handle, False)
                                                                      End If
                                                                  ElseIf item.ImageIndex = 1 Then
                                                                      If AD.GroupExists(item.Text, Handle) Then
                                                                          AD.DeleteGroup(item.Text, Handle, False)
                                                                      End If
                                                                  End If
                                                              End Sub, list.SelectedItems, Handle)
        mainF.ViewHandler.RefreshMainList()
        InitSearch()
    End Sub
End Class