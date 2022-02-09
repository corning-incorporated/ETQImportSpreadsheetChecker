' **************************************************
'   Copyright 2022 Corning Incorporated
'   Author: Tom Gee
' **************************************************
Public Class BusinessCollection
    Dim Businesses As New ArrayList
    ReadOnly delim As String = "|"

    ''' <summary>
    ''' This method will parse through the list of business definitions and add them as objects to the "Businesses" ArrayList
    ''' </summary>
    ''' <param name="buses"></param>
    Public Sub LoadBusinesses(ByVal buses As ArrayList)
        If buses Is Nothing Then
            Businesses = New ArrayList
        Else
            For Each bus As String In buses
                Businesses.Add(ConvertStringToBusiness(bus))
            Next
        End If
    End Sub

    Public Function GetBusinesses(Optional IncludeInactive As Boolean = False) As ArrayList
        If IncludeInactive = True Then
            Return Businesses
        Else
            Dim SelectBusinesses As New ArrayList
            For Each bus As Business In Businesses
                If IncludeInactive = False Then
                    If bus.Active = True Then
                        SelectBusinesses.Add(bus)
                    End If
                End If
            Next

            Return SelectBusinesses
        End If
    End Function

    Public Function ConvertBusinessToString(ByVal bus As Business)
        Dim busDetails As String
        With bus
            '                                                                                          0     1     2         3          4         5         6          7                8                  9          10
            busDetails = String.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}", delim, .ID, .Name, .DeployType, .FTPURL, .FTPPort, .FTPUser, .FTPPassword, .FTPHostFingerprint, .FTPLocalPath, .Active)
        End With

        Return busDetails
    End Function

    Public Function ConvertStringToBusiness(ByVal BusinessAsString As String) As Business
        Dim busDetails As String() = BusinessAsString.Split(Convert.ToChar(delim))

        Dim Bus As New Business(busDetails(0))
        With Bus
            .Name = busDetails(1)
            .DeployType = busDetails(2)
            .FTPURL = busDetails(3)
            .FTPPort = busDetails(4)
            .FTPUser = busDetails(5)
            .FTPPassword = busDetails(6)
            .FTPHostFingerprint = busDetails(7)
            .FTPLocalPath = busDetails(8)
            .Active = busDetails(9)
        End With

        Return Bus
    End Function

    Public Sub RemoveBusiness(ByVal bus As Business)
        GlobalVar.bc.Businesses.Remove(bus)
    End Sub

    Public Sub UpdateBusiness(ByVal OldBusiness As String, ByVal NewBusiness As Business)
        Dim oldBus As Business = GetBusiness(OldBusiness)
        With oldBus
            .ID = NewBusiness.ID
            .Name = NewBusiness.Name
            .DeployType = NewBusiness.DeployType
            .FTPURL = NewBusiness.FTPURL
            .FTPPort = NewBusiness.FTPPort
            .FTPUser = NewBusiness.FTPUser
            .FTPPassword = NewBusiness.FTPPassword
            .FTPHostFingerprint = NewBusiness.FTPHostFingerprint
            .FTPLocalPath = NewBusiness.FTPLocalPath
            .Active = NewBusiness.Active
        End With
    End Sub

    Public Sub AddBusiness(ByVal bus As Business)
        Businesses.Add(bus)
        My.Settings.Save()
    End Sub

    Public Function GetBusiness(ByVal BusinessID As String) As Business
        For Each bus As Business In Businesses
            If bus.ID = BusinessID Then
                Return bus
            End If
        Next

        Return Nothing
    End Function

    Public Function GetBusinessCount() As Integer
        Return Businesses.Count
    End Function
End Class
