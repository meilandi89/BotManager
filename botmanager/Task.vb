Imports System.Configuration
Imports System.Threading
    Public Class Task
        Public Shared Function RunBot(ByRef runInformation As RunInformation) As IntPtr
            CreateNewUserSettings(runInformation)

            Dim pInfo As New ProcessStartInfo
            pInfo.WorkingDirectory = Path.GetDirectoryName(runInformation.TempExecutablePath)
            pInfo.FileName = Path.GetFileName(runInformation.TempExecutablePath)

            Dim p As Process = Process.Start(pInfo)

            Thread.Sleep(100)

            runInformation.ProcessId = p.Id
            runInformation.Handle = p.MainWindowHandle
         

            runInformation.IsRunning = True
            Return p.MainWindowHandle
        End Function

        Private Shared Sub CreateNewUserSettings(ByRef runInformation As RunInformation)
            Dim fileMap As New ExeConfigurationFileMap()
            fileMap.ExeConfigFilename =
                runInformation.TempExecutablePath & ".config"
            Dim config As Configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                                                                                          ConfigurationUserLevel.None)
            Dim settingsSection 
            Dim tempSetting 

            If runInformation.IsHaxton Then
                settingsSection = config.AppSettings
                tempSetting = new KeyValueConfigurationElement("TempSetting", "temp")
            Else 
                settingsSection = config.GetSection("userSettings/PokemonGo.RocketAPI.Console.UserSettings")
                tempSetting = new SettingElement("TempSetting", SettingsSerializeAs.String)
            End If

            settingsSection.Settings.Add(tempSetting)

            If runInformation.IsHaxton Then
                For Each setting As String In runInformation.SettingKeys
                    DirectCast(settingsSection, AppSettingsSection).Settings.Item(Setting).Value = runInformation.GetSettingValue(setting).ToString()
                Next
                DirectCast(settingsSection, AppSettingsSection).Settings.Remove("TempSetting")
            Else 
                For Each setting As String In runInformation.SettingKeys
                    settingsSection.Settings.Get(Setting).Value.ValueXml.LastChild.InnerText = runInformation.GetSettingValue(setting).ToString()
                Next
                settingsSection.Settings.Remove(tempSetting)
            End If

            config.Save(ConfigurationSaveMode.Full)
        End Sub

        Public Shared Sub SetSettings(ByRef runInformation As RunInformation)
            Dim fileMap As New ExeConfigurationFileMap()
            fileMap.ExeConfigFilename =
                runInformation.TempExecutablePath & ".config"
            Dim config As Configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                                                                                          ConfigurationUserLevel.None)
            Dim settingsSection
            settingsSection = config.GetSection("userSettings/PokemonGo.RocketAPI.Console.UserSettings")

            If settingsSection is Nothing Then
                runInformation.IsHaxton = True
                settingsSection = config.AppSettings
            End If
            If runInformation.IsHaxton Then
                    For Each setting  In settingsSection.Settings
                        runInformation.AddKeyValue(setting.[Key], setting.Value.ToString())
                    Next
                Else 
                    For Each setting  In settingsSection.Settings
                        runInformation.AddKeyValue(setting.Name, setting.Value.ValueXml.InnerText)
                    Next
            End If
        End Sub

        Public Shared Sub StopBot(runInformation As RunInformation)
            Try
                Dim p As Process = Process.GetProcessById(runInformation.ProcessId)
                p.Kill()
                runInformation.IsRunning = False
            Catch
            End Try
        End Sub
    End Class
