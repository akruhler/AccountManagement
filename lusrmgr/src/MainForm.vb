Imports System.Runtime.InteropServices
Imports DsEntry = System.DirectoryServices.DirectoryEntry
Public Class MainForm

    Friend ADHandler As New ADHandler_C(Me)
    Friend ViewHandler As New ViewHandler_C(Me)
    Friend MenuHandler As New MenuHandler_C(Me)
    Friend QuickSearch As New QuickSearch_C(Me)
    Friend PropertyHandler As New PropertyHandler_C(Me)

    Friend SearchWindow As Search
    Friend Shared ListIcons As ImageList

    Public Sub New()
        InitializeComponent()
        ListIcons = Icons
    End Sub

#Region "Helper methods"

    Private Delegate Function _DInvokeGetHandle() As IntPtr
    Private DInvokeGetHandle As New _DInvokeGetHandle(AddressOf InvokeGetHandle)

    Function InvokeGetHandle() As IntPtr
        If InvokeRequired Then
            Return Invoke(DInvokeGetHandle)
        Else
            Return Handle
        End If
    End Function

    ''' <summary>
    ''' Returns the number of selected items in the main list.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function lselc() As Integer
        Return list.SelectedIndices.Count
    End Function

    ''' <summary>
    ''' Indicates whether the selected node is a machine root of a connected computer.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isConnectedAD() As Boolean
        If Not ViewHandler.GetView() = ViewHandler_C.View.MachineRoot Then
            Return False
        End If

        If tw.SelectedNode.Index = 0 OrElse ViewHandler.GetView() = ViewHandler_C.View.BuiltInPrincipals OrElse tw.SelectedNode.IsEditing Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region

#Region "Window events"

    Public Sub MainFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If WindowHandler.isAnyOpen() AndAlso Not cfgBool("SuppressExitWarning") Then

            Dim result As Integer, dontShowAgain As Boolean

            Dim tdc As New TASKDIALOGCONFIG
            tdc.cbSize = Marshal.SizeOf(tdc)
            tdc.hwndParent = Handle

            Dim buttons As TASKDIALOG_BUTTON() = {
                New TASKDIALOG_BUTTON(IDYES, "Close windows and exit"),
                New TASKDIALOG_BUTTON(IDCANCEL, "Go back")}

            tdc.cButtons = buttons.Length
            tdc.pButtons = arrPtr(buttons, TASKDIALOG_BUTTON.SIZE * tdc.cButtons)

            tdc.pszMainIcon = TASKDIALOG_ICONS.TD_APPLICATION
            tdc.dwFlags = TASKDIALOG_FLAGS.TDF_USE_COMMAND_LINKS Or TASKDIALOG_FLAGS.TDF_ALLOW_DIALOG_CANCELLATION
            tdc.pszVerificationText = "Don't show this warning again"

            tdc.pszWindowTitle = "Open property windows"
            tdc.pszMainInstruction = "Close open property windows?"
            tdc.pszContent = "There are still property windows open which might contain unsaved changes. Do you wish to exit anyways?"

            TaskDialogIndirect(tdc, result, 0, dontShowAgain)

            For i As Integer = 0 To buttons.Length - 1
                buttons(i).freem()
            Next
            Marshal.FreeHGlobal(tdc.pButtons)

            If result = IDYES AndAlso dontShowAgain Then
                Config.SetVal("SuppressExitWarning", 1, Handle)
            ElseIf result = IDCANCEL Then
                e.Cancel = True
                Return
            End If
        End If

        For Each AD As TreeNode In tw.Nodes
            If AD.Tag IsNot Nothing Then
                DirectCast(AD.Tag, ActiveDirectory).Disconnect()
            End If
        Next

        Config.SetVal("ShowAdvanced", Convert.ToInt32(AddUser.showAdvanced), Handle)
    End Sub

    Private Async Sub MainFormLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuHandler.PerformMenuRendering()
        Await ADHandler.InitLocalAD()
        If tw.SelectedNode Is Nothing Then tw.SelectedNode = tw.Nodes(0)
        MainTreeView_AfterSelect(Nothing, Nothing)
        ViewHandler.RefreshSearch()
        ListContextMenu.Close()
    End Sub

    Private Sub ExitTS_Click(sender As Object, e As EventArgs) Handles ExitTS.Click
        Close()
    End Sub
