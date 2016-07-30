Imports System.Configuration
Imports BotManager.Properties

Namespace Manager.Type
    Public Class Haxton
        Inherits Generic
        Public Sub New(ByRef botInformation As BotInformation)
            MyBase.New(botInformation)
            ExecutablePath = List.OfSupportedBots.GetInstance()("Haxton").ExecutablePath
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

            settingsSection = config.AppSettings
            tempSetting = new KeyValueConfigurationElement("TempSetting", "temp")

            settingsSection.Settings.Add(tempSetting)

            For Each setting As String In botInformation.SettingKeys
                DirectCast(settingsSection, AppSettingsSection).Settings.Item(Setting).Value =
                    botInformation.GetSettingValue(setting).ToString()
            Next
            DirectCast(settingsSection, AppSettingsSection).Settings.Remove("TempSetting")

            config.Save(ConfigurationSaveMode.Full)
        End Sub
    End Class
End NameSpace