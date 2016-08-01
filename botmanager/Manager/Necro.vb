Imports BotManager.Properties

Namespace Manager
    Public Class Necro
        Inherits Generic

        Public Sub New(ByRef botInformation As BotInformation)
            MyBase.New(botInformation)
            ExecutablePath = List.OfSupportedBots.GetInstance()("Necro").ExecutablePath
        End Sub

        Public Overrides Sub WriteSettings()
            Throw New NotImplementedException()
        End Sub
    End Class
End NameSpace