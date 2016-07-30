Imports System.Configuration
Imports BotManager.Properties

Namespace Manager.Type
    Public Class Spegeli
        Inherits Generic

        Public Sub New(ByRef botProperties As BotInformation)
            MyBase.New(botProperties)
            ExecutablePath =  List.OfSupportedBots.GetInstance()("Spegeli").ExecutablePath
            Initialize()
        End Sub
        Public Overrides Sub WriteSettings()
            Dim fileMap As New ExeConfigurationFileMap()
            fileMap.ExeConfigFilename =
                BotProperties.TempExecutablePath & ".config"
            Dim config As Configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                                                                                          ConfigurationUserLevel.None)
            Dim settingsSection
            Dim tempSetting

            settingsSection = config.GetSection("userSettings/PokemonGo.RocketAPI.Console.UserSettings")
            tempSetting = new SettingElement("TempSetting", SettingsSerializeAs.String)

            settingsSection.Settings.Add(tempSetting)
            For Each setting As String In BotProperties.SettingKeys
                settingsSection.Settings.Get(Setting).Value.ValueXml.LastChild.InnerText =
                    BotProperties.GetSettingValue(setting).ToString()
            Next
            settingsSection.Settings.Remove(tempSetting)

            config.Save(ConfigurationSaveMode.Full)
        End Sub
    End Class
End NameSpace