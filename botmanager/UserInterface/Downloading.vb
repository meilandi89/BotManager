Imports BotManager.Manager.Helpers
Imports BotManager.Windows

Public Class Downloading
    Private Sub Downloading_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        BackgroundWorker1.RunWorkerAsync()
    End Sub
        Private Sub InstallNuget()
            BackgroundWorker1.ReportProgress(10,  "Downloading Nuget.exe")
            If Not File.Exists("nuget.exe") Then
                Http.DownloadRepository("https://dist.nuget.org/win-x86-commandline/latest/nuget.exe", "nuget.exe")
            End If
        End Sub

         Private Sub InstallSpegeli()
            BackgroundWorker1.ReportProgress(20,  "Deleting Old Spegeli")
            IO.DeleteFilesFromFolder("Spegeli")
            BackgroundWorker1.ReportProgress(30,  "Downloading New Spegeli")
            Http.DownloadRepository("https://github.com/Spegeli/Pokemon-Go-Rocket-API/archive/master.zip", "Spegeli.zip")
            BackgroundWorker1.ReportProgress(40,  "UnZipping New Spegeli")
            IO.Unzip("Spegeli")

            BackgroundWorker1.ReportProgress(50,  "Compiling New Spegeli")
            Dim pInfo As New ProcessStartInfo
            Dim pInfo1 As New ProcessStartInfo
            pInfo1.WorkingDirectory = "Spegeli/PokemoGoBot-GottaCatchEmAll-master"
            pInfo1.FileName = """C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"""
            pinfo1.WindowStyle = ProcessWindowStyle.Hidden
            pinfo.WindowStyle = ProcessWindowStyle.Hidden

            pInfo.FileName = "nuget.exe"
            pInfo.Arguments = "restore " & "Spegeli/PokemoGoBot-GottaCatchEmAll-master"
            CmdLine.Run(pInfo, True)
            CmdLine.Run(pInfo1, True)
        End Sub

        Private Sub InstallHaxton()
            BackgroundWorker1.ReportProgress(60,  "Deleting Old Haxton")
            IO.DeleteFilesFromFolder("Haxton")
            BackgroundWorker1.ReportProgress(70,  "Downloading New Haxton")
            Http.DownloadRepository("https://github.com/d-haxton/HaxtonBot/archive/master.zip", "Haxton.zip")
            BackgroundWorker1.ReportProgress(80,  "UnZipping New Haxton")
            IO.Unzip("Haxton")

            BackgroundWorker1.ReportProgress(90,  "Compiling New Haxton")
            Dim pInfo As New ProcessStartInfo
            Dim pInfo1 As New ProcessStartInfo
            pInfo1.WorkingDirectory = "Haxton/HaxtonBot-master"
            pInfo1.FileName = """C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"""
            pinfo1.WindowStyle = ProcessWindowStyle.Hidden
            pinfo.WindowStyle = ProcessWindowStyle.Hidden
            pInfo.FileName = "nuget.exe"
            pInfo.Arguments = "restore " & "Haxton/HaxtonBot-master"

            CmdLine.Run(pInfo, True)
            CmdLine.Run(pInfo1, True)
        End Sub
     Private Sub BackgroundWorker1_ReportProgress(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Label1.Text = e.UserState.ToString()
     End Sub
     Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DialogResult = DialogResult.OK
     End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        InstallNuget()
        InstallSpegeli()
        InstallHaxton()
        BackgroundWorker1.ReportProgress(100,  "Complete")
        Threading.Thread.Sleep(1000)
    End Sub

    Private Sub Downloading_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class