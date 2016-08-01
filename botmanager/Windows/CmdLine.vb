Imports System.Runtime.InteropServices
Imports System.Threading
Imports BotManager.Properties

Namespace Windows
    Public Class CmdLine
        Public Shared Function Run(ByRef pInfo As ProcessStartInfo, waitForExit As Boolean) As Process
            If Not waitForExit Then
                Dim pId = StartProcessNoActivate(pInfo)
                Thread.Sleep(300)
                Return Process.GetProcessById(pId)
            End If

            Dim p As Process = Process.Start(pInfo)
            If waitForExit Then
                While Not p.HasExited
                    Thread.Sleep(200)
                End While
                Thread.Sleep(300)
            End If

            Return p
        End Function

        <DllImport("kernel32.dll")>
        Private Shared Function CreateProcess(lpApplicationName As String, lpCommandLine As String,
                                              lpProcessAttributes As IntPtr, lpThreadAttributes As IntPtr,
                                              bInheritHandles As Boolean, dwCreationFlags As UInteger,
                                              lpEnvironment As IntPtr, lpCurrentDirectory As String,
                                              <[In]> ByRef lpStartupInfo As STARTUPINFO,
                                              ByRef lpProcessInformation As PROCESS_INFORMATION) As Boolean
        End Function

        <DllImport("kernel32.dll", SetLastError := True)>
        Private Shared Function CloseHandle(hObject As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        Const STARTF_USESHOWWINDOW As Integer = 1
        Const SW_SHOWNOACTIVATE As Integer = 4
        Const SW_SHOWMINNOACTIVE As Integer = 7


        Public Shared Function StartProcessNoActivate(pInfo As ProcessStartInfo) As Integer
            Dim si As New STARTUPINFO()
            si.cb = Marshal.SizeOf(si)
            si.dwFlags = STARTF_USESHOWWINDOW
            si.wShowWindow = SW_SHOWMINNOACTIVE

            Dim pi As New PROCESS_INFORMATION()

            CreateProcess(Nothing, pInfo.WorkingDirectory & "\" & pInfo.FileName, IntPtr.Zero, IntPtr.Zero, True, 0,
                          IntPtr.Zero, pInfo.WorkingDirectory, si, pi)
            CloseHandle(pi.hProcess)
            CloseHandle(pi.hThread)

            Return  pi.dwProcessId
        End Function

        <StructLayout(LayoutKind.Sequential, CharSet := CharSet.Unicode)>
        Structure STARTUPINFO
            Public cb As Integer
            Public lpReserved As String
            Public lpDesktop As String
            Public lpTitle As String
            Public dwX As Integer
            Public dwY As Integer
            Public dwXSize As Integer
            Public dwYSize As Integer
            Public dwXCountChars As Integer
            Public dwYCountChars As Integer
            Public dwFillAttribute As Integer
            Public dwFlags As Integer
            Public wShowWindow As Short
            Public cbReserved2 As Short
            Public lpReserved2 As Integer
            Public hStdInput As Integer
            Public hStdOutput As Integer
            Public hStdError As Integer
        End Structure

        Structure PROCESS_INFORMATION
            Public hProcess As IntPtr
            Public hThread As IntPtr
            Public dwProcessId As Integer
            Public dwThreadId As Integer
        End Structure
    End Class
End NameSpace