Imports System.Text

Namespace Windows
    Public Class Api
        Public Declare Function SetParent Lib "user32.dll"(hWndChild As IntPtr, hWndNewParent As IntPtr) As IntPtr
        Public Declare Function SetWindowPos Lib "user32.dll"(hWnd As IntPtr, hWndInsertAfter As IntPtr, x As Integer,
                                                              y As Integer,
                                                              cx As Integer, cy As Integer, uFlags As Integer) _
            As Boolean
        Public Declare Function ShowWindow Lib "user32.dll"(hwnd As IntPtr, nCmdShow As Integer) As Boolean
        Public Declare Function GetParent Lib "user32.dll"(hwnd As Int32) As Int32
        Public Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow"() As IntPtr
        Public Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA"(hwnd As IntPtr,
                                                                                  lpString As StringBuilder,
                                                                                  cch As Integer) As Integer
    End Class
End NameSpace