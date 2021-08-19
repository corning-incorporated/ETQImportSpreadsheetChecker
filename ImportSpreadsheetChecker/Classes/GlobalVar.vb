Public Class GlobalVar
    Public Shared Property bc As BusinessCollection
    Public Shared Property ec As EnvironmentCollection
    Public Shared Property SelectedBusiness As String

#Region "Constructor"
    Public Sub New()
        bc = New BusinessCollection
        ec = New EnvironmentCollection
        SelectedBusiness = Nothing
    End Sub
#End Region

End Class
