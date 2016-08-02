Imports BotManager.List
Imports BotManager.Properties
Imports Newtonsoft.Json.Linq

Namespace Manager
    Public Class Necro
        Inherits Generic

        Public Sub New(ByRef botInformation As BotInformation)
            MyBase.New(botInformation)
            ExecutablePath = OfSupportedBots.GetInstance()("Necro").ExecutablePath
            Initialize()
        End Sub

        Public Overrides Sub WriteSettings()
            Dim _
                srSettings As _
                    New StreamReader(Path.GetDirectoryName(BotInformation.TempExecutablePath) & "\Config\config.json")
            Dim settings As String = srSettings.ReadToEnd()
            srSettings.Dispose()

            Dim _
                srAuth As _
                    New StreamReader(Path.GetDirectoryName(BotInformation.TempExecutablePath) & "\Config\auth.json")
            Dim auth As String = srAuth.ReadToEnd()
            srAuth.Dispose()

            Dim jObjectSettings As JObject = JObject.Parse(settings)
            Dim jObjectAuth As JObject = JObject.Parse(auth)

            For Each setting As String In botInformation.SettingKeys
                If _
                    setting.Equals("AuthType") OrElse setting.Equals("GoogleUsername") OrElse
                    setting.Equals("GooglePassword") OrElse setting.Equals("PtcUsername") OrElse
                    setting.Equals("PtcPassword") Then
                    jObjectAuth(setting) = botInformation.GetSettingValue(setting).ToString()
                Else
                    jObjectSettings(setting) = botInformation.GetSettingValue(setting).ToString()
                End If

            Next

            Using _
                outputFile As _
                    New StreamWriter(Path.GetDirectoryName(BotInformation.TempExecutablePath) & "\Config\auth.json")
                outputFile.Write(jObjectAuth.ToString())
            End Using

            Using _
                outputFile As _
                    New StreamWriter(Path.GetDirectoryName(BotInformation.TempExecutablePath) & "\Config\config.json")
                outputFile.Write(jObjectSettings.ToString())
            End Using
        End Sub
    End Class
End NameSpace