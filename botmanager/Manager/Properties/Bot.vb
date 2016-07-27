Namespace Manager.Properties
    <Serializable()>Public Class Bot
        Public ExecutablePath As String = ""
        Public TempExecutablePath As String = ""
        Public SettingKeys As New List(Of String)
        Public SettingValues As New List(Of String)
        Public IsRunning As Boolean = False
        Public IsHaxton As Boolean = False
        <NonSerialized()> Public ProcessId As Integer = 0
        <NonSerialized()> Public Handle As Integer = 0
        <NonSerialized()> Public TabPageHandle As Integer = 0

        Public Sub New()
        End Sub

        Public Function GetSettingValue(key As String)
            Dim indexOfKey As Integer = SettingKeys.IndexOf(key)
            Return SettingValues.Item(indexOfKey)
        End Function

        Public Sub AddKeyValue(key As String, value As String)
            SettingKeys.Add(key)
            SettingValues.Add(value)
        End Sub
    End Class
End NameSpace