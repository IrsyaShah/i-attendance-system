<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.lblname = New System.Windows.Forms.Label()
        Me.lbllogin = New System.Windows.Forms.Label()
        Me.txtuname = New System.Windows.Forms.TextBox()
        Me.txtUserType = New System.Windows.Forms.TextBox()
        Me.lblEnter = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.chkPass = New System.Windows.Forms.CheckBox()
        Me.lblForgot = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.txtusername2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtpass = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.White
        Me.lblname.Location = New System.Drawing.Point(23, 435)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(0, 20)
        Me.lblname.TabIndex = 71
        '
        'lbllogin
        '
        Me.lbllogin.AutoSize = True
        Me.lbllogin.BackColor = System.Drawing.Color.Transparent
        Me.lbllogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllogin.ForeColor = System.Drawing.Color.White
        Me.lbllogin.Location = New System.Drawing.Point(51, 635)
        Me.lbllogin.Name = "lbllogin"
        Me.lbllogin.Size = New System.Drawing.Size(44, 20)
        Me.lbllogin.TabIndex = 69
        Me.lbllogin.Text = "login"
        '
        'txtuname
        '
        Me.txtuname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuname.Location = New System.Drawing.Point(27, 598)
        Me.txtuname.Name = "txtuname"
        Me.txtuname.Size = New System.Drawing.Size(260, 26)
        Me.txtuname.TabIndex = 1
        '
        'txtUserType
        '
        Me.txtUserType.Location = New System.Drawing.Point(116, 659)
        Me.txtUserType.Name = "txtUserType"
        Me.txtUserType.Size = New System.Drawing.Size(171, 20)
        Me.txtUserType.TabIndex = 76
        Me.txtUserType.Visible = False
        '
        'lblEnter
        '
        Me.lblEnter.AutoSize = True
        Me.lblEnter.BackColor = System.Drawing.Color.Transparent
        Me.lblEnter.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnter.Location = New System.Drawing.Point(180, 112)
        Me.lblEnter.Name = "lblEnter"
        Me.lblEnter.Size = New System.Drawing.Size(253, 18)
        Me.lblEnter.TabIndex = 77
        Me.lblEnter.Text = "Please enter your Username and Password"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Constantia", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTitle.Location = New System.Drawing.Point(176, 57)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(388, 42)
        Me.lblTitle.TabIndex = 78
        Me.lblTitle.Text = "Sign in to your account"
        '
        'chkPass
        '
        Me.chkPass.AutoSize = True
        Me.chkPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPass.Location = New System.Drawing.Point(427, 247)
        Me.chkPass.Name = "chkPass"
        Me.chkPass.Size = New System.Drawing.Size(15, 14)
        Me.chkPass.TabIndex = 79
        Me.chkPass.UseVisualStyleBackColor = True
        '
        'lblForgot
        '
        Me.lblForgot.AutoSize = True
        Me.lblForgot.BackColor = System.Drawing.Color.Transparent
        Me.lblForgot.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblForgot.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForgot.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblForgot.Location = New System.Drawing.Point(198, 354)
        Me.lblForgot.Name = "lblForgot"
        Me.lblForgot.Size = New System.Drawing.Size(95, 16)
        Me.lblForgot.TabIndex = 80
        Me.lblForgot.Text = "Forgot Password?"
        '
        'Timer1
        '
        Me.Timer1.Interval = 30000
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_HOR_POSITIVE
        Me.Guna2BorderlessForm1.BorderRadius = 20
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'txtusername2
        '
        Me.txtusername2.Animated = True
        Me.txtusername2.AutoRoundedCorners = True
        Me.txtusername2.BorderColor = System.Drawing.Color.Gray
        Me.txtusername2.BorderRadius = 17
        Me.txtusername2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtusername2.DefaultText = ""
        Me.txtusername2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtusername2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtusername2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtusername2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtusername2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtusername2.Font = New System.Drawing.Font("Franklin Gothic Book", 11.25!)
        Me.txtusername2.ForeColor = System.Drawing.Color.Black
        Me.txtusername2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtusername2.Location = New System.Drawing.Point(201, 175)
        Me.txtusername2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtusername2.Name = "txtusername2"
        Me.txtusername2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtusername2.PlaceholderForeColor = System.Drawing.Color.Silver
        Me.txtusername2.PlaceholderText = "Username"
        Me.txtusername2.SelectedText = ""
        Me.txtusername2.Size = New System.Drawing.Size(220, 36)
        Me.txtusername2.TabIndex = 81
        '
        'txtpass
        '
        Me.txtpass.Animated = True
        Me.txtpass.AutoRoundedCorners = True
        Me.txtpass.BorderColor = System.Drawing.Color.Gray
        Me.txtpass.BorderRadius = 17
        Me.txtpass.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtpass.DefaultText = ""
        Me.txtpass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtpass.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtpass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtpass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtpass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtpass.Font = New System.Drawing.Font("Franklin Gothic Book", 11.25!)
        Me.txtpass.ForeColor = System.Drawing.Color.Black
        Me.txtpass.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtpass.Location = New System.Drawing.Point(201, 234)
        Me.txtpass.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpass.PlaceholderForeColor = System.Drawing.Color.Silver
        Me.txtpass.PlaceholderText = "Password"
        Me.txtpass.SelectedText = ""
        Me.txtpass.Size = New System.Drawing.Size(220, 36)
        Me.txtpass.TabIndex = 82
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLogin.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnLogin.Location = New System.Drawing.Point(201, 295)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(220, 47)
        Me.btnLogin.TabIndex = 77
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Linen
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Image = Global.BiometricFingerprintStudentAttendanceSystemVB.My.Resources.Resources.try4
        Me.Label9.Location = New System.Drawing.Point(957, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 18)
        Me.Label9.TabIndex = 408
        Me.Label9.Text = "X"
        '
        'Login
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.BiometricFingerprintStudentAttendanceSystemVB.My.Resources.Resources.wallpaper1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(987, 597)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtpass)
        Me.Controls.Add(Me.txtusername2)
        Me.Controls.Add(Me.lblForgot)
        Me.Controls.Add(Me.chkPass)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblEnter)
        Me.Controls.Add(Me.txtUserType)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtuname)
        Me.Controls.Add(Me.lblname)
        Me.Controls.Add(Me.lbllogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saint International School - Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblname As Label
    Friend WithEvents lbllogin As Label
    Friend WithEvents txtuname As TextBox
    Friend WithEvents lblEnter As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents chkPass As CheckBox
    Friend WithEvents lblForgot As Label
    Public WithEvents txtUserType As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents txtusername2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtpass As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents Label9 As Label
End Class
