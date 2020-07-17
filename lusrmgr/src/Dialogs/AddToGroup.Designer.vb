<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddToGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddToGroup))
        Me.InstructionLabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SelectButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.FilterButton = New System.Windows.Forms.Button()
        Me.FilterMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowUsers = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowBuiltInPrincipals = New System.Windows.Forms.ToolStripMenuItem()
        Me.filter_indicator = New System.Windows.Forms.PictureBox()
        Me.list = New lusrmgr.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FilterMenu.SuspendLayout()
        CType(Me.filter_indicator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'InstructionLabel
        '
        Me.InstructionLabel.AutoSize = True
        Me.InstructionLabel.Location = New System.Drawing.Point(32, 14)
        Me.InstructionLabel.Name = "InstructionLabel"
        Me.InstructionLabel.Size = New System.Drawing.Size(208, 15)
        Me.InstructionLabel.TabIndex = 6
        Me.InstructionLabel.Text = "Please select the user you wish to add."
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Location = New System.Drawing.Point(8, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 29)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'SelectButton
        '
        Me.SelectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SelectButton.Enabled = False
        Me.SelectButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SelectButton.Location = New System.Drawing.Point(221, 336)
        Me.SelectButton.Name = "SelectButton"
        Me.SelectButton.Size = New System.Drawing.Size(98, 31)
        Me.SelectButton.TabIndex = 1
        Me.SelectButton.Text = "Select"
        Me.SelectButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CloseButton.Location = New System.Drawing.Point(327, 336)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(98, 31)
        Me.CloseButton.TabIndex = 2
        Me.CloseButton.Text = "Cancel"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'FilterButton
        '
        Me.FilterButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FilterButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.FilterButton.Location = New System.Drawing.Point(11, 336)
        Me.FilterButton.Name = "FilterButton"
        Me.FilterButton.Size = New System.Drawing.Size(98, 31)
        Me.FilterButton.TabIndex = 8
        Me.FilterButton.Text = "Filter"
        Me.FilterButton.UseVisualStyleBackColor = True
        '
        'FilterMenu
        '
        Me.FilterMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowUsers, Me.ShowBuiltInPrincipals})
        Me.FilterMenu.Name = "ContextMenuStrip1"
        Me.FilterMenu.Size = New System.Drawing.Size(244, 48)
        '
        'ShowUsers
        '
        Me.ShowUsers.Checked = True
        Me.ShowUsers.CheckOnClick = True
        Me.ShowUsers.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowUsers.Name = "ShowUsers"
        Me.ShowUsers.Size = New System.Drawing.Size(243, 22)
        Me.ShowUsers.Text = "Show users"
        '
        'ShowBuiltInPrincipals
        '
        Me.ShowBuiltInPrincipals.Checked = True
        Me.ShowBuiltInPrincipals.CheckOnClick = True
        Me.ShowBuiltInPrincipals.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowBuiltInPrincipals.Name = "ShowBuiltInPrincipals"
        Me.ShowBuiltInPrincipals.Size = New System.Drawing.Size(243, 22)
        Me.ShowBuiltInPrincipals.Text = "Show built-in security principals"
        '
        'filter_indicator
        '
        Me.filter_indicator.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.filter_indicator.BackColor = System.Drawing.Color.Transparent
        Me.filter_indicator.Image = Global.lusrmgr.My.Resources.Resources.FilterIcon
        Me.filter_indicator.Location = New System.Drawing.Point(113, 338)
        Me.filter_indicator.Name = "filter_indicator"
        Me.filter_indicator.Size = New System.Drawing.Size(24, 24)
        Me.filter_indicator.TabIndex = 9
        Me.filter_indicator.TabStop = False
        Me.filter_indicator.Visible = False
        '
        'list
        '
        Me.list.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.list.Location = New System.Drawing.Point(11, 40)
        Me.list.Name = "list"
        Me.list.ShowItemToolTips = True
        Me.list.Size = New System.Drawing.Size(414, 285)
        Me.list.TabIndex = 0
        Me.list.UseCompatibleStateImageBehavior = False
        Me.list.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 410
        '
        'AddToGroup
        '
        Me.AcceptButton = Me.SelectButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(437, 378)
        Me.Controls.Add(Me.filter_indicator)
        Me.Controls.Add(Me.FilterButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.SelectButton)
        Me.Controls.Add(Me.list)
        Me.Controls.Add(Me.InstructionLabel)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(453, 417)
        Me.Name = "AddToGroup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add user to group"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FilterMenu.ResumeLayout(False)
        CType(Me.filter_indicator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents InstructionLabel As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents list As lusrmgr.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents SelectButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents FilterButton As System.Windows.Forms.Button
    Friend WithEvents FilterMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowUsers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowBuiltInPrincipals As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents filter_indicator As System.Windows.Forms.PictureBox
End Class
