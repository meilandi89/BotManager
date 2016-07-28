Imports BotManager.Manager
Imports BotManager.Manager.Properties
Imports BotManager.Manager.Type
Imports BotManager.Windows

Namespace UserInterface
    Public Class Main
        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            Dim botProperties As New Manager.Properties.Bot()
            botProperties.ExecutablePath = TextBox1.Text
            botProperties.BotClass = "BotManager.Manager.Type.Haxton"
            My.Settings.BotsProperties.Items.Add(botProperties)

            Dim genericBot As Manager.Type.Generic = Manager.BotFactory.GetBot(botProperties)
            Edit(botProperties)

            InitializeBot(botProperties, genericBot)
        End Sub

        Private Sub InitializeBot(ByRef botProperties As Bot, ByRef genericBot As Manager.Type.Generic)

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
                    InitializeBot(botProperties, Manager.BotFactory.GetBot(botProperties))
                Next
            End If

            TextBox1.Text = my.Settings.Textbox
        End Sub

        Private Sub Form1_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
            KillAllBots()
            My.Settings.Save()
        End Sub
        Private Sub KillAllBots()
            For Each runInformation As Bot In My.Settings.BotsProperties.Items
                KillBot(runInformation)
            Next
        End Sub
        Private Sub KillBot(ByRef botProperties As Bot)
            If Not botProperties.IsRunning Then Exit Sub
            Manager.Bots.Items(botProperties.ProcessId).Kill()
        End Sub


        Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
            If TabControl1.TabPages.Count = 0 Then Exit Sub
            Dim selectedTab As TabPage = TabControl1.SelectedTab
            Dim botProperties = DirectCast(selectedTab.Tag, Bot)

            KillBot(botProperties)
            Edit(botProperties, selectedTab)
            InitializeBot(botProperties, Manager.BotFactory.GetBot(botProperties))
        End Sub

        Private Sub Edit(bot As Bot, optional tabPage As TabPage = Nothing)
            Dim dialog As New SettingsEditor(bot.SettingKeys, bot.SettingValues)
            If dialog.ShowDialog() = DialogResult.OK Then
                If Not tabPage Is Nothing Then
                    tabPage.Dispose()
                    TabControl1.TabPages.Remove(tabPage)
                End If
            End If
        End Sub

        Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
            My.Settings.Textbox = TextBox1.Text
        End Sub

        Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
            OpenFileDialog.Filter = "executable|*.exe"
            If OpenFileDialog.ShowDialog() = DialogResult.OK
                TextBox1.Text = OpenFileDialog.FileName
                OpenFileDialog.InitialDirectory = path.GetDirectoryName(OpenFileDialog.FileName)
            End If
        End Sub
    End Class
End NameSpace