
Imports BotManager.Interfaces

Namespace Properties
    <Serializable>
    Public Class BotInformation
        Implements ISettings
        Public TempExecutablePath As String = ""
        Public ProjectPath As String = ""
        Public RestartTimer As Integer
        Public Hide As Boolean = False
        Public BotClass As String

        Public Property SettingKeys As New List(Of String) Implements ISettings.SettingKeys

        Public Property SettingValues As New List(Of String) Implements ISettings.SettingValues


        Public Sub AddKeyValue(key As String, value As String) Implements ISettings.AddKeyValue
            If SettingKeys.Contains(key) Then
                SettingValues.Item(SettingKeys.IndexOf(key)) = Value
            Else
                SettingKeys.Add(key)
                SettingValues.Add(value)
            End If
        End Sub

        Public Function GetSettingValue(key As String) As String Implements ISettings.GetSettingValue
            Dim indexOfKey As Integer = SettingKeys.IndexOf(key)
            Return SettingValues.Item(indexOfKey)
        End Function

        Public Sub New()
        End Sub
    End Class
End NameSpace