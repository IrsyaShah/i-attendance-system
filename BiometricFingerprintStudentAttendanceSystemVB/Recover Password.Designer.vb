<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Recover_Password
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Recover_Password))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbQuestion = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Guna2TextBox1 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtAnswer1 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnChangePass = New Guna.UI2.WinForms.Guna2Button()
        Me.btnGet = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExit = New Guna.UI2.WinForms.Guna2Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(399, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Question :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(410, 225)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Answer :"
        '
        'cmbQuestion
        '
        Me.cmbQuestion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbQuestion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbQuestion.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.cmbQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbQuestion.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbQuestion.FormattingEnabled = True
        Me.cmbQuestion.Items.AddRange(New Object() {"What was your childhood nickname?", "What is your favourite movie?", "What is your main hobby?", "What was your first car?", "Where were your born?"})
        Me.cmbQuestion.Location = New System.Drawing.Point(483, 168)
        Me.cmbQuestion.Name = "cmbQuestion"
        Me.cmbQuestion.Size = New System.Drawing.Size(278, 29)
        Me.cmbQuestion.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.BiometricFingerprintStudentAttendanceSystemVB.My.Resources.Resources._11
        Me.PictureBox1.Location = New System.Drawing.Point(-2, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(801, 452)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 96
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Constantia", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(389, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(257, 33)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Password Recovery"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(391, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 21)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Username :"
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.BorderRadius = 20
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Guna2TextBox1
        '
        Me.Guna2TextBox1.Animated = True
        Me.Guna2TextBox1.BackColor = System.Drawing.Color.White
        Me.Guna2TextBox1.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2TextBox1.BorderRadius = 7
        Me.Guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Guna2TextBox1.DefaultText = ""
        Me.Guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TextBox1.Font = New System.Drawing.Font("Franklin Gothic Book", 14.25!)
        Me.Guna2TextBox1.ForeColor = System.Drawing.Color.Black
        Me.Guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TextBox1.Location = New System.Drawing.Point(483, 117)
        Me.Guna2TextBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Guna2TextBox1.Name = "Guna2TextBox1"
        Me.Guna2TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Guna2TextBox1.PlaceholderText = ""
        Me.Guna2TextBox1.SelectedText = ""
        Me.Guna2TextBox1.Size = New System.Drawing.Size(179, 26)
        Me.Guna2TextBox1.TabIndex = 405
        '
        'txtAnswer1
        '
        Me.txtAnswer1.Animated = True
        Me.txtAnswer1.BackColor = System.Drawing.Color.White
        Me.txtAnswer1.BorderColor = System.Drawing.Color.DarkGray
        Me.txtAnswer1.BorderRadius = 7
        Me.txtAnswer1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAnswer1.DefaultText = ""
        Me.txtAnswer1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtAnswer1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtAnswer1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAnswer1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtAnswer1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAnswer1.Font = New System.Drawing.Font("Franklin Gothic Book", 14.25!)
        Me.txtAnswer1.ForeColor = System.Drawing.Color.Black
        Me.txtAnswer1.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAnswer1.Location = New System.Drawing.Point(483, 225)
        Me.txtAnswer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAnswer1.Name = "txtAnswer1"
        Me.txtAnswer1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtAnswer1.PlaceholderText = ""
        Me.txtAnswer1.SelectedText = ""
        Me.txtAnswer1.Size = New System.Drawing.Size(179, 26)
        Me.txtAnswer1.TabIndex = 406
        '
        'btnChangePass
        '
        Me.btnChangePass.Animated = True
        Me.btnChangePass.BackColor = System.Drawing.Color.White
        Me.btnChangePass.BorderRadius = 20
        Me.btnChangePass.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnChangePass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnChangePass.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnChangePass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnChangePass.FillColor = System.Drawing.Color.LightBlue
        Me.btnChangePass.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!)
        Me.btnChangePass.ForeColor = System.Drawing.Color.Black
        Me.btnChangePass.IndicateFocus = True
        Me.btnChangePass.Location = New System.Drawing.Point(455, 280)
        Me.btnChangePass.Name = "btnChangePass"
        Me.btnChangePass.Size = New System.Drawing.Size(150, 51)
        Me.btnChangePass.TabIndex = 407
        Me.btnChangePass.Text = "Change Password"
        '
        'btnGet
        '
        Me.btnGet.Animated = True
        Me.btnGet.BackColor = System.Drawing.Color.White
        Me.btnGet.BorderRadius = 20
        Me.btnGet.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnGet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnGet.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnGet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnGet.FillColor = System.Drawing.Color.Salmon
        Me.btnGet.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!)
        Me.btnGet.ForeColor = System.Drawing.Color.Black
        Me.btnGet.IndicateFocus = True
        Me.btnGet.Location = New System.Drawing.Point(611, 280)
        Me.btnGet.Name = "btnGet"
        Me.btnGet.Size = New System.Drawing.Size(126, 51)
        Me.btnGet.TabIndex = 408
        Me.btnGet.Text = "Get Password"
        '
        'btnExit
        '
        Me.btnExit.Animated = True
        Me.btnExit.BackColor = System.Drawing.Color.White
        Me.btnExit.BorderRadius = 20
        Me.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnExit.FillColor = System.Drawing.Color.CornflowerBlue
        Me.btnExit.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!)
        Me.btnExit.ForeColor = System.Drawing.Color.Black
        Me.btnExit.IndicateFocus = True
        Me.btnExit.Location = New System.Drawing.Point(638, 387)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(150, 51)
        Me.btnExit.TabIndex = 409
        Me.btnExit.Text = "Back to Log In"
        '
        'Recover_Password
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnGet)
        Me.Controls.Add(Me.btnChangePass)
        Me.Controls.Add(Me.txtAnswer1)
        Me.Controls.Add(Me.Guna2TextBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbQuestion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Recover_Password"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saint International School - Forgot Password"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Private WithEvents cmbQuestion As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents txtAnswer1 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2TextBox1 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnChangePass As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnGet As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExit As Guna.UI2.WinForms.Guna2Button
End Class
