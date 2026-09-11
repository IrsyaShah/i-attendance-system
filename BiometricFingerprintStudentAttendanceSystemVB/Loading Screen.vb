Public Class Loading_Screen

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        'Percentage value equals to progress bar value
        lblPercent.Text = Guna2ProgressBar1.Value & "%"
        Guna2ProgressBar1.Value += 1

        'Output if value is 10%
        If Guna2ProgressBar1.Value > 10 Then
            lblText.Text = "Loading ... Please wait"
        End If

        'Output if value is 35%
        If Guna2ProgressBar1.Value > 35 Then
            lblText.Text = "I - Attendance will change your future !"
        End If

        'Output if value is 65%
        If Guna2ProgressBar1.Value > 65 Then
            lblText.Text = "Hold on, it's almost finished."
        End If

        'Output if value is 80% 
        If Guna2ProgressBar1.Value > 80 Then
            lblText.Text = "Connecting to I - Attendance System ..."
        End If

        'Output if value is 95% 
        If Guna2ProgressBar1.Value = 95 Then
            lblText.Text = "Launching the Application."

            Login.Show()       'Go to Login Form
            Me.Hide()          'Close this Form
            Timer1.Dispose()    'Time will auto close
        End If
    End Sub
End Class