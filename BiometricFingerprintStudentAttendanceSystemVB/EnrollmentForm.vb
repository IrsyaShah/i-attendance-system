Imports System.Data.SqlClient
Imports System.IO


Public Class EnrollmentForm

    Public Data As AppData
    Dim counter As Integer = 0
    Dim mysqlconn As SqlConnection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim id As String

    Sub New(ByVal data As AppData)
        InitializeComponent()
        Me.Data = data
        ExchangeData(False)
        AddHandler data.OnChange, AddressOf OnDataChange

    End Sub

    Private Sub OnDataChange()
        ExchangeData(False)
    End Sub

    Public Sub ExchangeData(ByVal read As Boolean)
        If (read) Then
            Data.EnrolledFingersMask = EnrollmentControl.EnrolledFingerMask
            Data.MaxEnrollFingerCount = EnrollmentControl.MaxEnrollFingerCount
            Data.Update()
        Else
            EnrollmentControl.EnrolledFingerMask = Data.EnrolledFingersMask
            EnrollmentControl.MaxEnrollFingerCount = Data.MaxEnrollFingerCount
        End If
    End Sub

    Sub EnrollmentControl_OnEnroll(ByVal Control As Object, ByVal Finger As Integer, ByVal Template As DPFP.Template, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) Handles EnrollmentControl.OnEnroll
        If (Data.IsEventHandlerSucceeds) Then
            Data.Templates(Finger - 1) = Template
            ExchangeData(True)
            ListEvents.Items.Insert(0, String.Format("OnEnroll: finger {0}", Finger))
            saveme(Finger, Template)
            counter += 1
        Else
            EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Failure
        End If
    End Sub

    Sub EnrollmentControl_OnDelete(ByVal Control As Object, ByVal Finger As Integer, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) Handles EnrollmentControl.OnDelete
        If (Data.IsEventHandlerSucceeds) Then
            Data.Templates(Finger - 1) = Nothing
            ExchangeData(True)
            ListEvents.Items.Insert(0, String.Format("OnDelete: finger {0}", Finger))
            counter -= 1
            deleteprint(Finger, Data.EnrolledFingersMask)
        Else
            EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Failure
        End If
    End Sub

    Private Sub EnrollmentControl_OnCancelEnroll(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles EnrollmentControl.OnCancelEnroll
        ListEvents.Items.Insert(0, String.Format("OnCancelEnroll: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub EnrollmentControl_OnComplete(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles EnrollmentControl.OnComplete
        ListEvents.Items.Insert(0, String.Format("OnComplete: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub EnrollmentControl_OnFingerRemove(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles EnrollmentControl.OnFingerRemove
        ListEvents.Items.Insert(0, String.Format("OnFingerRemove: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub EnrollmentControl_OnFingerTouch(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles EnrollmentControl.OnFingerTouch
        ListEvents.Items.Insert(0, String.Format("OnFingerTouch: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub EnrollmentControl_OnReaderConnect(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles EnrollmentControl.OnReaderConnect
        ListEvents.Items.Insert(0, String.Format("OnReaderConnect: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub EnrollmentControl_OnReaderDisconnect(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles EnrollmentControl.OnReaderDisconnect
        ListEvents.Items.Insert(0, String.Format("OnReaderDisconnect: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub EnrollmentControl_OnSampleQuality(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32, ByVal CaptureFeedback As DPFP.Capture.CaptureFeedback) Handles EnrollmentControl.OnSampleQuality
        ListEvents.Items.Insert(0, String.Format("OnSampleQuality: {0}, finger {1}, {2}", ReaderSerialNumber, Finger, CaptureFeedback))
    End Sub

    Private Sub EnrollmentControl_OnStartEnroll(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles EnrollmentControl.OnStartEnroll
        ListEvents.Items.Insert(0, String.Format("OnStartEnroll: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub EnrollmentForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Admin.loadenrolleddata()
    End Sub

    Private Sub EnrollmentForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListEvents.Items.Clear()
        'txtPersonId.Text = Form1.ComboBox1.SelectedItem
    End Sub

    Private Sub CloseButton_Click(sender As System.Object, e As System.EventArgs)

        'If counter <> 3 Then
        'MsgBox("3 different fingers need to be enrolled")
        'Else
        Me.Close()
        'Form1.Panel1.BackgroundImage = My.Resources.punchclock_app
        'End If

    End Sub

    Sub saveme(ByVal Finger As Integer, ByVal Templatee As DPFP.Template)
        Dim cmd As New SqlCommand

        mysqlconn = New SqlConnection
        mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"

        Dim sup As Integer = 0
        Dim dr As SqlDataReader
        Dim query As String

        mysqlconn.Open()

        Try
            query = "select count(*) as nm from new_enrollment where personnelid = '" & txtPersonId.Text & "'"
            If mysqlconn.State = ConnectionState.Closed Then mysqlconn.Open()
            cmd = New SqlCommand(query, mysqlconn)
            dr = cmd.ExecuteReader()
            If dr.Read = True Then
                sup = dr("nm")
            End If
            mysqlconn.Close()
            dr.Close()
        Catch ex As Exception

        End Try

        If sup > 0 Then
            Using sqlCommand As New SqlCommand()
                With sqlCommand
                    .CommandText = "update new_enrollment set fingerdata" & Finger & " =@fingerdata,fingermask = @fingermask where personnelid = '" & txtPersonId.Text & "'  "
                    .Connection = mysqlconn
                    .CommandType = CommandType.Text
                    '.Parameters.AddWithValue("@personnelid", Form1.ComboBox1.SelectedItem)
                    .Parameters.AddWithValue("@fingermask", EnrollmentControl.EnrolledFingerMask)
                    Dim pp1 As New SqlParameter("@fingerdata", SqlDbType.Image)
                    Dim ms1 As New MemoryStream()
                    Templatee.Serialize(ms1)
                    Dim data As Byte() = ms1.GetBuffer()
                    pp1.Value = data
                    .Parameters.Add(pp1)
                End With
                Try
                    If mysqlconn.State = ConnectionState.Closed Then mysqlconn.Open()
                    sqlCommand.ExecuteNonQuery()
                    mysqlconn.Close()

                Catch ex As SqlException
                    MsgBox(ex.ToString)
                    Exit Sub
                End Try
            End Using
        Else

            Dim comd As New SqlCommand
            Dim cn As New SqlConnection
            cn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
            comd.CommandType = System.Data.CommandType.Text

            comd.CommandText = "Insert into new_enrollment (personnelid,fingerdata" & Finger & ",fingermask) Values ('" & txtPersonId.Text & "', @fingerdata,@fingermask)"
            Dim pp1 As New SqlParameter("@fingerdata", SqlDbType.Image)
            Dim ms1 As New MemoryStream()
            Templatee.Serialize(ms1)
            Dim data As Byte() = ms1.GetBuffer()
            pp1.Value = data
            comd.Parameters.Add(pp1)
            comd.Parameters.AddWithValue("@fingermask", EnrollmentControl.EnrolledFingerMask)
            comd.Connection = cn
            cn.Open()

            'Run Query
            comd.ExecuteNonQuery()
            cn.Close()
            '

            'Using sqlCommand As New SqlCommand()
            '    With sqlCommand
            '        .CommandText = "insert into new_enrollment (personnelid,fingerdata" & Finger & ",fingermask) values ('" & Form1.txtEmpID.Text & "',@fingerdata,@fingermask) "
            '        .Connection = mysqlconn
            '        .CommandType = CommandType.Text
            '        '.Parameters.AddWithValue("@personnelid", id)
            '        .Parameters.AddWithValue("@fingermask", EnrollmentControl.EnrolledFingerMask)
            '        Dim pp1 As New SqlParameter("@fingerdata", SqlDbType.Image)
            '        Dim ms1 As New MemoryStream()
            '        Templatee.Serialize(ms1)
            '        Dim data As Byte() = ms1.GetBuffer()
            '        pp1.Value = data
            '        .Parameters.Add(pp1)
            '    End With
            Try

                'If mysqlconn.State = ConnectionState.Closed Then mysqlconn.Open()
                'sqlCommand.ExecuteNonQuery()
                'mysqlconn.Close()
            Catch ex As SqlException
                MsgBox(ex.ToString)
                Exit Sub
            End Try
            'End Using
        End If
    End Sub


    Sub deleteprint(ByVal finger As Integer, ByVal fingermask As Object)
        Try
            Dim mysqlconn = New SqlConnection
            mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"
            Dim query = "update new_enrollment set fingerdata" & finger & " = null where personnelid = '" & txtPersonId.Text & "';update new_enrollment set fingermask = " & Data.EnrolledFingersMask & " where personnelid = '" & txtPersonId.Text & "' "
            If mysqlconn.State = ConnectionState.Closed Then mysqlconn.Open()
            cmd = New SqlCommand(query, mysqlconn)
            cmd.ExecuteNonQuery()
            mysqlconn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Sub loadfingeralreadytaken()
        Dim mysqlconn = New SqlConnection
        mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"

        Dim sup As Integer = 0
        Dim dr As SqlDataReader
        Dim query As String

        mysqlconn.Open()

        Try
            query = "select fingermask from new_enrollment where personnelid = '" & txtPersonId.Text & "'"
            If mysqlconn.State = ConnectionState.Closed Then mysqlconn.Open()
            cmd = New SqlCommand(query, mysqlconn)
            dr = cmd.ExecuteReader()
            If dr.Read = True Then
                EnrollmentControl.EnrolledFingerMask = Convert.ToInt32((dr("fingermask")))
                Data.EnrolledFingersMask = Convert.ToInt32((dr("fingermask")))
            End If
            mysqlconn.Close()
            dr.Close()
        Catch ex As Exception

        End Try
    End Sub



    Private Sub EnrollmentForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        loadfingeralreadytaken()
        'id = Form1.ComboBox1.SelectedItem
    End Sub

    Private Sub CloseButton_Click_1(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    'Protected Overridable Sub Process(ByVal Sample As DPFP.Sample)
    '    ConvertSampleToBitmap(Sample)
    'End Sub

    'Protected Function ConvertSampleToBitmap(ByVal Sample As DPFP.Sample) As Bitmap
    '    Dim convertor As New DPFP.Capture.SampleConversion()  ' Create a sample convertor.
    '    Dim bitmap As Bitmap = Nothing              ' TODO: the size doesn't matter
    '    convertor.ConvertToPicture(Sample, bitmap)

    '    Try
    '        Invoke(New FunctionCall(AddressOf _picturebox1draw), bitmap)
    '    Catch ex As Exception

    '    End Try

    '    Return bitmap
    'End Function

    'Sub _picturebox1draw(ByVal bmp)
    '    PictureBox1.Image = New Bitmap(bmp, 157, 168)
    'End Sub
End Class