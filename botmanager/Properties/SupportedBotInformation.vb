Namespace Properties
    Public Class SupportedBotInformation
        Public Name As String
        Public ZipName As String
        Public DownloadUrl As String
        Public WorkingDirectory As String
        Public ExecutablePath As String
        Public SettingKeys As New List(Of String)
        Public SettingValues As New List(Of String)

        Public Function GetSettingValue(key As String)
            Dim indexOfKey As Integer = SettingKeys.IndexOf(key)
            Return SettingValues.Item(indexOfKey)
        End Function

        Public Sub AddKeyValue(key As String, value As String)
            If SettingKeys.Contains(key) Then
                SettingValues.Item(SettingKeys.IndexOf(key)) = Value
            Else 
                SettingKeys.Add(key)
                SettingValues.Add(value)
            End If
        End Sub
    End Class
End NameSpace