' **************************************************
'   Copyright 2022 Corning Incorporated
'   Author: Tom Gee
' **************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReplace
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReplace))
        Me.lblFindWhat = New System.Windows.Forms.Label()
        Me.lblReplaceWith = New System.Windows.Forms.Label()
        Me.txtFindWhat = New System.Windows.Forms.TextBox()
        Me.txtReplaceWith = New System.Windows.Forms.TextBox()
        Me.btnReplaceAllInSelectedColumn = New System.Windows.Forms.Button()
        Me.btnReplaceAll = New System.Windows.Forms.Button()
        Me.cboColumns = New System.Windows.Forms.ComboBox()
        Me.lblColumn = New System.Windows.Forms.Label()
        Me.btnFindNext = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblFindWhat
        '
        Me.lblFindWhat.AutoSize = True
        Me.lblFindWhat.Location = New System.Drawing.Point(43, 16)
        Me.lblFindWhat.Name = "lblFindWhat"
        Me.lblFindWhat.Size = New System.Drawing.Size(56, 13)
        Me.lblFindWhat.TabIndex = 0
        Me.lblFindWhat.Text = "Find what:"
        '
        'lblReplaceWith
        '
        Me.lblReplaceWith.AutoSize = True
        Me.lblReplaceWith.Location = New System.Drawing.Point(27, 53)
        Me.lblReplaceWith.Name = "lblReplaceWith"
        Me.lblReplaceWith.Size = New System.Drawing.Size(72, 13)
        Me.lblReplaceWith.TabIndex = 1
        Me.lblReplaceWith.Text = "Replace with:"
        '
        'txtFindWhat
        '
        Me.txtFindWhat.Location = New System.Drawing.Point(105, 13)
        Me.txtFindWhat.Name = "txtFindWhat"
        Me.txtFindWhat.Size = New System.Drawing.Size(376, 20)
        Me.txtFindWhat.TabIndex = 2
        '
        'txtReplaceWith
        '
        Me.txtReplaceWith.Location = New System.Drawing.Point(105, 50)
        Me.txtReplaceWith.Name = "txtReplaceWith"
        Me.txtReplaceWith.Size = New System.Drawing.Size(376, 20)
        Me.txtReplaceWith.TabIndex = 3
        '
        'btnReplaceAllInSelectedColumn
        '
        Me.btnReplaceAllInSelectedColumn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnReplaceAllInSelectedColumn.Location = New System.Drawing.Point(487, 81)
        Me.btnReplaceAllInSelectedColumn.Name = "btnReplaceAllInSelectedColumn"
        Me.btnReplaceAllInSelectedColumn.Size = New System.Drawing.Size(216, 31)
        Me.btnReplaceAllInSelectedColumn.TabIndex = 4
        Me.btnReplaceAllInSelectedColumn.Text = "Replace all in selected column"
        Me.btnReplaceAllInSelectedColumn.UseVisualStyleBackColor = True
        '
        'btnReplaceAll
        '
        Me.btnReplaceAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnReplaceAll.Location = New System.Drawing.Point(487, 44)
        Me.btnReplaceAll.Name = "btnReplaceAll"
        Me.btnReplaceAll.Size = New System.Drawing.Size(216, 31)
        Me.btnReplaceAll.TabIndex = 5
        Me.btnReplaceAll.Text = "Replace All"
        Me.btnReplaceAll.UseVisualStyleBackColor = True
        '
        'cboColumns
        '
        Me.cboColumns.FormattingEnabled = True
        Me.cboColumns.Location = New System.Drawing.Point(105, 87)
        Me.cboColumns.Name = "cboColumns"
        Me.cboColumns.Size = New System.Drawing.Size(376, 21)
        Me.cboColumns.Sorted = True
        Me.cboColumns.TabIndex = 6
        '
        'lblColumn
        '
        Me.lblColumn.AutoSize = True
        Me.lblColumn.Location = New System.Drawing.Point(54, 90)
        Me.lblColumn.Name = "lblColumn"
        Me.lblColumn.Size = New System.Drawing.Size(45, 13)
        Me.lblColumn.TabIndex = 7
        Me.lblColumn.Text = "Column:"
        '
        'btnFindNext
        '
        Me.btnFindNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnFindNext.Location = New System.Drawing.Point(487, 7)
        Me.btnFindNext.Name = "btnFindNext"
        Me.btnFindNext.Size = New System.Drawing.Size(216, 31)
        Me.btnFindNext.TabIndex = 8
        Me.btnFindNext.Text = "Find Next"
        Me.btnFindNext.UseVisualStyleBackColor = True
        '
        'frmReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 124)
        Me.Controls.Add(Me.btnFindNext)
        Me.Controls.Add(Me.lblColumn)
        Me.Controls.Add(Me.cboColumns)
        Me.Controls.Add(Me.btnReplaceAll)
        Me.Controls.Add(Me.btnReplaceAllInSelectedColumn)
        Me.Controls.Add(Me.txtReplaceWith)
        Me.Controls.Add(Me.txtFindWhat)
        Me.Controls.Add(Me.lblReplaceWith)
        Me.Controls.Add(Me.lblFindWhat)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReplace"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Replace"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblFindWhat As Label
    Friend WithEvents lblReplaceWith As Label
    Friend WithEvents txtFindWhat As TextBox
    Friend WithEvents txtReplaceWith As TextBox
    Friend WithEvents btnReplaceAllInSelectedColumn As Button
    Friend WithEvents btnReplaceAll As Button
    Friend WithEvents cboColumns As ComboBox
    Friend WithEvents lblColumn As Label
    Friend WithEvents btnFindNext As Button
End Class
