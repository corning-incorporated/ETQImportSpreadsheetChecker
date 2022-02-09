' **************************************************
'   Copyright 2022 Corning Incorporated
'   Author: Tom Gee
' **************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.cboBusiness = New System.Windows.Forms.ComboBox()
        Me.lblBusiness = New System.Windows.Forms.Label()
        Me.lblEnvironment = New System.Windows.Forms.Label()
        Me.cboEnvironment = New System.Windows.Forms.ComboBox()
        Me.btnExcelFile = New System.Windows.Forms.Button()
        Me.txtExcelFile = New System.Windows.Forms.TextBox()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.lblExcelFile = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.progProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.progProgressMinor = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblApplication = New System.Windows.Forms.Label()
        Me.cboApplication = New System.Windows.Forms.ComboBox()
        Me.lblForm = New System.Windows.Forms.Label()
        Me.cboForm = New System.Windows.Forms.ComboBox()
        Me.btnExportToExcel = New System.Windows.Forms.Button()
        Me.cboSubform = New System.Windows.Forms.ComboBox()
        Me.chkSubform = New System.Windows.Forms.CheckBox()
        Me.btnValidate = New System.Windows.Forms.Button()
        Me.tabValidationIssues = New System.Windows.Forms.TabPage()
        Me.dgvValidationIssues = New System.Windows.Forms.DataGridView()
        Me.ColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecordNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FieldType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecordValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValueIssue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabUsersGroups = New System.Windows.Forms.TabPage()
        Me.btnReloadUsersGroups = New System.Windows.Forms.Button()
        Me.btnUserGroupSearch = New System.Windows.Forms.Button()
        Me.txtUserGroupSearch = New System.Windows.Forms.TextBox()
        Me.dgvUsersGroups = New System.Windows.Forms.DataGridView()
        Me.tabExcelData = New System.Windows.Forms.TabPage()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.mnuContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewAllowedValuesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReplaceValuesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabTabControl = New System.Windows.Forms.TabControl()
        Me.chkValidateAttachments = New System.Windows.Forms.CheckBox()
        Me.mnu_Menu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddBusinessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImportBusinessesFromFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportBusinessDefinitionsToFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImportEnvironmentsFromFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportEnvironmentsToFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RemoveAllBusinessesAndEnvironmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewSavedBusinessAndEnvironmentSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.tabValidationIssues.SuspendLayout()
        CType(Me.dgvValidationIssues, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabUsersGroups.SuspendLayout()
        CType(Me.dgvUsersGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabExcelData.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuContextMenu.SuspendLayout()
        Me.tabTabControl.SuspendLayout()
        Me.mnu_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboBusiness
        '
        Me.cboBusiness.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBusiness.FormattingEnabled = True
        Me.cboBusiness.Location = New System.Drawing.Point(105, 27)
        Me.cboBusiness.Name = "cboBusiness"
        Me.cboBusiness.Size = New System.Drawing.Size(164, 26)
        Me.cboBusiness.TabIndex = 0
        '
        'lblBusiness
        '
        Me.lblBusiness.AutoSize = True
        Me.lblBusiness.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusiness.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblBusiness.Location = New System.Drawing.Point(17, 30)
        Me.lblBusiness.Name = "lblBusiness"
        Me.lblBusiness.Size = New System.Drawing.Size(82, 18)
        Me.lblBusiness.TabIndex = 1
        Me.lblBusiness.Text = "Business:"
        '
        'lblEnvironment
        '
        Me.lblEnvironment.AutoSize = True
        Me.lblEnvironment.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnvironment.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblEnvironment.Location = New System.Drawing.Point(275, 30)
        Me.lblEnvironment.Name = "lblEnvironment"
        Me.lblEnvironment.Size = New System.Drawing.Size(107, 18)
        Me.lblEnvironment.TabIndex = 3
        Me.lblEnvironment.Text = "Environment:"
        '
        'cboEnvironment
        '
        Me.cboEnvironment.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEnvironment.FormattingEnabled = True
        Me.cboEnvironment.Location = New System.Drawing.Point(388, 27)
        Me.cboEnvironment.Name = "cboEnvironment"
        Me.cboEnvironment.Size = New System.Drawing.Size(95, 26)
        Me.cboEnvironment.TabIndex = 2
        '
        'btnExcelFile
        '
        Me.btnExcelFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcelFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelFile.Location = New System.Drawing.Point(988, 58)
        Me.btnExcelFile.Name = "btnExcelFile"
        Me.btnExcelFile.Size = New System.Drawing.Size(110, 26)
        Me.btnExcelFile.TabIndex = 5
        Me.btnExcelFile.Text = "Choose File"
        Me.btnExcelFile.UseVisualStyleBackColor = True
        '
        'txtExcelFile
        '
        Me.txtExcelFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExcelFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExcelFile.Location = New System.Drawing.Point(105, 60)
        Me.txtExcelFile.Name = "txtExcelFile"
        Me.txtExcelFile.Size = New System.Drawing.Size(877, 23)
        Me.txtExcelFile.TabIndex = 6
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Enabled = False
        Me.btnImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImport.Location = New System.Drawing.Point(1104, 58)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(150, 26)
        Me.btnImport.TabIndex = 7
        Me.btnImport.Text = " Import from Excel"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'lblExcelFile
        '
        Me.lblExcelFile.AutoSize = True
        Me.lblExcelFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExcelFile.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblExcelFile.Location = New System.Drawing.Point(13, 61)
        Me.lblExcelFile.Name = "lblExcelFile"
        Me.lblExcelFile.Size = New System.Drawing.Size(86, 18)
        Me.lblExcelFile.TabIndex = 9
        Me.lblExcelFile.Text = "Excel File:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.progProgress, Me.progProgressMinor, Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 798)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1639, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'progProgress
        '
        Me.progProgress.Name = "progProgress"
        Me.progProgress.Size = New System.Drawing.Size(100, 16)
        Me.progProgress.Visible = False
        '
        'progProgressMinor
        '
        Me.progProgressMinor.Name = "progProgressMinor"
        Me.progProgressMinor.Size = New System.Drawing.Size(100, 16)
        Me.progProgressMinor.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'lblApplication
        '
        Me.lblApplication.AutoSize = True
        Me.lblApplication.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApplication.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblApplication.Location = New System.Drawing.Point(489, 30)
        Me.lblApplication.Name = "lblApplication"
        Me.lblApplication.Size = New System.Drawing.Size(95, 18)
        Me.lblApplication.TabIndex = 13
        Me.lblApplication.Text = "Application:"
        '
        'cboApplication
        '
        Me.cboApplication.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboApplication.FormattingEnabled = True
        Me.cboApplication.Location = New System.Drawing.Point(590, 27)
        Me.cboApplication.Name = "cboApplication"
        Me.cboApplication.Size = New System.Drawing.Size(273, 26)
        Me.cboApplication.TabIndex = 12
        '
        'lblForm
        '
        Me.lblForm.AutoSize = True
        Me.lblForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForm.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblForm.Location = New System.Drawing.Point(880, 30)
        Me.lblForm.Name = "lblForm"
        Me.lblForm.Size = New System.Drawing.Size(53, 18)
        Me.lblForm.TabIndex = 15
        Me.lblForm.Text = "Form:"
        '
        'cboForm
        '
        Me.cboForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboForm.FormattingEnabled = True
        Me.cboForm.Location = New System.Drawing.Point(939, 27)
        Me.cboForm.Name = "cboForm"
        Me.cboForm.Size = New System.Drawing.Size(272, 26)
        Me.cboForm.TabIndex = 14
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportToExcel.Enabled = False
        Me.btnExportToExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportToExcel.Location = New System.Drawing.Point(1503, 58)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(124, 26)
        Me.btnExportToExcel.TabIndex = 17
        Me.btnExportToExcel.Text = "Export to Excel"
        Me.btnExportToExcel.UseVisualStyleBackColor = True
        '
        'cboSubform
        '
        Me.cboSubform.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSubform.Enabled = False
        Me.cboSubform.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSubform.FormattingEnabled = True
        Me.cboSubform.Location = New System.Drawing.Point(1336, 27)
        Me.cboSubform.Name = "cboSubform"
        Me.cboSubform.Size = New System.Drawing.Size(291, 26)
        Me.cboSubform.TabIndex = 18
        '
        'chkSubform
        '
        Me.chkSubform.AutoSize = True
        Me.chkSubform.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.chkSubform.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.chkSubform.Location = New System.Drawing.Point(1234, 29)
        Me.chkSubform.Name = "chkSubform"
        Me.chkSubform.Size = New System.Drawing.Size(96, 22)
        Me.chkSubform.TabIndex = 20
        Me.chkSubform.Text = "Subform:"
        Me.chkSubform.UseVisualStyleBackColor = True
        '
        'btnValidate
        '
        Me.btnValidate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnValidate.Enabled = False
        Me.btnValidate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValidate.Location = New System.Drawing.Point(1260, 58)
        Me.btnValidate.Name = "btnValidate"
        Me.btnValidate.Size = New System.Drawing.Size(124, 26)
        Me.btnValidate.TabIndex = 21
        Me.btnValidate.Text = "Validate Data"
        Me.btnValidate.UseVisualStyleBackColor = True
        '
        'tabValidationIssues
        '
        Me.tabValidationIssues.Controls.Add(Me.dgvValidationIssues)
        Me.tabValidationIssues.Location = New System.Drawing.Point(4, 25)
        Me.tabValidationIssues.Name = "tabValidationIssues"
        Me.tabValidationIssues.Size = New System.Drawing.Size(1631, 683)
        Me.tabValidationIssues.TabIndex = 4
        Me.tabValidationIssues.Text = "Validation Issues"
        Me.tabValidationIssues.UseVisualStyleBackColor = True
        '
        'dgvValidationIssues
        '
        Me.dgvValidationIssues.AllowUserToAddRows = False
        Me.dgvValidationIssues.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SandyBrown
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvValidationIssues.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvValidationIssues.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvValidationIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvValidationIssues.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnName, Me.RecordNumber, Me.FieldType, Me.RecordValue, Me.ValueIssue})
        Me.dgvValidationIssues.Location = New System.Drawing.Point(3, 0)
        Me.dgvValidationIssues.Name = "dgvValidationIssues"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvValidationIssues.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvValidationIssues.Size = New System.Drawing.Size(1625, 683)
        Me.dgvValidationIssues.TabIndex = 13
        '
        'ColumnName
        '
        Me.ColumnName.HeaderText = "Column Name"
        Me.ColumnName.Name = "ColumnName"
        Me.ColumnName.ReadOnly = True
        '
        'RecordNumber
        '
        Me.RecordNumber.HeaderText = "Record #"
        Me.RecordNumber.Name = "RecordNumber"
        Me.RecordNumber.ReadOnly = True
        '
        'FieldType
        '
        Me.FieldType.HeaderText = "Type"
        Me.FieldType.Name = "FieldType"
        Me.FieldType.ReadOnly = True
        '
        'RecordValue
        '
        Me.RecordValue.HeaderText = "Value"
        Me.RecordValue.Name = "RecordValue"
        '
        'ValueIssue
        '
        Me.ValueIssue.HeaderText = "Potential Issue"
        Me.ValueIssue.Name = "ValueIssue"
        Me.ValueIssue.ReadOnly = True
        '
        'tabUsersGroups
        '
        Me.tabUsersGroups.Controls.Add(Me.btnReloadUsersGroups)
        Me.tabUsersGroups.Controls.Add(Me.btnUserGroupSearch)
        Me.tabUsersGroups.Controls.Add(Me.txtUserGroupSearch)
        Me.tabUsersGroups.Controls.Add(Me.dgvUsersGroups)
        Me.tabUsersGroups.Location = New System.Drawing.Point(4, 25)
        Me.tabUsersGroups.Name = "tabUsersGroups"
        Me.tabUsersGroups.Size = New System.Drawing.Size(1631, 683)
        Me.tabUsersGroups.TabIndex = 3
        Me.tabUsersGroups.Text = "Reliance Users / Groups"
        Me.tabUsersGroups.UseVisualStyleBackColor = True
        '
        'btnReloadUsersGroups
        '
        Me.btnReloadUsersGroups.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReloadUsersGroups.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReloadUsersGroups.Location = New System.Drawing.Point(1513, 6)
        Me.btnReloadUsersGroups.Name = "btnReloadUsersGroups"
        Me.btnReloadUsersGroups.Size = New System.Drawing.Size(110, 31)
        Me.btnReloadUsersGroups.TabIndex = 16
        Me.btnReloadUsersGroups.Text = "Reload"
        Me.btnReloadUsersGroups.UseVisualStyleBackColor = True
        '
        'btnUserGroupSearch
        '
        Me.btnUserGroupSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUserGroupSearch.Location = New System.Drawing.Point(204, 6)
        Me.btnUserGroupSearch.Name = "btnUserGroupSearch"
        Me.btnUserGroupSearch.Size = New System.Drawing.Size(110, 31)
        Me.btnUserGroupSearch.TabIndex = 15
        Me.btnUserGroupSearch.Text = "Search"
        Me.btnUserGroupSearch.UseVisualStyleBackColor = True
        '
        'txtUserGroupSearch
        '
        Me.txtUserGroupSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserGroupSearch.Location = New System.Drawing.Point(8, 10)
        Me.txtUserGroupSearch.Name = "txtUserGroupSearch"
        Me.txtUserGroupSearch.Size = New System.Drawing.Size(190, 23)
        Me.txtUserGroupSearch.TabIndex = 14
        '
        'dgvUsersGroups
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUsersGroups.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvUsersGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvUsersGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsersGroups.Location = New System.Drawing.Point(2, 41)
        Me.dgvUsersGroups.Name = "dgvUsersGroups"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SandyBrown
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUsersGroups.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvUsersGroups.Size = New System.Drawing.Size(1626, 642)
        Me.dgvUsersGroups.TabIndex = 12
        '
        'tabExcelData
        '
        Me.tabExcelData.BackColor = System.Drawing.Color.Transparent
        Me.tabExcelData.Controls.Add(Me.dgvData)
        Me.tabExcelData.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabExcelData.Location = New System.Drawing.Point(4, 25)
        Me.tabExcelData.Name = "tabExcelData"
        Me.tabExcelData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabExcelData.Size = New System.Drawing.Size(1631, 683)
        Me.tabExcelData.TabIndex = 0
        Me.tabExcelData.Text = "Excel Data"
        '
        'dgvData
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.ContextMenuStrip = Me.mnuContextMenu
        Me.dgvData.Location = New System.Drawing.Point(2, 0)
        Me.dgvData.Name = "dgvData"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SandyBrown
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvData.Size = New System.Drawing.Size(1626, 683)
        Me.dgvData.TabIndex = 12
        '
        'mnuContextMenu
        '
        Me.mnuContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewAllowedValuesToolStripMenuItem, Me.ReplaceValuesToolStripMenuItem})
        Me.mnuContextMenu.Name = "mnuContextMenu"
        Me.mnuContextMenu.Size = New System.Drawing.Size(188, 48)
        '
        'ViewAllowedValuesToolStripMenuItem
        '
        Me.ViewAllowedValuesToolStripMenuItem.Name = "ViewAllowedValuesToolStripMenuItem"
        Me.ViewAllowedValuesToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ViewAllowedValuesToolStripMenuItem.Text = "View allowed values"
        '
        'ReplaceValuesToolStripMenuItem
        '
        Me.ReplaceValuesToolStripMenuItem.Name = "ReplaceValuesToolStripMenuItem"
        Me.ReplaceValuesToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ReplaceValuesToolStripMenuItem.Text = "Find/Replace value(s)"
        '
        'tabTabControl
        '
        Me.tabTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabTabControl.Controls.Add(Me.tabExcelData)
        Me.tabTabControl.Controls.Add(Me.tabUsersGroups)
        Me.tabTabControl.Controls.Add(Me.tabValidationIssues)
        Me.tabTabControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabTabControl.Location = New System.Drawing.Point(0, 83)
        Me.tabTabControl.Multiline = True
        Me.tabTabControl.Name = "tabTabControl"
        Me.tabTabControl.Padding = New System.Drawing.Point(15, 3)
        Me.tabTabControl.SelectedIndex = 0
        Me.tabTabControl.Size = New System.Drawing.Size(1639, 712)
        Me.tabTabControl.TabIndex = 16
        '
        'chkValidateAttachments
        '
        Me.chkValidateAttachments.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkValidateAttachments.AutoSize = True
        Me.chkValidateAttachments.BackColor = System.Drawing.Color.Transparent
        Me.chkValidateAttachments.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkValidateAttachments.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.chkValidateAttachments.Location = New System.Drawing.Point(1234, 84)
        Me.chkValidateAttachments.Name = "chkValidateAttachments"
        Me.chkValidateAttachments.Size = New System.Drawing.Size(184, 22)
        Me.chkValidateAttachments.TabIndex = 22
        Me.chkValidateAttachments.Text = "Validate Attachments"
        Me.chkValidateAttachments.UseVisualStyleBackColor = False
        '
        'mnu_Menu
        '
        Me.mnu_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem})
        Me.mnu_Menu.Location = New System.Drawing.Point(0, 0)
        Me.mnu_Menu.Name = "mnu_Menu"
        Me.mnu_Menu.Size = New System.Drawing.Size(1639, 24)
        Me.mnu_Menu.TabIndex = 23
        Me.mnu_Menu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddBusinessToolStripMenuItem, Me.ToolStripSeparator4, Me.ImportBusinessesFromFileToolStripMenuItem, Me.ExportBusinessDefinitionsToFileToolStripMenuItem, Me.ToolStripSeparator2, Me.ImportEnvironmentsFromFileToolStripMenuItem, Me.ExportEnvironmentsToFileToolStripMenuItem, Me.ToolStripSeparator1, Me.RemoveAllBusinessesAndEnvironmentsToolStripMenuItem, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'AddBusinessToolStripMenuItem
        '
        Me.AddBusinessToolStripMenuItem.Name = "AddBusinessToolStripMenuItem"
        Me.AddBusinessToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.AddBusinessToolStripMenuItem.Text = "Add Business"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(303, 6)
        '
        'ImportBusinessesFromFileToolStripMenuItem
        '
        Me.ImportBusinessesFromFileToolStripMenuItem.Name = "ImportBusinessesFromFileToolStripMenuItem"
        Me.ImportBusinessesFromFileToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.ImportBusinessesFromFileToolStripMenuItem.Text = "Import Business(es) from file"
        '
        'ExportBusinessDefinitionsToFileToolStripMenuItem
        '
        Me.ExportBusinessDefinitionsToFileToolStripMenuItem.Name = "ExportBusinessDefinitionsToFileToolStripMenuItem"
        Me.ExportBusinessDefinitionsToFileToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.ExportBusinessDefinitionsToFileToolStripMenuItem.Text = "Export Business definition(s) to file"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(303, 6)
        '
        'ImportEnvironmentsFromFileToolStripMenuItem
        '
        Me.ImportEnvironmentsFromFileToolStripMenuItem.Name = "ImportEnvironmentsFromFileToolStripMenuItem"
        Me.ImportEnvironmentsFromFileToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.ImportEnvironmentsFromFileToolStripMenuItem.Text = "Import Environment(s) from file"
        '
        'ExportEnvironmentsToFileToolStripMenuItem
        '
        Me.ExportEnvironmentsToFileToolStripMenuItem.Name = "ExportEnvironmentsToFileToolStripMenuItem"
        Me.ExportEnvironmentsToFileToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.ExportEnvironmentsToFileToolStripMenuItem.Text = "Export Environment(s) to file"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(303, 6)
        '
        'RemoveAllBusinessesAndEnvironmentsToolStripMenuItem
        '
        Me.RemoveAllBusinessesAndEnvironmentsToolStripMenuItem.Name = "RemoveAllBusinessesAndEnvironmentsToolStripMenuItem"
        Me.RemoveAllBusinessesAndEnvironmentsToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.RemoveAllBusinessesAndEnvironmentsToolStripMenuItem.Text = "Remove all Business(es) and Environment(s)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(303, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewSavedBusinessAndEnvironmentSettingsToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'ViewSavedBusinessAndEnvironmentSettingsToolStripMenuItem
        '
        Me.ViewSavedBusinessAndEnvironmentSettingsToolStripMenuItem.Name = "ViewSavedBusinessAndEnvironmentSettingsToolStripMenuItem"
        Me.ViewSavedBusinessAndEnvironmentSettingsToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.ViewSavedBusinessAndEnvironmentSettingsToolStripMenuItem.Text = "View saved Business and Environment settings"
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.Enabled = False
        Me.btnLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Location = New System.Drawing.Point(1390, 57)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(107, 26)
        Me.btnLogin.TabIndex = 24
        Me.btnLogin.Text = "Login URL"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1639, 820)
        Me.Controls.Add(Me.chkValidateAttachments)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.btnValidate)
        Me.Controls.Add(Me.chkSubform)
        Me.Controls.Add(Me.cboSubform)
        Me.Controls.Add(Me.btnExportToExcel)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnExcelFile)
        Me.Controls.Add(Me.tabTabControl)
        Me.Controls.Add(Me.lblForm)
        Me.Controls.Add(Me.cboForm)
        Me.Controls.Add(Me.lblApplication)
        Me.Controls.Add(Me.cboApplication)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.mnu_Menu)
        Me.Controls.Add(Me.lblExcelFile)
        Me.Controls.Add(Me.txtExcelFile)
        Me.Controls.Add(Me.lblEnvironment)
        Me.Controls.Add(Me.cboEnvironment)
        Me.Controls.Add(Me.lblBusiness)
        Me.Controls.Add(Me.cboBusiness)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnu_Menu
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ETQ Reliance Import Spreadsheet Validation Utility"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tabValidationIssues.ResumeLayout(False)
        CType(Me.dgvValidationIssues, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabUsersGroups.ResumeLayout(False)
        Me.tabUsersGroups.PerformLayout()
        CType(Me.dgvUsersGroups, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabExcelData.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuContextMenu.ResumeLayout(False)
        Me.tabTabControl.ResumeLayout(False)
        Me.mnu_Menu.ResumeLayout(False)
        Me.mnu_Menu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboBusiness As ComboBox
    Friend WithEvents lblBusiness As Label
    Friend WithEvents lblEnvironment As Label
    Friend WithEvents cboEnvironment As ComboBox
    Friend WithEvents btnExcelFile As Button
    Friend WithEvents txtExcelFile As TextBox
    Friend WithEvents btnImport As Button
    Friend WithEvents lblExcelFile As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents lblApplication As Label
    Friend WithEvents cboApplication As ComboBox
    Friend WithEvents lblForm As Label
    Friend WithEvents cboForm As ComboBox
    Friend WithEvents btnExportToExcel As Button
    Friend WithEvents cboSubform As ComboBox
    Friend WithEvents chkSubform As CheckBox
    Friend WithEvents btnValidate As Button
    Friend WithEvents tabValidationIssues As TabPage
    Friend WithEvents dgvValidationIssues As DataGridView
    Friend WithEvents ColumnName As DataGridViewTextBoxColumn
    Friend WithEvents RecordNumber As DataGridViewTextBoxColumn
    Friend WithEvents FieldType As DataGridViewTextBoxColumn
    Friend WithEvents RecordValue As DataGridViewTextBoxColumn
    Friend WithEvents ValueIssue As DataGridViewTextBoxColumn
    Friend WithEvents tabUsersGroups As TabPage
    Friend WithEvents dgvUsersGroups As DataGridView
    Friend WithEvents tabExcelData As TabPage
    Friend WithEvents dgvData As DataGridView
    Friend WithEvents tabTabControl As TabControl
    Friend WithEvents progProgress As ToolStripProgressBar
    Friend WithEvents progProgressMinor As ToolStripProgressBar
    Friend WithEvents chkValidateAttachments As CheckBox
    Friend WithEvents btnUserGroupSearch As Button
    Friend WithEvents txtUserGroupSearch As TextBox
    Friend WithEvents btnReloadUsersGroups As Button
    Friend WithEvents mnuContextMenu As ContextMenuStrip
    Friend WithEvents ViewAllowedValuesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReplaceValuesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnu_Menu As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddBusinessToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportBusinessesFromFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportBusinessDefinitionsToFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportEnvironmentsFromFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportEnvironmentsToFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents RemoveAllBusinessesAndEnvironmentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewSavedBusinessAndEnvironmentSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnLogin As Button
End Class
