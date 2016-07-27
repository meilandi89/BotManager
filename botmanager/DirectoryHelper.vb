Imports System.IO
Public Class DirectoryHelper
    Public Shared AppData As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\" & "BotManager\"

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
        If Directory.Exists(sourcePath) Then
            For Each _file As String In Directory.GetFiles(sourcePath)
                File.Delete(_file)
            Next
            For Each _folder As String In Directory.GetDirectories(sourcePath)

                DeleteFilesFromFolder(_folder)
            Next

        End If

        Directory.Delete(sourcePath)
    End Sub
End Class
