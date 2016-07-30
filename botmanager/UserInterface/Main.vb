Imports System.ComponentModel
Imports System.Management
Imports BotManager.List
Imports BotManager.Manager
Imports BotManager.Manager.Type
Imports BotManager.Properties
Imports BotManager.Windows

Namespace UserInterface
    Public Class Main
        Private ReadOnly _
            _processSearcher As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name='WerFault.exe'")

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
                t.Wait()
            End If

            dialog = Nothing
        End Sub

        Private Sub CreateTreeNode(ByRef botInformation As BotInformation)
            'If Not botInformation.Hide Then
            Dim newTreeNode As New TreeNode
            Dim title As String = botInformation.GetSettingValue("PtcUsername")
            If title.Contains("username") Then title = botInformation.GetSettingValue("GoogleEmail")
            newTreeNode.Name = title
            newTreeNode.Text = title
            newTreeNode.Tag = botInformation
            botInformation.PanelHandle = Panel1.Handle
            TreeView1.Nodes.Add(newTreeNode)
            'End If
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
                        Dim genericBot As Generic = BotFactory.GetBot(botInformation)
                        genericBot.Start()
                    Next
                                            End Sub)
                t.Wait()
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
            OfGenericBots.Items(botProperties.ProcessId).Kill()
        End Sub

        Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            Dim botProperties = DirectCast(TreeView1.SelectedNode.Tag, BotInformation)

            If Edit(botProperties) Then
                Dim title As String = botProperties.GetSettingValue("PtcUsername")
                If title.Contains("username") Then title = botProperties.GetSettingValue("GoogleEmail")
                TreeView1.SelectedNode.Text = title
                OfGenericBots.Items(botProperties.ProcessId).Kill(False)
                OfGenericBots.Items(botProperties.ProcessId).Start()
            End If
        End Sub
        Private Function Edit(bot As BotInformation, optional tabPage As TabPage = Nothing) As Boolean
            Dim dialog As New SettingsEditor(bot)
            If dialog.ShowDialog() = DialogResult.OK Then
                Return True
            End If
            Return False
        End Function

        Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
            Handles LinkLabel1.LinkClicked
            LinkLabel1.LinkVisited = True
            Process.Start(
                "http://www.ownedcore.com/forums/pokemon-go/pokemon-go-hacks-cheats/566095-bot-manager-auto-update-includes-multiple-bots-multi-account.html")
        End Sub

        Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            Dim botInformation = DirectCast(TreeView1.SelectedNode.Tag, BotInformation)

            OfGenericBots.Items(botInformation.ProcessId).Kill(False)
            OfGenericBots.Items(botInformation.ProcessId).Start()
        End Sub

        Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            Dim botInformation = DirectCast(TreeView1.SelectedNode.Tag, BotInformation)

            If botInformation.IsRunning Then
                OfGenericBots.Items(botInformation.ProcessId).Kill(False)
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
            For Each botProcessId As Integer In OfGenericBots.Items.Keys
                If commandLine.Contains(botProcessId.ToString())
                    Return True
                End If
            Next
            Return False
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