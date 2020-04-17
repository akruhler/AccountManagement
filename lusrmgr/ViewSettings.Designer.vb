<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewSettings))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.showcommandbar = New System.Windows.Forms.CheckBox()
        Me.showstausbar = New System.Windows.Forms.CheckBox()
        Me.QS = New System.Windows.Forms.ComboBox()
        Me.mTop = New System.Windows.Forms.RadioButton()
        Me.mBottom = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(15, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(313, 56)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Change main view appearance"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label6.Location = New System.Drawing.Point(-2, 268)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(446, 1)
        Me.Label6.TabIndex = 15
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Location = New System.Drawing.Point(16, 284)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(102, 27)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Reset settings"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Location = New System.Drawing.Point(326, 284)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 27)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label5.Location = New System.Drawing.Point(0, 269)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(444, 58)
        Me.Label5.TabIndex = 14
        '
        'showcommandbar
        '
        Me.showcommandbar.AutoSize = True
        Me.showcommandbar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.showcommandbar.Location = New System.Drawing.Point(22, 28)
        Me.showcommandbar.Name = "showcommandbar"
        Me.showcommandbar.Size = New System.Drawing.Size(139, 20)
        Me.showcommandbar.TabIndex = 16
        Me.showcommandbar.Text = "Show command bar"
        Me.showcommandbar.UseVisualStyleBackColor = True
        '
        'showstausbar
        '
        Me.showstausbar.AutoSize = True
        Me.showstausbar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.showstausbar.Location = New System.Drawing.Point(22, 63)
        Me.showstausbar.Name = "showstausbar"
        Me.showstausbar.Size = New System.Drawing.Size(158, 20)
        Me.showstausbar.TabIndex = 17
        Me.showstausbar.Text = "Show bottom status bar"
        Me.showstausbar.UseVisualStyleBackColor = True
        '
        'QS
        '
        Me.QS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.QS.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.QS.FormattingEnabled = True
        Me.QS.Items.AddRange(New Object() {"Show in menu", "Show as tool bar", "Hide"})
        Me.QS.Location = New System.Drawing.Point(15, 41)
        Me.QS.Name = "QS"
        Me.QS.Size = New System.Drawing.Size(171, 23)
        Me.QS.TabIndex = 18
        '
        'mTop
        '
        Me.mTop.AutoSize = True
        Me.mTop.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.mTop.Location = New System.Drawing.Point(22, 30)
        Me.mTop.Name = "mTop"
        Me.mTop.Size = New System.Drawing.Size(50, 20)
        Me.mTop.TabIndex = 19
        Me.mTop.TabStop = True
        Me.mTop.Text = "Top"
        Me.mTop.UseVisualStyleBackColor = True
        '
        'mBottom
        '
        Me.mBottom.AutoSize = True
        Me.mBottom.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.mBottom.Location = New System.Drawing.Point(109, 30)
        Me.mBottom.Name = "mBottom"
        Me.mBottom.Size = New System.Drawing.Size(71, 20)
        Me.mBottom.TabIndex = 20
        Me.mBottom.TabStop = True
        Me.mBottom.Text = "Bottom"
        Me.mBottom.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.showcommandbar)
        Me.GroupBox1.Controls.Add(Me.showstausbar)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Command and status bar"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.QS)
        Me.GroupBox2.Location = New System.Drawing.Point(227, 65)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Quick search"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.mTop)
        Me.GroupBox3.Controls.Add(Me.mBottom)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 180)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 68)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Menu bar position"
        '
        'ViewSettings
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.Button1
        Me.ClientSize = New System.Drawing.Size(444, 327)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents showcommandbar As System.Windows.Forms.CheckBox
    Friend WithEvents showstausbar As System.Windows.Forms.CheckBox
    Friend WithEvents QS As System.Windows.Forms.ComboBox
    Friend WithEvents mTop As System.Windows.Forms.RadioButton
    Friend WithEvents mBottom As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
