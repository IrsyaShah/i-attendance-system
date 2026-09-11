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
Imports System.Drawing.Imaging

Public Class Teacher
    Dim currentFrame As Image(Of Bgr, [Byte])
    Dim grabber As Capture
    Dim face As HaarCascade
    Dim eye As HaarCascade
    Dim tflag As Integer

    Private Sub ClockInToolStripMenuItem_Click(sender As Object, e As EventArgs)
        StudentIn.Close()
        StudentIn.ShowDialog()
    End Sub

    Private Sub ClockOutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        StudentOut.Close()
        StudentOut.ShowDialog()
    End Sub

    Private Sub User_Load(sender As Object, e As EventArgs) Handles Me.Load
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

            Timer1.Enabled = True
            Me.lblName.Text = Login.txtusername2.Text
            lblWelcome.Text = "Hello " + lblName.Text + ", Welcome Back !"

        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Private Sub AddStudentProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddStudentProfileToolStripMenuItem.Click
        Register.Show()
    End Sub

    Private Sub EnrollStudentFingerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnrollStudentFingerToolStripMenuItem.Click
        Enroll.Show()
    End Sub

    Private Sub TimeInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TimeInToolStripMenuItem.Click
        If TimeInToolStripMenuItem.Enabled = True Then
            tflag = 1
            StudentIn.Timer3.Enabled = True
            StudentIn.Show()
        End If
    End Sub

    Private Sub TimeOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TimeOutToolStripMenuItem.Click
        StudentOut.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Date.Now.ToString("dd MMM yyyy hh:mm:ss")
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Login.Show()
    End Sub

    Private Sub PasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasswordToolStripMenuItem.Click
        Change_Password2.Show()
    End Sub

    Private Sub ExportStudentAttendanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportStudentAttendanceToolStripMenuItem.Click
        Export_Student_Attendance.Show()
    End Sub

    Private Sub PrintStudentAttendanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintStudentAttendanceToolStripMenuItem.Click
        PrintAttendance.Show()
    End Sub
End Class