#End Region

#Region "Main tree events"

    Private Sub MainTreeView_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tw.AfterSelect

        Select Case tw.SelectedNode.ImageIndex
            Case 0
                ViewHandler.ViewChanged(ViewHandler_C.View.Users)
            Case 1
                ViewHandler.ViewChanged(ViewHandler_C.View.Groups)
            Case 5
                ViewHandler.ViewChanged(ViewHandler_C.View.BuiltInPrincipals)
            Case Else
                ViewHandler.ViewChanged(ViewHandler_C.View.MachineRoot)
        End Select
    End Sub

    Private Sub tw_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tw.NodeMouseClick
        tw.SelectedNode = e.Node
        list.SelectedIndices.Clear()
    End Sub

    Private Sub cExpand_Click(sender As Object, e As EventArgs) Handles cExpand.Click
        tw.ExpandAll()
    End Sub

    Private Sub cCollapse_Click(sender As Object, e As EventArgs) Handles cCollapse.Click
        Dim cRootNode As TreeNode

        If ViewHandler.GetView() = ViewHandler_C.View.MachineRoot Then
            cRootNode = tw.SelectedNode
        Else
            cRootNode = tw.SelectedNode.Parent
        End If

        tw.CollapseAll()
        tw.SelectedNode = cRootNode
    End Sub

    Private Sub tw_BeforeLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles tw.BeforeLabelEdit
        If Not isConnectedAD() OrElse Not ViewHandler.GetView() = ViewHandler_C.View.MachineRoot OrElse ViewHandler.GetView() = ViewHandler_C.View.BuiltInPrincipals Then
            e.CancelEdit = True
        End If
    End Sub

    Private Sub tw_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles tw.AfterLabelEdit
        If e.Label Is Nothing Then Return

        ADHandler.currentAD.ChangeDisplayName(e.Label)

        e.CancelEdit = True
        e.Node.Text = ADHandler.currentAD.GetDisplayName()

        ViewHandler.RefreshSearch()
    End Sub
#End Region

#Region "Main ListView events"

    Private Sub list_DoubleClick(sender As Object, e As EventArgs) Handles list.DoubleClick, cOpen.Click, cShowBuiltInDetails.Click
        If lselc() < 1 Then Return

        Select Case ViewHandler.GetView()
            Case ViewHandler_C.View.MachineRoot
                tw.SelectedNode = tw.SelectedNode.Nodes.Find(list.SelectedItems(0).Text, False)(0)
            Case ViewHandler_C.View.Users
                Dim newPropertyWindow As New EditUser
                newPropertyWindow.Show(list.SelectedItems(0).Text, ADHandler.currentAD)
            Case ViewHandler_C.View.Groups
                Dim newPropertyWindow As New EditGroup
                newPropertyWindow.Show(list.SelectedItems(0).Text, ADHandler.currentAD)
            Case ViewHandler_C.View.BuiltInPrincipals
                TaskDialog(Handle, "Built-in principal information", list.SelectedItems(0).Text & vbCrLf & list.SelectedItems(0).SubItems(1).Text, ADHandler.currentAD.GetPrincipalBySID(list.SelectedItems(0).SubItems(1).Text).Description, TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_CLOSE_BUTTON, My.Resources.usercpl_1.Handle, 0, True, True)
        End Select
    End Sub

    Private Sub list_KeyDown(sender As Object, e As KeyEventArgs) Handles list.KeyDown
        If e.KeyCode = Keys.Return Then list_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub list_AfterLabelEdit(sender As Object, e As LabelEditEventArgs) Handles list.AfterLabelEdit
        e.CancelEdit = True
        If e.Label Is Nothing OrElse e.Label = "" Then
            Return
        End If

        If ADHandler_C.RenameInitiated(list.Items(e.Item).Text, e.Label, If(ViewHandler.GetView() = ViewHandler_C.View.Users, 0, 1), ADHandler.currentAD, Handle) Then
            ViewHandler.RefreshItemCount()
        End If
    End Sub

    Private Sub list_BeforeLabelEdit(sender As Object, e As LabelEditEventArgs) Handles list.BeforeLabelEdit
        If ViewHandler.GetView() = ViewHandler_C.View.MachineRoot OrElse ViewHandler.GetView() = ViewHandler_C.View.BuiltInPrincipals Then
            e.CancelEdit = True
        End If
    End Sub

    Private Sub list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list.SelectedIndexChanged
        ViewHandler.UpdateSelectionCounter()
        MenuHandler.UpdateMenuControls()
    End Sub

    Private Sub list_SizeChanged(sender As Object, e As EventArgs) Handles list.SizeChanged
        If ViewHandler.GetView() = ViewHandler_C.View.BuiltInPrincipals OrElse ViewHandler.GetView() = ViewHandler_C.View.Users Then
            list.Columns(1).Width = list.Width / 3 - 3
            list.Columns(0).Width = list.Width - list.Columns(1).Width
            Return
        End If

        list.Columns(0).Width = list.Width - 4
    End Sub

    Private Sub list_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles list.ColumnWidthChanging
        If ViewHandler.GetView() = ViewHandler_C.View.BuiltInPrincipals OrElse ViewHandler.GetView() = ViewHandler_C.View.Users Then Return

        e.NewWidth = list.Columns(0).Width
        e.Cancel = True
    End Sub

