Imports System.Data.SqlClient
Imports System.IO
Public Class StudentOut
    Dim mysqlconn As SqlConnection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand

    Sub OnComplete(ByVal Control As Object, ByVal FeatureSet As DPFP.FeatureSet, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) Handles VerificationControl.OnComplete
        Dim ver As New DPFP.Verification.Verification()
        Dim res As New DPFP.Verification.Verification.Result()
        Dim plo As Integer = 0

        For Each template As DPFP.Template In fptemplist   ' Compare feature set with all stored templates:
            If Not template Is Nothing Then                     '   Get template from storage.
                ver.Verify(FeatureSet, template, res)           '   Compare feature set with particular template.
                'Data.IsFeatureSetMatched = res.Verified         '   Check the result of the comparison
                FalseAcceptRate.Text = res.FARAchieved.ToString          '   Determine the current False Accept Rate
                If res.Verified Then
                    EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Success
                    PictureBox2.Image = My.Resources.check_mark_symbol_transparent_background_22
                    Dim name As String = listofnames(plo)
                    TextBox1.Text = listofnames(plo)
                    autoselect(name)
                    TimeOut()
                    Exit For ' success
                End If
            End If
            plo += 1
        Next
        If Not res.Verified Then
            EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Failure
            PictureBox2.Image = My.Resources.question_mark_PNG66
            TextBox1.Text = ""
            'TextBox2.Text = ""
            Guna2TextBox1.Text = ""
        End If

    End Sub

    Sub autoselect(ByVal identity As String)
        Try
            Dim arrImage() As Byte = Nothing
            Dim dr As SqlDataReader
            Dim nm As String
            Dim name As String = ""
            Dim kelas As String = ""
            Dim tahap As String = ""
            Dim dept As String = ""
            Dim jobtitle As String = ""
            Dim mysqlconn = New SqlConnection
            mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"

            Dim name2 As String = identity
            Dim dept2 As String = ""

            If mysqlconn.State = ConnectionState.Closed Then
                mysqlconn.Open()
            End If

            nm = "select Name,Class,Standard,Passport from personnel where Studentid ='" & identity & "'"
            Dim cmd As New SqlCommand
            cmd.CommandText = nm
            cmd.Connection = mysqlconn
            dr = cmd.ExecuteReader
            If (dr.Read() = True) Then
                'jobtitle = dr("JobTitle")
                name = dr("Name")
                kelas = dr("Class")
                tahap = dr("Standard")

                Dim pByte As Byte()
                pByte = dr("Passport")
                Dim MS As MemoryStream = New MemoryStream(pByte)
                PictureBox1.Image = New Bitmap(MS)
            End If

            dr.Close()
            mysqlconn.Close()
            cmd.Dispose()
            If String.IsNullOrWhiteSpace(name) Then
                'jobtitle = "No Job title"
                name = "No Name"
            End If

            'Invoke(New FunctionCall(AddressOf setjobtitle), jobtitle)

            Invoke(New FunctionCall(AddressOf setname), name)

        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try


    End Sub
    'Private Sub setjobtitle(ByVal jobtitle As String)
    '    TextBox2.Text = jobtitle
    'End Sub
    Private Sub setstandard(ByVal tahap As String)
        txtStandard.Text = tahap
    End Sub

    Private Sub setclass(ByVal kelas As String)
        txtClass.Text = kelas
    End Sub

    Private Sub setname(ByVal name As String)
        Guna2TextBox1.Text = name
    End Sub

    Public Sub TimeOut()
        Try
            Dim Tout As String = ""

            'Connection String
            Dim constr As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
            Using cnn As SqlConnection = New SqlConnection(constr)
                Using com As SqlCommand = New SqlCommand("SELECT TimeOut FROM Attendance WHERE StudentId = '" & TextBox1.Text & "' and Date = '" & System.DateTime.Now.ToShortDateString() & "' ")
                    com.CommandType = CommandType.Text
                    com.Connection = cnn
                    cnn.Open()
                    Using sdr As SqlDataReader = com.ExecuteReader()

                        If sdr.Read() Then
                            Tout = sdr("TimeOut").ToString()
                            cnn.Close()

                        End If

                        If String.IsNullOrWhiteSpace(Tout) Then
                            Dim comd As New SqlCommand
                            Dim cn As New SqlConnection
                            cn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"

                            comd = New SqlCommand("update Attendance set TimeOut=@tout where StudentId=@id and Date=@dat", cn)
                            cn.Open()
                            comd.Parameters.AddWithValue("@id", TextBox1.Text)
                            comd.Parameters.AddWithValue("@dat", System.DateTime.Now.ToShortDateString())
                            comd.Parameters.AddWithValue("@tout", System.DateTime.Now.ToShortTimeString())
                            comd.ExecuteNonQuery()

                            cn.Close()
                            ListView1.Items.Clear()
                            BackgroundWorker1.RunWorkerAsync()
                            'Reset()
                            'MsgBox("Time-out Attendance Recorded", MsgBoxStyle.Information, "Time and Attendance System")
                        Else
                            'MsgBox("Duplicate Time-Out Detected", MsgBoxStyle.Information, "Time and Attendance System")
                        End If


                    End Using
                    'con.Close()
                End Using
            End Using


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub Reset()
        TextBox1.Text = Nothing
        Guna2TextBox1.Text = Nothing
        PictureBox1.Image = My.Resources.photo
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim mysqlconn = New SqlConnection
            mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
            mysqlconn.Open()
            Dim females As Integer = 0
            Dim males As Integer = 0
            Dim sqlstr As String = "select StudentId,Name,Date,Day,TimeIn,TimeOut,Class,Standard,Status from Attendance where Date = '" & System.DateTime.Now.ToShortDateString() & "'"
            Dim cmd = New SqlCommand(sqlstr, mysqlconn)
            Dim sqlReader As SqlDataReader = cmd.ExecuteReader
            For i As Integer = 1 To sqlReader.FieldCount

                'Dim da As SqlDataAdapter = New SqlDataAdapter()
                '    da.SelectCommand = cmd
                '    Dim dt As DataTable = New DataTable()
                '    da.Fill(dt)
                '    Dim bs As BindingSource = New BindingSource()
                '    bs.DataSource = dt
                '    DataGridView1.DataSource = dt
                '    da.Update(dt)



                Dim li As ListViewItem
                ListView1.BeginUpdate()
                While sqlReader.Read
                    li = ListView1.Items.Add(sqlReader("StudentId").ToString())
                    li.SubItems.Add(sqlReader("Name").ToString())
                    li.SubItems.Add(sqlReader("Class").ToString())
                    li.SubItems.Add(sqlReader("Standard").ToString())
                    li.SubItems.Add(sqlReader("Date").ToString())
                    li.SubItems.Add(sqlReader("Day").ToString())
                    li.SubItems.Add(sqlReader("TimeIn").ToString())
                    li.SubItems.Add(sqlReader("TimeOut").ToString())
                    li.SubItems.Add(sqlReader("Status").ToString())
                End While
                ListView1.EndUpdate()
            Next

            mysqlconn.Close()
            cmd.Dispose()
            sqlReader.Dispose()
            Label4.Text = ListView1.Items.Count

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub TimeOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Public Sub TimeOut_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click
        Me.Close()
    End Sub

    Private Sub lblExit_MouseEnter(sender As Object, e As EventArgs) Handles lblExit.MouseEnter
        lblExit.ForeColor = Color.Red
    End Sub

    Private Sub lblExit_MouseLeave(sender As Object, e As EventArgs) Handles lblExit.MouseLeave
        lblExit.ForeColor = Color.Black
    End Sub
End Class