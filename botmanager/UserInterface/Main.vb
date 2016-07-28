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

            Dim genericBot As Generic = BotFactory.GetBot(botProperties)

            If Edit(botProperties) Then
                My.Settings.BotsProperties.Items.Add(botProperties)
                InitializeBot(botProperties, genericBot)
            Else 
                 botProperties = Nothing
            End If
        End Sub
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

        Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
            Dim bot As Bot

            For Each tabPage As TabPage In TabControl1.TabPages
                bot = DirectCast(tabPage.Tag, Bot)
                Api.SetWindowPos(bot.Handle, 1, 0, 0, tabPage.Width, tabPage.Height, 0)
            Next
        End Sub
       Private Sub Form1_HasLoad(sender As Object, e As EventArgs) Handles MyBase.Shown
            If New Downloading().ShowDialog() = DialogResult.OK Then
                If My.Settings.BotsProperties Is Nothing Then
                    My.Settings.BotsProperties = New BotsProperties
                Else
                    For Each botProperties As Bot In My.Settings.BotsProperties.Items
                        InitializeBot(botProperties, BotFactory.GetBot(botProperties))
                    Next
                End If
            End If
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

        Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
            Dim selectedTab As TabPage = TabControl1.SelectedTab
            Dim botProperties = DirectCast(selectedTab.Tag, Bot)

            selectedTab.Text = botProperties.GetSettingValue("PtcUsername")
            Bots.Items(botProperties.ProcessId).Kill(False)
            Bots.Items(botProperties.ProcessId).Start()
        End Sub

        Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
            Me.LinkLabel1.LinkVisited = True
            System.Diagnostics.Process.Start("http://www.ownedcore.com/forums/pokemon-go/pokemon-go-hacks-cheats/566095-bot-manager-auto-update-includes-multiple-bots-multi-account.html")
        End Sub
    End Class
End NameSpace