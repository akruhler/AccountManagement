<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddUser))
        Me.MoreOptions = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.UserNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FullName = New System.Windows.Forms.TextBox()
        Me.Comment = New System.Windows.Forms.TextBox()
        Me.UserLabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SymbolDisallowedTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.TimesBtn = New System.Windows.Forms.Button()
        Me.SmartcardRequired = New System.Windows.Forms.CheckBox()
        Me.AccountDisabled = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.AccountExpDate = New System.Windows.Forms.DateTimePicker()
        Me.AccountNeverExpires = New System.Windows.Forms.CheckBox()
        Me.AccountExpTime = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.homedrvR = New System.Windows.Forms.ComboBox()
        Me.HomeRemotePath = New System.Windows.Forms.RadioButton()
        Me.homedirL = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.homedirR = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.HomeLocalPath = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ProfilePath = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ScriptPath = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.RmGroup = New System.Windows.Forms.Button()
        Me.AddToGrpBtn = New System.Windows.Forms.Button()
        Me.GroupMembership = New lusrmgr.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.warnImg = New System.Windows.Forms.PictureBox()
        Me.PwNotRequired = New System.Windows.Forms.CheckBox()
        Me.UserMustChangePwOnNextLogon = New System.Windows.Forms.CheckBox()
        Me.UserCantChangePw = New System.Windows.Forms.CheckBox()
        Me.PwNeverExpires = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PasswordConfirm = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.warnImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MoreOptions
        '
        Me.MoreOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MoreOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MoreOptions.Location = New System.Drawing.Point(311, 429)
        Me.MoreOptions.Name = "MoreOptions"
        Me.MoreOptions.Size = New System.Drawing.Size(97, 29)
        Me.MoreOptions.TabIndex = 3
        Me.MoreOptions.Text = "Advanced >>"
        Me.MoreOptions.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Enabled = False
        Me.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OkButton.Location = New System.Drawing.Point(103, 429)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(97, 29)
        Me.OkButton.TabIndex = 5
        Me.OkButton.Text = "Create"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CloseButton.Location = New System.Drawing.Point(207, 429)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(97, 29)
        Me.CloseButton.TabIndex = 4
        Me.CloseButton.Text = "Cancel"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'UserNameTextBox
        '
        Me.UserNameTextBox.Location = New System.Drawing.Point(110, 62)
        Me.UserNameTextBox.MaxLength = 20
        Me.UserNameTextBox.Name = "UserNameTextBox"
        Me.UserNameTextBox.Size = New System.Drawing.Size(291, 23)
        Me.UserNameTextBox.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 15)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Username:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 15)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Full name:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Description:"
        '
        'FullName
        '
        Me.FullName.Location = New System.Drawing.Point(110, 97)
        Me.FullName.Name = "FullName"
        Me.FullName.Size = New System.Drawing.Size(291, 23)
        Me.FullName.TabIndex = 1
        '
        'Comment
        '
        Me.Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Comment.Location = New System.Drawing.Point(110, 136)
        Me.Comment.Multiline = True
        Me.Comment.Name = "Comment"
        Me.Comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Comment.Size = New System.Drawing.Size(291, 51)
        Me.Comment.TabIndex = 2
        '
        'UserLabel
        '
        Me.UserLabel.Location = New System.Drawing.Point(48, 10)
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(363, 39)
        Me.UserLabel.TabIndex = 12
        Me.UserLabel.Text = "Create new user on "
        Me.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.lusrmgr.My.Resources.Resources.UserIcon
        Me.PictureBox1.Location = New System.Drawing.Point(10, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'SymbolDisallowedTooltip
        '
        Me.SymbolDisallowedTooltip.IsBalloon = True
        Me.SymbolDisallowedTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.SymbolDisallowedTooltip.ToolTipTitle = "Symbol not allowed"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox8)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox3)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox2)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox7)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(422, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(0, 473)
        Me.FlowLayoutPanel1.TabIndex = 32
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.TimesBtn)
        Me.GroupBox8.Controls.Add(Me.SmartcardRequired)
        Me.GroupBox8.Controls.Add(Me.AccountDisabled)
        Me.GroupBox8.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(383, 130)
        Me.GroupBox8.TabIndex = 7
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Account"
        '
        'TimesBtn
        '
        Me.TimesBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TimesBtn.Location = New System.Drawing.Point(27, 82)
        Me.TimesBtn.Name = "TimesBtn"
        Me.TimesBtn.Size = New System.Drawing.Size(148, 33)
        Me.TimesBtn.TabIndex = 15
        Me.TimesBtn.Text = "Define access times..."
        Me.TimesBtn.UseVisualStyleBackColor = True
        '
        'SmartcardRequired
        '
        Me.SmartcardRequired.AutoSize = True
        Me.SmartcardRequired.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SmartcardRequired.Location = New System.Drawing.Point(27, 54)
        Me.SmartcardRequired.Name = "SmartcardRequired"
        Me.SmartcardRequired.Size = New System.Drawing.Size(221, 20)
        Me.SmartcardRequired.TabIndex = 14
        Me.SmartcardRequired.Text = "User has to logon using a smartcard"
        Me.SmartcardRequired.UseVisualStyleBackColor = True
        '
        'AccountDisabled
        '
        Me.AccountDisabled.AutoSize = True
        Me.AccountDisabled.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AccountDisabled.Location = New System.Drawing.Point(27, 25)
        Me.AccountDisabled.Name = "AccountDisabled"
        Me.AccountDisabled.Size = New System.Drawing.Size(135, 20)
        Me.AccountDisabled.TabIndex = 13
        Me.AccountDisabled.Text = "Account is disabled"
        Me.AccountDisabled.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.AccountExpDate)
        Me.GroupBox3.Controls.Add(Me.AccountNeverExpires)
        Me.GroupBox3.Controls.Add(Me.AccountExpTime)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 139)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(383, 90)
        Me.GroupBox3.TabIndex = 104
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Account expirarion date"
        '
        'AccountExpDate
        '
        Me.AccountExpDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AccountExpDate.CustomFormat = ""
        Me.AccountExpDate.Enabled = False
        Me.AccountExpDate.Location = New System.Drawing.Point(19, 28)
        Me.AccountExpDate.Name = "AccountExpDate"
        Me.AccountExpDate.Size = New System.Drawing.Size(259, 23)
        Me.AccountExpDate.TabIndex = 18
        '
        'AccountNeverExpires
        '
        Me.AccountNeverExpires.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AccountNeverExpires.AutoSize = True
        Me.AccountNeverExpires.Checked = True
        Me.AccountNeverExpires.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AccountNeverExpires.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AccountNeverExpires.Location = New System.Drawing.Point(19, 58)
        Me.AccountNeverExpires.Name = "AccountNeverExpires"
        Me.AccountNeverExpires.Size = New System.Drawing.Size(149, 20)
        Me.AccountNeverExpires.TabIndex = 101
        Me.AccountNeverExpires.Text = "Account never expires"
        Me.AccountNeverExpires.UseVisualStyleBackColor = True
        '
        'AccountExpTime
        '
        Me.AccountExpTime.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AccountExpTime.CustomFormat = ""
        Me.AccountExpTime.Enabled = False
        Me.AccountExpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.AccountExpTime.Location = New System.Drawing.Point(284, 28)
        Me.AccountExpTime.Name = "AccountExpTime"
        Me.AccountExpTime.ShowUpDown = True
        Me.AccountExpTime.Size = New System.Drawing.Size(86, 23)
        Me.AccountExpTime.TabIndex = 102
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.homedrvR)
        Me.GroupBox1.Controls.Add(Me.HomeRemotePath)
        Me.GroupBox1.Controls.Add(Me.homedirL)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.homedirR)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.HomeLocalPath)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 235)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(383, 169)
        Me.GroupBox1.TabIndex = 80
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
        Me.homedirL.Enabled = False
        Me.homedirL.Location = New System.Drawing.Point(105, 29)
        Me.homedirL.Name = "homedirL"
        Me.homedirL.Size = New System.Drawing.Size(265, 23)
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
        Me.homedirR.Enabled = False
        Me.homedirR.Location = New System.Drawing.Point(105, 131)
        Me.homedirR.Name = "homedirR"
        Me.homedirR.Size = New System.Drawing.Size(265, 23)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.ProfilePath)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.ScriptPath)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 410)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(383, 105)
        Me.GroupBox2.TabIndex = 39
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "User profile"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(10, 28)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(73, 23)
        Me.Label21.TabIndex = 104
        Me.Label21.Text = "Profile path:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ProfilePath
        '
        Me.ProfilePath.Location = New System.Drawing.Point(89, 27)
        Me.ProfilePath.Name = "ProfilePath"
        Me.ProfilePath.Size = New System.Drawing.Size(281, 23)
        Me.ProfilePath.TabIndex = 102
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(10, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 23)
        Me.Label15.TabIndex = 101
        Me.Label15.Text = "Logon script:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ScriptPath
        '
        Me.ScriptPath.Location = New System.Drawing.Point(89, 65)
        Me.ScriptPath.Name = "ScriptPath"
        Me.ScriptPath.Size = New System.Drawing.Size(281, 23)
        Me.ScriptPath.TabIndex = 23
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.RmGroup)
        Me.GroupBox7.Controls.Add(Me.AddToGrpBtn)
        Me.GroupBox7.Controls.Add(Me.GroupMembership)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 521)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(383, 299)
        Me.GroupBox7.TabIndex = 11
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Group membership"
        '
        'RmGroup
        '
        Me.RmGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RmGroup.Enabled = False
        Me.RmGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RmGroup.Location = New System.Drawing.Point(197, 259)
        Me.RmGroup.Name = "RmGroup"
        Me.RmGroup.Size = New System.Drawing.Size(172, 27)
        Me.RmGroup.TabIndex = 27
        Me.RmGroup.Text = "Remove from group"
        Me.RmGroup.UseVisualStyleBackColor = True
        '
        'AddToGrpBtn
        '
        Me.AddToGrpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.AddToGrpBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AddToGrpBtn.Location = New System.Drawing.Point(14, 259)
        Me.AddToGrpBtn.Name = "AddToGrpBtn"
        Me.AddToGrpBtn.Size = New System.Drawing.Size(172, 27)
        Me.AddToGrpBtn.TabIndex = 26
        Me.AddToGrpBtn.Text = "Add to group..."
        Me.AddToGrpBtn.UseVisualStyleBackColor = True
        '
        'GroupMembership
        '
        Me.GroupMembership.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.GroupMembership.Location = New System.Drawing.Point(15, 29)
        Me.GroupMembership.Name = "GroupMembership"
        Me.GroupMembership.ShowItemToolTips = True
        Me.GroupMembership.Size = New System.Drawing.Size(354, 219)
        Me.GroupMembership.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.GroupMembership.TabIndex = 25
        Me.GroupMembership.UseCompatibleStateImageBehavior = False
        Me.GroupMembership.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Groups"
        Me.ColumnHeader3.Width = 350
        '
        'warnImg
        '
        Me.warnImg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.warnImg.Image = Global.lusrmgr.My.Resources.Resources.Warning
        Me.warnImg.Location = New System.Drawing.Point(199, 327)
        Me.warnImg.Name = "warnImg"
        Me.warnImg.Size = New System.Drawing.Size(16, 16)
        Me.warnImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.warnImg.TabIndex = 124
        Me.warnImg.TabStop = False
        Me.warnImg.Visible = False
        '
        'PwNotRequired
        '
        Me.PwNotRequired.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PwNotRequired.AutoSize = True
        Me.PwNotRequired.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PwNotRequired.Location = New System.Drawing.Point(17, 388)
        Me.PwNotRequired.Name = "PwNotRequired"
        Me.PwNotRequired.Size = New System.Drawing.Size(150, 20)
        Me.PwNotRequired.TabIndex = 12
        Me.PwNotRequired.Text = "Password not required"
        Me.PwNotRequired.UseVisualStyleBackColor = True
        '
        'UserMustChangePwOnNextLogon
        '
        Me.UserMustChangePwOnNextLogon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.UserMustChangePwOnNextLogon.AutoSize = True
        Me.UserMustChangePwOnNextLogon.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.UserMustChangePwOnNextLogon.Location = New System.Drawing.Point(17, 295)
        Me.UserMustChangePwOnNextLogon.Name = "UserMustChangePwOnNextLogon"
        Me.UserMustChangePwOnNextLogon.Size = New System.Drawing.Size(253, 20)
        Me.UserMustChangePwOnNextLogon.TabIndex = 8
        Me.UserMustChangePwOnNextLogon.Text = "User must change password at next logon"
        Me.UserMustChangePwOnNextLogon.UseVisualStyleBackColor = True
        '
        'UserCantChangePw
        '
        Me.UserCantChangePw.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.UserCantChangePw.AutoSize = True
        Me.UserCantChangePw.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.UserCantChangePw.Location = New System.Drawing.Point(17, 326)
        Me.UserCantChangePw.Name = "UserCantChangePw"
        Me.UserCantChangePw.Size = New System.Drawing.Size(190, 20)
        Me.UserCantChangePw.TabIndex = 9
        Me.UserCantChangePw.Text = "User cannot change password"
        Me.UserCantChangePw.UseVisualStyleBackColor = True
        '
        'PwNeverExpires
        '
        Me.PwNeverExpires.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PwNeverExpires.AutoSize = True
        Me.PwNeverExpires.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PwNeverExpires.Location = New System.Drawing.Point(17, 357)
        Me.PwNeverExpires.Name = "PwNeverExpires"
        Me.PwNeverExpires.Size = New System.Drawing.Size(154, 20)
        Me.PwNeverExpires.TabIndex = 10
        Me.PwNeverExpires.Text = "Password never expires"
        Me.PwNeverExpires.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Location = New System.Drawing.Point(13, 202)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(388, 2)
        Me.Label13.TabIndex = 100
        '
        'Password
        '
        Me.Password.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Password.Location = New System.Drawing.Point(127, 218)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(274, 23)
        Me.Password.TabIndex = 6
        Me.Password.UseSystemPasswordChar = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(62, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 15)
        Me.Label5.TabIndex = 120
        Me.Label5.Text = "Password:"
        '
        'PasswordConfirm
        '
        Me.PasswordConfirm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PasswordConfirm.Location = New System.Drawing.Point(127, 253)
        Me.PasswordConfirm.Name = "PasswordConfirm"
        Me.PasswordConfirm.Size = New System.Drawing.Size(274, 23)
        Me.PasswordConfirm.TabIndex = 7
        Me.PasswordConfirm.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 256)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 15)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "Confirm password:"
        '
        'AddUser
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(422, 475)
        Me.Controls.Add(Me.warnImg)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PwNotRequired)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.UserMustChangePwOnNextLogon)
        Me.Controls.Add(Me.UserCantChangePw)
        Me.Controls.Add(Me.MoreOptions)
        Me.Controls.Add(Me.PwNeverExpires)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.PasswordConfirm)
        Me.Controls.Add(Me.UserNameTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FullName)
        Me.Controls.Add(Me.Comment)
        Me.Controls.Add(Me.UserLabel)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "AddUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create new user"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.warnImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MoreOptions As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents UserNameTextBox As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FullName As System.Windows.Forms.TextBox
    Friend WithEvents Comment As System.Windows.Forms.TextBox
    Private WithEvents UserLabel As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents SymbolDisallowedTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents PwNotRequired As System.Windows.Forms.CheckBox
    Friend WithEvents UserMustChangePwOnNextLogon As System.Windows.Forms.CheckBox
    Friend WithEvents UserCantChangePw As System.Windows.Forms.CheckBox
    Friend WithEvents PwNeverExpires As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents TimesBtn As System.Windows.Forms.Button
    Friend WithEvents SmartcardRequired As System.Windows.Forms.CheckBox
    Friend WithEvents AccountDisabled As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents RmGroup As System.Windows.Forms.Button
    Friend WithEvents AddToGrpBtn As System.Windows.Forms.Button
    Friend WithEvents GroupMembership As lusrmgr.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents warnImg As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Password As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PasswordConfirm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ProfilePath As System.Windows.Forms.TextBox
    Private WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ScriptPath As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents homedrvR As System.Windows.Forms.ComboBox
    Friend WithEvents HomeRemotePath As System.Windows.Forms.RadioButton
    Friend WithEvents homedirL As System.Windows.Forms.TextBox
    Private WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents homedirR As System.Windows.Forms.TextBox
    Private WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents HomeLocalPath As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents AccountExpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents AccountNeverExpires As System.Windows.Forms.CheckBox
    Friend WithEvents AccountExpTime As System.Windows.Forms.DateTimePicker
End Class
