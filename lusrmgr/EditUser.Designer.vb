<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditUser))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SID = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ApplyButton = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.UserNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FullName = New System.Windows.Forms.TextBox()
        Me.Comment = New System.Windows.Forms.TextBox()
        Me.UserLabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.warnImg = New System.Windows.Forms.PictureBox()
        Me.disabledImg = New System.Windows.Forms.PictureBox()
        Me.pwnotrequired = New System.Windows.Forms.CheckBox()
        Me.pwrvencryption = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Apply4 = New System.Windows.Forms.Button()
        Me.OK4 = New System.Windows.Forms.Button()
        Me.Cancel4 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.bCantChgPasswd = New System.Windows.Forms.CheckBox()
        Me.ChangePwButton = New System.Windows.Forms.Button()
        Me.bPNeverExp = New System.Windows.Forms.CheckBox()
        Me.bChgPNextLogon = New System.Windows.Forms.CheckBox()
        Me.lastpwchanged = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.scriptpath = New System.Windows.Forms.TextBox()
        Me.openbtn = New System.Windows.Forms.Button()
        Me.bAccNeverExp = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.accexpire = New System.Windows.Forms.DateTimePicker()
        Me.TimesBtn = New System.Windows.Forms.Button()
        Me.bDisabled = New System.Windows.Forms.CheckBox()
        Me.bSmartcard = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Apply3 = New System.Windows.Forms.Button()
        Me.OK3 = New System.Windows.Forms.Button()
        Me.Cancel3 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.failedtimes = New System.Windows.Forms.Label()
        Me.lastlogon = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.unlockbtn = New System.Windows.Forms.Button()
        Me.acclockoutdate = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.homedrvR = New System.Windows.Forms.ComboBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.homedirL = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.homedirR = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Apply2 = New System.Windows.Forms.Button()
        Me.OkButton2 = New System.Windows.Forms.Button()
        Me.Cancel2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.GroupOK = New System.Windows.Forms.Button()
        Me.RmGroup = New System.Windows.Forms.Button()
        Me.AddToGrpBtn = New System.Windows.Forms.Button()
        Me.ListView1 = New lusrmgr.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Icons = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.warnImg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.disabledImg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.ToolTip1.ToolTipTitle = "Symbol not allowed"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(434, 436)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.SID)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.ApplyButton)
        Me.TabPage1.Controls.Add(Me.OkButton)
        Me.TabPage1.Controls.Add(Me.CancelBtn)
        Me.TabPage1.Controls.Add(Me.UserNameTextBox)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.FullName)
        Me.TabPage1.Controls.Add(Me.Comment)
        Me.TabPage1.Controls.Add(Me.UserLabel)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(426, 408)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Profile"
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Location = New System.Drawing.Point(22, 282)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(376, 2)
        Me.Label13.TabIndex = 99
        '
        'SID
        '
        Me.SID.Location = New System.Drawing.Point(101, 300)
        Me.SID.Name = "SID"
        Me.SID.ReadOnly = True
        Me.SID.Size = New System.Drawing.Size(297, 23)
        Me.SID.TabIndex = 65
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(21, 300)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 23)
        Me.Label20.TabIndex = 64
        Me.Label20.Text = "SID:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplyButton.Enabled = False
        Me.ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ApplyButton.Location = New System.Drawing.Point(328, 366)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(88, 29)
        Me.ApplyButton.TabIndex = 6
        Me.ApplyButton.Text = "Apply"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OkButton.Location = New System.Drawing.Point(138, 366)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(88, 29)
        Me.OkButton.TabIndex = 4
        Me.OkButton.Text = "OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CancelBtn.Location = New System.Drawing.Point(233, 366)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(88, 29)
        Me.CancelBtn.TabIndex = 5
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'UserNameTextBox
        '
        Me.UserNameTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.UserNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.UserNameTextBox.Location = New System.Drawing.Point(101, 73)
        Me.UserNameTextBox.MaxLength = 20
        Me.UserNameTextBox.Name = "UserNameTextBox"
        Me.UserNameTextBox.ReadOnly = True
        Me.UserNameTextBox.Size = New System.Drawing.Size(297, 16)
        Me.UserNameTextBox.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 15)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Username:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 15)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Description:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 15)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Full name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 151)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Description:"
        '
        'FullName
        '
        Me.FullName.Location = New System.Drawing.Point(101, 108)
        Me.FullName.Name = "FullName"
        Me.FullName.Size = New System.Drawing.Size(297, 23)
        Me.FullName.TabIndex = 2
        '
        'Comment
        '
        Me.Comment.Location = New System.Drawing.Point(101, 151)
        Me.Comment.Multiline = True
        Me.Comment.Name = "Comment"
        Me.Comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Comment.Size = New System.Drawing.Size(297, 113)
        Me.Comment.TabIndex = 3
        '
        'UserLabel
        '
        Me.UserLabel.Location = New System.Drawing.Point(51, 15)
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(363, 39)
        Me.UserLabel.TabIndex = 15
        Me.UserLabel.Text = "User settings for"
        Me.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(13, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage5.Controls.Add(Me.warnImg)
        Me.TabPage5.Controls.Add(Me.disabledImg)
        Me.TabPage5.Controls.Add(Me.pwnotrequired)
        Me.TabPage5.Controls.Add(Me.pwrvencryption)
        Me.TabPage5.Controls.Add(Me.Label9)
        Me.TabPage5.Controls.Add(Me.Apply4)
        Me.TabPage5.Controls.Add(Me.OK4)
        Me.TabPage5.Controls.Add(Me.Cancel4)
        Me.TabPage5.Controls.Add(Me.Label8)
        Me.TabPage5.Controls.Add(Me.PictureBox5)
        Me.TabPage5.Controls.Add(Me.bCantChgPasswd)
        Me.TabPage5.Controls.Add(Me.ChangePwButton)
        Me.TabPage5.Controls.Add(Me.bPNeverExp)
        Me.TabPage5.Controls.Add(Me.bChgPNextLogon)
        Me.TabPage5.Controls.Add(Me.lastpwchanged)
        Me.TabPage5.Controls.Add(Me.Label12)
        Me.TabPage5.Location = New System.Drawing.Point(4, 24)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(426, 408)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Password"
        '
        'warnImg
        '
        Me.warnImg.Image = CType(resources.GetObject("warnImg.Image"), System.Drawing.Image)
        Me.warnImg.Location = New System.Drawing.Point(209, 184)
        Me.warnImg.Name = "warnImg"
        Me.warnImg.Size = New System.Drawing.Size(28, 27)
        Me.warnImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.warnImg.TabIndex = 102
        Me.warnImg.TabStop = False
        Me.warnImg.Visible = False
        '
        'disabledImg
        '
        Me.disabledImg.Image = CType(resources.GetObject("disabledImg.Image"), System.Drawing.Image)
        Me.disabledImg.Location = New System.Drawing.Point(267, 251)
        Me.disabledImg.Name = "disabledImg"
        Me.disabledImg.Size = New System.Drawing.Size(34, 34)
        Me.disabledImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.disabledImg.TabIndex = 101
        Me.disabledImg.TabStop = False
        Me.disabledImg.Visible = False
        '
        'pwnotrequired
        '
        Me.pwnotrequired.AutoSize = True
        Me.pwnotrequired.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.pwnotrequired.Location = New System.Drawing.Point(28, 327)
        Me.pwnotrequired.Name = "pwnotrequired"
        Me.pwnotrequired.Size = New System.Drawing.Size(150, 20)
        Me.pwnotrequired.TabIndex = 13
        Me.pwnotrequired.Text = "Password not required"
        Me.pwnotrequired.UseVisualStyleBackColor = True
        '
        'pwrvencryption
        '
        Me.pwrvencryption.AutoSize = True
        Me.pwrvencryption.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.pwrvencryption.Location = New System.Drawing.Point(28, 292)
        Me.pwrvencryption.Name = "pwrvencryption"
        Me.pwrvencryption.Size = New System.Drawing.Size(257, 20)
        Me.pwrvencryption.TabIndex = 12
        Me.pwrvencryption.Text = "Store password using reversible encryption"
        Me.pwrvencryption.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Location = New System.Drawing.Point(13, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(401, 2)
        Me.Label9.TabIndex = 98
        '
        'Apply4
        '
        Me.Apply4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Apply4.Enabled = False
        Me.Apply4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Apply4.Location = New System.Drawing.Point(328, 366)
        Me.Apply4.Name = "Apply4"
        Me.Apply4.Size = New System.Drawing.Size(88, 29)
        Me.Apply4.TabIndex = 16
        Me.Apply4.Text = "Apply"
        Me.Apply4.UseVisualStyleBackColor = True
        '
        'OK4
        '
        Me.OK4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OK4.Location = New System.Drawing.Point(138, 366)
        Me.OK4.Name = "OK4"
        Me.OK4.Size = New System.Drawing.Size(88, 29)
        Me.OK4.TabIndex = 14
        Me.OK4.Text = "OK"
        Me.OK4.UseVisualStyleBackColor = True
        '
        'Cancel4
        '
        Me.Cancel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel4.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cancel4.Location = New System.Drawing.Point(233, 366)
        Me.Cancel4.Name = "Cancel4"
        Me.Cancel4.Size = New System.Drawing.Size(88, 29)
        Me.Cancel4.TabIndex = 15
        Me.Cancel4.Text = "Cancel"
        Me.Cancel4.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(51, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(363, 39)
        Me.Label8.TabIndex = 94
        Me.Label8.Text = "User settings for"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(13, 15)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox5.TabIndex = 93
        Me.PictureBox5.TabStop = False
        '
        'bCantChgPasswd
        '
        Me.bCantChgPasswd.AutoSize = True
        Me.bCantChgPasswd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bCantChgPasswd.Location = New System.Drawing.Point(28, 187)
        Me.bCantChgPasswd.Name = "bCantChgPasswd"
        Me.bCantChgPasswd.Size = New System.Drawing.Size(190, 20)
        Me.bCantChgPasswd.TabIndex = 9
        Me.bCantChgPasswd.Text = "User cannot change password"
        Me.bCantChgPasswd.UseVisualStyleBackColor = True
        '
        'ChangePwButton
        '
        Me.ChangePwButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ChangePwButton.Location = New System.Drawing.Point(162, 114)
        Me.ChangePwButton.Name = "ChangePwButton"
        Me.ChangePwButton.Size = New System.Drawing.Size(196, 33)
        Me.ChangePwButton.TabIndex = 8
        Me.ChangePwButton.Text = "Change password..."
        Me.ChangePwButton.UseVisualStyleBackColor = True
        '
        'bPNeverExp
        '
        Me.bPNeverExp.AutoSize = True
        Me.bPNeverExp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bPNeverExp.Location = New System.Drawing.Point(28, 222)
        Me.bPNeverExp.Name = "bPNeverExp"
        Me.bPNeverExp.Size = New System.Drawing.Size(154, 20)
        Me.bPNeverExp.TabIndex = 10
        Me.bPNeverExp.Text = "Password never expires"
        Me.bPNeverExp.UseVisualStyleBackColor = True
        '
        'bChgPNextLogon
        '
        Me.bChgPNextLogon.AutoSize = True
        Me.bChgPNextLogon.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bChgPNextLogon.Location = New System.Drawing.Point(28, 257)
        Me.bChgPNextLogon.Name = "bChgPNextLogon"
        Me.bChgPNextLogon.Size = New System.Drawing.Size(253, 20)
        Me.bChgPNextLogon.TabIndex = 11
        Me.bChgPNextLogon.Text = "User must change password at next logon"
        Me.bChgPNextLogon.UseVisualStyleBackColor = True
        '
        'lastpwchanged
        '
        Me.lastpwchanged.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lastpwchanged.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lastpwchanged.Location = New System.Drawing.Point(162, 75)
        Me.lastpwchanged.Name = "lastpwchanged"
        Me.lastpwchanged.Size = New System.Drawing.Size(234, 23)
        Me.lastpwchanged.TabIndex = 7
        Me.lastpwchanged.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ForeColor = System.Drawing.Color.Black
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(103, 26)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.CopyToolStripMenuItem.Image = CType(resources.GetObject("CopyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(21, 75)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 23)
        Me.Label12.TabIndex = 87
        Me.Label12.Text = "Password last changed:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage4.Controls.Add(Me.GroupBox2)
        Me.TabPage4.Controls.Add(Me.bAccNeverExp)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Controls.Add(Me.accexpire)
        Me.TabPage4.Controls.Add(Me.TimesBtn)
        Me.TabPage4.Controls.Add(Me.bDisabled)
        Me.TabPage4.Controls.Add(Me.bSmartcard)
        Me.TabPage4.Controls.Add(Me.Label19)
        Me.TabPage4.Controls.Add(Me.Apply3)
        Me.TabPage4.Controls.Add(Me.OK3)
        Me.TabPage4.Controls.Add(Me.Cancel3)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.PictureBox4)
        Me.TabPage4.Controls.Add(Me.failedtimes)
        Me.TabPage4.Controls.Add(Me.lastlogon)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.Label10)
        Me.TabPage4.Location = New System.Drawing.Point(4, 24)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(426, 408)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Logon settings"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.scriptpath)
        Me.GroupBox2.Controls.Add(Me.openbtn)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 285)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(402, 65)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Logon script"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(17, 30)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 15)
        Me.Label15.TabIndex = 101
        Me.Label15.Text = "Path:"
        '
        'scriptpath
        '
        Me.scriptpath.Location = New System.Drawing.Point(57, 27)
        Me.scriptpath.Name = "scriptpath"
        Me.scriptpath.Size = New System.Drawing.Size(289, 23)
        Me.scriptpath.TabIndex = 23
        '
        'openbtn
        '
        Me.openbtn.Image = CType(resources.GetObject("openbtn.Image"), System.Drawing.Image)
        Me.openbtn.Location = New System.Drawing.Point(352, 26)
        Me.openbtn.Name = "openbtn"
        Me.openbtn.Size = New System.Drawing.Size(37, 25)
        Me.openbtn.TabIndex = 24
        Me.openbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.openbtn.UseVisualStyleBackColor = True
        '
        'bAccNeverExp
        '
        Me.bAccNeverExp.AutoSize = True
        Me.bAccNeverExp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bAccNeverExp.Location = New System.Drawing.Point(181, 177)
        Me.bAccNeverExp.Name = "bAccNeverExp"
        Me.bAccNeverExp.Size = New System.Drawing.Size(149, 20)
        Me.bAccNeverExp.TabIndex = 19
        Me.bAccNeverExp.Text = "Account never expires"
        Me.bAccNeverExp.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 15)
        Me.Label7.TabIndex = 98
        Me.Label7.Text = "Account expirarion date:"
        '
        'accexpire
        '
        Me.accexpire.Location = New System.Drawing.Point(181, 144)
        Me.accexpire.Name = "accexpire"
        Me.accexpire.Size = New System.Drawing.Size(234, 23)
        Me.accexpire.TabIndex = 18
        '
        'TimesBtn
        '
        Me.TimesBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TimesBtn.Location = New System.Drawing.Point(15, 230)
        Me.TimesBtn.Name = "TimesBtn"
        Me.TimesBtn.Size = New System.Drawing.Size(148, 33)
        Me.TimesBtn.TabIndex = 22
        Me.TimesBtn.Text = "Define access times..."
        Me.TimesBtn.UseVisualStyleBackColor = True
        '
        'bDisabled
        '
        Me.bDisabled.AutoSize = True
        Me.bDisabled.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bDisabled.Location = New System.Drawing.Point(181, 222)
        Me.bDisabled.Name = "bDisabled"
        Me.bDisabled.Size = New System.Drawing.Size(135, 20)
        Me.bDisabled.TabIndex = 20
        Me.bDisabled.Text = "Account is disabled"
        Me.bDisabled.UseVisualStyleBackColor = True
        '
        'bSmartcard
        '
        Me.bSmartcard.AutoSize = True
        Me.bSmartcard.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bSmartcard.Location = New System.Drawing.Point(181, 253)
        Me.bSmartcard.Name = "bSmartcard"
        Me.bSmartcard.Size = New System.Drawing.Size(221, 20)
        Me.bSmartcard.TabIndex = 21
        Me.bSmartcard.Text = "User has to logon using a smartcard"
        Me.bSmartcard.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Location = New System.Drawing.Point(13, 208)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(401, 2)
        Me.Label19.TabIndex = 82
        '
        'Apply3
        '
        Me.Apply3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Apply3.Enabled = False
        Me.Apply3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Apply3.Location = New System.Drawing.Point(328, 366)
        Me.Apply3.Name = "Apply3"
        Me.Apply3.Size = New System.Drawing.Size(88, 29)
        Me.Apply3.TabIndex = 27
        Me.Apply3.Text = "Apply"
        Me.Apply3.UseVisualStyleBackColor = True
        '
        'OK3
        '
        Me.OK3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OK3.Location = New System.Drawing.Point(138, 366)
        Me.OK3.Name = "OK3"
        Me.OK3.Size = New System.Drawing.Size(88, 29)
        Me.OK3.TabIndex = 25
        Me.OK3.Text = "OK"
        Me.OK3.UseVisualStyleBackColor = True
        '
        'Cancel3
        '
        Me.Cancel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cancel3.Location = New System.Drawing.Point(233, 366)
        Me.Cancel3.Name = "Cancel3"
        Me.Cancel3.Size = New System.Drawing.Size(88, 29)
        Me.Cancel3.TabIndex = 26
        Me.Cancel3.Text = "Cancel"
        Me.Cancel3.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(51, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(363, 39)
        Me.Label14.TabIndex = 67
        Me.Label14.Text = "User settings for"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(13, 15)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox4.TabIndex = 66
        Me.PictureBox4.TabStop = False
        '
        'failedtimes
        '
        Me.failedtimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.failedtimes.ContextMenuStrip = Me.ContextMenuStrip1
        Me.failedtimes.Location = New System.Drawing.Point(181, 108)
        Me.failedtimes.Name = "failedtimes"
        Me.failedtimes.Size = New System.Drawing.Size(234, 23)
        Me.failedtimes.TabIndex = 18
        Me.failedtimes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lastlogon
        '
        Me.lastlogon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lastlogon.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lastlogon.Location = New System.Drawing.Point(181, 70)
        Me.lastlogon.Name = "lastlogon"
        Me.lastlogon.Size = New System.Drawing.Size(234, 23)
        Me.lastlogon.TabIndex = 17
        Me.lastlogon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(9, 107)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(167, 23)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "Failed logons since last logon:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(9, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(167, 23)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "Last successful logon:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Apply2)
        Me.TabPage2.Controls.Add(Me.OkButton2)
        Me.TabPage2.Controls.Add(Me.Cancel2)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(426, 408)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Advanced"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.unlockbtn)
        Me.GroupBox3.Controls.Add(Me.acclockoutdate)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 248)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(403, 102)
        Me.GroupBox3.TabIndex = 79
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Account lock"
        '
        'unlockbtn
        '
        Me.unlockbtn.Image = CType(resources.GetObject("unlockbtn.Image"), System.Drawing.Image)
        Me.unlockbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.unlockbtn.Location = New System.Drawing.Point(151, 59)
        Me.unlockbtn.Name = "unlockbtn"
        Me.unlockbtn.Size = New System.Drawing.Size(117, 29)
        Me.unlockbtn.TabIndex = 34
        Me.unlockbtn.Text = "Unlock account"
        Me.unlockbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.unlockbtn.UseVisualStyleBackColor = True
        '
        'acclockoutdate
        '
        Me.acclockoutdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.acclockoutdate.ContextMenuStrip = Me.ContextMenuStrip1
        Me.acclockoutdate.Location = New System.Drawing.Point(152, 25)
        Me.acclockoutdate.Name = "acclockoutdate"
        Me.acclockoutdate.Size = New System.Drawing.Size(234, 23)
        Me.acclockoutdate.TabIndex = 33
        Me.acclockoutdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(21, 24)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 23)
        Me.Label18.TabIndex = 79
        Me.Label18.Text = "Account lockout state:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.homedrvR)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.homedirL)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.homedirR)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(405, 174)
        Me.GroupBox1.TabIndex = 65
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Home folder"
        '
        'homedrvR
        '
        Me.homedrvR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.homedrvR.Enabled = False
        Me.homedrvR.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.homedrvR.FormattingEnabled = True
        Me.homedrvR.Items.AddRange(New Object() {"", "C:", "D:", "E:", "F:", "G:", "H:", "I:", "J:", "K:", "L:", "M:", "N:", "O:", "P:", "Q:", "R:", "S:", "T:", "U:", "V:", "W:", "X:", "Y:", "Z:"})
        Me.homedrvR.Location = New System.Drawing.Point(105, 99)
        Me.homedrvR.Name = "homedrvR"
        Me.homedrvR.Size = New System.Drawing.Size(59, 23)
        Me.homedrvR.TabIndex = 31
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RadioButton2.Location = New System.Drawing.Point(22, 67)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(102, 20)
        Me.RadioButton2.TabIndex = 30
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Remote path:"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'homedirL
        '
        Me.homedirL.Enabled = False
        Me.homedirL.Location = New System.Drawing.Point(105, 30)
        Me.homedirL.Name = "homedirL"
        Me.homedirL.Size = New System.Drawing.Size(283, 23)
        Me.homedirL.TabIndex = 29
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Enabled = False
        Me.Label17.Location = New System.Drawing.Point(68, 139)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 15)
        Me.Label17.TabIndex = 56
        Me.Label17.Text = "Path:"
        '
        'homedirR
        '
        Me.homedirR.Enabled = False
        Me.homedirR.Location = New System.Drawing.Point(105, 136)
        Me.homedirR.Name = "homedirR"
        Me.homedirR.Size = New System.Drawing.Size(283, 23)
        Me.homedirR.TabIndex = 32
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Enabled = False
        Me.Label16.Location = New System.Drawing.Point(65, 102)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 15)
        Me.Label16.TabIndex = 58
        Me.Label16.Text = "Drive:"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RadioButton1.Location = New System.Drawing.Point(22, 31)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(89, 20)
        Me.RadioButton1.TabIndex = 28
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Local path:"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Apply2
        '
        Me.Apply2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Apply2.Enabled = False
        Me.Apply2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Apply2.Location = New System.Drawing.Point(328, 366)
        Me.Apply2.Name = "Apply2"
        Me.Apply2.Size = New System.Drawing.Size(88, 29)
        Me.Apply2.TabIndex = 37
        Me.Apply2.Text = "Apply"
        Me.Apply2.UseVisualStyleBackColor = True
        '
        'OkButton2
        '
        Me.OkButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OkButton2.Location = New System.Drawing.Point(138, 366)
        Me.OkButton2.Name = "OkButton2"
        Me.OkButton2.Size = New System.Drawing.Size(88, 29)
        Me.OkButton2.TabIndex = 35
        Me.OkButton2.Text = "OK"
        Me.OkButton2.UseVisualStyleBackColor = True
        '
        'Cancel2
        '
        Me.Cancel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cancel2.Location = New System.Drawing.Point(233, 366)
        Me.Cancel2.Name = "Cancel2"
        Me.Cancel2.Size = New System.Drawing.Size(88, 29)
        Me.Cancel2.TabIndex = 36
        Me.Cancel2.Text = "Cancel"
        Me.Cancel2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(51, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(363, 39)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "User settings for"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(13, 15)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.PictureBox3)
        Me.TabPage3.Controls.Add(Me.GroupOK)
        Me.TabPage3.Controls.Add(Me.RmGroup)
        Me.TabPage3.Controls.Add(Me.AddToGrpBtn)
        Me.TabPage3.Controls.Add(Me.ListView1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(426, 408)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Group membership"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(51, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(363, 39)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "User settings for"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(13, 15)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox3.TabIndex = 42
        Me.PictureBox3.TabStop = False
        '
        'GroupOK
        '
        Me.GroupOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupOK.Location = New System.Drawing.Point(332, 364)
        Me.GroupOK.Name = "GroupOK"
        Me.GroupOK.Size = New System.Drawing.Size(86, 30)
        Me.GroupOK.TabIndex = 41
        Me.GroupOK.Text = "OK"
        Me.GroupOK.UseVisualStyleBackColor = True
        '
        'RmGroup
        '
        Me.RmGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RmGroup.Enabled = False
        Me.RmGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RmGroup.Location = New System.Drawing.Point(172, 364)
        Me.RmGroup.Name = "RmGroup"
        Me.RmGroup.Size = New System.Drawing.Size(154, 30)
        Me.RmGroup.TabIndex = 40
        Me.RmGroup.Text = "Remove membership"
        Me.RmGroup.UseVisualStyleBackColor = True
        '
        'AddToGrpBtn
        '
        Me.AddToGrpBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AddToGrpBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AddToGrpBtn.Location = New System.Drawing.Point(8, 364)
        Me.AddToGrpBtn.Name = "AddToGrpBtn"
        Me.AddToGrpBtn.Size = New System.Drawing.Size(158, 30)
        Me.AddToGrpBtn.TabIndex = 39
        Me.AddToGrpBtn.Text = "Add to group"
        Me.AddToGrpBtn.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListView1.Location = New System.Drawing.Point(8, 70)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.Size = New System.Drawing.Size(410, 283)
        Me.ListView1.SmallImageList = Me.Icons
        Me.ListView1.TabIndex = 38
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Group"
        Me.ColumnHeader1.Width = 406
        '
        'Icons
        '
        Me.Icons.ImageStream = CType(resources.GetObject("Icons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Icons.TransparentColor = System.Drawing.Color.Transparent
        Me.Icons.Images.SetKeyName(0, "group.ico")
        '
        'ToolTip2
        '
        Me.ToolTip2.IsBalloon = True
        Me.ToolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip2.ToolTipTitle = "User must change password at next logon"
        '
        'EditUser
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CancelBtn
        Me.ClientSize = New System.Drawing.Size(434, 436)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EditUser"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.warnImg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.disabledImg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
    Friend WithEvents UserNameTextBox As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FullName As System.Windows.Forms.TextBox
    Friend WithEvents Comment As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupOK As System.Windows.Forms.Button
    Friend WithEvents RmGroup As System.Windows.Forms.Button
    Friend WithEvents AddToGrpBtn As System.Windows.Forms.Button
    Friend WithEvents ListView1 As lusrmgr.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents UserLabel As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Icons As System.Windows.Forms.ImageList
    Private WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Apply2 As System.Windows.Forms.Button
    Friend WithEvents OkButton2 As System.Windows.Forms.Button
    Friend WithEvents Cancel2 As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Apply3 As System.Windows.Forms.Button
    Friend WithEvents OK3 As System.Windows.Forms.Button
    Friend WithEvents Cancel3 As System.Windows.Forms.Button
    Private WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents failedtimes As System.Windows.Forms.Label
    Friend WithEvents lastlogon As System.Windows.Forms.Label
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents homedirR As System.Windows.Forms.TextBox
    Private WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents homedirL As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents homedrvR As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents scriptpath As System.Windows.Forms.TextBox
    Friend WithEvents openbtn As System.Windows.Forms.Button
    Private WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents accexpire As System.Windows.Forms.DateTimePicker
    Friend WithEvents TimesBtn As System.Windows.Forms.Button
    Friend WithEvents bDisabled As System.Windows.Forms.CheckBox
    Friend WithEvents bSmartcard As System.Windows.Forms.CheckBox
    Friend WithEvents lastpwchanged As System.Windows.Forms.Label
    Private WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents unlockbtn As System.Windows.Forms.Button
    Friend WithEvents acclockoutdate As System.Windows.Forms.Label
    Private WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents pwrvencryption As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Apply4 As System.Windows.Forms.Button
    Friend WithEvents OK4 As System.Windows.Forms.Button
    Friend WithEvents Cancel4 As System.Windows.Forms.Button
    Private WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents bCantChgPasswd As System.Windows.Forms.CheckBox
    Friend WithEvents ChangePwButton As System.Windows.Forms.Button
    Friend WithEvents bPNeverExp As System.Windows.Forms.CheckBox
    Friend WithEvents bChgPNextLogon As System.Windows.Forms.CheckBox
    Friend WithEvents pwnotrequired As System.Windows.Forms.CheckBox
    Friend WithEvents bAccNeverExp As System.Windows.Forms.CheckBox
    Friend WithEvents disabledImg As System.Windows.Forms.PictureBox
    Private WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents warnImg As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents SID As System.Windows.Forms.TextBox
    Private WithEvents Label20 As System.Windows.Forms.Label
End Class
