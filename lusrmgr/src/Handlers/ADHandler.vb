Imports DsEntry = System.DirectoryServices.DirectoryEntry
Imports System.Runtime.InteropServices

Class ADHandler_C
    Private mainF As MainForm
    Private _currentAD As ActiveDirectory

    Public Sub New(mainForm As MainForm)
        mainF = mainForm
    End Sub

    Public Function areADsConnected() As Boolean
        Return mainF.tw.Nodes.Count <> 1
    End Function

    Public Property localAD As ActiveDirectory
        Get
            Return mainF.tw.Nodes(0).Tag
        End Get
        Private Set(value As ActiveDirectory)
            mainF.tw.Nodes(0).Tag = value 'The tag values of the TreeView map to their corresponding AD objects
        End Set
    End Property

    Public ReadOnly Property currentAD As ActiveDirectory
        Get
            Return _currentAD
        End Get
    End Property

    Public Event CurrentADChanged()

    Public Sub UpdateCurrentAD()
        If mainF.ViewHandler.GetView() = ViewHandler_C.View.MachineRoot Then
            If _currentAD IsNot mainF.tw.SelectedNode.Tag Then
                _currentAD = mainF.tw.SelectedNode.Tag
                RaiseEvent CurrentADChanged()
            End If
        Else
            If _currentAD IsNot mainF.tw.SelectedNode.Parent.Tag Then
                _currentAD = mainF.tw.SelectedNode.Parent.Tag
                RaiseEvent CurrentADChanged()
            End If
        End If
    End Sub

    Public Async Function InitLocalAD() As Task
        Try
            Dim ComputerName As String = Environment.MachineName
            If ComputerName = Nothing Then ComputerName = "Local Computer"
            mainF.tw.Nodes(0).Text = ComputerName & " (loading)"

            _currentAD = New ActiveDirectory(mainF)
            localAD = _currentAD

            While localAD.IsLoading()
                Await Task.Delay(10)
            End While

            If Not mainF.tw.IsDisposed Then
                mainF.tw.Nodes(0).ImageIndex = 2
                mainF.tw.Nodes(0).SelectedImageIndex = 2
                mainF.tw.Nodes(0).Text = ComputerName & " (this computer)"

                mainF.tw.Nodes(0).Nodes.Add("Users", "Users", 0, 0)
                mainF.tw.Nodes(0).Nodes.Add("Groups", "Groups", 1, 1)
                mainF.tw.Nodes(0).Nodes.Add("Built-in security principals", "Built-in security principals", 5, 5)

                mainF.tw.ExpandAll()
            End If

        Catch ex As Exception
            ShowUnknownErr(mainF.Handle, ex.Message)
        End Try

        RaiseEvent CurrentADChanged()
    End Function

    ''' <summary>
    ''' Returns an AD by its index in the TreeView.
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getAD(index As Integer)
        Return mainF.tw.Nodes(index).Tag
    End Function

    Enum ObjectType
        User
        Group
    End Enum

    Public Shared Function RenameInitiated(oldName As String, newName As String, objectType As ObjectType, AD As ActiveDirectory, parentWnd As IntPtr) As Boolean
        For Each c As Char In newName.ToCharArray()
            If isDisallowed(c) Then
                TaskDialog(parentWnd, "Local users and groups", "Invalid name", "The symbols / \ [ ] "" : ; | < > + = , ? * % @ cannot be used in user and group names.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_WARNING_ICON, 0)
                Return False
            End If
        Next

        If objectType = ADHandler_C.ObjectType.User Then
            If newName.Length > 20 Then
                TaskDialog(parentWnd, "Local users and groups", "Too long username", "The length of an username must not be longer than 20 characters.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_WARNING_ICON, 0)
                Return False
            Else
                Return AD.RenameUser(oldName, newName, parentWnd)
            End If
        ElseIf objectType = ADHandler_C.ObjectType.Group Then
            Return AD.RenameGroup(oldName, newName, parentWnd)
        End If
        Return False
    End Function

    Public Delegate Sub DeleteAction(item As ListViewItem)

    Public Sub ShowDeleteDialog(singular As String, plural As String, DeleteAction As DeleteAction, items As ListView.SelectedListViewItemCollection, parentWnd As IntPtr)
        Dim result As Integer

        Dim tdc As New TASKDIALOGCONFIG
        tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)

        Dim buttons As TASKDIALOG_BUTTON() = {
            New TASKDIALOG_BUTTON(IDYES, " Delete "),
            New TASKDIALOG_BUTTON(IDCANCEL, "Cancel")}

        tdc.cButtons = buttons.Length
        tdc.pButtons = arrPtr(buttons, TASKDIALOG_BUTTON.SIZE * tdc.cButtons)

        tdc.hwndParent = parentWnd
        tdc.pszMainIcon = TASKDIALOG_ICONS.TD_WARNING_ICON
        tdc.nDefaultButton = TASKDIALOG_RESULT.IDCANCEL

        If items.Count > 1 Then
            tdc.pszWindowTitle = "Delete " & plural
            tdc.pszMainInstruction = "Delete " & items.Count & " " & plural
            tdc.pszContent = "Are you sure that you want to delete the selected " & plural & "?"

            tdc.pszCollapsedControlText = "Show " & plural
            tdc.pszExpandedControlText = "Hide " & plural
            tdc.pszExpandedInformation = "The following " & plural & " will be deleted:"

            For Each item As ListViewItem In items
                tdc.pszExpandedInformation &= vbCrLf & " - " & item.Text
            Next
        Else
            Dim selectedObject As String = items(0).Text

            tdc.pszWindowTitle = "Delete " & singular
            tdc.pszMainInstruction = "Delete """ & selectedObject & """"
            tdc.pszContent = "Are you sure that you want to delete the " & singular & " " & selectedObject & " ?"
        End If

        TaskDialogIndirect(tdc, result, 0, 0)

        For i As Integer = 0 To buttons.Length - 1
            buttons(i).freem()
        Next
        Marshal.FreeHGlobal(tdc.pButtons)

        If result = TASKDIALOG_RESULT.IDYES Then
            Dim noAsk As Boolean = False

            For Each item As ListViewItem In items
                Try
                    DeleteAction(item)

                Catch ex As Exception

                    Dim isLastIteration As Boolean = items.IndexOf(item) = items.Count - 1

                    If noAsk Then
                        Exit Try
                    End If

                    Dim tdc_ As New TASKDIALOGCONFIG
                    Dim result_ As Integer = 0

                    tdc_.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc_)
                    tdc_.hwndParent = parentWnd
                    tdc_.pszMainIcon = TASKDIALOG_ICONS.TD_ERROR_ICON

                    tdc_.pszWindowTitle = "Local users and groups"
                    tdc_.pszMainInstruction = "Could not delete """ & item.Text & """"
                    tdc_.pszContent = ex.Message.Replace(vbCrLf, "")

                    Dim tdc_btn As TASKDIALOG_BUTTON()

                    If Not isLastIteration Then

                        tdc_btn = {
                            New TASKDIALOG_BUTTON(TASKDIALOG_RESULT.IDOK, "OK"),
                            New TASKDIALOG_BUTTON(TASKDIALOG_RESULT.IDCANCEL, "Cancel deleting")}

                        tdc_.cButtons = tdc_btn.Length
                        tdc_.pButtons = arrPtr(tdc_btn, TASKDIALOG_BUTTON.SIZE * tdc_.cButtons)
                        tdc_.pszVerificationText = "Don't ask again for the remaining " & plural
                    Else
                        tdc_.dwCommonButtons = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON
                    End If

                    TaskDialogIndirect(tdc_, result_, 0, noAsk)

                    If Not isLastIteration Then
                        For i As Integer = 0 To tdc_btn.Length - 1
                            tdc_btn(i).freem()
                        Next
                        Marshal.FreeHGlobal(tdc_.pButtons)
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
            mainF.ViewHandler.RefreshItemCount()
        End If
    End Sub
End Class
