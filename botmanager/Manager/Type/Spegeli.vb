Imports System.Configuration
Imports BotManager.Manager.Properties

Namespace Manager.Type
    Public Class Spegeli
        Inherits Generic
        Private Shared ReadOnly SettingValues As New List(Of String)

        Public Sub New(ByRef botProperties As Bot)
            MyBase.New(botProperties)
            ExecutablePath =  "Spegeli/PokemoGoBot-GottaCatchEmAll-master/PokemonGo.RocketAPI.Console/bin/Debug/PokemonGo.RocketAPI.Console.exe"
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


            settingsSection = config.GetSection("userSettings/PokemonGo.RocketAPI.Console.UserSettings")
            tempSetting = new SettingElement("TempSetting", SettingsSerializeAs.String)

            settingsSection.Settings.Add(tempSetting)
            SettingValues.Clear()
            For Each setting As String In BotProperties.SettingKeys
                settingsSection.Settings.Get(Setting).Value.ValueXml.LastChild.InnerText =
                    BotProperties.GetSettingValue(setting).ToString()
                SettingValues.Add(BotProperties.GetSettingValue(setting).ToString())
            Next
            settingsSection.Settings.Remove(tempSetting)

            config.Save(ConfigurationSaveMode.Full)
        End Sub
        Public Overrides Sub ReadSettings()
            Dim fileMap As New ExeConfigurationFileMap()
            fileMap.ExeConfigFilename =
                BotProperties.TempExecutablePath & ".config"
            Dim config As Configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                                                                                          ConfigurationUserLevel.None)
            Dim settingsSection
            settingsSection = config.GetSection("userSettings/PokemonGo.RocketAPI.Console.UserSettings")

            For Each setting In settingsSection.Settings
                BotProperties.AddKeyValue(setting.Name, setting.Value.ValueXml.InnerText)
            Next
        End Sub
    End Class
End NameSpace