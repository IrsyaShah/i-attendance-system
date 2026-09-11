Imports System.Data.SqlClient
Imports System.IO

Public Class StudentIn
    Dim mysqlconn As SqlConnection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim tflag As Integer
    Dim secs As Integer
    Dim mins As Integer

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
                    TimeIn()
                    Exit For ' success
                End If
            End If
            plo += 1
        Next
        If Not res.Verified Then
            EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Failure
            PictureBox2.Image = My.Resources.question_mark_PNG66
            TextBox1.Text = ""
            txtName.Text = ""
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

            nm = "select Name,Class,Standard,Passport from personnel where StudentId ='" & identity & "'"
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
            Invoke(New FunctionCall(AddressOf setclass), kelas)
            Invoke(New FunctionCall(AddressOf setstandard), tahap)

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
        txtName.Text = name
    End Sub
    Public Sub TimeIn()
        Try
            'Connection String
            Dim constr As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
            Using cnn As SqlConnection = New SqlConnection(constr)
                Using com As SqlCommand = New SqlCommand("SELECT StudentId FROM Attendance WHERE StudentId = '" & TextBox1.Text & "' and Date = '" & System.DateTime.Now.ToShortDateString() & "'")
                    com.CommandType = CommandType.Text
                    com.Connection = cnn
                    cnn.Open()
                    Using sdr As SqlDataReader = com.ExecuteReader()
                        If sdr.Read() Then
                            'MsgBox("Duplicate Time-In Detected", MsgBoxStyle.Information, "Time and Attendance System")
                            cnn.Close()
                        Else

                            Dim comd As New SqlCommand
                            Dim cn As New SqlConnection
                            cn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
                            comd.CommandType = System.Data.CommandType.Text

                            comd.CommandText = "Insert into Attendance (StudentId,Name,Date,Day,TimeIn,Class,Standard,Status) Values ('" & TextBox1.Text & "','" & txtName.Text & "','" & System.DateTime.Now.ToShortDateString() & "','" & System.DateTime.Now.ToString("dddd") & "','" & System.DateTime.Now.ToShortTimeString() & "','" & txtClass.Text & "','" & txtStandard.Text & "','" & txtStatus.Text & "')"
                            'comd.Parameters.AddWithValue("@pic", picc)
                            comd.Connection = cn
                            cn.Open()

                            'pic.Image.Save(AppDomain.CurrentDomain.BaseDirectory + txtUserId.Text + ".jpg")

                            'Run Query
                            comd.ExecuteNonQuery()
                            cn.Close()
                            ListView1.Items.Clear()
                            BackgroundWorker1.RunWorkerAsync()
                            'Reset()
                            'MsgBox("Time-In Attendance Recorded", MsgBoxStyle.Information, "Time and Attendance System")

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
        txtName.Text = Nothing
        PictureBox1.Image = My.Resources.photo
    End Sub

    Private Sub StudentIn_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim mysqlconn = New SqlConnection
        mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
        mysqlconn.Open()
        Dim females As Integer = 0
        Dim males As Integer = 0
        Dim sqlstr As String = "select StudentId,Name,Date,Day,TimeIn,TimeOut,Class,Standard,Status from Attendance where Date = '" & System.DateTime.Now.ToShortDateString() & "'"
        Dim cmd = New SqlCommand(sqlstr, mysqlconn)
        Dim sqlReader As SqlDataReader = cmd.ExecuteReader
        For i As Integer = 1 To sqlReader.FieldCount
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

    End Sub

    Public Sub StudentIn_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If mins <= 2 Then
            txtStatus.Text = " Present"
        End If

        If mins > 2 And mins < 5 Then
            txtStatus.Text = "Late"
        End If

        If mins >= 5 Then
            txtStatus.Text = "Late"
        End If
    End Sub
    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        'timer2 will be used to empty the textbox1 for the new data. the timer interval is set to 1 second. 
        txtStatus.Text = ""
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick

        secs = secs + 1
        lblsecs.Text = secs
        lblmins.Text = mins
        If secs = 60 Then
            secs = 0
            mins = mins + 1
        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
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