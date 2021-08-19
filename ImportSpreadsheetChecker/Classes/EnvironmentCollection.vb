Public Class EnvironmentCollection
    Dim Environments As New ArrayList
    ReadOnly delim As String = "|"

    ''' <summary>
    ''' This method will parse through the list of environment definitions and add them as objects to the "Environments" ArrayList
    ''' </summary>
    ''' <param name="envs"></param>
    Public Sub LoadEnvironments(ByVal envs As ArrayList)
        If envs Is Nothing Then
            Environments = New ArrayList
        Else
            For Each env As String In envs
                Environments.Add(ConvertStringToEnvironment(env))
            Next
        End If
    End Sub

    Public Function GetEnvironments() As ArrayList
        Return Environments
    End Function

    Public Function GetEnvironmentsForBusiness(ByVal BusinessID As String, Optional ByVal IncludeInactive As Boolean = False) As ArrayList
        Dim SelectEnvironments As New ArrayList
        For Each env As Environment In Environments
            If env.Business_ID = BusinessID Then
                If IncludeInactive = False Then
                    If env.Active = True Then
                        SelectEnvironments.Add(env)
                    End If
                Else
                    SelectEnvironments.Add(env)
                End If
            End If
        Next

        Return SelectEnvironments
    End Function

    Public Function ConvertEnvironmentToString(ByVal env As Environment)
        Dim envDetails As String
        With env
            '                                                                                                 0         1               2                3               4           5            6               7           8           9                    10                    11
            envDetails = String.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}", delim, .Business_ID, .Environment_ID, .Environment_URL, .App_Server, .Version, .SQLServerAddress, .SQLUser, .SQLPassword, .Database_Name, .EtQAdministrator_Password, .Active)
        End With

        Return envDetails
    End Function

    Public Function ConvertStringToEnvironment(ByVal EnvironmentAsString As String) As Environment
        Dim envDetails As String() = EnvironmentAsString.Split(Convert.ToChar(delim))
        Dim env As New Environment(envDetails(0), envDetails(1))

        With env
            .Environment_URL = envDetails(2)
            .App_Server = envDetails(3)
            .Version = envDetails(4)
            .SQLServerAddress = envDetails(5)
            .SQLUser = envDetails(6)
            .SQLPassword = envDetails(7)
            .Database_Name = envDetails(8)
            .EtQAdministrator_Password = envDetails(9)
            .Active = envDetails(10)
        End With

        Return env
    End Function

    Public Sub RemoveEnvironment(ByVal env As Environment)
        GlobalVar.ec.Environments.Remove(env)
    End Sub

    Public Sub RemoveEnvironmentsFromBusiness(ByVal BusinessID As String)
        Dim EnvsToRemove As New ArrayList
        For Each env As Environment In Environments
            If env.Business_ID = BusinessID Then
                EnvsToRemove.Add(env)
            End If
        Next

        For Each env As Environment In EnvsToRemove
            RemoveEnvironment(env)
        Next
    End Sub

    Public Sub UpdateEnvironment(ByVal Business As String, ByVal Env As String, ByVal NewEnvironment As Environment)
        Dim oldEnv As Environment = GetEnvironment(Business, Env)
        With oldEnv
            .Business_ID = NewEnvironment.Business_ID
            .Environment_ID = NewEnvironment.Environment_ID
            .Environment_URL = NewEnvironment.Environment_URL
            .App_Server = NewEnvironment.App_Server
            .Version = NewEnvironment.Version
            .SQLServerAddress = NewEnvironment.SQLServerAddress
            .SQLUser = NewEnvironment.SQLUser
            .SQLPassword = NewEnvironment.SQLPassword
            .Database_Name = NewEnvironment.Database_Name
            .EtQAdministrator_Password = NewEnvironment.EtQAdministrator_Password
            .Active = NewEnvironment.Active
        End With
    End Sub

    Public Sub AddEnvironment(ByVal env As Environment)
        Environments.Add(env)
        My.Settings.Save()
    End Sub

    Public Function GetEnvironment(ByVal BusinessID As String, ByVal EnvironmentID As String) As Environment
        For Each env As Environment In Environments
            If env.Business_ID = BusinessID And env.Environment_ID = EnvironmentID Then
                Return env
            End If
        Next

        Return Nothing
    End Function

    Public Function GetEnvironmentCount() As Integer
        Return Environments.Count
    End Function
End Class
