Imports BotManager.Properties

Namespace List
    Public Class OfSupportedBots
       Inherits List(Of Properties.SupportedBotInformation)
       Private Shared _instances As OfSupportedBots

        Private Sub New()
        End Sub

        Public Shared Function GetInstance() As List(Of Properties.SupportedBotInformation)
            If _instances Is Nothing
                _instances = New OfSupportedBots()
                    _instances.Add(New SupportedBotInformation() With {
                          .Name = "Spegeli", 
                          .DownloadUrl = "https://github.com/Spegeli/Pokemon-Go-Rocket-API/archive/master.zip",
                          .WorkingDirectory = "Spegeli/PokemoGoBot-GottaCatchEmAll-master",
                          .ZipName = "Spegeli.zip"})

                    _instances.Add(New SupportedBotInformation() With {
                          .Name = "Haxton", 
                          .DownloadUrl = "https://github.com/d-haxton/HaxtonBot/archive/master.zip",
                          .WorkingDirectory = "Haxton/HaxtonBot-master",
                          .ZipName = "Haxton.zip"})
                Return _instances
            Else 
                Return _instances
            End If
        End Function
    End Class
End NameSpace