#End Region

#Region "Menu events"

#Region "Main"
    Private Sub WarningsDismissedTS_Click(sender As Object, e As EventArgs) Handles WarningsDismissedTS.Click
        Warnings.Show()
    End Sub

    Private Sub AppearanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AppearanceTS.Click
        ViewSettings.Show(Me)
    End Sub

    Private Sub AboutThisProgramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutTS.Click
        Using About As New About
            About.ShowDialog()
        End Using
    End Sub
#End Region

#Region "Quick search"

    Public Sub QuickSearch_Toolbar(sender As Object, e As EventArgs) Handles QSearch.TextChanged
        QuickSearch.QuickSearchInitiated(QSearch.Text)
    End Sub

    Public Sub QuickSearch_Menu(sender As Object, e As EventArgs) Handles QSMenu.TextChanged
        QuickSearch.QuickSearchInitiated(QSMenu.Text)
    End Sub
#End Region

#Region "Builtin"
    Private Sub cCopyName_Click(sender As Object, e As EventArgs) Handles cCopyName.Click
        If ViewHandler.GetView() = ViewHandler_C.View.BuiltInPrincipals AndAlso lselc() = 1 Then
            Clipboard.SetText(list.SelectedItems(0).Text)
        Else
            Connect(Nothing, Nothing)
        End If
    End Sub

    Private Sub cCopySID_Click(sender As Object, e As EventArgs) Handles cCopySID.Click
        If ViewHandler.GetView() = ViewHandler_C.View.BuiltInPrincipals AndAlso lselc() = 1 Then
            Clipboard.SetText(list.SelectedItems(0).SubItems(1).Text)
        End If
    End Sub
#End Region

#Region "Edit"

    Private Sub EditUserTS_Click(sender As Object, e As EventArgs) Handles EditUserTS.Click
        Dim newPropertyWindow As New EditUser
        newPropertyWindow.Show(list.SelectedItems(0).Text, ADHandler.currentAD)
    End Sub

    Private Sub EditGroupTS_Click(sender As Object, e As EventArgs) Handles EditGroupTS.Click
        Dim newPropertyWindow As New EditGroup
        newPropertyWindow.Show(list.SelectedItems(0).Text, ADHandler.currentAD)
    End Sub

    Private Sub cEdit_Click(sender As Object, e As EventArgs) Handles cEdit.Click, tEdit.Click
        If ViewHandler.GetView() = ViewHandler_C.View.Users Then EditUserTS_Click(Nothing, Nothing) : Return
        If ViewHandler.GetView() = ViewHandler_C.View.Groups Then EditGroupTS_Click(Nothing, Nothing)
    End Sub
