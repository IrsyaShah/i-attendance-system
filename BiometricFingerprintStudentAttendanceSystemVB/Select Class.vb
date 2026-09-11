Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports System
Imports System.IO
Imports System.Data

Public Class Select_Class
    Private Sub Select_Class_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoDisplaySubject()
        AutoDisplayClassName()
        AutoDisplayStandard()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        'Connection String
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select Name from personnel where Class = '" & txtClass.Text & "' and Standard = '" & txtStandard.Text & "' "

        StudentIn.Show()
        Me.Hide()
        'finger()
        Reset()
    End Sub

    Public Sub AutoDisplaySubject()
        Try
            Dim con As SqlConnection = Nothing
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("SELECT Subject FROM Class", con)
            Dim ds As DataSet = New DataSet()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "list") 'list can be any name u want

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("Subject").ToString())  'columnname same As In query

            Next

            txtSubject.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtSubject.AutoCompleteCustomSource = col
            txtSubject.AutoCompleteMode = AutoCompleteMode.Suggest

            con.Close()
        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Public Sub AutoDisplayClassName()
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
End Class