Imports System.Timers
Imports BotManager.Helpers
Imports BotManager.Properties
Imports BotManager.Windows

Namespace Manager
    Public MustInherit Class Generic
        Implements IDisposable
        Public IsRunning As Boolean = False
        Public IsSelected As Boolean = False
        Public Shared PanelHandle As Integer
        Private _processId As Integer

        Public ReadOnly Property ProcessId As Integer
            Get
                Return _processId
            End Get
        End Property

        Private _handle As IntPtr = 0

        Public ReadOnly Property Handle As IntPtr
            Get
                Return _handle
            End Get
        End Property

        Public BotInformation As BotInformation

        Protected ExecutablePath As String = ""
        Private _p As Process
        Private ReadOnly _timer As New Timer(500)
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
            pInfo.WindowStyle = ProcessWindowStyle.Maximized
            Dim p As Process = CmdLine.Run(pInfo, False)

            _p = Nothing
            _p = p

            UpdateBotInformation()
            PutConsoleInPanel()
            Api.SendMessage(_p.MainWindowHandle, &H100, 13, 0)
            _timer.Start()
        End Sub

        Private Sub UpdateBotInformation()
            _processId = _p.Id
            _handle = _p.MainWindowHandle
            IsRunning = True
        End Sub

        Public Sub PutConsoleInPanel()
            Api.SetParent(_handle, PanelHandle)

            If IsSelected Then
                Api.ShowWindow(Handle, 5)
                Api.SetWindowPos(Handle, 1, 0, 0, Control.FromHandle(PanelHandle).Width,
                                 Control.FromHandle(PanelHandle).Height, 0)
            Else
                Api.ShowWindow(_p.MainWindowHandle, 0)
            End If
        End Sub

        Public Sub Kill(Optional delete As Boolean = True)
            If IsRunning Then
                _timer.Stop()
                If Not _p.HasExited Then
                    _p.Kill()
                End If
                _startTime = Nothing
                IsRunning = False
            End If

            If delete Then
                Dim directory As String = Path.GetDirectoryName(BotInformation.TempExecutablePath)

                While Not IO.DirectoryIsEmpty(directory)
                    IO.DeleteFilesFromFolder(directory)
                End While
            End If
        End Sub

        Private Sub HandleTimer(sender As Object, e As EventArgs)
            If _p.HasExited Then
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

        Public Sub Dispose() Implements IDisposable.Dispose
            If IsRunning Then Kill(True)
            IsRunning = Nothing
            IsSelected = Nothing
            _handle = Nothing
            ExecutablePath = Nothing
            _p.Dispose()
            _timer.Dispose()
            _startTime = Nothing
        End Sub
    End Class
End NameSpace