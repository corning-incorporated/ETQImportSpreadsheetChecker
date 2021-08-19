Public Class frmListValues
    Private Sub btnUserGroupSearch_Click(sender As Object, e As EventArgs) Handles btnUserGroupSearch.Click
        FilterListValues()
    End Sub

    Private Sub FilterListValues()
        If dgvListValues.Rows.Count > 0 Then
            If txtListValuesSearch.Text = "" Then
                TryCast(dgvListValues.DataSource, DataTable).DefaultView.RowFilter = ""
            Else
                Dim colName As String = dgvListValues.Columns(1).Name
                TryCast(dgvListValues.DataSource, DataTable).DefaultView.RowFilter = String.Format("{0} LIKE '%{1}%'", colName, txtListValuesSearch.Text)
            End If
        End If
    End Sub

    Public Sub New(ByRef dtValues As DataTable, ByVal ColumnName As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = String.Format("List Values - {0}", ColumnName)

        If dtValues IsNot Nothing And dtValues.Rows.Count > 0 Then
            Dim maxColWidth As Integer = 800
            With dgvListValues
                .DataSource = dtValues
                .Columns(0).HeaderText = "ID"
                .Columns(1).HeaderText = "Value"
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                For Each c As DataGridViewColumn In .Columns
                    If c.Width > maxColWidth Then
                        c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        c.Width = maxColWidth
                    End If
                Next

                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            End With
        End If
    End Sub

    Private Sub dgvListValues_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvListValues.RowHeaderMouseDoubleClick
        CloseLookupForm()
    End Sub

    Private Sub dgvListValues_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListValues.CellDoubleClick
        CloseLookupForm()
    End Sub

    Private Sub dgvListValues_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListValues.CellContentDoubleClick
        CloseLookupForm()
    End Sub
    Private Sub dgvListValues_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvListValues.CellMouseDoubleClick
        CloseLookupForm()
    End Sub

    Private Sub CloseLookupForm()
        If dgvListValues.CurrentRow.Index > 0 Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class