<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddGroup))
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.GroupNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Comment = New System.Windows.Forms.TextBox()
        Me.GroupLabel = New System.Windows.Forms.Label()
        Me.SymbolDisallowedTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.list = New lusrmgr.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TIPP = New System.Windows.Forms.ToolTip(Me.components)
        Me.RmBtn = New System.Windows.Forms.Button()
        Me.AddBtn = New System.Windows.Forms.Button()
        Me.GroupIcon = New System.Windows.Forms.PictureBox()
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.GroupIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Enabled = False
        Me.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OkButton.Location = New System.Drawing.Point(187, 400)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(125, 29)
        Me.OkButton.TabIndex = 5
        Me.OkButton.Text = "Create group"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CloseButton.Location = New System.Drawing.Point(319, 400)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(97, 29)
        Me.CloseButton.TabIndex = 6
        Me.CloseButton.Text = "Cancel"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'GroupNameTextBox
        '
        Me.GroupNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupNameTextBox.Location = New System.Drawing.Point(113, 59)
        Me.GroupNameTextBox.Name = "GroupNameTextBox"
        Me.GroupNameTextBox.Size = New System.Drawing.Size(304, 23)
        Me.GroupNameTextBox.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Group name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Description:"
        '
        'Comment
        '
        Me.Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Comment.Location = New System.Drawing.Point(113, 98)
        Me.Comment.Multiline = True
        Me.Comment.Name = "Comment"
        Me.Comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Comment.Size = New System.Drawing.Size(304, 88)
        Me.Comment.TabIndex = 1
        '
        'GroupLabel
        '
        Me.GroupLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupLabel.Location = New System.Drawing.Point(48, 8)
        Me.GroupLabel.Name = "GroupLabel"
        Me.GroupLabel.Size = New System.Drawing.Size(369, 39)
        Me.GroupLabel.TabIndex = 27
        Me.GroupLabel.Text = "Create new group on "
        Me.GroupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SymbolDisallowedTooltip
        '
        Me.SymbolDisallowedTooltip.IsBalloon = True
        Me.SymbolDisallowedTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.SymbolDisallowedTooltip.ToolTipTitle = "Symbol not allowed"
        '
        'list
        '
        Me.list.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.list.Location = New System.Drawing.Point(11, 221)
        Me.list.Name = "list"
        Me.list.ShowItemToolTips = True
        Me.list.Size = New System.Drawing.Size(405, 164)
        Me.list.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.list.TabIndex = 2
        Me.list.UseCompatibleStateImageBehavior = False
        Me.list.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Group members"
        Me.ColumnHeader1.Width = 401
        '
        'RmBtn
        '
        Me.RmBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RmBtn.BackgroundImage = Global.lusrmgr.My.Resources.Resources.DeleteImg
        Me.RmBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RmBtn.Enabled = False
        Me.RmBtn.Location = New System.Drawing.Point(51, 392)
        Me.RmBtn.Name = "RmBtn"
        Me.RmBtn.Size = New System.Drawing.Size(35, 27)
        Me.RmBtn.TabIndex = 4
        Me.TIPP.SetToolTip(Me.RmBtn, "Remove this user from the group")
        Me.RmBtn.UseVisualStyleBackColor = True
        '
        'AddBtn
        '
        Me.AddBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AddBtn.BackgroundImage = Global.lusrmgr.My.Resources.Resources.AddImg
        Me.AddBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.AddBtn.Location = New System.Drawing.Point(10, 392)
        Me.AddBtn.Name = "AddBtn"
        Me.AddBtn.Size = New System.Drawing.Size(35, 27)
        Me.AddBtn.TabIndex = 3
        Me.TIPP.SetToolTip(Me.AddBtn, "Add user to this group")
        Me.AddBtn.UseVisualStyleBackColor = True
        '
        'GroupIcon
        '
        Me.GroupIcon.Image = Global.lusrmgr.My.Resources.Resources.GroupIcon
        Me.GroupIcon.Location = New System.Drawing.Point(10, 8)
        Me.GroupIcon.Name = "GroupIcon"
        Me.GroupIcon.Size = New System.Drawing.Size(38, 40)
        Me.GroupIcon.TabIndex = 28
        Me.GroupIcon.TabStop = False
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Location = New System.Drawing.Point(13, 203)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(403, 2)
        Me.Label13.TabIndex = 105
        '
        'AddGroup
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(429, 442)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.RmBtn)
        Me.Controls.Add(Me.AddBtn)
        Me.Controls.Add(Me.list)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.GroupNameTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Comment)
        Me.Controls.Add(Me.GroupLabel)
        Me.Controls.Add(Me.GroupIcon)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(445, 481)
        Me.Name = "AddGroup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create new group"
        CType(Me.GroupIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents GroupNameTextBox As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Comment As System.Windows.Forms.TextBox
    Private WithEvents GroupLabel As System.Windows.Forms.Label
    Friend WithEvents GroupIcon As System.Windows.Forms.PictureBox
    Private WithEvents SymbolDisallowedTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents list As lusrmgr.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents RmBtn As System.Windows.Forms.Button
    Friend WithEvents AddBtn As System.Windows.Forms.Button
    Friend WithEvents TIPP As System.Windows.Forms.ToolTip
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
