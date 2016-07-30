Imports BotManager.Properties

Namespace Manager.Type
    Public Class Maclone
        Inherits Generic
                Public Sub New(ByRef botInformation As BotInformation)
            MyBase.New(botInformation)
        End Sub
        Public Overrides Sub WriteSettings()
            Throw New NotImplementedException()
        End Sub
    End Class
End NameSpace