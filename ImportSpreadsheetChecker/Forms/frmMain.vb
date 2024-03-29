﻿' **************************************************
'   Copyright 2022 Corning Incorporated
'   Author: Tom Gee
' **************************************************

Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.IO
Imports System.Net
Imports Microsoft.Office.Interop
Imports WinSCP

Public Class frmMain

#Region "Private Variables"
    Private _dbCalls As New clsDatabaseCalls
    Private _dbCallsReliance As New clsDatabaseCalls
    Private _htRelianceFormFields As New Hashtable
    Private _htRelianceUsersAndGroups As New Hashtable
    Private _htRelianceCurrentLookupValues As New Hashtable
    Private _htUniqueValues As New Hashtable
    Private _errorCount As Integer = 0
    Private _htErrorLog As New Hashtable
    Private _selectedListValue As String
    Private _formTable As String
    Private _dtColumns As DataTable = Nothing
    Private _frmCaption As String
    Private _currentBusiness As Business
    Private _currentEnvironment As Environment
#End Region

#Region "Public Properties"
    Public Property CurrentBusiness As Business
        Get
            Return _currentBusiness
        End Get
        Set(value As Business)
            _currentBusiness = value
        End Set
    End Property

    Public Property CurrentEnvironment As Environment
        Get
            Return _currentEnvironment
        End Get
        Set(value As Environment)
            _currentEnvironment = value
        End Set
    End Property
#End Region

