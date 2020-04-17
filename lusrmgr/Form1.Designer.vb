<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Users")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Groups", 1, 1)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Local users and groups on", 2, 2, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Users", 0)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Groups", 1)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ConnectOtherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetDisplayNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisconnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExpandAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollapseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Icons = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tw = New lusrmgr.TreeView()
        Me.loadingL = New System.Windows.Forms.Label()
        Me.list = New lusrmgr.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EDIT = New System.Windows.Forms.ToolStripMenuItem()
        Me.OPEN = New System.Windows.Forms.ToolStripMenuItem()
        Me.RENAME = New System.Windows.Forms.ToolStripMenuItem()
        Me.ADD = New System.Windows.Forms.ToolStripMenuItem()
        Me.REMOVE = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopySIDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.itemcount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WarningsDismissedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppearanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutThisProgramToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewBuiltinSecurityPrincipalsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllesAktualisierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BenutzerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeuenBenutzerErstellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BenutzerEntfernenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BenutzerBearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GruppeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeueGruppeErstellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GruppeEntfernenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.GruppeBearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameGroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QSMenu = New System.Windows.Forms.ToolStripTextBox()
        Me.QSLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
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
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.QSBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectOtherToolStripMenuItem, Me.HideToolStripMenuItem, Me.SetDisplayNameToolStripMenuItem, Me.DisconnectToolStripMenuItem, Me.ToolStripSeparator4, Me.ExpandAllToolStripMenuItem, Me.CollapseAllToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(198, 142)
        '
        'ConnectOtherToolStripMenuItem
        '
        Me.ConnectOtherToolStripMenuItem.Image = CType(resources.GetObject("ConnectOtherToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConnectOtherToolStripMenuItem.Name = "ConnectOtherToolStripMenuItem"
        Me.ConnectOtherToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ConnectOtherToolStripMenuItem.Text = "Connect to computer..."
        '
        'HideToolStripMenuItem
        '
        Me.HideToolStripMenuItem.Name = "HideToolStripMenuItem"
        Me.HideToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.HideToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.HideToolStripMenuItem.Text = "Hide"
        Me.HideToolStripMenuItem.Visible = False
        '
        'SetDisplayNameToolStripMenuItem
        '
        Me.SetDisplayNameToolStripMenuItem.Image = CType(resources.GetObject("SetDisplayNameToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SetDisplayNameToolStripMenuItem.Name = "SetDisplayNameToolStripMenuItem"
        Me.SetDisplayNameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.SetDisplayNameToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.SetDisplayNameToolStripMenuItem.Text = "Set display name"
        '
        'DisconnectToolStripMenuItem
        '
        Me.DisconnectToolStripMenuItem.Image = CType(resources.GetObject("DisconnectToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem"
        Me.DisconnectToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.DisconnectToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.DisconnectToolStripMenuItem.Text = "Disconnect"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(194, 6)
        '
        'ExpandAllToolStripMenuItem
        '
        Me.ExpandAllToolStripMenuItem.Name = "ExpandAllToolStripMenuItem"
        Me.ExpandAllToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ExpandAllToolStripMenuItem.Text = "Expand all"
        '
        'CollapseAllToolStripMenuItem
        '
        Me.CollapseAllToolStripMenuItem.Name = "CollapseAllToolStripMenuItem"
        Me.CollapseAllToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.CollapseAllToolStripMenuItem.Text = "Collapse all"
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.loadingL)
        Me.SplitContainer1.Panel2.Controls.Add(Me.list)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Size = New System.Drawing.Size(788, 325)
        Me.SplitContainer1.SplitterDistance = 261
        Me.SplitContainer1.TabIndex = 1
        '
        'tw
        '
        Me.tw.BackColor = System.Drawing.SystemColors.Window
        Me.tw.ContextMenuStrip = Me.ContextMenuStrip2
        Me.tw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tw.HideSelection = False
        Me.tw.HotTracking = True
        Me.tw.ImageIndex = 0
        Me.tw.ImageList = Me.Icons
        Me.tw.LabelEdit = True
        Me.tw.Location = New System.Drawing.Point(0, 0)
        Me.tw.Name = "tw"
        TreeNode1.Name = "Knoten2"
        TreeNode1.Text = "Users"
        TreeNode2.ImageIndex = 1
        TreeNode2.Name = "Knoten3"
        TreeNode2.SelectedImageIndex = 1
        TreeNode2.Text = "Groups"
        TreeNode3.ImageIndex = 2
        TreeNode3.Name = "Knoten0"
        TreeNode3.SelectedImageIndex = 2
        TreeNode3.Text = "Local users and groups on"
        Me.tw.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode3})
        Me.tw.SelectedImageIndex = 0
        Me.tw.ShowLines = False
        Me.tw.Size = New System.Drawing.Size(261, 325)
        Me.tw.TabIndex = 0
        '
        'loadingL
        '
        Me.loadingL.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.loadingL.BackColor = System.Drawing.SystemColors.Window
        Me.loadingL.Font = New System.Drawing.Font("Segoe UI", 25.0!)
        Me.loadingL.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.loadingL.Location = New System.Drawing.Point(184, 138)
        Me.loadingL.Name = "loadingL"
        Me.loadingL.Size = New System.Drawing.Size(185, 55)
        Me.loadingL.TabIndex = 105
        Me.loadingL.Text = "Loading"
        Me.loadingL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.loadingL.Visible = False
        '
        'list
        '
        Me.list.BackColor = System.Drawing.SystemColors.Window
        Me.list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.list.ContextMenuStrip = Me.ContextMenuStrip1
        Me.list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.list.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
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
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EDIT, Me.OPEN, Me.RENAME, Me.ADD, Me.REMOVE, Me.CopyNameToolStripMenuItem, Me.CopySIDToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(180, 158)
        '
        'EDIT
        '
        Me.EDIT.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.EDIT.Image = CType(resources.GetObject("EDIT.Image"), System.Drawing.Image)
        Me.EDIT.Name = "EDIT"
        Me.EDIT.Size = New System.Drawing.Size(179, 22)
        Me.EDIT.Text = "Edit..."
        '
        'OPEN
        '
        Me.OPEN.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.OPEN.Image = CType(resources.GetObject("OPEN.Image"), System.Drawing.Image)
        Me.OPEN.Name = "OPEN"
        Me.OPEN.Size = New System.Drawing.Size(179, 22)
        Me.OPEN.Text = "Open"
        Me.OPEN.Visible = False
        '
        'RENAME
        '
        Me.RENAME.Image = CType(resources.GetObject("RENAME.Image"), System.Drawing.Image)
        Me.RENAME.Name = "RENAME"
        Me.RENAME.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.RENAME.Size = New System.Drawing.Size(179, 22)
        Me.RENAME.Text = "Rename"
        '
        'ADD
        '
        Me.ADD.Image = CType(resources.GetObject("ADD.Image"), System.Drawing.Image)
        Me.ADD.Name = "ADD"
        Me.ADD.Size = New System.Drawing.Size(179, 22)
        Me.ADD.Text = "Create..."
        '
        'REMOVE
        '
        Me.REMOVE.Image = CType(resources.GetObject("REMOVE.Image"), System.Drawing.Image)
        Me.REMOVE.Name = "REMOVE"
        Me.REMOVE.Size = New System.Drawing.Size(179, 22)
        Me.REMOVE.Text = "Delete"
        '
        'CopyNameToolStripMenuItem
        '
        Me.CopyNameToolStripMenuItem.Image = CType(resources.GetObject("CopyNameToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyNameToolStripMenuItem.Name = "CopyNameToolStripMenuItem"
        Me.CopyNameToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyNameToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.CopyNameToolStripMenuItem.Text = "Copy name"
        Me.CopyNameToolStripMenuItem.Visible = False
        '
        'CopySIDToolStripMenuItem
        '
        Me.CopySIDToolStripMenuItem.Image = CType(resources.GetObject("CopySIDToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopySIDToolStripMenuItem.Name = "CopySIDToolStripMenuItem"
        Me.CopySIDToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.CopySIDToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.CopySIDToolStripMenuItem.Text = "Copy SID"
        Me.CopySIDToolStripMenuItem.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status, Me.itemcount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 402)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(788, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
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
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WarningsDismissedToolStripMenuItem, Me.AppearanceToolStripMenuItem, Me.ToolStripSeparator5, Me.AboutThisProgramToolStripMenuItem, Me.BeendenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(80, 23)
        Me.DateiToolStripMenuItem.Text = "Application"
        '
        'WarningsDismissedToolStripMenuItem
        '
        Me.WarningsDismissedToolStripMenuItem.Image = CType(resources.GetObject("WarningsDismissedToolStripMenuItem.Image"), System.Drawing.Image)
        Me.WarningsDismissedToolStripMenuItem.Name = "WarningsDismissedToolStripMenuItem"
        Me.WarningsDismissedToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.WarningsDismissedToolStripMenuItem.Text = "Dismissed warnings..."
        '
        'AppearanceToolStripMenuItem
        '
        Me.AppearanceToolStripMenuItem.Image = CType(resources.GetObject("AppearanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AppearanceToolStripMenuItem.Name = "AppearanceToolStripMenuItem"
        Me.AppearanceToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.AppearanceToolStripMenuItem.Text = "View settings..."
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(203, 6)
        '
        'AboutThisProgramToolStripMenuItem
        '
        Me.AboutThisProgramToolStripMenuItem.Image = CType(resources.GetObject("AboutThisProgramToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutThisProgramToolStripMenuItem.Name = "AboutThisProgramToolStripMenuItem"
        Me.AboutThisProgramToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.AboutThisProgramToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.AboutThisProgramToolStripMenuItem.Text = "About this program..."
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Image = CType(resources.GetObject("BeendenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.BeendenToolStripMenuItem.Text = "Exit"
        '
        'DatabaseToolStripMenuItem
        '
        Me.DatabaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectToolStripMenuItem, Me.ToolStripSeparator8, Me.ViewBuiltinSecurityPrincipalsToolStripMenuItem, Me.AllesAktualisierenToolStripMenuItem, Me.SearchToolStripMenuItem})
        Me.DatabaseToolStripMenuItem.Name = "DatabaseToolStripMenuItem"
        Me.DatabaseToolStripMenuItem.Size = New System.Drawing.Size(67, 23)
        Me.DatabaseToolStripMenuItem.Text = "Database"
        '
        'ConnectToolStripMenuItem
        '
        Me.ConnectToolStripMenuItem.Image = CType(resources.GetObject("ConnectToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConnectToolStripMenuItem.Name = "ConnectToolStripMenuItem"
        Me.ConnectToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.ConnectToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.ConnectToolStripMenuItem.Text = "Connect to computer..."
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(255, 6)
        '
        'ViewBuiltinSecurityPrincipalsToolStripMenuItem
        '
        Me.ViewBuiltinSecurityPrincipalsToolStripMenuItem.Name = "ViewBuiltinSecurityPrincipalsToolStripMenuItem"
        Me.ViewBuiltinSecurityPrincipalsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.ViewBuiltinSecurityPrincipalsToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.ViewBuiltinSecurityPrincipalsToolStripMenuItem.Text = "View built-in security principals"
        '
        'AllesAktualisierenToolStripMenuItem
        '
        Me.AllesAktualisierenToolStripMenuItem.Image = CType(resources.GetObject("AllesAktualisierenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AllesAktualisierenToolStripMenuItem.Name = "AllesAktualisierenToolStripMenuItem"
        Me.AllesAktualisierenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.AllesAktualisierenToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.AllesAktualisierenToolStripMenuItem.Text = "Refresh users and groups"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Image = CType(resources.GetObject("SearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.SearchToolStripMenuItem.Text = "Search..."
        '
        'BenutzerToolStripMenuItem
        '
        Me.BenutzerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuenBenutzerErstellenToolStripMenuItem, Me.BenutzerEntfernenToolStripMenuItem, Me.ToolStripSeparator2, Me.BenutzerBearbeitenToolStripMenuItem, Me.RenameUserToolStripMenuItem})
        Me.BenutzerToolStripMenuItem.Name = "BenutzerToolStripMenuItem"
        Me.BenutzerToolStripMenuItem.Size = New System.Drawing.Size(42, 23)
        Me.BenutzerToolStripMenuItem.Text = "User"
        '
        'NeuenBenutzerErstellenToolStripMenuItem
        '
        Me.NeuenBenutzerErstellenToolStripMenuItem.Image = CType(resources.GetObject("NeuenBenutzerErstellenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NeuenBenutzerErstellenToolStripMenuItem.Name = "NeuenBenutzerErstellenToolStripMenuItem"
        Me.NeuenBenutzerErstellenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.NeuenBenutzerErstellenToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.NeuenBenutzerErstellenToolStripMenuItem.Text = "Create new user..."
        '
        'BenutzerEntfernenToolStripMenuItem
        '
        Me.BenutzerEntfernenToolStripMenuItem.Enabled = False
        Me.BenutzerEntfernenToolStripMenuItem.Image = CType(resources.GetObject("BenutzerEntfernenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BenutzerEntfernenToolStripMenuItem.Name = "BenutzerEntfernenToolStripMenuItem"
        Me.BenutzerEntfernenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.BenutzerEntfernenToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.BenutzerEntfernenToolStripMenuItem.Text = "Delete user"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(208, 6)
        '
        'BenutzerBearbeitenToolStripMenuItem
        '
        Me.BenutzerBearbeitenToolStripMenuItem.Enabled = False
        Me.BenutzerBearbeitenToolStripMenuItem.Image = CType(resources.GetObject("BenutzerBearbeitenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BenutzerBearbeitenToolStripMenuItem.Name = "BenutzerBearbeitenToolStripMenuItem"
        Me.BenutzerBearbeitenToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.BenutzerBearbeitenToolStripMenuItem.Text = "Edit user..."
        '
        'RenameUserToolStripMenuItem
        '
        Me.RenameUserToolStripMenuItem.Enabled = False
        Me.RenameUserToolStripMenuItem.Image = CType(resources.GetObject("RenameUserToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RenameUserToolStripMenuItem.Name = "RenameUserToolStripMenuItem"
        Me.RenameUserToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.RenameUserToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.RenameUserToolStripMenuItem.Text = "Rename user"
        '
        'GruppeToolStripMenuItem
        '
        Me.GruppeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeueGruppeErstellenToolStripMenuItem, Me.GruppeEntfernenToolStripMenuItem, Me.ToolStripSeparator3, Me.GruppeBearbeitenToolStripMenuItem, Me.RenameGroupToolStripMenuItem})
        Me.GruppeToolStripMenuItem.Name = "GruppeToolStripMenuItem"
        Me.GruppeToolStripMenuItem.Size = New System.Drawing.Size(52, 23)
        Me.GruppeToolStripMenuItem.Text = "Group"
        '
        'NeueGruppeErstellenToolStripMenuItem
        '
        Me.NeueGruppeErstellenToolStripMenuItem.Image = CType(resources.GetObject("NeueGruppeErstellenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NeueGruppeErstellenToolStripMenuItem.Name = "NeueGruppeErstellenToolStripMenuItem"
        Me.NeueGruppeErstellenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.NeueGruppeErstellenToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.NeueGruppeErstellenToolStripMenuItem.Text = "Create new group..."
        '
        'GruppeEntfernenToolStripMenuItem
        '
        Me.GruppeEntfernenToolStripMenuItem.Enabled = False
        Me.GruppeEntfernenToolStripMenuItem.Image = CType(resources.GetObject("GruppeEntfernenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GruppeEntfernenToolStripMenuItem.Name = "GruppeEntfernenToolStripMenuItem"
        Me.GruppeEntfernenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.GruppeEntfernenToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.GruppeEntfernenToolStripMenuItem.Text = "Delete group"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(218, 6)
        '
        'GruppeBearbeitenToolStripMenuItem
        '
        Me.GruppeBearbeitenToolStripMenuItem.Enabled = False
        Me.GruppeBearbeitenToolStripMenuItem.Image = CType(resources.GetObject("GruppeBearbeitenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GruppeBearbeitenToolStripMenuItem.Name = "GruppeBearbeitenToolStripMenuItem"
        Me.GruppeBearbeitenToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.GruppeBearbeitenToolStripMenuItem.Text = "Edit group..."
        '
        'RenameGroupToolStripMenuItem
        '
        Me.RenameGroupToolStripMenuItem.Enabled = False
        Me.RenameGroupToolStripMenuItem.Image = CType(resources.GetObject("RenameGroupToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RenameGroupToolStripMenuItem.Name = "RenameGroupToolStripMenuItem"
        Me.RenameGroupToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.RenameGroupToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.RenameGroupToolStripMenuItem.Text = "Rename group"
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
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.QSBar)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tAdd, Me.tDelete, Me.ToolStripSeparator1, Me.tEdit, Me.tRename, Me.ToolStripSeparator6, Me.tConnect, Me.tRefresh, Me.tSearch})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(185, 25)
        Me.ToolStrip1.TabIndex = 3
        '
        'tAdd
        '
        Me.tAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tAdd.Image = CType(resources.GetObject("tAdd.Image"), System.Drawing.Image)
        Me.tAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tAdd.Name = "tAdd"
        Me.tAdd.Size = New System.Drawing.Size(23, 22)
        Me.tAdd.Text = "Create new..."
        '
        'tDelete
        '
        Me.tDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tDelete.Image = CType(resources.GetObject("tDelete.Image"), System.Drawing.Image)
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
        Me.tEdit.Image = CType(resources.GetObject("tEdit.Image"), System.Drawing.Image)
        Me.tEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tEdit.Name = "tEdit"
        Me.tEdit.Size = New System.Drawing.Size(23, 22)
        Me.tEdit.Text = "Edit..."
        '
        'tRename
        '
        Me.tRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tRename.Image = CType(resources.GetObject("tRename.Image"), System.Drawing.Image)
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
        Me.tConnect.Image = CType(resources.GetObject("tConnect.Image"), System.Drawing.Image)
        Me.tConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tConnect.Name = "tConnect"
        Me.tConnect.Size = New System.Drawing.Size(23, 22)
        Me.tConnect.Text = "Connect to computer..."
        '
        'tRefresh
        '
        Me.tRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tRefresh.Image = CType(resources.GetObject("tRefresh.Image"), System.Drawing.Image)
        Me.tRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tRefresh.Name = "tRefresh"
        Me.tRefresh.Size = New System.Drawing.Size(23, 22)
        Me.tRefresh.Text = "Refresh"
        '
        'tSearch
        '
        Me.tSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tSearch.Image = CType(resources.GetObject("tSearch.Image"), System.Drawing.Image)
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 424)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(571, 226)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Local users and groups"
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.QSBar.ResumeLayout(False)
        Me.QSBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Icons As System.Windows.Forms.ImageList
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BenutzerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NeuenBenutzerErstellenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BenutzerEntfernenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GruppeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BenutzerBearbeitenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NeueGruppeErstellenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GruppeEntfernenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GruppeBearbeitenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllesAktualisierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tw As lusrmgr.TreeView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ADD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REMOVE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EDIT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OPEN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutThisProgramToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RENAME As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameUserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameGroupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents list As lusrmgr.ListView
    Friend WithEvents ConnectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DisconnectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConnectOtherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExpandAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CollapseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WarningsDismissedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents loadingL As System.Windows.Forms.Label
    Friend WithEvents SetDisplayNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewBuiltinSecurityPrincipalsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents HideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopySIDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents itemcount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
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
    Friend WithEvents AppearanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
