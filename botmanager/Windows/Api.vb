Imports System.Runtime.InteropServices
Imports System.Text

Namespace Windows
    Public Class Api
        Public Declare Function SetParent Lib "user32.dll" Alias "SetParent"(hWndChild As IntPtr,
                                                                             hWndNewParent As IntPtr) As IntPtr
        Public Declare Function SetWindowPos Lib "user32.dll" Alias "SetWindowPos"(hWnd As IntPtr,
                                                                                   hWndInsertAfter As IntPtr,
                                                                                   x As Integer,
                                                                                   y As Integer,
                                                                                   cx As Integer, cy As Integer,
                                                                                   uFlags As Integer) _
            As Boolean
        Public Declare Function ShowWindow Lib "user32.dll" Alias "ShowWindow"(hwnd As IntPtr, nCmdShow As Integer) _
            As Boolean

        <DllImport("user32.dll", ExactSpelling := True, CharSet := CharSet.Auto)>
        Public Shared Function GetParent(hWnd As IntPtr) As IntPtr
        End Function

        Public Declare Function GetActiveWindow Lib "user32.dll" Alias "GetActiveWindow"() As IntPtr
        Public Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA"(hwnd As IntPtr,
                                                                                      lpString As StringBuilder,
                                                                                      cch As Integer) As Integer

        Public Declare Auto Function SendMessage Lib "user32.dll"(hWnd As IntPtr, msg As Integer, wParam As IntPtr,
                                                                  lParam As IntPtr) As IntPtr
        Public Declare Function PostMessage Lib "user32.dll" Alias "PostMessage"(hWnd As IntPtr, msg As UInteger,
                                                                                 wParam As IntPtr, lParam As IntPtr) _
            As IntPtr

        <DllImport("User32.dll")>
        Private Shared Function EnumChildWindows _
            (WindowHandle As IntPtr, Callback As EnumWindowProcess,
             lParam As IntPtr) As Boolean
        End Function

        Public Delegate Function EnumWindowProcess(Handle As IntPtr, Parameter As IntPtr) As Boolean

        Public Shared Function GetChildWindows(ParentHandle As IntPtr) As IntPtr()
            Dim ChildrenList As New List(Of IntPtr)
            Dim ListHandle As GCHandle = GCHandle.Alloc(ChildrenList)
            Try
                EnumChildWindows(ParentHandle, AddressOf EnumWindow, GCHandle.ToIntPtr(ListHandle))
            Finally
                If ListHandle.IsAllocated Then ListHandle.Free()
            End Try
            Return ChildrenList.ToArray
        End Function

        Private Shared Function EnumWindow(Handle As IntPtr, Parameter As IntPtr) As Boolean
            Dim ChildrenList As List(Of IntPtr) = GCHandle.FromIntPtr(Parameter).Target
            If ChildrenList Is Nothing Then Throw New Exception("GCHandle Target could not be cast as List(Of IntPtr)")
            ChildrenList.Add(Handle)
            Return True
        End Function
    End Class
End NameSpace