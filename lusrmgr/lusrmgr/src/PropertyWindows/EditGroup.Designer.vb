<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditGroup))
        Me.GroupLabel = New System.Windows.Forms.Label()
        Me.ApplyButton = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.GroupNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Comment = New System.Windows.Forms.TextBox()
        Me.GroupMembers = New lusrmgr.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TIPP = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SID = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupLabel
        '
        Me.GroupLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupLabel.Location = New System.Drawing.Point(48, 10)
        Me.GroupLabel.Name = "GroupLabel"
        Me.GroupLabel.Size = New System.Drawing.Size(369, 39)
        Me.GroupLabel.TabIndex = 0
        Me.GroupLabel.Text = "Group settings for"
        Me.GroupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplyButton.Enabled = False
        Me.ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ApplyButton.Location = New System.Drawing.Point(329, 469)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(88, 29)
        Me.ApplyButton.TabIndex = 9
        Me.ApplyButton.Text = "Apply"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OkButton.Location = New System.Drawing.Point(139, 469)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(88, 29)
        Me.OkButton.TabIndex = 7
        Me.OkButton.Text = "OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CloseButton.Location = New System.Drawing.Point(234, 469)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(88, 29)
        Me.CloseButton.TabIndex = 8
        Me.CloseButton.Text = "Cancel"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'GroupNameTextBox
        '
        Me.GroupNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GroupNameTextBox.Location = New System.Drawing.Point(94, 71)
        Me.GroupNameTextBox.Name = "GroupNameTextBox"
        Me.GroupNameTextBox.ReadOnly = True
        Me.GroupNameTextBox.Size = New System.Drawing.Size(323, 16)
        Me.GroupNameTextBox.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Group name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Description:"
        '
        'Comment
        '
        Me.Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Comment.Location = New System.Drawing.Point(94, 109)
        Me.Comment.Multiline = True
        Me.Comment.Name = "Comment"
        Me.Comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Comment.Size = New System.Drawing.Size(323, 88)
        Me.Comment.TabIndex = 2
        '
        'GroupMembers
        '
        Me.GroupMembers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupMembers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.GroupMembers.Location = New System.Drawing.Point(11, 270)
        Me.GroupMembers.Name = "GroupMembers"
        Me.GroupMembers.ShowItemToolTips = True
        Me.GroupMembers.Size = New System.Drawing.Size(406, 182)
        Me.GroupMembers.TabIndex = 4
        Me.GroupMembers.UseCompatibleStateImageBehavior = False
        Me.GroupMembers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Group members"
        Me.ColumnHeader1.Width = 404
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackgroundImage = Global.lusrmgr.My.Resources.Resources.DeleteImg
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(52, 460)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 27)
        Me.Button2.TabIndex = 6
        Me.TIPP.SetToolTip(Me.Button2, "Remove user from group")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = Global.lusrmgr.My.Resources.Resources.AddImg
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Location = New System.Drawing.Point(10, 460)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 27)
        Me.Button1.TabIndex = 5
        Me.TIPP.SetToolTip(Me.Button1, "Add user to this group")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SID
        '
        Me.SID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SID.Location = New System.Drawing.Point(94, 212)
        Me.SID.Name = "SID"
        Me.SID.ReadOnly = True
        Me.SID.Size = New System.Drawing.Size(323, 23)
        Me.SID.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(14, 212)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 23)
        Me.Label20.TabIndex = 100
        Me.Label20.Text = "SID:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Location = New System.Drawing.Point(13, 252)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(403, 2)
        Me.Label13.TabIndex = 104
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.lusrmgr.My.Resources.Resources.GroupIcon
        Me.PictureBox1.Location = New System.Drawing.Point(10, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'EditGroup
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(429, 511)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.SID)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupMembers)
        Me.Controls.Add(Me.ApplyButton)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.GroupNameTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Comment)
        Me.Controls.Add(Me.GroupLabel)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(445, 495)
        Me.Name = "EditGroup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EditGroup"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents GroupLabel As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents GroupNameTextBox As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Comment As System.Windows.Forms.TextBox
    Friend WithEvents GroupMembers As lusrmgr.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TIPP As System.Windows.Forms.ToolTip
    Friend WithEvents SID As System.Windows.Forms.TextBox
    Private WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
