Imports System.Data.SqlClient
Imports System.IO
Imports System.Diagnostics
Imports Emgu.CV.Structure
Imports Emgu.CV
Imports Emgu.CV.CvEnum
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Security.Cryptography
Imports System.Data

Public Class AdminUser_Profile
    Dim currentFrame As Image(Of Bgr, [Byte])
    Dim grabber As Capture
    Dim face As HaarCascade
    Dim eye As HaarCascade

    Private Sub btnNameSearch_Click_1(sender As Object, e As EventArgs) Handles btnNameSearch.Click
        SearchRecord()
    End Sub

    Public Sub AutoDisplayName()
        Try
            Dim con As SqlConnection = Nothing
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("SELECT Name FROM Registration", con)
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
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
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

            nm = "select Id,Username,usertype,password,ContactNo,Email,Question1,Answer1,Passport from Registration where Name ='" & txtNameSearch.Text & "'"
            Dim cmd As New SqlCommand
            cmd.CommandText = nm
            cmd.Connection = mysqlconn
            dr = cmd.ExecuteReader
            If (dr.Read() = True) Then
                txtUsertype.Text = dr("usertype")
                txtEmail.Text = dr("Email")
                txtPassword.Text = dr("password")
                txtContact.Text = dr("ContactNo")
                txtUsername.Text = dr("Username")
                cmbQuestion1.Text = dr("Question1")
                txtAnswer1.Text = dr("Answer1")

                Dim pByte As Byte()
                pByte = dr("Passport")
                Dim MS As MemoryStream = New MemoryStream(pByte)
                PictureBox1.Image = New Bitmap(MS)
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
            PictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim picc As Byte()
            picc = stream.ToArray()

            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")
            con.Open()

            Dim cb As String = "update Registration set Username=@d2,usertype=@d3,password=@d4,ContactNo=@d5,Email=@d6,Question1=@d7,Answer1=@d8,Passport=@pic where Name=@d1"
            Dim com As SqlCommand = New SqlCommand(cb)

            'com = New SqlCommand(cb)

            com.Connection = con
            com.Parameters.AddWithValue("@d1", txtNameSearch.Text)
            com.Parameters.AddWithValue("@d2", txtUsername.Text)
            com.Parameters.AddWithValue("@d3", txtUsertype.Text)
            com.Parameters.AddWithValue("@d4", txtPassword.Text)
            com.Parameters.AddWithValue("@d5", txtContact.Text)
            com.Parameters.AddWithValue("@d6", txtEmail.Text)
            com.Parameters.AddWithValue("@d7", cmbQuestion1.Text)
            com.Parameters.AddWithValue("@d8", txtAnswer1.Text)
            com.Parameters.AddWithValue("@pic", picc)

            com.ExecuteReader()
            MessageBox.Show("Data Successfully Updated!", "Admin/User Record!", MessageBoxButtons.OK, MessageBoxIcon.Information)

            con.Close()

        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try

    End Sub

    Public Sub Reset()
        'txtStaffID.Text = ""
        txtEmail.Text = ""
        txtPassword.Text = ""
        txtContact.Text = ""
        txtUsername.Text = ""
        cmbQuestion1.Text = ""
        txtAnswer1.Text = ""
        txtNameSearch.Text = ""
        txtUsertype.Text = ""
        PictureBox1.Image = Nothing

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try

            If (MessageBox.Show("Are you sure you want to delete " + txtUsername.Text + " record? This CANNOT be undone", "Admin/User Record!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Yes) Then

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
            Dim cq As String = "delete from Registration where Name='" + txtNameSearch.Text + "'"
            Dim comm As SqlCommand = New SqlCommand(cq)
            'cmd = New SqlCommand(cq)
            comm.Connection = con

            RowsAffected = comm.ExecuteNonQuery()

            If (RowsAffected > 0) Then

                MessageBox.Show("Data Successfully Deleted!", "Admin/User Record!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No record found", "Data Missing!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            grabber.Dispose()
            Timer1.Stop()

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
            PictureBox1.Image = currentFrame.ToBitmap()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Me.Close()
    End Sub

    Private Sub Label9_MouseEnter(sender As Object, e As EventArgs) Handles Label9.MouseEnter
        Label9.ForeColor = Color.Red
    End Sub

    Private Sub Label9_MouseLeave(sender As Object, e As EventArgs) Handles Label9.MouseLeave
        Label9.ForeColor = Color.Black
    End Sub
End Class