#End Region

#Region "Create new"
    Private Sub cCreate_Click(sender As Object, e As EventArgs) Handles cCreate.Click
        If ViewHandler.GetView() = ViewHandler_C.View.Users Then
            OpenAddUser(ADHandler.currentAD)
        ElseIf ViewHandler.GetView() = ViewHandler_C.View.Groups Then
            OpenAddGroup(ADHandler.currentAD)
        ElseIf lselc() < 1 Then
            Return
        ElseIf list.SelectedItems(0).Text = "Users" Then
            OpenAddUser(ADHandler.currentAD)
        ElseIf list.SelectedItems(0).Text = "Groups" Then
            OpenAddGroup(ADHandler.currentAD)
        End If
    End Sub

    Private Sub tAdd_Click(sender As Object, e As EventArgs) Handles tAdd.Click
        If ViewHandler.GetView() = ViewHandler_C.View.Users Then
            OpenAddUser(ADHandler.currentAD)
        ElseIf ViewHandler.GetView() = ViewHandler_C.View.Groups Then
            OpenAddGroup(ADHandler.currentAD)
        End If
    End Sub

    Private Sub CreateNewUserTS_Click(sender As Object, e As EventArgs) Handles CreateNewUserTS.Click
        OpenAddUser(ADHandler.currentAD)
    End Sub

    Private Sub CreateNewGroupTS_Click(sender As Object, e As EventArgs) Handles CreateNewGroupTS.Click
        OpenAddGroup(ADHandler.currentAD)
    End Sub
#End Region

#Region "Delete"
    Private Sub DeleteUserTS_Click(sender As Object, e As EventArgs) Handles DeleteUserTS.Click
        Dim AD As ActiveDirectory = ADHandler.currentAD
        ADHandler.ShowDeleteDialog("user", "users", New ADHandler_C.DeleteAction(Sub(item As ListViewItem)
                                                                                     AD.DeleteUser(item.Text, Handle, False)
                                                                                 End Sub), list.SelectedItems, Handle)
        ViewHandler.RefreshLists()
    End Sub

    Private Sub DeleteGroupTS_Click(sender As Object, e As EventArgs) Handles DeleteGroupTS.Click
        Dim AD As ActiveDirectory = ADHandler.currentAD
        ADHandler.ShowDeleteDialog("group", "groups", New ADHandler_C.DeleteAction(Sub(item As ListViewItem)
                                                                                       AD.DeleteGroup(item.Text, Handle, False)
                                                                                   End Sub), list.SelectedItems, Handle)
        ViewHandler.RefreshLists()
    End Sub

    Private Sub cDelete_Click(sender As Object, e As EventArgs) Handles cDelete.Click, tDelete.Click
        If ViewHandler.GetView() = ViewHandler_C.View.Users Then DeleteUserTS_Click(Nothing, Nothing) : Return
        If ViewHandler.GetView() = ViewHandler_C.View.Groups Then DeleteGroupTS_Click(Nothing, Nothing)
    End Sub
#End Region

