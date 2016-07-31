Imports System.Runtime.InteropServices

Namespace Windows
    Public Class Api
        <DllImport("user32.dll", SetLastError := True, CharSet := CharSet.Auto)>
        Public Shared Function SetParent(hWndChild As IntPtr, hWndNewParent As IntPtr) As IntPtr
        End Function

        <DllImport("user32.dll", SetLastError := True)>
        Public Shared Function SetWindowPos(hWnd As IntPtr, hWndInsertAfter As IntPtr, X As Integer, Y As Integer,
                                            cx As Integer, cy As Integer, uFlags As Integer) As Boolean
        End Function

        <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
        Public Shared Function ShowWindow(ByVal hwnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
        End Function

        Public Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow" () As IntPtr
        Public Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer
    End Class
End NameSpace