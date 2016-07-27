Imports BotManager.Manager
Imports BotManager.Manager.Helper
Imports BotManager.Manager.Properties
Imports BotManager.Manager.Type
Imports BotManager.Windows

Namespace UserInterface
    Public Class Main
        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            Dim runInformation As New Bot()
            runInformation.ExecutablePath = TextBox1.Text
            My.Settings.Bots.Items.Add(runInformation)

            StartBot(runInformation, True)
        End Sub

        Private Sub StartBot(ByRef bot As Bot, Optional isNew As Boolean = False)
            If File.Exists(bot.ExecutablePath) Then
                bot.TempExecutablePath = IO.CopyFolder(Path.GetDirectoryName(bot.ExecutablePath)) & "\" & Path.GetFileName(bot.ExecutablePath)
            Else 
                MsgBox("Path doesn't Exists")
                My.Settings.Bots.Items.Remove(bot)
                Exit Sub
            End If

            If isNew Then 
                Generic.SetSettings(bot)
                Edit(bot)
            End If

            Dim newTabPage As TabPage = CreateTabPage(bot)
            Generic.RunBot(bot)
            bot.TabPageHandle = newTabPage.Handle

            Api.SetParent(bot.Handle, bot.TabPageHandle)
            Api.SetWindowPos(bot.Handle, 1, 0, 0, newTabPage.Width, newTabPage.Height, 0)
        End Sub

        Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
            If TabControl1.TabPages.Count = 0 Then Exit Sub
            Dim selectedTab As TabPage = TabControl1.SelectedTab
            Dim runInformation = DirectCast(selectedTab.Tag, Bot)

            KillBot(runInformation)
            My.Settings.Bots.Items.Remove(runInformation)

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
            If My.Settings.Bots Is Nothing Then
                My.Settings.Bots = New Bots
            Else
                For Each runInformation As Bot In My.Settings.Bots.Items
                    StartBot(runInformation)
                Next
            End If

            TextBox1.Text = my.Settings.Textbox
        End Sub

        Private Sub Form1_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing

            KillAllBots()
            My.Settings.Save()
        End Sub

        Private Sub KillAllBots()
            For Each runInformation As Bot In My.Settings.Bots.Items
                KillBot(runInformation)
            Next
        End Sub
        Private Sub KillBot(bot As Bot)
            If Not bot.IsRunning Then Exit Sub
            Generic.StopBot(bot)
            Threading.Thread.Sleep(300)
            IO.DeleteFilesFromFolder(Path.GetDirectoryName(bot.TempExecutablePath))
        End Sub


        Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
            If TabControl1.TabPages.Count = 0 Then Exit Sub

            Dim selectedTab As TabPage = TabControl1.SelectedTab
            Dim runInformation = DirectCast(selectedTab.Tag, Bot)
            KillBot(runInformation)
            Edit(runInformation, selectedTab)
            StartBot(runInformation)
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