#Region "Private Methods/Functions"
    Private Sub AppStartup()
        Try
            _frmCaption = Me.Text

            If My.Settings.Businesses Is Nothing Then
                My.Settings.Businesses = New ArrayList
            End If

            If My.Settings.Environments Is Nothing Then
                My.Settings.Environments = New ArrayList
            End If

            If GlobalVar.bc Is Nothing Then
                GlobalVar.bc = New BusinessCollection
            End If

            For Each bus As String In My.Settings.Businesses
                GlobalVar.bc.AddBusiness(GlobalVar.bc.ConvertStringToBusiness(bus))
            Next

            If GlobalVar.ec Is Nothing Then
                GlobalVar.ec = New EnvironmentCollection
            End If

            For Each env As String In My.Settings.Environments
                GlobalVar.ec.AddEnvironment(GlobalVar.ec.ConvertStringToEnvironment(env))
            Next

            txtExcelFile.Text = My.Settings.FileURL
            If txtExcelFile.Text <> "" Then
                btnImport.Enabled = True
            End If

            GetBusinesses()

        Catch ex As Exception
            MessageBox.Show("An ERROR occurred while retrieving application settings in AppStartup: " & ex.Message.ToString & System.Environment.NewLine & "Inner Exception: " & ex.InnerException.ToString & System.Environment.NewLine & "Stack Trace: " & ex.StackTrace.ToString)
        End Try
    End Sub

    Private Sub SaveAppSettings()
        Try
            'clear existing Businesses
            If My.Settings.Businesses IsNot Nothing Then
                My.Settings.Businesses.Clear()
            End If

            If GlobalVar.bc IsNot Nothing Then
                For Each bus As Business In GlobalVar.bc.GetBusinesses(True)
                    My.Settings.Businesses.Add(GlobalVar.bc.ConvertBusinessToString(bus))
                Next
            End If

            'clear existing Environments
            If My.Settings.Environments IsNot Nothing Then
                My.Settings.Environments.Clear()
            End If

            If GlobalVar.ec IsNot Nothing Then
                For Each env As Environment In GlobalVar.ec.GetEnvironments
                    My.Settings.Environments.Add(GlobalVar.ec.ConvertEnvironmentToString(env))
                Next
            End If

            My.Settings.FileURL = txtExcelFile.Text

            My.Settings.Save()

        Catch ex As Exception
            MessageBox.Show("An ERROR occurred while saving application settings in AppShutdown: " & ex.Message.ToString & System.Environment.NewLine & "Inner Exception: " & ex.InnerException.ToString & System.Environment.NewLine & "Stack Trace: " & ex.StackTrace.ToString)
        End Try
    End Sub

    Private Sub AppShutdown()
        SaveAppSettings()
    End Sub

    Private Sub GetBusinesses()
        Try
            UpdateStatus("Refreshing list of Businesses...")

            With cboBusiness
                .IntegralHeight = True
                .Text = ""
                .Items.Clear()
                .SelectedIndex = -1
                .DropDownHeight = 106
                .IntegralHeight = False
                .MaxDropDownItems = 25

                If GlobalVar.bc IsNot Nothing Then
                    For Each bus As Business In GlobalVar.bc.GetBusinesses()
                        .Items.Add(bus.ID)
                    Next
                End If

                .Sorted = True
            End With

            UpdateStatus("List of Businesses updated.")

        Catch ex As Exception
            MessageBox.Show("An ERROR occurred while retrieving the list of businesses in GetBusinesses: " & ex.Message.ToString & System.Environment.NewLine & "Inner Exception: " & ex.InnerException.ToString & System.Environment.NewLine & "Stack Trace: " & ex.StackTrace.ToString)
        End Try
    End Sub

    Private Sub GetEnvironments()
        Try
            UpdateStatus("Refreshing list of Environments...")

            With cboEnvironment
                .IntegralHeight = True
                .Text = ""
                .Items.Clear()
                .SelectedIndex = -1
                .DropDownHeight = 106
                .IntegralHeight = False
                .MaxDropDownItems = 25

                If GlobalVar.ec IsNot Nothing Then
                    For Each env As Environment In GlobalVar.ec.GetEnvironmentsForBusiness(cboBusiness.Text)
                        .Items.Add(env.Environment_ID)
                    Next
                End If

                .Sorted = True
            End With

            UpdateStatus("List of Environments updated.")

        Catch ex As Exception
            MessageBox.Show("An ERROR occurred while retrieving the list of environments in GetEnvironments: " & ex.Message.ToString & System.Environment.NewLine & "Inner Exception: " & ex.InnerException.ToString & System.Environment.NewLine & "Stack Trace: " & ex.StackTrace.ToString)
        End Try
    End Sub

    Private Sub UpdateStatus(ByVal Message As String)
        lblStatus.Text = String.Format("[{0}]  {1}", Date.Now, Message)
        Application.DoEvents()
    End Sub

    Private Sub ImportExcelData()
        Try
            UpdateStatus("Importing data from Excel...")

            Dim Name As String = "Items"
            Dim constr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & txtExcelFile.Text & ";Extended Properties='Excel 12.0 XML;HDR=YES;';"
            Dim con As New OleDbConnection(constr)

            con.Open()

            Dim dtSchema As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
            Dim drSchema As DataRow = dtSchema.Rows(0)
            Dim strSheetName As String = drSchema("TABLE_NAME")

            Dim cmd As New OleDbCommand("Select * From [" & strSheetName & "]", con)
            cmd.Connection = con

            Dim sda As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable
            sda.Fill(dt)

            Dim rows As Integer = dt.Rows.Count + 1
            Dim cols As Integer = dt.Columns.Count
            Dim colName As String = ""
            If cols > 0 Then
                colName = GetExcelColumnName(cols)
            End If

            dt.Clear()
            cmd = New OleDbCommand("Select * From [" & strSheetName & "A1:" & colName & rows & "]", con)
            cmd.Connection = con
            sda = New OleDbDataAdapter(cmd)
            dt = New DataTable
            sda.Fill(dt)

            con.Close()

            UpdateStatus("Binding Excel data to the grid...")

            Dim maxColWidth As Integer = 800
            With dgvData
                .DataSource = dt
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                ' Add the column to the Columns datatable for use in the Find/Replace dialog
                _dtColumns = New DataTable
                Dim col As DataColumn = New DataColumn("col")
                col.DataType = System.Type.GetType("System.String")
                _dtColumns.Columns.Add(col)

                For Each c As DataGridViewColumn In .Columns
                    If c.Width > maxColWidth Then
                        c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        c.Width = maxColWidth
                    End If

                    ' Add the column to the Columns datatable for use in the Find/Replace dialog
                    Dim r As DataRow = _dtColumns.NewRow()
                    r.Item(0) = c.HeaderText
                    _dtColumns.Rows.Add(r)
                Next

                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            End With

            UpdateStatus(dt.Rows.Count & " records imported from Excel.")

        Catch ex As Exception
            Dim err As String = String.Format("Error importing Excel data. {0}", ex.Message)
            MessageBox.Show(err, "Import Error")
            UpdateStatus(err)
        End Try
    End Sub

    Private Function GetExcelColumnName(columnNumber As Integer) As String
        Dim dividend As Integer = columnNumber
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() & columnName
            dividend = CInt((dividend - modulo) / 26)
        End While

        Return columnName
    End Function

    Private Function GetRelianceConnectionString()
        If CurrentEnvironment IsNot Nothing Then
            Return String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", CurrentEnvironment.SQLServerAddress, CurrentEnvironment.Database_Name, CurrentEnvironment.SQLUser, CurrentEnvironment.SQLPassword)
        End If
    End Function

    Private Sub GetRelianceApplicationList()
        Try
            UpdateStatus("Refreshing list of Applications...")

            _dbCallsReliance.ConnectionString = GetRelianceConnectionString()

            Dim dtApplications As New DataTable
            dtApplications = _dbCallsReliance.GetRelianceApplications()

            If dtApplications Is Nothing Then
                UpdateStatus("Unable to determine Applications for selected business and environment")
                MessageBox.Show("Unable to determine Applications for selected business and environment")
            Else
                With cboApplication
                    .DataSource = Nothing
                    .Items.Clear()
                    .DataSource = dtApplications
                    .ValueMember = "APPLICATION_ID"
                    .DisplayMember = "DISPLAY_NAME"
                End With

                UpdateStatus("List of Applications updated.")
            End If

        Catch ex As Exception
            MessageBox.Show("An ERROR occurred while retrieving the list of applications: " & ex.Message.ToString & System.Environment.NewLine & "Inner Exception: " & ex.InnerException.ToString & System.Environment.NewLine & "Stack Trace: " & ex.StackTrace.ToString)
        End Try
    End Sub

    Private Sub GetRelianceFormList()
        UpdateStatus("Refreshing list of Forms...")

        Dim dtForms As New DataTable
        Dim appID As Integer
        If IsNumeric(cboApplication.Text) Then
            appID = cboApplication.Text
        ElseIf IsNumeric(cboApplication.SelectedValue) Then
            appID = cboApplication.SelectedValue
        End If

        If appID > 0 Then
            dtForms = _dbCallsReliance.GetRelianceForms(appID)

            With cboForm
                .DataSource = Nothing
                .Items.Clear()
                .DataSource = dtForms
                .ValueMember = "FORM_ID"
                .DisplayMember = "DISPLAY_NAME"
            End With
        End If

        UpdateStatus("List of Forms updated.")
    End Sub

    Private Sub GetRelianceSubformList()
        UpdateStatus("Refreshing list of Subforms...")

        Dim dtSubforms As New DataTable
        Dim formID As Integer
        If IsNumeric(cboForm.Text) Then
            formID = cboForm.Text
        ElseIf IsNumeric(cboForm.SelectedValue) Then
            formID = cboForm.SelectedValue
        End If

        If formID > 0 Then
            dtSubforms = _dbCallsReliance.GetRelianceSubforms(formID)

            With cboSubform
                .DataSource = Nothing
                .Items.Clear()
                .DataSource = dtSubforms
                .ValueMember = "SUBFORM_ID"
                .DisplayMember = "DISPLAY_NAME"
            End With
        End If

        UpdateStatus("List of Subforms updated.")
    End Sub

    Private Sub GetRelianceFormFields()
        UpdateStatus("Retrieving Form fields from Reliance...")

        _htRelianceFormFields.Clear()
        _htRelianceFormFields = New Hashtable

        Dim formID As Integer
        If IsNumeric(cboForm.Text) Then
            formID = cboForm.Text
        ElseIf IsNumeric(cboForm.SelectedValue) Then
            formID = cboForm.SelectedValue
        End If

        If formID > 0 Then
            Dim dtFormFields As New DataTable
            dtFormFields = _dbCallsReliance.GetRelianceFormFields(formID)

            If dtFormFields.Rows.Count > 0 Then
                For Each dr As DataRow In dtFormFields.Rows
                    '                    FIELD_NAME, FIELD_TYPE
                    _htRelianceFormFields.Add(dr(0), dr(1))
                Next
            End If
        End If

        UpdateStatus("Form fields updated.")
    End Sub

    Private Function GetRelianceFormTable() As String
        UpdateStatus("Retrieving Form table from Reliance...")

        _formTable = ""

        Dim appID As Integer
        Dim formID As Integer
        If IsNumeric(cboForm.Text) Then
            formID = cboForm.Text
        ElseIf IsNumeric(cboForm.SelectedValue) Then
            formID = cboForm.SelectedValue
        End If

        If IsNumeric(cboApplication.Text) Then
            appID = cboApplication.Text
        ElseIf IsNumeric(cboApplication.SelectedValue) Then
            appID = cboApplication.SelectedValue
        End If

        If formID > 0 Then
            _formTable = ""
            _formTable = _dbCallsReliance.GetRelianceFormTable(appID, formID)
        End If

        Return _formTable

        UpdateStatus("Form fields updated.")
    End Function

    Private Sub GetRelianceSubformFields()
        If cboForm.Text = "" Then
            Exit Sub
        End If

        UpdateStatus("Retrieving Subform fields from Reliance...")

        _htRelianceFormFields.Clear()
        _htRelianceFormFields = New Hashtable

        Dim subformID As Integer
        If IsNumeric(cboSubform.Text) Then
            subformID = cboSubform.Text
        ElseIf IsNumeric(cboSubform.SelectedValue) Then
            subformID = cboSubform.SelectedValue
        End If

        If subformID > 0 Then
            Dim dtSubformFields As New DataTable
            dtSubformFields = _dbCallsReliance.GetRelianceSubformFields(subformID)

            If dtSubformFields.Rows.Count > 0 Then
                For Each dr As DataRow In dtSubformFields.Rows
                    '                    FIELD_NAME, FIELD_TYPE
                    _htRelianceFormFields.Add(dr(0), dr(1))
                Next
            End If
        End If

        UpdateStatus("Subform fields updated.")
    End Sub

    Private Sub GetRelianceUsersAndGroups()
        UpdateStatus("Import Reliance Users and Groups...")

        _htRelianceUsersAndGroups.Clear()
        _htRelianceUsersAndGroups = New Hashtable

        Dim dtUsers As New DataTable
        dtUsers = _dbCallsReliance.GetRelianceUsersAndGroups()

        If dtUsers.Rows.Count() > 0 Then
            For Each dr As DataRow In dtUsers.Rows
                Dim valUpper As String = dr(0).ToString.ToUpper

                If Not _htRelianceUsersAndGroups.Contains(valUpper) Then
                    '                      DISPLAY_NAME, IS_GROUP
                    _htRelianceUsersAndGroups.Add(valUpper, valUpper)
                End If
            Next

            With dgvUsersGroups
                .DataSource = Nothing
                .DataSource = dtUsers
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With

            UpdateStatus(dtUsers.Rows.Count & " User/Group records returned from Reliance.")
        End If
    End Sub

    ''' <summary>
    ''' This method populates a hashtable with all ETQ$NUMBER values in the related schema/table
    ''' </summary>
    Private Sub GetUniqueNumbers()
        UpdateStatus("Import Existing Unique Numbers...")

        _htUniqueValues.Clear()
        _htUniqueValues = New Hashtable

        Dim TableName As String = GetRelianceFormTable()

        Dim dtNumbers As New DataTable
        dtNumbers = _dbCallsReliance.GetRelianceUniqueNumbers(TableName)

        If dtNumbers Is Nothing Then
            UpdateStatus("Unable to return Unique Numbers from Reliance.")
        End If

        If dtNumbers.Rows.Count() > 0 Then
            For Each dr As DataRow In dtNumbers.Rows
                Dim valUpper As String = dr(0).ToString.ToUpper

                If Not _htUniqueValues.Contains(valUpper) Then
                    '                      DISPLAY_NAME, IS_GROUP
                    _htUniqueValues.Add(valUpper, valUpper)
                End If
            Next

            UpdateStatus(dtNumbers.Rows.Count & " Unique Numbers returned from Reliance.")
        End If
    End Sub

    ''' <summary>
    ''' This method will determine the type of column in Reliance
    ''' </summary>
    ''' <param name="ColumnName"></param>
    ''' <returns>Column type in UPPERCASE</returns>
    Private Function GetColumnType(ByVal ColumnName As String) As String
        Dim colType As String = _htRelianceFormFields(ColumnName)

        If ColumnName.Contains("ETQ$") Then
            ' System field
            Select Case ColumnName
                Case "ETQ$NUMBER"
                    colType = "Unique"

                Case "ETQ$NUMBER_ONLY"
                    colType = "Text"

                Case "ETQ$AUTHOR"
                    ' validate user/group
                    colType = "Names"

                Case "ETQ$ASSIGNED"
                    ' validate user/group
                    colType = "Names"

                Case "ETQ$APPROVERS"
                    ' validate user/group
                    colType = "Names"

                Case "ETQ$REVIEWERS"
                    ' validate user/group
                    colType = "Names"

                Case "ETQ$FILTER"
                    colType = "Dialog"  ' System field doesn't match standard logic

                Case "ETQ$LOCATIONS"
                    colType = "Dialog"  ' System field doesn't match standard logic

                Case "ETQ$REVISION"
                    colType = "Number"

                Case "ETQ$ONLINE_DISTRIBUTION"
                    colType = "Names"

                Case "ETQ$OFFLINE_DISTRIBUTION"
                    colType = "Dialog"

                Case "ETQ$REQUESTED_BY"
                    colType = "Names"

                Case "ETQ$EFFECTIVE_DATE"
                    colType = "Date"

                Case "ETQ$REVIEW_DATE"
                    colType = "Date"

                Case "ETQ$REASON"
                    colType = "Text"

                Case "ETQ$CREATED_DATE"
                    colType = "Date"

                Case "ETQ$COMPLETED_DATE"
                    colType = "Date"

                Case "ETQ$DUE_DATE"
                    colType = "Date"

                Case Else   ' skip validation on all other system fields
                    colType = ""

            End Select
        End If

        If colType = Nothing Then
            colType = ""
        End If

        Return colType.ToUpper  ' return the column type in UPPERCASE
    End Function

    Private Sub ValidateExcelData()
        UpdateStatus("Beginning data validation...")
        _htErrorLog.Clear()
        _htErrorLog = New Hashtable
        dgvValidationIssues.Rows.Clear()
        _errorCount = 0

        ' reset the DataSource to default the cell styles
        Dim ds = dgvData.DataSource
        dgvData.DataSource = Nothing

        ' the following helps dramatically with performance and can be re-enabled after the data is bound
        dgvData.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvData.RowHeadersVisible = False
        dgvData.DataSource = ds

        progProgress.Maximum = dgvData.Columns.GetColumnCount(DataGridViewElementStates.None)
        progProgress.Style = ProgressBarStyle.Blocks
        progProgress.Visible = True


        Dim deployType As String = CurrentBusiness.DeployType

        Dim sessOptions As New SessionOptions
        Dim sess As New Session
        If deployType = "Hosted" And chkValidateAttachments.Checked Then
            Try
                With sessOptions

                    .Protocol = Protocol.Sftp
                    .HostName = CurrentBusiness.FTPURL
                    .UserName = CurrentBusiness.FTPUser
                    .Password = CurrentBusiness.FTPPassword
                    .SshHostKeyFingerprint = CurrentBusiness.FTPHostFingerprint
                End With

                sess.Open(sessOptions)
            Catch ex As Exception
                Try
                    sess.Close()
                Catch ex2 As Exception
                    'don't throw a second exception
                End Try
                MessageBox.Show("An error occurred while setting up the FTP session." & ex.Message.ToString & System.Environment.NewLine & ex.InnerException.ToString, "FTP Session Error")
            End Try
        End If


        For Each col As DataGridViewTextBoxColumn In dgvData.Columns
            progProgress.Value = col.Index
            Application.DoEvents()

            Dim colName As String = col.Name
            Dim colType As String = GetColumnType(colName)

            UpdateStatus(String.Format("Evaluating data in the '{0}' column...", colName))

            Select Case colType
                Case "DIALOG", "COMBOBOX", "LISTBOX"
                    _htRelianceCurrentLookupValues.Clear()
                    _htRelianceCurrentLookupValues = New Hashtable
                    Dim dtValues As New DataTable

                    Select Case colName
                        Case "ETQ$FILTER" ' System field (Additional Security) uses non-standard lookup methodology
                            dtValues = _dbCallsReliance.GetAdditionalSecurityValues()
                        Case "ETQ$LOCATIONS"
                            dtValues = _dbCallsReliance.GetLocationProfileValues()
                        Case "ETQ$OFFLINE_DISTRIBUTION"
                            dtValues = _dbCallsReliance.GetOfflineDistributionValues()
                        Case Else
                            dtValues = _dbCallsReliance.GetLookupValues(colName)
                    End Select

                    If dtValues.Rows.Count > 0 Then
                        For Each dr As DataRow In dtValues.Rows
                            Dim valUpper = dr(1).ToString.ToUpper
                            If Not _htRelianceCurrentLookupValues.Contains(valUpper) Then
                                _htRelianceCurrentLookupValues.Add(valUpper, valUpper)    ' store the Display Value as both the ID and Value in the hashtable
                            End If
                        Next
                    End If
            End Select

            If colType = "" Then
                'Column not found in Reliance
                Dim issue As String = String.Format("'{0}' is not a valid field on the '{1}' form in the '{2}' application in Reliance.", colName, cboForm.Text, cboApplication.Text)
                dgvData.Columns(col.Index).HeaderCell.ErrorText = issue  '.Cells(colName).ErrorText = issue
                dgvData.Columns(col.Index).HeaderCell.Style.BackColor = Color.Yellow
                AddValidationError(colName, 0, colType, "", issue)

                'MessageBox.Show(String.Format("'{0}' is not a valid field on the '{1}' form in the '{2}' application in Reliance.", colName, cboForm.Text, cboApplication.Text), "Import Spreadsheet Error")
            Else
                progProgressMinor.Maximum = dgvData.Rows.Count
                progProgressMinor.Style = ProgressBarStyle.Blocks
                progProgressMinor.Visible = True

                For Each dr As DataGridViewRow In dgvData.Rows
                    progProgressMinor.Value = dr.Index
                    Application.DoEvents()

                    If dr.Index = 0 Then
                        ' skip the first record because it is used for instructions
                        Continue For
                    End If
                    If Not IsDBNull(dr.Cells(colName).Value) Then
                        Dim val As String = dr.Cells(colName).Value
                        If val = Nothing Then
                            ' skip validation if no value in cell
                            Continue For
                        End If

                        val = val.Replace("&amp;", "&").ToUpper ' replace the ampersand expression with an actual ampersand
                        Dim values As String() = val.Split(";")

                        Dim valCounter As Integer = 0 ' create a counter to see how many values are in the field

                        Select Case colType
                            Case "UNIQUE"   ' verify that all records in the column have a unique value (ETQ$NUMBER)
                                If _htUniqueValues.ContainsKey(val) Then
                                    Dim issue As String = String.Format("Duplicate value in unique/key column ({0})", val)
                                    AddValidationError(colName, dr.Index, colType, val, issue)
                                Else
                                    _htUniqueValues.Add(val, val)   ' store the value as both the ID and Value in the hashtable
                                End If


                            Case "NAMES"
                                For Each val In values
                                    'ignore the leading space for subsequent values, if multiple are provided
                                    If valCounter > 0 Then
                                        val = LTrim(val)
                                    End If

                                    If Not _htRelianceUsersAndGroups.Contains(val) Then
                                        Dim issue As String = "Invalid User/Group " & PotentialIssue(val)
                                        AddValidationError(colName, dr.Index, colType, val, issue)
                                    End If

                                    valCounter += 1
                                Next

                            Case "DIALOG", "COMBOBOX", "LISTBOX"
                                For Each val In values
                                    'ignore the leading space for subsequent values, if multiple are provided
                                    If valCounter > 0 Then
                                        val = LTrim(val)
                                    End If

                                    If Not _htRelianceCurrentLookupValues.Contains(val) Then
                                        Dim issue As String = "Invalid value" & PotentialIssue(val)
                                        AddValidationError(colName, dr.Index, colType, val, issue)
                                    End If

                                    valCounter += 1
                                Next

                            Case "ATTACHMENT"
                                'Check that the actual file exists on the remote server
                                If chkValidateAttachments.Checked Then
                                    For Each val In values
                                        'ignore the leading space for subsequent values, if multiple are provided
                                        If valCounter > 0 Then
                                            val = LTrim(val)
                                        End If

                                        'On-premise servers are accessible over the network, while FTP servers will require WinSCP reference
                                        If deployType = "On-Premise" Then
                                            Dim filePath As String = String.Format("\\{0}\{1}", CurrentEnvironment.App_Server, Trim(val.Replace(":", "$")))
                                            If Not File.Exists(filePath) Then
                                                Dim issue As String = "File not found (" & filePath & ")" & PotentialIssue(val)
                                                AddValidationError(colName, dr.Index, colType, val, issue)
                                            End If
                                        Else
                                            ' If Hosted, check for file via FTP
                                            Dim filePath As String = CurrentBusiness.FTPLocalPath + val
                                            filePath = filePath.Replace("\\", "/").Replace(":", "").Replace("\", "/")
                                            Try
                                                If Not sess.FileExists(filePath) Then
                                                    Dim issue As String = "File not found on remote FTP server (" & filePath & ")" & PotentialIssue(val)
                                                    AddValidationError(colName, dr.Index, colType, val, issue)
                                                End If
                                            Catch ex As Exception
                                                Dim issue As String = "Error occurred checking file on remote FTP server (" & filePath & ")" & PotentialIssue(val)
                                                AddValidationError(colName, dr.Index, colType, val, issue)
                                            End Try
                                        End If

                                        valCounter += 1
                                    Next
                                End If

                            Case "DATE"
                                If IsDate(val) = False Then
                                    Dim issue As String = String.Format("Invalid date value [{0}]", val)
                                    AddValidationError(colName, dr.Index, colType, val, issue)
                                End If

                        End Select
                    End If
                Next

                progProgressMinor.Visible = False
            End If
        Next

        Try
            If deployType = "Hosted" And chkValidateAttachments.Checked Then
                'Try to close the WinSCP session, if open
                sess.Close()
            End If
        Catch ex As Exception
            'no need to show exception if an error occurs when closing the session
        End Try

        ShowDataIssues()

        dgvData.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        dgvData.RowHeadersVisible = True

        With dgvValidationIssues
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .Sort(dgvValidationIssues.Columns("RecordNumber"), System.ComponentModel.ListSortDirection.Ascending)
        End With

        Dim status As String = String.Format("Data validation complete. {0} validation issue(s) detected.", _errorCount.ToString("N0"))
        UpdateStatus(status)

        If _errorCount = 0 Then
            status = "Great job!" & vbCrLf & status
            MessageBox.Show(Owner, status, "Validation Completed", vbOKOnly, MessageBoxIcon.Information)
        Else
            MessageBox.Show(Owner, status, "Validation Completed", vbOKOnly, MessageBoxIcon.Information)
        End If

        progProgress.Visible = False
    End Sub


    ' - ERROR DISPLAY -
    Private Sub AddError(ByVal RowIndex As Integer, ByVal ColumnName As String, ByVal ErrorText As String)
        Dim key As String = String.Format("{0};{1}", RowIndex, ColumnName)
        If Not _htErrorLog.Contains(key) Then
            _htErrorLog.Add(key, ErrorText)
        End If
    End Sub

    Private Sub ShowDataIssues()
        UpdateStatus("Highlighting data issues in grid...")

        For Each issue As DictionaryEntry In _htErrorLog
            Dim key As String() = issue.Key.ToString.Split(";")

            dgvData.Rows(key(0)).Cells(key(1)).ErrorText = issue.Value
            dgvData.Rows(key(0)).Cells(key(1)).Style.BackColor = Color.Yellow
        Next
    End Sub

    Private Function PotentialIssue(ByVal FieldValue As String) As String
        Dim issue As String = ""
        If FieldValue.Length > 0 Then
            Dim firstChar As Char = FieldValue.Substring(0, 1)
            If firstChar = " " Then
                issue = " - Leading blank space"
            End If

            Dim lastChar As Char = FieldValue(FieldValue.Length - 1)
            If lastChar = " " Then
                issue += " - Trailing blank space"
            End If

            If FieldValue.Contains("\n") Then
                issue += " - Field contains line break"
            End If
        End If

        Return issue
    End Function

    Private Sub AddValidationError(ByVal ColumnName As String, ByVal RecordNumber As Integer, ByVal FieldType As String, ByVal RecordValue As String, Optional ValueIssue As String = "")
        _errorCount += 1

        Dim newRowIndex As Integer = dgvValidationIssues.Rows.Add
        Dim newRow As DataGridViewRow = dgvValidationIssues.Rows(newRowIndex)
        newRow.Cells(0).Value = ColumnName
        newRow.Cells(1).Value = RecordNumber
        newRow.Cells(2).Value = FieldType
        newRow.Cells(3).Value = RecordValue
        newRow.Cells(4).Value = ValueIssue

        AddError(RecordNumber, ColumnName, ValueIssue)
    End Sub

    Private Sub ExportDataGridViewToExcel(ByVal dgv As DataGridView)
        If dgv.RowCount = 0 Then
            MessageBox.Show("No data to export.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
            Return
        End If

        Dim fd As SaveFileDialog = New SaveFileDialog()
        fd.OverwritePrompt = False
        fd.FileName = Path.GetFileName(txtExcelFile.Text)
        fd.Filter = "Excel (*.xls) |*.xls;*.xlsx"

        If fd.ShowDialog() = DialogResult.OK Then
            UpdateStatus("Exporting data to Excel...")
            Dim xlApp As Excel._Application = New Microsoft.Office.Interop.Excel.Application()
            Dim xlWB As Excel._Workbook = xlApp.Workbooks.Add()
            Dim xlWS As Excel._Worksheet = CType(xlWB.Worksheets(1), Excel._Worksheet)

            Try
                progProgress.Visible = True
                progProgress.Style = ProgressBarStyle.Blocks
                progProgress.Maximum = dgv.RowCount - 1

                For c As Integer = 0 To dgv.ColumnCount - 1
                    xlWS.Cells(1, c + 1) = dgv.Columns(c).HeaderText
                Next

                Dim rng As Excel.Range = CType(xlWS.Rows(1), Excel.Range)
                rng.EntireRow.Font.Bold = True
                rng.EntireRow.Font.Underline = True
                xlApp.ActiveWindow.SplitRow = 1
                xlApp.ActiveWindow.FreezePanes = True

                For r As Integer = 0 To dgv.RowCount - 1
                    Application.DoEvents()
                    progProgress.Value = r

                    For c As Integer = 0 To dgv.ColumnCount - 1
                        xlWS.Cells(r + 2, c + 1) = dgv(c, r).Value
                    Next
                Next

                xlWS.Columns.AutoFit()
                xlWB.SaveAs(fd.FileName)
                progProgress.Visible = False
                xlWB.Close()
                xlWS = Nothing
                xlWB = Nothing
                xlApp.Quit()
                fd = Nothing
                MessageBox.Show("Excel Workbook Created Successfully", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UpdateStatus("Export to Excel complete!")
            Catch ex As Exception
                xlWB.SaveAs(fd.FileName)
                xlApp.Quit()
                progProgress.Value = progProgress.Maximum
                MessageBox.Show("Error exporting data to Excel." & vbCrLf + ex.Message, "Export error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                UpdateStatus("Error exporting data to Excel.")
                progProgress.Visible = False
            End Try
        End If
    End Sub

    Private Sub FilterUserGroups()
        If dgvUsersGroups.Rows.Count > 0 Then
            TryCast(dgvUsersGroups.DataSource, DataTable).DefaultView.RowFilter = String.Format("DISPLAY_NAME LIKE '%{0}%'", txtUserGroupSearch.Text)
        End If
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AppStartup()
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        AppShutdown()
    End Sub

    Private Sub cboBusiness_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBusiness.SelectedIndexChanged
        If cboBusiness.Text <> "" Then
            GetEnvironments()

            Dim bus As Business = GlobalVar.bc.GetBusiness(cboBusiness.Text)
            If bus IsNot Nothing Then
                CurrentBusiness = bus
                Me.Text = _frmCaption & " - " & CurrentBusiness.Name
            End If
        Else
            cboEnvironment.Items.Clear()
        End If
    End Sub


    Private Sub cboEnvironment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEnvironment.SelectedIndexChanged
        If cboBusiness.Text <> "" And cboEnvironment.Text <> "" Then
            btnLogin.Enabled = True

            Dim env As Environment = GlobalVar.ec.GetEnvironment(cboBusiness.Text, cboEnvironment.Text)
            If env IsNot Nothing Then
                CurrentEnvironment = env
            End If

            GetRelianceApplicationList()
        Else
            btnLogin.Enabled = False
        End If
    End Sub

    Private Sub btnExcelFile_Click(sender As Object, e As EventArgs) Handles btnExcelFile.Click
        Dim ofd As New OpenFileDialog()
        ofd.Title = "Please select Excel template file..."
        ofd.Filter = "Excel Files (*.xls, *.xlsx, *.xlsm)|*.xls;*.xlsx;*.xlsm"
        ofd.Multiselect = False

        If ofd.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtExcelFile.Text = ofd.FileName.ToString
            btnImport.Enabled = True
            My.Settings.FileURL = Me.txtExcelFile.Text
        End If
    End Sub

    Private Sub cboApplication_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboApplication.SelectedIndexChanged
        GetRelianceFormList()
    End Sub

    Private Sub cboForm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboForm.SelectedIndexChanged
        GetRelianceFormFields()

        If cboSubform.Enabled Then
            GetRelianceSubformList()
        End If

        If txtExcelFile.Text <> "" Then
            btnValidate.Enabled = True
        End If
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        ImportExcelData()
        If cboForm.Text <> "" Then
            btnValidate.Enabled = True
        End If
    End Sub

    Private Sub chkSubform_CheckedChanged(sender As Object, e As EventArgs) Handles chkSubform.CheckedChanged
        cboSubform.Enabled = chkSubform.Checked
        If cboSubform.Enabled Then
            GetRelianceSubformList()
        Else
            cboSubform.DataSource = Nothing
            GetRelianceFormFields()
        End If
    End Sub

    Private Sub cboSubform_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubform.SelectedIndexChanged
        GetRelianceSubformFields()
    End Sub

    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click
        If tabTabControl.SelectedTab Is tabExcelData Then
            ExportDataGridViewToExcel(dgvData)
        ElseIf tabTabControl.SelectedTab Is tabUsersGroups Then
            ExportDataGridViewToExcel(dgvUsersGroups)
        Else
            ExportDataGridViewToExcel(dgvValidationIssues)
        End If
    End Sub

    Private Sub btnValidate_Click(sender As Object, e As EventArgs) Handles btnValidate.Click
        GetRelianceUsersAndGroups() ' refresh the list of User and Group profiles prior to performing validation
        GetUniqueNumbers()  ' refresh the list of unique numbers prior to performing validation
        ValidateExcelData() ' validate the data in the dgvData grid

        btnExportToExcel.Enabled = True
    End Sub

    Private Sub dgvValidationIssues_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvValidationIssues.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim dr As DataGridViewRow = dgvValidationIssues.Rows(e.RowIndex)
            Dim dataRow As Integer = dr.Cells("RecordNumber").Value
            Dim dataColumn As String = dr.Cells("ColumnName").Value

            dgvData.ClearSelection()
            dgvData.Rows(dataRow).Cells(dataColumn).Selected = True
            dgvData.CurrentCell = dgvData.Item(dataColumn, dataRow)
            tabTabControl.SelectedTab = tabExcelData
        End If
    End Sub

    Private Sub btnUserGroupSearch_Click(sender As Object, e As EventArgs) Handles btnUserGroupSearch.Click
        FilterUserGroups()
    End Sub

    Private Sub btnReloadUsersGroups_Click(sender As Object, e As EventArgs) Handles btnReloadUsersGroups.Click
        GetRelianceUsersAndGroups()
    End Sub

    Private Sub txtUserGroupSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserGroupSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            FilterUserGroups()
        End If
    End Sub

    Private Sub ViewAllowedValuesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewAllowedValuesToolStripMenuItem.Click
        UpdateStatus("Fetching allowed values from Reliance...")
        Dim colName As String = dgvData.Columns(dgvData.CurrentCell.ColumnIndex).Name
        Dim colType As String = GetColumnType(colName)
        Dim dtValues As New DataTable

        Select Case colType
            Case "DIALOG", "COMBOBOX", "LISTBOX"
                _htRelianceCurrentLookupValues.Clear()
                _htRelianceCurrentLookupValues = New Hashtable

                Select Case colName
                    Case "ETQ$FILTER" ' System field (Additional Security) uses non-standard lookup methodology
                        dtValues = _dbCallsReliance.GetAdditionalSecurityValues()
                    Case "ETQ$LOCATIONS"
                        dtValues = _dbCallsReliance.GetLocationProfileValues()
                    Case Else
                        dtValues = _dbCallsReliance.GetLookupValues(colName)
                End Select

                If dtValues.Rows.Count > 0 Then
                    For Each dr As DataRow In dtValues.Rows
                        Dim valUpper = dr(1).ToString.ToUpper
                        If Not _htRelianceCurrentLookupValues.Contains(valUpper) Then
                            _htRelianceCurrentLookupValues.Add(valUpper, valUpper)    ' store the Display Value as booth the ID and Value in the hashtable
                        End If
                    Next
                End If

            Case Else
                UpdateStatus(String.Format("List values not available for {0} fields", colType))

        End Select

        UpdateStatus(String.Format("{0} values returned.", dtValues.Rows.Count))

        Dim frmValues As New frmListValues(dtValues, colName)
        frmValues.ShowDialog()

        If frmValues.DialogResult = DialogResult.OK Then
            Dim result As String = frmValues.dgvListValues.CurrentRow.Cells(1).Value
            If result <> "" Then
                dgvData.CurrentCell.Value = result
            End If
        End If
    End Sub

    Private Sub ShowFindDialog()
        Dim frmFind As New frmReplace(Me)
        frmFind.Columns = _dtColumns

        If Not dgvData.CurrentCell Is Nothing Then
            frmFind.CurrentColumn = dgvData.Columns(dgvData.CurrentCell.ColumnIndex).HeaderText

            If Not dgvData.CurrentCell.Value Is DBNull.Value Then
                frmFind.FindWhat = dgvData.CurrentCell.Value
            End If

        End If

        frmFind.Show()
    End Sub

    Private Sub ReplaceValuesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReplaceValuesToolStripMenuItem.Click
        ShowFindDialog()
    End Sub

    Public Sub FindNext(ByVal FindWhat As String)
        If FindWhat <> "" Then
            Dim startRow As Integer = dgvData.CurrentRow.Index
            Dim startColumn As Integer = dgvData.CurrentCell.ColumnIndex
            If startColumn < _dtColumns.Rows.Count - 1 Then
                startColumn += 1
            Else
                startColumn = 0
            End If
            Dim itemFound As Boolean = False

            For r = startRow To dgvData.Rows.Count - 1
                If Not dgvData.Rows(r).IsNewRow And dgvData.Rows(r) IsNot Nothing Then
                    For c = startColumn To _dtColumns.Rows.Count - 1

                        'If dgvData.Rows(r).Cells(c).Value.ToString.ToLower.Contains(FindWhat) Then  'convert to lowercase for comparison
                        If dgvData.Rows(r).Cells(c).Value.ToString.IndexOf(FindWhat, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                            dgvData.ClearSelection()
                            dgvData.Rows(r).Cells(c).Selected = True
                            dgvData.CurrentCell = dgvData.Item(c, r)
                            tabTabControl.SelectedTab = tabExcelData

                            itemFound = True
                            Exit For
                        End If
                    Next
                End If

                If itemFound Then
                    Exit For
                Else
                    startColumn = 0     'reset the starting column for the next row
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' Iterate through all rows in the selected column and find/replace related values
    ''' </summary>
    ''' <param name="ColumnName"></param>
    ''' <param name="FindWhat"></param>
    ''' <param name="ReplaceWith"></param>
    Public Sub ReplaceColumnValues(ByVal ColumnName As String, ByVal FindWhat As String, ByVal ReplaceWith As String)
        Dim i As Integer = 0
        For Each col As DataGridViewColumn In dgvData.Columns
            If col.HeaderText = ColumnName Then
                For r As Integer = 1 To dgvData.Rows.Count - 1
                    If Not dgvData.Rows(r).IsNewRow And dgvData.Rows(r) IsNot Nothing Then
                        Dim cellValue As String
                        If dgvData.Rows(r).Cells(col.Index).Value Is DBNull.Value Then
                            cellValue = ""
                        Else
                            cellValue = dgvData.Rows(r).Cells(col.Index).Value.ToString
                        End If


                        If cellValue = "" And FindWhat = "" Then
                            dgvData.Rows(r).Cells(col.Index).Value = ReplaceWith
                            i += 1
                        ElseIf FindWhat = "" Then
                            Continue For
                        ElseIf cellValue.IndexOf(FindWhat, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then  ' match found
                            dgvData.Rows(r).Cells(col.Index).Value = ReplaceWithStringComparison(cellValue, FindWhat, ReplaceWith, StringComparison.CurrentCultureIgnoreCase)
                            i += 1
                        End If
                    End If
                Next
            End If
        Next

        Dim status = String.Format("All done. {0} replacement(s) made in column [{1}].", i, ColumnName)
        UpdateStatus(status)
        MessageBox.Show(Owner, status, "Find & Replace", vbOKOnly, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Look through the entire data grid and find/replace related values
    ''' 
    ''' Note: The dgvData.DataError event handler suppresses data-type mismatches
    ''' </summary>
    ''' <param name="FindWhat"></param>
    ''' <param name="ReplaceWith"></param>
    Public Sub ReplaceAll(ByVal FindWhat As String, ByVal ReplaceWith As String)
        Dim i As Integer = 0
        For r As Integer = 1 To dgvData.Rows.Count - 1
            For c As Integer = 0 To _dtColumns.Rows.Count - 1
                If Not dgvData.Rows(r).IsNewRow And dgvData.Rows(r) IsNot Nothing Then
                    Dim cellValue As String
                    If dgvData.Rows(r).Cells(c).Value Is DBNull.Value Then
                        cellValue = ""
                    Else
                        cellValue = dgvData.Rows(r).Cells(c).Value.ToString
                    End If


                    If cellValue = "" And FindWhat = "" Then
                        dgvData.Rows(r).Cells(c).Value = ReplaceWith
                        i += 1
                    ElseIf FindWhat = "" Then
                        Continue For
                    ElseIf cellValue.IndexOf(FindWhat, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then  ' match found
                        dgvData.Rows(r).Cells(c).Value = ReplaceWithStringComparison(cellValue, FindWhat, ReplaceWith, StringComparison.CurrentCultureIgnoreCase)
                        i += 1
                    End If
                End If
            Next
        Next

        Dim status = String.Format("All done. {0} replacement(s) made across the entire data grid.", i)
        UpdateStatus(status)
        MessageBox.Show(Owner, status, "Find & Replace", vbOK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Replaces the portion of the selected string with the new value
    ''' </summary>
    ''' <param name="input"></param>
    ''' <param name="search"></param>
    ''' <param name="replace"></param>
    ''' <param name="comparison"></param>
    ''' <returns></returns>
    Public Shared Function ReplaceWithStringComparison(input As String, search As String, replace As String, comparison As StringComparison) As String
        ' handle find/replace on blank cells
        If input = "" Then
            Return replace
        End If
        ' if no search value was provided, leave as-is
        If search = "" Then
            Return input
        End If

        Dim stringBuilder = New System.Text.StringBuilder()
        Dim lastIndex = 0
        Dim currIndex = input.IndexOf(search, comparison)
        While currIndex <> -1
            stringBuilder.Append(input.Substring(lastIndex, currIndex - lastIndex))
            stringBuilder.Append(replace)
            currIndex += search.Length
            lastIndex = currIndex
            currIndex = input.IndexOf(search, currIndex, comparison)
        End While
        stringBuilder.Append(input.Substring(lastIndex))

        Return stringBuilder.ToString()
    End Function

    ''' <summary>
    ''' This method catches and suppresses all data-type errors detected by the find/replace operations
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvData_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvData.DataError
        'do nothing
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Control) Then ' CTRL + F
            ShowFindDialog()
        End If
    End Sub

    Private Sub dgvData_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvData.KeyDown
        If (e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Control) Then ' CTRL + F
            ShowFindDialog()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ImportBusinessesFromFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportBusinessesFromFileToolStripMenuItem.Click
        Try
            Dim fd As OpenFileDialog = New OpenFileDialog()
            fd.InitialDirectory = Path.GetFullPath(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments))
            fd.ShowDialog()
            If fd.FileName <> "" Then LoadBusinessesFromFile(fd.FileName)

        Catch ex As Exception
            MessageBox.Show("Error!  " & ex.Message + System.Environment.NewLine + System.Environment.NewLine & "No business definitions were imported.  The syntax for the import file should be bar-delimited (|) and should not contain column headings" + System.Environment.NewLine, "Import failed")
        End Try
    End Sub

    Private Sub LoadBusinessesFromFile(ByVal FilePath As String)
        Try
            Dim sr As StreamReader = New StreamReader(FilePath)
            Dim busCount As Integer = 0

            If GlobalVar.bc Is Nothing Then
                GlobalVar.bc = New BusinessCollection
            End If

            While Not sr.EndOfStream
                GlobalVar.bc.AddBusiness(GlobalVar.bc.ConvertStringToBusiness(sr.ReadLine()))
                busCount += 1
            End While

            If busCount = 0 Then
                MessageBox.Show(Path.GetFileName(FilePath) & " did not contain any valid business definitions.")
                Return
            End If

            sr.Dispose()
            sr.Close()

            GetBusinesses()
            MessageBox.Show(busCount & " business definitions imported successfully from " & Path.GetFileName(FilePath), "Import complete", MessageBoxButtons.OK)

        Catch ex As Exception
            MessageBox.Show("Error loading business definitions from file." & vbCrLf & ex.Message, "Load error", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ExportBusinessDefinitionsToFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportBusinessDefinitionsToFileToolStripMenuItem.Click
        Try
            If GlobalVar.bc.GetBusinessCount < 1 Then
                MessageBox.Show("No business definitions to export.", "No businesses", MessageBoxButtons.OK)
                Exit Sub
            End If

            Dim sd As SaveFileDialog = New SaveFileDialog()
            sd.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop)
            sd.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*"
            sd.Title = "Export Business Definition(s)..."
            Dim count As Integer = 0

            If sd.ShowDialog() = DialogResult.OK Then
                Dim sw As StreamWriter = New StreamWriter(sd.FileName)

                For Each bus As Business In GlobalVar.bc.GetBusinesses(True)
                    count += 1
                    sw.WriteLine(GlobalVar.bc.ConvertBusinessToString(bus))
                Next

                sw.Close()
                sw.Dispose()
            End If

            UpdateStatus(count & " definitions exported")

        Catch ex As Exception
            MessageBox.Show("Error exporting business definitions." & vbCrLf & ex.Message, "Export error", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ImportEnvironmentsFromFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportEnvironmentsFromFileToolStripMenuItem.Click
        Try
            Dim fd As OpenFileDialog = New OpenFileDialog()
            fd.InitialDirectory = Path.GetFullPath(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments))
            fd.ShowDialog()
            If fd.FileName <> "" Then LoadEnvironmentsFromFile(fd.FileName)

        Catch ex As Exception
            MessageBox.Show("Error!  " & ex.Message + System.Environment.NewLine + System.Environment.NewLine & "No environment definitions were imported.  The syntax for the import file should be bar-delimited (|) and should not contain column headings" + System.Environment.NewLine, "Import failed")
        End Try
    End Sub

    Private Sub LoadEnvironmentsFromFile(ByVal FilePath As String)
        Try
            Dim sr As StreamReader = New StreamReader(FilePath)
            Dim envCount As Integer = 0

            If GlobalVar.ec Is Nothing Then
                GlobalVar.ec = New EnvironmentCollection
            End If

            While Not sr.EndOfStream
                GlobalVar.ec.AddEnvironment(GlobalVar.ec.ConvertStringToEnvironment(sr.ReadLine()))
                envCount += 1
            End While

            If envCount = 0 Then
                MessageBox.Show(Path.GetFileName(FilePath) & " did not contain any valid environment definitions.")
                Return
            End If

            sr.Dispose()
            sr.Close()

            GetEnvironments()
            MessageBox.Show(envCount & " environment definitions imported successfully from " & Path.GetFileName(FilePath), "Import complete", MessageBoxButtons.OK)

        Catch ex As Exception
            MessageBox.Show("Error loading business definitions from file." & vbCrLf & ex.Message, "Load error", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ExportEnvironmentsToFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportEnvironmentsToFileToolStripMenuItem.Click
        Try
            If GlobalVar.ec.GetEnvironmentCount < 1 Then
                MessageBox.Show("No environment definitions to export.", "No environments", MessageBoxButtons.OK)
                Exit Sub
            End If

            Dim sd As SaveFileDialog = New SaveFileDialog()
            sd.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop)
            sd.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*"
            sd.Title = "Export Environment Definition(s)..."
            Dim count As Integer = 0

            If sd.ShowDialog() = DialogResult.OK Then
                Dim sw As StreamWriter = New StreamWriter(sd.FileName)

                For Each env As Environment In GlobalVar.ec.GetEnvironments
                    count += 1
                    sw.WriteLine(GlobalVar.ec.ConvertEnvironmentToString(env))
                Next

                sw.Close()
                sw.Dispose()
            End If

            UpdateStatus(count & " definitions exported")

        Catch ex As Exception
            MessageBox.Show("Error exporting environment definitions." & vbCrLf & ex.Message, "Export error", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub RemoveAllBusinessesAndEnvironmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveAllBusinessesAndEnvironmentsToolStripMenuItem.Click
        If GlobalVar.bc.GetBusinessCount > 0 Or GlobalVar.ec.GetEnvironmentCount > 0 Then
            If MessageBox.Show(String.Format("Are you sure you want to remove the {0} business and {1} environment settings?", GlobalVar.bc.GetBusinessCount, GlobalVar.ec.GetEnvironmentCount), "Delete Business and Environment settings?", MessageBoxButtons.YesNoCancel) = DialogResult.Yes Then
                GlobalVar.bc = New BusinessCollection
                GlobalVar.ec = New EnvironmentCollection
                GetBusinesses()
                GetEnvironments()
                MessageBox.Show("Business and Environment definitions removed successfully")
            End If
        Else
            MessageBox.Show("There are no Business and Environment definitions to remove")
        End If
    End Sub

    Private Sub ViewSavedBusinessAndEnvironmentSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewSavedBusinessAndEnvironmentSettingsToolStripMenuItem.Click
        Dim frmBusEnv As New frmBusinessProperties
        frmBusEnv.ShowDialog()
        SaveAppSettings()
        GetBusinesses() 'refresh the business list
    End Sub

    Private Sub AddBusinessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddBusinessToolStripMenuItem.Click
        Dim frmBusEnv As New frmBusinessProperties
        frmBusEnv.ShowDialog()
        SaveAppSettings()
        GetBusinesses() 'refresh the business list
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If CurrentEnvironment IsNot Nothing And CurrentEnvironment.Environment_URL <> "" Then
            Process.Start(CurrentEnvironment.Environment_URL)
        End If
    End Sub
#End Region
End Class
