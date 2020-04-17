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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.warnImg = New System.Windows.Forms.PictureBox()
        Me.pwnotrequired = New System.Windows.Forms.CheckBox()
        Me.pwrevencryption = New System.Windows.Forms.CheckBox()
        Me.pwchangenextlogon = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.pwcantchange = New System.Windows.Forms.CheckBox()
        Me.pwneverex = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.smartcardreq = New System.Windows.Forms.CheckBox()
        Me.accdisabled = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.homedrvR = New System.Windows.Forms.ComboBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.homedirL = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.homedirR = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.accexpireC = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.accexpireD = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.logonscript = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.errmsg = New System.Windows.Forms.Label()
        Me.errimg = New System.Windows.Forms.PictureBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.ListView1 = New lusrmgr.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Icons = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.warnImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.errimg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MoreOptions
        '
        Me.MoreOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MoreOptions.Location = New System.Drawing.Point(304, 266)
        Me.MoreOptions.Name = "MoreOptions"
        Me.MoreOptions.Size = New System.Drawing.Size(97, 29)
        Me.MoreOptions.TabIndex = 3
        Me.MoreOptions.Text = "Advanced >>"
        Me.MoreOptions.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Enabled = False
        Me.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OkButton.Location = New System.Drawing.Point(88, 266)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(97, 29)
        Me.OkButton.TabIndex = 5
        Me.OkButton.Text = "Create"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CloseButton.Location = New System.Drawing.Point(197, 266)
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
        Me.Label2.Location = New System.Drawing.Point(43, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 15)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Full name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Description:"
        '
        'FullName
        '
        Me.FullName.Location = New System.Drawing.Point(110, 102)
        Me.FullName.Name = "FullName"
        Me.FullName.Size = New System.Drawing.Size(291, 23)
        Me.FullName.TabIndex = 1
        '
        'Comment
        '
        Me.Comment.Location = New System.Drawing.Point(110, 146)
        Me.Comment.Multiline = True
        Me.Comment.Name = "Comment"
        Me.Comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Comment.Size = New System.Drawing.Size(291, 98)
        Me.Comment.TabIndex = 2
        '
        'UserLabel
        '
        Me.UserLabel.Location = New System.Drawing.Point(48, 10)
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(363, 39)
        Me.UserLabel.TabIndex = 12
        Me.UserLabel.Text = "Please enter the account details of the user:"
        Me.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(10, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.ToolTip1.ToolTipTitle = "Symbol not allowed"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox3)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox8)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox4)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox5)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox6)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox7)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(422, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(0, 314)
        Me.FlowLayoutPanel1.TabIndex = 32
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.warnImg)
        Me.GroupBox3.Controls.Add(Me.pwnotrequired)
        Me.GroupBox3.Controls.Add(Me.pwrevencryption)
        Me.GroupBox3.Controls.Add(Me.pwchangenextlogon)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.pwcantchange)
        Me.GroupBox3.Controls.Add(Me.pwneverex)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.TextBox4)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(383, 302)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Password"
        '
        'warnImg
        '
        Me.warnImg.Image = CType(resources.GetObject("warnImg.Image"), System.Drawing.Image)
        Me.warnImg.Location = New System.Drawing.Point(208, 148)
        Me.warnImg.Name = "warnImg"
        Me.warnImg.Size = New System.Drawing.Size(28, 27)
        Me.warnImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.warnImg.TabIndex = 124
        Me.warnImg.TabStop = False
        Me.warnImg.Visible = False
        '
        'pwnotrequired
        '
        Me.pwnotrequired.AutoSize = True
        Me.pwnotrequired.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.pwnotrequired.Location = New System.Drawing.Point(26, 267)
        Me.pwnotrequired.Name = "pwnotrequired"
        Me.pwnotrequired.Size = New System.Drawing.Size(150, 20)
        Me.pwnotrequired.TabIndex = 12
        Me.pwnotrequired.Text = "Password not required"
        Me.pwnotrequired.UseVisualStyleBackColor = True
        '
        'pwrevencryption
        '
        Me.pwrevencryption.AutoSize = True
        Me.pwrevencryption.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.pwrevencryption.Location = New System.Drawing.Point(26, 229)
        Me.pwrevencryption.Name = "pwrevencryption"
        Me.pwrevencryption.Size = New System.Drawing.Size(257, 20)
        Me.pwrevencryption.TabIndex = 11
        Me.pwrevencryption.Text = "Store password using reversible encryption"
        Me.pwrevencryption.UseVisualStyleBackColor = True
        '
        'pwchangenextlogon
        '
        Me.pwchangenextlogon.AutoSize = True
        Me.pwchangenextlogon.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.pwchangenextlogon.Location = New System.Drawing.Point(26, 114)
        Me.pwchangenextlogon.Name = "pwchangenextlogon"
        Me.pwchangenextlogon.Size = New System.Drawing.Size(344, 20)
        Me.pwchangenextlogon.TabIndex = 8
        Me.pwchangenextlogon.Text = "User must change password before logging in the first time"
        Me.pwchangenextlogon.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 15)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "Confirm password:"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(135, 66)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(235, 23)
        Me.TextBox3.TabIndex = 7
        Me.TextBox3.UseSystemPasswordChar = True
        '
        'pwcantchange
        '
        Me.pwcantchange.AutoSize = True
        Me.pwcantchange.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.pwcantchange.Location = New System.Drawing.Point(26, 152)
        Me.pwcantchange.Name = "pwcantchange"
        Me.pwcantchange.Size = New System.Drawing.Size(190, 20)
        Me.pwcantchange.TabIndex = 9
        Me.pwcantchange.Text = "User cannot change password"
        Me.pwcantchange.UseVisualStyleBackColor = True
        '
        'pwneverex
        '
        Me.pwneverex.AutoSize = True
        Me.pwneverex.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.pwneverex.Location = New System.Drawing.Point(26, 191)
        Me.pwneverex.Name = "pwneverex"
        Me.pwneverex.Size = New System.Drawing.Size(154, 20)
        Me.pwneverex.TabIndex = 10
        Me.pwneverex.Text = "Password never expires"
        Me.pwneverex.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(72, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 15)
        Me.Label5.TabIndex = 120
        Me.Label5.Text = "Password:"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(135, 26)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(235, 23)
        Me.TextBox4.TabIndex = 6
        Me.TextBox4.UseSystemPasswordChar = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Button9)
        Me.GroupBox8.Controls.Add(Me.smartcardreq)
        Me.GroupBox8.Controls.Add(Me.accdisabled)
        Me.GroupBox8.Location = New System.Drawing.Point(3, 311)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(383, 142)
        Me.GroupBox8.TabIndex = 7
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Logon"
        '
        'Button9
        '
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button9.Location = New System.Drawing.Point(26, 94)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(148, 33)
        Me.Button9.TabIndex = 15
        Me.Button9.Text = "Define access times..."
        Me.Button9.UseVisualStyleBackColor = True
        '
        'smartcardreq
        '
        Me.smartcardreq.AutoSize = True
        Me.smartcardreq.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.smartcardreq.Location = New System.Drawing.Point(27, 62)
        Me.smartcardreq.Name = "smartcardreq"
        Me.smartcardreq.Size = New System.Drawing.Size(221, 20)
        Me.smartcardreq.TabIndex = 14
        Me.smartcardreq.Text = "User has to logon using a smartcard"
        Me.smartcardreq.UseVisualStyleBackColor = True
        '
        'accdisabled
        '
        Me.accdisabled.AutoSize = True
        Me.accdisabled.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.accdisabled.Location = New System.Drawing.Point(27, 30)
        Me.accdisabled.Name = "accdisabled"
        Me.accdisabled.Size = New System.Drawing.Size(135, 20)
        Me.accdisabled.TabIndex = 13
        Me.accdisabled.Text = "Account is disabled"
        Me.accdisabled.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.homedrvR)
        Me.GroupBox4.Controls.Add(Me.RadioButton2)
        Me.GroupBox4.Controls.Add(Me.homedirL)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.homedirR)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.RadioButton1)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 459)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(383, 180)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Home folder"
        '
        'homedrvR
        '
        Me.homedrvR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.homedrvR.Enabled = False
        Me.homedrvR.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.homedrvR.FormattingEnabled = True
        Me.homedrvR.Items.AddRange(New Object() {"", "C:", "D:", "E:", "F:", "G:", "H:", "I:", "J:", "K:", "L:", "M:", "N:", "O:", "P:", "Q:", "R:", "S:", "T:", "U:", "V:", "W:", "X:", "Y:", "Z:"})
        Me.homedrvR.Location = New System.Drawing.Point(110, 100)
        Me.homedrvR.Name = "homedrvR"
        Me.homedrvR.Size = New System.Drawing.Size(59, 23)
        Me.homedrvR.TabIndex = 19
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RadioButton2.Location = New System.Drawing.Point(27, 68)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(102, 20)
        Me.RadioButton2.TabIndex = 18
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Remote path:"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'homedirL
        '
        Me.homedirL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.homedirL.Enabled = False
        Me.homedirL.Location = New System.Drawing.Point(110, 30)
        Me.homedirL.Name = "homedirL"
        Me.homedirL.Size = New System.Drawing.Size(260, 23)
        Me.homedirL.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Location = New System.Drawing.Point(73, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 15)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Path:"
        '
        'homedirR
        '
        Me.homedirR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.homedirR.Enabled = False
        Me.homedirR.Location = New System.Drawing.Point(110, 137)
        Me.homedirR.Name = "homedirR"
        Me.homedirR.Size = New System.Drawing.Size(260, 23)
        Me.homedirR.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Enabled = False
        Me.Label7.Location = New System.Drawing.Point(70, 103)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 15)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Drive:"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RadioButton1.Location = New System.Drawing.Point(27, 31)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(89, 20)
        Me.RadioButton1.TabIndex = 16
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Local path:"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.accexpireC)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.accexpireD)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 645)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(383, 90)
        Me.GroupBox5.TabIndex = 9
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Account expiration"
        '
        'accexpireC
        '
        Me.accexpireC.AutoSize = True
        Me.accexpireC.Checked = True
        Me.accexpireC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.accexpireC.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.accexpireC.Location = New System.Drawing.Point(156, 56)
        Me.accexpireC.Name = "accexpireC"
        Me.accexpireC.Size = New System.Drawing.Size(149, 20)
        Me.accexpireC.TabIndex = 22
        Me.accexpireC.Text = "Account never expires"
        Me.accexpireC.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(137, 15)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "Account expirarion date:"
        '
        'accexpireD
        '
        Me.accexpireD.Enabled = False
        Me.accexpireD.Location = New System.Drawing.Point(156, 24)
        Me.accexpireD.Name = "accexpireD"
        Me.accexpireD.Size = New System.Drawing.Size(214, 23)
        Me.accexpireD.TabIndex = 21
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.logonscript)
        Me.GroupBox6.Controls.Add(Me.Button6)
        Me.GroupBox6.Location = New System.Drawing.Point(3, 741)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(383, 65)
        Me.GroupBox6.TabIndex = 10
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Logon script"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 15)
        Me.Label9.TabIndex = 101
        Me.Label9.Text = "Path:"
        '
        'logonscript
        '
        Me.logonscript.Location = New System.Drawing.Point(57, 27)
        Me.logonscript.Name = "logonscript"
        Me.logonscript.Size = New System.Drawing.Size(270, 23)
        Me.logonscript.TabIndex = 23
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(333, 25)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 25)
        Me.Button6.TabIndex = 24
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.errmsg)
        Me.GroupBox7.Controls.Add(Me.errimg)
        Me.GroupBox7.Controls.Add(Me.Button7)
        Me.GroupBox7.Controls.Add(Me.Button8)
        Me.GroupBox7.Controls.Add(Me.ListView1)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 812)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(383, 240)
        Me.GroupBox7.TabIndex = 11
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Group membership"
        '
        'errmsg
        '
        Me.errmsg.AutoSize = True
        Me.errmsg.BackColor = System.Drawing.SystemColors.Window
        Me.errmsg.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.errmsg.Location = New System.Drawing.Point(105, 79)
        Me.errmsg.Name = "errmsg"
        Me.errmsg.Size = New System.Drawing.Size(227, 60)
        Me.errmsg.TabIndex = 17
        Me.errmsg.Text = "The account database for this computer" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "is still being retrieved, which may take " & _
    "a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "while. If finished, the user will be assigned" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to the user's group automatica" & _
    "lly."
        Me.errmsg.Visible = False
        '
        'errimg
        '
        Me.errimg.BackColor = System.Drawing.SystemColors.Window
        Me.errimg.Location = New System.Drawing.Point(64, 74)
        Me.errimg.Name = "errimg"
        Me.errimg.Size = New System.Drawing.Size(38, 65)
        Me.errimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.errimg.TabIndex = 16
        Me.errimg.TabStop = False
        Me.errimg.Visible = False
        '
        'Button7
        '
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button7.Enabled = False
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button7.Location = New System.Drawing.Point(198, 199)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(172, 27)
        Me.Button7.TabIndex = 27
        Me.Button7.Text = "Remove membership"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button8.Location = New System.Drawing.Point(19, 199)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(172, 27)
        Me.Button8.TabIndex = 26
        Me.Button8.Text = "Add to group"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.ListView1.Location = New System.Drawing.Point(19, 29)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.Size = New System.Drawing.Size(351, 160)
        Me.ListView1.SmallImageList = Me.Icons
        Me.ListView1.TabIndex = 25
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Group"
        Me.ColumnHeader3.Width = 347
        '
        'Icons
        '
        Me.Icons.ImageStream = CType(resources.GetObject("Icons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Icons.TransparentColor = System.Drawing.Color.Transparent
        Me.Icons.Images.SetKeyName(0, "group.ico")
        '
        'AddUser
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(422, 314)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.MoreOptions)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.UserNameTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FullName)
        Me.Controls.Add(Me.Comment)
        Me.Controls.Add(Me.UserLabel)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create new user"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.warnImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.errimg, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents pwnotrequired As System.Windows.Forms.CheckBox
    Friend WithEvents pwrevencryption As System.Windows.Forms.CheckBox
    Friend WithEvents pwchangenextlogon As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents pwcantchange As System.Windows.Forms.CheckBox
    Friend WithEvents pwneverex As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents smartcardreq As System.Windows.Forms.CheckBox
    Friend WithEvents accdisabled As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents homedrvR As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents homedirL As System.Windows.Forms.TextBox
    Private WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents homedirR As System.Windows.Forms.TextBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents accexpireC As System.Windows.Forms.CheckBox
    Private WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents accexpireD As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Private WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents logonscript As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents ListView1 As lusrmgr.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Icons As System.Windows.Forms.ImageList
    Friend WithEvents warnImg As System.Windows.Forms.PictureBox
    Friend WithEvents errmsg As System.Windows.Forms.Label
    Friend WithEvents errimg As System.Windows.Forms.PictureBox
End Class
