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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Please select the user you wish to add."
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
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Enabled = False
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Location = New System.Drawing.Point(221, 336)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 31)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Select"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Location = New System.Drawing.Point(327, 336)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 31)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button3.Location = New System.Drawing.Point(11, 336)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(98, 31)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Filter"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FilterMenu
        '
        Me.FilterMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowUsers, Me.ShowBuiltInPrincipals})
        Me.FilterMenu.Name = "ContextMenuStrip1"
        Me.FilterMenu.Size = New System.Drawing.Size(244, 70)
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
        Me.filter_indicator.Image = CType(resources.GetObject("filter_indicator.Image"), System.Drawing.Image)
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
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(437, 378)
        Me.Controls.Add(Me.filter_indicator)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.list)
        Me.Controls.Add(Me.Label1)
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents list As lusrmgr.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents FilterMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowUsers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowBuiltInPrincipals As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents filter_indicator As System.Windows.Forms.PictureBox
End Class
