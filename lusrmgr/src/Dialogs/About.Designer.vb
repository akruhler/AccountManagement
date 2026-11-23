<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DevelopedBy = New System.Windows.Forms.Label()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.Copyright = New System.Windows.Forms.Label()
        Me.Version = New System.Windows.Forms.Label()
        Me.GitHubLink = New System.Windows.Forms.LinkLabel()
        Me.CopyContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IconCreditsButton = New System.Windows.Forms.Button()
        Me.CopyContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 17.0!)
        Me.Label1.Location = New System.Drawing.Point(0, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(601, 50)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Local User and Group Management"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DevelopedBy
        '
        Me.DevelopedBy.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.DevelopedBy.Location = New System.Drawing.Point(-1, 114)
        Me.DevelopedBy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DevelopedBy.Name = "DevelopedBy"
        Me.DevelopedBy.Size = New System.Drawing.Size(603, 48)
        Me.DevelopedBy.TabIndex = 1
        Me.DevelopedBy.Text = "Developed by: A. Krühler"
        Me.DevelopedBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CloseButton.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CloseButton.Location = New System.Drawing.Point(479, 218)
        Me.CloseButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(112, 36)
        Me.CloseButton.TabIndex = 0
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'Copyright
        '
        Me.Copyright.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Copyright.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Copyright.Location = New System.Drawing.Point(0, 236)
        Me.Copyright.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(605, 32)
        Me.Copyright.TabIndex = 7
        Me.Copyright.Text = "© 2017-2026 A. Krühler"
        Me.Copyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Version
        '
        Me.Version.Font = New System.Drawing.Font("Segoe UI", 15.0!)
        Me.Version.Location = New System.Drawing.Point(-1, 63)
        Me.Version.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(603, 48)
        Me.Version.TabIndex = 8
        Me.Version.Text = "Version 1.6.4 (x86)"
        Me.Version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GitHubLink
        '
        Me.GitHubLink.AutoSize = True
        Me.GitHubLink.ContextMenuStrip = Me.CopyContextMenu
        Me.GitHubLink.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GitHubLink.Location = New System.Drawing.Point(260, 162)
        Me.GitHubLink.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.GitHubLink.Name = "GitHubLink"
        Me.GitHubLink.Size = New System.Drawing.Size(75, 28)
        Me.GitHubLink.TabIndex = 10
        Me.GitHubLink.TabStop = True
        Me.GitHubLink.Text = "GitHub"
        Me.GitHubLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CopyContextMenu
        '
        Me.CopyContextMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CopyContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem})
        Me.CopyContextMenu.Name = "ContextMenuStrip1"
        Me.CopyContextMenu.Size = New System.Drawing.Size(144, 30)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = Global.lusrmgr.My.Resources.Resources.CopyImg
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(143, 26)
        Me.CopyToolStripMenuItem.Text = "Copy link"
        '
        'IconCreditsButton
        '
        Me.IconCreditsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconCreditsButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.IconCreditsButton.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.IconCreditsButton.Location = New System.Drawing.Point(339, 218)
        Me.IconCreditsButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IconCreditsButton.Name = "IconCreditsButton"
        Me.IconCreditsButton.Size = New System.Drawing.Size(132, 36)
        Me.IconCreditsButton.TabIndex = 11
        Me.IconCreditsButton.Text = "Icon credits"
        Me.IconCreditsButton.UseVisualStyleBackColor = True
        '
        'About
        '
        Me.AcceptButton = Me.CloseButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(605, 268)
        Me.Controls.Add(Me.IconCreditsButton)
        Me.Controls.Add(Me.GitHubLink)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.DevelopedBy)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Copyright)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About this program"
        Me.CopyContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DevelopedBy As System.Windows.Forms.Label
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents Copyright As System.Windows.Forms.Label
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents GitHubLink As System.Windows.Forms.LinkLabel
    Friend WithEvents CopyContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IconCreditsButton As System.Windows.Forms.Button
End Class
