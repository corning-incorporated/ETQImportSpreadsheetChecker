' **************************************************
'   Copyright 2022 Corning Incorporated
'   Author: Tom Gee
' **************************************************

Public Class frmBusinessProperties
#Region "Private Variables"
    Private pwd As Char = "*"
#End Region

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cboBusinessID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBusinessID.SelectedIndexChanged
        If cboBusinessID.Text <> "" Then
            cboHostingType.Text = ""    'clear SelectedText value

            Dim bus As Business = GlobalVar.bc.GetBusiness(cboBusinessID.Text)
            If bus IsNot Nothing Then
                With bus
                    txtBusinessName.Text = .Name
                    cboHostingType.SelectedText = .DeployType
                    txtFTPAddress.Text = .FTPURL
                    txtFTPPort.Text = .FTPPort
                    txtFTPUser.Text = .FTPUser
                    txtFTPPassword.Text = .FTPPassword
                    txtFTPHostFingerprint.Text = .FTPHostFingerprint
                    txtFTPLocalPath.Text = .FTPLocalPath
                    chkBusinessActive.Checked = .Active
                End With
            End If
            UpdateEnvironmentList(cboBusinessID.Text)
        Else
            ClearFormValues()
        End If
    End Sub

    Private Sub ClearFormValues()
        txtBusinessName.Text = ""
        cboHostingType.Text = ""
        cboHostingType.SelectedIndex = -1
        txtFTPAddress.Text = ""
        txtFTPPort.Text = ""
        txtFTPUser.Text = ""
        txtFTPPassword.Text = ""
        txtFTPHostFingerprint.Text = ""
        txtFTPLocalPath.Text = ""
        chkBusinessActive.Checked = False
        dgvEnvironments.Rows.Clear()
    End Sub

    Private Sub UpdateEnvironmentList(ByVal BusinessID As String)
        dgvEnvironments.Rows.Clear()

        Dim envs As ArrayList = GlobalVar.ec.GetEnvironmentsForBusiness(BusinessID, True)
        For Each env As Environment In envs
            Dim dr As DataGridViewRow = dgvEnvironments.Rows(0).Clone
            With env
                dr.Cells(0).Value = .Environment_ID
                dr.Cells(1).Value = .Environment_URL
                dr.Cells(2).Value = .App_Server
                dr.Cells(3).Value = .Version
                dr.Cells(4).Value = .SQLServerAddress
                dr.Cells(5).Value = .SQLUser
                dr.Cells(6).Value = .SQLPassword
                dr.Cells(7).Value = .Database_Name
                dr.Cells(8).Value = .EtQAdministrator_Password
                dr.Cells(9).Value = .Active
            End With
            dgvEnvironments.Rows.Add(dr)
        Next
    End Sub
    Private Sub GetBusinesses()
        If GlobalVar.bc IsNot Nothing Then
            cboBusinessID.Items.Clear()
            For Each bus As Business In GlobalVar.bc.GetBusinesses(True)
                cboBusinessID.Items.Add(bus.ID)
            Next
        End If

        cboBusinessID.Sorted = True
    End Sub

    Private Sub frmBusinessProperties_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetBusinesses()
    End Sub

    Private Sub btn_ShowFTPPassword_Click(sender As Object, e As EventArgs) Handles btn_ShowFTPPassword.Click
        With txtFTPPassword
            If .PasswordChar = "*" Then
                .PasswordChar = ""
            Else
                .PasswordChar = "*"
            End If
        End With
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteBusinessAndEnvironments(cboBusinessID.Text)
    End Sub

    Private Sub DeleteBusinessAndEnvironments(ByVal BusinessID As String)
        If MessageBox.Show(String.Format("Are you sure you want to remove the {0} business and associated environment settings?", BusinessID), "Delete Business and Environment settings?", MessageBoxButtons.YesNoCancel) = DialogResult.Yes Then
            GlobalVar.bc.RemoveBusiness(GlobalVar.bc.GetBusiness(BusinessID))
            GlobalVar.ec.RemoveEnvironmentsFromBusiness(cboBusinessID.Text)
            cboBusinessID.Text = ""
            ClearFormValues()
            GetBusinesses()
            MessageBox.Show("Business and Environment definitions removed successfully")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveBusinessDetails()
        SaveEnvironmentDetails()

        MessageBox.Show("Business and Environment definitions saved successfully")
    End Sub

    Private Sub SaveBusinessDetails()
        Dim bus As New Business(cboBusinessID.Text)
        With bus
            .Name = txtBusinessName.Text
            .DeployType = cboHostingType.Text
            .FTPURL = txtFTPAddress.Text
            .FTPPort = txtFTPPort.Text
            .FTPUser = txtFTPUser.Text
            .FTPPassword = txtFTPPassword.Text
            .FTPHostFingerprint = txtFTPHostFingerprint.Text
            .FTPLocalPath = txtFTPLocalPath.Text
            .Active = chkBusinessActive.Checked
        End With

        If GlobalVar.bc.GetBusiness(cboBusinessID.Text) Is Nothing Then
            GlobalVar.bc.AddBusiness(bus)
        Else
            GlobalVar.bc.UpdateBusiness(cboBusinessID.Text, bus)
        End If
    End Sub

    Private Sub SaveEnvironmentDetails()
        GlobalVar.ec.RemoveEnvironmentsFromBusiness(cboBusinessID.Text)
        For Each dr As DataGridViewRow In dgvEnvironments.Rows
            If Not dr.IsNewRow Then
                Dim env As New Environment(cboBusinessID.Text, dr.Cells(0).Value)
                With env
                    .Environment_URL = dr.Cells(1).Value
                    .App_Server = dr.Cells(2).Value
                    .Version = dr.Cells(3).Value
                    .SQLServerAddress = dr.Cells(4).Value
                    .SQLUser = dr.Cells(5).Value
                    If dr.Tag IsNot Nothing Then
                        .SQLPassword = dr.Tag.ToString  'set to the hidden Tag value
                    Else
                        .SQLPassword = dr.Cells(6).Value
                    End If

                    .Database_Name = dr.Cells(7).Value
                    .EtQAdministrator_Password = dr.Cells(8).Value
                    .Active = dr.Cells(9).Value
                End With
                GlobalVar.ec.AddEnvironment(env)
            End If
        Next
    End Sub

    Private Sub PasswordFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles dgvEnvironments.CellFormatting
        If dgvEnvironments.Columns(e.ColumnIndex).DataPropertyName = "password" And e.Value IsNot Nothing Then
            dgvEnvironments.Rows(e.RowIndex).Tag = e.Value
            e.Value = New String(pwd, e.Value.ToString.Length)
        Else
            dgvEnvironments.Rows(e.RowIndex).Tag = Nothing
        End If
    End Sub

    Private Sub PasswordEditing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvEnvironments.EditingControlShowing
        If dgvEnvironments.CurrentRow.Tag IsNot Nothing Then
            e.Control.Text = dgvEnvironments.CurrentRow.Tag.ToString
        End If
    End Sub

    Private Sub btnSaveAndClose_Click(sender As Object, e As EventArgs) Handles btnSaveAndClose.Click
        SaveBusinessDetails()
        SaveEnvironmentDetails()

        MessageBox.Show("Business and Environment definitions saved successfully")
        Me.Close()
    End Sub
End Class