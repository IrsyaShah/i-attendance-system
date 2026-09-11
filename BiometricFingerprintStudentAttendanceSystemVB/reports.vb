Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Reporting.WinForms
Imports System.Data
Imports System.IO.Directory
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Public Class reports

    Private Sub reports_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ListView1.Columns.Add("")
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Sub loademployees()
        Dim mysqlconn = New SqlConnection
        mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"

        Dim sup As Integer = 0
        Dim dr As SqlDataReader
        Dim query As String

        mysqlconn.Open()

        Try
            query = "select (Name) as nm from personnel"
            If mysqlconn.State = ConnectionState.Closed Then mysqlconn.Open()
            Dim cmd = New SqlCommand(query, mysqlconn)
            dr = cmd.ExecuteReader()
            While dr.Read
                ComboBox1.Items.Add(dr("nm"))
            End While
            mysqlconn.Close()
            dr.Close()
        Catch ex As Exception

        End Try

    End Sub

    Sub loadClass()
        Dim mysqlconn = New SqlConnection
        mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"

        Dim sup As Integer = 0
        Dim dr As SqlDataReader
        Dim query As String

        mysqlconn.Open()

        Try
            query = "select (Class) as cs from personnel"
            If mysqlconn.State = ConnectionState.Closed Then mysqlconn.Open()
            Dim cmd = New SqlCommand(query, mysqlconn)
            dr = cmd.ExecuteReader()
            While dr.Read
                ComboBox2.Items.Add(dr("cs"))
            End While
            mysqlconn.Close()
            dr.Close()
        Catch ex As Exception

        End Try

    End Sub

    Sub loadStandard()
        Dim mysqlconn = New SqlConnection
        mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"

        Dim sup As Integer = 0
        Dim dr As SqlDataReader
        Dim query As String

        mysqlconn.Open()

        Try
            query = "select (Standard) as std from personnel"
            If mysqlconn.State = ConnectionState.Closed Then mysqlconn.Open()
            Dim cmd = New SqlCommand(query, mysqlconn)
            dr = cmd.ExecuteReader()
            While dr.Read
                ComboBox3.Items.Add(dr("std"))
            End While
            mysqlconn.Close()
            dr.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub reports_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        loademployees()
        loadClass()
        loadStandard()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim mysqlconn = New SqlConnection
            mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
            mysqlconn.Open()

            Dim mysqlconn2 = New SqlConnection
            mysqlconn2.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
            mysqlconn2.Open()

            Dim females As Integer = 0
            Dim males As Integer = 0
            Dim sqlstr As String
            report1source.Tables.Clear()

            'sqlstr = "select namee,dept,datee from fingerclock where (STR_TO_DATE(datee,'%W, %M %d, %Y     %h:%i %p')) BETWEEN (STR_TO_DATE('" & DateTimePicker1.Text & "','%W, %M %d, %Y')) and (STR_TO_DATE('" & DateTimePicker2.Text & "','%W, %M %d, %Y')) GROUP BY concat(datee,namee)"
            If String.IsNullOrWhiteSpace(ComboBox1.Text) Then
                sqlstr = "select StudentId,Name,Class,Standard,Date,Day,TimeIn,TimeOut,Status from Attendance where Date >= '" & DateTimePicker1.Value.Date & "' AND Date <= '" & DateTimePicker2.Value.Date & "'"
            Else
                sqlstr = "select StudentId,Name,Class,Standard,Date,Day,TimeIn,TimeOut,Status from Attendance where Name='" & ComboBox1.Text & "' AND Date >= '" & DateTimePicker1.Value.Date & "' AND Date <= '" & DateTimePicker2.Value.Date & "'"
            End If

            If String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                sqlstr = "select StudentId,Name,Class,Standard,Date,Day,TimeIn,TimeOut,Status from Attendance where Date >= '" & DateTimePicker1.Value.Date & "' AND Date <= '" & DateTimePicker2.Value.Date & "'"
            Else
                sqlstr = "select StudentId,Name,Class,Standard,Date,Day,TimeIn,TimeOut,Status from Attendance where Class='" & ComboBox2.Text & "' AND Date >= '" & DateTimePicker1.Value.Date & "' AND Date <= '" & DateTimePicker2.Value.Date & "'"
            End If

            If String.IsNullOrWhiteSpace(ComboBox3.Text) Then
                sqlstr = "select StudentId,Name,Class,Standard,Date,Day,TimeIn,TimeOut,Status from Attendance where Date >= '" & DateTimePicker1.Value.Date & "' AND Date <= '" & DateTimePicker2.Value.Date & "'"
            Else
                sqlstr = "select StudentId,Name,Class,Standard,Date,Day,TimeIn,TimeOut,Status from Attendance where Standard='" & ComboBox3.Text & "' AND Date >= '" & DateTimePicker1.Value.Date & "' AND Date <= '" & DateTimePicker2.Value.Date & "'"
            End If

            Dim cmd = New SqlCommand(sqlstr, mysqlconn)

            'Dim da As SqlDataAdapter = New SqlDataAdapter()
            'da.SelectCommand = cmd
            'Dim dt As DataTable = New DataTable()
            'da.Fill(dt)
            'Dim bs As BindingSource = New BindingSource()
            'bs.DataSource = dt
            'DataGridView1.DataSource = dt
            'da.Update(dt)

            Dim adapterr = New SqlDataAdapter(sqlstr, mysqlconn2)

            adapterr.Fill(report1source)

            Dim sqlReader As SqlDataReader = cmd.ExecuteReader
            For i As Integer = 1 To sqlReader.FieldCount
                Dim li As ListViewItem
                ListView1.BeginUpdate()
                While sqlReader.Read
                    li = ListView1.Items.Add(sqlReader("StudentId"))
                    li.SubItems.Add(sqlReader("Name").ToString())
                    li.SubItems.Add(sqlReader("Class").ToString())
                    li.SubItems.Add(sqlReader("Standard").ToString())
                    li.SubItems.Add(sqlReader("Date"))
                    li.SubItems.Add(sqlReader("Day").ToString())
                    li.SubItems.Add(sqlReader("TimeIn").ToString())
                    li.SubItems.Add(sqlReader("TimeOut").ToString())
                    li.SubItems.Add(sqlReader("Status").ToString())
                    'li.SubItems.Add("??")
                    If li.Index Mod 3 = 0 Then
                        li.BackColor = Color.LightBlue
                    End If
                End While
                ListView1.EndUpdate()
            Next
            mysqlconn.Close()
            cmd.Dispose()
            sqlReader.Dispose()
            Label5.Text = ListView1.Items.Count
            mysqlconn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
    '    ToolStripStatusLabel2.Text = ListView1.Items.Count
    '    If String.IsNullOrWhiteSpace(ComboBox1.Text) Then
    '        nameemodule = "All"
    '    Else
    '        nameemodule = ComboBox1.Text
    '    End If
    '    date1 = DateTimePicker1.Text
    '    date2 = DateTimePicker2.Text

    '    For i As Integer = 0 To ListView1.Items.Count - 1

    '        Try
    '            If String.IsNullOrWhiteSpace(ListView1.Items(i).SubItems(3).Text) Or String.IsNullOrWhiteSpace(ListView1.Items(i).SubItems(4).Text) Then

    '            Else

    '                Dim dateOne = DateTime.ParseExact(ListView1.Items(i).SubItems(3).Text, "hh:mm:ss tt", New CultureInfo("en-US"))
    '                Dim dateTwo = DateTime.ParseExact(ListView1.Items(i).SubItems(4).Text, "hh:mm:ss tt", New CultureInfo("en-US"))

    '                Dim timeSpan As TimeSpan = dateTwo - dateOne
    '                Dim difDays As Integer = timeSpan.Days
    '                Dim difHr As Integer = timeSpan.Hours
    '                Dim difMin As Integer = timeSpan.Minutes
    '                Dim difsec As Integer = timeSpan.Seconds

    '                Dim difminn As Integer = timeSpan.TotalMinutes   'get 0 hours although 3 days difference
    '                Dim remainder As Single = Math.Round(difminn / 60, 2)
    '                ListView1.Items(i).SubItems(5).Text = difHr & " hrs : " & difMin & " min : " & difsec & " sec"
    '                'ITalk_Listview1.Items(i).SubItems(8).Text = remainder & " hrs"
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try

    '    Next
    'End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy Then
        Else
            ListView1.Items.Clear()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        'printss.Close()
        'Dim rds = New ReportDataSource("report1", report1source.Tables(0))
        'printss.ReportViewer1.LocalReport.DataSources.Clear()
        'printss.ReportViewer1.LocalReport.DataSources.Add(rds)
        'printss.ReportViewer1.LocalReport.ReportEmbeddedResource = "ClockSmart.Report1.rdlc"

        'Dim Name As New ReportParameter("Name", nameemodule)
        'Dim fromm As New ReportParameter("from", date1)
        'Dim Too As New ReportParameter("To", date2)

        'printss.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Name})
        'printss.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {fromm})
        'printss.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {Too})


        'printss.ReportViewer1.ShowParameterPrompts = True
        'printss.ReportViewer1.PrinterSettings.DefaultPageSettings.Landscape = False
        'printss.ReportViewer1.RefreshReport()
        'printss.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) 

    End Sub
End Class
