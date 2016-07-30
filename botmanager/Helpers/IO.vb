Imports System.IO.Compression

Namespace Manager.Helpers
    Public Class IO
        Public Shared _
            AppData As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\" &
                                "BotManager\"

        Public Shared Function CopyFolder(sourcePath As String) As String
            Dim tempFolderName As String = Path.GetRandomFileName()
            Dim tempFolderPath As String = AppData & tempFolderName
            Directory.CreateDirectory(tempFolderPath)

            'Now Create all of the directories
            For Each dirPath As String In Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories)
                Directory.CreateDirectory(dirPath.Replace(SourcePath, tempFolderPath))
            Next

            'Copy all the files & Replaces any files with the same name
            For Each newPath As String In Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories)
                File.Copy(newPath, newPath.Replace(SourcePath, tempFolderPath), True)
            Next

            Return tempFolderPath
        End Function

        Public Shared Sub DeleteFilesFromFolder(sourcePath As String)
            Try
                If Directory.Exists(sourcePath) Then
                    For Each _file As String In Directory.GetFiles(sourcePath)
                        File.Delete(_file)
                    Next
                    For Each _folder As String In Directory.GetDirectories(sourcePath)

                        DeleteFilesFromFolder(_folder)
                    Next

                End If

                Directory.Delete(sourcePath)
            Catch

            End Try
        End Sub

        Public Shared Function DirectoryIsEmpty(directory As String)
            Try
            Return System.IO.Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories).Count() = 0 AndAlso
                   System.IO.Directory.GetDirectories(directory, "*", SearchOption.AllDirectories).Count() = 0
            Catch e As DirectoryNotFoundException
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Sub Unzip(fileName As String)
            ZipFile.ExtractToDirectory(fileName & ".zip", fileName)
        End Sub
    End Class
End NameSpace