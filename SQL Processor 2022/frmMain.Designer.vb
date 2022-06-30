<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lstHistory = New System.Windows.Forms.ListBox()
        Me.GroupBoxDBStatus = New System.Windows.Forms.GroupBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblDatabase = New System.Windows.Forms.Label()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.txtLastError = New System.Windows.Forms.TextBox()
        Me.mnu = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.tmrDelete = New System.Windows.Forms.Timer(Me.components)
        Me.tmrSecond = New System.Windows.Forms.Timer(Me.components)
        Me.txtTime = New System.Windows.Forms.TextBox()
        Me.TTtxtServer = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblDeleteTitle = New System.Windows.Forms.Label()
        Me.lblDelete = New System.Windows.Forms.Label()
        Me.mnuTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenWindowMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.iconTray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.lblCountdown = New System.Windows.Forms.Label()
        Me.GroupBoxDBStatus.SuspendLayout()
        Me.mnu.SuspendLayout()
        Me.mnuTray.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstHistory
        '
        Me.lstHistory.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstHistory.FormattingEnabled = True
        Me.lstHistory.ItemHeight = 14
        Me.lstHistory.Location = New System.Drawing.Point(12, 201)
        Me.lstHistory.Name = "lstHistory"
        Me.lstHistory.ScrollAlwaysVisible = True
        Me.lstHistory.Size = New System.Drawing.Size(781, 88)
        Me.lstHistory.TabIndex = 0
        '
        'GroupBoxDBStatus
        '
        Me.GroupBoxDBStatus.Controls.Add(Me.txtStatus)
        Me.GroupBoxDBStatus.Controls.Add(Me.txtDatabase)
        Me.GroupBoxDBStatus.Controls.Add(Me.txtServer)
        Me.GroupBoxDBStatus.Controls.Add(Me.lblStatus)
        Me.GroupBoxDBStatus.Controls.Add(Me.lblDatabase)
        Me.GroupBoxDBStatus.Controls.Add(Me.lblServer)
        Me.GroupBoxDBStatus.Location = New System.Drawing.Point(12, 27)
        Me.GroupBoxDBStatus.Name = "GroupBoxDBStatus"
        Me.GroupBoxDBStatus.Size = New System.Drawing.Size(236, 142)
        Me.GroupBoxDBStatus.TabIndex = 1
        Me.GroupBoxDBStatus.TabStop = False
        Me.GroupBoxDBStatus.Text = "DB Status"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(88, 103)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(135, 20)
        Me.txtStatus.TabIndex = 5
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(88, 66)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.ReadOnly = True
        Me.txtDatabase.Size = New System.Drawing.Size(135, 20)
        Me.txtDatabase.TabIndex = 4
        Me.txtDatabase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(88, 26)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.ReadOnly = True
        Me.txtServer.Size = New System.Drawing.Size(135, 20)
        Me.txtServer.TabIndex = 3
        Me.txtServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(7, 106)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 2
        Me.lblStatus.Text = "Status"
        '
        'lblDatabase
        '
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.Location = New System.Drawing.Point(6, 69)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(53, 13)
        Me.lblDatabase.TabIndex = 1
        Me.lblDatabase.Text = "Database"
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(6, 29)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(38, 13)
        Me.lblServer.TabIndex = 0
        Me.lblServer.Text = "Server"
        '
        'txtLastError
        '
        Me.txtLastError.BackColor = System.Drawing.Color.Tomato
        Me.txtLastError.Location = New System.Drawing.Point(254, 27)
        Me.txtLastError.Multiline = True
        Me.txtLastError.Name = "txtLastError"
        Me.txtLastError.Size = New System.Drawing.Size(539, 86)
        Me.txtLastError.TabIndex = 2
        Me.txtLastError.TabStop = False
        Me.txtLastError.Visible = False
        '
        'mnu
        '
        Me.mnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuOptions})
        Me.mnu.Location = New System.Drawing.Point(0, 0)
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(805, 24)
        Me.mnu.TabIndex = 3
        Me.mnu.Text = "File"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "File"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(93, 22)
        Me.mnuExit.Text = "Exit"
        '
        'mnuOptions
        '
        Me.mnuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSetup})
        Me.mnuOptions.Name = "mnuOptions"
        Me.mnuOptions.Size = New System.Drawing.Size(61, 20)
        Me.mnuOptions.Text = "Options"
        '
        'mnuSetup
        '
        Me.mnuSetup.Name = "mnuSetup"
        Me.mnuSetup.Size = New System.Drawing.Size(104, 22)
        Me.mnuSetup.Text = "Setup"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.SystemColors.Control
        Me.lblVersion.ForeColor = System.Drawing.Color.Blue
        Me.lblVersion.Location = New System.Drawing.Point(720, 159)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(62, 13)
        Me.lblVersion.TabIndex = 4
        Me.lblVersion.Text = "Version X.X"
        '
        'tmrDelete
        '
        Me.tmrDelete.Enabled = True
        Me.tmrDelete.Interval = 600000
        '
        'tmrSecond
        '
        Me.tmrSecond.Enabled = True
        Me.tmrSecond.Interval = 1000
        '
        'txtTime
        '
        Me.txtTime.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtTime.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTime.Location = New System.Drawing.Point(12, 175)
        Me.txtTime.Multiline = True
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(781, 23)
        Me.txtTime.TabIndex = 5
        '
        'lblDeleteTitle
        '
        Me.lblDeleteTitle.AutoSize = True
        Me.lblDeleteTitle.Location = New System.Drawing.Point(255, 120)
        Me.lblDeleteTitle.Name = "lblDeleteTitle"
        Me.lblDeleteTitle.Size = New System.Drawing.Size(103, 13)
        Me.lblDeleteTitle.TabIndex = 7
        Me.lblDeleteTitle.Text = "Files To Be Deleted:"
        Me.lblDeleteTitle.Visible = False
        '
        'lblDelete
        '
        Me.lblDelete.AutoSize = True
        Me.lblDelete.Location = New System.Drawing.Point(364, 120)
        Me.lblDelete.Name = "lblDelete"
        Me.lblDelete.Size = New System.Drawing.Size(112, 13)
        Me.lblDelete.TabIndex = 8
        Me.lblDelete.Text = "                                   "
        Me.lblDelete.Visible = False
        '
        'mnuTray
        '
        Me.mnuTray.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenWindowMenu})
        Me.mnuTray.Name = "SysTrayMenu"
        Me.mnuTray.Size = New System.Drawing.Size(151, 26)
        '
        'OpenWindowMenu
        '
        Me.OpenWindowMenu.Name = "OpenWindowMenu"
        Me.OpenWindowMenu.Size = New System.Drawing.Size(150, 22)
        Me.OpenWindowMenu.Text = "Open Window"
        '
        'iconTray
        '
        Me.iconTray.ContextMenuStrip = Me.mnuTray
        Me.iconTray.Icon = CType(resources.GetObject("iconTray.Icon"), System.Drawing.Icon)
        Me.iconTray.Text = "SQL Processor 2022"
        Me.iconTray.Visible = True
        '
        'lblCountdown
        '
        Me.lblCountdown.AutoSize = True
        Me.lblCountdown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCountdown.Location = New System.Drawing.Point(255, 152)
        Me.lblCountdown.Name = "lblCountdown"
        Me.lblCountdown.Size = New System.Drawing.Size(95, 15)
        Me.lblCountdown.TabIndex = 9
        Me.lblCountdown.Text = "Restart Counter: 0"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 303)
        Me.Controls.Add(Me.lblCountdown)
        Me.Controls.Add(Me.lblDelete)
        Me.Controls.Add(Me.lblDeleteTitle)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.txtLastError)
        Me.Controls.Add(Me.GroupBoxDBStatus)
        Me.Controls.Add(Me.lstHistory)
        Me.Controls.Add(Me.mnu)
        Me.MainMenuStrip = Me.mnu
        Me.Name = "frmMain"
        Me.Text = "SQL Processor"
        Me.GroupBoxDBStatus.ResumeLayout(False)
        Me.GroupBoxDBStatus.PerformLayout()
        Me.mnu.ResumeLayout(False)
        Me.mnu.PerformLayout()
        Me.mnuTray.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstHistory As ListBox
    Friend WithEvents GroupBoxDBStatus As GroupBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblDatabase As Label
    Friend WithEvents lblServer As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents txtDatabase As TextBox
    Friend WithEvents txtServer As TextBox
    Friend WithEvents txtLastError As TextBox
    Friend WithEvents mnu As MenuStrip
    Friend WithEvents mnuFile As ToolStripMenuItem
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents mnuOptions As ToolStripMenuItem
    Friend WithEvents mnuSetup As ToolStripMenuItem
    Friend WithEvents lblVersion As Label
    Friend WithEvents tmrDelete As Timer
    Friend WithEvents tmrSecond As Timer
    Friend WithEvents txtTime As TextBox
    Friend WithEvents TTtxtServer As ToolTip
    Friend WithEvents lblDeleteTitle As Label
    Friend WithEvents lblDelete As Label
    Friend WithEvents mnuTray As ContextMenuStrip
    Friend WithEvents OpenWindowMenu As ToolStripMenuItem
    Friend WithEvents iconTray As NotifyIcon
    Friend WithEvents lblCountdown As Label
End Class