#Region "Other"

    Private Sub SetPasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cSetPassword.Click
        Using pwdlg As New SetPw
            Dim cAD As ActiveDirectory = ADHandler.currentAD
            Dim user As DsEntry = cAD.FindUser(list.SelectedItems(0).Text, Handle)
            If user IsNot Nothing Then
                pwdlg.Show(user, cAD)
            End If
        End Using
    End Sub

    Private Sub cSetDspName_Click(sender As Object, e As EventArgs) Handles cSetDspName.Click
        If isConnectedAD() Then
            tw.SelectedNode.BeginEdit()
        End If
    End Sub

    Private Sub RefreshTS_Click(sender As Object, e As EventArgs) Handles RefreshTS.Click, tRefresh.Click
        If ADHandler.currentAD.IsLoading() = False Then
            ADHandler.currentAD.RefreshDS()
            If Not ViewHandler.GetView() = ViewHandler_C.View.MachineRoot Then ViewHandler.RefreshItemCount()
        End If
    End Sub

    Private Sub RefreshAll_Click(sender As Object, e As EventArgs) Handles RefreshAll.Click
        For Each node As TreeNode In tw.Nodes
            Dim AD As ActiveDirectory = node.Tag
            If AD.IsLoading() = False AndAlso AD IsNot ADHandler.currentAD Then
                AD.RefreshDS(True)
            End If
        Next
        ADHandler.currentAD.RefreshDS()

        If Not ViewHandler.GetView() = ViewHandler_C.View.MachineRoot Then ViewHandler.RefreshItemCount()
    End Sub

    Private Sub SearchTS_Click(sender As Object, e As EventArgs) Handles SearchTS.Click, tSearch.Click
        If SearchWindow IsNot Nothing AndAlso Not SearchWindow.IsDisposed Then
            SearchWindow.Show()
        Else
            SearchWindow = New Search(Me)
            SearchWindow.Show()
        End If
    End Sub

    Private Sub RENAME_Click(sender As Object, e As EventArgs) Handles cRename.Click, RenameGroupTS.Click, RenameUserTS.Click, tRename.Click
        If lselc() <> 1 Then Return

        list.SelectedItems(0).BeginEdit()
    End Sub

    Private Sub Database_DropDownOpening(sender As Object, e As EventArgs) Handles DatabaseToolStripMenuItem.DropDownOpening
        If ADHandler.areADsConnected Then
            RefreshAll.Visible = True
            RefreshAll.Text = "Refresh all connected machines"
            RefreshTS.Text = "Refresh users and groups on " & ADHandler.currentAD.GetDisplayName()
        Else
            RefreshAll.Visible = False
            RefreshAll.Text = ""
            RefreshTS.Text = "Refresh users and groups"
        End If
    End Sub
#End Region

#End Region

#Region "ContextMenuStrip handlers"

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ListContextMenu.Opening
        'The return value of PrehandleConextMenu() indicates whether the context menu should open or not.
        e.Cancel = Not MenuHandler.PrehandleContextMenu()
    End Sub

    Private Sub ContextMenuStrip2_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TwContextMenu.Opening
        Dim isConnectedADSelected As Boolean = isConnectedAD()
        cDisconnect.Visible = isConnectedADSelected
        cSetDspName.Visible = isConnectedADSelected

        If Not ViewHandler.GetView() = ViewHandler_C.View.MachineRoot Then
            e.Cancel = True
            If Not ViewHandler.GetView() = ViewHandler_C.View.BuiltInPrincipals Then ListContextMenu.Show(Cursor.Position)
        End If
    End Sub
