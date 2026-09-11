Imports System.Data.SqlClient
Imports System.Data
Imports System.IO.Directory
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Public Class Export_Student_Attendance
    Private Sub btnBrowse_Click_1(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'Initialize the objects before use
        Dim dataAdapter As New SqlClient.SqlDataAdapter()
        Dim dataSet As New DataSet
        Dim command As New SqlClient.SqlCommand
        Dim datatableMain As New System.Data.DataTable()
        Dim connection As New SqlClient.SqlConnection

        'Assign your connection string to connection object
        connection.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
        command.Connection = connection
        command.CommandType = CommandType.Text
        'You can use any command select
        command.CommandText = "Select Id,Studentid as'Student ID',Name,Class,Standard,Date,Day,TimeIn,TimeOut,Status From Attendance where Class = '" & txtClass.Text & "' and Standard = '" & txtStandard.Text & "' and Date = '" & txtDate.Text & "' "
        dataAdapter.SelectCommand = command


        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Try
            If f.ShowDialog() = DialogResult.OK Then
                'This section help you if your language is not English.
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
                Dim oExcel As Excel.Application
                Dim oBook As Excel.Workbook
                Dim oSheet As Excel.Worksheet
                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Add(Type.Missing)
                oSheet = oBook.Worksheets(1)

                Dim misValue As Object = System.Reflection.Missing.Value
                'Dim i As Integer
                'Dim j As Integer
                Dim dc As System.Data.DataColumn
                Dim dr As System.Data.DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0

                'Fill data to datatable
                connection.Open()
                dataAdapter.Fill(datatableMain)
                connection.Close()


                'Export the Columns to excel file
                For Each dc In datatableMain.Columns
                    colIndex = colIndex + 1
                    oSheet.Cells(1, colIndex) = dc.ColumnName
                Next

                'Export the rows to excel file
                For Each dr In datatableMain.Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In datatableMain.Columns
                        colIndex = colIndex + 1
                        oSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next

                'Set final path
                Dim fileName As String = "\Student Record Attendance" + ".xls"
                Dim finalPath = f.SelectedPath + fileName
                txtPath.Text = finalPath
                oSheet.Columns.AutoFit()
                'Save file in final path
                oBook.SaveAs(finalPath, XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)



                'Release the objects
                ReleaseObject(oSheet)
                oBook.Close(False, Type.Missing, Type.Missing)
                ReleaseObject(oBook)
                oExcel.Quit()
                ReleaseObject(oExcel)
                'Some time Office application does not quit after automation: so i am calling GC.Collect method.
                GC.Collect()

                'MessageBox.Show("Export done successfully!")
                MessageBox.Show("Record exported successfully!", "Student Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FillGridView()
                txtClass.Text = ""
                txtPath.Text = ""
                txtStandard.Text = ""
                txtDate.Text = ""

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

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

    Private Sub ExportEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillGridView()
        AutoDisplayClass()
        AutoDisplayStandard()
        AutoDisplayDate()
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
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