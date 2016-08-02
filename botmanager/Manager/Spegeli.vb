Imports System.Configuration
Imports BotManager.List
Imports BotManager.Properties

Namespace Manager
    Public Class Spegeli
        Inherits Generic

        Public Sub New(ByRef botInformation As BotInformation)
            MyBase.New(botInformation)
            ExecutablePath = OfSupportedBots.GetInstance()("Spegeli").ExecutablePath
            Initialize()
        End Sub

        Public Overrides Sub WriteSettings()
            Dim fileMap As New ExeConfigurationFileMap()
            fileMap.ExeConfigFilename =
                botInformation.TempExecutablePath & ".config"
            Dim config As Configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                                                                                          ConfigurationUserLevel.None)
            Dim settingsSection
            Dim tempSetting

            settingsSection = config.GetSection("userSettings/PokemonGo.RocketAPI.Console.UserSettings")
            tempSetting = new SettingElement("TempSetting", SettingsSerializeAs.String)

            settingsSection.Settings.Add(tempSetting)
            For Each setting As String In botInformation.SettingKeys
                settingsSection.Settings.Get(Setting).Value.ValueXml.LastChild.InnerText =
                    botInformation.GetSettingValue(setting).ToString()
            Next
            settingsSection.Settings.Remove(tempSetting)

            config.Save(ConfigurationSaveMode.Full)
        End Sub
    End Class
End NameSpace