#End Region

    Private Async Sub Connect(sender As Object, e As EventArgs) Handles ConnectTS.Click, tConnect.Click, cConnect.Click
        Dim loadingWindow As Connecting = Nothing

        Using Connect As New Connect
            Do
                Try
                    If Connect.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        Dim addr As String = Connect.hostAddress.Text
                        loadingWindow = New Connecting(Me)

                        '/////// WNetAddConnection /////////////////////////
                        loadingWindow.ControlBox = False
                        loadingWindow.SetText("Waiting for authentication")

                        Dim retry As Boolean = False

                        Do
                            Dim WNetConnectResult As SystemErrorCodes = Await WNetConnectAsync(addr, Connect.promptAuth.Checked)

                            If WNetConnectResult <> SystemErrorCodes.SUCCESS Then

                                loadingWindow.Hide()
                                ShowWNetAddConnectionError(WNetConnectResult, addr, Handle)

                                'The account lockout is not handled by the system network logon dialog, so it needs to be handled here (otherwise, the dialog aborts)
                                If WNetConnectResult = SystemErrorCodes.ERROR_ACCOUNT_LOCKED_OUT Then
                                    loadingWindow.Show(Me)
                                    Continue Do
                                End If
                                loadingWindow.Close()

                                If WNetConnectResult = SystemErrorCodes.ERROR_CANCELLED OrElse WNetConnectResult = SystemErrorCodes.ERROR_NOT_CONNECTED Then
                                    Return
                                Else
                                    retry = True
                                End If
                            End If

                            Exit Do
                        Loop
                        If retry Then Continue Do

                        '/////// Connect and initialise AD /////////////////
                        loadingWindow.ControlBox = True
                        loadingWindow.SetText("Establishing connection with " & addr)

                        Dim newAD As New ActiveDirectory(addr, Me)

                        '/////// AD loading process ///////////////////////
                        While newAD.IsLoading()

                            If newAD.ConnectionErrorOccurred() Then
                                loadingWindow.Close()
                                newAD.Disconnect()

                                Dim result As Integer

                                TaskDialog(Handle, "Connection error", "Could not connect to computer", "An error occurred whilst connecting to " & addr & "." & vbCrLf &
                                                        "Please ensure the host address and account credentials are correct, and that the remote computer is configured to allow connetions.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_RETRY_BUTTON Or TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_CLOSE_BUTTON, TD_ERROR_ICON, result)
                                If result = IDRETRY Then
                                    Continue Do
                                End If

                                Return
                            End If

                            Await Task.Delay(100)

                            If loadingWindow.isCancelled Then 'The user cancelled the process
                                loadingWindow.Close()
                                newAD.Disconnect()
                                Return
                            End If
                        End While

                        '/////// DNS lookup ///////////////////////////////////
                        loadingWindow.SetText("Waiting for DNS lookup")
                        Dim dnsTask As Task(Of String) = Connect.waitForDns

                        While Not dnsTask.IsCompleted
                            Await Task.Delay(100)

                            If loadingWindow.isCancelled Then 'The user cancelled the process
                                loadingWindow.Close()
                                newAD.Disconnect()
                                Return
                            End If
                        End While

                        Dim dspName As String = dnsTask.Result

                        If dspName = "" Then
                            dspName = addr
                        End If
                        newAD.ChangeDisplayName(dspName)

                        loadingWindow.Close()

                        '//////////////////////////////////////////////////

                        Dim newNode As TreeNode

                        newNode = tw.Nodes.Add(dspName, dspName, 3, 3)

                        newNode.Nodes.Add("Users", "Users", 0, 0)
                        newNode.Nodes.Add("Groups", "Groups", 1, 1)
                        If newAD.BuiltInPrincipals.Count > 0 Then
                            newNode.Nodes.Add("Built-in security principals", "Built-in security principals", 5, 5)
                        End If
                        newNode.Tag = newAD

                        ViewHandler.RefreshSearch()
                    End If

                    Return

                Catch ex As Exception
                    If loadingWindow IsNot Nothing Then
                        loadingWindow.Close()
                    End If
                    Dim result As Integer

                    TaskDialog(Handle, "Unkown error", "Could not connect to computer", "An unkown error occurred whilst connecting to the computer." & vbCrLf & ex.Message,
                                TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_RETRY_BUTTON Or TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_CLOSE_BUTTON, TD_ERROR_ICON, result)
                    If result = IDRETRY Then
                        Continue Do
                    End If

                    Return
                End Try
            Loop
        End Using
    End Sub

    Private Sub cDisconnect_Click(sender As Object, e As EventArgs) Handles cDisconnect.Click
        If isConnectedAD() Then
            DirectCast(tw.SelectedNode.Tag, ActiveDirectory).Disconnect()
            tw.SelectedNode.Remove()
            ViewHandler.RefreshSearch()
        End If
    End Sub

    Private Sub ShowUACSettings(sender As Object, e As EventArgs) Handles UACSettingsTS.Click
        Dim result As Integer = 0, radioResult As Integer = 0

        Dim tdc As New TASKDIALOGCONFIG
        tdc.cbSize = Marshal.SizeOf(tdc)

        Dim buttons As TASKDIALOG_BUTTON() = {
            New TASKDIALOG_BUTTON(IDOK, " Save "),
            New TASKDIALOG_BUTTON(IDCANCEL, " Cancel ")}

        tdc.cButtons = buttons.Length
        tdc.pButtons = arrPtr(buttons, TASKDIALOG_BUTTON.SIZE * tdc.cButtons)

        Dim radioButtons As TASKDIALOG_BUTTON() = {
            New TASKDIALOG_BUTTON(UACBehaviour.PromptUAC, "Prompt UAC for elevation"),
            New TASKDIALOG_BUTTON(UACBehaviour.LaunchWithoutPrivileges, "Launch without administrative privileges"),
            New TASKDIALOG_BUTTON(UACBehaviour.AskEveryTime, "Ask every time the program is launched")}

        tdc.nDefaultRadioButton = cfgInt("UACPrompt", UACBehaviour.AskEveryTime)
        If Not tdc.nDefaultRadioButton = UACBehaviour.PromptUAC AndAlso Not tdc.nDefaultRadioButton = UACBehaviour.LaunchWithoutPrivileges AndAlso Not tdc.nDefaultRadioButton = UACBehaviour.AskEveryTime Then
            tdc.nDefaultRadioButton = UACBehaviour.AskEveryTime
        End If

        tdc.cRadioButtons = radioButtons.Length
        tdc.pRadioButtons = arrPtr(radioButtons, TASKDIALOG_BUTTON.SIZE * tdc.cRadioButtons)

        tdc.pszMainIcon = TASKDIALOG_ICONS.TD_SHIELD_ICON
        tdc.hwndParent = Handle

        tdc.pszWindowTitle = "UAC settings"
        tdc.pszMainInstruction = "Change behavior of User Account Control when executing application using a standard user account"
        tdc.pszContent = "In order to be able to use this application without administrative privileges, you can configure its behavior when launched using a standard user account." &
            vbCrLf & vbCrLf & "When this application is launched without administrative privileges:"

        tdc.pszExpandedControlText = "Less information"
        tdc.pszCollapsedControlText = "More information"
        tdc.pszExpandedInformation = "If this application is not executed with administrative privileges, you might not be able to perform administrative tasks on the local machine, such as creating and editing users and groups. In order to still allow standard users to use this program (for example to only view the information or for the purpose of managing remote machines), you can configure the behavior of this application when launched without administrative privileges:"

        TaskDialogIndirect(tdc, result, radioResult, 0)

        For i As Integer = 0 To buttons.Length - 1
            buttons(i).freem()
        Next
        Marshal.FreeHGlobal(tdc.pButtons)

        For i As Integer = 0 To radioButtons.Length - 1
            radioButtons(i).freem()
        Next
        Marshal.FreeHGlobal(tdc.pRadioButtons)

        If result = IDOK Then
            Config.SetVal("UACPrompt", radioResult, Handle)
        End If
    End Sub

#Region "Toolbar dragging handlers"

    Private Sub Bar_DragDrop(sender As Object, e As EventArgs) Handles QSBar.EndDrag, MainToolStrip.EndDrag, MenuStrip1.EndDrag
        Config.SetVal("CommandBarX", MainToolStrip.Left, Handle)
        Config.SetVal("CommandBarY", MainToolStrip.Top, Handle)

        If ToolStripContainer1.TopToolStripPanel.Controls.Contains(MainToolStrip) Then
            Config.SetVal("CommandBar", 0, Handle)
        ElseIf ToolStripContainer1.BottomToolStripPanel.Controls.Contains(MainToolStrip) Then
            Config.SetVal("CommandBar", 1, Handle)
        ElseIf ToolStripContainer1.LeftToolStripPanel.Controls.Contains(MainToolStrip) Then
            Config.SetVal("CommandBar", 2, Handle)
        ElseIf ToolStripContainer1.RightToolStripPanel.Controls.Contains(MainToolStrip) Then
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
#End Region
End Class