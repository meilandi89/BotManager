﻿Imports System.Timers
Imports BotManager.Manager.Helpers
Imports BotManager.Properties
Imports BotManager.Windows

Namespace Manager.Type
    Public MustInherit Class Generic
        Protected BotProperties As BotInformation
        Protected ExecutablePath As String = ""
        Private ReadOnly _timer As New Timer(1000)
        Private _startTime As Date = Nothing
        Public MustOverride Sub WriteSettings()
        Public MustOverride Sub ReadSettings()

        Public Sub New(ByRef botProperties As BotInformation)
            Me.BotProperties = botProperties
            _timer.Stop()
            AddHandler _timer.Elapsed, AddressOf HandleTimer
        End Sub

        Protected Function Initialize() As Boolean
            If File.Exists(ExecutablePath) Then
                BotProperties.TempExecutablePath = IO.CopyFolder(
                    Path.GetDirectoryName(ExecutablePath)) & "\" &
                                                   Path.GetFileName(ExecutablePath)
                Return True
            Else
                MsgBox("Path doesn't Exists")
                My.Settings.ListOfPropertiesBots.Items.Remove(BotProperties)
                Return False
            End If
        End Function

        Public Sub Start()


            WriteSettings()

            Dim pInfo As New ProcessStartInfo
            pInfo.WorkingDirectory = Path.GetDirectoryName(botProperties.TempExecutablePath)
            pInfo.FileName = Path.GetFileName(botProperties.TempExecutablePath)

            Dim p As Process = CmdLine.Run(pInfo, False)
            'If ListOfGenericBots.Items.ContainsKey(BotProperties.ProcessId) Then ListOfGenericBots.Items.Remove(BotProperties.ProcessId)


            BotProperties.ProcessId = p.Id
            BotProperties.Handle = p.MainWindowHandle
            BotProperties.IsRunning = True

            Api.SetParent(botProperties.Handle, botProperties.TabPageHandle)
            Dim tabPAge As TabPage = Control.FromHandle(botProperties.TabPageHandle)
            Api.SetWindowPos(botProperties.Handle, 1, 0, 0, tabPAge.Width,
                             tabPAge.Height, 0)
            List.OfGenericBots.Items.Add(botProperties.ProcessId, Me)
            _timer.Start()
        End Sub

        Public Sub Kill(Optional delete As Boolean = True)
            _timer.Stop()
            CmdLine.Kill(BotProperties)
            _startTime = Nothing
            BotProperties.IsRunning = False
            'If ListOfGenericBots.Items.ContainsKey(BotProperties.ProcessId) Then ListOfGenericBots.Items.Remove(BotProperties.ProcessId)

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

            If BotProperties.RestartTimer > 0 Then
                If _startTime = Nothing Then
                    _startTime = Now()
                End If

                If Now() >= _startTime.AddMinutes(BotProperties.RestartTimer)
                    Kill(False)
                    Start()
                    _startTime = Now()
                End If
            End If
        End Sub
    End Class
End NameSpace