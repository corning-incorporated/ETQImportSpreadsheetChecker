' **************************************************
'   Copyright 2022 Corning Incorporated
'   Author: Tom Gee
' **************************************************

Public Class Environment
#Region "Private Variables"
    Private _businessID As String
    Private _environmentID As String
    Private _environmentURL As String
    Private _appServer As String
    Private _sqlServerAddress As String
    Private _sqlUser As String
    Private _sqlPassword As String
    Private _version As String
    Private _databaseName As String
    Private _etqAdminPassword As String
    Private _active As Boolean
#End Region

#Region "Public Properties"
    Public Property Business_ID As String
        Get
            Return _businessID
        End Get
        Set(value As String)
            _businessID = value
        End Set
    End Property

    Public Property Environment_ID As String
        Get
            Return _environmentID
        End Get
        Set(value As String)
            _environmentID = value
        End Set
    End Property

    Public Property Environment_URL As String
        Get
            Return _environmentURL
        End Get
        Set(value As String)
            _environmentURL = value
        End Set
    End Property

    Public Property App_Server As String
        Get
            Return _appServer
        End Get
        Set(value As String)
            _appServer = value
        End Set
    End Property

    Public Property SQLServerAddress As String
        Get
            Return _sqlServerAddress
        End Get
        Set(value As String)
            _sqlServerAddress = value
        End Set
    End Property

    Public Property SQLUser As String
        Get
            Return _sqlUser
        End Get
        Set(value As String)
            _sqlUser = value
        End Set
    End Property

    Public Property SQLPassword As String
        Get
            Return _sqlPassword
        End Get
        Set(value As String)
            _sqlPassword = value
        End Set
    End Property

    Public Property Version As String
        Get
            Return _version
        End Get
        Set(value As String)
            _version = value
        End Set
    End Property

    Public Property Database_Name As String
        Get
            Return _databaseName
        End Get
        Set(value As String)
            _databaseName = value
        End Set
    End Property

    Public Property EtQAdministrator_Password As String
        Get
            Return _etqAdminPassword
        End Get
        Set(value As String)
            _etqAdminPassword = value
        End Set
    End Property

    Public Property Active As Boolean
        Get
            Return _active
        End Get
        Set(value As Boolean)
            _active = value
        End Set
    End Property
#End Region

#Region "Constructors"
    Public Sub New(ByVal BusinessID As String, ByVal EnvironmentID As String)
        Me.Business_ID = BusinessID
        Me.Environment_ID = EnvironmentID
    End Sub
#End Region
End Class
