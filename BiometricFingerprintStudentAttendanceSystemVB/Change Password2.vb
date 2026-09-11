Imports System.Data.SqlClient
Imports System.IO

Public Class Change_Password2
    Private Sub btnChangePassword1_Click_1(sender As Object, e As EventArgs) Handles btnChangePassword1.Click
        UpdatePassword()
    End Sub

    Public Sub UpdatePassword()
        Try
            If (txtOldPass1.Text = Nothing Or txtNewPass1.Text = Nothing Or txtConfPass1.Text = Nothing) Then
                MessageBox.Show("Cannot Submit an Empty Form", "Please try again!", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")
                con.Open()

                Dim cb As String = "update Registration set password=@d2 where password=@d1"
                Dim com As SqlCommand = New SqlCommand(cb)

                'com = New SqlCommand(cb)

                com.Connection = con
                com.Parameters.AddWithValue("@d2", txtNewPass1.Text)
                com.Parameters.AddWithValue("@d1", txtOldPass1.Text)

                com.ExecuteReader()
                MessageBox.Show("Your password has been changed successfully", "Password Changed!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                con.Close()
                reset()
            End If

        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")

        End Try

    End Sub

    Public Sub reset()
        txtOldPass1.Text = String.Empty
        txtConfPass1.Text = String.Empty
        txtNewPass1.Text = String.Empty
    End Sub

    Private Sub btnClear_Click_1(sender As Object, e As EventArgs) Handles btnClear.Click
        txtOldPass1.Text = ""
        txtConfPass1.Text = ""
        txtNewPass1.Text = ""
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

    Private Sub chkPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkPass.CheckedChanged
        If chkPass.Checked = False Then
            txtOldPass1.PasswordChar = "*"    'Show password as "*" in textbox where the checkbox is unchecked

        Else
            txtOldPass1.PasswordChar = ""     'Show password in textbox where the checkbox is checked
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            txtNewPass1.PasswordChar = "*"    'Show password as "*" in textbox where the checkbox is unchecked

        Else
            txtNewPass1.PasswordChar = ""     'Show password in textbox where the checkbox is checked
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = False Then
            txtConfPass1.PasswordChar = "*"    'Show password as "*" in textbox where the checkbox is unchecked

        Else
            txtConfPass1.PasswordChar = ""     'Show password in textbox where the checkbox is checked
        End If
    End Sub
End Class