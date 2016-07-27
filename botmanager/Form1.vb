Public Class Form1
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim runInformation As New RunInformation()
        runInformation.ExecutablePath = TextBox1.Text
        My.Settings.Bots.Items.Add(runInformation)

        StartBot(runInformation, True)
    End Sub

    Private Sub StartBot(ByRef runInformation As RunInformation, Optional isNew As Boolean = False)
        If File.Exists(runInformation.ExecutablePath) Then
            runInformation.TempExecutablePath = DirectoryHelper.CopyFolder(Path.GetDirectoryName(runInformation.ExecutablePath)) & "\" & Path.GetFileName(runInformation.ExecutablePath)
        Else 
            MsgBox("Path doesn't Exists")
            My.Settings.Bots.Items.Remove(runInformation)
            Exit Sub
        End If

        If isNew Then 
            Task.SetSettings(runInformation)
            Edit(runInformation)
        End If

        Dim newTabPage As TabPage = CreateTabPage(runInformation)
        Task.RunBot(runInformation)
        runInformation.TabPageHandle = newTabPage.Handle

        WinApi.SetParent(runInformation.Handle, runInformation.TabPageHandle)
        WinApi.SetWindowPos(runInformation.Handle, 1, 0, 0, newTabPage.Width, newTabPage.Height, 0)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If TabControl1.TabPages.Count = 0 Then Exit Sub
        Dim selectedTab As TabPage = TabControl1.SelectedTab
        Dim runInformation = DirectCast(selectedTab.Tag, runInformation)

        KillBot(runInformation)
        My.Settings.Bots.Items.Remove(runInformation)

        selectedTab.Dispose()
        TabControl1.TabPages.Remove(selectedTab)
    End Sub

    Private Function CreateTabPage(runInformation As RunInformation) As TabPage
        TabControl1.TabPages.Add(runInformation.GetSettingValue("PtcUsername"))
        Dim newTabPage As TabPage = TabControl1.TabPages(TabControl1.TabPages.Count - 1)
        newTabPage.Tag = runInformation

        Return newTabPage
    End Function

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim runInformation As RunInformation

        For Each tabPage As TabPage In TabControl1.TabPages
            runInformation = DirectCast(tabPage.Tag, RunInformation)
            WinApi.SetWindowPos(runInformation.Handle, 1, 0, 0, tabPage.Width, tabPage.Height, 0)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.Bots Is Nothing Then
            My.Settings.Bots = New Bots
        Else
            For Each runInformation As RunInformation In My.Settings.Bots.Items
                StartBot(runInformation)
            Next
        End If

        TextBox1.Text = my.Settings.Textbox
    End Sub

    Private Sub Form1_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing

        KillAllBots()
        My.Settings.Save()
    End Sub

    Private Sub KillAllBots()
        For Each runInformation As RunInformation In My.Settings.Bots.Items
            KillBot(runInformation)
        Next
    End Sub
    Private Sub KillBot(runInformation As RunInformation)
            If Not runInformation.IsRunning Then Exit Sub
            Task.StopBot(runInformation)
            Threading.Thread.Sleep(300)
            DirectoryHelper.DeleteFilesFromFolder(Path.GetDirectoryName(runInformation.TempExecutablePath))
    End Sub


    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If TabControl1.TabPages.Count = 0 Then Exit Sub

        Dim selectedTab As TabPage = TabControl1.SelectedTab
        Dim runInformation = DirectCast(selectedTab.Tag, runInformation)
        KillBot(runInformation)
        Edit(runInformation, selectedTab)
        StartBot(runInformation)
    End Sub

    Private Sub Edit(runInformation As RunInformation, optional tabPage As TabPage = Nothing)
        Dim dialog As New SettingsEditor(runInformation.SettingKeys, runInformation.SettingValues)
        If dialog.ShowDialog() = DialogResult.OK Then
            If Not tabPage Is Nothing Then
                tabPage.Dispose()
                TabControl1.TabPages.Remove(tabPage)
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
       My.Settings.Textbox = TextBox1.Text
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        OpenFileDialog.Filter = "executable|*.exe"
        If OpenFileDialog.ShowDialog() = DialogResult.OK
            TextBox1.Text = OpenFileDialog.FileName
            OpenFileDialog.InitialDirectory = path.GetDirectoryName(OpenFileDialog.FileName)
        End If
    End Sub
End Class