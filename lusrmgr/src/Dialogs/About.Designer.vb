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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
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
        Me.Label1.Location = New System.Drawing.Point(0, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(451, 41)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Local User and Group Management"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(-1, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(452, 39)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Developed by: A. Krühler"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CloseButton.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CloseButton.Location = New System.Drawing.Point(359, 177)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(84, 29)
        Me.CloseButton.TabIndex = 0
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(0, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(454, 26)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "© 2017-2020 A. Krühler"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 15.0!)
        Me.Label4.Location = New System.Drawing.Point(-1, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(452, 39)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Version 1.6.3 (x86)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(101, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(184, 21)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Contact the developer on"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GitHubLink
        '
        Me.GitHubLink.AutoSize = True
        Me.GitHubLink.ContextMenuStrip = Me.CopyContextMenu
        Me.GitHubLink.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GitHubLink.Location = New System.Drawing.Point(279, 135)
        Me.GitHubLink.Name = "GitHubLink"
        Me.GitHubLink.Size = New System.Drawing.Size(59, 21)
        Me.GitHubLink.TabIndex = 10
        Me.GitHubLink.TabStop = True
        Me.GitHubLink.Text = "GitHub"
        Me.GitHubLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CopyContextMenu
        '
        Me.CopyContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem})
        Me.CopyContextMenu.Name = "ContextMenuStrip1"
        Me.CopyContextMenu.Size = New System.Drawing.Size(125, 26)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = Global.lusrmgr.My.Resources.Resources.CopyImg
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.CopyToolStripMenuItem.Text = "Copy link"
        '
        'IconCreditsButton
        '
        Me.IconCreditsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconCreditsButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.IconCreditsButton.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.IconCreditsButton.Location = New System.Drawing.Point(254, 177)
        Me.IconCreditsButton.Name = "IconCreditsButton"
        Me.IconCreditsButton.Size = New System.Drawing.Size(99, 29)
        Me.IconCreditsButton.TabIndex = 11
        Me.IconCreditsButton.Text = "Icon credits"
        Me.IconCreditsButton.UseVisualStyleBackColor = True
        '
        'About
        '
        Me.AcceptButton = Me.CloseButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(454, 218)
        Me.Controls.Add(Me.IconCreditsButton)
        Me.Controls.Add(Me.GitHubLink)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GitHubLink As System.Windows.Forms.LinkLabel
    Friend WithEvents CopyContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IconCreditsButton As System.Windows.Forms.Button
End Class
