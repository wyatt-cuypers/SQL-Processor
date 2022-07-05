Imports System.IO

Public Class frmMain

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mod1.Main()
        txtTime.Text = Date.Now
        My.Computer.FileSystem.WriteAllText(sLogFileName, Date.Now & " - PROGRAM START" & Environment.NewLine, True)
        lblVersion.Text = "Version: " & Application.ProductVersion
        iconTray.Visible = False
    End Sub

    'Shows the settings form when the File/Setup button is clicked
    Private Sub SetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuSetup.Click
        frmConnect.Show()
    End Sub

    'Refreshes the status textbox
    Private Sub StatusTextBox_TextChanged(sender As Object, e As EventArgs) Handles txtStatus.TextChanged
        txtStatus.Refresh()
    End Sub

    'Hides the main form when clicked
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Me.Hide()
        iconTray.Visible = True
    End Sub

    'Prevents the application from closing when the red x in the top right is clicked
    'Continues to run in the background. Users can reopen the form by clicking the application icon
    'in the "Show Hidden Icons" tray
    Private Sub MainForm_Close(sender As Object, e As FormClosingEventArgs) Handles MyBase.Closing
        Me.Hide()
        iconTray.Visible = True
        e.Cancel = True
    End Sub

    'Opens the main form when the button is clicked
    Private Sub OpenWindowMenu_Click(sender As Object, e As EventArgs) Handles OpenWindowMenu.Click
        Me.WindowState = vbNormal
        iconTray.Visible = False
        Me.Show()
    End Sub

    'Changes the last error textbox to visible and temporarily displays the error message
    Private Sub LastErrorTextBox_TextChanged(sender As Object, e As EventArgs) Handles txtLastError.TextChanged
        If txtLastError.Text = "" Then
            txtLastError.Visible = False
        Else
            txtLastError.Visible = True
        End If
        txtLastError.Refresh()
    End Sub

    'The only way to actually close the application completely
    'Users must double-click the countdown label 3 times in order for the application to quit
    Private Sub lblCountdown_DoubleClick(sender As Object, e As EventArgs) Handles lblCountdown.MouseDoubleClick
        Static clickCounter As Integer
        clickCounter += clickCounter + 1
        If clickCounter >= 6 Then
            My.Computer.FileSystem.WriteAllText(sLogFileName, Date.Now & " - PROGRAM STOP - END" & Environment.NewLine, True)
            Application.Exit()
        End If
    End Sub

    'Continually updates the database connection status
    Public Sub Set_DB_Connect_Disconnect_Display()
        Try
            If bDBConnected Then
                txtStatus.Text = "Connected"
                txtStatus.ForeColor = Color.Green
                txtStatus.Visible = True
                iconTray.Icon = New Icon(Directory.GetCurrentDirectory() & "\OK1.ico")
                iconTray.Text = "SQL Processor 2022 - Connected"
            Else
                txtStatus.Text = "Not Connected"
                txtStatus.ForeColor = Color.Red
                txtStatus.Visible = Not txtStatus.Visible
                If txtStatus.Visible Then
                    iconTray.Icon = New Icon(Directory.GetCurrentDirectory() & "\NotOK1.ico")
                Else
                    iconTray.Icon = New Icon(Directory.GetCurrentDirectory() & "\NotOK2.ico")
                End If
                iconTray.Text = "SQL Processor - Disconnected"
            End If
            txtStatus.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    'Executed every second
    'After the number of seconds specified by the user in the settings form (or the default of 10),
    'the Process_Files method is called, and the countdown timer is reset to the specified number of seconds
    Private Sub SecondsTimer_Tick(sender As Object, e As EventArgs) Handles tmrSecond.Tick
        Static nSecondCounter As Long '= nDelaySeconds
        Try
            If Me.WindowState = FormWindowState.Minimized And Me.Visible Then
                Me.Hide()
            End If
            txtTime.Text = Date.Now
            Set_DB_Connect_Disconnect_Display()
            If sDB_Server = "" _
              Or sDB_Database = "" _
              Or sDB_SourcePath = "" Then
                lblCountdown.Text = "Setup is Invalid"
                Exit Sub
            End If
            If bProcessingNewFilesActive Then
                Exit Sub
            End If
            nSecondCounter = nSecondCounter - 1
            If nSecondCounter <= 0 Then
                bProcessingNewFilesActive = True
                lblCountdown.Text = "Processing"
                lblCountdown.Refresh()
                Process_Files()
                nSecondCounter = nDelaySeconds
                bProcessingNewFilesActive = False
            End If
            lblCountdown.Text = "Restart Counter: " & CStr(nSecondCounter)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    
    'After x amount of hours determined by the user in the settings form (or the default of 24 hours), the timer looks
    'every hour to see how old the files are in the Processed folder. If they are older than x hours, since they have 
    'already been stored in the database, they are deleted. Each deletion is logged in the form's listbox 
    Private Sub DeleteTimer_Tick(sender As Object, e As EventArgs) Handles tmrDelete.Tick
        Static nDeleteCount As Integer = 0
        Dim objSec As New Stopwatch
        Dim oFolder As String = sDB_SourcePath & "\" & PROCESSED_FOLDER
        objSec.Start()
        Try
            lblDeleteTitle.Visible = True
            lblDelete.Visible = True
            For Each s In Directory.GetFiles(oFolder)
                lblDeleteTitle.Text = "Checking: "
                lblDelete.Text = My.Computer.FileSystem.GetName(s)
                If DateDiff(DateInterval.Hour, File.GetLastWriteTime(s), Now()) >= nDeleteAfterXHours Then
                    lblDeleteTitle.Text = "Deleting: "
                    lblDelete.Text = My.Computer.FileSystem.GetName(s)
                    File.Delete(s)
                    nDeleteCount = nDeleteCount + 1
                End If
                Application.DoEvents()
            Next
            lblDelete.Text = ""
            lblDeleteTitle.Visible = False
            lblDelete.Visible = False
            Add_History_Entry(Date.Now & " - " & Strings.Right(Space(3) & Format((Int(objSec.ElapsedMilliseconds / 1000)), "0"), 3) + "." + Strings.Left(Format((objSec.ElapsedMilliseconds Mod 1000), "000"), 3) & " Secs - " & Space(5) & "Deleted " & Trim(Str(nDeleteCount)) & " old files")
            objSec.Reset()
            nDeleteCount = 0
        Catch ex As Exception
            lError = ex.HResult
            sErrorDesc = ex.Message
            sErrorHndl = "TimerDelete_Timer"
            Show_Error(False, lError, sErrorDesc, sErrorHndl)
            lblDelete.Text = ""
            lblDeleteTitle.Visible = False
            lblDelete.Visible = False
        End Try
    End Sub

End Class
