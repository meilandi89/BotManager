Imports System.Configuration
Imports BotManager.Manager.Helpers
Imports BotManager.Properties
Imports BotManager.Windows

Namespace UserInterface

    Public Class Downloading
        Const Nuget As String = "nuget.exe"
        Const NugetArgument As String = "restore "
        Const MsBuild As String = "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"
        Private _compIncrement As Integer = 0
        Private _currentComp As Integer = 0
        Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
            InstallNuget()
            _compIncrement = 90/(List.OfSupportedBots.GetInstance().Count*5)

            For Each supportedBotInformation As SupportedBotInformation In List.OfSupportedBots.GetInstance().Values
                InstallBot(supportedBotInformation)
            Next

            BackgroundWorker1.ReportProgress(0,  "Complete")
            Threading.Thread.Sleep(500)
        End Sub
        Private Sub BackgroundWorker1_ReportProgress(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
            _currentComp += e.ProgressPercentage
            ProgressBar1.Value = _currentComp
            Label1.Text = e.UserState.ToString()
        End Sub
        Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
            DialogResult = DialogResult.OK
        End Sub
        Private Sub InstallNuget()
            BackgroundWorker1.ReportProgress(10,  "Downloading Nuget.exe")
            If Not File.Exists(Nuget) Then
                Http.DownloadRepository("https://dist.nuget.org/win-x86-commandline/latest/nuget.exe", "nuget.exe")
            End If
        End Sub
        Private Sub InstallBot(ByRef supportedBotInformation As SupportedBotInformation)
            DeleteOldBot(supportedBotInformation)
            DownloadBot(supportedBotInformation)
            UnZipBot(supportedBotInformation)
            DownloadBotPackages(supportedBotInformation)
            CompileBot(supportedBotInformation)
        End Sub
        Private Sub DeleteOldBot(ByRef supportedBotInformation As SupportedBotInformation)
            BackgroundWorker1.ReportProgress(_compIncrement, "Deleting " & supportedBotInformation.Name & "directory")
            IO.DeleteFilesFromFolder(supportedBotInformation.Name)
        End Sub
        Private Sub DownloadBot(ByRef supportedBotInformation As SupportedBotInformation)
            BackgroundWorker1.ReportProgress(_compIncrement, "Downloading " & supportedBotInformation.Name)
            Http.DownloadRepository(supportedBotInformation.DownloadUrl, supportedBotInformation.ZipName)
        End Sub
        Private Sub UnZipBot(ByRef supportedBotInformation As SupportedBotInformation)
            BackgroundWorker1.ReportProgress(_compIncrement, "Unzipping " & supportedBotInformation.Name)
            IO.Unzip(supportedBotInformation.Name)
        End Sub
        Private Sub DownloadBotPackages(ByRef supportedBotInformation As SupportedBotInformation)
            BackgroundWorker1.ReportProgress(_compIncrement, "Downloading packages for " & supportedBotInformation.Name)
            Dim nugetInfo As New ProcessStartInfo
            nugetInfo.FileName = Nuget
            nugetInfo.Arguments = NugetArgument & supportedBotInformation.WorkingDirectory
            nugetInfo.WindowStyle = ProcessWindowStyle.Hidden
            CmdLine.Run(nugetInfo, True)
        End Sub
        Private Sub CompileBot(ByRef supportedBotInformation As SupportedBotInformation)
            BackgroundWorker1.ReportProgress(_compIncrement, "Compiling " & supportedBotInformation.Name)
            Dim msBuildInfo As New ProcessStartInfo
            msBuildInfo.WorkingDirectory = supportedBotInformation.WorkingDirectory
            msBuildInfo.FileName = Chr(34) & MsBuild & Chr(34)
            msBuildInfo.WindowStyle = ProcessWindowStyle.Hidden
            CmdLine.Run(msBuildInfo, True)
        End Sub
        Private Sub AddSettings(ByRef supportedBotInformation As SupportedBotInformation)
            Select Case supportedBotInformation.Name
                Case "Spegeli"
                    SpegeliReadSettings(supportedBotInformation)
                Case "Haxton"
                    HaxtonReadSettings(supportedBotInformation)
            End Select
        End Sub
         Private Sub HaxtonReadSettings(ByRef supportedBotInformation As SupportedBotInformation)
            Dim fileMap As New ExeConfigurationFileMap()
            fileMap.ExeConfigFilename =
                supportedBotInformation.ExecutablePath & ".config"
            Dim config As Configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                                                                                          ConfigurationUserLevel.None)
            Dim settingsSection
            settingsSection = config.AppSettings

            For Each setting In settingsSection.Settings
                supportedBotInformation.AddKeyValue(setting.[Key], setting.Value.ToString())
            Next
        End Sub
        Private Sub SpegeliReadSettings(ByRef supportedBotInformation As SupportedBotInformation)
            Dim fileMap As New ExeConfigurationFileMap()
            fileMap.ExeConfigFilename =
                supportedBotInformation.ExecutablePath & ".config"
            Dim config As Configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                                                                                          ConfigurationUserLevel.None)
            Dim settingsSection
            settingsSection = config.GetSection("userSettings/PokemonGo.RocketAPI.Console.UserSettings")

            For Each setting In settingsSection.Settings
                supportedBotInformation.AddKeyValue(setting.Name, setting.Value.ValueXml.InnerText)
            Next
        End Sub
        Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
            btnYes.Visible = False
            btnNo.Visible = False
            BackgroundWorker1.RunWorkerAsync()
        End Sub
        Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
            DialogResult = DialogResult.Cancel
        End Sub
        Private Sub Downloading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If Not File.Exists(MsBuild) Then
                MsgBox("Please install all the required software!")
                End
            End If
            If Not Installed Then
                BackgroundWorker1.RunWorkerAsync()
            Else 
                btnYes.Visible = True
                btnNo.Visible = True
            End If

            For Each supportedBotInformation As SupportedBotInformation In List.OfSupportedBots.GetInstance().Values
                AddSettings(supportedBotInformation)
            Next
        End Sub
        Private Function Installed() As Boolean
            For Each supportedBotInformation As SupportedBotInformation In List.OfSupportedBots.GetInstance().Values
                If Not Directory.Exists(supportedBotInformation.WorkingDirectory & "\") Then
                    Return False
                End If
            Next
            Return True
        End Function
    End Class
End NameSpace