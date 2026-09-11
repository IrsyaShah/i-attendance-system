Imports System.Data.SqlClient
Imports System.IO

Public Class Enroll
    Private Data As AppData
    Private Enroller As EnrollmentForm
    Public WithEvents AppData As AppData
    'Private Templatedata As DPFP.Data

    Dim mysqlconn As SqlConnection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand

    'Public Shared connection = "server= localhost;" _
    '  & "user id=root;" _
    '  & "port= 3306 ;" _
    '  & "password= ;" _
    '  & "database=new_time_and_attendance"
    'Public Shared connection = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AutoDisplayName()
    End Sub

    'Sub New()
    '    InitializeComponent()

    'End Sub

    Private Sub OnDataChange()
        ExchangeData(False)
    End Sub

    Private Sub ExchangeData(ByVal read As Boolean)
        If (read) Then
            Data.EnrolledFingersMask = 0

            Data.MaxEnrollFingerCount = 10

            Data.IsEventHandlerSucceeds = True
            Data.Update()
        Else
            Mask.Value = Data.EnrolledFingersMask
            MaxFingers.Value = Data.MaxEnrollFingerCount
            IsSuccess.Checked = Data.IsEventHandlerSucceeds

           
            'IsFailure.Checked = Not IsSuccess.Checked
            'IsFeatureSetMatched.Checked = Data.IsFeatureSetMatched
            'FalseAcceptRate.Text = Data.FalseAcceptRate.ToString()
            'VerifyButton.Enabled = Data.EnrolledFingersMask > 0
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(txtStaffID.Text) Then
        Else
            'InsertID()

            Data = New AppData()
            AddHandler Data.OnChange, AddressOf OnDataChange
            Enroller = New EnrollmentForm(Data)
            ExchangeData(False)
            startenrollerment()
        End If

    End Sub

    Public Sub InsertID()
        Try
            Dim cmdd As New SqlCommand

            cmdd.CommandType = System.Data.CommandType.Text
            cmdd.CommandText = "Insert into new_enrollment (personnelid) Values ('" & txtName.Text & "')"
            'cmdd.Parameters.AddWithValue("@img", bytes)
            cmdd.Connection = con
            con.Open()

            'Run Query
            cmdd.ExecuteNonQuery()
            con.Close()
            'reset()
            'MsgBox("Submitted Successfully", MsgBoxStyle.Information, "Fingerprint Enrollment Module")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub startenrollerment()
        ExchangeData(True)
        'Enroller.ShowDialog()
        'Enroller.Close()
        Panel1.Controls.Clear()
        Dim frmControl As Form = Enroller
        With frmControl
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .TopLevel = False
            .Dock = DockStyle.Fill
        End With
        Panel1.Controls.Add(Enroller)
        frmControl.Show()
        frmControl.WindowState = FormWindowState.Maximized
        'Me.Text = ComboBox1.Text
        Enroller.txtPersonId.Text = txtStaffID.Text

    End Sub


    Sub save()
        'If Not Directory.Exists(Application.StartupPath & "\Enrolled_Fingers") Then
        '    Directory.CreateDirectory(Application.StartupPath & "\Enrolled_Fingers")
        'End If

        'If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Enrolled_Fingers\" & TextBox1.Text & ".fpt") Then
        '    If MessageBox.Show("User has already been enrolled", "", MessageBoxButtons.YesNo) = DialogResult.No Then
        '        Exit Sub
        '    Else

        '        For Each template As DPFP.Template In Data.Templates

        '        Next

        '        Using fs As IO.FileStream = IO.File.Open(Application.StartupPath & "\Enrolled_Fingers\" & TextBox1.Text & ".fpt", IO.FileMode.Create, IO.FileAccess.Write)
        '            Template.Serialize(fs)
        '        End Using
        '        Try
        '            wait(100)
        '            Speech = CreateObject("sapi.spvoice")

        '            With Speech
        '                .voice = .getvoices.item(0)
        '                '.Volume = 100
        '                '.Rate = 3
        '            End With

        '            'Speech.Speak("Welcome ")
        '            Speech.Speak("Thank you for enrolling")
        '        Catch ex As Exception

        '        End Try

        '    End If
        'Else



        '    Using fs As IO.FileStream = IO.File.Open(Application.StartupPath & "\Enrolled_Fingers\" & ComboBox1.Text & ".fpt", IO.FileMode.Create, IO.FileAccess.Write)
        '        Template.Serialize(fs)
        '    End Using
        'End If

        'Dim cmd As New MySqlCommand

        'mysqlconn = New MySqlConnection
        'mysqlconn.ConnectionString = Choose.connection

        'Using sqlCommand As New MySqlCommand()
        '    With sqlCommand
        '        .CommandText = "update personnel set fingerimage2=@fingerimage2,fingerstring=@fingerstring,dept=@dept where concat(name,'_',personnelid)= '" & ComboBox1.Text & "'"
        '        .Connection = mysqlconn
        '        .CommandType = CommandType.Text

        '        'Dim pbImage1 As Image = PictureBox7.Image
        '        .Parameters.AddWithValue("@fingerstring", Template.ToString)
        '        .Parameters.AddWithValue("@dept", ComboBox2.Text)
        '        'Dim p As New MySqlParameter("@fingerimage", MySqlDbType.VarBinary)
        '        Dim pp As New MySqlParameter("@fingerimage2", MySqlDbType.MediumBlob)

        '        Dim ms As New MemoryStream()
        '        Dim mss As New MemoryStream()

        '        Template.Serialize(ms)
        '        Template.Serialize(mss)
        '        Dim data As Byte() = ms.GetBuffer()
        '        'Dim data2 As Byte() = mss.GetBuffer
        '        pp.Value = data
        '        'p.Value = data
        '        '.Parameters.Add(p)
        '        .Parameters.Add(pp)


        '    End With
        '    Try
        '        If mysqlconn.State = ConnectionState.Closed Then mysqlconn.Open()
        '        sqlCommand.ExecuteNonQuery()
        '        'MsgBox("Data Saved Successfully", MsgBoxStyle.Information, "Finger Saved")

        '    Catch ex As MySqlException
        '        MsgBox("An Error Occurred. " & ex.Number & " – " & ex.Message)
        '        Exit Sub
        '    Finally
        '        mysqlconn.Close()

        '    End Try
        'End Using

        'Panel2.Controls.Clear()
        'Dim frmControl As PictureBox = PictureBox2
        'With frmControl
        '    .Dock = DockStyle.Fill
        'End With
        'Panel2.Controls.Add(frmControl)
        'frmControl.Show()
        'Button2.Enabled = False
        'ComboBox1.Text = ""
        'ComboBox2.Text = ""
        'PictureBox1.Image = My.Resources.S2qIYcp
        'Me.Text = "Home - Enrollment"


        'Dim cmd As New MySqlCommand

        'mysqlconn = New MySqlConnection
        'mysqlconn.ConnectionString = connection

        'Using sqlCommand As New MySqlCommand()
        '    With sqlCommand
        '        .CommandText = "insert into new_enrollement (personnelid,dept,fingerdata1,fingerdata2,fingerdata3) values (@personnelid,@dept,@fingerdata1,@fingerdata2,@fingerdata3) "
        '        .Connection = mysqlconn
        '        .CommandType = CommandType.Text
        '        .Parameters.AddWithValue("@personnelid", template.ToString)
        '        Dim pp1 As New MySqlParameter("@fingerdata1", MySqlDbType.MediumBlob)
        '        Dim pp2 As New MySqlParameter("@fingerdata2", MySqlDbType.MediumBlob)
        '        Dim pp3 As New MySqlParameter("@fingerdata3", MySqlDbType.MediumBlob)

        '        Dim ms1 As New MemoryStream()
        '        Dim ms2 As New MemoryStream()
        '        Dim ms3 As New MemoryStream()

        '        data.template(0).Serialize(ms1)
        '        template.Serialize(mss)
        '        Dim data As Byte() = MS.GetBuffer()
        '        'Dim data2 As Byte() = mss.GetBuffer
        '        pp.Value = data
        '        'p.Value = data
        '        '.Parameters.Add(p)
        '        .Parameters.Add(pp)


        '    End With
        '    Try
        '        If mysqlconn.State = ConnectionState.Closed Then mysqlconn.Open()
        '        sqlCommand.ExecuteNonQuery()
        '        'MsgBox("Data Saved Successfully", MsgBoxStyle.Information, "Finger Saved")

        '    Catch ex As MySqlException
        '        MsgBox("An Error Occurred. " & ex.Number & " – " & ex.Message)
        '        Exit Sub
        '    Finally
        '        mysqlconn.Close()

        '    End Try
        'End Using

    End Sub

    Private Sub Form1_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        loademployees()
    End Sub
    Public Sub AutoDisplayName()
        Try
            Dim con As SqlConnection = Nothing
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("SELECT Name FROM personnel", con)
            Dim ds As DataSet = New DataSet()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "list") 'list can be any name u want

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("Name").ToString())  'columnname same As In query

            Next

            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtName.AutoCompleteCustomSource = col
            txtName.AutoCompleteMode = AutoCompleteMode.Suggest

            con.Close()
        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try

    End Sub

    Sub loademployees()
        Dim mysqlconn = New SqlConnection
        mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"

        Dim sup As Integer = 0
        Dim dr As SqlDataReader
        Dim query As String

        mysqlconn.Open()

        Try
            query = "select concat(namee,'_',personnelid) as nm from personnel"
            If mysqlconn.State = ConnectionState.Closed Then mysqlconn.Open()
            cmd = New SqlCommand(query, mysqlconn)
            dr = cmd.ExecuteReader()
            While dr.Read
                ComboBox1.Items.Add(dr("nm"))
            End While
            mysqlconn.Close()
            dr.Close()
        Catch ex As Exception

        End Try

    End Sub

    'Sub loadenrolleddata()
    '    Dim drt As MySqlDataReader
    '    Dim nm As String

    '    Dim mysqlconn = New MySqlConnection
    '    mysqlconn.ConnectionString = Form1.connection

    '    If mysqlconn.State = ConnectionState.Closed Then
    '        mysqlconn.Open()
    '    End If

    '    nm = "select personnelid,fingerdata1,fingerdata2,fingerdata3,fingerdata4,fingerdata5,fingerdata6,fingerdata7,fingerdata8," _
    '        & "fingerdata9,fingerdata10 from new_enrollment"

    '    'nm = "select personnelid,fingerdata7" _
    '    '   & "from new_enrollment where length(fingerdata7) > 0 "

    '    Dim cmd As New MySqlCommand
    '    cmd.CommandText = nm
    '    cmd.Connection = mysqlconn
    '    drt = cmd.ExecuteReader
    '    'MetroProgressBar1.Maximum = drt.FieldCount
    '    While drt.Read()
    '        Dim mstram As IO.MemoryStream

    '        For i = 1 To 10
    '            Dim fpbytes As Byte()
    '                fpbytes = drt("fingerdata" & i)
    '                mstram = New IO.MemoryStream(fpbytes)
    '            If fpbytes.Length > 0 Then
    '                Dim temp8 As DPFP.Template = New DPFP.Template
    '                temp8.DeSerialize(mstram)
    '                fptemplist.Add(temp8)
    '                listofnames.Add(drt("personnelid"))
    '            End If
    '        Next
    '    End While
    '    drt.Close()
    '    mysqlconn.Close()
    'End Sub

    'Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
    '    loadenrolleddata()
    'End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        MsgBox(listofnames.ToList.Count)
    End Sub

    Sub autoselect(ByVal staffID As String)
        Try
            Dim arrImage() As Byte = Nothing
            Dim dr As SqlDataReader
            Dim nm As String
            Dim name As String = ""
            Dim sID As String = ""
            Dim mysqlconn = New SqlConnection
            mysqlconn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\biometricdb.mdf;Integrated Security=True"

            Dim name2 As String = staffID
            'Dim dept2 As String = ""

            If mysqlconn.State = ConnectionState.Closed Then
                mysqlconn.Open()
            End If

            nm = "select Studentid from personnel where Name ='" & staffID & "'"
            Dim cmd As New SqlCommand
            cmd.CommandText = nm
            cmd.Connection = mysqlconn
            dr = cmd.ExecuteReader
            If (dr.Read() = True) Then
                sID = dr("Studentid")
            End If

            dr.Close()
            mysqlconn.Close()
            cmd.Dispose()
            If String.IsNullOrWhiteSpace(sID) Then
                sID = "No Group"
            End If

            Invoke(New FunctionCall(AddressOf setstaffID), sID)

        Catch ex As SqlException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "")
        End Try


    End Sub

    Private Sub setstaffID(ByVal ssID As String)
        txtStaffID.Text = ssID
    End Sub

    'Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
    '    autoselect(ComboBox1.Text)
    '    'txtEmpID.Text = ComboBox1.SelectedItem
    'End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        autoselect(txtName.Text)
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        txtName.Text = ""
        txtStaffID.Text = ""
        Me.Close()
    End Sub
End Class
