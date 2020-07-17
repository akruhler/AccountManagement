Public Class About

    Public Sub New()
        InitializeComponent()
        CopyContextMenu.Renderer = New clsMenuRenderer()
    End Sub

    Private Sub GitHubLink_Click(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GitHubLink.LinkClicked
        If e.Button = Windows.Forms.MouseButtons.Right Then Return
        Process.Start("https://github.com/proviq/lusrmgr/")
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Clipboard.SetText("https://github.com/proviq/lusrmgr")
    End Sub

#Region "Icon credits window"
    Private Sub IconCreditsButton_Click(sender As Object, e As EventArgs) Handles IconCreditsButton.Click
        Dim ICForm As New Form With {
           .Text = "Icon credits",
           .Size = New Size(570, 340),
           .MinimizeBox = False,
           .MaximizeBox = False,
           .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog,
           .Font = New Font("Segoe UI", 9),
           .StartPosition = FormStartPosition.CenterScreen
        }

        Dim ICIcons As New ImageList
        ICIcons.ColorDepth = ColorDepth.Depth32Bit
        ICIcons.Images.Add(Icon)
        ICIcons.Images.Add(My.Resources.CopyImg)
        ICIcons.Images.Add(My.Resources.SearchImg)
        ICIcons.Images.Add(My.Resources.RefreshImg)
        ICIcons.Images.Add(My.Resources.AddImg)
        ICIcons.Images.Add(My.Resources.DeleteImg)
        ICIcons.Images.Add(My.Resources.EditImg)
        ICIcons.Images.Add(My.Resources.RenameImg)
        ICIcons.Images.Add(My.Resources.DisconnectIcon)
        ICIcons.Images.Add(My.Resources.SettingsImg)
        ICIcons.Images.Add(My.Resources.UnlockIcon)
        ICIcons.Images.Add(My.Resources.FilterIcon)

        Dim ICText As New Label With {
            .TextAlign = ContentAlignment.MiddleLeft,
            .Dock = DockStyle.Top,
            .Height = 40,
            .Font = New Font("Segoe UI", 12),
            .Text = " Icon credits to non-Windows/Visual Studio image library icons"
        }

        Dim ICCopyContext As New ContextMenuStrip
        ICCopyContext.Renderer = New clsMenuRenderer
        ICCopyContext.Items.Add("Open website", Nothing, AddressOf IconOpenWebsite).Font = New Font("Segoe UI", 9, FontStyle.Bold)
        ICCopyContext.Items.Add("Copy author name", My.Resources.CopyImg, AddressOf IconCopyAuthor)
        ICCopyContext.Items.Add("Copy website address", My.Resources.CopyImg, AddressOf IconCopyWebAddr)
        AddHandler ICCopyContext.Opening, AddressOf IconOnOpenContext

        Dim ICList As New ListView With {
            .Dock = DockStyle.Fill,
            .SmallImageList = ICIcons,
            .ContextMenuStrip = ICCopyContext,
            .View = View.Details,
            .MultiSelect = False,
            .FullRowSelect = True
        }
        ICList.Columns.Add("Icon").Width = 120
        ICList.Columns.Add("Author").Width = 135
        ICList.Columns.Add("Website").Width = 295

        ICList.Items.Add(New ListViewItem({"Help icon", "Visual Pharm", "https://visualpharm.com/must_have_icon_set/"})).ImageIndex = 0
        ICList.Items.Add(New ListViewItem({"Copy icon", "Visual Pharm", "https://visualpharm.com/must_have_icon_set/"})).ImageIndex = 1
        ICList.Items.Add(New ListViewItem({"Search icon", "Visual Pharm", "https://visualpharm.com/must_have_icon_set/"})).ImageIndex = 2
        ICList.Items.Add(New ListViewItem({"Refresh icon", "Yusuke Kamiyamane", "http://p.yusukekamiyamane.com/"})).ImageIndex = 3
        ICList.Items.Add(New ListViewItem({"Add icon", "Yusuke Kamiyamane", "http://p.yusukekamiyamane.com/"})).ImageIndex = 4
        ICList.Items.Add(New ListViewItem({"Remove icon", "Dat Nguyen", "http://splashyfish.com/icons/"})).ImageIndex = 5
        ICList.Items.Add(New ListViewItem({"Edit icon", "Gasyoun", "http://led24.de/iconset/"})).ImageIndex = 6
        ICList.Items.Add(New ListViewItem({"Rename icon", "Gasyoun", "http://led24.de/iconset/"})).ImageIndex = 7
        ICList.Items.Add(New ListViewItem({"Disconnect icon", "Gasyoun", "http://led24.de/iconset/"})).ImageIndex = 8
        ICList.Items.Add(New ListViewItem({"Preferences icon", "FatCow Web Hosting", "http://www.fatcow.com/free-icons/"})).ImageIndex = 9
        ICList.Items.Add(New ListViewItem({"Unlock icon", "Aha-Soft", "http://www.small-icons.com/packs/16x16-free-application-icons.htm"})).ImageIndex = 10
        ICList.Items.Add(New ListViewItem({"Filter icon", "Gnome Project", "http://www.gnome.org/"})).ImageIndex = 11

        AddHandler ICList.MouseDoubleClick, AddressOf IconLinkClicked
        AddHandler ICList.KeyDown, AddressOf IconListKeyDown

        ICForm.Controls.Add(ICList)
        ICForm.Controls.Add(ICText)
        ICForm.ShowDialog()
        ICForm.Dispose()
    End Sub

#Region "Icon credits window event handlers"

    Private Sub IconOnOpenContext(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If DirectCast(sender.SourceControl, ListView).SelectedItems.Count <> 1 Then e.Cancel = True
    End Sub

    Private Sub IconCopyAuthor(sender As Object, e As EventArgs)
        Dim list As ListView = DirectCast(sender.GetCurrentParent().SourceControl, ListView)
        If list.SelectedItems.Count = 1 Then
            Clipboard.SetText(list.SelectedItems(0).SubItems(1).Text)
        End If
    End Sub

    Private Sub IconCopyWebAddr(sender As Object, e As EventArgs)
        Dim list As ListView = DirectCast(sender.GetCurrentParent().SourceControl, ListView)
        If list.SelectedItems.Count = 1 Then
            Clipboard.SetText(list.SelectedItems(0).SubItems(2).Text)
        End If
    End Sub

    Private Sub IconOpenWebsite(sender As Object, e As EventArgs)
        Dim list As ListView = DirectCast(sender.GetCurrentParent().SourceControl, ListView)
        If list.SelectedItems.Count = 1 Then
            Process.Start(list.SelectedItems(0).SubItems(2).Text)
        End If
    End Sub

    Private Sub IconListKeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            DirectCast(sender.Parent, Form).Close()
        ElseIf e.KeyCode = Keys.Enter Then
            IconLinkClicked(sender, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 0, 0, 0, 0))
        End If
    End Sub

    Private Sub IconLinkClicked(sender As Object, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim list As ListView = DirectCast(sender, ListView)
            If list.SelectedItems.Count = 1 Then
                Process.Start(list.SelectedItems(0).SubItems(2).Text)
            End If
        End If
    End Sub
#End Region
#End Region
End Class