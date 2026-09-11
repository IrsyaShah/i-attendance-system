<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnrollmentForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.EnrollmentControl = New DPFP.Gui.Enrollment.EnrollmentControl()
        Me.GroupEvents = New System.Windows.Forms.GroupBox()
        Me.ListEvents = New System.Windows.Forms.ListBox()
        Me.txtPersonId = New System.Windows.Forms.TextBox()
        Me.CloseButton = New Guna.UI2.WinForms.Guna2Button()
        Me.GroupEvents.SuspendLayout()
        Me.SuspendLayout()
        '
        'EnrollmentControl
        '
        Me.EnrollmentControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EnrollmentControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.EnrollmentControl.EnrolledFingerMask = 0
        Me.EnrollmentControl.Location = New System.Drawing.Point(2, 2)
        Me.EnrollmentControl.MaxEnrollFingerCount = 10
        Me.EnrollmentControl.Name = "EnrollmentControl"
        Me.EnrollmentControl.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000"
        Me.EnrollmentControl.Size = New System.Drawing.Size(492, 314)
        Me.EnrollmentControl.TabIndex = 3
        '
        'GroupEvents
        '
        Me.GroupEvents.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupEvents.Controls.Add(Me.ListEvents)
        Me.GroupEvents.Font = New System.Drawing.Font("Franklin Gothic Book", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupEvents.Location = New System.Drawing.Point(14, 282)
        Me.GroupEvents.Name = "GroupEvents"
        Me.GroupEvents.Size = New System.Drawing.Size(470, 146)
        Me.GroupEvents.TabIndex = 4
        Me.GroupEvents.TabStop = False
        Me.GroupEvents.Text = "Events"
        '
        'ListEvents
        '
        Me.ListEvents.BackColor = System.Drawing.Color.Salmon
        Me.ListEvents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListEvents.ForeColor = System.Drawing.Color.Black
        Me.ListEvents.FormattingEnabled = True
        Me.ListEvents.ItemHeight = 17
        Me.ListEvents.Location = New System.Drawing.Point(3, 18)
        Me.ListEvents.Name = "ListEvents"
        Me.ListEvents.Size = New System.Drawing.Size(464, 125)
        Me.ListEvents.TabIndex = 0
        '
        'txtPersonId
        '
        Me.txtPersonId.Location = New System.Drawing.Point(283, 472)
        Me.txtPersonId.Name = "txtPersonId"
        Me.txtPersonId.Size = New System.Drawing.Size(100, 20)
        Me.txtPersonId.TabIndex = 5
        Me.txtPersonId.Visible = False
        '
        'CloseButton
        '
        Me.CloseButton.Animated = True
        Me.CloseButton.BorderRadius = 20
        Me.CloseButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.CloseButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.CloseButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.CloseButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.CloseButton.FillColor = System.Drawing.Color.NavajoWhite
        Me.CloseButton.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!)
        Me.CloseButton.ForeColor = System.Drawing.Color.Black
        Me.CloseButton.IndicateFocus = True
        Me.CloseButton.Location = New System.Drawing.Point(17, 457)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(100, 45)
        Me.CloseButton.TabIndex = 422
        Me.CloseButton.Text = "Close"
        '
        'EnrollmentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 504)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.txtPersonId)
        Me.Controls.Add(Me.GroupEvents)
        Me.Controls.Add(Me.EnrollmentControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EnrollmentForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fingerprint Enrollment"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupEvents.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EnrollmentControl As DPFP.Gui.Enrollment.EnrollmentControl
    Private WithEvents GroupEvents As System.Windows.Forms.GroupBox
    Private WithEvents ListEvents As System.Windows.Forms.ListBox
    Public WithEvents txtPersonId As TextBox
    Friend WithEvents CloseButton As Guna.UI2.WinForms.Guna2Button
End Class
