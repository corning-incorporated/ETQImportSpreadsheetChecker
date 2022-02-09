' **************************************************
'   Copyright 2022 Corning Incorporated
'   Author: Tom Gee
' **************************************************

Public Class frmReplace
    Private _dtColumns As DataTable = Nothing
    Private _strCurrentColumn As String = Nothing
    Private _strFindWhat As String = Nothing
    Private _strReplaceWith As String = Nothing
    Private _parentForm As frmMain


    Private Property ParentForm As frmMain
        Get
            Return _parentForm
        End Get
        Set(value As frmMain)
            _parentForm = value
        End Set
    End Property

    Public Property Columns() As DataTable
        Get
            Return _dtColumns
        End Get
        Set(value As DataTable)
            _dtColumns = value
            With cboColumns
                .DataSource = Nothing
                .DataSource = _dtColumns
                .DisplayMember = "col"
                .ValueMember = "col"
            End With
        End Set
    End Property

    Public Property CurrentColumn As String
        Get
            Return _strCurrentColumn
        End Get
        Set(value As String)
            _strCurrentColumn = value

            cboColumns.Text = _strCurrentColumn
        End Set
    End Property

    Public Property FindWhat As String
        Get
            Return _strFindWhat
        End Get
        Set(value As String)
            _strFindWhat = value
            txtFindWhat.Text = _strFindWhat
        End Set
    End Property

    Public Property ReplaceWith As String
        Get
            Return _strReplaceWith
        End Get
        Set(value As String)
            _strReplaceWith = value
        End Set
    End Property

    Private Sub frmReplace_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Columns Is Nothing Then
            lblColumn.Visible = False
            cboColumns.Visible = False
        Else
            lblColumn.Visible = True
            cboColumns.Visible = True
        End If

        If FindWhat Is Nothing Then
            txtFindWhat.Select()    'set the default focus
        Else
            txtReplaceWith.Select() 'set the default focus
        End If
    End Sub

    Public Sub New(ByRef parent As frmMain)
        InitializeComponent()
        _parentForm = parent
    End Sub

    Private Sub btnFindNext_Click(sender As Object, e As EventArgs) Handles btnFindNext.Click
        ParentForm.FindNext(txtFindWhat.Text)
    End Sub

    Private Sub ReplaceInColumn()
        ParentForm.ReplaceColumnValues(cboColumns.Text, txtFindWhat.Text, txtReplaceWith.Text)
    End Sub

    Private Sub btnReplaceAllInSelectedColumn_Click(sender As Object, e As EventArgs) Handles btnReplaceAllInSelectedColumn.Click
        ReplaceInColumn()
    End Sub

    Private Sub btnReplaceAll_Click(sender As Object, e As EventArgs) Handles btnReplaceAll.Click
        ReplaceAll()
    End Sub

    Private Sub ReplaceAll()
        ParentForm.ReplaceAll(txtFindWhat.Text, txtReplaceWith.Text)
    End Sub

    Private Sub frmReplace_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.A AndAlso e.Modifiers = Keys.Alt) Then 'CTRL + A
            ReplaceAll()
        ElseIf (e.KeyCode = Keys.R AndAlso e.Modifiers = Keys.Alt) Then 'CTRL + R
            ReplaceInColumn()
        End If
    End Sub
End Class