' **************************************************
'   Copyright 2022 Corning Incorporated
'   Author: Tom Gee
' **************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBusinessProperties
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBusinessProperties))
        Me.cboBusinessID = New System.Windows.Forms.ComboBox()
        Me.lblBusinessID = New System.Windows.Forms.Label()
        Me.txtBusinessName = New System.Windows.Forms.TextBox()
        Me.lblBusinessName = New System.Windows.Forms.Label()
        Me.lblHostingType = New System.Windows.Forms.Label()
        Me.cboHostingType = New System.Windows.Forms.ComboBox()
        Me.lblFTPHostFingerprint = New System.Windows.Forms.Label()
        Me.txtFTPHostFingerprint = New System.Windows.Forms.TextBox()
        Me.lblFTPUser = New System.Windows.Forms.Label()
        Me.txtFTPUser = New System.Windows.Forms.TextBox()
        Me.lblFTPAddress = New System.Windows.Forms.Label()
        Me.txtFTPAddress = New System.Windows.Forms.TextBox()
        Me.lblFTPPort = New System.Windows.Forms.Label()
        Me.txtFTPPort = New System.Windows.Forms.TextBox()
        Me.lblFTPPassword = New System.Windows.Forms.Label()
        Me.txtFTPPassword = New System.Windows.Forms.TextBox()
        Me.dgvEnvironments = New System.Windows.Forms.DataGridView()
        Me.Environment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnvironmentURL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AppServer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Version = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DBServerAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DBUsername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DBPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatabaseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EtQAdministratorPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Active = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lblEnvironments = New System.Windows.Forms.Label()
        Me.lblFTPLocalPath = New System.Windows.Forms.Label()
        Me.txtFTPLocalPath = New System.Windows.Forms.TextBox()
        Me.btn_ShowFTPPassword = New System.Windows.Forms.Button()
        Me.chkBusinessActive = New System.Windows.Forms.CheckBox()
        Me.btnSaveAndClose = New System.Windows.Forms.Button()
        CType(Me.dgvEnvironments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboBusinessID
        '
        Me.cboBusinessID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.cboBusinessID.FormattingEnabled = True
        Me.cboBusinessID.Location = New System.Drawing.Point(121, 12)
        Me.cboBusinessID.Name = "cboBusinessID"
        Me.cboBusinessID.Size = New System.Drawing.Size(100, 26)
        Me.cboBusinessID.TabIndex = 0
        '
        'lblBusinessID
        '
        Me.lblBusinessID.AutoSize = True
        Me.lblBusinessID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblBusinessID.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblBusinessID.Location = New System.Drawing.Point(86, 17)
        Me.lblBusinessID.Name = "lblBusinessID"
        Me.lblBusinessID.Size = New System.Drawing.Size(28, 17)
        Me.lblBusinessID.TabIndex = 1
        Me.lblBusinessID.Text = "ID:"
        '
        'txtBusinessName
        '
        Me.txtBusinessName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtBusinessName.Location = New System.Drawing.Point(290, 12)
        Me.txtBusinessName.Name = "txtBusinessName"
        Me.txtBusinessName.Size = New System.Drawing.Size(365, 24)
        Me.txtBusinessName.TabIndex = 2
        '
        'lblBusinessName
        '
        Me.lblBusinessName.AutoSize = True
        Me.lblBusinessName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblBusinessName.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblBusinessName.Location = New System.Drawing.Point(230, 17)
        Me.lblBusinessName.Name = "lblBusinessName"
        Me.lblBusinessName.Size = New System.Drawing.Size(54, 17)
        Me.lblBusinessName.TabIndex = 3
        Me.lblBusinessName.Text = "Name:"
        '
        'lblHostingType
        '
        Me.lblHostingType.AutoSize = True
        Me.lblHostingType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblHostingType.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblHostingType.Location = New System.Drawing.Point(676, 17)
        Me.lblHostingType.Name = "lblHostingType"
        Me.lblHostingType.Size = New System.Drawing.Size(109, 17)
        Me.lblHostingType.TabIndex = 5
        Me.lblHostingType.Text = "Hosting Type:"
        '
        'cboHostingType
        '
        Me.cboHostingType.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.cboHostingType.FormattingEnabled = True
        Me.cboHostingType.Items.AddRange(New Object() {"On-Premise", "Hosted"})
        Me.cboHostingType.Location = New System.Drawing.Point(791, 12)
        Me.cboHostingType.Name = "cboHostingType"
        Me.cboHostingType.Size = New System.Drawing.Size(156, 26)
        Me.cboHostingType.TabIndex = 4
        '
        'lblFTPHostFingerprint
        '
        Me.lblFTPHostFingerprint.AutoSize = True
        Me.lblFTPHostFingerprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblFTPHostFingerprint.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblFTPHostFingerprint.Location = New System.Drawing.Point(195, 94)
        Me.lblFTPHostFingerprint.Name = "lblFTPHostFingerprint"
        Me.lblFTPHostFingerprint.Size = New System.Drawing.Size(164, 17)
        Me.lblFTPHostFingerprint.TabIndex = 17
        Me.lblFTPHostFingerprint.Text = "FTP Host Fingerprint:"
        '
        'txtFTPHostFingerprint
        '
        Me.txtFTPHostFingerprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFTPHostFingerprint.Location = New System.Drawing.Point(365, 89)
        Me.txtFTPHostFingerprint.Multiline = True
        Me.txtFTPHostFingerprint.Name = "txtFTPHostFingerprint"
        Me.txtFTPHostFingerprint.Size = New System.Drawing.Size(290, 52)
        Me.txtFTPHostFingerprint.TabIndex = 16
        '
        'lblFTPUser
        '
        Me.lblFTPUser.AutoSize = True
        Me.lblFTPUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblFTPUser.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblFTPUser.Location = New System.Drawing.Point(412, 60)
        Me.lblFTPUser.Name = "lblFTPUser"
        Me.lblFTPUser.Size = New System.Drawing.Size(81, 17)
        Me.lblFTPUser.TabIndex = 15
        Me.lblFTPUser.Text = "FTP User:"
        '
        'txtFTPUser
        '
        Me.txtFTPUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtFTPUser.Location = New System.Drawing.Point(499, 55)
        Me.txtFTPUser.Name = "txtFTPUser"
        Me.txtFTPUser.Size = New System.Drawing.Size(156, 24)
        Me.txtFTPUser.TabIndex = 14
        '
        'lblFTPAddress
        '
        Me.lblFTPAddress.AutoSize = True
        Me.lblFTPAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblFTPAddress.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblFTPAddress.Location = New System.Drawing.Point(9, 58)
        Me.lblFTPAddress.Name = "lblFTPAddress"
        Me.lblFTPAddress.Size = New System.Drawing.Size(106, 17)
        Me.lblFTPAddress.TabIndex = 13
        Me.lblFTPAddress.Text = "FTP Address:"
        '
        'txtFTPAddress
        '
        Me.txtFTPAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtFTPAddress.Location = New System.Drawing.Point(121, 53)
        Me.txtFTPAddress.Name = "txtFTPAddress"
        Me.txtFTPAddress.Size = New System.Drawing.Size(274, 24)
        Me.txtFTPAddress.TabIndex = 12
        '
        'lblFTPPort
        '
        Me.lblFTPPort.AutoSize = True
        Me.lblFTPPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblFTPPort.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblFTPPort.Location = New System.Drawing.Point(39, 94)
        Me.lblFTPPort.Name = "lblFTPPort"
        Me.lblFTPPort.Size = New System.Drawing.Size(77, 17)
        Me.lblFTPPort.TabIndex = 19
        Me.lblFTPPort.Text = "FTP Port:"
        '
        'txtFTPPort
        '
        Me.txtFTPPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtFTPPort.Location = New System.Drawing.Point(122, 89)
        Me.txtFTPPort.Name = "txtFTPPort"
        Me.txtFTPPort.Size = New System.Drawing.Size(63, 24)
        Me.txtFTPPort.TabIndex = 18
        '
        'lblFTPPassword
        '
        Me.lblFTPPassword.AutoSize = True
        Me.lblFTPPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblFTPPassword.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblFTPPassword.Location = New System.Drawing.Point(709, 58)
        Me.lblFTPPassword.Name = "lblFTPPassword"
        Me.lblFTPPassword.Size = New System.Drawing.Size(76, 17)
        Me.lblFTPPassword.TabIndex = 21
        Me.lblFTPPassword.Text = "FTP Pwd:"
        '
        'txtFTPPassword
        '
        Me.txtFTPPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtFTPPassword.Location = New System.Drawing.Point(791, 53)
        Me.txtFTPPassword.Name = "txtFTPPassword"
        Me.txtFTPPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtFTPPassword.Size = New System.Drawing.Size(156, 24)
        Me.txtFTPPassword.TabIndex = 20
        '
        'dgvEnvironments
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SandyBrown
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEnvironments.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEnvironments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEnvironments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvEnvironments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEnvironments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Environment, Me.EnvironmentURL, Me.AppServer, Me.Version, Me.DBServerAddress, Me.DBUsername, Me.DBPassword, Me.DatabaseName, Me.EtQAdministratorPassword, Me.Active})
        Me.dgvEnvironments.Location = New System.Drawing.Point(1, 149)
        Me.dgvEnvironments.Name = "dgvEnvironments"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SandyBrown
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEnvironments.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEnvironments.Size = New System.Drawing.Size(982, 262)
        Me.dgvEnvironments.TabIndex = 22
        '
        'Environment
        '
        Me.Environment.HeaderText = "Environment"
        Me.Environment.Name = "Environment"
        Me.Environment.Width = 91
        '
        'EnvironmentURL
        '
        Me.EnvironmentURL.HeaderText = "Environment URL"
        Me.EnvironmentURL.Name = "EnvironmentURL"
        Me.EnvironmentURL.Width = 106
        '
        'AppServer
        '
        Me.AppServer.HeaderText = "App Server"
        Me.AppServer.Name = "AppServer"
        Me.AppServer.Width = 78
        '
        'Version
        '
        Me.Version.HeaderText = "Version"
        Me.Version.Name = "Version"
        Me.Version.Width = 67
        '
        'DBServerAddress
        '
        Me.DBServerAddress.HeaderText = "DB Server Address"
        Me.DBServerAddress.Name = "DBServerAddress"
        Me.DBServerAddress.Width = 112
        '
        'DBUsername
        '
        Me.DBUsername.HeaderText = "DB Username"
        Me.DBUsername.Name = "DBUsername"
        Me.DBUsername.Width = 90
        '
        'DBPassword
        '
        Me.DBPassword.DataPropertyName = "password"
        Me.DBPassword.HeaderText = "DB Password"
        Me.DBPassword.Name = "DBPassword"
        Me.DBPassword.Width = 88
        '
        'DatabaseName
        '
        Me.DatabaseName.HeaderText = "Database Name"
        Me.DatabaseName.Name = "DatabaseName"
        '
        'EtQAdministratorPassword
        '
        Me.EtQAdministratorPassword.HeaderText = "EtQAdministrator Password"
        Me.EtQAdministratorPassword.Name = "EtQAdministratorPassword"
        Me.EtQAdministratorPassword.Width = 145
        '
        'Active
        '
        Me.Active.HeaderText = "Active"
        Me.Active.Name = "Active"
        Me.Active.Width = 43
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.Location = New System.Drawing.Point(767, 415)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(78, 31)
        Me.btnSave.TabIndex = 23
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(675, 415)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 31)
        Me.btnCancel.TabIndex = 24
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(8, 415)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(78, 31)
        Me.btnDelete.TabIndex = 25
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lblEnvironments
        '
        Me.lblEnvironments.AutoSize = True
        Me.lblEnvironments.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblEnvironments.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblEnvironments.Location = New System.Drawing.Point(5, 126)
        Me.lblEnvironments.Name = "lblEnvironments"
        Me.lblEnvironments.Size = New System.Drawing.Size(128, 18)
        Me.lblEnvironments.TabIndex = 26
        Me.lblEnvironments.Text = "Environment(s):"
        '
        'lblFTPLocalPath
        '
        Me.lblFTPLocalPath.AutoSize = True
        Me.lblFTPLocalPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblFTPLocalPath.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblFTPLocalPath.Location = New System.Drawing.Point(661, 97)
        Me.lblFTPLocalPath.Name = "lblFTPLocalPath"
        Me.lblFTPLocalPath.Size = New System.Drawing.Size(124, 17)
        Me.lblFTPLocalPath.TabIndex = 28
        Me.lblFTPLocalPath.Text = "FTP Local Path:"
        '
        'txtFTPLocalPath
        '
        Me.txtFTPLocalPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtFTPLocalPath.Location = New System.Drawing.Point(791, 92)
        Me.txtFTPLocalPath.Name = "txtFTPLocalPath"
        Me.txtFTPLocalPath.Size = New System.Drawing.Size(156, 24)
        Me.txtFTPLocalPath.TabIndex = 27
        '
        'btn_ShowFTPPassword
        '
        Me.btn_ShowFTPPassword.Image = Global.ImportSpreadsheetChecker.My.Resources.Resources.Show24
        Me.btn_ShowFTPPassword.Location = New System.Drawing.Point(950, 53)
        Me.btn_ShowFTPPassword.Name = "btn_ShowFTPPassword"
        Me.btn_ShowFTPPassword.Size = New System.Drawing.Size(25, 23)
        Me.btn_ShowFTPPassword.TabIndex = 30
        Me.btn_ShowFTPPassword.UseVisualStyleBackColor = True
        '
        'chkBusinessActive
        '
        Me.chkBusinessActive.AutoSize = True
        Me.chkBusinessActive.Checked = True
        Me.chkBusinessActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBusinessActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.chkBusinessActive.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.chkBusinessActive.Location = New System.Drawing.Point(876, 122)
        Me.chkBusinessActive.Name = "chkBusinessActive"
        Me.chkBusinessActive.Size = New System.Drawing.Size(71, 21)
        Me.chkBusinessActive.TabIndex = 31
        Me.chkBusinessActive.Text = "Active"
        Me.chkBusinessActive.UseVisualStyleBackColor = True
        '
        'btnSaveAndClose
        '
        Me.btnSaveAndClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAndClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAndClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveAndClose.Location = New System.Drawing.Point(859, 415)
        Me.btnSaveAndClose.Name = "btnSaveAndClose"
        Me.btnSaveAndClose.Size = New System.Drawing.Size(113, 31)
        Me.btnSaveAndClose.TabIndex = 32
        Me.btnSaveAndClose.Text = "Save && Close"
        Me.btnSaveAndClose.UseVisualStyleBackColor = True
        '
        'frmBusinessProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(984, 450)
        Me.Controls.Add(Me.btnSaveAndClose)
        Me.Controls.Add(Me.chkBusinessActive)
        Me.Controls.Add(Me.btn_ShowFTPPassword)
        Me.Controls.Add(Me.lblFTPLocalPath)
        Me.Controls.Add(Me.txtFTPLocalPath)
        Me.Controls.Add(Me.lblEnvironments)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgvEnvironments)
        Me.Controls.Add(Me.lblFTPPassword)
        Me.Controls.Add(Me.txtFTPPassword)
        Me.Controls.Add(Me.lblFTPPort)
        Me.Controls.Add(Me.txtFTPPort)
        Me.Controls.Add(Me.lblFTPHostFingerprint)
        Me.Controls.Add(Me.txtFTPHostFingerprint)
        Me.Controls.Add(Me.lblFTPUser)
        Me.Controls.Add(Me.txtFTPUser)
        Me.Controls.Add(Me.lblFTPAddress)
        Me.Controls.Add(Me.txtFTPAddress)
        Me.Controls.Add(Me.lblHostingType)
        Me.Controls.Add(Me.cboHostingType)
        Me.Controls.Add(Me.lblBusinessName)
        Me.Controls.Add(Me.txtBusinessName)
        Me.Controls.Add(Me.lblBusinessID)
        Me.Controls.Add(Me.cboBusinessID)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBusinessProperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Business Properties"
        CType(Me.dgvEnvironments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboBusinessID As ComboBox
    Friend WithEvents lblBusinessID As Label
    Friend WithEvents txtBusinessName As TextBox
    Friend WithEvents lblBusinessName As Label
    Friend WithEvents lblHostingType As Label
    Friend WithEvents cboHostingType As ComboBox
    Friend WithEvents lblFTPHostFingerprint As Label
    Friend WithEvents txtFTPHostFingerprint As TextBox
    Friend WithEvents lblFTPUser As Label
    Friend WithEvents txtFTPUser As TextBox
    Friend WithEvents lblFTPAddress As Label
    Friend WithEvents txtFTPAddress As TextBox
    Friend WithEvents lblFTPPort As Label
    Friend WithEvents txtFTPPort As TextBox
    Friend WithEvents lblFTPPassword As Label
    Friend WithEvents txtFTPPassword As TextBox
    Friend WithEvents dgvEnvironments As DataGridView
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents lblEnvironments As Label
    Friend WithEvents lblFTPLocalPath As Label
    Friend WithEvents txtFTPLocalPath As TextBox
    Friend WithEvents btn_ShowFTPPassword As Button
    Friend WithEvents chkBusinessActive As CheckBox
    Friend WithEvents Environment As DataGridViewTextBoxColumn
    Friend WithEvents EnvironmentURL As DataGridViewTextBoxColumn
    Friend WithEvents AppServer As DataGridViewTextBoxColumn
    Friend WithEvents Version As DataGridViewTextBoxColumn
    Friend WithEvents DBServerAddress As DataGridViewTextBoxColumn
    Friend WithEvents DBUsername As DataGridViewTextBoxColumn
    Friend WithEvents DBPassword As DataGridViewTextBoxColumn
    Friend WithEvents DatabaseName As DataGridViewTextBoxColumn
    Friend WithEvents EtQAdministratorPassword As DataGridViewTextBoxColumn
    Friend WithEvents Active As DataGridViewCheckBoxColumn
    Friend WithEvents btnSaveAndClose As Button
End Class
