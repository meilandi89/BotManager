Imports System.Configuration
Imports BotManager.Properties

Namespace Manager.Type
    Public Class Haxton
        Inherits Generic
        Public Sub New(ByRef botProperties As BotInformation)
            MyBase.New(botProperties)
            ExecutablePath = List.OfSupportedBots.GetInstance()("Haxton").ExecutablePath
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

            settingsSection = config.AppSettings
            tempSetting = new KeyValueConfigurationElement("TempSetting", "temp")

            settingsSection.Settings.Add(tempSetting)

            For Each setting As String In BotProperties.SettingKeys
                DirectCast(settingsSection, AppSettingsSection).Settings.Item(Setting).Value =
                    BotProperties.GetSettingValue(setting).ToString()
            Next
            DirectCast(settingsSection, AppSettingsSection).Settings.Remove("TempSetting")

            config.Save(ConfigurationSaveMode.Full)
        End Sub
    End Class
End NameSpace