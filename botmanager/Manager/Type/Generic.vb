Imports System.Configuration
Imports System.Threading
Imports BotManager.Manager.Properties

Namespace Manager.Type
    Public Class Generic
        Public Shared Function RunBot(ByRef bot As Bot) As IntPtr
            CreateNewUserSettings(bot)

            Dim pInfo As New ProcessStartInfo
            pInfo.WorkingDirectory = Path.GetDirectoryName(bot.TempExecutablePath)
            pInfo.FileName = Path.GetFileName(bot.TempExecutablePath)

            Dim p As Process = Process.Start(pInfo)

            Thread.Sleep(100)

            bot.ProcessId = p.Id
            bot.Handle = p.MainWindowHandle

            bot.IsRunning = True
            Return p.MainWindowHandle
        End Function

        Private Shared Sub CreateNewUserSettings(ByRef bot As Bot)
            Dim fileMap As New ExeConfigurationFileMap()
            fileMap.ExeConfigFilename =
                bot.TempExecutablePath & ".config"
            Dim config As Configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                                                                                          ConfigurationUserLevel.None)
            Dim settingsSection 
            Dim tempSetting 

            If bot.IsHaxton Then
                settingsSection = config.AppSettings
                tempSetting = new KeyValueConfigurationElement("TempSetting", "temp")
            Else 
                settingsSection = config.GetSection("userSettings/PokemonGo.RocketAPI.Console.UserSettings")
                tempSetting = new SettingElement("TempSetting", SettingsSerializeAs.String)
            End If

            settingsSection.Settings.Add(tempSetting)

            If bot.IsHaxton Then
                For Each setting As String In bot.SettingKeys
                    DirectCast(settingsSection, AppSettingsSection).Settings.Item(Setting).Value = bot.GetSettingValue(setting).ToString()
                Next
                DirectCast(settingsSection, AppSettingsSection).Settings.Remove("TempSetting")
            Else 
                For Each setting As String In bot.SettingKeys
                    settingsSection.Settings.Get(Setting).Value.ValueXml.LastChild.InnerText = bot.GetSettingValue(setting).ToString()
                Next
                settingsSection.Settings.Remove(tempSetting)
            End If

            config.Save(ConfigurationSaveMode.Full)
        End Sub

        Public Shared Sub SetSettings(ByRef bot As Bot)
            Dim fileMap As New ExeConfigurationFileMap()
            fileMap.ExeConfigFilename =
                bot.TempExecutablePath & ".config"
            Dim config As Configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                                                                                          ConfigurationUserLevel.None)
            Dim settingsSection
            settingsSection = config.GetSection("userSettings/PokemonGo.RocketAPI.Console.UserSettings")

            If settingsSection is Nothing Then
                bot.IsHaxton = True
                settingsSection = config.AppSettings
            End If
            If bot.IsHaxton Then
                For Each setting  In settingsSection.Settings
                    bot.AddKeyValue(setting.[Key], setting.Value.ToString())
                Next
            Else 
                For Each setting  In settingsSection.Settings
                    bot.AddKeyValue(setting.Name, setting.Value.ValueXml.InnerText)
                Next
            End If
        End Sub

        Public Shared Sub StopBot(bot As Bot)
            Try
                Dim p As Process = Process.GetProcessById(bot.ProcessId)
                p.Kill()
                bot.IsRunning = False
            Catch
            End Try
        End Sub
    End Class
End NameSpace