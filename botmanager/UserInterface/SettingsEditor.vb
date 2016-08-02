Imports BotManager.Interfaces
Imports BotManager.List
Imports BotManager.Properties

Namespace UserInterface
    Public Class SettingsEditor
        Private ReadOnly _botProperties As BotInformation
        Public BatchAddProperties As List(Of BotInformation)

        Public Sub New(ByRef botProperties As BotInformation)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _botProperties = botProperties
        End Sub

        Private Sub SettingsEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If _botProperties.SettingValues.Count > 0 Then
                AddToGridView(_botProperties)
            Else
                Select Case _botProperties.BotClass
                    Case "BotManager.Manager.Haxton"
                        AddToGridView(OfSupportedBots.GetInstance()("Haxton"))
                    Case "BotManager.Manager.Spegeli"
                        AddToGridView(OfSupportedBots.GetInstance()("Spegeli"))
                    Case "BotManager.Manager.Necro"
                        AddToGridView(OfSupportedBots.GetInstance()("Necro"))
                End Select
            End If
        End Sub

        Private Sub AddToGridView(supportedBotInformation As ISettings)
            Dim newTable As New DataTable
            newTable.Columns.Add("Name")
            newTable.Columns.Add("Value")
            For i = 0 To supportedBotInformation.SettingKeys.Count - 1
                newTable.Rows.Add(supportedBotInformation.SettingKeys(i), supportedBotInformation.SettingValues(i))
                _botProperties.AddKeyValue(supportedBotInformation.SettingKeys(i),
                                           supportedBotInformation.SettingValues(i))
            Next

            txtRestartTimer.Text = _botProperties.RestartTimer
            chkHide.Checked = _botProperties.Hide
            DataGridView1.DataSource = newTable
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            BatchAddProperties = New List(Of BotInformation)

            For row = 0 To DataGridView1.Rows.Count - 2
                _botProperties.SettingValues.Item(row) = DataGridView1.Rows(row).Cells(1).Value.ToString()
            Next

            If Not Integer.TryParse(txtRestartTimer.Text, _botProperties.RestartTimer) Then
                _botProperties.RestartTimer = 0
            End If
            _botProperties.Hide = chkHide.Checked
            If chkBatchAdd.Checked Then
                Dim currentLineIndex As String = ""
                Dim currentLine As String = 0
                Dim currentField As String = ""
                Try
                    Dim reader As New StreamReader(fileLoc.Text)
                    Dim content = reader.ReadToEnd().Trim().Split(vbCrLf)
                    reader.Dispose()
                    Dim newBotProperty As BotInformation


                    For j As Integer = 0 To content.Length - 1
                        currentLine = content(j)
                        currentLineIndex = j
                        newBotProperty = New BotInformation()
                        newBotProperty.Hide = _botProperties.Hide
                        newBotProperty.RestartTimer = _botProperties.RestartTimer
                        newBotProperty.BotClass = _botProperties.BotClass
                        For i = 0 To _botProperties.SettingKeys.Count - 1
                            newBotProperty.AddKeyValue(_botProperties.SettingKeys(i), _botProperties.SettingValues(i))
                        Next

                        Dim settings As String() = currentLine.Trim(vbLf).Split(",")
                        If settings.Length = 0 Then Continue For
                        For Each setting As String In settings
                            Dim field As String = setting.Split(":")(0)
                            Dim value As String = setting.Split(":")(1)
                            If field = "" OrElse value = "" Then Continue For

                            currentField = field
                            Dim indexOf As Integer = newBotProperty.SettingKeys.IndexOf(field)
                            newBotProperty.SettingValues(indexOf) = value
                        Next

                        BatchAddProperties.Add(newBotProperty)
                    Next
                Catch ex As Exception
                    MsgBox(ex.Message & vbCrLf & vbCrLf &
                           "Line Index: " & currentLineIndex & vbCrLf &
                           "Field: " & currentField)
                    Exit Sub
                End Try
            Else
                BatchAddProperties.Add(_botProperties)
            End If

            DialogResult = DialogResult.OK
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            DialogResult = DialogResult.Cancel
        End Sub

        Private Sub chkBatchAdd_CheckedChanged(sender As Object, e As EventArgs) Handles chkBatchAdd.CheckedChanged
            browseBtn.Enabled = chkBatchAdd.Checked
            fileLoc.Enabled = chkBatchAdd.Checked
        End Sub

        Private Sub browseBtn_Click(sender As Object, e As EventArgs) Handles browseBtn.Click
            Using LD As New OpenFileDialog()
                LD.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
                If LD.ShowDialog = DialogResult.OK Then
                    fileLoc.Text = LD.FileName
                End If
            End Using
        End Sub
    End Class
End NameSpace