Imports BotManager.Manager.Type

Namespace Manager
    Public Class BotFactory
        Public Shared Function GetBot(ByRef botProperties As Properties.BotInformation) As Manager.Type.Generic
            Select Case botProperties.BotClass
                Case "BotManager.Manager.Type.Haxton"
                    Return New Manager.Type.Haxton(botProperties)
                Case "BotManager.Manager.Type.Spegeli"
                    Return New Manager.Type.Spegeli(botProperties)
            End Select

            Throw New Exception("Uknown Bot Class!")
        End Function
    End Class
End NameSpace