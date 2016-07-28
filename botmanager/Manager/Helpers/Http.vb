Imports System.Net

Namespace Manager.Helpers

    Public Class Http
        Public Shared Sub DownloadRepository(fileUrl As String, fileName As String)
            Dim saveAs as string = fileName
            Dim theResponse As HttpWebResponse
            Dim theRequest As HttpWebRequest
            Try 'Checks if the file exist
                theRequest = WebRequest.Create(fileUrl) 'fileUrl is your zip url
                theResponse = theRequest.GetResponse
            Catch ex As Exception
                'could not be found on the server (network delay maybe)
                Exit sub 'Exit sub or function, because if not found can't be downloaded
            End Try
            Dim length As Long = theResponse.ContentLength
            Dim writeStream As New System.IO.FileStream(saveAs, System.IO.FileMode.Create)
            Dim nRead As Integer
            Do
                Dim readBytes(4095) As Byte
                Dim bytesread As Integer = theResponse.GetResponseStream.Read(readBytes, 0, 4096)
                nRead += bytesread
                If bytesread = 0 Then Exit Do
                writeStream.Write(readBytes, 0, bytesread)
            Loop
            theResponse.GetResponseStream.Close()
            writeStream.Close()
            'File downloaded 100%
        End Sub
    End Class
End NameSpace