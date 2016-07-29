Imports BotManager.Manager.Properties

Namespace Manager.Type
    Public Class Maclone
        Inherits Generic
                Public Sub New(ByRef botProperties As Bot)
            MyBase.New(botProperties)
            ReadSettings()
        End Sub
        Public Overrides Sub ReadSettings()
            Throw New NotImplementedException()
        End Sub

        Public Overrides Sub WriteSettings()
            Throw New NotImplementedException()
        End Sub
    End Class
End NameSpace