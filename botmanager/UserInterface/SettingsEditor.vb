Namespace UserInterface
    Public Class SettingsEditor
        Private ReadOnly _botProperties As Properties.BotInformation
        Public BatchAddProperties As List(Of Properties.BotInformation)

        Public Sub New (ByRef botProperties As Properties.BotInformation)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _botProperties = botProperties

        End Sub
        Private Sub SettingsEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim newTable As New DataTable
            newTable.Columns.Add("Name")
            newTable.Columns.Add("Value")

            For i As Integer = 0 To _botProperties.SettingKeys.Count - 1
                newTable.Rows.Add(_botProperties.SettingKeys(i),_botProperties.SettingValues(i))
            Next
        
            txtRestartTimer.Text = _botProperties.RestartTimer
            DataGridView1.DataSource = newTable
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            For row As Integer = 0 To DataGridView1.Rows.Count - 2
                _botProperties.SettingValues.Item(row) = DataGridView1.Rows(row).Cells(1).Value.ToString()
            Next

            If Not Integer.TryParse(txtRestartTimer.Text, _botProperties.RestartTimer) Then
                _botProperties.RestartTimer = 0
            End If

            If chkBatchAdd.Checked Then
                batchAddProperties = New List(Of Properties.BotInformation)
                Dim reader As New StreamReader(TextBox1.Text)
                Dim content As String() = reader.ReadToEnd().Split(vbcrlf)
                Dim newBotProperty As Properties.BotInformation


                For Each line As String In content
                    newBotProperty = New Properties.BotInformation()
                    For row As Integer = 0 To DataGridView1.Rows.Count - 2
                        newBotProperty.SettingValues.Item(row) = DataGridView1.Rows(row).Cells(1).Value.ToString()
                    Next

                    Dim settings As String() = line.Split(",")

                    For Each setting As String In settings
                        Dim field As String = setting.Split(":")(0)
                        Dim value As String = setting.Split(":")(1)

                        newBotProperty.SettingValues(newBotProperty.SettingKeys.IndexOf(field)) = value
                    Next

                    batchAddProperties.Add(newBotProperty)
                Next
            End If

            DialogResult = DialogResult.OK
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            DialogResult = DialogResult.Cancel
        End Sub
        Private Sub chkBatchAdd_CheckedChanged(sender As Object, e As EventArgs) Handles chkBatchAdd.CheckedChanged
            TextBox1.Enabled = chkBatchAdd.Checked
        End Sub
    End Class
End NameSpace