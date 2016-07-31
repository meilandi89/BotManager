Imports System.ComponentModel
Imports System.Timers
Imports BotManager.Helpers
Imports BotManager.List
Imports BotManager.Properties
Imports BotManager.Windows

Namespace Manager
    Public MustInherit Class Generic
        Protected BotInformation As BotInformation
        Protected ExecutablePath As String = ""
        Private ReadOnly _timer As New Timer(1000)
        Private _startTime As Date = Nothing
        Public MustOverride Sub WriteSettings()

        Public Sub New(ByRef botInformation As BotInformation)
            Me.botInformation = botInformation
            _timer.Stop()
            AddHandler _timer.Elapsed, AddressOf HandleTimer
        End Sub

        Protected Function Initialize() As Boolean
            If File.Exists(ExecutablePath) Then
                botInformation.TempExecutablePath = IO.CopyFolder(
                    Path.GetDirectoryName(ExecutablePath)) & "\" &
                                                    Path.GetFileName(ExecutablePath)
                Return True
            Else
                MsgBox("Path doesn't Exists")
                My.Settings.ListOfPropertiesBots.Items.Remove(botInformation)
                Return False
            End If
        End Function
        Public Sub Start()
                        WriteSettings()

            Dim pInfo As New ProcessStartInfo
            pInfo.WorkingDirectory = Path.GetDirectoryName(botInformation.TempExecutablePath)
            pInfo.FileName = Path.GetFileName(botInformation.TempExecutablePath)
            If BotInformation.Hide Then pInfo.WindowStyle = ProcessWindowStyle.Hidden
            Dim p As Process = CmdLine.Run(pInfo, False)
            If OfGenericBots.Items.ContainsKey(botInformation.ProcessId) Then OfGenericBots.Items.Remove(botInformation.ProcessId)


            botInformation.ProcessId = p.Id
            botInformation.Handle = p.MainWindowHandle
            botInformation.IsRunning = True

            Api.ShowWindow(p.MainWindowHandle, 0)
            Api.SetParent(botInformation.Handle, botInformation.PanelHandle)

            If botInformation.IsSelected Then
                Api.ShowWindow(botInformation.Handle, 5)
                Api.SetWindowPos(botInformation.Handle, 1, 0, 0, Control.FromHandle(botInformation.PanelHandle).Width,
                                 Control.FromHandle(botInformation.PanelHandle).Height, 0)
            End If

            OfGenericBots.Items.Add(botInformation.ProcessId, Me)
            _timer.Start()
        End Sub

        Public Sub Kill(Optional delete As Boolean = True)
                        _timer.Stop()
            CmdLine.Kill(botInformation)
            _startTime = Nothing
            botInformation.IsRunning = False
 '           If OfGenericBots.Items.ContainsKey(botInformation.ProcessId) Then OfGenericBots.Items.Remove(botInformation.ProcessId)

            If delete Then
                Dim directory As String = Path.GetDirectoryName(botInformation.TempExecutablePath)

                While Not IO.DirectoryIsEmpty(directory)
                    IO.DeleteFilesFromFolder(directory)
                End While
            End If
        End Sub

        Private Sub HandleTimer(sender As Object, e As EventArgs)
            If Not CmdLine.IsRunning(botInformation) Then
                Start()
            End If

            If botInformation.RestartTimer > 0 Then
                If _startTime = Nothing Then
                    _startTime = Now()
                End If

                If Now() >= _startTime.AddMinutes(botInformation.RestartTimer)
                    Kill(False)
                    Start()
                    _startTime = Now()
                End If
            End If
        End Sub
    End Class
End NameSpace