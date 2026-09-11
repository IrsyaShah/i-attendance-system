Imports System.Diagnostics
Imports Emgu.CV.Structure
Imports Emgu.CV
Imports Emgu.CV.CvEnum
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports System.Data
Public Class StudentProfile
    Dim currentFrame As Image(Of Bgr, [Byte])
    Dim grabber As Capture
    Dim face As HaarCascade
    Dim eye As HaarCascade

    Private Sub btnNameSearch_Click_1(sender As Object, e As EventArgs) Handles btnNameSearch.Click
        SearchRecord()
    End Sub
    Public Sub AutoDisplayClass()
        Try
            Dim con As SqlConnection = Nothing
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("SELECT ClassName FROM Class", con)
            Dim ds As DataSet = New DataSet()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "list") 'list can be any name u want

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("ClassName").ToString())  'columnname same As In query

            Next

            txtClass.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtClass.AutoCompleteCustomSource = col
            txtClass.AutoCompleteMode = AutoCompleteMode.Suggest

            con.Close()
        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Public Sub AutoDisplayStandard()
        Try
            Dim con As SqlConnection = Nothing
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("SELECT Standard FROM Class", con)
            Dim ds As DataSet = New DataSet()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "list") 'list can be any name u want

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("Standard").ToString())  'columnname same As In query

            Next

            txtStandard.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtStandard.AutoCompleteCustomSource = col
            txtStandard.AutoCompleteMode = AutoCompleteMode.Suggest

            con.Close()
        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Public Sub AutoDisplayName()
        Try
            Dim con As SqlConnection = Nothing
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("SELECT Name FROM personnel", con)
            Dim ds As DataSet = New DataSet()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "list") 'list can be any name u want

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("Name").ToString())  'columnname same As In query

            Next

            txtNameSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtNameSearch.AutoCompleteCustomSource = col
            txtNameSearch.AutoCompleteMode = AutoCompleteMode.Suggest


            con.Close()
        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try

    End Sub

    Private Sub EmployeeProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoDisplayName()
        AutoDisplayClass()
        AutoDisplayStandard()
    End Sub

    Private Sub btnUpdate_Click_1(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateRecord()
        Reset()
    End Sub

    Public Sub SearchRecord()
        Try
            Dim arrImage() As Byte = Nothing
            Dim dr As SqlDataReader
            Dim nm As String
            'Dim name As String = ""
            'Dim dept As String = ""
            'Dim jobtitle As String = ""
            Dim mysqlconn = New SqlConnection
            mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"

            If mysqlconn.State = ConnectionState.Closed Then
                mysqlconn.Open()
            End If

            nm = "select Studentid,Name,Email,Mobile,DOB,Sex,Address,State,Nationality,Passport,Class,Standard from personnel where Name ='" & txtNameSearch.Text & "'"
            Dim cmd As New SqlCommand
            cmd.CommandText = nm
            cmd.Connection = mysqlconn
            dr = cmd.ExecuteReader
            If (dr.Read() = True) Then
                txtStudentID.Text = dr("Studentid")
                txtName.Text = dr("Name")
                txtEmail.Text = dr("Email")
                txtPhone.Text = dr("Mobile")
                txtDOB.Text = dr("DOB")
                txtAddress.Text = dr("Address")
                txtState.Text = dr("State")
                txtSex.Text = dr("Sex")
                txtNationality.Text = dr("Nationality")
                txtClass.Text = dr("Class")
                txtStandard.Text = dr("Standard")

                Dim pByte As Byte()
                pByte = dr("Passport")
                Dim MS As MemoryStream = New MemoryStream(pByte)
                pictureBox1.Image = New Bitmap(MS)
            End If

            btnUpdate.Enabled = True
            btnDelete.Enabled = True

            dr.Close()
            mysqlconn.Close()
            cmd.Dispose()

        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Public Sub UpdateRecord()
        Try
            Dim stream As New MemoryStream
            pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim picc As Byte()
            picc = stream.ToArray()

            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")
            con.Open()

            Dim cb As String = "update personnel set Name=@d2,Email=@d3,Mobile=@d4,DOB=@d5,Sex=@d6,Address=@d7,State=@d8,Nationality=@d9,Class=@d10,Standard=@d11,Passport=@pic where Studentid=@d1"
            Dim com As SqlCommand = New SqlCommand(cb)

            'com = New SqlCommand(cb)

            com.Connection = con
            com.Parameters.AddWithValue("@d1", txtStudentID.Text)
            com.Parameters.AddWithValue("@d2", txtName.Text)
            com.Parameters.AddWithValue("@d3", txtEmail.Text)
            com.Parameters.AddWithValue("@d4", txtPhone.Text)
            com.Parameters.AddWithValue("@d5", txtDOB.Text)
            com.Parameters.AddWithValue("@d6", txtSex.Text)
            com.Parameters.AddWithValue("@d7", txtAddress.Text)
            com.Parameters.AddWithValue("@d8", txtState.Text)
            com.Parameters.AddWithValue("@d9", txtNationality.Text)
            com.Parameters.AddWithValue("@d10", txtClass.Text)
            com.Parameters.AddWithValue("@d11", txtStandard.Text)
            com.Parameters.AddWithValue("@pic", picc)

            com.ExecuteReader()
            MessageBox.Show("Student Record Updated Successfully", "Student Attendance System", MessageBoxButtons.OK, MessageBoxIcon.Information)

            con.Close()

        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try

    End Sub

    Public Sub Reset()
        'txtStaffID.Text = ""
        txtNameSearch.Text = ""
        txtStudentID.Text = ""
        txtName.Text = ""
        txtEmail.Text = ""
        txtPhone.Text = ""
        txtDOB.Text = ""
        txtAddress.Text = ""
        txtState.Text = ""
        txtNationality.Text = ""
        txtSex.Text = ""
        txtClass.Text = ""
        txtStandard.Text = ""
        pictureBox1.Image = Nothing
    End Sub

    Private Sub btnDelete_Click_1(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try

            If (MessageBox.Show("Are you sure you want to delete " + txtName.Text + " record? This CANNOT be undone", "Student Attendance System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Yes) Then

                DeleteAttendance()
                DeleteRecord()

                'MessageBox.Show("Successfully deleted", "Clock Smart", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If

        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Public Sub DeleteRecord()
        Try

            Dim RowsAffected As Integer = 0
            'Int RowsAffected = 0
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")
            con.Open()
            Dim cq As String = "delete from personnel where Studentid='" + txtStudentID.Text + "'"
            Dim comm As SqlCommand = New SqlCommand(cq)
            'cmd = New SqlCommand(cq)
            comm.Connection = con

            RowsAffected = comm.ExecuteNonQuery()

            If (RowsAffected > 0) Then

                MessageBox.Show("Successfully Deleted", "Student Attendance System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No record found", "Student Attendance System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Reset()
            End If

            con.Close()

        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Public Sub DeleteAttendance()
        Try

            Dim RowsAffected As Integer = 0
            'Int RowsAffected = 0
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")
            con.Open()
            Dim cq As String = "delete from Attendance where Studentid='" + txtStudentID.Text + "'"
            Dim comm As SqlCommand = New SqlCommand(cq)
            'cmd = New SqlCommand(cq)
            comm.Connection = con

            RowsAffected = comm.ExecuteNonQuery()

            If (RowsAffected > 0) Then

                'MessageBox.Show("Successfully Deleted", "Clock Smart", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'MessageBox.Show("No record found", "Clock Smart", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Reset()
            End If

            con.Close()

        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            grabber = New Capture()
            grabber.QueryFrame()
            Timer1.Start()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            'Label3.Text = "0"

            'Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(250, 192, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)


            'Show the faces procesed and recognized
            pictureBox1.Image = currentFrame.ToBitmap()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            grabber.Dispose()
            Timer1.Stop()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click
        Me.Close()
    End Sub

    Private Sub lblExit_MouseEnter(sender As Object, e As EventArgs) Handles lblExit.MouseEnter
        lblExit.ForeColor = Color.Red
    End Sub

    Private Sub lblExit_MouseLeave(sender As Object, e As EventArgs) Handles lblExit.MouseLeave
        lblExit.ForeColor = Color.Black
    End Sub
End Class