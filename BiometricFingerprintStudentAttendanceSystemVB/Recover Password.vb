Imports System.Data.SqlClient
Imports System.IO

Public Class Recover_Password
    Private Sub btnGet_Click_1(sender As Object, e As EventArgs) Handles btnGet.Click
        ShowPassword()
    End Sub

    Public Sub ShowPassword()
        Try
            Dim dr As SqlDataReader
            Dim q1 As String
            Dim mysqlconn = New SqlConnection
            mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"

            If mysqlconn.State = ConnectionState.Closed Then
                mysqlconn.Open()
            End If

            q1 = "select password from Registration where Answer1 ='" & txtAnswer1.Text & "' and Question1 ='" & cmbQuestion.Text & "' and Username ='" & Guna2TextBox1.Text & "'"
            Dim cmd As New SqlCommand
            cmd.CommandText = q1
            cmd.Connection = mysqlconn
            dr = cmd.ExecuteReader
            If (dr.Read() = True) Then
                MessageBox.Show("Your Password is : " + dr("password"), "Password Recovery!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnChangePass.Visible = True
                reset()
            End If

            dr.Close()
            mysqlconn.Close()
            cmd.Dispose()

        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Public Sub reset()
        Guna2TextBox1.Text = String.Empty
        txtAnswer1.Text = String.Empty
        cmbQuestion.Text = ""
    End Sub

    Private Sub btnExit_Click_1(sender As Object, e As EventArgs) Handles btnExit.Click
        btnChangePass.Visible = False
        Login.Show()
        Me.Hide()

        Login.txtusername2.Text = ""
        Login.txtpass.Text = ""
    End Sub

    Private Sub btnChangePass_Click_1(sender As Object, e As EventArgs) Handles btnChangePass.Click
        btnChangePass.Visible = False
        Me.Hide()
        Change_Password.Show()
    End Sub

    Private Sub Recover_Password_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnChangePass.Visible = False
    End Sub
End Class