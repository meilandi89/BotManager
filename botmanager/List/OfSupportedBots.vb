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
                    _instances.Add("Spegeli", New SupportedBotInformation() With {
                          .Name = "Spegeli", 
                          .DownloadUrl = "https://github.com/Spegeli/Pokemon-Go-Rocket-API/archive/master.zip",
                          .WorkingDirectory = "Spegeli/PokemoGoBot-GottaCatchEmAll-master",
                          .ZipName = "Spegeli.zip",
                          .ExecutablePath = "Spegeli/PokemoGoBot-GottaCatchEmAll-master/PokemonGo.RocketAPI.Console/bin/Debug/PokemonGo.RocketAPI.Console.exe"})

                    _instances.Add("Haxton", New SupportedBotInformation() With {
                          .Name = "Haxton", 
                          .DownloadUrl = "https://github.com/d-haxton/HaxtonBot/archive/master.zip",
                          .WorkingDirectory = "Haxton/HaxtonBot-master",
                          .ZipName = "Haxton.zip",
                          .ExecutablePath = "Haxton/HaxtonBot-master/PokemonGo.Haxton.Console/bin/Debug/PokemonGo.Haxton.Console.exe"})
                Return _instances
            Else 
                Return _instances
            End If
        End Function
    End Class
End NameSpace