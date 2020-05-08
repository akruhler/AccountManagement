Imports DsEntry = System.DirectoryServices.DirectoryEntry
Public Class Form1
    Public localAD As New ActiveDirectory(Me)
    Public connectedADs As New List(Of ActiveDirectory)
    Public showAdvanced As Boolean
    Public Shared ReadOnly disallowedChars As Char() = {"/"c, "\"c, "["c, "]"c, """"c, ":"c, ";"c, "|"c, "<"c, ">"c, "+"c, "="c, ","c, "?"c, "*"c, "%"c, "@"c}

    Private Connect As New Connect()

    Enum cTag
        Connected = -15
        Buffering = -20
    End Enum

    Public Function currentAD() As ActiveDirectory
        If isRootNode() Then
            If tw.SelectedNode.Index = 0 OrElse isShowingPrincipals() Then
                Return localAD
            Else
                Return connectedADs(tw.SelectedNode.Index - 1)
            End If
        Else
            If tw.SelectedNode.Parent.Index = 0 Then
                Return localAD
            Else
                Return connectedADs(tw.SelectedNode.Parent.Index - 1)
            End If
        End If
    End Function

    Public Sub refreshItemCount()
        If list.Items.Count = 1 Then
            status.Text = "1 element"
        Else
            status.Text = list.Items.Count & " elements"
        End If
        ListView1_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Public Function isShowingPrincipals() As Boolean
        If tw.SelectedNode Is Nothing Then Return False
        Return tw.SelectedNode.ImageIndex = 5
    End Function

    Public Function getIAD(AD As ActiveDirectory) As Integer
        If AD.Equals(localAD) Then
            Return 0
        Else
            Return connectedADs.IndexOf(AD) + 1
        End If
    End Function

    Public Function isRootNode() As Boolean

        If tw Is Nothing Then
            Return False
        End If

        If tw.SelectedNode Is Nothing Then
            tw.SelectedNode = tw.Nodes(0)
            Return True
        End If

        If tw.SelectedNode.Text = "Users" OrElse tw.SelectedNode.Text = "Groups" Then
            Return False
        End If
        Return True
    End Function

    Public Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        localAD.Disconnect()
        connectedADs.ForEach(Sub(AD As ActiveDirectory)
                                 AD.Disconnect()
                             End Sub)
    End Sub

    Private Sub PerformMenuRendering()
        MenuStrip1.Renderer = New clsMenuRenderer
        ContextMenuStrip1.Renderer = New clsMenuRenderer
        ContextMenuStrip2.Renderer = New clsMenuRenderer

        '// 0 = top, 1 = bottom, 2 = left, 3 = right
        Dim X As Int32 = cfgInt("CommandBarX", ToolStrip1.Left)
        Dim Y As Int32 = cfgInt("CommandBarY", ToolStrip1.Top)

        Dim QX As Int32 = cfgInt("QuickSearchX", QSBar.Left)
        Dim QY As Int32 = cfgInt("QuickSearchY", QSBar.Top)

        Dim QSLayout As Int32 = cfgInt("QuickSearch")
        Dim CommandBarLayout As Int32 = cfgInt("CommandBar")

        Select Case CommandBarLayout
            Case 0
                ToolStripContainer1.TopToolStripPanel.Join(ToolStrip1, X, Y)
            Case 1
                ToolStripContainer1.BottomToolStripPanel.Join(ToolStrip1, X, Y)
            Case 2
                ToolStripContainer1.LeftToolStripPanel.Join(ToolStrip1, X, Y)
            Case 3
                ToolStripContainer1.RightToolStripPanel.Join(ToolStrip1, X, Y)
        End Select

        Select Case cfgInt("QuickSearchVisible")
            Case 0
                QSBar.Hide()
                QSMenu.Visible = True
                QSLabel.Visible = True
            Case 1
                QSBar.Show()
                QSMenu.Visible = False
                QSLabel.Visible = False
            Case 2
                QSMenu.Visible = False
                QSLabel.Visible = False
                QSBar.Hide()
        End Select

        '// 0 = top, 1 = bottom, 2 = left, 3 = right

        Select Case QSLayout
            Case 0
                ToolStripContainer1.TopToolStripPanel.Join(QSBar, QX, QY)
            Case 1
                ToolStripContainer1.BottomToolStripPanel.Join(QSBar, QX, QY)
            Case 2
                ToolStripContainer1.LeftToolStripPanel.Join(QSBar, QX, QY)
            Case 3
                ToolStripContainer1.RightToolStripPanel.Join(QSBar, QX, QY)
        End Select

        If Not cfgInt("MenuBar") = 0 Then
            MenuStrip1.Dock = DockStyle.Bottom
        End If

        If Not cfgBool("ShowStatusBar", True) Then
            StatusStrip1.Hide()
        End If

        If Not cfgBool("ShowCommands", True) Then
            ToolStrip1.Hide()
        End If
    End Sub

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ComputerName As String = My.Computer.Name
        If ComputerName = Nothing Then ComputerName = "Local Computer"
        tw.Nodes(0).Text = ComputerName & " (this computer)"
        tw.Nodes(0).Tag = cTag.Connected

        PerformMenuRendering()

        Try

            Dim c As New Loading(Me)

            loadingL.Tag = 0

            While localAD.isLoading()

                Await Task.Delay(100)

                If c.isBackground AndAlso tw.Nodes(0).Tag = cTag.Connected Then
                    If Not c.isClosing Then c.Close()

                    tw.Nodes(0).ImageIndex = 4
                    tw.Nodes(0).SelectedImageIndex = 4
                    tw.Nodes(0).Text = ComputerName & " (loading)"
                    tw.Nodes(0).Tag = cTag.Buffering
                    tw.ExpandAll()
                End If

                Select Case loadingL.Tag
                    Case Is < 24
                        loadingL.Tag += 1
                        If loadingL.Tag = 6 OrElse loadingL.Tag = 12 OrElse loadingL.Tag = 18 Then
                            loadingL.Text &= "."
                        End If
                    Case 24
                        loadingL.Tag = 0
                        loadingL.Text = loadingL.Text.Remove(loadingL.Text.Length - 3)
                End Select
            End While

            If tw.Nodes(0).Tag = cTag.Buffering Then
                tw.Nodes(0).ImageIndex = 2
                tw.Nodes(0).SelectedImageIndex = 2
                tw.Nodes(0).Text = ComputerName & " (this computer)"
                tw.Nodes(0).Tag = cTag.Connected

                TreeView1_AfterSelect(Nothing, Nothing)
            End If

            c.Close()
            tw.ExpandAll()

        Catch ex As Exception
            ShowUnknownErr(Handle, ex.Message)
        End Try
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tw.AfterSelect

        hiddenItems.Clear()
        QSMenu.Clear()
        QSearch.Clear()

        If tw.SelectedNode Is Nothing Then
            tw.SelectedNode = tw.Nodes(0)
            Return
        End If

        list.Columns(1).Width = 0
        list.Columns(0).Width = list.Width - 4

        NeuenBenutzerErstellenToolStripMenuItem.Enabled = True
        NeueGruppeErstellenToolStripMenuItem.Enabled = True
        tAdd.Enabled = False

        list.MultiSelect = True

        If tw.SelectedNode.Text = "Users" Then
            list.Items.Clear()
            list.Sorting = SortOrder.Ascending

            If tw.SelectedNode.Parent.Tag = cTag.Connected Then
                For Each u As String In currentAD().UserList.Keys
                    list.Items.Add(u, u, 0)
                Next

                loadingL.Hide()
                refreshItemCount()
            Else
                loadingL.Show()
            End If

            tAdd.Enabled = True

        ElseIf tw.SelectedNode.Text = "Groups" Then
            list.Items.Clear()
            list.Sorting = SortOrder.Ascending

            If tw.SelectedNode.Parent.Tag = cTag.Connected Then
                For Each g As String In currentAD().GroupList
                    list.Items.Add(g, g, 1)
                Next

                loadingL.Hide()
                refreshItemCount()
            Else
                loadingL.Show()
            End If

            tAdd.Enabled = True

        ElseIf isShowingPrincipals() Then
            loadingL.Hide()

            NeuenBenutzerErstellenToolStripMenuItem.Enabled = False
            NeueGruppeErstellenToolStripMenuItem.Enabled = False

            list.Columns(1).Width = list.Width / 3 - 3
            list.Columns(0).Width = list.Width - list.Columns(1).Width

            list.Items.Clear()
            list.MultiSelect = False
            list.Sorting = SortOrder.None

            For Each p In currentAD().BuiltInSecurityPrincipals
                list.Items.Add(New ListViewItem({p.Value, p.Key}, 1))
            Next

            refreshItemCount()
        Else
            list.Items.Clear()
            list.MultiSelect = False
            list.Sorting = SortOrder.None
            list.Items.Add("Users", 0)
            list.Items.Add("Groups", 1)

            loadingL.Hide()

            status.Text = ""
            itemcount.Text = ""
        End If
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles list.DoubleClick
        If list.SelectedIndices.Count < 1 Then Return
        If isRootNode() Then
            Select Case list.SelectedItems(0).Text
                Case "Users"
                    tw.SelectedNode = tw.SelectedNode.Nodes(0)
                Case "Groups"
                    tw.SelectedNode = tw.SelectedNode.Nodes(1)
            End Select
        Else
            If tw.SelectedNode.Text = "Users" Then EditUser.Show(list.SelectedItems(0).Text, Me)
            If tw.SelectedNode.Text = "Groups" Then EditGroup.Show(list.SelectedItems(0).Text, Me)
        End If
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles list.KeyDown
        If e.KeyCode = Keys.Return Then ListView1_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub BeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeendenToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AllesAktualisierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllesAktualisierenToolStripMenuItem.Click
        If currentAD().isLoading() = False Then
            currentAD().RefreshDS()
            If Not isRootNode() Then refreshItemCount()
        End If
    End Sub

    Private Sub NeuenBenutzerErstellenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeuenBenutzerErstellenToolStripMenuItem.Click
        AddUser.Show(Me)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list.SelectedIndexChanged
        itemcount.Text = ""

        If tw.SelectedNode Is Nothing Then
            tw.SelectedNode = tw.Nodes(0)
            Return
        End If

        If tw.SelectedNode.Text = "Users" Then

            GruppeEntfernenToolStripMenuItem.Enabled = False
            GruppeBearbeitenToolStripMenuItem.Enabled = False
            RenameGroupToolStripMenuItem.Enabled = False

            If list.SelectedIndices.Count = 1 Then
                BenutzerEntfernenToolStripMenuItem.Enabled = True
                BenutzerBearbeitenToolStripMenuItem.Enabled = True
                RenameUserToolStripMenuItem.Enabled = True

                itemcount.Text = "(1 selected)"
            ElseIf list.SelectedIndices.Count = 0 Then
                BenutzerEntfernenToolStripMenuItem.Enabled = False
                BenutzerBearbeitenToolStripMenuItem.Enabled = False
                RenameUserToolStripMenuItem.Enabled = False
            Else
                BenutzerEntfernenToolStripMenuItem.Enabled = True
                BenutzerBearbeitenToolStripMenuItem.Enabled = False
                RenameUserToolStripMenuItem.Enabled = False

                itemcount.Text = "(" & list.SelectedIndices.Count & " selected)"
            End If

        ElseIf tw.SelectedNode.Text = "Groups" Then

            BenutzerEntfernenToolStripMenuItem.Enabled = False
            BenutzerBearbeitenToolStripMenuItem.Enabled = False
            RenameUserToolStripMenuItem.Enabled = False

            If list.SelectedIndices.Count = 1 Then
                GruppeEntfernenToolStripMenuItem.Enabled = True
                GruppeBearbeitenToolStripMenuItem.Enabled = True
                RenameGroupToolStripMenuItem.Enabled = True

                itemcount.Text = "(1 selected)"
            ElseIf list.SelectedIndices.Count = 0 Then
                GruppeEntfernenToolStripMenuItem.Enabled = False
                GruppeBearbeitenToolStripMenuItem.Enabled = False
                RenameGroupToolStripMenuItem.Enabled = False
            Else
                GruppeEntfernenToolStripMenuItem.Enabled = True
                GruppeBearbeitenToolStripMenuItem.Enabled = False
                RenameGroupToolStripMenuItem.Enabled = False

                itemcount.Text = "(" & list.SelectedIndices.Count & " selected)"
            End If

        Else

            GruppeEntfernenToolStripMenuItem.Enabled = False
            GruppeBearbeitenToolStripMenuItem.Enabled = False
            RenameGroupToolStripMenuItem.Enabled = False

            BenutzerEntfernenToolStripMenuItem.Enabled = False
            BenutzerBearbeitenToolStripMenuItem.Enabled = False
            RenameUserToolStripMenuItem.Enabled = False

        End If
    End Sub

    Private Sub BenuzerBearbeitenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BenutzerBearbeitenToolStripMenuItem.Click
        EditUser.Show(list.SelectedItems(0).Text, Me)
    End Sub

    Private Sub GruppeBearbeitenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GruppeBearbeitenToolStripMenuItem.Click
        EditGroup.Show(list.SelectedItems(0).Text, Me)
    End Sub

    Private Sub BenutzerEntfernenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BenutzerEntfernenToolStripMenuItem.Click
        Dim result As Integer

        Dim tdc As New TASKDIALOGCONFIG
        tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)

        Dim buttons As TASKDIALOG_BUTTON() = {
            New TASKDIALOG_BUTTON(IDYES, " Delete "),
            New TASKDIALOG_BUTTON(IDCANCEL, "Cancel")}

        tdc.cButtons = buttons.Length
        tdc.pButtons = arrPtr(buttons, TASKDIALOG_BUTTON.SIZE * tdc.cButtons)

        tdc.hwndParent = Handle
        tdc.pszMainIcon = TASKDIALOG_ICONS.TD_WARNING_ICON
        tdc.nDefaultButton = TASKDIALOG_RESULT.IDCANCEL

        If list.SelectedIndices.Count > 1 Then
            tdc.pszWindowTitle = "Delete users"
            tdc.pszMainInstruction = "Delete " & list.SelectedIndices.Count & " users"
            tdc.pszContent = "Are you sure that you want to delete the selected users?"

            tdc.pszCollapsedControlText = "Show users"
            tdc.pszExpandedControlText = "Hide users"
            tdc.pszExpandedInformation = "The following users will be deleted:"

            For Each item As ListViewItem In list.SelectedItems
                tdc.pszExpandedInformation &= vbCrLf & " - " & item.Text
            Next
        Else
            Dim usr As String = list.SelectedItems(0).Text

            tdc.pszWindowTitle = "Delete user"
            tdc.pszMainInstruction = "Delete """ & usr & """"
            tdc.pszContent = "Are you sure that you want to delete the user " & usr & " ?"
        End If

        TaskDialogIndirect(tdc, result, 0, 0)

        For i As Integer = 0 To buttons.Length - 1
            buttons(i).freem()
        Next
        free(tdc.pButtons)

        If result = TASKDIALOG_RESULT.IDYES Then
            Dim noAsk As Boolean = False

            For Each item As ListViewItem In list.SelectedItems
                Try
                    currentAD().DeleteUser(item.Text)
                Catch ex As Exception

                    If noAsk Then
                        Exit Try
                    End If

                    Dim tdc_ As New TASKDIALOGCONFIG
                    Dim result_ As Integer = 0

                    tdc_.cbSize = sizeof(tdc_)
                    tdc_.hwndParent = Handle
                    tdc_.pszMainIcon = TASKDIALOG_ICONS.TD_ERROR_ICON

                    tdc_.pszWindowTitle = "Local users and groups"
                    tdc_.pszMainInstruction = "Could not delete """ & item.Text & """"
                    tdc_.pszContent = ex.Message.Replace(vbCrLf, "")

                    Dim tdc_btn As TASKDIALOG_BUTTON()

                    If Not list.SelectedItems.IndexOf(item) = list.SelectedItems.Count - 1 Then

                        tdc_btn = {
                            New TASKDIALOG_BUTTON(TASKDIALOG_RESULT.IDOK, "OK"),
                            New TASKDIALOG_BUTTON(TASKDIALOG_RESULT.IDCANCEL, "Cancel deleting")}

                        tdc_.cButtons = tdc_btn.Length
                        tdc_.pButtons = arrPtr(tdc_btn, TASKDIALOG_BUTTON.SIZE * tdc_.cButtons)
                        tdc_.pszVerificationText = "Don't ask again for the remaining users"
                    Else
                        tdc_.dwCommonButtons = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON
                    End If

                    TaskDialogIndirect(tdc_, result_, 0, noAsk)

                    If Not list.SelectedItems.IndexOf(item) = list.SelectedItems.Count - 1 Then
                        For i As Integer = 0 To tdc_btn.Length - 1
                            tdc_btn(i).freem()
                        Next
                        free(tdc_.pButtons)
                    Else
                        Exit For
                    End If

                    If result_ = IDOK Then
                        Continue For
                    Else
                        Exit For
                    End If
                End Try
            Next
            currentAD().RefreshDS()
            refreshItemCount()
        End If
    End Sub

    Private Sub GruppeEntfernenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GruppeEntfernenToolStripMenuItem.Click
        Dim tdc As New TASKDIALOGCONFIG
        Dim result As Integer

        tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)

        Dim buttons As TASKDIALOG_BUTTON() = {
            New TASKDIALOG_BUTTON(IDYES, " Delete "),
            New TASKDIALOG_BUTTON(IDCANCEL, "Cancel")}

        tdc.cButtons = buttons.Length
        tdc.pButtons = arrPtr(buttons, TASKDIALOG_BUTTON.SIZE * tdc.cButtons)

        tdc.hwndParent = Handle
        tdc.pszMainIcon = TASKDIALOG_ICONS.TD_WARNING_ICON
        tdc.nDefaultButton = TASKDIALOG_RESULT.IDCANCEL

        If list.SelectedIndices.Count > 1 Then
            tdc.pszWindowTitle = "Delete groups"
            tdc.pszMainInstruction = "Delete " & list.SelectedIndices.Count & " groups"
            tdc.pszContent = "Are you sure that you want to delete the selected groups?"

            tdc.pszCollapsedControlText = "Show groups"
            tdc.pszExpandedControlText = "Hide groups"
            tdc.pszExpandedInformation = "The following groups will be deleted:"

            For Each item As ListViewItem In list.SelectedItems
                tdc.pszExpandedInformation &= vbCrLf & " - " & item.Text
            Next
        Else
            Dim g As String = list.SelectedItems(0).Text

            tdc.pszWindowTitle = "Delete group"
            tdc.pszMainInstruction = "Delete """ & g & """"
            tdc.pszContent = "Are you sure that you want to delete the group " & g & " ?"
        End If

        TaskDialogIndirect(tdc, result, 0, 0)

        For i As Integer = 0 To buttons.Length - 1
            buttons(i).freem()
        Next
        free(tdc.pButtons)

        If result = TASKDIALOG_RESULT.IDYES Then
            Dim noAsk As Boolean = False

            For Each item As ListViewItem In list.SelectedItems
                Try
                    currentAD().DeleteGroup(item.Text)
                Catch ex As Exception

                    If noAsk Then
                        Exit Try
                    End If

                    Dim tdc_ As New TASKDIALOGCONFIG
                    Dim result_ As Integer = 0

                    tdc_.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc_)
                    tdc_.hwndParent = Handle
                    tdc_.pszMainIcon = TASKDIALOG_ICONS.TD_ERROR_ICON

                    tdc_.pszWindowTitle = "Local users and groups"
                    tdc_.pszMainInstruction = "Could not delete """ & item.Text & """"
                    tdc_.pszContent = ex.Message.Replace(vbCrLf, "")

                    Dim tdc_btn As TASKDIALOG_BUTTON()

                    If Not list.SelectedItems.IndexOf(item) = list.SelectedItems.Count - 1 Then

                        tdc_btn = {
                            New TASKDIALOG_BUTTON(TASKDIALOG_RESULT.IDOK, "OK"),
                            New TASKDIALOG_BUTTON(TASKDIALOG_RESULT.IDCANCEL, "Cancel deleting")}

                        tdc_.cButtons = tdc_btn.Length
                        tdc_.pButtons = arrPtr(tdc_btn, TASKDIALOG_BUTTON.SIZE * tdc_.cButtons)
                        tdc_.pszVerificationText = "Don't ask again for the remaining groups"
                    Else
                        tdc_.dwCommonButtons = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON
                    End If

                    TaskDialogIndirect(tdc_, result_, 0, noAsk)

                    If Not list.SelectedItems.IndexOf(item) = list.SelectedItems.Count - 1 Then
                        For i As Integer = 0 To tdc_btn.Length - 1
                            tdc_btn(i).freem()
                        Next
                        free(tdc_.pButtons)
                    Else
                        Exit For
                    End If

                    If result_ = IDOK Then
                        Continue For
                    Else
                        Exit For
                    End If
                End Try
            Next
            currentAD().RefreshDS()
            refreshItemCount()
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        ADD.Visible = True
        CopyNameToolStripMenuItem.Visible = False
        CopySIDToolStripMenuItem.Visible = False

        If isRootNode() Then
            If list.SelectedItems.Count = 0 Then e.Cancel = True : Return
            OPEN.Visible = True
            REMOVE.Visible = False
            EDIT.Visible = False
            RENAME.Visible = False

            If isShowingPrincipals() Then
                ADD.Visible = False
                OPEN.Visible = False
                CopyNameToolStripMenuItem.Visible = True
                CopySIDToolStripMenuItem.Visible = True
            End If

            Return
        End If
        OPEN.Visible = False
        If list.SelectedIndices.Count = 1 Then
            REMOVE.Visible = True
            EDIT.Visible = True
            RENAME.Visible = True
        ElseIf list.SelectedIndices.Count = 0 Then
            REMOVE.Visible = False
            EDIT.Visible = False
            RENAME.Visible = False
        ElseIf list.SelectedIndices.Count > 1 Then
            EDIT.Visible = False
            RENAME.Visible = False
            REMOVE.Visible = True
        End If
    End Sub

    Private Sub ADD_Click(sender As Object, e As EventArgs) Handles ADD.Click
        If tw.SelectedNode.Text = "Users" Then AddUser.Show(Me)
        If tw.SelectedNode.Text = "Groups" Then AddGroup.Show(Me)
        If list.SelectedIndices.Count < 1 Then Return
        If list.SelectedItems(0).Text = "Users" Then AddUser.Show(Me)
        If list.SelectedItems(0).Text = "Groups" Then AddGroup.Show(Me)
    End Sub

    Private Sub REMOVE_Click(sender As Object, e As EventArgs) Handles REMOVE.Click
        If tw.SelectedNode.Text = "Users" Then BenutzerEntfernenToolStripMenuItem_Click(Nothing, Nothing)
        If tw.SelectedNode.Text = "Groups" Then GruppeEntfernenToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub EDIT_Click(sender As Object, e As EventArgs) Handles EDIT.Click
        If tw.SelectedNode.Text = "Users" Then BenuzerBearbeitenToolStripMenuItem_Click(Nothing, Nothing)
        If tw.SelectedNode.Text = "Groups" Then GruppeBearbeitenToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub NeueGruppeErstellenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeueGruppeErstellenToolStripMenuItem.Click
        AddGroup.Show(Me)
    End Sub

    Private Sub ListView1_SizeChanged(sender As Object, e As EventArgs) Handles list.SizeChanged
        If isShowingPrincipals() Then
            list.Columns(1).Width = list.Width / 3 - 3
            list.Columns(0).Width = list.Width - list.Columns(1).Width
            Return
        End If

        list.Columns(0).Width = list.Width - 4
    End Sub

    Private Sub ListView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles list.ColumnWidthChanging
        If isShowingPrincipals() Then Return

        e.NewWidth = list.Columns(0).Width
        e.Cancel = True
    End Sub

    Private Sub OPEN_Click(sender As Object, e As EventArgs) Handles OPEN.Click
        ListView1_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub AboutThisProgramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutThisProgramToolStripMenuItem.Click
        About.ContextMenuStrip1.Renderer = New clsMenuRenderer()
        About.ShowDialog()
    End Sub

    Private Sub RENAME_Click(sender As Object, e As EventArgs) Handles RENAME.Click, RenameGroupToolStripMenuItem.Click, RenameUserToolStripMenuItem.Click
        If list.SelectedIndices.Count <> 1 Then Return

        list.SelectedItems(0).BeginEdit()
    End Sub

    Private Sub ListView1_AfterLabelEdit(sender As Object, e As LabelEditEventArgs) Handles list.AfterLabelEdit
        e.CancelEdit = True
        Try
            If e.Label Is Nothing OrElse e.Label = "" Then Return

            For Each c As Char In e.Label.ToCharArray()
                If disallowedChars.Contains(c) Then
                    TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Invalid name", "The symbols / \ [ ] "" : ; | < > + = , ? * % @ cannot be used in user and group names.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_WARNING_ICON, 0)
                    Return
                End If
            Next

            If e.Label.Length > 20 AndAlso tw.SelectedNode.Text = "Users" Then
                TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Too long username", "The length of an username must not be longer than 20 characters.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_WARNING_ICON, 0)
                Return
            End If

            If tw.SelectedNode.Text = "Users" Then
                Dim uD As DsEntry = currentAD().FindUser(list.Items(e.Item).Text, Handle)

                If uD Is Nothing Then
                    Return
                End If

                If e.Label = uD.Name Then Return

                uD.Rename(e.Label)
                uD.CommitChanges()
                currentAD().RefreshDS()
            ElseIf tw.SelectedNode.Text = "Groups" Then
                Dim gD As DsEntry = currentAD().FindGroup(list.Items(e.Item).Text, Handle)

                If gD Is Nothing Then
                    Return
                End If

                If e.Label = gD.Name Then Return

                gD.Rename(e.Label)
                gD.CommitChanges()
                currentAD().RefreshDS()
            End If

        Catch ex As UnauthorizedAccessException
            TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Access denied", "You are not allowed to perform this operation." & vbCrLf & "Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
        Catch ex As Runtime.InteropServices.COMException
            ShowCOMErr(ex.ErrorCode, Handle, ex.Message)
        End Try

        refreshItemCount()
    End Sub

    Private Sub ListView1_BeforeLabelEdit(sender As Object, e As LabelEditEventArgs) Handles list.BeforeLabelEdit
        If isRootNode() Then
            e.CancelEdit = True
        End If
    End Sub

    Dim searchUser As Boolean = True
    Dim searchGroup As Boolean = True
    Dim searchOnAll As Boolean = True

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        Search.ContextMenuStrip1.Renderer = New clsMenuRenderer

        Search.CheckBox1.Checked = searchUser
        Search.CheckBox2.Checked = searchGroup
        If connectedADs.Count > 0 Then
            Search.CheckBox3.Checked = searchOnAll
        End If

        If Search.Show(Me) = Windows.Forms.DialogResult.Retry Then
            list.Select()
        End If

        searchUser = Search.CheckBox1.Checked
        searchGroup = Search.CheckBox2.Checked
        If connectedADs.Count > 0 Then
            searchOnAll = Search.CheckBox3.Checked
        End If

        Search.Dispose()
    End Sub

    Private Async Sub ConnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectToolStripMenuItem.Click
        Dim c As Connecting

        Try
            If Connect.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim addr As String = Connect.TextBox1.Text
                c = New Connecting(Me)


                '/////// DNS lookup ///////////////////////////////////
                Try
                    c.SetText("Resolving host name")

                    Dim tmp As String = addr
                    tmp = (Await Net.Dns.GetHostEntryAsync(addr)).HostName

                    If tmp = "" Then
                        tmp = addr
                    Else
                        addr = tmp
                    End If
                Catch ex As Exception
                    c.Close()

                    Dim result As Integer

                    TASKDIALOG.TaskDialog(Handle, nullptr, "Connection error", "Address could not be found", "The DNS entry of the given host address could not be found. Make sure the address is correct and an internet connection is available.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_RETRY_BUTTON Or TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_CLOSE_BUTTON, TD_ERROR_ICON, result)

                    If result = IDRETRY Then
                        Connect.TextBox1.Text = addr
                        Connect.TextBox1.SelectAll()

                        ConnectToolStripMenuItem_Click(Nothing, Nothing)
                    End If

                    Return
                End Try
                '//////////////////////////////////////////////////


                '/////// Set display name /////////////////////////
                Dim dspName As String = addr
                If Connect.TextBox2.TextLength > 0 Then
                    dspName = Connect.TextBox2.Text
                End If
                '//////////////////////////////////////////////////

                Connect.TextBox1.Text = ""
                Connect.TextBox1.Select()

                Dim newAD As ActiveDirectory

                '/////// Authentication //////////////////////////
                If Connect.promptAuth.Checked = False Then
                    c.SetText(addr, True)
                    'Create AD object, connect
                    newAD = New ActiveDirectory(addr, Me, dspName)
                Else
                    c.SetText("Waiting for authentication")

                    Dim auth As New Auth
                    Dim cred As Credentials = auth.Authenticate()

                    If auth.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        auth.Dispose()
                        c.Close()

                        Return
                    End If

                    auth.Dispose()

                    c.SetText(addr, True)

                    'Create AD object, connect with credentials
                    newAD = New ActiveDirectory(addr, cred.Username, cred.Password, Me, dspName)

                    cred.Username = ""
                    cred.Password = ""
                End If
                '//////////////////////////////////////////////////

                While newAD.isLoading()

                    If newAD.conErr Then 'An error occurred
                        c.Close()

                        Dim result As Integer

                        TASKDIALOG.TaskDialog(Handle, nullptr, "Connection error", "Could not connect to computer", "There was an error whilst connecting to " & addr & "." & vbCrLf &
                                                "Please ensure the host address and account credentials are correct, and that the remote computer is configured to allow connetions.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_RETRY_BUTTON Or TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_CLOSE_BUTTON, TD_ERROR_ICON, result)

                        If result = IDRETRY Then
                            Connect.TextBox1.Text = addr
                            Connect.TextBox1.SelectAll()

                            ConnectToolStripMenuItem_Click(Nothing, Nothing)
                        End If

                        Return
                    End If

                    Await Task.Delay(100)

                    If c.Cancel Then 'The user cancelled the process
                        c.Close()
                        newAD.Disconnect()
                        Return
                    End If
                End While

                c.Close()

                If Not newAD.testConnection() Then
                    Dim result As Integer

                    TASKDIALOG.TaskDialog(Handle, nullptr, "Connection error", "Could not connect to computer", "There was an error whilst connecting to " & addr & "." & vbCrLf &
                                            "Please ensure the host address and account credentials are correct, and that the remote computer is configured to allow connetions.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_RETRY_BUTTON Or TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_CLOSE_BUTTON, TD_ERROR_ICON, result)

                    If result = IDRETRY Then
                        Connect.TextBox1.Text = addr
                        Connect.TextBox1.SelectAll()

                        ConnectToolStripMenuItem_Click(Nothing, Nothing)
                    End If

                    Return
                End If

                connectedADs.Add(newAD)

                Dim newNode As TreeNode

                If builtinsecenabled() Then
                    newNode = tw.Nodes.Insert(tw.Nodes.Count - 1, dspName, dspName, 3, 3)
                Else
                    newNode = tw.Nodes.Add(dspName, dspName, 3, 3)
                End If

                newNode.Nodes.Add("Users", "Users", 0, 0)
                newNode.Nodes.Add("Groups", "Groups", 1, 1)
                newNode.Tag = cTag.Connected
            Else
                Connect.TextBox1.Text = ""
                Connect.TextBox1.Select()
            End If
        Catch ex As Exception
            If c IsNot Nothing Then
                c.Close()
            End If
            Dim result As Integer

            TASKDIALOG.TaskDialog(Handle, nullptr, "Unkown error", "Could not connect to computer", "An unkown error occurred whilst connecting to the computer." & vbCrLf &
                                    ex.Message.Replace(vbNewLine, ""), TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_RETRY_BUTTON Or TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_CLOSE_BUTTON, TD_ERROR_ICON, result)

            If result = IDRETRY Then
                Connect.TextBox1.SelectAll()

                ConnectToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End Try
    End Sub

    Private Sub ContextMenuStrip2_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening
        DisconnectToolStripMenuItem.Visible = canDisconnect()
        SetDisplayNameToolStripMenuItem.Visible = canDisconnect()

        If Not isRootNode() Then
            e.Cancel = True
            ContextMenuStrip1.Show(Cursor.Position)
        End If

        If isShowingPrincipals() Then
            HideToolStripMenuItem.Visible = True
        Else
            HideToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Function canDisconnect() As Boolean
        If Not isRootNode() Then
            Return False
        End If

        If tw.SelectedNode.Index = 0 OrElse isShowingPrincipals() OrElse tw.SelectedNode.IsEditing Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub ConnectOtherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectOtherToolStripMenuItem.Click
        ConnectToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub DisconnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisconnectToolStripMenuItem.Click
        If isShowingPrincipals() Then
            HideToolStripMenuItem_Click(Nothing, Nothing)
        End If
        If Not canDisconnect() Then Return
        If isRootNode() Then
            connectedADs(tw.SelectedNode.Index - 1).Disconnect()
            connectedADs.RemoveAt(tw.SelectedNode.Index - 1)
            tw.SelectedNode.Remove()
        End If
    End Sub

    Private Sub tw_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tw.NodeMouseClick
        tw.SelectedNode = e.Node
        list.SelectedIndices.Clear()
    End Sub

    Private Sub ExpandAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpandAllToolStripMenuItem.Click
        tw.ExpandAll()
    End Sub

    Private Sub CollapseAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CollapseAllToolStripMenuItem.Click
        Dim cRootNode As TreeNode

        If isRootNode() Then
            cRootNode = tw.SelectedNode
        Else
            cRootNode = tw.SelectedNode.Parent
        End If

        tw.CollapseAll()
        tw.SelectedNode = cRootNode
    End Sub

    Private Sub WarningsDismissedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WarningsDismissedToolStripMenuItem.Click
        Warnings.Show(Me)
    End Sub

    Private Sub tw_BeforeLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles tw.BeforeLabelEdit
        If Not canDisconnect() OrElse Not isRootNode() OrElse isShowingPrincipals() Then
            e.CancelEdit = True
            Return
        End If
    End Sub

    Private Sub SetDisplayNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetDisplayNameToolStripMenuItem.Click
        If canDisconnect() Then
            tw.SelectedNode.BeginEdit()
        End If
    End Sub

    Private Sub tw_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles tw.AfterLabelEdit
        currentAD().changeDisplayName(e.Label)

        e.CancelEdit = True
        tw.SelectedNode.Text = currentAD().displayName
    End Sub

    Private Function builtinsecenabled() As Boolean
        Return ViewBuiltinSecurityPrincipalsToolStripMenuItem.Text = "Hide built-in security principals"
    End Function

    Private Sub ViewBuiltinSecurityPrincipalsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewBuiltinSecurityPrincipalsToolStripMenuItem.Click
        If builtinsecenabled() Then
            ViewBuiltinSecurityPrincipalsToolStripMenuItem.Text = "View built-in security principals"
            tw.Nodes.Find("builtin", False)(0).Remove()
        Else
            ViewBuiltinSecurityPrincipalsToolStripMenuItem.Text = "Hide built-in security principals"
            tw.SelectedNode = tw.Nodes.Add("builtin", "Built-in security principals", 5, 5)
        End If
        
    End Sub

    Private Sub HideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideToolStripMenuItem.Click
        tw.SelectedNode.Remove()
        ViewBuiltinSecurityPrincipalsToolStripMenuItem.Text = "View built-in security principals"
    End Sub

    Private Sub CopyNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyNameToolStripMenuItem.Click
        If isShowingPrincipals() AndAlso list.SelectedIndices.Count = 1 Then
            Clipboard.SetText(list.SelectedItems(0).Text)
        Else
            ConnectToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub CopySIDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopySIDToolStripMenuItem.Click
        If isShowingPrincipals() AndAlso list.SelectedIndices.Count = 1 Then
            Clipboard.SetText(list.SelectedItems(0).SubItems(1).Text)
        End If
    End Sub

    Private Sub tSearch_Click(sender As Object, e As EventArgs) Handles tSearch.Click
        SearchToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub tConnect_Click(sender As Object, e As EventArgs) Handles tConnect.Click
        ConnectToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub tRefresh_Click(sender As Object, e As EventArgs) Handles tRefresh.Click
        AllesAktualisierenToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub RenameUserToolStripMenuItem_EnabledChanged(sender As Object, e As EventArgs) Handles RenameUserToolStripMenuItem.EnabledChanged, RenameGroupToolStripMenuItem.EnabledChanged
        If RenameGroupToolStripMenuItem.Enabled = False AndAlso RenameUserToolStripMenuItem.Enabled = False Then
            tRename.Enabled = False
        Else
            tRename.Enabled = True
        End If
    End Sub

    Private Sub BenutzerBearbeitenToolStripMenuItem_EnabledChanged(sender As Object, e As EventArgs) Handles BenutzerBearbeitenToolStripMenuItem.EnabledChanged, GruppeBearbeitenToolStripMenuItem.EnabledChanged
        If BenutzerBearbeitenToolStripMenuItem.Enabled = False AndAlso GruppeBearbeitenToolStripMenuItem.Enabled = False Then
            tEdit.Enabled = False
        Else
            tEdit.Enabled = True
        End If
    End Sub

    Private Sub GruppeEntfernenToolStripMenuItem_EnabledChanged(sender As Object, e As EventArgs) Handles GruppeEntfernenToolStripMenuItem.EnabledChanged, BenutzerEntfernenToolStripMenuItem.EnabledChanged
        If BenutzerEntfernenToolStripMenuItem.Enabled = False AndAlso GruppeEntfernenToolStripMenuItem.Enabled = False Then
            tDelete.Enabled = False
        Else
            tDelete.Enabled = True
        End If
    End Sub

    Private Sub tAdd_Click(sender As Object, e As EventArgs) Handles tAdd.Click
        If tw.SelectedNode.Text = "Users" Then
            AddUser.Show(Me)
        ElseIf tw.SelectedNode.Text = "Groups" Then
            AddGroup.Show(Me)
        End If
    End Sub

    Private Sub tDelete_Click(sender As Object, e As EventArgs) Handles tDelete.Click
        If tw.SelectedNode.Text = "Users" Then
            BenutzerEntfernenToolStripMenuItem_Click(Nothing, Nothing)
        ElseIf tw.SelectedNode.Text = "Groups" Then
            GruppeEntfernenToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tEdit_Click(sender As Object, e As EventArgs) Handles tEdit.Click
        If tw.SelectedNode.Text = "Users" Then
            BenuzerBearbeitenToolStripMenuItem_Click(Nothing, Nothing)
        ElseIf tw.SelectedNode.Text = "Groups" Then
            GruppeBearbeitenToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tRename_Click(sender As Object, e As EventArgs) Handles tRename.Click
        RENAME_Click(Nothing, Nothing)
    End Sub

    Private Sub Bar_DragDrop(sender As Object, e As EventArgs) Handles ToolStrip1.EndDrag, QSBar.EndDrag, MenuStrip1.EndDrag
        Config.SetVal("CommandBarX", ToolStrip1.Left, Handle)
        Config.SetVal("CommandBarY", ToolStrip1.Top, Handle)

        If ToolStripContainer1.TopToolStripPanel.Controls.Contains(ToolStrip1) Then
            Config.SetVal("CommandBar", 0, Handle)
        ElseIf ToolStripContainer1.BottomToolStripPanel.Controls.Contains(ToolStrip1) Then
            Config.SetVal("CommandBar", 1, Handle)
        ElseIf ToolStripContainer1.LeftToolStripPanel.Controls.Contains(ToolStrip1) Then
            Config.SetVal("CommandBar", 2, Handle)
        ElseIf ToolStripContainer1.RightToolStripPanel.Controls.Contains(ToolStrip1) Then
            Config.SetVal("CommandBar", 3, Handle)
        End If

        Config.SetVal("QuickSearchX", QSBar.Left, Handle)
        Config.SetVal("QuickSearchY", QSBar.Top, Handle)

        If ToolStripContainer1.TopToolStripPanel.Controls.Contains(QSBar) Then
            Config.SetVal("QuickSearch", 0, Handle)
        ElseIf ToolStripContainer1.BottomToolStripPanel.Controls.Contains(QSBar) Then
            Config.SetVal("QuickSearch", 1, Handle)
        ElseIf ToolStripContainer1.LeftToolStripPanel.Controls.Contains(QSBar) Then
            Config.SetVal("QuickSearch", 2, Handle)
        ElseIf ToolStripContainer1.RightToolStripPanel.Controls.Contains(QSBar) Then
            Config.SetVal("QuickSearch", 3, Handle)
        End If

        If ToolStripContainer1.TopToolStripPanel.Controls.Contains(MenuStrip1) Then

            Config.SetVal("MenuBar", 0, Handle)
            ToolStripContainer1.TopToolStripPanel.Join(MenuStrip1, 0, -1024)

        ElseIf ToolStripContainer1.BottomToolStripPanel.Controls.Contains(MenuStrip1) Then

            Config.SetVal("MenuBar", 2, Handle)
            ToolStripContainer1.BottomToolStripPanel.Join(MenuStrip1, 0, 1024)

        ElseIf ToolStripContainer1.LeftToolStripPanel.Controls.Contains(MenuStrip1) Then

            Config.SetVal("MenuBar", 3, Handle)
            ToolStripContainer1.LeftToolStripPanel.Join(MenuStrip1, -1024, 0)

        ElseIf ToolStripContainer1.RightToolStripPanel.Controls.Contains(MenuStrip1) Then

            Config.SetVal("MenuBar", 4, Handle)
            ToolStripContainer1.RightToolStripPanel.Join(MenuStrip1, 1024, 0)
        End If
    End Sub

    Public hiddenItems As List(Of ListViewItem) = New List(Of ListViewItem)()

    Public Sub QuickSearch(sender As Object, e As EventArgs) Handles QSearch.TextChanged

        list.Items.AddRange(hiddenItems.ToArray())
        hiddenItems.Clear()

        If QSearch.TextLength = 0 Then
            If Not isRootNode() OrElse isShowingPrincipals() Then
                refreshItemCount()
            Else
                list.Items.Clear()
                list.Items.Add("Users", 0)
                list.Items.Add("Groups", 1)
            End If
            Return
        End If

        For Each item As ListViewItem In list.Items
            If Not item.Text.ToLower().Contains(QSearch.Text.ToLower()) Then
                hiddenItems.Add(item)
                item.Remove()
            End If
        Next

        If Not isRootNode() OrElse isShowingPrincipals() Then
            status.Text = "Showing " & list.Items.Count & " out of " & list.Items.Count + hiddenItems.Count & " elements"
        End If
    End Sub

    Public Sub QuickSearch_Menu(sender As Object, e As EventArgs) Handles QSMenu.TextChanged

        list.Items.AddRange(hiddenItems.ToArray())
        hiddenItems.Clear()

        If QSMenu.TextLength = 0 Then
            If Not isRootNode() OrElse isShowingPrincipals() Then
                refreshItemCount()
            Else
                list.Items.Clear()
                list.Items.Add("Users", 0)
                list.Items.Add("Groups", 1)
            End If
            Return
        End If

        For Each item As ListViewItem In list.Items
            If Not item.Text.ToLower().Contains(QSMenu.Text.ToLower()) Then
                hiddenItems.Add(item)
                item.Remove()
            End If
        Next

        If Not isRootNode() OrElse isShowingPrincipals() Then
            status.Text = "Showing " & list.Items.Count & " out of " & list.Items.Count + hiddenItems.Count & " elements"
        End If
    End Sub

    Private Async Sub QSBar_BeginDrag(sender As Object, e As EventArgs) Handles QSBar.BeginDrag
        While QSBar.IsCurrentlyDragging

            If MenuStrip1.Dock = DockStyle.Top Then

                If PointToClient(Cursor.Position).Y < 0 Then

                    QSBar.Hide()
                    QSMenu.Visible = True
                    QSLabel.Visible = True
                    Config.SetVal("QuickSearchVisible", 0, Handle)
                Else

                    QSBar.Show()
                    QSMenu.Visible = False
                    QSLabel.Visible = False

                    Config.SetVal("QuickSearchVisible", 1, Handle)
                End If

            Else

                If PointToClient(Cursor.Position).Y > MenuStrip1.Top + MenuStrip1.Height / 2 Then

                    QSBar.Hide()
                    QSMenu.Visible = True
                    QSLabel.Visible = True
                    Config.SetVal("QuickSearchVisible", 0, Handle)

                Else

                    QSBar.Show()
                    QSMenu.Visible = False
                    QSLabel.Visible = False

                    Config.SetVal("QuickSearchVisible", 1, Handle)
                End If
            End If

            Await Task.Delay(100)
        End While
    End Sub

    Private Sub AppearanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AppearanceToolStripMenuItem.Click
        ViewSettings.Show(Me)
    End Sub
End Class