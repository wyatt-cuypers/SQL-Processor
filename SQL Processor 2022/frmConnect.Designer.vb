<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnect
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblConnect = New System.Windows.Forms.Label()
        Me.cboConnType = New System.Windows.Forms.ComboBox()
        Me.txtWait = New System.Windows.Forms.TextBox()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.lblWait = New System.Windows.Forms.Label()
        Me.lblSourcePath = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblDatabase = New System.Windows.Forms.Label()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.lblAuth = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.txt4Digit = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDelTime = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblConnect
        '
        Me.lblConnect.AutoSize = True
        Me.lblConnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConnect.Location = New System.Drawing.Point(236, 9)
        Me.lblConnect.Name = "lblConnect"
        Me.lblConnect.Size = New System.Drawing.Size(135, 25)
        Me.lblConnect.TabIndex = 2
        Me.lblConnect.Text = "Connect Via:"
        '
        'cboConnType
        '
        Me.cboConnType.AllowDrop = True
        Me.cboConnType.FormattingEnabled = True
        Me.cboConnType.Items.AddRange(New Object() {"SQL Server", "Windows"})
        Me.cboConnType.Location = New System.Drawing.Point(129, 164)
        Me.cboConnType.Name = "cboConnType"
        Me.cboConnType.Size = New System.Drawing.Size(121, 21)
        Me.cboConnType.Sorted = True
        Me.cboConnType.TabIndex = 3
        '
        'txtWait
        '
        Me.txtWait.Location = New System.Drawing.Point(129, 138)
        Me.txtWait.Name = "txtWait"
        Me.txtWait.Size = New System.Drawing.Size(75, 20)
        Me.txtWait.TabIndex = 25
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(129, 112)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(487, 20)
        Me.txtSource.TabIndex = 24
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(129, 221)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(176, 20)
        Me.txtPassword.TabIndex = 23
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(129, 191)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(176, 20)
        Me.txtUser.TabIndex = 22
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(129, 86)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(176, 20)
        Me.txtDatabase.TabIndex = 21
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(129, 60)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(176, 20)
        Me.txtServer.TabIndex = 20
        '
        'lblWait
        '
        Me.lblWait.AutoSize = True
        Me.lblWait.Location = New System.Drawing.Point(28, 145)
        Me.lblWait.Name = "lblWait"
        Me.lblWait.Size = New System.Drawing.Size(86, 13)
        Me.lblWait.TabIndex = 19
        Me.lblWait.Text = "Seconds to Wait"
        '
        'lblSourcePath
        '
        Me.lblSourcePath.AutoSize = True
        Me.lblSourcePath.Location = New System.Drawing.Point(28, 119)
        Me.lblSourcePath.Name = "lblSourcePath"
        Me.lblSourcePath.Size = New System.Drawing.Size(66, 13)
        Me.lblSourcePath.TabIndex = 18
        Me.lblSourcePath.Text = "Source Path"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(28, 224)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 17
        Me.lblPassword.Text = "Password"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(28, 198)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(29, 13)
        Me.lblUser.TabIndex = 16
        Me.lblUser.Text = "User"
        '
        'lblDatabase
        '
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.Location = New System.Drawing.Point(28, 93)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(53, 13)
        Me.lblDatabase.TabIndex = 15
        Me.lblDatabase.Text = "Database"
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(28, 67)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(38, 13)
        Me.lblServer.TabIndex = 14
        Me.lblServer.Text = "Server"
        '
        'lblAuth
        '
        Me.lblAuth.AutoSize = True
        Me.lblAuth.Location = New System.Drawing.Point(28, 172)
        Me.lblAuth.Name = "lblAuth"
        Me.lblAuth.Size = New System.Drawing.Size(75, 13)
        Me.lblAuth.TabIndex = 26
        Me.lblAuth.Text = "Authentication"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(230, 276)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 31)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(129, 276)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 31)
        Me.btnOk.TabIndex = 27
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(311, 215)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(60, 23)
        Me.btnView.TabIndex = 30
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'txt4Digit
        '
        Me.txt4Digit.Location = New System.Drawing.Point(377, 218)
        Me.txt4Digit.Name = "txt4Digit"
        Me.txt4Digit.Size = New System.Drawing.Size(100, 20)
        Me.txt4Digit.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 332)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Delete Processed Files After"
        '
        'txtDelTime
        '
        Me.txtDelTime.Location = New System.Drawing.Point(170, 329)
        Me.txtDelTime.Name = "txtDelTime"
        Me.txtDelTime.Size = New System.Drawing.Size(34, 20)
        Me.txtDelTime.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 332)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Hours"
        '
        'frmConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 363)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDelTime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt4Digit)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lblAuth)
        Me.Controls.Add(Me.txtWait)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.txtDatabase)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.lblWait)
        Me.Controls.Add(Me.lblSourcePath)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblDatabase)
        Me.Controls.Add(Me.lblServer)
        Me.Controls.Add(Me.cboConnType)
        Me.Controls.Add(Me.lblConnect)
        Me.Name = "frmConnect"
        Me.Text = "Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblConnect As Label
    Friend WithEvents cboConnType As ComboBox
    Friend WithEvents txtWait As TextBox
    Friend WithEvents txtSource As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtDatabase As TextBox
    Friend WithEvents txtServer As TextBox
    Friend WithEvents lblWait As Label
    Friend WithEvents lblSourcePath As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblUser As Label
    Friend WithEvents lblDatabase As Label
    Friend WithEvents lblServer As Label
    Friend WithEvents lblAuth As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOk As Button
    Friend WithEvents btnView As Button
    Friend WithEvents txt4Digit As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDelTime As TextBox
    Friend WithEvents Label2 As Label
End Class
