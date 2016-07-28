Imports System.Threading
Imports BotManager.Manager.Helpers
Imports BotManager.Manager.Properties
Imports BotManager.Windows

Namespace Manager.Type
    Public MustInherit Class Generic
        Protected BotProperties As Bot
        Protected ExecutablePath As String = ""
        Private ReadOnly _timer As New Timers.Timer(1000)
        Public MustOverride Sub WriteSettings()
        Public MustOverride Sub ReadSettings()

        Public Sub New(ByRef botProperties As Bot)
            Me.BotProperties = botProperties
            _timer.Stop()
            AddHandler _timer.Elapsed, AddressOf HandleTimer
        End Sub

        Protected Sub Initialize()
            If File.Exists(ExecutablePath) Then
                BotProperties.TempExecutablePath = IO.CopyFolder(
                    Path.GetDirectoryName(ExecutablePath)) & "\" &
                                                   Path.GetFileName(ExecutablePath)
            Else
                MsgBox("Path doesn't Exists")
                My.Settings.BotsProperties.Items.Remove(BotProperties)
                Exit Sub
            End If
        End Sub

        Public Sub Start()
            WriteSettings()
            Dim pInfo As New ProcessStartInfo
            pInfo.WorkingDirectory = Path.GetDirectoryName(botProperties.TempExecutablePath)
            pInfo.FileName = Path.GetFileName(botProperties.TempExecutablePath)

            Dim p As Process = CmdLine.Run(pInfo, False)
            If Bots.Items.ContainsKey(BotProperties.ProcessId) Then Bots.Items.Remove(BotProperties.ProcessId)


            BotProperties.ProcessId = p.Id
            BotProperties.Handle = p.MainWindowHandle
            BotProperties.IsRunning = True

            Api.SetParent(botProperties.Handle, botProperties.TabPageHandle)
            Dim tabPAge As TabPage = Control.FromHandle(botProperties.TabPageHandle)
            Api.SetWindowPos(botProperties.Handle, 1, 0, 0, tabPAge.Width,
                             tabPAge.Height, 0)
            Bots.Items.Add(botProperties.ProcessId, Me)
            _timer.Start()
        End Sub

        Public Sub Kill(Optional delete As Boolean = True)
            _timer.Stop()
            CmdLine.Kill(BotProperties)
            BotProperties.IsRunning = False

            If delete Then
                 Dim directory As String = Path.GetDirectoryName(BotProperties.TempExecutablePath)

                While Not IO.DirectoryIsEmpty(directory)
                   IO.DeleteFilesFromFolder(directory)
                End While
            End If
        End Sub
        Private Sub HandleTimer(sender As Object, e As EventArgs)
            If Not CmdLine.IsRunning(BotProperties) Then
                Start()
            End If
        End Sub
    End Class
End NameSpace