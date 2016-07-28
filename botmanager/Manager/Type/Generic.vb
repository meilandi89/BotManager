Imports System.Threading
Imports BotManager.Manager.Helpers
Imports BotManager.Manager.Properties
Imports BotManager.Windows

Namespace Manager.Type
    Public MustInherit Class Generic
        Protected BotProperties As Bot
        Private ReadOnly _timer As New Timers.Timer(1000)
        Public MustOverride Sub WriteSettings()
        Public MustOverride Sub ReadSettings()

        Public Sub New(ByRef botProperties As Bot)
            Me.BotProperties = botProperties
            Initialize()
            _timer.Stop()
            AddHandler _timer.Elapsed, AddressOf HandleTimer
        End Sub

        Private Sub Initialize()
            If File.Exists(BotProperties.ExecutablePath) Then
                BotProperties.TempExecutablePath = IO.CopyFolder(
                    Path.GetDirectoryName(BotProperties.ExecutablePath)) & "\" &
                                                   Path.GetFileName(BotProperties.ExecutablePath)
            Else
                MsgBox("Path doesn't Exists")
                My.Settings.BotsProperties.Items.Remove(BotProperties)
                Exit Sub
            End If
        End Sub

        Public Sub Start()
            WriteSettings()
            Dim p As Process = CmdLine.Run(BotProperties)
            If Bots.Items.ContainsKey(BotProperties.ProcessId) Then Bots.Items.Remove(BotProperties.ProcessId)

            BotProperties.ProcessId = p.Id
            BotProperties.Handle = p.MainWindowHandle
            BotProperties.IsRunning = True

            Api.SetParent(botProperties.Handle, botProperties.TabPageHandle)
            Api.SetWindowPos(botProperties.Handle, 1, 0, 0, Control.FromHandle(botProperties.TabPageHandle).Width,
                             Control.FromHandle(botProperties.TabPageHandle).Height, 0)
            Bots.Items.Add(botProperties.ProcessId, Me)
            _timer.Start()
        End Sub

        Public Sub Kill()
            _timer.Stop()
            CmdLine.Kill(BotProperties)
            BotProperties.IsRunning = False
            If Bots.Items.ContainsKey(BotProperties.ProcessId) Then Bots.Items.Remove(BotProperties.ProcessId)

            Dim directory As String = Path.GetDirectoryName(BotProperties.TempExecutablePath)

            While Not IO.DirectoryIsEmpty(directory)
                IO.DeleteFilesFromFolder(directory)
            End While
        End Sub
        Private Sub HandleTimer(sender As Object, e As EventArgs)
            If Not CmdLine.IsRunning(BotProperties) Then
                Start()
            End If
        End Sub
    End Class
End NameSpace