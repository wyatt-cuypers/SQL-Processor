Imports System.Data.SqlClient
Imports System.IO

Module mod1
    Public Const REJECT_FOLDER = "Reject"
    Public Const PROCESSED_FOLDER = "Processed"
    Const SETTINGS = "SQL Processor.txt"
    Const VERSION_QUERY = "SELECT @@VERSION"

    Const DATABASE_OK = 0
    Const DATABASE_ERROR_LOGIN = -2147217843
    Const DATABASE_ERROR_SERVER = -2147467259
    Const DATABASE_ERROR_EXECUTE = -2146232060
    Const DATABASE_CUSTOM_ERROR = -2146233088
    Const DATABASE_ERROR_PERMISSION = -2147217911
    Const DATABASE_ERROR_TIMEOUT = -2147217871

    Public sDB_Server As String = ""
    Public sDB_Database As String = ""
    Public sDB_User As String = ""
    Public sDB_Password As String = ""
    Public sDB_SourcePath As String = ""
    Public nDeleteAfterXHours As Integer
    Dim crypt As Simple3Des = New Simple3Des("Hello World")
    Public nDelaySeconds As Integer

    Public sSQLVersion As String
    Public conn As New SqlConnection
    Public intConType As Integer
    Public bDBConnected As Boolean
    Public bProcessingNewFilesActive As Boolean

    Public lError As Long
    Public sErrorDesc As String
    Public sErrorHndl As String
    Dim sFullSETTINGSPath As String = Directory.GetCurrentDirectory() & "\" & SETTINGS
    Public sLogFileName As String = Directory.GetCurrentDirectory() & "\SQL Processor.log"

    Sub Main()
        Load_From_INI()
        'If settings do not exist, a form that is used to set/edit settings pops up
        If sDB_Database = "" Or sDB_SourcePath = "" Then
            frmConnect.Show()
        End If
        frmMain.iconTray.Icon = New Icon(Directory.GetCurrentDirectory() & "\NotOK1.ico")
    End Sub

    'Creates a file with the parameter as the file path if the file doesn't already exist
    Public Sub makeFile(FileName As String)
        If File.Exists(FileName) = False Then
            File.Create(FileName)
        End If
    End Sub

    'Reads the file, splits the contents up by newline characters and then stores each line in an array
    Public Function readOptions(optionsFile As String) As String()
        Dim options = File.ReadAllText(optionsFile)
        Dim optionsSplit As String() = options.Split(Environment.NewLine)
        Dim optionsParameters(optionsSplit.Length) As String
        For i = 0 To optionsSplit.Length - 1
            optionsParameters(i) = optionsSplit(i).Trim()
        Next
        Return optionsParameters
    End Function

    'Closes current database connection
    Sub DB_Close()
        Try
            bDBConnected = False
            conn.Close()
            conn = Nothing
            frmMain.Set_DB_Connect_Disconnect_Display()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    'Looks at the array, searches for a string that begins with the second parameter.
    'If it finds the string, it then returns the part of the string that does not contain the parameter
    Public Function SearchArray(aStringArray As String(), sSearchString As String) As String
        Dim i As Integer
        Dim sReturn As String = ""
        For i = aStringArray.GetLowerBound(0) To aStringArray.GetUpperBound(0)
            If InStr(aStringArray(i), sSearchString) = 1 Then
                sReturn = aStringArray(i).Replace(sSearchString, "")
                Exit For
            End If
        Next
        Return sReturn
    End Function

    'Adds an entry to the specified form's listbox control
    Public Sub Add_History_Entry(sMessage As String)
        Try
            frmMain.lstHistory.Items.Add(sMessage)
            If frmMain.lstHistory.Items.Count > 10000 Then
                frmMain.lstHistory.Items.Remove(10000)
            End If
            frmMain.lstHistory.TopIndex = frmMain.lstHistory.Items.Count - 1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    'Writes to a specified file information about an error, if one occurs
    Public Sub Show_Error(bShowError As Boolean, sPassedlError As Long, sPassedErrorDesc As String, sPassedErrorHndl As String)
        Try
            My.Computer.FileSystem.WriteAllText(sLogFileName, Date.Now & " - *** " & sPassedErrorHndl & " ***" & Environment.NewLine, True)
            My.Computer.FileSystem.WriteAllText(sLogFileName, Date.Now & " - --- " & sPassedlError & " ---" & Environment.NewLine, True)
            My.Computer.FileSystem.WriteAllText(sLogFileName, Date.Now & " - --- " & sPassedErrorDesc & " ---" & Environment.NewLine, True)
            If bShowError Then
                frmMain.txtLastError.Text = sPassedErrorHndl & vbCrLf & sPassedlError & vbCrLf & sPassedErrorDesc
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    'Stores settings for connecting to a database in a specified file
    Public Sub Store_INI_Values()
        Try
            If Not sDB_Password = "" Then
                Dim optionsWrite = "Server=" & sDB_Server & Environment.NewLine & "Database=" & sDB_Database & Environment.NewLine & "User=" & sDB_User & Environment.NewLine & "Password=" & crypt.EncryptData(sDB_Password) & Environment.NewLine & "Source Path=" & sDB_SourcePath & Environment.NewLine & "Wait=" & nDelaySeconds & Environment.NewLine & "Delete After X Hours=" & nDeleteAfterXHours
                File.WriteAllText(sFullSETTINGSPath, optionsWrite)
            Else
                Dim optionsWrite = "Server=" & sDB_Server & Environment.NewLine & "Database=" & sDB_Database & Environment.NewLine & "User=" & sDB_User & Environment.NewLine & "Password=" & sDB_Password & Environment.NewLine & "Source Path=" & sDB_SourcePath & Environment.NewLine & "Wait=" & nDelaySeconds & Environment.NewLine & "Delete After X Hours=" & nDeleteAfterXHours
                File.WriteAllText(sFullSETTINGSPath, optionsWrite)
            End If
            frmMain.txtServer.Text = sDB_Server
            frmMain.txtDatabase.Text = sDB_Database
            Create_Processed_And_Reject_Folders()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    'Creates two folders if they do not already exist
    Sub Create_Processed_And_Reject_Folders()
        Try
            If Not Directory.Exists(sDB_SourcePath & "\" & PROCESSED_FOLDER) Then
                Directory.CreateDirectory(sDB_SourcePath & "\" & PROCESSED_FOLDER)
            End If
            If Not Directory.Exists(sDB_SourcePath & "\" & REJECT_FOLDER) Then
                Directory.CreateDirectory(sDB_SourcePath & "\" & REJECT_FOLDER)
            End If
        Catch ex As Exception
            lError = ex.HResult
            sErrorDesc = Err.Description
            sErrorHndl = "Create_Processed_And_Reject_Folders"
            Show_Error(False, lError, sErrorDesc, sErrorHndl)
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    'Makes a connection to a database specified in the settings file or form
    Sub DB_Connect()
        Dim sTempErrorMessage As String = ""
        Try
            conn = New SqlConnection()
            If intConType = 1 Then
                conn.ConnectionString = ("Data Source=" & sDB_Server & ";Initial Catalog=" & sDB_Database & ";User ID=" & sDB_User & "; Password=" & sDB_Password)
                conn.Open()
                bDBConnected = True
                frmMain.Set_DB_Connect_Disconnect_Display()
                DB_Execute_Statement(VERSION_QUERY, sTempErrorMessage)
                frmMain.txtLastError.Text = ""
            ElseIf intConType = 2 Then
                conn.ConnectionString = ("Data Source=" & sDB_Server & ";Initial Catalog=" & sDB_Database & ";Integrated Security=SSPI;Trusted_Connection=True")
                conn.Open()
                bDBConnected = True
                frmMain.Set_DB_Connect_Disconnect_Display()
                DB_Execute_Statement(VERSION_QUERY, sTempErrorMessage)
                frmMain.txtLastError.Text = ""
            End If
        Catch ex As Exception
            lError = ex.HResult
            sErrorDesc = ex.Message
            sErrorHndl = "DB_Connect"
            Show_Error(True, lError, sErrorDesc, sErrorHndl)
            bDBConnected = False
            frmMain.Set_DB_Connect_Disconnect_Display()
        End Try
    End Sub

    'Loads the current settings stored in a settings file
    Public Sub Load_From_INI()
        makeFile(sLogFileName)
        makeFile(sFullSETTINGSPath)
        Try
            Dim arrOptions As String() = readOptions(sFullSETTINGSPath)
            If SearchArray(arrOptions, "User=") = "" Then
                frmConnect.cboConnType.SelectedIndex = 1
            Else
                frmConnect.cboConnType.SelectedIndex = 0
            End If
            sDB_Server = SearchArray(arrOptions, "Server=")
            sDB_Database = SearchArray(arrOptions, "Database=")
            sDB_User = SearchArray(arrOptions, "User=")
            If Not SearchArray(arrOptions, "Password=") = "" Then
                sDB_Password = crypt.DecryptData(SearchArray(arrOptions, "Password="))
            Else
                sDB_Password = SearchArray(arrOptions, "Password=")
            End If
            sDB_SourcePath = SearchArray(arrOptions, "Source Path=")
            If Not SearchArray(arrOptions, "Wait=") = "" Then
                nDelaySeconds = CInt(SearchArray(arrOptions, "Wait="))
            End If
            If Not SearchArray(arrOptions, "Delete After X Hours=") = "" Then
                nDeleteAfterXHours = CInt(SearchArray(arrOptions, "Delete After X Hours="))
            End If
            frmMain.txtServer.Text = sDB_Server
            frmMain.txtDatabase.Text = sDB_Database
            Create_Processed_And_Reject_Folders()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    'Takes in a SQL command and executes it as long as there are no errors
    Function DB_Execute_Statement(ByVal sPassedSQL As String, ByRef sPassedErrorMessage As String) As Long
        Dim objComm As New SqlCommand
        Try
            If Not sPassedSQL.StartsWith("exec ") And Not sPassedSQL.StartsWith("INSERT INTO") And Not sPassedSQL.StartsWith("UPDATE") And Not sPassedSQL = VERSION_QUERY Then
                Throw New Exception("Exec, insert, or update missing")
            End If
            If sPassedSQL.StartsWith("DELETE") And Not sPassedSQL.Contains("WHERE") Then
                Throw New Exception("Delete without Where")
            End If
            If Trim(sPassedSQL) > "" Then
                objComm.CommandType = CommandType.Text
                objComm.CommandText = sPassedSQL
                objComm.Connection = conn
                objComm.ExecuteNonQuery()
                If sPassedSQL = VERSION_QUERY Then
                    sSQLVersion = ""
                    sSQLVersion = "Server Version: " & objComm.Connection.ServerVersion
                    frmMain.TTtxtServer.SetToolTip(frmMain.txtServer, sSQLVersion)
                    My.Computer.FileSystem.WriteAllText(sLogFileName, Date.Now & " - " & sSQLVersion & Environment.NewLine, True)
                End If
            End If
            sPassedErrorMessage = ""
            DB_Execute_Statement = 0
            frmMain.txtLastError.Text = ""
        Catch ex As Exception
            lError = ex.HResult
            sErrorDesc = Err.Description
            sErrorHndl = "DB_Execute_Statement"
            sPassedErrorMessage = sErrorDesc
            DB_Execute_Statement = lError
            My.Computer.FileSystem.WriteAllText(sLogFileName, Date.Now & " - ." & Environment.NewLine, True)
            Show_Error(True, lError, sErrorDesc, sErrorHndl)
            My.Computer.FileSystem.WriteAllText(sLogFileName, Date.Now & " - " & sPassedSQL & Environment.NewLine, True)
            My.Computer.FileSystem.WriteAllText(sLogFileName, Date.Now & " - ." & Environment.NewLine, True)
        End Try
    End Function

    'Looks at all of the files in the specified directory and orders them based on the time they were last modified
    Public Function Get_Ordered_Files(FilePattern As String) As Collection
        Dim ofsDir As String
        Dim colFiles As Collection, ofsAddedFile As String
        Dim i As Long, strFileName As String
        Dim lngFileCount As Long, dteDateLastModifed As Date
        Try
            'create the new collection
            colFiles = New Collection
            'get the directory and file name of the file
            ofsDir = FilePattern 'oFs.GetFolder(oFs.GetParentFolderName(FilePattern))
            strFileName = UCase(FilePattern & "\*") 'UCase(oFs.GetFileName(FilePattern))
            'iterate through all of the files in the directory
            For Each s In Directory.GetFiles(ofsDir) 'ofsDir.Files
                'if the file name matches the passed-in file name
                If UCase(s) Like strFileName Then
                    dteDateLastModifed = File.GetLastWriteTime(s)
                    For i = lngFileCount To 1& Step -1&
                        ofsAddedFile = colFiles(i)
                        If dteDateLastModifed >= File.GetLastWriteTime(ofsAddedFile.ToString) Then
                            Exit For
                        End If
                    Next i
                    'add the file to the collection
                    If i < lngFileCount Then
                        colFiles.Add(Item:=s, Before:=(i + 1&))
                    Else
                        colFiles.Add(s)
                    End If
                    'increment the number of added files
                    lngFileCount = lngFileCount + 1&
                End If
            Next
            'return the collection
            Get_Ordered_Files = colFiles
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

'Looks at the now-ordered files, ensures the title of the file is correctly formatted, and attempts to put them in a database
'If the file is good, it is executed/logged into the database and then moved into the Processed folder
'If the file is bad/has errors, it is not executed, marked as rejected, and moved into the Reject folder
'Each entry, whether processed or rejected, is logged on the form's listbox with the date and time is was read
'Each rejected file is documented in the program's log file
    Sub Process_Files()
        Dim lRowsBad As Long = 0
        Dim lRowsTotal As Long = 0
        Dim lReturn As Long
        Dim sReturnError As String
        Dim sFile As String, sFileNoExt As String, sInputLine As String, sFileEnd As String
        Dim bAbortProcess As Boolean, bClearLastError As Boolean, bOKToProcess As Boolean
        Dim dTempCreateDateTime As Date, dTempDate As Date
        Dim ofsFiles As Collection
        Dim objMili As New Stopwatch
        Dim objTotal As New Stopwatch
        Dim intOneOrZero As Integer
        Try
            bAbortProcess = False
            bClearLastError = True
            If Not bDBConnected Then
                DB_Connect()
            End If
            ofsFiles = Get_Ordered_Files(sDB_SourcePath)
            For Each s In ofsFiles
                sFile = s.ToString
                sFileEnd = My.Computer.FileSystem.GetName(sFile)
                bOKToProcess = False
                ' If the file name format is
                ' YYMMDDHHNN.SQL or YYYYMMDDHHNN.SQL or YYMMDDHHNNSS.SQL or YYYYMMDDHHNNSS.SQL
                ' or YYYYMMDDHHNNSS_??.SQL
                ' then we can use file name to determine whether the file is old enough to process.
                sFileNoExt = Left(sFile, Len(sFile) - 4)
                If IsNumeric(sFileNoExt) Then
                    If Len(sFileNoExt) = 10 Then
                        ' YYMMDDHHNN.SQL
                        dTempCreateDateTime = DateSerial(Val(Left(sFileNoExt, 2)), Val(Mid(sFileNoExt, 3, 2)), Val(Mid(sFileNoExt, 5, 2))) + TimeSerial(Val(Mid(sFileNoExt, 7, 2)), Val(Mid(sFileNoExt, 9, 2)), 0)
                        If Now() > DateAdd("s", nDelaySeconds, DateAdd("n", 1, dTempCreateDateTime)) Then
                            bOKToProcess = True
                        End If
                    ElseIf Len(sFileNoExt) = 12 Then
                        ' determine if the format is YYYYMMDDHHNN.SQL or YYMMDDHHNNSS.SQL
                        dTempDate = DateSerial(Val(Left(sFileNoExt, 4)), 1, 1) + TimeSerial(0, 0, 0)
                        If Year(dTempDate) = Date.Today.Year _
                      Or Year(dTempDate) + 1 = Date.Today.Year Then
                            ' YYYYMMDDHHNN.SQL
                            dTempCreateDateTime = DateSerial(Val(Left(sFileNoExt, 4)), Val(Mid(sFileNoExt, 5, 2)), Val(Mid(sFileNoExt, 7, 2))) + TimeSerial(Val(Mid(sFileNoExt, 9, 2)), Val(Mid(sFileNoExt, 11, 2)), 0)
                            If Now() > DateAdd("s", nDelaySeconds, DateAdd("n", 1, dTempCreateDateTime)) Then
                                bOKToProcess = True
                            End If
                        Else
                            ' YYMMDDHHNNSS.SQL
                            dTempCreateDateTime = DateSerial(Val(Left(sFileNoExt, 2)), Val(Mid(sFileNoExt, 3, 2)), Val(Mid(sFileNoExt, 5, 2))) + TimeSerial(Val(Mid(sFileNoExt, 7, 2)), Val(Mid(sFileNoExt, 9, 2)), Val(Mid(sFileNoExt, 11, 2)))
                            If Now() > DateAdd("s", nDelaySeconds, dTempCreateDateTime) Then
                                bOKToProcess = True
                            End If
                        End If
                    ElseIf Len(sFileNoExt) = 14 Then
                        ' YYYYMMDDHHNNSS.SQL
                        dTempCreateDateTime = DateSerial(Val(Left(sFileNoExt, 4)), Val(Mid(sFileNoExt, 5, 2)), Val(Mid(sFileNoExt, 7, 2))) + TimeSerial(Val(Mid(sFileNoExt, 9, 2)), Val(Mid(sFileNoExt, 11, 2)), Val(Mid(sFileNoExt, 13, 2)))
                        If Now() > DateAdd("s", nDelaySeconds, dTempCreateDateTime) Then
                            bOKToProcess = True
                        End If
                    Else
                        If DateDiff("s", File.GetLastWriteTime(s.ToString), Now()) >= 1 Then
                            bOKToProcess = True
                        End If
                    End If
                ElseIf Len(sFileNoExt) > 14 _
              And IsNumeric(Left(sFileNoExt, 14)) Then
                    ' YYYYMMDDHHNNSS_??.SQL
                    dTempCreateDateTime = DateSerial(Val(Left(sFileNoExt, 4)), Val(Mid(sFileNoExt, 5, 2)), Val(Mid(sFileNoExt, 7, 2))) + TimeSerial(Val(Mid(sFileNoExt, 9, 2)), Val(Mid(sFileNoExt, 11, 2)), Val(Mid(sFileNoExt, 13, 2)))
                    If Now() > DateAdd("s", nDelaySeconds, dTempCreateDateTime) Then
                        bOKToProcess = True
                    End If
                Else
                    If DateDiff("s", File.GetLastWriteTime(s.ToString), Now()) >= 1 Then
                        bOKToProcess = True
                    End If
                End If
                If bOKToProcess Then
                    bClearLastError = False
                    objMili.Start()
                    lRowsBad = 0
                    sInputLine = File.ReadAllText(sFile)
                    If Trim(sInputLine) > "" Then
                        lRowsTotal = lRowsTotal + 1
                        lReturn = DB_Execute_Statement(sInputLine, sReturnError)
                        If lReturn = DATABASE_OK Then
                            intOneOrZero = 1
                            bAbortProcess = False
                            File.Move(sFile, sDB_SourcePath & "\" & PROCESSED_FOLDER & "\" & sFileEnd)
                        ElseIf lReturn = DATABASE_ERROR_LOGIN _
                          Or lReturn = DATABASE_ERROR_PERMISSION _
                          Or lReturn = DATABASE_ERROR_SERVER _
                          Or lReturn = DATABASE_ERROR_TIMEOUT Then
                            lRowsBad = lRowsBad + 1
                            bAbortProcess = True
                            intOneOrZero = 0
                            DB_Close()
                        ElseIf lReturn = DATABASE_ERROR_EXECUTE Or DATABASE_CUSTOM_ERROR Then
                            lRowsBad = lRowsBad + 1
                            intOneOrZero = 0
                            File.Move(sFile, sDB_SourcePath & "\" & REJECT_FOLDER & "\" & "Reject" & sFileEnd)
                            bAbortProcess = True
                        Else
                            lRowsBad = lRowsBad + 1
                            intOneOrZero = 0
                            bAbortProcess = True
                            DB_Close()
                        End If
                    End If
                    Application.DoEvents()
                    frmMain.lstHistory.Refresh()
                    If Not bAbortProcess Then
                        Add_History_Entry(Date.Now & " - " & Right(Space(3) & Format((Int((objMili.ElapsedMilliseconds) / 1000)), "0"), 3) + "." + Left(Format(((objMili.ElapsedMilliseconds) Mod 1000), "000"), 3) & " Secs - " & Right(Space(6) & intOneOrZero, 6) & " Good Rows - " & Right(Space(6) & Format(lRowsBad, "0"), 6) & " Bad Rows - " & sFileEnd)
                        frmMain.iconTray.Icon = New Icon(Directory.GetCurrentDirectory() & "\OK1.ico")
                        frmMain.iconTray.BalloonTipText = "SQL Processor - Last Activity: " & Format(Now, "mm/dd/yyyy hh:mm:ss")
                    Else
                        Add_History_Entry(Date.Now & " - " & Right(Space(3) & Format((Int((objMili.ElapsedMilliseconds) / 1000)), "0"), 3) + "." + Left(Format(((objMili.ElapsedMilliseconds) Mod 1000), "000"), 3) & " Secs - " & Right(Space(6) & intOneOrZero, 6) & " Good Rows - " & Right(Space(6) & Format(lRowsBad, "0"), 6) & " Bad Rows - " & sFileEnd)
                    End If
                    objMili.Reset()
                End If
                'Add_History_Entry(Date.Now & " - " & Right(Space(3) & Format((Int((objMili.ElapsedMilliseconds) / 1000)), "0"), 3) + "." + Left(Format(((objMili.ElapsedMilliseconds) Mod 1000), "000"), 3) & " Secs - " & Right(Space(6) & intOneOrZero, 6) & " Good Rows - " & Right(Space(6) & Format(lRowsBad, "0"), 6) & " Bad Rows - " & sFileEnd)
                Application.DoEvents()
            Next
            If Not bAbortProcess And frmMain.iconTray.Icon.ToString <> Directory.GetCurrentDirectory() & "\OK1.ico" Then
                frmMain.iconTray.Icon = New Icon(Directory.GetCurrentDirectory() & "\OK1.ico")
                frmMain.iconTray.BalloonTipText = "SQL Processor - OK"
            End If
            If bClearLastError Then
                frmMain.txtLastError.Text = ""
            End If
        Catch ex As Exception
            lError = ex.HResult
            sErrorDesc = Err.Description
            sErrorHndl = "Process_Files"
            Call Show_Error(True, lError, sErrorDesc, sErrorHndl)
        End Try
    End Sub

End Module
