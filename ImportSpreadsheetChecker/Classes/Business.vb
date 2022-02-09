' **************************************************
'   Copyright 2022 Corning Incorporated
'   Author: Tom Gee
' **************************************************
Public Class Business

#Region "Private variables"
    Private _businessID As String
    Private _businessName As String
    Private _deployType As String
    Private _ftpURL As String
    Private _ftpPort As String
    Private _ftpUser As String
    Private _ftpPassword As String
    Private _ftpFingerprint As String
    Private _ftpLocalPath As String
    Private _active As Boolean
#End Region

#Region "Public Properties"
    Public Property ID As String
        Get
            Return _businessID
        End Get
        Set(value As String)
            _businessID = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return _businessName
        End Get
        Set(value As String)
            _businessName = value
        End Set
    End Property

    Public Property DeployType As String
        Get
            Return _deployType
        End Get
        Set(value As String)
            _deployType = value
        End Set
    End Property

    Public Property FTPURL
        Get
            Return _ftpURL
        End Get
        Set(value)
            _ftpURL = value
        End Set
    End Property

    Public Property FTPPort
        Get
            Return _ftpPort
        End Get
        Set(value)
            _ftpPort = value
        End Set
    End Property

    Public Property FTPUser As String
        Get
            Return _ftpUser
        End Get
        Set(value As String)
            _ftpUser = value
        End Set
    End Property

    Public Property FTPPassword As String
        Get
            Return _ftpPassword
        End Get
        Set(value As String)
            _ftpPassword = value
        End Set
    End Property

    Public Property FTPHostFingerprint As String
        Get
            Return _ftpFingerprint
        End Get
        Set(value As String)
            _ftpFingerprint = value
        End Set
    End Property

    Public Property FTPLocalPath As String
        Get
            Return _ftpLocalPath
        End Get
        Set(value As String)
            _ftpLocalPath = value
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
    Public Sub New(ByVal BusinessID As String)
        Me.ID = BusinessID
    End Sub
#End Region

End Class
