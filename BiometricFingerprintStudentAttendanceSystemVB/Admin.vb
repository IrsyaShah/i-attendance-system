Imports System.Data.SqlClient
Imports System
Imports System.IO
Imports System.Data
Imports System.Diagnostics
Imports Emgu.CV.Structure
Imports Emgu.CV
Imports Emgu.CV.CvEnum
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Security.Cryptography

Public Class Admin
    Dim currentFrame As Image(Of Bgr, [Byte])
    Dim grabber As Capture
    Dim face As HaarCascade
    Dim eye As HaarCascade
    Dim mysqlconn As SqlConnection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim tflag As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'day.Text = System.DateTime.Now.ToString("dddd")
        'dDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy")
        'timeNow.Text = System.DateTime.Now.ToString("HH:mm:ss")
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim arrImage() As Byte = Nothing
            Dim dr As SqlDataReader
            Dim nm As String

            Dim mysqlconn = New SqlConnection
            mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"

            If mysqlconn.State = ConnectionState.Closed Then
                mysqlconn.Open()
            End If

            nm = "select Passport from Registration where Username ='" & Login.txtusername2.Text & "'"
            Dim cmd As New SqlCommand
            cmd.CommandText = nm
            cmd.Connection = mysqlconn
            dr = cmd.ExecuteReader
            If (dr.Read() = True) Then
                Dim pByte As Byte()
                pByte = dr("Passport")
                Dim MS As MemoryStream = New MemoryStream(pByte)
                PictureBox1.Image = New Bitmap(MS)
            End If

            dr.Close()
            mysqlconn.Close()
            cmd.Dispose()
            Timer1.Start()

            Timer2.Enabled = True
            Me.lblName.Text = Login.txtusername2.Text
            lblWelcome.Text = "Hello " + lblName.Text + ", Welcome Back !"
        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Private Sub verificationToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        'Dim verif As New main_form()
        'verif.Show()
    End Sub
    Sub loadenrolleddata()
        Dim drt As SqlDataReader
        Dim nm As String
        fptemplist.Clear()
        listofnames.Clear()
        Dim mysqlconn = New SqlConnection
        mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"

        If mysqlconn.State = ConnectionState.Closed Then
            mysqlconn.Open()
        End If

        nm = "select personnelid,fingerdata1,fingerdata2,fingerdata3,fingerdata4,fingerdata5,fingerdata6,fingerdata7,fingerdata8," _
            & "fingerdata9,fingerdata10 from new_enrollment"

        'nm = "select personnelid,fingerdata7" _
        '   & "from new_enrollment where length(fingerdata7) > 0 "

        Dim cmd As New SqlCommand
        cmd.CommandText = nm
        cmd.Connection = mysqlconn
        drt = cmd.ExecuteReader
        'MetroProgressBar1.Maximum = drt.FieldCount
        While drt.Read()
            Dim mstram As IO.MemoryStream

            Try 'Add
                For i = 1 To 10
                    Dim fpbytes As Byte()
                    fpbytes = drt("fingerdata" & i)
                    mstram = New IO.MemoryStream(fpbytes)
                    If fpbytes.Length > 0 Then
                        Dim temp8 As DPFP.Template = New DPFP.Template
                        temp8.DeSerialize(mstram)
                        fptemplist.Add(temp8)
                        listofnames.Add(drt("personnelid"))
                    End If
                Next
            Catch ex As Exception 'Add
            End Try 'Add
        End While
        drt.Close()
        mysqlconn.Close()
    End Sub
    Private Sub Main_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        loadenrolleddata()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        Dim register As New Register()
        register.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub AddStudentProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddStudentProfileToolStripMenuItem.Click
        Dim register As New Register()
        register.Show()
    End Sub

    Private Sub AttendanceReportToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        reports.Close()
        reports.ShowDialog()
    End Sub

    Private Sub AddStaffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddStaffToolStripMenuItem.Click
        Dim adminreg As New AdminReg()
        adminreg.Show()
    End Sub

    Private Sub StudentProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentProfileToolStripMenuItem.Click
        Dim employeeProfile As New StudentProfile()
        employeeProfile.Show()
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        Dim exportEmployee As New ExportStudent()
        exportEmployee.Show()
    End Sub

    Private Sub PrintAttendanceReportToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Dim printAttendance As New PrintAttendance()
        printAttendance.Show()
    End Sub

    Private Sub EnrollStudentFingerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnrollStudentFingerToolStripMenuItem.Click
        Enroll.Close()
        Enroll.ShowDialog()
    End Sub

    Private Sub TimeInToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        'If TimeInToolStripMenuItem.Enabled = True Then
        'tflag = 1
        'StudentIn.Timer3.Enabled = True
        'StudentIn.Show()
        'End If
    End Sub

    Private Sub TimeOutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        StudentOut.Close()
        StudentOut.ShowDialog()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        lblDateTime.Text = Date.Now.ToString("dd MMM yyyy hh:mm:ss")
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Login.Show()
    End Sub

    Private Sub AdminUserProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminUserProfileToolStripMenuItem.Click
        AdminUser_Profile.ShowDialog()
    End Sub

    Private Sub ExportStudentAttendanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportStudentAttendanceToolStripMenuItem.Click
        Export_Student_Attendance.ShowDialog()
    End Sub

    Private Sub PrintAttendanceReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintAttendanceReportToolStripMenuItem.Click
        PrintAttendance.ShowDialog()
    End Sub

    Private Sub AddClassToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddClassToolStripMenuItem.Click
        Add_Class.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Change_Password2.Show()
    End Sub
End Class