' **************************************************
'   Copyright 2022 Corning Incorporated
'   Author: Tom Gee
' **************************************************

Imports System.Data.SqlClient

Public Class clsDatabaseCalls
#Region "Private Variables"
    Private _strConnStr As String
    Private _objConn As New SqlConnection
    Private _objCmd As New SqlCommand
    Private _objDa As New SqlDataAdapter
#End Region

#Region "Private Methods/Functions"
    ''' <summary>
    ''' Gets/Sets the SQL Connection String, which is stored as a private variable
    ''' </summary>
    ''' <returns>SQL Connection String</returns>
    ''' <remarks>Copyright © 2020 by Corning, Inc.</remarks>
    Public Property ConnectionString() As String
        Get
            Return _strConnStr
        End Get
        Set(value As String)
            _strConnStr = value
        End Set
    End Property

    ''' <summary>
    ''' Setup the SQL Server Connection object for either the Proficy or Exact MAX database
    ''' </summary>
    ''' <remarks>Copyright © 2020 by Corning, Inc.</remarks>
    Private Sub SetConnectionString()
        Try
            _objConn = New SqlConnection(ConnectionString)

            If _objConn.State = ConnectionState.Closed Then
                _objConn.Open()
            End If

        Catch ex As Exception
            '_ErrorLogger.Log(ex, False, "An error occurred while setting-up the database connection.")
        End Try
    End Sub

    ''' <summary>
    ''' Set the SQL Command that will be executed
    ''' </summary>
    ''' <param name="SQLCommand"></param>
    ''' <param name="StoredProcedure"></param>
    ''' <remarks>Copyright © 2020 - Corning, Inc.</remarks>
    Private Sub SetSqlCommand(ByVal SQLCommand As String, StoredProcedure As Boolean)
        Try
            SetConnectionString()

            _objCmd = New SqlCommand

            With _objCmd
                .Connection = _objConn
                .CommandText = SQLCommand
                .CommandTimeout = 120   'Set the command timeout to 2 minutes

                If StoredProcedure Then
                    .CommandType = CommandType.StoredProcedure
                Else
                    .CommandType = CommandType.Text
                End If

                .Parameters.Clear() 'Clear all existing parameters as they will be re-added by the related method/function
            End With


        Catch ex As Exception
            'ErrorLogger.Log(ex, "An error occurred while setting-up the SQL Command object")

        End Try
    End Sub

    ''' <summary>
    ''' This method closes the database connection and disposes of all related objects
    ''' </summary>
    ''' <remarks>Copyright © 2016 by Corning, Inc.</remarks>
    Private Sub CloseDatabaseConnection()
        Try
            If _objConn.State <> ConnectionState.Closed Then
                'Close and dispose of the SQLConnection object
                _objConn.Close()
                _objConn.Dispose()
                _objConn = Nothing

                'Dispose of the SQL Command object
                _objCmd.Dispose()
                _objCmd = Nothing
            End If

        Catch ex As Exception
            'do nothing if an error occurs while closing the database connection
        End Try
    End Sub
#End Region

#Region "Public Methods/Functions"
    Public Function GetBusinesses() As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            Dim strSQL As String = "SELECT BUSINESS_ID, BUSINESS_NAME, DEPLOY_TYPE, SQL_SERVER, SQL_USER, SQL_PASSWORD, FTP_URL, FTP_PORT, FTP_USER_NAME, FTP_PASSWORD, FTP_HOST_FINGERPRINT, FTP_LOCAL_PATH FROM Business WHERE Active=1 ORDER BY 1"
            SetSqlCommand(strSQL, False)

            _objDa = New SqlDataAdapter(_objCmd)
            _objDa.Fill(ds)

            If ds.Tables.Count <> 0 Then
                dt = ds.Tables(0)
            End If

            Return dt

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function GetEnvironments(ByVal Business As String) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            Dim strSQL As String = "SELECT BUSINESS_ID, ENVIRONMENT_ID, ENVIRONMENT_URL, VERSION, DATABASE_NAME, ETQADMINISTRATOR_PASSWORD FROM ENVIRONMENT WHERE ACTIVE=1 AND BUSINESS_ID='" & Business & "' ORDER BY 1, 2"
            SetSqlCommand(strSQL, False)

            _objDa = New SqlDataAdapter(_objCmd)
            _objDa.Fill(ds)

            If ds.Tables.Count <> 0 Then
                dt = ds.Tables(0)
            End If

            Return dt

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function GetDatabaseDetails(ByVal Business As String, ByVal Environment As String) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            Dim strSQL As String = "SELECT B.BUSINESS_ID, B.BUSINESS_NAME, E.ENVIRONMENT_ID, E.APP_SERVER, B.SQL_SERVER, E.DATABASE_NAME, B.SQL_USER, B.SQL_PASSWORD, B.DEPLOY_TYPE FROM BUSINESS B LEFT JOIN Environment E ON B.BUSINESS_ID=E.BUSINESS_ID WHERE E.ACTIVE=1 AND B.BUSINESS_ID='" & Business & "' AND E.ENVIRONMENT_ID='" & Environment & "'"
            SetSqlCommand(strSQL, False)

            _objDa = New SqlDataAdapter(_objCmd)
            _objDa.Fill(ds)

            If ds.Tables.Count <> 0 Then
                dt = ds.Tables(0)
            End If

            Return dt

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function GetRelianceApplications() As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            Dim strSQL As String = "SELECT APPLICATION_ID, DISPLAY_NAME FROM ENGINE.APPLICATION_SETTINGS WHERE DISPLAY_IN_HOMEPAGE=1 ORDER BY 2"
            SetSqlCommand(strSQL, False)

            _objDa = New SqlDataAdapter(_objCmd)
            _objDa.Fill(ds)

            If ds.Tables.Count <> 0 Then
                dt = ds.Tables(0)
            End If

            Return dt

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function GetRelianceForms(ByVal ApplicationID As Integer) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            Dim strSQL As String = "SELECT FS.FORM_ID, FS.DISPLAY_NAME FROM ENGINE.APPLICATION_FORMS AF JOIN ENGINE.FORM_SETTINGS FS ON AF.FORM_ID=FS.FORM_ID WHERE AF.APPLICATION_ID=" & ApplicationID & " AND FS.IS_DISABLED=0 ORDER BY FS.DISPLAY_NAME"
            SetSqlCommand(strSQL, False)

            _objDa = New SqlDataAdapter(_objCmd)
            _objDa.Fill(ds)

            If ds.Tables.Count <> 0 Then
                dt = ds.Tables(0)
            End If

            Return dt

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function GetRelianceFormFields(ByVal FormID As Integer) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            Dim strSQL As String = "SELECT FS.FIELD_NAME, FT.DESCRIPTION AS FIELD_TYPE FROM ENGINE.FORM_FIELDS FF JOIN ENGINE.FIELD_SETTINGS FS ON FF.FIELD_ID=FS.FIELD_ID JOIN ENGINE.FIELD_TYPES FT ON FS.FIELD_TYPE_ID=FT.FIELD_TYPE_ID AND FT.ETQ$IS_DISABLED=0 WHERE FF.FORM_ID=" & FormID
            SetSqlCommand(strSQL, False)

            _objDa = New SqlDataAdapter(_objCmd)
            _objDa.Fill(ds)

            If ds.Tables.Count <> 0 Then
                dt = ds.Tables(0)
            End If

            Return dt

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function GetRelianceFormTable(ByVal AppID As Integer, ByVal FormID As Integer) As String
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            Dim strSQL As String = String.Format("SELECT A.APPLICATION_NAME + '.' + F.TABLE_NAME FROM ENGINE.APPLICATION_SETTINGS A JOIN ENGINE.APPLICATION_FORMS AF ON A.APPLICATION_ID=AF.APPLICATION_ID JOIN ENGINE.FORM_SETTINGS F ON AF.FORM_ID=F.FORM_ID WHERE A.APPLICATION_ID={0} AND F.FORM_ID={1}", AppID, FormID)
            SetSqlCommand(strSQL, False)

            Dim tableName As String = _objCmd.ExecuteScalar()

            Return tableName

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function GetRelianceSubforms(ByVal FormID As Integer) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            Dim strSQL As String = "SELECT SS.SUBFORM_ID, SS.DISPLAY_NAME FROM ENGINE.SUBFORM_SETTINGS SS JOIN ENGINE.FORM_SETTINGS FS ON SS.FORM_ID=FS.FORM_ID WHERE FS.FORM_ID=" & FormID & " ORDER BY 2"
            SetSqlCommand(strSQL, False)

            _objDa = New SqlDataAdapter(_objCmd)
            _objDa.Fill(ds)

            If ds.Tables.Count <> 0 Then
                dt = ds.Tables(0)
            End If

            Return dt

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function GetRelianceSubformFields(ByVal FormID As Integer) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            Dim strSQL As String = "SELECT FS.FIELD_NAME, FT.DESCRIPTION AS FIELD_TYPE FROM ENGINE.SUBFORM_FIELDS SF JOIN ENGINE.FIELD_SETTINGS FS ON SF.FIELD_ID=FS.FIELD_ID JOIN ENGINE.FIELD_TYPES FT ON FS.FIELD_TYPE_ID=FT.FIELD_TYPE_ID AND FT.ETQ$IS_DISABLED=0 WHERE SF.SUBFORM_ID=" & FormID
            SetSqlCommand(strSQL, False)

            _objDa = New SqlDataAdapter(_objCmd)
            _objDa.Fill(ds)

            If ds.Tables.Count <> 0 Then
                dt = ds.Tables(0)
            End If

            Return dt

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function GetRelianceUsersAndGroups() As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            Dim strSQL As String = "SELECT U.DISPLAY_NAME, U.IS_GROUP FROM ENGINE.USER_SETTINGS U WHERE IS_DISABLED=0 AND IS_INACTIVE=0 ORDER BY 1"
            SetSqlCommand(strSQL, False)

            _objDa = New SqlDataAdapter(_objCmd)
            _objDa.Fill(ds)

            If ds.Tables.Count <> 0 Then
                dt = ds.Tables(0)
            End If

            Return dt

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function GetRelianceUniqueNumbers(ByVal SchemaTable As String) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            Dim strSQL As String = String.Format("SELECT DISTINCT ETQ$NUMBER FROM {0} ORDER BY 1", SchemaTable)
            SetSqlCommand(strSQL, False)

            _objDa = New SqlDataAdapter(_objCmd)
            _objDa.Fill(ds)

            If ds.Tables.Count <> 0 Then
                dt = ds.Tables(0)
            End If

            Return dt

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function GetLookupValues(ByVal FieldName As String) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            'Dim strSQL As String = "SELECT ISNULL(FS.BASE_TABLE, MKL.BASE_TABLE) AS BASE_TABLE, ISNULL(FS.BASE_TABLE_PK, MKL.BASE_TABLE_PK) AS BASE_TABLE_PK, ISNULL(FS.LOOKUP_DISPLAY_VALUE, MKL.LOOKUP_DISPLAY_VALUE) AS LOOKUP_DISPLAY_VALUE, FS.LOOKUP_SQL_QUERY FROM ENGINE.FIELD_SETTINGS FS LEFT JOIN DATACENTER.MASTER_KEYWORD_LIST MKL ON FS.MASTER_KEYWORD_LIST_ID=MKL.MASTER_KEYWORD_LIST_ID WHERE FS.FIELD_NAME='" & FieldName & "'"
            Dim strSQL As String = "SELECT ISNULL(MKL.BASE_TABLE, FS.BASE_TABLE) AS BASE_TABLE, ISNULL(MKL.BASE_TABLE_PK, FS.BASE_TABLE_PK) AS BASE_TABLE_PK, ISNULL(MKL.LOOKUP_DISPLAY_VALUE, FS.LOOKUP_DISPLAY_VALUE) AS LOOKUP_DISPLAY_VALUE, FS.LOOKUP_SQL_QUERY FROM ENGINE.FIELD_SETTINGS FS LEFT JOIN DATACENTER.MASTER_KEYWORD_LIST MKL ON FS.MASTER_KEYWORD_LIST_ID=MKL.MASTER_KEYWORD_LIST_ID WHERE FS.FIELD_NAME='" & FieldName & "'"
            SetSqlCommand(strSQL, False)

            _objDa = New SqlDataAdapter(_objCmd)
            _objDa.Fill(ds)

            If ds.Tables.Count <> 0 Then
                dt = ds.Tables(0)
            End If

            If dt.Rows.Count = 1 Then
                Dim dr As DataRow = dt.Rows(0)
                Dim LookupTable As String = dr(0)
                Dim LookupKey As String = dr(1)
                Dim LookupField As String = dr(2)
                Dim LookupSQL As String = ""
                If Not IsDBNull(dr(3)) Then
                    LookupSQL = dr(3)
                End If

                Dim dt2 As New DataTable
                Dim ds2 As New DataSet
                If LookupSQL = "" Then
                    strSQL = "SELECT " & LookupKey & ", UPPER(" & LookupField & ") FROM " & LookupTable & " WHERE ETQ$IS_DISABLED=0 ORDER BY 2"
                Else
                    strSQL = LookupSQL
                End If

                SetSqlCommand(strSQL, False)

                _objDa = New SqlDataAdapter(_objCmd)
                _objDa.Fill(ds2)

                If ds2.Tables.Count <> 0 Then
                    dt2 = ds2.Tables(0)
                End If

                Return dt2
            End If

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function GetAdditionalSecurityValues() As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            Dim strSQL As String = "SELECT F.ETQ$VALUE_ID, UPPER(F.ETQ$VALUE_DESCRIPTION) FROM ENGINE.ETQ$FILTER_VALUES F WHERE F.ETQ$IS_DISABLED=0 ORDER BY 2"
            SetSqlCommand(strSQL, False)

            _objDa = New SqlDataAdapter(_objCmd)
            _objDa.Fill(ds)

            If ds.Tables.Count <> 0 Then
                dt = ds.Tables(0)
            End If

            Return dt

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function GetLocationProfileValues() As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            Dim strSQL As String = "SELECT LOCATION_PROFILE_ID, UPPER(HIERARCHICAL_NAME) FROM DATACENTER.LOCATION_PROFILE WHERE DISABLED=0 ORDER BY 2"
            SetSqlCommand(strSQL, False)

            _objDa = New SqlDataAdapter(_objCmd)
            _objDa.Fill(ds)

            If ds.Tables.Count <> 0 Then
                dt = ds.Tables(0)
            End If

            Return dt

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function GetOfflineDistributionValues() As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet

        Try
            Dim strSQL As String = "SELECT LIST_ID, DESCRIPTION FROM ENGINE.WF_OFFLINE_LIST WHERE ETQ$IS_DISABLED=0 ORDER BY 2"
            SetSqlCommand(strSQL, False)

            _objDa = New SqlDataAdapter(_objCmd)
            _objDa.Fill(ds)

            If ds.Tables.Count <> 0 Then
                dt = ds.Tables(0)
            End If

            Return dt

        Catch ex As Exception
            Return Nothing

        Finally
            CloseDatabaseConnection()
        End Try
    End Function
#End Region
End Class
