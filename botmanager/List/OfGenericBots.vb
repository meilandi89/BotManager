Namespace List
    Public Class OfGenericBots
        Inherits Dictionary(Of Integer, Manager.Generic)
            Private Shared _instances As OfGenericBots

        Private Sub New()
        End Sub

        Public Shared Function GetInstance() As OfGenericBots
            If _instances Is Nothing
                _instances = New OfGenericBots()
                 
                Return _instances
            Else 
                Return _instances
            End If
        End Function
    End Class
End NameSpace