Imports System.Data.SqlClient
Public Class Login
    Dim TimesTried As String = 0
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Try
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim rd As SqlDataReader

            'Connection String
            con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
            cmd.Connection = con
            con.Open()
            cmd.CommandText = "select usertype from Registration where Username = '" & txtusername2.Text & "' and password = '" & txtpass.Text & "' "

            rd = cmd.ExecuteReader

            If rd.Read Then
                txtUserType.Text = (rd.GetString(0))
                TimesTried = 0

            ElseIf Timer1.Enabled = False Then

                If txtpass.Text = "password" Or txtusername2.Text = "Username" = False Then
                    TimesTried += 1
                    MessageBox.Show("Username or Password is incorrect!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtusername2.Text = ""
                    txtpass.Text = ""

                    If TimesTried = 3 Then
                        MessageBox.Show("You have reached the limit for Login!", "Too many failed attempts", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Timer1.Enabled = True
                    End If
                End If
            End If

            If Timer1.Enabled = True Then
                MessageBox.Show("Please try again in 30 Seconds", "Account Locked!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            rd.Close()

            If (txtUserType.Text.Trim() = "Administrator") Then
                MessageBox.Show("Welcome Back " + txtUserType.Text + vbCrLf + "We support the system up To Date As much As possible.", "Login Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Hide()
                Dim parentForm As New Admin()
                parentForm.Show()

                parentForm.lblUserType.Text = txtUserType.Text
                Admin.lblName.Text = Me.txtusername2.Text
                Admin.lblWelcome.Text = "Hello" + lblname.Text + ", Welcome Back !"

                txtusername2.Text = ""
                txtpass.Text = ""

                txtUserType.Text = ""
            End If

            If (txtUserType.Text.Trim() = "Teacher") Then
                MessageBox.Show("Welcome Back " + txtUserType.Text + vbCrLf + "it's great to see you again", "Login Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Hide()
                Dim usa As New Teacher()
                usa.Show()

                usa.lblUserType.Text = txtUserType.Text
                Admin.lblName.Text = Me.txtusername2.Text
                Admin.lblWelcome.Text = "Hello" + lblname.Text + ",Welcome Back !"

                txtusername2.Text = ""
                txtpass.Text = ""

                txtUserType.Text = ""
            End If

            'If rd.HasRows Then
            '    Dim parentForm As New Main()
            '    parentForm.Show()
            '    txtpass.Text = String.Empty
            '    txtusername.Text = String.Empty
            '    Me.Hide()
            'Else
            '    MessageBox.Show("Invalid Login or Password")
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub chkPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkPass.CheckedChanged
        If chkPass.Checked = False Then
            txtpass.PasswordChar = "*"    'Show password as "*" in textbox where the checkbox is unchecked

        Else
            txtpass.PasswordChar = ""     'Show password in textbox where the checkbox is checked
        End If
    End Sub

    Private Sub lblForgot_Click(sender As Object, e As EventArgs) Handles lblForgot.Click
        Recover_Password.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TimesTried = 0
        Timer1.Enabled = False
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub label9_MouseEnter(sender As Object, e As EventArgs) Handles Label9.MouseEnter
        Label9.ForeColor = Color.Red
    End Sub

    Private Sub label9_MouseLeave(sender As Object, e As EventArgs) Handles Label9.MouseLeave
        Label9.ForeColor = Color.Black
    End Sub
End Class