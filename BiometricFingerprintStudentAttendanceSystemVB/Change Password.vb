Imports System.Data.SqlClient
Imports System.IO

Public Class Change_Password
    Private Sub btnChangePassword_Click_1(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        UpdatePassword()
    End Sub

    Public Sub UpdatePassword()
        Try
            If (txtOldPass.Text = Nothing Or txtNewPass.Text = Nothing Or txtConfPass.Text = Nothing) Then
                MessageBox.Show("Cannot Submit an Empty Form", "Please try again!", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")
                con.Open()

                Dim cb As String = "update Registration set password=@d2 where password=@d1"
                Dim com As SqlCommand = New SqlCommand(cb)

                'com = New SqlCommand(cb)

                com.Connection = con
                com.Parameters.AddWithValue("@d2", txtNewPass.Text)
                com.Parameters.AddWithValue("@d1", txtOldPass.Text)

                com.ExecuteReader()
                MessageBox.Show("Your password has been changed successfully", "Password Changed!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                con.Close()

                reset()
                Me.Hide()
                Login.Show()

                Login.txtusername2.Text = ""
                Login.txtpass.Text = ""
            End If

        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")

        End Try

    End Sub

    Public Sub reset()
        txtOldPass.Text = String.Empty
        txtConfPass.Text = String.Empty
        txtNewPass.Text = String.Empty
    End Sub

    Private Sub btnExit_Click_1(sender As Object, e As EventArgs) Handles btnExit.Click

        txtOldPass.Text = ""
        txtNewPass.Text = ""
        txtConfPass.Text = ""

        Me.Hide()
        Login.Show()

        Login.txtusername2.Text = ""
        Login.txtpass.Text = ""
    End Sub

    Private Sub btnClear_Click_1(sender As Object, e As EventArgs) Handles btnClear.Click
        txtOldPass.Text = ""
        txtNewPass.Text = ""
        txtConfPass.Text = ""
    End Sub

    Private Sub chkPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkPass.CheckedChanged
        If chkPass.Checked = False Then
            txtOldPass.PasswordChar = "*"    'Show password as "*" in textbox where the checkbox is unchecked

        Else
            txtOldPass.PasswordChar = ""     'Show password in textbox where the checkbox is checked
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            txtNewPass.PasswordChar = "*"    'Show password as "*" in textbox where the checkbox is unchecked

        Else
            txtNewPass.PasswordChar = ""     'Show password in textbox where the checkbox is checked
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = False Then
            txtConfPass.PasswordChar = "*"    'Show password as "*" in textbox where the checkbox is unchecked

        Else
            txtConfPass.PasswordChar = ""     'Show password in textbox where the checkbox is checked
        End If
    End Sub
End Class