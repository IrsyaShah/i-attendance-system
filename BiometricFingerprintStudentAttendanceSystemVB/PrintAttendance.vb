Imports System.Data.SqlClient
Imports System.Data
Imports System.IO.Directory
Imports System.IO
Imports System.Drawing.Printing

Public Class PrintAttendance

    Public Sub FillGridView()
        Try

            Dim con As SqlConnection = Nothing
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")

            Dim cmd As SqlCommand = New SqlCommand("Select Id,Studentid as'Student ID',Name,Class,Standard,Date,Day,TimeIn,TimeOut,Status From Attendance", con)


            con.Open()
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            da.SelectCommand = cmd
            Dim dt As Data.DataTable = New Data.DataTable()
            da.Fill(dt)
            Dim bs As BindingSource = New BindingSource()
            bs.DataSource = dt
            dataGridExportStudent.DataSource = dt
            da.Update(dt)
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub PrintAttendance_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillGridView()
        AutoDisplayClass()
        AutoDisplayStandard()
        AutoDisplayDate()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim con As SqlConnection = Nothing
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")

            Dim cmd As SqlCommand = New SqlCommand("select Id,Studentid as'Student ID',Name,Class,Standard,Date,Day,TimeIn,TimeOut,Status From Attendance where Class = '" & txtClass.Text & "' and Standard = '" & txtStandard.Text & "' and Date = '" & txtDate.Text & "' ", con)


            con.Open()
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            da.SelectCommand = cmd
            Dim dt As Data.DataTable = New Data.DataTable()
            da.Fill(dt)
            Dim bs As BindingSource = New BindingSource()
            bs.DataSource = dt
            dataGridExportStudent.DataSource = dt
            da.Update(dt)
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
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

    Public Sub AutoDisplayDate()
        Try
            Dim con As SqlConnection = Nothing
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("SELECT Date FROM Attendance", con)
            Dim ds As DataSet = New DataSet()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "list") 'list can be any name u want

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("Date").ToString())  'columnname same As In query

            Next

            txtDate.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtDate.AutoCompleteCustomSource = col
            txtDate.AutoCompleteMode = AutoCompleteMode.Suggest

            con.Close()
        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Button1.Visible = False
        Button2.Visible = False
        txtClass.Visible = False
        txtStandard.Visible = False
        txtDate.Visible = False
        Label2.Visible = False
        Label5.Visible = False
        Label3.Visible = False
        lblExit.Visible = False
        Me.PrintForm1.PrinterSettings.DefaultPageSettings.Landscape = True
        PrintForm1.PrinterSettings.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
        PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.CompatibleModeFullWindow)
        Me.PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview
        Me.PrintForm1.Print()
        Button1.Visible = True
        Button2.Visible = True
        txtClass.Visible = True
        txtStandard.Visible = True
        txtDate.Visible = True
        Label2.Visible = True
        Label5.Visible = True
        Label3.Visible = True
        lblExit.Visible = True
        txtClass.Text = ""
        txtStandard.Text = ""
        txtDate.Text = ""
        FillGridView()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles lblExit.Click
        Me.Close()
    End Sub

    Private Sub lblExit_MouseEnter(sender As Object, e As EventArgs) Handles lblExit.MouseEnter
        lblExit.ForeColor = Color.Red
    End Sub

    Private Sub lblExit_MouseLeave(sender As Object, e As EventArgs) Handles lblExit.MouseLeave
        lblExit.ForeColor = Color.Black
    End Sub
End Class