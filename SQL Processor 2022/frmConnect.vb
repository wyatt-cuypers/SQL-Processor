Public Class frmConnect

    Dim bViewPass As Boolean = False

    Private Sub frmConnect_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        frmMain.Hide()
        If intConType = 1 Then
            txtServer.Text = sDB_Server
            txtDatabase.Text = sDB_Database
            txtUser.Text = sDB_User
            txtPassword.Text = sDB_Password
            txtSource.Text = sDB_SourcePath
            txtWait.Text = nDelaySeconds
            txtDelTime.Text = nDeleteAfterXHours
            txtServer.Select()
        ElseIf intConType = 2 Then
            txtServer.Text = sDB_Server
            txtDatabase.Text = sDB_Database
            txtSource.Text = sDB_SourcePath
            txtWait.Text = nDelaySeconds
            txtDelTime.Text = nDeleteAfterXHours
            txtServer.Select()
        End If
    End Sub

    Private Sub ConnectForm_Close(sender As Object, e As FormClosingEventArgs) Handles MyBase.Closing
        Me.Hide()
        frmMain.Show()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txt4Digit.Clear()
        txtPassword.PasswordChar = "*"
        Me.Hide()
        frmMain.Show()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If txt4Digit.Text = Date.Now.ToString("hh") & Date.Now.ToString("mm") Then
            bViewPass = Not bViewPass
        Else
            bViewPass = False
        End If
        If bViewPass Then
            txtPassword.PasswordChar = ""
        Else
            txtPassword.PasswordChar = "*"
        End If
    End Sub

    Private Sub cboConnType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConnType.SelectedIndexChanged
        If cboConnType.SelectedIndex = 0 Then
            intConType = 1
            lblUser.Visible = True
            lblPassword.Visible = True
            txtUser.Visible = True
            txtPassword.Visible = True
            btnView.Visible = True
            txt4Digit.Visible = True
        ElseIf cboConnType.SelectedIndex = 1 Then
            intConType = 2
            lblUser.Visible = False
            lblPassword.Visible = False
            txtUser.Visible = False
            txtPassword.Visible = False
            btnView.Visible = False
            txt4Digit.Visible = False
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If cboConnType.SelectedIndex = 0 Then
            sDB_Server = txtServer.Text
            sDB_Database = txtDatabase.Text
            sDB_User = txtUser.Text
            sDB_Password = txtPassword.Text
            sDB_SourcePath = txtSource.Text
            nDelaySeconds = txtWait.Text
            If nDelaySeconds = 0 Then
                nDelaySeconds = 10
            End If
            nDeleteAfterXHours = txtDelTime.Text
            Store_INI_Values()
            DB_Close()
            DB_Connect()
        ElseIf cboConnType.SelectedIndex = 1 Then
            sDB_Server = txtServer.Text
            sDB_Database = txtDatabase.Text
            sDB_User = ""
            sDB_Password = ""
            sDB_SourcePath = txtSource.Text
            If Not txtWait.Text = "" Then
                nDelaySeconds = txtWait.Text
            Else
                txtWait.Text = 10
                nDelaySeconds = 10
            End If
            If nDelaySeconds = 0 Then
                nDelaySeconds = 10
            End If
            If Not txtDelTime.Text = "" Then
                nDeleteAfterXHours = txtDelTime.Text
            Else
                txtDelTime.Text = 24
                nDeleteAfterXHours = 24
            End If
            Store_INI_Values()
            DB_Close()
            DB_Connect()
        End If
        txt4Digit.Clear()
        txtPassword.PasswordChar = "*"
        Me.Hide()
        frmMain.Show()
    End Sub

End Class