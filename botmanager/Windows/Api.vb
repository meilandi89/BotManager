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

        <DllImport("user32.dll")>
        Public Shared Function MoveWindow(hWnd As IntPtr, x As Integer, y As Integer, nWidth As Integer,
                                          nHeight As Integer, bRepaint As Boolean) As Boolean
        End Function
    End Class
End NameSpace