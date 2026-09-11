Imports System.Security.Cryptography
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

Public Class AdminReg
    Dim currentFrame As Image(Of Bgr, [Byte])
    Dim grabber As Capture
    Dim face As HaarCascade
    Dim eye As HaarCascade

    Private Sub btnRegister_Click_1(sender As Object, e As EventArgs) Handles btnRegister.Click
        Try
            If (cmbUserType.Text = Nothing Or cmbQuestion1.Text = Nothing Or txtEmail.Text = Nothing Or txtName.Text = Nothing Or txtContact_no.Text = Nothing Or txtPassword.Text = Nothing Or txtEmail.Text = Nothing Or txtUsername.Text = Nothing Or txtAnswer1.Text = Nothing) Then
                MessageBox.Show("Cannot submit an empty form", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim stream As New MemoryStream
                PictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim picc As Byte()
                picc = stream.ToArray()

                'Connection String
                Dim constr As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
                Using cnn As SqlConnection = New SqlConnection(constr)
                    Using com As SqlCommand = New SqlCommand("SELECT Username, Email, ContactNo, Answer1 FROM Registration WHERE password = '" & txtPassword.Text & "'")
                        com.CommandType = CommandType.Text
                        com.Connection = cnn
                        cnn.Open()
                        Using sdr As SqlDataReader = com.ExecuteReader()
                            If sdr.Read() Then
                                MessageBox.Show("Duplicate Record Detected", "Data Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                cnn.Close()
                            Else
                                Dim comd As New SqlCommand
                                Dim cn As New SqlConnection
                                cn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
                                comd.CommandType = System.Data.CommandType.Text

                                comd.CommandText = "Insert into Registration (Username, usertype, password, Name, ContactNo, Email, Question1, Answer1, Passport) Values ('" & txtUsername.Text & "','" & cmbUserType.Text & "','" & txtPassword.Text & "','" & txtName.Text & "','" & txtContact_no.Text & "','" & txtEmail.Text & "','" & cmbQuestion1.Text & "','" & txtAnswer1.Text & "',@pic)"
                                'comd.Parameters.AddWithValue("@finga", bytes)
                                comd.Parameters.AddWithValue("@pic", picc)
                                comd.Connection = cn
                                cn.Open()

                                'pic.Image.Save(AppDomain.CurrentDomain.BaseDirectory + txtUserId.Text + ".jpg")

                                'Run Query
                                comd.ExecuteNonQuery()
                                cn.Close()
                                'finger()
                                reset()
                                MessageBox.Show("The information has now been Added.", "Data Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Public Sub reset()
        txtEmail.Text = String.Empty
        txtName.Text = String.Empty
        txtContact_no.Text = String.Empty
        txtPassword.Text = String.Empty
        txtUsername.Text = String.Empty
        txtAnswer1.Text = String.Empty
        cmbQuestion1.Text = ""
        cmbUserType.Text = ""
        PictureBox1.Image = Nothing
    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtEmail.Text = String.Empty
        txtName.Text = String.Empty
        txtContact_no.Text = String.Empty
        txtPassword.Text = String.Empty
        txtUsername.Text = String.Empty
        txtAnswer1.Text = String.Empty
        cmbQuestion1.Text = ""
        cmbUserType.Text = ""
    End Sub

    Private Sub chkPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkPass.CheckedChanged
        If chkPass.Checked = False Then
            txtPassword.PasswordChar = "*"    'Show password as "*" in textbox where the checkbox is unchecked

        Else
            txtPassword.PasswordChar = ""     'Show password in textbox where the checkbox is checked
        End If
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
            PictureBox1.Image = currentFrame.ToBitmap()

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