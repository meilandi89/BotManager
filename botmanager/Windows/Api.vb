Imports System.Text

Namespace Windows
    Public Class Api
        Public Declare Function SetParent Lib "user32.dll" Alias "SetParent"(hWndChild As IntPtr, hWndNewParent As IntPtr) As IntPtr
        Public Declare Function SetWindowPos Lib "user32.dll" Alias "SetWindowPos" (hWnd As IntPtr, hWndInsertAfter As IntPtr, x As Integer,
                                                              y As Integer,
                                                              cx As Integer, cy As Integer, uFlags As Integer) _
            As Boolean
        Public Declare Function ShowWindow Lib "user32.dll" Alias "ShowWindow"(hwnd As IntPtr, nCmdShow As Integer) As Boolean
        Public Declare Function GetParent Lib "user32.dll" Alias "GetParent"(hwnd As Int32) As Int32
        Public Declare Function GetActiveWindow Lib "user32.dll" Alias "GetActiveWindow"() As IntPtr
        Public Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA"(hwnd As IntPtr,
                                                                                  lpString As StringBuilder,
                                                                                  cch As Integer) As Integer

		Public Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
		Public Declare Function PostMessage Lib "user32.dll" Alias "PostMessage" (hWnd As IntPtr, msg As UInteger, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Class
End NameSpace