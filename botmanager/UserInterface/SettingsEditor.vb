Namespace UserInterface
    Public Class SettingsEditor
        Private ReadOnly _settingKeys As List(Of String)
        Private ReadOnly _settingValues As List(Of String)

        Public Sub New (ByRef settingKeys As List(Of String), ByRef settingValues As List(Of String))

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _settingKeys = settingKeys
            _settingValues = settingValues

        End Sub
        Private Sub SettingsEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim newTable As New DataTable
            newTable.Columns.Add("Name")
            newTable.Columns.Add("Value")

            For i As Integer = 0 To _settingKeys.Count - 1
                newTable.Rows.Add(_settingKeys(i),_settingValues(i))
            Next
        

            DataGridView1.DataSource = newTable
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            For row As Integer = 0 To DataGridView1.Rows.Count - 2
                _settingValues.Item(row) = DataGridView1.Rows(row).Cells(1).Value.ToString()
            Next

            DialogResult = DialogResult.OK
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            DialogResult = DialogResult.Cancel
        End Sub
    End Class
End NameSpace