Imports System.Configuration
Imports BotManager.Properties

Namespace Manager.Type
    Public Class Haxton
        Inherits Generic
        Private Shared ReadOnly SettingValues As New List(Of String)
        Public Sub New(ByRef botProperties As BotInformation)
            MyBase.New(botProperties)
            ExecutablePath = "Haxton/HaxtonBot-master/PokemonGo.Haxton.Console/bin/Debug/PokemonGo.Haxton.Console.exe"
            Initialize()
             If botProperties.SettingKeys.Count = 0 Then 
                ReadSettings()
                If SettingValues.Count > 0 Then
                    botProperties.SettingValues.Clear()
                    For Each setting As String In SettingValues
                        botProperties.SettingValues.Add(setting)
                    Next
                End If
            End If
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
            SettingValues.Clear()
            For Each setting As String In BotProperties.SettingKeys
                DirectCast(settingsSection, AppSettingsSection).Settings.Item(Setting).Value =
                    BotProperties.GetSettingValue(setting).ToString()
                SettingValues.Add(BotProperties.GetSettingValue(setting).ToString())
            Next
            DirectCast(settingsSection, AppSettingsSection).Settings.Remove("TempSetting")

            config.Save(ConfigurationSaveMode.Full)
        End Sub

        Public Overrides Sub ReadSettings()
            Dim fileMap As New ExeConfigurationFileMap()
            fileMap.ExeConfigFilename =
                BotProperties.TempExecutablePath & ".config"
            Dim config As Configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                                                                                          ConfigurationUserLevel.None)
            Dim settingsSection
            settingsSection = config.AppSettings

            For Each setting In settingsSection.Settings
                BotProperties.AddKeyValue(setting.[Key], setting.Value.ToString())
            Next
        End Sub
    End Class
End NameSpace