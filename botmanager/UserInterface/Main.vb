Imports System.ComponentModel
Imports System.Management
Imports System.Text
Imports BotManager.List
Imports BotManager.Manager
Imports BotManager.Properties
Imports BotManager.Windows

Namespace UserInterface
    Public Class Main
        Private ReadOnly _
            _processSearcher As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name='WerFault.exe'")
        Private ReadOnly _bots As New ArrayList

        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            Dim botInformation As New BotInformation()

            If ComboBox1.Text = "Haxton" Then
                botInformation.BotClass = "BotManager.Manager.Haxton"
            ElseIf ComboBox1.Text = "Spegeli" Then
                botInformation.BotClass = "BotManager.Manager.Spegeli"
            ElseIf ComboBox1.Text = "Necro" Then
                botInformation.BotClass = "BotManager.Manager.Necro"
            Else
                botInformation = Nothing
                MsgBox("Select bot type")
                Exit Sub
            End If
            Dim dialog As New SettingsEditor(botInformation)


            If dialog.ShowDialog() = DialogResult.OK Then
                For Each returnedBotInformation As BotInformation In dialog.BatchAddProperties
                    My.Settings.ListOfPropertiesBots.Items.Add(returnedBotInformation)
                    CreateTreeNode(returnedBotInformation)
                Next

                 StartAllBots()
            End If

            dialog = Nothing
        End Sub

        Private Sub CreateTreeNode(ByRef botInformation As BotInformation)
            Dim newTreeNode As New TreeNode
            Dim title As String = botInformation.GetSettingValue("PtcUsername")
            If title.Contains("username") Then title = botInformation.GetSettingValue("GoogleEmail")
            newTreeNode.Name = title
            newTreeNode.Text = title
            Dim bot As Generic = BotFactory.GetBot(botInformation)
            _bots.Add(bot)
            newTreeNode.Tag = bot
            TreeView1.Nodes.Add(newTreeNode)
        End Sub

        Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            Dim bot = DirectCast(TreeView1.SelectedNode.Tag, Generic)
            _bots.Remove(bot)
            bot.Dispose()
            My.Settings.ListOfPropertiesBots.Items.Remove(bot.BotInformation)
            TreeView1.Nodes.Remove(TreeView1.SelectedNode)
        End Sub

        Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
            ResizeCmd()
        End Sub

        Private Sub ResizeCmd()
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            Dim bot = DirectCast(TreeView1.SelectedNode.Tag, Generic)
            Api.SetWindowPos(bot.Handle, 1, 0, 0, Panel1.Width, Panel1.Height, 0)
        End Sub

        Private Sub Form1_HasLoad(sender As Object, e As EventArgs) Handles MyBase.Shown
            Generic.PanelHandle = Panel1.Handle
            If New Downloading().ShowDialog() = DialogResult.OK Then
            End If

            If My.Settings.ListOfPropertiesBots Is Nothing Then
                My.Settings.ListOfPropertiesBots = New OfPropertiesBots
            Else
                For Each botInformation As BotInformation In My.Settings.ListOfPropertiesBots.Items
                    CreateTreeNode(botInformation)
                Next

                StartAllBots()
            End If
        End Sub
        Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
            Dim t As Task = Task.Run(Sub()
                For Each bot As Generic In _bots
                    bot.Dispose()                       
                Next
            End Sub)

            t.Wait()
            My.Settings.Save()
        End Sub
        Private Sub StartAllBots()
            Dim t As Task = Task.Run(Sub()
                For Each bot As Generic In _bots
                    If Not bot.IsRunning Then bot.Start()
                Next
            End Sub)
        End Sub
        Private Sub KillAllBots()
            Dim t As Task = Task.Run(Sub()
                For Each bot As Generic In _bots
                    If bot.IsRunning Then bot.Kill(False)
                Next
            End Sub)

            t.Wait()
        End Sub
        Private Sub btnRestartAll_Click(sender As Object, e As EventArgs) Handles btnRestartAll.Click
            KillAllBots()
            StartAllBots()
        End Sub
        Private Sub btnStopAll_Click(sender As Object, e As EventArgs) Handles btnStopAll.Click
            KillAllBots()
        End Sub
        Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            Dim bot = DirectCast(TreeView1.SelectedNode.Tag, Generic)
            Dim dialog As New SettingsEditor(bot.BotInformation)

            If dialog.ShowDialog() = DialogResult.OK Then
                Dim title As String = bot.BotInformation.GetSettingValue("PtcUsername")
                If title.ToLower().Contains("username") Then title = bot.BotInformation.GetSettingValue("GoogleEmail")
                TreeView1.SelectedNode.Text = title

                bot.Kill(false)
                bot.Start()
            End If
        End Sub

        Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
            Handles LinkLabel1.LinkClicked
            LinkLabel1.LinkVisited = True
            Process.Start(
                "http://www.ownedcore.com/forums/pokemon-go/pokemon-go-hacks-cheats/566095-bot-manager-auto-update-includes-multiple-bots-multi-account.html")
        End Sub

        Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            Dim bot = DirectCast(TreeView1.SelectedNode.Tag, Generic)
            If bot.IsRunning Then bot.Kill(False)
            bot.Start()
        End Sub

        Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            Dim bot = DirectCast(TreeView1.SelectedNode.Tag, Generic)

            If bot.IsRunning Then
                 bot.Kill(False)
            End If
        End Sub

        Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            For Each supportedBotInformation As SupportedBotInformation In OfSupportedBots.GetInstance().Values
                If Not supportedBotInformation.DisplayAsBot Then Continue For
                ComboBox1.Items.Add(supportedBotInformation.Name)
            Next
        End Sub

        Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
            If Not BackgroundWorker.IsBusy Then
                BackgroundWorker.RunWorkerAsync()
            End If
            Dim total As Double = 0
            For Each treeNode As TreeNode In TreeView1.nodes
                Dim bot = DirectCast(treeNode.Tag, Generic)

                If bot.IsRunning Then
                    Dim caption As New StringBuilder(256)
                    Api.GetWindowText(bot.Handle, caption, caption.Capacity)
                    Dim str As String() = caption.ToString.Split("|")
                    If str.Length >= 2 Then
                        treeNode.Text = treeNode.Name & " - " & str(2)
                        total += CDbl(str(2).Split(":")(1).Trim())
                    End If
                End If
            Next

            Label3.Text = String.Format("Total Bots: {0}, Average Exp: {1}, Total Exp: {2}", TreeView1.Nodes.Count, total/TreeView1.Nodes.Count, total)
        End Sub

        Private Sub BackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker.DoWork
            TimerTask()
        End Sub

        Private Sub TimerTask()
            For Each process As ManagementObject in _processSearcher.Get()
                If ContainsProcess(process("CommandLine").ToString())
                    process.InvokeMethod("Terminate", Nothing)
                End If
            Next
        End Sub

        Private Function ContainsProcess(commandLine As String)
            Return _bots.Cast (Of Generic)().Any(Function(bot) commandLine.Contains(bot.ProcessId.ToString()))
        End Function

        Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
            If Not e.Node.IsSelected Then Exit Sub
            Dim bot = DirectCast(e.Node.Tag, Generic)
            Api.ShowWindow(bot.Handle, 5)
            Api.SetWindowPos(bot.Handle, 1, 0, 0, Panel1.Width, Panel1.Height, 0)
            bot.IsSelected = True
        End Sub

        Private Sub TreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) _
            Handles TreeView1.BeforeSelect

            If TreeView1.SelectedNode Is Nothing Then
                Dim bot = DirectCast(e.Node.Tag, Generic)
                Api.ShowWindow(bot.Handle, 5)
                Api.SetWindowPos(bot.Handle, 1, 0, 0, Panel1.Width, Panel1.Height, 0)
            Else
                Dim bot = DirectCast(TreeView1.SelectedNode.Tag, Generic)
                Api.ShowWindow(bot.Handle, 0)
                bot.IsSelected = False
            End If
        End Sub
    End Class
End NameSpace