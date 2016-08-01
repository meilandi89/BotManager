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

        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            Dim botProperties As New BotInformation()

            If ComboBox1.Text = "Haxton" Then
                botProperties.BotClass = "BotManager.Manager.Haxton"
            ElseIf ComboBox1.Text = "Spegeli" Then
                botProperties.BotClass = "BotManager.Manager.Spegeli"
            Else
                botProperties = Nothing
                MsgBox("Select bot type")
                Exit Sub
            End If
            Dim dialog As New SettingsEditor(botProperties)


            If dialog.ShowDialog() = DialogResult.OK Then
                For Each botInformation As BotInformation In dialog.BatchAddProperties
                    My.Settings.ListOfPropertiesBots.Items.Add(botInformation)
                    CreateTreeNode(botInformation)
                Next

                Dim t As Task = Task.Run(Sub()
                    For Each botInformation As BotInformation In My.Settings.ListOfPropertiesBots.Items
                        Dim genericBot As Generic = BotFactory.GetBot(botInformation)
                        genericBot.Start()
                    Next
                                            End Sub)
            End If

            dialog = Nothing
        End Sub

        Private Sub CreateTreeNode(ByRef botInformation As BotInformation)
            Dim newTreeNode As New TreeNode
            Dim title As String = botInformation.GetSettingValue("PtcUsername")
            If title.Contains("username") Then title = botInformation.GetSettingValue("GoogleEmail")
            newTreeNode.Name = title
            newTreeNode.Text = title
            newTreeNode.Tag = botInformation
            botInformation.PanelHandle = Panel1.Handle
            TreeView1.Nodes.Add(newTreeNode)
        End Sub

        Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            Dim botInformation = DirectCast(TreeView1.SelectedNode.Tag, BotInformation)

            KillBot(botInformation)
            My.Settings.ListOfPropertiesBots.Items.Remove(botInformation)

            TreeView1.Nodes.Remove(TreeView1.SelectedNode)
        End Sub

        Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
            ResizeCmd()
        End Sub

        Private Sub ResizeCmd()
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            Dim botInformation = DirectCast(TreeView1.SelectedNode.Tag, BotInformation)
            Api.SetWindowPos(botInformation.Handle, 1, 0, 0, Panel1.Width, Panel1.Height, 0)
        End Sub

        Private Sub Form1_HasLoad(sender As Object, e As EventArgs) Handles MyBase.Shown
            If New Downloading().ShowDialog() = DialogResult.OK Then
            End If

            If My.Settings.ListOfPropertiesBots Is Nothing Then
                My.Settings.ListOfPropertiesBots = New OfPropertiesBots
            Else
                For Each botInformation As BotInformation In My.Settings.ListOfPropertiesBots.Items
                    CreateTreeNode(botInformation)
                Next

                Dim t As Task = Task.Run(Sub()
                    For Each botInformation As BotInformation In My.Settings.ListOfPropertiesBots.Items
                        botInformation.IsSelected = False
                        Dim genericBot As Generic = BotFactory.GetBot(botInformation)
                        genericBot.Start()
                    Next
                                            End Sub)
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
            OfGenericBots.GetInstance()(botProperties.ProcessId).Kill()
        End Sub

        Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            Dim botProperties = DirectCast(TreeView1.SelectedNode.Tag, BotInformation)
            Dim dialog As New SettingsEditor(botProperties)

            If dialog.ShowDialog() = DialogResult.OK Then
                Dim title As String = botProperties.GetSettingValue("PtcUsername")
                If title.ToLower().Contains("username") Then title = botProperties.GetSettingValue("GoogleEmail")
                TreeView1.SelectedNode.Text = title

                OfGenericBots.GetInstance()(botProperties.ProcessId).Kill(False)
                OfGenericBots.GetInstance()(botProperties.ProcessId).Start()
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
            Dim botInformation = DirectCast(TreeView1.SelectedNode.Tag, BotInformation)

            OfGenericBots.GetInstance()(botInformation.ProcessId).Kill(False)
            OfGenericBots.GetInstance()(botInformation.ProcessId).Start()
        End Sub

        Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            Dim botInformation = DirectCast(TreeView1.SelectedNode.Tag, BotInformation)

            If botInformation.IsRunning Then
                OfGenericBots.GetInstance()(botInformation.ProcessId).Kill(False)
            End If
        End Sub

        Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            For Each supportedBotInformation As SupportedBotInformation In OfSupportedBots.GetInstance().Values
                ComboBox1.Items.Add(supportedBotInformation.Name)
            Next
        End Sub

        Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
            If Not BackgroundWorker.IsBusy Then
                BackgroundWorker.RunWorkerAsync()
            End If
            Dim total As Double = 0
            For Each treeNode As TreeNode In TreeView1.nodes
                Dim botInformation = DirectCast(treeNode.Tag, BotInformation)

                If botInformation.IsRunning Then
                    Dim caption As New StringBuilder(256)
                    Api.GetWindowText(botInformation.Handle, caption, caption.Capacity)
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
            Return OfGenericBots.GetInstance().Keys.Any(Function(botProcessId) commandLine.Contains(botProcessId.ToString()))
        End Function

        Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
            If Not e.Node.IsSelected Then Exit Sub
            Dim botInformation = DirectCast(e.Node.Tag, BotInformation)
            Api.ShowWindow(botInformation.Handle, 5)
            Api.SetWindowPos(botInformation.Handle, 1, 0, 0, Panel1.Width, Panel1.Height, 0)
            botInformation.IsSelected = True
        End Sub

        Private Sub TreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) _
            Handles TreeView1.BeforeSelect

            If TreeView1.SelectedNode Is Nothing Then
                Dim botInformation = DirectCast(e.Node.Tag, BotInformation)
                Api.ShowWindow(botInformation.Handle, 5)
                Api.SetWindowPos(botInformation.Handle, 1, 0, 0, Panel1.Width, Panel1.Height, 0)
            Else
                Dim botInformation = DirectCast(TreeView1.SelectedNode.Tag, BotInformation)
                Api.ShowWindow(botInformation.Handle, 0)
                botInformation.IsSelected = False
            End If
        End Sub
    End Class
End NameSpace