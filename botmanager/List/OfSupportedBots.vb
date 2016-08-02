Imports BotManager.Properties

Namespace List
    Public Class OfSupportedBots
       Inherits Dictionary(Of String, Properties.SupportedBotInformation)
       Private Shared _instances As OfSupportedBots

        Private Sub New()
        End Sub

        Public Shared Function GetInstance() As Dictionary(Of String, Properties.SupportedBotInformation)
            If _instances Is Nothing
                _instances = New OfSupportedBots()
                 _instances.Add("Nuget", New SupportedBotInformation() With {
                          .Name = "Nuget", 
                          .DownloadUrl = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe",
                          .WorkingDirectory = "",
                          .ExecutablePath = "Nuget.exe",
                          .ZipName = "Nuget.exe",
                          .DisplayAsBot = False,
                          .DownloadPackages = False,
                          .ReadSettings = False,
                          .UnZip = False,
                          .DeleteOld = False,
                          .Compile = False})

                    _instances.Add("Spegeli", New SupportedBotInformation() With {
                          .Name = "Spegeli", 
                          .DownloadUrl = "https://github.com/Spegeli/Pokemon-Go-Rocket-API/archive/master.zip",
                          .WorkingDirectory = "Spegeli/PokemoGoBot-GottaCatchEmAll-master",
                          .ZipName = "Spegeli.zip",
                          .UnZipDirectory = "Spegeli",
                          .ExecutablePath = "Spegeli/PokemoGoBot-GottaCatchEmAll-master/PokemonGo.RocketAPI.Console/bin/Debug/PokemonGo.RocketAPI.Console.exe",
                          .BotClass = "BotManager.Manager.Spegeli"})

                    _instances.Add("Haxton", New SupportedBotInformation() With {
                          .Name = "Haxton", 
                          .DownloadUrl = "https://github.com/d-haxton/HaxtonBot/archive/master.zip",
                          .WorkingDirectory = "Haxton/HaxtonBot-master",
                          .ZipName = "Haxton.zip",
                          .UnZipDirectory = "Haxton",
                          .ExecutablePath = "Haxton/HaxtonBot-master/PokemonGo.Haxton.Console/bin/Debug/PokemonGo.Haxton.Console.exe",
                          .BotClass = "BotManager.Manager.Haxton"})

                   _instances.Add("Necro", New SupportedBotInformation() With {
                          .Name = "Necro", 
                          .DownloadUrl = "https://github.com/NecronomiconCoding/NecroBot/archive/master.zip",
                          .WorkingDirectory = "Necro/NecroBot-master",
                          .ZipName = "Necro.zip",
                          .UnZipDirectory = "Necro",
                          .ExecutablePath = "Necro/NecroBot-master/PoGo.NecroBot.CLI/bin/Debug/NecroBot.exe",
                          .BotClass = "BotManager.Manager.Necro"})

                  _instances.Add("NecroAPI", New SupportedBotInformation() With {
                          .Name = "NecroAPI", 
                          .DownloadUrl = "https://github.com/NecronomiconCoding/NecroBot-Rocket-API/archive/master.zip",
                          .WorkingDirectory = "NecroAPI/NecroBot-Rocket-API-master",
                          .MoveTo = "Necro/NecroBot-master/FeroxRev",
                          .ZipName = "NecroAPI.zip",
                          .UnZipDirectory = "NecroAPI",
                          .DisplayAsBot = False,
                          .DownloadPackages = False,
                          .ReadSettings = False,
                          .Compile = False,
                          .MoveFolder = True})
                Return _instances
            Else 
                Return _instances
            End If
        End Function
    End Class
End NameSpace