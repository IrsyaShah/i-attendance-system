<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Teacher
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Teacher))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblUserType = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.menuStrip3 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintAttendanceReportToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportStudentAttendanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintStudentAttendanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddStudentProfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnrollStudentFingerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AttendanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimeInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimeOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentProfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AttendanceReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddStaffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer5 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.menuStrip3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Wheat
        Me.Panel3.Controls.Add(Me.lblWelcome)
        Me.Panel3.Controls.Add(Me.lblDateTime)
        Me.Panel3.Location = New System.Drawing.Point(173, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(814, 57)
        Me.Panel3.TabIndex = 30
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.Location = New System.Drawing.Point(18, 15)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(91, 25)
        Me.lblWelcome.TabIndex = 26
        Me.lblWelcome.Text = "Welcome"
        '
        'lblDateTime
        '
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Font = New System.Drawing.Font("Nirmala UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.Location = New System.Drawing.Point(626, 17)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(82, 21)
        Me.lblDateTime.TabIndex = 24
        Me.lblDateTime.Text = "Date/Time"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PowderBlue
        Me.Panel1.Controls.Add(Me.lblUserType)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Location = New System.Drawing.Point(0, 174)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(173, 56)
        Me.Panel1.TabIndex = 29
        '
        'lblUserType
        '
        Me.lblUserType.AutoSize = True
        Me.lblUserType.Font = New System.Drawing.Font("Myanmar Text", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserType.Location = New System.Drawing.Point(60, 29)
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(59, 21)
        Me.lblUserType.TabIndex = 26
        Me.lblUserType.Text = "UserType"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Bookman Old Style", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(60, 9)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(54, 20)
        Me.lblName.TabIndex = 22
        Me.lblName.Text = "Name"
        '
        'menuStrip3
        '
        Me.menuStrip3.AllowItemReorder = True
        Me.menuStrip3.AutoSize = False
        Me.menuStrip3.BackColor = System.Drawing.Color.CadetBlue
        Me.menuStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.menuStrip3.Dock = System.Windows.Forms.DockStyle.Left
        Me.menuStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.FileToolStripMenuItem1, Me.StudentToolStripMenuItem, Me.AttendanceToolStripMenuItem, Me.ViewToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.SettingToolStripMenuItem})
        Me.menuStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.menuStrip3.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip3.Name = "menuStrip3"
        Me.menuStrip3.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.menuStrip3.Size = New System.Drawing.Size(173, 597)
        Me.menuStrip3.TabIndex = 27
        Me.menuStrip3.Text = "menuStrip3"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.FileToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintAttendanceReportToolStripMenuItem1, Me.ExportToolStripMenuItem})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.FileToolStripMenuItem.Margin = New System.Windows.Forms.Padding(6, 238, 0, 0)
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(12, 4)
        '
        'PrintAttendanceReportToolStripMenuItem1
        '
        Me.PrintAttendanceReportToolStripMenuItem1.BackColor = System.Drawing.Color.MediumAquamarine
        Me.PrintAttendanceReportToolStripMenuItem1.Name = "PrintAttendanceReportToolStripMenuItem1"
        Me.PrintAttendanceReportToolStripMenuItem1.Size = New System.Drawing.Size(242, 26)
        Me.PrintAttendanceReportToolStripMenuItem1.Text = "Print Attendance Report"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.BackColor = System.Drawing.Color.MediumAquamarine
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(242, 26)
        Me.ExportToolStripMenuItem.Text = "Export Student Profile"
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportStudentAttendanceToolStripMenuItem, Me.PrintStudentAttendanceToolStripMenuItem})
        Me.FileToolStripMenuItem1.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileToolStripMenuItem1.Image = Global.BiometricFingerprintStudentAttendanceSystemVB.My.Resources.Resources.file
        Me.FileToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.FileToolStripMenuItem1.Margin = New System.Windows.Forms.Padding(8, 20, 0, 0)
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(94, 52)
        Me.FileToolStripMenuItem1.Text = "File"
        '
        'ExportStudentAttendanceToolStripMenuItem
        '
        Me.ExportStudentAttendanceToolStripMenuItem.BackColor = System.Drawing.Color.MediumAquamarine
        Me.ExportStudentAttendanceToolStripMenuItem.Name = "ExportStudentAttendanceToolStripMenuItem"
        Me.ExportStudentAttendanceToolStripMenuItem.Size = New System.Drawing.Size(262, 26)
        Me.ExportStudentAttendanceToolStripMenuItem.Text = "Export Student Attendance"
        '
        'PrintStudentAttendanceToolStripMenuItem
        '
        Me.PrintStudentAttendanceToolStripMenuItem.BackColor = System.Drawing.Color.MediumAquamarine
        Me.PrintStudentAttendanceToolStripMenuItem.Name = "PrintStudentAttendanceToolStripMenuItem"
        Me.PrintStudentAttendanceToolStripMenuItem.Size = New System.Drawing.Size(262, 26)
        Me.PrintStudentAttendanceToolStripMenuItem.Text = "Print Student Attendance"
        '
        'StudentToolStripMenuItem
        '
        Me.StudentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddStudentProfileToolStripMenuItem, Me.EnrollStudentFingerToolStripMenuItem})
        Me.StudentToolStripMenuItem.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StudentToolStripMenuItem.Image = CType(resources.GetObject("StudentToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StudentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.StudentToolStripMenuItem.Margin = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.StudentToolStripMenuItem.Name = "StudentToolStripMenuItem"
        Me.StudentToolStripMenuItem.Size = New System.Drawing.Size(124, 52)
        Me.StudentToolStripMenuItem.Text = "Student"
        '
        'AddStudentProfileToolStripMenuItem
        '
        Me.AddStudentProfileToolStripMenuItem.BackColor = System.Drawing.Color.Turquoise
        Me.AddStudentProfileToolStripMenuItem.Name = "AddStudentProfileToolStripMenuItem"
        Me.AddStudentProfileToolStripMenuItem.Size = New System.Drawing.Size(223, 26)
        Me.AddStudentProfileToolStripMenuItem.Text = "Add Student Profile"
        '
        'EnrollStudentFingerToolStripMenuItem
        '
        Me.EnrollStudentFingerToolStripMenuItem.BackColor = System.Drawing.Color.Turquoise
        Me.EnrollStudentFingerToolStripMenuItem.Name = "EnrollStudentFingerToolStripMenuItem"
        Me.EnrollStudentFingerToolStripMenuItem.Size = New System.Drawing.Size(223, 26)
        Me.EnrollStudentFingerToolStripMenuItem.Text = "Enroll Student Finger"
        '
        'AttendanceToolStripMenuItem
        '
        Me.AttendanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TimeInToolStripMenuItem, Me.TimeOutToolStripMenuItem})
        Me.AttendanceToolStripMenuItem.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AttendanceToolStripMenuItem.Image = Global.BiometricFingerprintStudentAttendanceSystemVB.My.Resources.Resources.attendance
        Me.AttendanceToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AttendanceToolStripMenuItem.Margin = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.AttendanceToolStripMenuItem.Name = "AttendanceToolStripMenuItem"
        Me.AttendanceToolStripMenuItem.Size = New System.Drawing.Size(147, 52)
        Me.AttendanceToolStripMenuItem.Text = "Attendance"
        '
        'TimeInToolStripMenuItem
        '
        Me.TimeInToolStripMenuItem.BackColor = System.Drawing.Color.PowderBlue
        Me.TimeInToolStripMenuItem.Name = "TimeInToolStripMenuItem"
        Me.TimeInToolStripMenuItem.Size = New System.Drawing.Size(151, 26)
        Me.TimeInToolStripMenuItem.Text = "Start Class"
        '
        'TimeOutToolStripMenuItem
        '
        Me.TimeOutToolStripMenuItem.BackColor = System.Drawing.Color.PowderBlue
        Me.TimeOutToolStripMenuItem.Name = "TimeOutToolStripMenuItem"
        Me.TimeOutToolStripMenuItem.Size = New System.Drawing.Size(151, 26)
        Me.TimeOutToolStripMenuItem.Text = "End Class"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StudentProfileToolStripMenuItem, Me.AttendanceReportToolStripMenuItem})
        Me.ViewToolStripMenuItem.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ViewToolStripMenuItem.Margin = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(12, 4)
        '
        'StudentProfileToolStripMenuItem
        '
        Me.StudentProfileToolStripMenuItem.BackColor = System.Drawing.Color.LightSteelBlue
        Me.StudentProfileToolStripMenuItem.Name = "StudentProfileToolStripMenuItem"
        Me.StudentProfileToolStripMenuItem.Size = New System.Drawing.Size(206, 26)
        Me.StudentProfileToolStripMenuItem.Text = "Student Profile"
        '
        'AttendanceReportToolStripMenuItem
        '
        Me.AttendanceReportToolStripMenuItem.BackColor = System.Drawing.Color.LightSteelBlue
        Me.AttendanceReportToolStripMenuItem.Name = "AttendanceReportToolStripMenuItem"
        Me.AttendanceReportToolStripMenuItem.Size = New System.Drawing.Size(206, 26)
        Me.AttendanceReportToolStripMenuItem.Text = "Attendance Report"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddStaffToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SettingsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SettingsToolStripMenuItem.Margin = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(12, 4)
        '
        'AddStaffToolStripMenuItem
        '
        Me.AddStaffToolStripMenuItem.BackColor = System.Drawing.Color.CornflowerBlue
        Me.AddStaffToolStripMenuItem.Name = "AddStaffToolStripMenuItem"
        Me.AddStaffToolStripMenuItem.Size = New System.Drawing.Size(141, 26)
        Me.AddStaffToolStripMenuItem.Text = "Add User"
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PasswordToolStripMenuItem})
        Me.SettingToolStripMenuItem.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SettingToolStripMenuItem.Image = Global.BiometricFingerprintStudentAttendanceSystemVB.My.Resources.Resources.ezgif_com_gif_maker__1__removebg_preview
        Me.SettingToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SettingToolStripMenuItem.Margin = New System.Windows.Forms.Padding(5, -9, 0, 0)
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(124, 52)
        Me.SettingToolStripMenuItem.Text = "Account"
        '
        'PasswordToolStripMenuItem
        '
        Me.PasswordToolStripMenuItem.BackColor = System.Drawing.Color.SteelBlue
        Me.PasswordToolStripMenuItem.Name = "PasswordToolStripMenuItem"
        Me.PasswordToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.PasswordToolStripMenuItem.Text = "Change Password"
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1000
        '
        'Timer3
        '
        Me.Timer3.Enabled = True
        Me.Timer3.Interval = 2000
        '
        'Timer4
        '
        Me.Timer4.Interval = 1000
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.BiometricFingerprintStudentAttendanceSystemVB.My.Resources.Resources.animated_illustration_for_web
        Me.PictureBox2.Location = New System.Drawing.Point(173, 57)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(814, 540)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 34
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.CadetBlue
        Me.PictureBox1.Image = Global.BiometricFingerprintStudentAttendanceSystemVB.My.Resources.Resources._2
        Me.PictureBox1.Location = New System.Drawing.Point(0, -9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(173, 186)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 20
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Button1
        '
        Me.Button1.Animated = True
        Me.Button1.BackColor = System.Drawing.Color.CadetBlue
        Me.Button1.BorderRadius = 20
        Me.Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Button1.FillColor = System.Drawing.Color.Aquamarine
        Me.Button1.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!)
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.IndicateFocus = True
        Me.Button1.Location = New System.Drawing.Point(13, 504)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 48)
        Me.Button1.TabIndex = 403
        Me.Button1.Text = "Logout"
        '
        'Teacher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 597)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.menuStrip3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Teacher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saint International School - Teacher"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.menuStrip3.ResumeLayout(False)
        Me.menuStrip3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblDateTime As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblUserType As Label
    Friend WithEvents lblName As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents menuStrip3 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintAttendanceReportToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StudentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddStudentProfileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnrollStudentFingerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AttendanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TimeInToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TimeOutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StudentProfileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AttendanceReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddStaffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents SettingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasswordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ExportStudentAttendanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Timer4 As Timer
    Friend WithEvents Timer5 As Timer
    Friend WithEvents PrintStudentAttendanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Button1 As Guna.UI2.WinForms.Guna2Button
End Class
