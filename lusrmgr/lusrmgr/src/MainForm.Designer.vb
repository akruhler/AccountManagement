<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Local users and groups on", 4, 4)
        Me.TwContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cConnect = New System.Windows.Forms.ToolStripMenuItem()
        Me.cSetDspName = New System.Windows.Forms.ToolStripMenuItem()
        Me.cDisconnect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.cExpand = New System.Windows.Forms.ToolStripMenuItem()
        Me.cCollapse = New System.Windows.Forms.ToolStripMenuItem()
        Me.Icons = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tw = New lusrmgr.TreeView()
        Me.list = New lusrmgr.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.cOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.cRename = New System.Windows.Forms.ToolStripMenuItem()
        Me.cSetPassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.cCreate = New System.Windows.Forms.ToolStripMenuItem()
        Me.cDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cShowBuiltInDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.cCopyName = New System.Windows.Forms.ToolStripMenuItem()
        Me.cCopySID = New System.Windows.Forms.ToolStripMenuItem()
        Me.BottomStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.itemcount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WarningsDismissedTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppearanceTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.UACSettingsTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnectTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.BenutzerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateNewUserTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteUserTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditUserTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameUserTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.GruppeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateNewGroupTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteGroupTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditGroupTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameGroupTS = New System.Windows.Forms.ToolStripMenuItem()
        Me.QSMenu = New System.Windows.Forms.ToolStripTextBox()
        Me.QSLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tAdd = New System.Windows.Forms.ToolStripButton()
        Me.tDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tEdit = New System.Windows.Forms.ToolStripButton()
        Me.tRename = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tConnect = New System.Windows.Forms.ToolStripButton()
        Me.tRefresh = New System.Windows.Forms.ToolStripButton()
        Me.tSearch = New System.Windows.Forms.ToolStripButton()
        Me.QSBar = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.QSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.TwContextMenu.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ListContextMenu.SuspendLayout()
        Me.BottomStatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.MainToolStrip.SuspendLayout()
        Me.QSBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'TwContextMenu
        '
        Me.TwContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cConnect, Me.cSetDspName, Me.cDisconnect, Me.ToolStripSeparator4, Me.cExpand, Me.cCollapse})
        Me.TwContextMenu.Name = "ContextMenuStrip2"
        Me.TwContextMenu.Size = New System.Drawing.Size(198, 120)
        '
        'cConnect
        '
        Me.cConnect.Image = Global.lusrmgr.My.Resources.Resources.ConnectImg
        Me.cConnect.Name = "cConnect"
        Me.cConnect.Size = New System.Drawing.Size(197, 22)
        Me.cConnect.Text = "Connect to computer..."
        '
        'cSetDspName
        '
        Me.cSetDspName.Image = Global.lusrmgr.My.Resources.Resources.RenameImg
        Me.cSetDspName.Name = "cSetDspName"
        Me.cSetDspName.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.cSetDspName.Size = New System.Drawing.Size(197, 22)
        Me.cSetDspName.Text = "Set display name"
        '
        'cDisconnect
        '
        Me.cDisconnect.Image = CType(resources.GetObject("cDisconnect.Image"), System.Drawing.Image)
        Me.cDisconnect.Name = "cDisconnect"
        Me.cDisconnect.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.cDisconnect.Size = New System.Drawing.Size(197, 22)
        Me.cDisconnect.Text = "Disconnect"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(194, 6)
        '
        'cExpand
        '
        Me.cExpand.Name = "cExpand"
        Me.cExpand.Size = New System.Drawing.Size(197, 22)
        Me.cExpand.Text = "Expand all"
        '
        'cCollapse
        '
        Me.cCollapse.Name = "cCollapse"
        Me.cCollapse.Size = New System.Drawing.Size(197, 22)
        Me.cCollapse.Text = "Collapse all"
        '
        'Icons
        '
        Me.Icons.ImageStream = CType(resources.GetObject("Icons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Icons.TransparentColor = System.Drawing.Color.Transparent
        Me.Icons.Images.SetKeyName(0, "user.ico")
        Me.Icons.Images.SetKeyName(1, "group.ico")
        Me.Icons.Images.SetKeyName(2, "netplwiz_108.ico")
        Me.Icons.Images.SetKeyName(3, "netplwiz_110.ico")
        Me.Icons.Images.SetKeyName(4, "comres_2856.ico")
        Me.Icons.Images.SetKeyName(5, "dsuiext_4096.ico")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tw)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.list)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Size = New System.Drawing.Size(788, 325)
        Me.SplitContainer1.SplitterDistance = 261
        Me.SplitContainer1.TabIndex = 1
        '
        'tw
        '
        Me.tw.BackColor = System.Drawing.SystemColors.Window
        Me.tw.ContextMenuStrip = Me.TwContextMenu
        Me.tw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tw.HideSelection = False
        Me.tw.HotTracking = True
        Me.tw.ImageIndex = 0
        Me.tw.ImageList = Me.Icons
        Me.tw.LabelEdit = True
        Me.tw.Location = New System.Drawing.Point(0, 0)
        Me.tw.Name = "tw"
        TreeNode1.ImageIndex = 4
        TreeNode1.Name = "Knoten0"
        TreeNode1.SelectedImageIndex = 4
        TreeNode1.Text = "Local users and groups on"
        Me.tw.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.tw.SelectedImageIndex = 0
        Me.tw.ShowLines = False
        Me.tw.ShowNodeToolTips = True
        Me.tw.Size = New System.Drawing.Size(261, 325)
        Me.tw.TabIndex = 0
        '
        'list
        '
        Me.list.BackColor = System.Drawing.SystemColors.Window
        Me.list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.list.ContextMenuStrip = Me.ListContextMenu
        Me.list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.list.FullRowSelect = True
        Me.list.LabelEdit = True
        Me.list.LabelWrap = False
        Me.list.Location = New System.Drawing.Point(0, 0)
        Me.list.Name = "list"
        Me.list.ShowItemToolTips = True
        Me.list.Size = New System.Drawing.Size(523, 325)
        Me.list.SmallImageList = Me.Icons
        Me.list.TabIndex = 0
        Me.list.UseCompatibleStateImageBehavior = False
        Me.list.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 519
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "SID"
        Me.ColumnHeader2.Width = 0
        '
        'ListContextMenu
        '
        Me.ListContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cEdit, Me.cOpen, Me.cRename, Me.cSetPassword, Me.cCreate, Me.cDelete, Me.cShowBuiltInDetails, Me.cCopyName, Me.cCopySID})
        Me.ListContextMenu.Name = "ContextMenuStrip1"
        Me.ListContextMenu.Size = New System.Drawing.Size(180, 202)
        '
        'cEdit
        '
        Me.cEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cEdit.Image = Global.lusrmgr.My.Resources.Resources.EditImg
        Me.cEdit.Name = "cEdit"
        Me.cEdit.Size = New System.Drawing.Size(179, 22)
        Me.cEdit.Text = "Edit..."
        '
        'cOpen
        '
        Me.cOpen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cOpen.Image = Global.lusrmgr.My.Resources.Resources.OpenImg
        Me.cOpen.Name = "cOpen"
        Me.cOpen.Size = New System.Drawing.Size(179, 22)
        Me.cOpen.Text = "Open"
        Me.cOpen.Visible = False
        '
        'cRename
        '
        Me.cRename.Image = Global.lusrmgr.My.Resources.Resources.RenameImg
        Me.cRename.Name = "cRename"
        Me.cRename.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.cRename.Size = New System.Drawing.Size(179, 22)
        Me.cRename.Text = "Rename"
        '
        'cSetPassword
        '
        Me.cSetPassword.Name = "cSetPassword"
        Me.cSetPassword.Size = New System.Drawing.Size(179, 22)
        Me.cSetPassword.Text = "Set password..."
        '
        'cCreate
        '
        Me.cCreate.Image = Global.lusrmgr.My.Resources.Resources.AddImg
        Me.cCreate.Name = "cCreate"
        Me.cCreate.Size = New System.Drawing.Size(179, 22)
        Me.cCreate.Text = "Create..."
        '
        'cDelete
        '
        Me.cDelete.Image = Global.lusrmgr.My.Resources.Resources.DeleteImg
        Me.cDelete.Name = "cDelete"
        Me.cDelete.Size = New System.Drawing.Size(179, 22)
        Me.cDelete.Text = "Delete"
        '
        'cShowBuiltInDetails
        '
        Me.cShowBuiltInDetails.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cShowBuiltInDetails.Name = "cShowBuiltInDetails"
        Me.cShowBuiltInDetails.Size = New System.Drawing.Size(179, 22)
        Me.cShowBuiltInDetails.Text = "Show details"
        '
        'cCopyName
        '
        Me.cCopyName.Image = Global.lusrmgr.My.Resources.Resources.CopyImg
        Me.cCopyName.Name = "cCopyName"
        Me.cCopyName.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.cCopyName.Size = New System.Drawing.Size(179, 22)
        Me.cCopyName.Text = "Copy name"
        Me.cCopyName.Visible = False
        '
        'cCopySID
        '
        Me.cCopySID.Image = Global.lusrmgr.My.Resources.Resources.CopyImg
        Me.cCopySID.Name = "cCopySID"
        Me.cCopySID.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.cCopySID.Size = New System.Drawing.Size(179, 22)
        Me.cCopySID.Text = "Copy SID"
        Me.cCopySID.Visible = False
        '
        'BottomStatusStrip
        '
        Me.BottomStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status, Me.itemcount})
        Me.BottomStatusStrip.Location = New System.Drawing.Point(0, 402)
        Me.BottomStatusStrip.Name = "BottomStatusStrip"
        Me.BottomStatusStrip.Size = New System.Drawing.Size(788, 22)
        Me.BottomStatusStrip.TabIndex = 1
        Me.BottomStatusStrip.Text = "StatusStrip1"
        '
        'status
        '
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(0, 17)
        '
        'itemcount
        '
        Me.itemcount.Name = "itemcount"
        Me.itemcount.Size = New System.Drawing.Size(0, 17)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.DatabaseToolStripMenuItem, Me.BenutzerToolStripMenuItem, Me.GruppeToolStripMenuItem, Me.QSMenu, Me.QSLabel})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(788, 27)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WarningsDismissedTS, Me.AppearanceTS, Me.UACSettingsTS, Me.ToolStripSeparator5, Me.AboutTS, Me.ExitTS})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(80, 23)
        Me.DateiToolStripMenuItem.Text = "Application"
        '
        'WarningsDismissedTS
        '
        Me.WarningsDismissedTS.Image = Global.lusrmgr.My.Resources.Resources.SettingsImg
        Me.WarningsDismissedTS.Name = "WarningsDismissedTS"
        Me.WarningsDismissedTS.Size = New System.Drawing.Size(206, 22)
        Me.WarningsDismissedTS.Text = "Dismissed warnings..."
        Me.WarningsDismissedTS.ToolTipText = "Configure warnings and hints to be displayed or hidden"
        '
        'AppearanceTS
        '
        Me.AppearanceTS.Image = Global.lusrmgr.My.Resources.Resources.SettingsImg
        Me.AppearanceTS.Name = "AppearanceTS"
        Me.AppearanceTS.Size = New System.Drawing.Size(206, 22)
        Me.AppearanceTS.Text = "View settings..."
        Me.AppearanceTS.ToolTipText = "Change main view appearance"
        '
        'UACSettingsTS
        '
        Me.UACSettingsTS.Image = CType(resources.GetObject("UACSettingsTS.Image"), System.Drawing.Image)
        Me.UACSettingsTS.Name = "UACSettingsTS"
        Me.UACSettingsTS.Size = New System.Drawing.Size(206, 22)
        Me.UACSettingsTS.Text = "UAC settings..."
        Me.UACSettingsTS.ToolTipText = "Configure the User Account Control behavior when running the application as a nor" & _
    "mal user"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(203, 6)
        '
        'AboutTS
        '
        Me.AboutTS.Image = CType(resources.GetObject("AboutTS.Image"), System.Drawing.Image)
        Me.AboutTS.Name = "AboutTS"
        Me.AboutTS.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.AboutTS.Size = New System.Drawing.Size(206, 22)
        Me.AboutTS.Text = "About this program..."
        '
        'ExitTS
        '
        Me.ExitTS.Image = CType(resources.GetObject("ExitTS.Image"), System.Drawing.Image)
        Me.ExitTS.Name = "ExitTS"
        Me.ExitTS.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitTS.Size = New System.Drawing.Size(206, 22)
        Me.ExitTS.Text = "Exit"
        '
        'DatabaseToolStripMenuItem
        '
        Me.DatabaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectTS, Me.ToolStripSeparator8, Me.RefreshTS, Me.RefreshAll, Me.SearchTS})
        Me.DatabaseToolStripMenuItem.Name = "DatabaseToolStripMenuItem"
        Me.DatabaseToolStripMenuItem.Size = New System.Drawing.Size(67, 23)
        Me.DatabaseToolStripMenuItem.Text = "Database"
        '
        'ConnectTS
        '
        Me.ConnectTS.Image = Global.lusrmgr.My.Resources.Resources.ConnectImg
        Me.ConnectTS.Name = "ConnectTS"
        Me.ConnectTS.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.ConnectTS.Size = New System.Drawing.Size(343, 22)
        Me.ConnectTS.Text = "Connect to computer..."
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(340, 6)
        '
        'RefreshTS
        '
        Me.RefreshTS.Image = Global.lusrmgr.My.Resources.Resources.RefreshImg
        Me.RefreshTS.Name = "RefreshTS"
        Me.RefreshTS.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.RefreshTS.Size = New System.Drawing.Size(343, 22)
        Me.RefreshTS.Text = "Refresh users and groups"
        '
        'RefreshAll
        '
        Me.RefreshAll.Name = "RefreshAll"
        Me.RefreshAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.RefreshAll.Size = New System.Drawing.Size(343, 22)
        Me.RefreshAll.Text = "Refresh all connected machines"
        '
        'SearchTS
        '
        Me.SearchTS.Image = Global.lusrmgr.My.Resources.Resources.SearchImg
        Me.SearchTS.Name = "SearchTS"
        Me.SearchTS.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.SearchTS.Size = New System.Drawing.Size(343, 22)
        Me.SearchTS.Text = "Search..."
        '
        'BenutzerToolStripMenuItem
        '
        Me.BenutzerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateNewUserTS, Me.DeleteUserTS, Me.ToolStripSeparator2, Me.EditUserTS, Me.RenameUserTS})
        Me.BenutzerToolStripMenuItem.Name = "BenutzerToolStripMenuItem"
        Me.BenutzerToolStripMenuItem.Size = New System.Drawing.Size(42, 23)
        Me.BenutzerToolStripMenuItem.Text = "User"
        '
        'CreateNewUserTS
        '
        Me.CreateNewUserTS.Image = Global.lusrmgr.My.Resources.Resources.AddImg
        Me.CreateNewUserTS.Name = "CreateNewUserTS"
        Me.CreateNewUserTS.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.CreateNewUserTS.Size = New System.Drawing.Size(211, 22)
        Me.CreateNewUserTS.Text = "Create new user..."
        '
        'DeleteUserTS
        '
        Me.DeleteUserTS.Enabled = False
        Me.DeleteUserTS.Image = Global.lusrmgr.My.Resources.Resources.DeleteImg
        Me.DeleteUserTS.Name = "DeleteUserTS"
        Me.DeleteUserTS.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.DeleteUserTS.Size = New System.Drawing.Size(211, 22)
        Me.DeleteUserTS.Text = "Delete user"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(208, 6)
        '
        'EditUserTS
        '
        Me.EditUserTS.Enabled = False
        Me.EditUserTS.Image = Global.lusrmgr.My.Resources.Resources.EditImg
        Me.EditUserTS.Name = "EditUserTS"
        Me.EditUserTS.Size = New System.Drawing.Size(211, 22)
        Me.EditUserTS.Text = "Edit user..."
        '
        'RenameUserTS
        '
        Me.RenameUserTS.Enabled = False
        Me.RenameUserTS.Image = Global.lusrmgr.My.Resources.Resources.RenameImg
        Me.RenameUserTS.Name = "RenameUserTS"
        Me.RenameUserTS.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.RenameUserTS.Size = New System.Drawing.Size(211, 22)
        Me.RenameUserTS.Text = "Rename user"
        '
        'GruppeToolStripMenuItem
        '
        Me.GruppeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateNewGroupTS, Me.DeleteGroupTS, Me.ToolStripSeparator3, Me.EditGroupTS, Me.RenameGroupTS})
        Me.GruppeToolStripMenuItem.Name = "GruppeToolStripMenuItem"
        Me.GruppeToolStripMenuItem.Size = New System.Drawing.Size(52, 23)
        Me.GruppeToolStripMenuItem.Text = "Group"
        '
        'CreateNewGroupTS
        '
        Me.CreateNewGroupTS.Image = Global.lusrmgr.My.Resources.Resources.AddImg
        Me.CreateNewGroupTS.Name = "CreateNewGroupTS"
        Me.CreateNewGroupTS.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.CreateNewGroupTS.Size = New System.Drawing.Size(221, 22)
        Me.CreateNewGroupTS.Text = "Create new group..."
        '
        'DeleteGroupTS
        '
        Me.DeleteGroupTS.Enabled = False
        Me.DeleteGroupTS.Image = Global.lusrmgr.My.Resources.Resources.DeleteImg
        Me.DeleteGroupTS.Name = "DeleteGroupTS"
        Me.DeleteGroupTS.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.DeleteGroupTS.Size = New System.Drawing.Size(221, 22)
        Me.DeleteGroupTS.Text = "Delete group"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(218, 6)
        '
        'EditGroupTS
        '
        Me.EditGroupTS.Enabled = False
        Me.EditGroupTS.Image = Global.lusrmgr.My.Resources.Resources.EditImg
        Me.EditGroupTS.Name = "EditGroupTS"
        Me.EditGroupTS.Size = New System.Drawing.Size(221, 22)
        Me.EditGroupTS.Text = "Edit group..."
        '
        'RenameGroupTS
        '
        Me.RenameGroupTS.Enabled = False
        Me.RenameGroupTS.Image = Global.lusrmgr.My.Resources.Resources.RenameImg
        Me.RenameGroupTS.Name = "RenameGroupTS"
        Me.RenameGroupTS.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.RenameGroupTS.Size = New System.Drawing.Size(221, 22)
        Me.RenameGroupTS.Text = "Rename group"
        '
        'QSMenu
        '
        Me.QSMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.QSMenu.Name = "QSMenu"
        Me.QSMenu.Size = New System.Drawing.Size(150, 23)
        '
        'QSLabel
        '
        Me.QSLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.QSLabel.AutoSize = False
        Me.QSLabel.Name = "QSLabel"
        Me.QSLabel.Size = New System.Drawing.Size(78, 20)
        Me.QSLabel.Text = "Quick search:"
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SplitContainer1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(788, 325)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 27)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(788, 375)
        Me.ToolStripContainer1.TabIndex = 3
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MainToolStrip)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.QSBar)
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tAdd, Me.tDelete, Me.ToolStripSeparator1, Me.tEdit, Me.tRename, Me.ToolStripSeparator6, Me.tConnect, Me.tRefresh, Me.tSearch})
        Me.MainToolStrip.Location = New System.Drawing.Point(3, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MainToolStrip.Size = New System.Drawing.Size(185, 25)
        Me.MainToolStrip.TabIndex = 3
        '
        'tAdd
        '
        Me.tAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tAdd.Image = Global.lusrmgr.My.Resources.Resources.AddImg
        Me.tAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tAdd.Name = "tAdd"
        Me.tAdd.Size = New System.Drawing.Size(23, 22)
        Me.tAdd.Text = "Create new..."
        '
        'tDelete
        '
        Me.tDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tDelete.Image = Global.lusrmgr.My.Resources.Resources.DeleteImg
        Me.tDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tDelete.Name = "tDelete"
        Me.tDelete.Size = New System.Drawing.Size(23, 22)
        Me.tDelete.Text = "Delete selected"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tEdit
        '
        Me.tEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tEdit.Image = Global.lusrmgr.My.Resources.Resources.EditImg
        Me.tEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tEdit.Name = "tEdit"
        Me.tEdit.Size = New System.Drawing.Size(23, 22)
        Me.tEdit.Text = "Edit..."
        '
        'tRename
        '
        Me.tRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tRename.Image = Global.lusrmgr.My.Resources.Resources.RenameImg
        Me.tRename.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tRename.Name = "tRename"
        Me.tRename.Size = New System.Drawing.Size(23, 22)
        Me.tRename.Text = "Rename"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tConnect
        '
        Me.tConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tConnect.Image = Global.lusrmgr.My.Resources.Resources.ConnectImg
        Me.tConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tConnect.Name = "tConnect"
        Me.tConnect.Size = New System.Drawing.Size(23, 22)
        Me.tConnect.Text = "Connect to computer..."
        '
        'tRefresh
        '
        Me.tRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tRefresh.Image = Global.lusrmgr.My.Resources.Resources.RefreshImg
        Me.tRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tRefresh.Name = "tRefresh"
        Me.tRefresh.Size = New System.Drawing.Size(23, 22)
        Me.tRefresh.Text = "Refresh"
        Me.tRefresh.ToolTipText = "Refresh current database"
        '
        'tSearch
        '
        Me.tSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tSearch.Image = Global.lusrmgr.My.Resources.Resources.SearchImg
        Me.tSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tSearch.Name = "tSearch"
        Me.tSearch.Size = New System.Drawing.Size(23, 22)
        Me.tSearch.Text = "Search..."
        '
        'QSBar
        '
        Me.QSBar.Dock = System.Windows.Forms.DockStyle.None
        Me.QSBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.QSearch})
        Me.QSBar.Location = New System.Drawing.Point(3, 25)
        Me.QSBar.Name = "QSBar"
        Me.QSBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.QSBar.Size = New System.Drawing.Size(242, 25)
        Me.QSBar.TabIndex = 4
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(78, 22)
        Me.ToolStripLabel2.Text = "Quick search:"
        '
        'QSearch
        '
        Me.QSearch.Name = "QSearch"
        Me.QSearch.Size = New System.Drawing.Size(150, 25)
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 424)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.BottomStatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(571, 226)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Local users and groups"
        Me.TwContextMenu.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ListContextMenu.ResumeLayout(False)
        Me.BottomStatusStrip.ResumeLayout(False)
        Me.BottomStatusStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.QSBar.ResumeLayout(False)
        Me.QSBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Icons As System.Windows.Forms.ImageList
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BenutzerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateNewUserTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteUserTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GruppeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditUserTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateNewGroupTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteGroupTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditGroupTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tw As lusrmgr.TreeView
    Friend WithEvents ListContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cCreate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cRename As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameUserTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameGroupTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SearchTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents list As lusrmgr.ListView
    Friend WithEvents ConnectTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TwContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cDisconnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cConnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cExpand As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cCollapse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WarningsDismissedTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cSetDspName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cCopyName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cCopySID As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BottomStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents itemcount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tRename As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents tRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents tSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents QSBar As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents QSearch As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents QSLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents QSMenu As System.Windows.Forms.ToolStripTextBox
    Public WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AppearanceTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UACSettingsTS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cShowBuiltInDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cSetPassword As System.Windows.Forms.ToolStripMenuItem

End Class
