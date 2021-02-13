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
        Me.Tabs = New System.Windows.Forms.TabControl()
        Me.TabGeneral = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SID = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.UserNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FullName = New System.Windows.Forms.TextBox()
        Me.Comment = New System.Windows.Forms.TextBox()
        Me.TabPassword = New System.Windows.Forms.TabPage()
        Me.disabledInfo = New lusrmgr.TransparentPanel()
        Me.warnImg = New System.Windows.Forms.PictureBox()
        Me.PwNotRequired = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.UserCantChangePw = New System.Windows.Forms.CheckBox()
        Me.SetPwButton = New System.Windows.Forms.Button()
        Me.PwNeverExpires = New System.Windows.Forms.CheckBox()
        Me.UserMustChangePwOnNextLogon = New System.Windows.Forms.CheckBox()
        Me.PwLastChanged = New System.Windows.Forms.Label()
        Me.CopyContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.PwExpDate = New System.Windows.Forms.Label()
        Me.TabLogon = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.AccountExpDate = New System.Windows.Forms.DateTimePicker()
        Me.AccountNeverExpires = New System.Windows.Forms.CheckBox()
        Me.AccountExpTime = New System.Windows.Forms.DateTimePicker()
        Me.unlockbtn = New System.Windows.Forms.Button()
        Me.TimesBtn = New System.Windows.Forms.Button()
        Me.AccountDisabled = New System.Windows.Forms.CheckBox()
        Me.SmartcardRequired = New System.Windows.Forms.CheckBox()
        Me.failedtimes = New System.Windows.Forms.Label()
        Me.lastlogon = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabProfile = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ProfilePath = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ScriptPath = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.homedrvR = New System.Windows.Forms.ComboBox()
        Me.HomeRemotePath = New System.Windows.Forms.RadioButton()
        Me.homedirL = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.homedirR = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.HomeLocalPath = New System.Windows.Forms.RadioButton()
        Me.TabGroups = New System.Windows.Forms.TabPage()
        Me.GroupOK = New System.Windows.Forms.Button()
        Me.RmGroup = New System.Windows.Forms.Button()
        Me.AddToGrpBtn = New System.Windows.Forms.Button()
        Me.GroupMembership = New lusrmgr.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UserLabel = New System.Windows.Forms.Label()
        Me.UserIcon = New System.Windows.Forms.PictureBox()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.ApplyButton = New System.Windows.Forms.Button()
        Me.UserMustChangePasswordInfo = New System.Windows.Forms.ToolTip(Me.components)
        Me.BottomPanel = New System.Windows.Forms.Panel()
        Me.TopPanel = New System.Windows.Forms.Panel()
        Me.Tabs.SuspendLayout()
        Me.TabGeneral.SuspendLayout()
        Me.TabPassword.SuspendLayout()
        CType(Me.warnImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CopyContextMenu.SuspendLayout()
        Me.TabLogon.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabProfile.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabGroups.SuspendLayout()
        CType(Me.UserIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BottomPanel.SuspendLayout()
        Me.TopPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tabs
        '
        Me.Tabs.Controls.Add(Me.TabGeneral)
        Me.Tabs.Controls.Add(Me.TabPassword)
        Me.Tabs.Controls.Add(Me.TabLogon)
        Me.Tabs.Controls.Add(Me.TabProfile)
        Me.Tabs.Controls.Add(Me.TabGroups)
        Me.Tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabs.Location = New System.Drawing.Point(0, 0)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.Padding = New System.Drawing.Point(8, 3)
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(434, 436)
        Me.Tabs.TabIndex = 0
        '
        'TabGeneral
        '
        Me.TabGeneral.BackColor = System.Drawing.SystemColors.Control
        Me.TabGeneral.Controls.Add(Me.Label13)
        Me.TabGeneral.Controls.Add(Me.SID)
        Me.TabGeneral.Controls.Add(Me.Label20)
        Me.TabGeneral.Controls.Add(Me.UserNameTextBox)
        Me.TabGeneral.Controls.Add(Me.Label3)
        Me.TabGeneral.Controls.Add(Me.Label4)
        Me.TabGeneral.Controls.Add(Me.Label2)
        Me.TabGeneral.Controls.Add(Me.Label1)
        Me.TabGeneral.Controls.Add(Me.FullName)
        Me.TabGeneral.Controls.Add(Me.Comment)
        Me.TabGeneral.Location = New System.Drawing.Point(4, 24)
        Me.TabGeneral.Name = "TabGeneral"
        Me.TabGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGeneral.Size = New System.Drawing.Size(426, 408)
        Me.TabGeneral.TabIndex = 0
        Me.TabGeneral.Text = "General"
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Location = New System.Drawing.Point(22, 277)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(376, 2)
        Me.Label13.TabIndex = 99
        '
        'SID
        '
        Me.SID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SID.Location = New System.Drawing.Point(101, 295)
        Me.SID.Name = "SID"
        Me.SID.ReadOnly = True
        Me.SID.Size = New System.Drawing.Size(297, 23)
        Me.SID.TabIndex = 4
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.Location = New System.Drawing.Point(21, 295)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 23)
        Me.Label20.TabIndex = 64
        Me.Label20.Text = "SID:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UserNameTextBox
        '
        Me.UserNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.FullName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FullName.Location = New System.Drawing.Point(101, 108)
        Me.FullName.Name = "FullName"
        Me.FullName.Size = New System.Drawing.Size(297, 23)
        Me.FullName.TabIndex = 2
        '
        'Comment
        '
        Me.Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Comment.Location = New System.Drawing.Point(101, 151)
        Me.Comment.Multiline = True
        Me.Comment.Name = "Comment"
        Me.Comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Comment.Size = New System.Drawing.Size(297, 108)
        Me.Comment.TabIndex = 3
        '
        'TabPassword
        '
        Me.TabPassword.BackColor = System.Drawing.SystemColors.Control
        Me.TabPassword.Controls.Add(Me.disabledInfo)
        Me.TabPassword.Controls.Add(Me.warnImg)
        Me.TabPassword.Controls.Add(Me.PwNotRequired)
        Me.TabPassword.Controls.Add(Me.Label9)
        Me.TabPassword.Controls.Add(Me.UserCantChangePw)
        Me.TabPassword.Controls.Add(Me.SetPwButton)
        Me.TabPassword.Controls.Add(Me.PwNeverExpires)
        Me.TabPassword.Controls.Add(Me.UserMustChangePwOnNextLogon)
        Me.TabPassword.Controls.Add(Me.PwLastChanged)
        Me.TabPassword.Controls.Add(Me.Label12)
        Me.TabPassword.Controls.Add(Me.Label22)
        Me.TabPassword.Controls.Add(Me.PwExpDate)
        Me.TabPassword.Location = New System.Drawing.Point(4, 24)
        Me.TabPassword.Name = "TabPassword"
        Me.TabPassword.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPassword.Size = New System.Drawing.Size(426, 408)
        Me.TabPassword.TabIndex = 4
        Me.TabPassword.Text = "Password"
        '
        'disabledInfo
        '
        Me.disabledInfo.BackColor = System.Drawing.Color.Transparent
        Me.disabledInfo.Location = New System.Drawing.Point(18, 211)
        Me.disabledInfo.Name = "disabledInfo"
        Me.disabledInfo.Size = New System.Drawing.Size(260, 36)
        Me.disabledInfo.TabIndex = 108
        Me.UserMustChangePasswordInfo.SetToolTip(Me.disabledInfo, "This option cannot be enabled if either the option" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & """Password never expires"" is e" & _
        "nabled or a smartcard logon is forced.")
        Me.disabledInfo.Visible = False
        '
        'warnImg
        '
        Me.warnImg.Image = Global.lusrmgr.My.Resources.Resources.Warning
        Me.warnImg.Location = New System.Drawing.Point(209, 255)
        Me.warnImg.Name = "warnImg"
        Me.warnImg.Size = New System.Drawing.Size(16, 16)
        Me.warnImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.warnImg.TabIndex = 102
        Me.warnImg.TabStop = False
        Me.warnImg.Visible = False
        '
        'PwNotRequired
        '
        Me.PwNotRequired.AutoSize = True
        Me.PwNotRequired.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PwNotRequired.Location = New System.Drawing.Point(28, 324)
        Me.PwNotRequired.Name = "PwNotRequired"
        Me.PwNotRequired.Size = New System.Drawing.Size(150, 20)
        Me.PwNotRequired.TabIndex = 13
        Me.PwNotRequired.Text = "Password not required"
        Me.PwNotRequired.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Location = New System.Drawing.Point(13, 199)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(401, 2)
        Me.Label9.TabIndex = 98
        '
        'UserCantChangePw
        '
        Me.UserCantChangePw.AutoSize = True
        Me.UserCantChangePw.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.UserCantChangePw.Location = New System.Drawing.Point(28, 254)
        Me.UserCantChangePw.Name = "UserCantChangePw"
        Me.UserCantChangePw.Size = New System.Drawing.Size(190, 20)
        Me.UserCantChangePw.TabIndex = 9
        Me.UserCantChangePw.Text = "User cannot change password"
        Me.UserCantChangePw.UseVisualStyleBackColor = True
        '
        'SetPwButton
        '
        Me.SetPwButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SetPwButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SetPwButton.Location = New System.Drawing.Point(162, 147)
        Me.SetPwButton.Name = "SetPwButton"
        Me.SetPwButton.Size = New System.Drawing.Size(179, 33)
        Me.SetPwButton.TabIndex = 8
        Me.SetPwButton.Text = "Set password..."
        Me.SetPwButton.UseVisualStyleBackColor = True
        '
        'PwNeverExpires
        '
        Me.PwNeverExpires.AutoSize = True
        Me.PwNeverExpires.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PwNeverExpires.Location = New System.Drawing.Point(28, 289)
        Me.PwNeverExpires.Name = "PwNeverExpires"
        Me.PwNeverExpires.Size = New System.Drawing.Size(154, 20)
        Me.PwNeverExpires.TabIndex = 10
        Me.PwNeverExpires.Text = "Password never expires"
        Me.PwNeverExpires.UseVisualStyleBackColor = True
        '
        'UserMustChangePwOnNextLogon
        '
        Me.UserMustChangePwOnNextLogon.AutoSize = True
        Me.UserMustChangePwOnNextLogon.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.UserMustChangePwOnNextLogon.Location = New System.Drawing.Point(28, 219)
        Me.UserMustChangePwOnNextLogon.Name = "UserMustChangePwOnNextLogon"
        Me.UserMustChangePwOnNextLogon.Size = New System.Drawing.Size(253, 20)
        Me.UserMustChangePwOnNextLogon.TabIndex = 11
        Me.UserMustChangePwOnNextLogon.Text = "User must change password at next logon"
        Me.UserMustChangePwOnNextLogon.UseVisualStyleBackColor = True
        '
        'PwLastChanged
        '
        Me.PwLastChanged.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PwLastChanged.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PwLastChanged.ContextMenuStrip = Me.CopyContextMenu
        Me.PwLastChanged.Location = New System.Drawing.Point(162, 109)
        Me.PwLastChanged.Name = "PwLastChanged"
        Me.PwLastChanged.Size = New System.Drawing.Size(240, 23)
        Me.PwLastChanged.TabIndex = 7
        Me.PwLastChanged.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CopyContextMenu
        '
        Me.CopyContextMenu.ForeColor = System.Drawing.Color.Black
        Me.CopyContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem})
        Me.CopyContextMenu.Name = "ContextMenuStrip1"
        Me.CopyContextMenu.Size = New System.Drawing.Size(103, 26)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.CopyToolStripMenuItem.Image = Global.lusrmgr.My.Resources.Resources.CopyImg
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(21, 109)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 23)
        Me.Label12.TabIndex = 87
        Me.Label12.Text = "Password last changed:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(21, 71)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(136, 23)
        Me.Label22.TabIndex = 104
        Me.Label22.Text = "Password expires:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PwExpDate
        '
        Me.PwExpDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PwExpDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PwExpDate.ContextMenuStrip = Me.CopyContextMenu
        Me.PwExpDate.Location = New System.Drawing.Point(162, 71)
        Me.PwExpDate.Name = "PwExpDate"
        Me.PwExpDate.Size = New System.Drawing.Size(240, 23)
        Me.PwExpDate.TabIndex = 106
        Me.PwExpDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabLogon
        '
        Me.TabLogon.BackColor = System.Drawing.SystemColors.Control
        Me.TabLogon.Controls.Add(Me.GroupBox3)
        Me.TabLogon.Controls.Add(Me.unlockbtn)
        Me.TabLogon.Controls.Add(Me.TimesBtn)
        Me.TabLogon.Controls.Add(Me.AccountDisabled)
        Me.TabLogon.Controls.Add(Me.SmartcardRequired)
        Me.TabLogon.Controls.Add(Me.failedtimes)
        Me.TabLogon.Controls.Add(Me.lastlogon)
        Me.TabLogon.Controls.Add(Me.Label11)
        Me.TabLogon.Controls.Add(Me.Label10)
        Me.TabLogon.Location = New System.Drawing.Point(4, 24)
        Me.TabLogon.Name = "TabLogon"
        Me.TabLogon.Padding = New System.Windows.Forms.Padding(3)
        Me.TabLogon.Size = New System.Drawing.Size(426, 408)
        Me.TabLogon.TabIndex = 3
        Me.TabLogon.Text = "Account"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.AccountExpDate)
        Me.GroupBox3.Controls.Add(Me.AccountNeverExpires)
        Me.GroupBox3.Controls.Add(Me.AccountExpTime)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 146)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(402, 90)
        Me.GroupBox3.TabIndex = 103
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Account expirarion date"
        '
        'AccountExpDate
        '
        Me.AccountExpDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AccountExpDate.CustomFormat = ""
        Me.AccountExpDate.Location = New System.Drawing.Point(17, 28)
        Me.AccountExpDate.Name = "AccountExpDate"
        Me.AccountExpDate.Size = New System.Drawing.Size(266, 23)
        Me.AccountExpDate.TabIndex = 18
        '
        'AccountNeverExpires
        '
        Me.AccountNeverExpires.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.AccountNeverExpires.AutoSize = True
        Me.AccountNeverExpires.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AccountNeverExpires.Location = New System.Drawing.Point(17, 58)
        Me.AccountNeverExpires.Name = "AccountNeverExpires"
        Me.AccountNeverExpires.Size = New System.Drawing.Size(149, 20)
        Me.AccountNeverExpires.TabIndex = 101
        Me.AccountNeverExpires.Text = "Account never expires"
        Me.AccountNeverExpires.UseVisualStyleBackColor = True
        '
        'AccountExpTime
        '
        Me.AccountExpTime.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.AccountExpTime.CustomFormat = ""
        Me.AccountExpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.AccountExpTime.Location = New System.Drawing.Point(289, 28)
        Me.AccountExpTime.Name = "AccountExpTime"
        Me.AccountExpTime.ShowUpDown = True
        Me.AccountExpTime.Size = New System.Drawing.Size(91, 23)
        Me.AccountExpTime.TabIndex = 102
        '
        'unlockbtn
        '
        Me.unlockbtn.Image = Global.lusrmgr.My.Resources.Resources.UnlockIcon
        Me.unlockbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.unlockbtn.Location = New System.Drawing.Point(188, 250)
        Me.unlockbtn.Name = "unlockbtn"
        Me.unlockbtn.Size = New System.Drawing.Size(116, 33)
        Me.unlockbtn.TabIndex = 100
        Me.unlockbtn.Text = "Unlock account"
        Me.unlockbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.unlockbtn.UseVisualStyleBackColor = True
        '
        'TimesBtn
        '
        Me.TimesBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TimesBtn.Location = New System.Drawing.Point(30, 250)
        Me.TimesBtn.Name = "TimesBtn"
        Me.TimesBtn.Size = New System.Drawing.Size(148, 33)
        Me.TimesBtn.TabIndex = 22
        Me.TimesBtn.Text = "Define access times..."
        Me.TimesBtn.UseVisualStyleBackColor = True
        '
        'AccountDisabled
        '
        Me.AccountDisabled.AutoSize = True
        Me.AccountDisabled.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AccountDisabled.Location = New System.Drawing.Point(30, 294)
        Me.AccountDisabled.Name = "AccountDisabled"
        Me.AccountDisabled.Size = New System.Drawing.Size(135, 20)
        Me.AccountDisabled.TabIndex = 20
        Me.AccountDisabled.Text = "Account is disabled"
        Me.AccountDisabled.UseVisualStyleBackColor = True
        '
        'SmartcardRequired
        '
        Me.SmartcardRequired.AutoSize = True
        Me.SmartcardRequired.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SmartcardRequired.Location = New System.Drawing.Point(30, 325)
        Me.SmartcardRequired.Name = "SmartcardRequired"
        Me.SmartcardRequired.Size = New System.Drawing.Size(221, 20)
        Me.SmartcardRequired.TabIndex = 21
        Me.SmartcardRequired.Text = "User has to logon using a smartcard"
        Me.SmartcardRequired.UseVisualStyleBackColor = True
        '
        'failedtimes
        '
        Me.failedtimes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.failedtimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.failedtimes.ContextMenuStrip = Me.CopyContextMenu
        Me.failedtimes.Location = New System.Drawing.Point(181, 108)
        Me.failedtimes.Name = "failedtimes"
        Me.failedtimes.Size = New System.Drawing.Size(234, 23)
        Me.failedtimes.TabIndex = 18
        Me.failedtimes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lastlogon
        '
        Me.lastlogon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lastlogon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lastlogon.ContextMenuStrip = Me.CopyContextMenu
        Me.lastlogon.Location = New System.Drawing.Point(181, 69)
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
        Me.Label10.Location = New System.Drawing.Point(9, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(167, 23)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "Last successful logon:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabProfile
        '
        Me.TabProfile.BackColor = System.Drawing.SystemColors.Control
        Me.TabProfile.Controls.Add(Me.GroupBox2)
        Me.TabProfile.Controls.Add(Me.GroupBox1)
        Me.TabProfile.Location = New System.Drawing.Point(4, 24)
        Me.TabProfile.Name = "TabProfile"
        Me.TabProfile.Padding = New System.Windows.Forms.Padding(3)
        Me.TabProfile.Size = New System.Drawing.Size(426, 408)
        Me.TabProfile.TabIndex = 1
        Me.TabProfile.Text = "Profile"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.ProfilePath)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.ScriptPath)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 67)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(402, 105)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "User profile"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(20, 27)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(73, 23)
        Me.Label21.TabIndex = 104
        Me.Label21.Text = "Profile path:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ProfilePath
        '
        Me.ProfilePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProfilePath.Location = New System.Drawing.Point(97, 27)
        Me.ProfilePath.Name = "ProfilePath"
        Me.ProfilePath.Size = New System.Drawing.Size(290, 23)
        Me.ProfilePath.TabIndex = 102
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(17, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 23)
        Me.Label15.TabIndex = 101
        Me.Label15.Text = "Logon script:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ScriptPath
        '
        Me.ScriptPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScriptPath.Location = New System.Drawing.Point(97, 65)
        Me.ScriptPath.Name = "ScriptPath"
        Me.ScriptPath.Size = New System.Drawing.Size(290, 23)
        Me.ScriptPath.TabIndex = 23
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.homedrvR)
        Me.GroupBox1.Controls.Add(Me.HomeRemotePath)
        Me.GroupBox1.Controls.Add(Me.homedirL)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.homedirR)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.HomeLocalPath)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 180)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(405, 169)
        Me.GroupBox1.TabIndex = 28
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
        Me.homedrvR.Location = New System.Drawing.Point(105, 95)
        Me.homedrvR.Name = "homedrvR"
        Me.homedrvR.Size = New System.Drawing.Size(59, 23)
        Me.homedrvR.TabIndex = 31
        '
        'HomeRemotePath
        '
        Me.HomeRemotePath.AutoSize = True
        Me.HomeRemotePath.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HomeRemotePath.Location = New System.Drawing.Point(22, 65)
        Me.HomeRemotePath.Name = "HomeRemotePath"
        Me.HomeRemotePath.Size = New System.Drawing.Size(102, 20)
        Me.HomeRemotePath.TabIndex = 30
        Me.HomeRemotePath.TabStop = True
        Me.HomeRemotePath.Text = "Remote path:"
        Me.HomeRemotePath.UseVisualStyleBackColor = True
        '
        'homedirL
        '
        Me.homedirL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.homedirL.Enabled = False
        Me.homedirL.Location = New System.Drawing.Point(105, 29)
        Me.homedirL.Name = "homedirL"
        Me.homedirL.Size = New System.Drawing.Size(283, 23)
        Me.homedirL.TabIndex = 29
        '
        'Label17
        '
        Me.Label17.Enabled = False
        Me.Label17.Location = New System.Drawing.Point(68, 134)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 15)
        Me.Label17.TabIndex = 56
        Me.Label17.Text = "Path:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'homedirR
        '
        Me.homedirR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.homedirR.Enabled = False
        Me.homedirR.Location = New System.Drawing.Point(105, 131)
        Me.homedirR.Name = "homedirR"
        Me.homedirR.Size = New System.Drawing.Size(283, 23)
        Me.homedirR.TabIndex = 32
        '
        'Label16
        '
        Me.Label16.Enabled = False
        Me.Label16.Location = New System.Drawing.Point(65, 98)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 15)
        Me.Label16.TabIndex = 58
        Me.Label16.Text = "Drive:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HomeLocalPath
        '
        Me.HomeLocalPath.AutoSize = True
        Me.HomeLocalPath.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HomeLocalPath.Location = New System.Drawing.Point(22, 30)
        Me.HomeLocalPath.Name = "HomeLocalPath"
        Me.HomeLocalPath.Size = New System.Drawing.Size(89, 20)
        Me.HomeLocalPath.TabIndex = 28
        Me.HomeLocalPath.TabStop = True
        Me.HomeLocalPath.Text = "Local path:"
        Me.HomeLocalPath.UseVisualStyleBackColor = True
        '
        'TabGroups
        '
        Me.TabGroups.BackColor = System.Drawing.SystemColors.Control
        Me.TabGroups.Controls.Add(Me.GroupOK)
        Me.TabGroups.Controls.Add(Me.RmGroup)
        Me.TabGroups.Controls.Add(Me.AddToGrpBtn)
        Me.TabGroups.Controls.Add(Me.GroupMembership)
        Me.TabGroups.Location = New System.Drawing.Point(4, 24)
        Me.TabGroups.Name = "TabGroups"
        Me.TabGroups.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGroups.Size = New System.Drawing.Size(426, 408)
        Me.TabGroups.TabIndex = 2
        Me.TabGroups.Text = "Group membership"
        '
        'GroupOK
        '
        Me.GroupOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupOK.Location = New System.Drawing.Point(330, 366)
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
        Me.RmGroup.Location = New System.Drawing.Point(172, 366)
        Me.RmGroup.Name = "RmGroup"
        Me.RmGroup.Size = New System.Drawing.Size(154, 30)
        Me.RmGroup.TabIndex = 40
        Me.RmGroup.Text = "Remove membership"
        Me.RmGroup.UseVisualStyleBackColor = True
        '
        'AddToGrpBtn
        '
        Me.AddToGrpBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AddToGrpBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AddToGrpBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AddToGrpBtn.Location = New System.Drawing.Point(8, 366)
        Me.AddToGrpBtn.Name = "AddToGrpBtn"
        Me.AddToGrpBtn.Size = New System.Drawing.Size(158, 30)
        Me.AddToGrpBtn.TabIndex = 39
        Me.AddToGrpBtn.Text = "Add membership..."
        Me.AddToGrpBtn.UseVisualStyleBackColor = True
        '
        'GroupMembership
        '
        Me.GroupMembership.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupMembership.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.GroupMembership.Location = New System.Drawing.Point(8, 70)
        Me.GroupMembership.Name = "GroupMembership"
        Me.GroupMembership.ShowItemToolTips = True
        Me.GroupMembership.Size = New System.Drawing.Size(408, 285)
        Me.GroupMembership.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.GroupMembership.TabIndex = 38
        Me.GroupMembership.UseCompatibleStateImageBehavior = False
        Me.GroupMembership.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Groups"
        Me.ColumnHeader1.Width = 406
        '
        'UserLabel
        '
        Me.UserLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UserLabel.Location = New System.Drawing.Point(41, 9)
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(368, 39)
        Me.UserLabel.TabIndex = 15
        Me.UserLabel.Text = "User settings for"
        Me.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UserIcon
        '
        Me.UserIcon.Image = Global.lusrmgr.My.Resources.Resources.UserIcon
        Me.UserIcon.Location = New System.Drawing.Point(3, 9)
        Me.UserIcon.Name = "UserIcon"
        Me.UserIcon.Size = New System.Drawing.Size(38, 40)
        Me.UserIcon.TabIndex = 14
        Me.UserIcon.TabStop = False
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OkButton.Location = New System.Drawing.Point(125, 7)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(88, 29)
        Me.OkButton.TabIndex = 8
        Me.OkButton.Text = "OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CancelBtn.Location = New System.Drawing.Point(220, 7)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(88, 29)
        Me.CancelBtn.TabIndex = 9
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplyButton.Enabled = False
        Me.ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ApplyButton.Location = New System.Drawing.Point(315, 7)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(88, 29)
        Me.ApplyButton.TabIndex = 10
        Me.ApplyButton.Text = "Apply"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'UserMustChangePasswordInfo
        '
        Me.UserMustChangePasswordInfo.IsBalloon = True
        Me.UserMustChangePasswordInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.UserMustChangePasswordInfo.ToolTipTitle = "User must change password at next logon"
        '
        'BottomPanel
        '
        Me.BottomPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BottomPanel.Controls.Add(Me.ApplyButton)
        Me.BottomPanel.Controls.Add(Me.OkButton)
        Me.BottomPanel.Controls.Add(Me.CancelBtn)
        Me.BottomPanel.Location = New System.Drawing.Point(16, 382)
        Me.BottomPanel.Name = "BottomPanel"
        Me.BottomPanel.Size = New System.Drawing.Size(409, 43)
        Me.BottomPanel.TabIndex = 1
        '
        'TopPanel
        '
        Me.TopPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TopPanel.Controls.Add(Me.UserLabel)
        Me.TopPanel.Controls.Add(Me.UserIcon)
        Me.TopPanel.Location = New System.Drawing.Point(13, 30)
        Me.TopPanel.Name = "TopPanel"
        Me.TopPanel.Size = New System.Drawing.Size(415, 53)
        Me.TopPanel.TabIndex = 100
        '
        'EditUser
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CancelBtn
        Me.ClientSize = New System.Drawing.Size(434, 436)
        Me.Controls.Add(Me.BottomPanel)
        Me.Controls.Add(Me.TopPanel)
        Me.Controls.Add(Me.Tabs)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(450, 475)
        Me.Name = "EditUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EditUser"
        Me.Tabs.ResumeLayout(False)
        Me.TabGeneral.ResumeLayout(False)
        Me.TabGeneral.PerformLayout()
        Me.TabPassword.ResumeLayout(False)
        Me.TabPassword.PerformLayout()
        CType(Me.warnImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CopyContextMenu.ResumeLayout(False)
        Me.TabLogon.ResumeLayout(False)
        Me.TabLogon.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabProfile.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabGroups.ResumeLayout(False)
        CType(Me.UserIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BottomPanel.ResumeLayout(False)
        Me.TopPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tabs As System.Windows.Forms.TabControl
    Friend WithEvents TabGeneral As System.Windows.Forms.TabPage
    Friend WithEvents UserNameTextBox As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FullName As System.Windows.Forms.TextBox
    Friend WithEvents Comment As System.Windows.Forms.TextBox
    Friend WithEvents UserIcon As System.Windows.Forms.PictureBox
    Friend WithEvents TabProfile As System.Windows.Forms.TabPage
    Friend WithEvents TabGroups As System.Windows.Forms.TabPage
    Friend WithEvents GroupOK As System.Windows.Forms.Button
    Friend WithEvents RmGroup As System.Windows.Forms.Button
    Friend WithEvents AddToGrpBtn As System.Windows.Forms.Button
    Friend WithEvents GroupMembership As lusrmgr.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents UserLabel As System.Windows.Forms.Label
    Friend WithEvents TabLogon As System.Windows.Forms.TabPage
    Friend WithEvents failedtimes As System.Windows.Forms.Label
    Friend WithEvents lastlogon As System.Windows.Forms.Label
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents homedirR As System.Windows.Forms.TextBox
    Private WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents homedirL As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents homedrvR As System.Windows.Forms.ComboBox
    Friend WithEvents HomeRemotePath As System.Windows.Forms.RadioButton
    Friend WithEvents HomeLocalPath As System.Windows.Forms.RadioButton
    Friend WithEvents TabPassword As System.Windows.Forms.TabPage
    Friend WithEvents AccountExpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TimesBtn As System.Windows.Forms.Button
    Friend WithEvents AccountDisabled As System.Windows.Forms.CheckBox
    Friend WithEvents SmartcardRequired As System.Windows.Forms.CheckBox
    Friend WithEvents PwLastChanged As System.Windows.Forms.Label
    Private WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents UserCantChangePw As System.Windows.Forms.CheckBox
    Friend WithEvents SetPwButton As System.Windows.Forms.Button
    Friend WithEvents PwNeverExpires As System.Windows.Forms.CheckBox
    Friend WithEvents UserMustChangePwOnNextLogon As System.Windows.Forms.CheckBox
    Friend WithEvents PwNotRequired As System.Windows.Forms.CheckBox
    Private WithEvents UserMustChangePasswordInfo As System.Windows.Forms.ToolTip
    Friend WithEvents warnImg As System.Windows.Forms.PictureBox
    Friend WithEvents CopyContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents SID As System.Windows.Forms.TextBox
    Private WithEvents Label20 As System.Windows.Forms.Label
    Private WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents unlockbtn As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ProfilePath As System.Windows.Forms.TextBox
    Private WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ScriptPath As System.Windows.Forms.TextBox
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
    Friend WithEvents PwExpDate As System.Windows.Forms.Label
    Friend WithEvents AccountNeverExpires As System.Windows.Forms.CheckBox
    Friend WithEvents AccountExpTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BottomPanel As System.Windows.Forms.Panel
    Friend WithEvents TopPanel As System.Windows.Forms.Panel
    Friend WithEvents disabledInfo As lusrmgr.TransparentPanel
End Class
