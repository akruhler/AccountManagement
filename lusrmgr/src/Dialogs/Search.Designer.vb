<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Search
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Search))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SearchBox = New System.Windows.Forms.TextBox()
        Me.ContextMenuS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.cShowBuiltInDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.cDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cRename = New System.Windows.Forms.ToolStripMenuItem()
        Me.cSeperator = New System.Windows.Forms.ToolStripSeparator()
        Me.cJumpTo = New System.Windows.Forms.ToolStripMenuItem()
        Me.cCopyName = New System.Windows.Forms.ToolStripMenuItem()
        Me.cCopySID = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeperatorLabel = New System.Windows.Forms.Label()
        Me.SearchUsers = New System.Windows.Forms.CheckBox()
        Me.SearchGroups = New System.Windows.Forms.CheckBox()
        Me.SearchInterval = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.NoResultsLabel = New System.Windows.Forms.Label()
        Me.SearchOptionsExpander = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SearchBuiltin = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SRangeCurrent = New System.Windows.Forms.RadioButton()
        Me.SRangeAll = New System.Windows.Forms.RadioButton()
        Me.list = New lusrmgr.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuS.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Location = New System.Drawing.Point(17, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Find what:"
        '
        'SearchBox
        '
        Me.SearchBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchBox.Location = New System.Drawing.Point(79, 14)
        Me.SearchBox.Name = "SearchBox"
        Me.SearchBox.Size = New System.Drawing.Size(459, 23)
        Me.SearchBox.TabIndex = 1
        '
        'ContextMenuS
        '
        Me.ContextMenuS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cEdit, Me.cShowBuiltInDetails, Me.cDelete, Me.cRename, Me.cSeperator, Me.cJumpTo, Me.cCopyName, Me.cCopySID})
        Me.ContextMenuS.Name = "ContextMenuStrip1"
        Me.ContextMenuS.Size = New System.Drawing.Size(180, 164)
        '
        'cEdit
        '
        Me.cEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cEdit.Image = Global.lusrmgr.My.Resources.Resources.EditImg
        Me.cEdit.Name = "cEdit"
        Me.cEdit.Size = New System.Drawing.Size(179, 22)
        Me.cEdit.Text = "Edit..."
        '
        'cShowBuiltInDetails
        '
        Me.cShowBuiltInDetails.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cShowBuiltInDetails.Name = "cShowBuiltInDetails"
        Me.cShowBuiltInDetails.Size = New System.Drawing.Size(179, 22)
        Me.cShowBuiltInDetails.Text = "Show details"
        '
        'cDelete
        '
        Me.cDelete.Image = Global.lusrmgr.My.Resources.Resources.DeleteImg
        Me.cDelete.Name = "cDelete"
        Me.cDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.cDelete.Size = New System.Drawing.Size(179, 22)
        Me.cDelete.Text = "Delete"
        '
        'cRename
        '
        Me.cRename.Image = Global.lusrmgr.My.Resources.Resources.RenameImg
        Me.cRename.Name = "cRename"
        Me.cRename.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.cRename.Size = New System.Drawing.Size(179, 22)
        Me.cRename.Text = "Rename"
        '
        'cSeperator
        '
        Me.cSeperator.Name = "cSeperator"
        Me.cSeperator.Size = New System.Drawing.Size(176, 6)
        '
        'cJumpTo
        '
        Me.cJumpTo.Image = Global.lusrmgr.My.Resources.Resources.ConnectImg
        Me.cJumpTo.Name = "cJumpTo"
        Me.cJumpTo.ShortcutKeys = System.Windows.Forms.Keys.F11
        Me.cJumpTo.Size = New System.Drawing.Size(179, 22)
        Me.cJumpTo.Text = "Go to element"
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
        'SeperatorLabel
        '
        Me.SeperatorLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeperatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SeperatorLabel.Location = New System.Drawing.Point(15, 205)
        Me.SeperatorLabel.Name = "SeperatorLabel"
        Me.SeperatorLabel.Size = New System.Drawing.Size(524, 2)
        Me.SeperatorLabel.TabIndex = 99
        '
        'SearchUsers
        '
        Me.SearchUsers.AutoSize = True
        Me.SearchUsers.Checked = True
        Me.SearchUsers.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SearchUsers.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SearchUsers.Location = New System.Drawing.Point(14, 24)
        Me.SearchUsers.Name = "SearchUsers"
        Me.SearchUsers.Size = New System.Drawing.Size(115, 20)
        Me.SearchUsers.TabIndex = 2
        Me.SearchUsers.Text = "Search for users"
        Me.SearchUsers.UseVisualStyleBackColor = True
        '
        'SearchGroups
        '
        Me.SearchGroups.AutoSize = True
        Me.SearchGroups.Checked = True
        Me.SearchGroups.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SearchGroups.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SearchGroups.Location = New System.Drawing.Point(14, 50)
        Me.SearchGroups.Name = "SearchGroups"
        Me.SearchGroups.Size = New System.Drawing.Size(125, 20)
        Me.SearchGroups.TabIndex = 3
        Me.SearchGroups.Text = "Search for groups"
        Me.SearchGroups.UseVisualStyleBackColor = True
        '
        'SearchInterval
        '
        Me.SearchInterval.Interval = 700
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 22.0!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(164, 346)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(294, 41)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Searching for items..."
        Me.Label2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(96, 335)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 103
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'NoResultsLabel
        '
        Me.NoResultsLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.NoResultsLabel.AutoSize = True
        Me.NoResultsLabel.BackColor = System.Drawing.SystemColors.Window
        Me.NoResultsLabel.Font = New System.Drawing.Font("Segoe UI", 22.0!)
        Me.NoResultsLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.NoResultsLabel.Location = New System.Drawing.Point(164, 346)
        Me.NoResultsLabel.Name = "NoResultsLabel"
        Me.NoResultsLabel.Size = New System.Drawing.Size(239, 41)
        Me.NoResultsLabel.TabIndex = 104
        Me.NoResultsLabel.Text = "No results found"
        Me.NoResultsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NoResultsLabel.Visible = False
        '
        'SearchOptionsExpander
        '
        Me.SearchOptionsExpander.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SearchOptionsExpander.Location = New System.Drawing.Point(79, 46)
        Me.SearchOptionsExpander.Name = "SearchOptionsExpander"
        Me.SearchOptionsExpander.Size = New System.Drawing.Size(134, 28)
        Me.SearchOptionsExpander.TabIndex = 105
        Me.SearchOptionsExpander.Text = "Show search options"
        Me.SearchOptionsExpander.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SearchBuiltin)
        Me.GroupBox1.Controls.Add(Me.SearchUsers)
        Me.GroupBox1.Controls.Add(Me.SearchGroups)
        Me.GroupBox1.Location = New System.Drawing.Point(79, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 108)
        Me.GroupBox1.TabIndex = 106
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Objects to search for"
        '
        'SearchBuiltin
        '
        Me.SearchBuiltin.AutoSize = True
        Me.SearchBuiltin.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SearchBuiltin.Location = New System.Drawing.Point(14, 76)
        Me.SearchBuiltin.Name = "SearchBuiltin"
        Me.SearchBuiltin.Size = New System.Drawing.Size(181, 20)
        Me.SearchBuiltin.TabIndex = 4
        Me.SearchBuiltin.Text = "Search for built-in principals"
        Me.SearchBuiltin.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SRangeCurrent)
        Me.GroupBox2.Controls.Add(Me.SRangeAll)
        Me.GroupBox2.Location = New System.Drawing.Point(295, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(243, 108)
        Me.GroupBox2.TabIndex = 107
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search range"
        '
        'SRangeCurrent
        '
        Me.SRangeCurrent.AutoSize = True
        Me.SRangeCurrent.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SRangeCurrent.Location = New System.Drawing.Point(16, 50)
        Me.SRangeCurrent.Name = "SRangeCurrent"
        Me.SRangeCurrent.Size = New System.Drawing.Size(199, 20)
        Me.SRangeCurrent.TabIndex = 1
        Me.SRangeCurrent.Text = "Search on current machine only"
        Me.SRangeCurrent.UseVisualStyleBackColor = True
        '
        'SRangeAll
        '
        Me.SRangeAll.AutoSize = True
        Me.SRangeAll.Checked = True
        Me.SRangeAll.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SRangeAll.Location = New System.Drawing.Point(16, 24)
        Me.SRangeAll.Name = "SRangeAll"
        Me.SRangeAll.Size = New System.Drawing.Size(211, 20)
        Me.SRangeAll.TabIndex = 0
        Me.SRangeAll.TabStop = True
        Me.SRangeAll.Text = "Search on all connected machines"
        Me.SRangeAll.UseVisualStyleBackColor = True
        '
        'list
        '
        Me.list.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.list.BackColor = System.Drawing.SystemColors.Window
        Me.list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.list.ContextMenuStrip = Me.ContextMenuS
        Me.list.LabelEdit = True
        Me.list.Location = New System.Drawing.Point(15, 221)
        Me.list.Name = "list"
        Me.list.ShowItemToolTips = True
        Me.list.Size = New System.Drawing.Size(523, 307)
        Me.list.TabIndex = 5
        Me.list.UseCompatibleStateImageBehavior = False
        Me.list.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Search results"
        Me.ColumnHeader1.Width = 289
        '
        'Search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 545)
        Me.Controls.Add(Me.NoResultsLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SearchOptionsExpander)
        Me.Controls.Add(Me.SeperatorLabel)
        Me.Controls.Add(Me.SearchBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.list)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(570, 445)
        Me.Name = "Search"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search"
        Me.ContextMenuS.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SearchBox As System.Windows.Forms.TextBox
    Private WithEvents list As lusrmgr.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents SeperatorLabel As System.Windows.Forms.Label
    Friend WithEvents SearchUsers As System.Windows.Forms.CheckBox
    Friend WithEvents SearchGroups As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchInterval As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents NoResultsLabel As System.Windows.Forms.Label
    Friend WithEvents cJumpTo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchOptionsExpander As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SearchBuiltin As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents SRangeCurrent As System.Windows.Forms.RadioButton
    Friend WithEvents SRangeAll As System.Windows.Forms.RadioButton
    Friend WithEvents cDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cRename As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cCopyName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cSeperator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cShowBuiltInDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cCopySID As System.Windows.Forms.ToolStripMenuItem
End Class
