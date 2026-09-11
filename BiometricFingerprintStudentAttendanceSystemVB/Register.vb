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
Public Class Register
    'Declaration of all variables, vectors And haarcascades
    Dim currentFrame As Image(Of Bgr, [Byte])
    Dim grabber As Capture
    Dim face As HaarCascade
    Dim eye As HaarCascade
    'Dim font As New MCvFont(CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5, 0.5)

    Private Sub btnStart_Click_1(sender As Object, e As EventArgs) Handles btnStart.Click
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

    Private Sub btnCapture_Click_1(sender As Object, e As EventArgs) Handles btnCapture.Click
        Try

            grabber.Dispose()
            Timer1.Stop()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Private Sub btnSubmit_Click_1(sender As Object, e As EventArgs) Handles btnSubmit.Click
        RegisterStudent()
    End Sub

    Public Sub GenerateID()
        'Dim alphabets As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        'Dim small_alphabets As String = "abcdefghijklmnopqrstuvwxyz"
        Dim numbers As String = "1234567890"

        Dim characters As String = numbers
        'If rbType.SelectedItem.Value = "1" Then
        'characters += Convert.ToString(alphabets & small_alphabets) & numbers
        characters += Convert.ToString(numbers)
        'End If
        Dim length As Integer = Integer.Parse("4")
        Dim id As String = String.Empty
        For i As Integer = 0 To length - 1
            Dim character As String = String.Empty
            Do
                Dim index As Integer = New Random().Next(0, characters.Length)
                character = characters.ToCharArray()(index).ToString()
            Loop While id.IndexOf(character) <> -1
            id += character
        Next
        txtStudentID.Text = id.Trim()
    End Sub

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateID()
        AutoDisplayClass()
        AutoDisplayStandard()
    End Sub
    'Public Sub SavePicture()
    '    Dim stream As New MemoryStream
    '    pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
    '    Dim picc As Byte()
    '    picc = stream.ToArray()
    'End Sub
    Public Sub RegisterStudent()
        Try
            If (txtEmail.Text = Nothing Or txtName.Text = Nothing Or txtAddress.Text = Nothing Or txtPhone.Text = Nothing Or txtStudentID.Text = Nothing Or ddlNationality.Text = Nothing Or ddlSex.Text = Nothing Or txtState.Text = Nothing Or txtClass.Text = Nothing Or txtStandard.Text = Nothing) Then
                MessageBox.Show("Cannot submit an empty form", "Input Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                'Connection String
                Dim constr As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
                Using cnn As SqlConnection = New SqlConnection(constr)
                    Using com As SqlCommand = New SqlCommand("SELECT Name, Email, Mobile FROM personnel WHERE Name = '" & txtName.Text & "' and Mobile='" & txtPhone.Text & "' and Email='" & txtEmail.Text & "'")
                        com.CommandType = CommandType.Text
                        com.Connection = cnn
                        cnn.Open()
                        Using sdr As SqlDataReader = com.ExecuteReader()
                            If sdr.Read() Then
                                MsgBox("Duplicate Record Detected", MsgBoxStyle.Exclamation, "Data Error!")
                                cnn.Close()
                            Else

                                Dim stream As New MemoryStream
                                pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
                                Dim picc As Byte()
                                picc = stream.ToArray()

                                Dim comd As New SqlCommand
                                Dim cn As New SqlConnection
                                cn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
                                comd.CommandType = System.Data.CommandType.Text

                                comd.CommandText = "Insert into personnel (Studentid,Name,Email,Mobile,DOB,Sex,Address,State,Nationality,Class,Standard,Passport) Values ('" & txtStudentID.Text & "','" _
                                    & txtName.Text & "','" & txtEmail.Text & "','" & txtPhone.Text & "','" & txtDOB.Text & "','" & ddlSex.Text & "','" & txtAddress.Text & "','" & txtState.Text & "','" & ddlNationality.Text & "','" & txtClass.Text & "','" & txtStandard.Text & "',@pic)"
                                comd.Parameters.AddWithValue("@pic", picc)
                                comd.Connection = cn
                                cn.Open()

                                'pic.Image.Save(AppDomain.CurrentDomain.BaseDirectory + txtUserId.Text + ".jpg")

                                'Run Query
                                comd.ExecuteNonQuery()
                                cn.Close()
                                'finger()
                                GenerateID()
                                Reset()
                                MessageBox.Show("Submitted Successfully", "Data Successfully Added!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        End Using
                        'con.Close()
                    End Using
                End Using

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtAddress.Text = Nothing
        txtEmail.Text = Nothing
        txtPhone.Text = Nothing
        txtFrefAddress.Text = Nothing
        txtFrefMobile.Text = Nothing
        txtFrefName.Text = Nothing
        txtFrefOccupat.Text = Nothing
        txtName.Text = Nothing
        ddlNationality.SelectedIndex = -1
        ddlSex.SelectedIndex = -1
        txtState.Text = Nothing
        txtClass.Text = Nothing
        txtStandard.Text = Nothing
    End Sub
    Public Sub Reset()
        txtAddress.Text = Nothing
        txtEmail.Text = Nothing
        txtPhone.Text = Nothing
        txtFrefAddress.Text = Nothing
        txtFrefMobile.Text = Nothing
        txtFrefName.Text = Nothing
        txtFrefOccupat.Text = Nothing
        txtName.Text = Nothing
        ddlNationality.SelectedIndex = -1
        ddlSex.SelectedIndex = -1
        txtState.Text = Nothing
        pictureBox1.Image = Nothing
        txtClass.Text = Nothing
        txtStandard.Text = Nothing
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