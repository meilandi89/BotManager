Imports BotManager.Manager
Imports BotManager.Manager.Helpers
Imports BotManager.Manager.Properties
Imports BotManager.Manager.Type
Imports BotManager.Windows

Namespace UserInterface
    Public Class Main
        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            Dim botProperties As New Bot()
            If ComboBox1.Text = "Haxton" Then
                botProperties.BotClass = "BotManager.Manager.Type.Haxton"
            ElseIf ComboBox1.Text = "Spegeli" Then
                botProperties.BotClass = "BotManager.Manager.Type.Spegeli"
            Else 
                botProperties = Nothing
                MsgBox("Select bot type")
                Exit Sub
            End If

            My.Settings.BotsProperties.Items.Add(botProperties)
            Dim genericBot As Generic = BotFactory.GetBot(botProperties)
            Edit(botProperties)

            InitializeBot(botProperties, genericBot)
        End Sub

        Private Function GetBotTypeName(botname As String) As String()
        End Function

        Private Sub InitializeBot(ByRef botProperties As Bot, ByRef genericBot As Generic)

            Dim newTabPage As TabPage = CreateTabPage(botProperties)
            botProperties.TabPageHandle = newTabPage.Handle

            genericBot.Start()
        End Sub

        Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
            If TabControl1.TabPages.Count = 0 Then Exit Sub
            Dim selectedTab As TabPage = TabControl1.SelectedTab
            Dim runInformation = DirectCast(selectedTab.Tag, Bot)

            KillBot(runInformation)
            My.Settings.BotsProperties.Items.Remove(runInformation)

            selectedTab.Dispose()
            TabControl1.TabPages.Remove(selectedTab)
        End Sub

        Private Function CreateTabPage(bot As Bot) As TabPage
            TabControl1.TabPages.Add(bot.GetSettingValue("PtcUsername"))
            Dim newTabPage As TabPage = TabControl1.TabPages(TabControl1.TabPages.Count - 1)
            newTabPage.Tag = bot

            Return newTabPage
        End Function

        Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
            Dim bot As Bot

            For Each tabPage As TabPage In TabControl1.TabPages
                bot = DirectCast(tabPage.Tag, Bot)
                Api.SetWindowPos(bot.Handle, 1, 0, 0, tabPage.Width, tabPage.Height, 0)
            Next
        End Sub

        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If My.Settings.BotsProperties Is Nothing Then
                My.Settings.BotsProperties = New BotsProperties
            Else
                For Each botProperties As Bot In My.Settings.BotsProperties.Items
                    InitializeBot(botProperties, BotFactory.GetBot(botProperties))
                Next
            End If

            Http.DownloadRepository("https://dist.nuget.org/win-x86-commandline/latest/nuget.exe", "nuget.exe")
            InstallSpegeli()
            InstallHaxton()
        End Sub

        Private Sub InstallSpegeli()
            IO.DeleteFilesFromFolder("Spegeli")
            Http.DownloadRepository("https://github.com/Spegeli/Pokemon-Go-Rocket-API/archive/master.zip", "Spegeli.zip")
            IO.Unzip("Spegeli")

            Dim pInfo As New ProcessStartInfo
            Dim pInfo1 As New ProcessStartInfo
            pInfo1.WorkingDirectory = "Spegeli/PokemoGoBot-GottaCatchEmAll-master"
            pInfo1.FileName = """C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"""
            pinfo1.WindowStyle = ProcessWindowStyle.Hidden
            pinfo.WindowStyle = ProcessWindowStyle.Hidden

            pInfo.FileName = "nuget.exe"
            pInfo.Arguments = "restore " & "Spegeli/PokemoGoBot-GottaCatchEmAll-master"
            CmdLine.Run(pInfo, True)
            CmdLine.Run(pInfo1, True)
        End Sub

        Private Sub InstallHaxton()
            IO.DeleteFilesFromFolder("Haxton")
            Http.DownloadRepository("https://github.com/d-haxton/HaxtonBot/archive/master.zip", "Haxton.zip")
            IO.Unzip("Haxton")
            Dim pInfo As New ProcessStartInfo
            Dim pInfo1 As New ProcessStartInfo
            pInfo1.WorkingDirectory = "Haxton/HaxtonBot-master"
            pInfo1.FileName = """C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"""
            pinfo1.WindowStyle = ProcessWindowStyle.Hidden
            pinfo.WindowStyle = ProcessWindowStyle.Hidden
            pInfo.FileName = "nuget.exe"
            pInfo.Arguments = "restore " & "Haxton/HaxtonBot-master"

            CmdLine.Run(pInfo, True)
            CmdLine.Run(pInfo1, True)
        End Sub

        Private Sub Form1_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
            KillAllBots()
            My.Settings.Save()
        End Sub

        Private Sub KillAllBots()
            For Each botProperties As Bot In My.Settings.BotsProperties.Items
                KillBot(botProperties)
            Next
        End Sub

        Private Sub KillBot(ByRef botProperties As Bot)
            If Not botProperties.IsRunning Then Exit Sub
            Bots.Items(botProperties.ProcessId).Kill()
        End Sub

        Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
            If TabControl1.TabPages.Count = 0 Then Exit Sub
            Dim selectedTab As TabPage = TabControl1.SelectedTab
            Dim botProperties = DirectCast(selectedTab.Tag, Bot)

            If Edit(botProperties, selectedTab) Then
                selectedTab.Text = botProperties.GetSettingValue("PtcUsername")
                Bots.Items(botProperties.ProcessId).Kill(False)
                Bots.Items(botProperties.ProcessId).Start()
            End If
        End Sub

        Private Function Edit(bot As Bot, optional tabPage As TabPage = Nothing) As Boolean
            Dim dialog As New SettingsEditor(bot.SettingKeys, bot.SettingValues)
            If dialog.ShowDialog() = DialogResult.OK Then
                Return True
            End If
            Return False
        End Function

    End Class
End NameSpace