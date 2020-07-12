<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Warnings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Warnings))
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox1.Location = New System.Drawing.Point(17, 74)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(298, 20)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Show warning for access times not being enforced"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox2.Location = New System.Drawing.Point(17, 108)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(265, 20)
        Me.CheckBox2.TabIndex = 1
        Me.CheckBox2.Text = "Show warning for inaccessible account state"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox3.Location = New System.Drawing.Point(17, 177)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(322, 20)
        Me.CheckBox3.TabIndex = 3
        Me.CheckBox3.Text = "Show information for disabled flags when editing users"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(12, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(373, 56)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "You can configure warnings and hints to be shown or hidden."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label6.Location = New System.Drawing.Point(-11, 251)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(423, 1)
        Me.Label6.TabIndex = 15
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Location = New System.Drawing.Point(152, 264)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(102, 29)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(-11, 252)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(396, 58)
        Me.Label5.TabIndex = 14
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Location = New System.Drawing.Point(265, 264)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 29)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox4.Location = New System.Drawing.Point(17, 142)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(296, 20)
        Me.CheckBox4.TabIndex = 2
        Me.CheckBox4.Text = "Show warning for users not assigned to any group"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox5.Location = New System.Drawing.Point(17, 212)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(306, 20)
        Me.CheckBox5.TabIndex = 16
        Me.CheckBox5.Text = "Inform about open property windows before exiting"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'Warnings
        '
        Me.AcceptButton = Me.Button2
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.Button1
        Me.ClientSize = New System.Drawing.Size(380, 307)
        Me.Controls.Add(Me.CheckBox5)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Warnings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configure warnings and hints"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
End Class
