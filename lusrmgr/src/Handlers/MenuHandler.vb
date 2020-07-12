Class MenuHandler_C
    Private mainF As MainForm

    Public Sub New(mainForm As MainForm)
        mainF = mainForm
    End Sub

    ''' <summary>
    ''' Renders the menu controls (e.g. toolbars) according to the configuration.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PerformMenuRendering()
        mainF.MenuStrip1.Renderer = New clsMenuRenderer
        mainF.ListContextMenu.Renderer = New clsMenuRenderer
        mainF.TwContextMenu.Renderer = New clsMenuRenderer

        '// 0 = top, 1 = bottom, 2 = left, 3 = right
        Dim X As Int32 = cfgInt(mainF, "CommandBarX", mainF.MainToolStrip.Left)
        Dim Y As Int32 = cfgInt(mainF, "CommandBarY", mainF.MainToolStrip.Top)

        Dim QX As Int32 = cfgInt(mainF, "QuickSearchX", mainF.QSBar.Left)
        Dim QY As Int32 = cfgInt(mainF, "QuickSearchY", mainF.QSBar.Top)

        Dim QSLayout As Int32 = cfgInt(mainF, "QuickSearch")
        Dim CommandBarLayout As Int32 = cfgInt(mainF, "CommandBar")

        Select Case CommandBarLayout
            Case 0
                mainF.ToolStripContainer1.TopToolStripPanel.Join(mainF.MainToolStrip, X, Y)
            Case 1
                mainF.ToolStripContainer1.BottomToolStripPanel.Join(mainF.MainToolStrip, X, Y)
            Case 2
                mainF.ToolStripContainer1.LeftToolStripPanel.Join(mainF.MainToolStrip, X, Y)
            Case 3
                mainF.ToolStripContainer1.RightToolStripPanel.Join(mainF.MainToolStrip, X, Y)
        End Select

        Select Case cfgInt(mainF, "QuickSearchVisible")
            Case 0
                mainF.QSBar.Hide()
                mainF.QSMenu.Visible = True
                mainF.QSLabel.Visible = True
            Case 1
                mainF.QSBar.Show()
                mainF.QSMenu.Visible = False
                mainF.QSLabel.Visible = False
            Case 2
                mainF.QSMenu.Visible = False
                mainF.QSLabel.Visible = False
                mainF.QSBar.Hide()
        End Select

        '// 0 = top, 1 = bottom, 2 = left, 3 = right

        Select Case QSLayout
            Case 0
                mainF.ToolStripContainer1.TopToolStripPanel.Join(mainF.QSBar, QX, QY)
            Case 1
                mainF.ToolStripContainer1.BottomToolStripPanel.Join(mainF.QSBar, QX, QY)
            Case 2
                mainF.ToolStripContainer1.LeftToolStripPanel.Join(mainF.QSBar, QX, QY)
            Case 3
                mainF.ToolStripContainer1.RightToolStripPanel.Join(mainF.QSBar, QX, QY)
        End Select

        If Not cfgInt(mainF, "MenuBar") = 0 Then
            mainF.MenuStrip1.Dock = DockStyle.Bottom
        End If

        If Not cfgBool(mainF, "ShowStatusBar", True) Then
            mainF.BottomStatusStrip.Hide()
        End If

        If Not cfgBool(mainF, "ShowCommands", True) Then
            mainF.MainToolStrip.Hide()
        End If
    End Sub

    ''' <summary>
    ''' Enables/disables the menu controls according to the current view and item selection.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateMenuControls()
        If mainF.ViewHandler.GetView() = ViewHandler_C.View.Users Then

            mainF.PropertyHandler.CanEditGroups = False
            mainF.PropertyHandler.CanDeleteGroups = False

            If mainF.lselc() = 1 Then
                mainF.PropertyHandler.CanEditUsers = True
                mainF.PropertyHandler.CanDeleteUsers = True

            ElseIf mainF.lselc() = 0 Then
                mainF.PropertyHandler.CanEditUsers = False
                mainF.PropertyHandler.CanDeleteUsers = False
            Else
                'If multiple items are selected, allow deleting, but not editing or renaming
                mainF.PropertyHandler.CanDeleteUsers = True
                mainF.PropertyHandler.CanEditUsers = False
            End If

        ElseIf mainF.ViewHandler.GetView() = ViewHandler_C.View.Groups Then

            mainF.PropertyHandler.CanEditUsers = False
            mainF.PropertyHandler.CanDeleteUsers = False

            If mainF.lselc() = 1 Then
                mainF.PropertyHandler.CanEditGroups = True
                mainF.PropertyHandler.CanDeleteGroups = True

            ElseIf mainF.lselc() = 0 Then
                mainF.PropertyHandler.CanEditGroups = False
                mainF.PropertyHandler.CanDeleteGroups = False
            Else
                'If multiple items are selected, allow deleting, but not editing or renaming
                mainF.PropertyHandler.CanDeleteGroups = True
                mainF.PropertyHandler.CanEditGroups = False
            End If
        Else
            mainF.PropertyHandler.CanEditGroups = False
            mainF.PropertyHandler.CanEditUsers = False
            mainF.PropertyHandler.CanDeleteUsers = False
            mainF.PropertyHandler.CanDeleteGroups = False
        End If
    End Sub

    ''' <summary>
    ''' Shows/hides the context menu controls according to the view and the nubmer of items selected.
    ''' </summary>
    ''' <returns>Indicates whether the menu should open or not.</returns>
    ''' <remarks></remarks>
    Public Function PrehandleContextMenu() As Boolean
        mainF.cCreate.Visible = True
        mainF.cCopyName.Visible = False
        mainF.cCopySID.Visible = False
        mainF.cShowBuiltInDetails.Visible = False
        mainF.cSetPassword.Visible = False

        If mainF.ViewHandler.GetView() = ViewHandler_C.View.MachineRoot Then
            If mainF.lselc() = 0 Then
                Return False
            End If
            mainF.cOpen.Visible = True
            mainF.cDelete.Visible = False
            mainF.cEdit.Visible = False
            mainF.cRename.Visible = False

            If mainF.list.SelectedItems(0).ImageIndex = 5 Then
                mainF.cCreate.Visible = False
            End If

            Return True

        ElseIf mainF.ViewHandler.GetView() = ViewHandler_C.View.BuiltInPrincipals Then
            If mainF.lselc() = 0 Then
                Return False
            End If

            mainF.cCreate.Visible = False
            mainF.cOpen.Visible = False
            mainF.cDelete.Visible = False
            mainF.cEdit.Visible = False
            mainF.cRename.Visible = False

            mainF.cCopyName.Visible = True
            mainF.cCopySID.Visible = True
            mainF.cShowBuiltInDetails.Visible = True

            Return True
        End If

        mainF.cOpen.Visible = False
        If mainF.lselc() = 1 Then
            mainF.cDelete.Visible = True
            mainF.cEdit.Visible = True
            mainF.cRename.Visible = True
            If mainF.ViewHandler.GetView() = ViewHandler_C.View.Users Then
                mainF.cSetPassword.Visible = True
            End If
        ElseIf mainF.lselc() = 0 Then
            mainF.cDelete.Visible = False
            mainF.cEdit.Visible = False
            mainF.cRename.Visible = False
        ElseIf mainF.lselc() > 1 Then
            mainF.cEdit.Visible = False
            mainF.cRename.Visible = False
            mainF.cDelete.Visible = True
        End If

        Return True
    End Function
End Class
