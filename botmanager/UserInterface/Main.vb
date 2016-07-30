Imports BotManager.Manager
Imports BotManager.Manager.Type
Imports BotManager.Properties
Imports BotManager.Windows

Namespace UserInterface
    Public Class Main
        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            Dim botProperties As New BotInformation()

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
                My.Settings.ListOfPropertiesBots.Items.Add(botProperties)
                InitializeBot(botProperties, genericBot)
            Else 
                 botProperties = Nothing
            End If
        End Sub
        Private Sub InitializeBot(ByRef botProperties As BotInformation, ByRef genericBot As Generic)
            Dim newTabPage As TabPage = CreateTabPage(botProperties)
            botProperties.TabPageHandle = newTabPage.Handle
            genericBot.Start()
        End Sub

        Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
            If TabControl1.TabPages.Count = 0 Then Exit Sub
            Dim selectedTab As TabPage = TabControl1.SelectedTab
            Dim botProperties = DirectCast(selectedTab.Tag, BotInformation)

            KillBot(botProperties)
            My.Settings.ListOfPropertiesBots.Items.Remove(botProperties)

            selectedTab.Dispose()
            TabControl1.TabPages.Remove(selectedTab)
        End Sub

        Private Function CreateTabPage(botProperties As BotInformation) As TabPage
            Dim title As String = botProperties.GetSettingValue("PtcUsername")
            If title.Contains("username") Then title = botProperties.GetSettingValue("GoogleEmail")

            TabControl1.TabPages.Add(title)
            Dim newTabPage As TabPage = TabControl1.TabPages(TabControl1.TabPages.Count - 1)
            newTabPage.Tag = botProperties

            Return newTabPage
        End Function

        Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
            ResizeCmd()
        End Sub
        Private Sub ResizeCmd()
            If TabControl1.TabPages.Count = 0 Then Exit Sub
            Dim selectedTab As TabPage = TabControl1.SelectedTab
            Dim botProperties = DirectCast(selectedTab.Tag, BotInformation)
            Api.SetWindowPos(botProperties.Handle, 1, 0, 0, selectedTab.Width, selectedTab.Height, 0)
        End Sub
       Private Sub Form1_HasLoad(sender As Object, e As EventArgs) Handles MyBase.Shown
            If New Downloading().ShowDialog() = DialogResult.OK Then
            End If

                            If My.Settings.ListOfPropertiesBots Is Nothing Then
                    My.Settings.ListOfPropertiesBots = New List.OfPropertiesBots
                Else
                    For Each botProperties As BotInformation In My.Settings.ListOfPropertiesBots.Items
                        InitializeBot(botProperties, BotFactory.GetBot(botProperties))
                    Next
                End If
       End Sub
        Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
            KillAllBots()
            My.Settings.Save()
        End Sub
        Private Sub KillAllBots()
            For Each botProperties As BotInformation In My.Settings.ListOfPropertiesBots.Items
                KillBot(botProperties)
            Next
        End Sub
        Private Sub KillBot(ByRef botProperties As BotInformation)
            If Not botProperties.IsRunning Then Exit Sub
            List.OfGenericBots.Items(botProperties.ProcessId).Kill()
        End Sub
        Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
            If TabControl1.TabPages.Count = 0 Then Exit Sub
            Dim selectedTab As TabPage = TabControl1.SelectedTab
            Dim botProperties = DirectCast(selectedTab.Tag, BotInformation)

            If Edit(botProperties, selectedTab) Then
                Dim title As String = botProperties.GetSettingValue("PtcUsername")
                If title.Contains("username") Then title = botProperties.GetSettingValue("GoogleEmail")
                selectedTab.Text = title
                List.OfGenericBots.Items(botProperties.ProcessId).Kill(False)
                List.OfGenericBots.Items(botProperties.ProcessId).Start()
            End If
        End Sub
        Private Function Edit(bot As BotInformation, optional tabPage As TabPage = Nothing) As Boolean
            Dim dialog As New SettingsEditor(bot)
            If dialog.ShowDialog() = DialogResult.OK Then
                Return True
            End If
            Return False
        End Function
        Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
            LinkLabel1.LinkVisited = True
            Process.Start("http://www.ownedcore.com/forums/pokemon-go/pokemon-go-hacks-cheats/566095-bot-manager-auto-update-includes-multiple-bots-multi-account.html")
        End Sub
        Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
            Dim selectedTab As TabPage = TabControl1.SelectedTab
            Dim botProperties = DirectCast(selectedTab.Tag, BotInformation)

            List.OfGenericBots.Items(botProperties.ProcessId).Kill(False)
            List.OfGenericBots.Items(botProperties.ProcessId).Start()
        End Sub
        Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
            Dim selectedTab As TabPage = TabControl1.SelectedTab
            Dim botProperties = DirectCast(selectedTab.Tag, BotInformation)

            If botProperties.IsRunning Then
                List.OfGenericBots.Items(botProperties.ProcessId).Kill(False)
            End If
        End Sub
        Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
            ResizeCmd()
        End Sub
        Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            For Each supportedBotInformation As Properties.SupportedBotInformation In List.OfSupportedBots.GetInstance()
                ComboBox1.Items.Add(supportedBotInformation.Name)
            Next
        End Sub
    End Class
End NameSpace