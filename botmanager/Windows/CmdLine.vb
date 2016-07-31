Imports System.Threading
Imports System.Management
Imports BotManager.Properties

Namespace Windows
    Public Class CmdLine
        Public Shared Function Run(ByRef pInfo As ProcessStartInfo, waitForExit As Boolean) As Process
            Dim p As Process = Process.Start(pInfo)

            If waitForExit Then
                While Not p.HasExited
                    Thread.Sleep(200)
                End While
            End If
            
            Thread.Sleep(350)

            Return p
        End Function

        Public Shared Sub Kill(ByRef botProperties As BotInformation)
            Try
                Dim p As Process = Process.GetProcessById(botProperties.ProcessId)
                p.Kill()
                botProperties.IsRunning = False
            Catch
            End Try
        End Sub

        Public Shared Function IsRunning(ByRef botProperties As BotInformation) As Boolean
            Try
                Dim p As Process = Process.GetProcessById(botProperties.ProcessId)
                If Not p.Responding Then
                    Kill(botProperties)
                    Return False
                End If
                Return True
            Catch
                Return False
            End Try
        End Function
    End Class
End NameSpace