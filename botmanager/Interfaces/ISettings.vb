Namespace Interfaces
    Public Interface ISettings
        Property SettingKeys As List(Of String)
        Property SettingValues As List(Of String)

        Function GetSettingValue(key As String) As String


        Sub AddKeyValue(key As String, value As String)
    End Interface
End NameSpace