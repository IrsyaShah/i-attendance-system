Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports System
Imports System.IO
Imports System.Data

Public Class Add_Class
    Private Sub btnNameSearch_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim comd As New SqlCommand
        Dim cn As New SqlConnection
        cn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
        comd.CommandType = System.Data.CommandType.Text

        comd.CommandText = "Insert into Class (ClassName, Standard) Values ('" & txtClass.Text & "','" & txtStandard.Text & "')"
        'comd.Parameters.AddWithValue("@finga", bytes)
        comd.Connection = cn
        cn.Open()

        'pic.Image.Save(AppDomain.CurrentDomain.BaseDirectory + txtUserId.Text + ".jpg")

        'Run Query
        comd.ExecuteNonQuery()
        cn.Close()
        'finger()
        reset()
        MessageBox.Show("The information has now been Added.", "Data Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Public Sub reset()
        txtClass.Text = String.Empty
        txtStandard.Text = String.Empty

    End Sub

    Private Sub btnClear_Click_1(sender As Object, e As EventArgs) Handles btnClear.Click
        txtClass.Text = ""
        txtStandard.Text = ""
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
    End Sub

    Private Sub Label1_MouseEnter(sender As Object, e As EventArgs) Handles Label1.MouseEnter
        Label1.ForeColor = Color.Red
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.Black
    End Sub
End Class