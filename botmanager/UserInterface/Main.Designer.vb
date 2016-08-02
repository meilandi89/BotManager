﻿Namespace UserInterface
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Main
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.botSelectBox = New System.Windows.Forms.ComboBox()
        Me.btnRestart = New System.Windows.Forms.Button()
        Me.repLabel = New System.Windows.Forms.LinkLabel()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.botTree = New System.Windows.Forms.TreeView()
        Me.botPanel = New System.Windows.Forms.Panel()
        Me.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.botsContainer = New System.Windows.Forms.SplitContainer()
        Me.btnStopAll = New System.Windows.Forms.Button()
        Me.btnRestartAll = New System.Windows.Forms.Button()
        Me.selectedOptionsGroup = New System.Windows.Forms.GroupBox()
        Me.batchOptionsGroup = New System.Windows.Forms.GroupBox()
        Me.btnStartAll = New System.Windows.Forms.Button()
        Me.donationGroup = New System.Windows.Forms.GroupBox()
        Me.paypalLabel = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.showPokemon = New System.Windows.Forms.CheckBox()
        Me.showExp = New System.Windows.Forms.CheckBox()
        Me.showLvl = New System.Windows.Forms.CheckBox()
        Me.batchStarter = New System.ComponentModel.BackgroundWorker()
        Me.batchKiller = New System.ComponentModel.BackgroundWorker()
        CType(Me.botsContainer,System.ComponentModel.ISupportInitialize).BeginInit
        Me.botsContainer.Panel1.SuspendLayout
        Me.botsContainer.Panel2.SuspendLayout
        Me.botsContainer.SuspendLayout
        Me.selectedOptionsGroup.SuspendLayout
        Me.batchOptionsGroup.SuspendLayout
        Me.donationGroup.SuspendLayout
        Me.GroupBox1.SuspendLayout
        Me.StatusStrip1.SuspendLayout
        Me.GroupBox2.SuspendLayout
        Me.SuspendLayout
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(148, 19)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(65, 25)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = true
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(219, 19)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(65, 25)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = true
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(6, 19)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(65, 25)
        Me.btnEdit.TabIndex = 7
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = true
        '
        'botSelectBox
        '
        Me.botSelectBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.botSelectBox.DisplayMember = "1"
        Me.botSelectBox.FormattingEnabled = true
        Me.botSelectBox.Location = New System.Drawing.Point(6, 22)
        Me.botSelectBox.Name = "botSelectBox"
        Me.botSelectBox.Size = New System.Drawing.Size(136, 21)
        Me.botSelectBox.TabIndex = 10
        '
        'btnRestart
        '
        Me.btnRestart.Location = New System.Drawing.Point(148, 19)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(65, 25)
        Me.btnRestart.TabIndex = 11
        Me.btnRestart.Text = "Restart"
        Me.btnRestart.UseVisualStyleBackColor = true
        '
        'repLabel
        '
        Me.repLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.repLabel.AutoSize = true
        Me.repLabel.Location = New System.Drawing.Point(6, 25)
        Me.repLabel.Name = "repLabel"
        Me.repLabel.Size = New System.Drawing.Size(35, 13)
        Me.repLabel.TabIndex = 12
        Me.repLabel.TabStop = true
        Me.repLabel.Text = "Help?"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(77, 19)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(65, 25)
        Me.btnStop.TabIndex = 15
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = true
        '
        'Timer
        '
        Me.Timer.Enabled = true
        Me.Timer.Interval = 400
        '
        'botTree
        '
        Me.botTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.botTree.Location = New System.Drawing.Point(0, 0)
        Me.botTree.Margin = New System.Windows.Forms.Padding(2)
        Me.botTree.Name = "botTree"
        Me.botTree.ShowLines = false
        Me.botTree.ShowPlusMinus = false
        Me.botTree.ShowRootLines = false
        Me.botTree.Size = New System.Drawing.Size(195, 550)
        Me.botTree.TabIndex = 16
        '
        'botPanel
        '
        Me.botPanel.AutoSize = true
        Me.botPanel.BackColor = System.Drawing.Color.Black
        Me.botPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.botPanel.Location = New System.Drawing.Point(0, 0)
        Me.botPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.botPanel.Name = "botPanel"
        Me.botPanel.Size = New System.Drawing.Size(914, 550)
        Me.botPanel.TabIndex = 17
        '
        'BackgroundWorker
        '
        '
        'botsContainer
        '
        Me.botsContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.botsContainer.Location = New System.Drawing.Point(12, 68)
        Me.botsContainer.Margin = New System.Windows.Forms.Padding(2)
        Me.botsContainer.Name = "botsContainer"
        '
        'botsContainer.Panel1
        '
        Me.botsContainer.Panel1.Controls.Add(Me.botTree)
        '
        'botsContainer.Panel2
        '
        Me.botsContainer.Panel2.Controls.Add(Me.botPanel)
        Me.botsContainer.Panel2MinSize = 0
        Me.botsContainer.Size = New System.Drawing.Size(1112, 550)
        Me.botsContainer.SplitterDistance = 195
        Me.botsContainer.SplitterWidth = 3
        Me.botsContainer.TabIndex = 18
        '
        'btnStopAll
        '
        Me.btnStopAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnStopAll.Location = New System.Drawing.Point(77, 19)
        Me.btnStopAll.Name = "btnStopAll"
        Me.btnStopAll.Size = New System.Drawing.Size(65, 25)
        Me.btnStopAll.TabIndex = 20
        Me.btnStopAll.Text = "Stop"
        Me.btnStopAll.UseVisualStyleBackColor = true
        '
        'btnRestartAll
        '
        Me.btnRestartAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnRestartAll.Location = New System.Drawing.Point(148, 19)
        Me.btnRestartAll.Name = "btnRestartAll"
        Me.btnRestartAll.Size = New System.Drawing.Size(65, 25)
        Me.btnRestartAll.TabIndex = 21
        Me.btnRestartAll.Text = "Restart"
        Me.btnRestartAll.UseVisualStyleBackColor = true
        '
        'selectedOptionsGroup
        '
        Me.selectedOptionsGroup.Controls.Add(Me.btnEdit)
        Me.selectedOptionsGroup.Controls.Add(Me.btnStop)
        Me.selectedOptionsGroup.Controls.Add(Me.btnRestart)
        Me.selectedOptionsGroup.Controls.Add(Me.btnRemove)
        Me.selectedOptionsGroup.Location = New System.Drawing.Point(12, 9)
        Me.selectedOptionsGroup.Name = "selectedOptionsGroup"
        Me.selectedOptionsGroup.Size = New System.Drawing.Size(293, 54)
        Me.selectedOptionsGroup.TabIndex = 22
        Me.selectedOptionsGroup.TabStop = false
        Me.selectedOptionsGroup.Text = "Selected Bot Operations"
        '
        'batchOptionsGroup
        '
        Me.batchOptionsGroup.Controls.Add(Me.btnStartAll)
        Me.batchOptionsGroup.Controls.Add(Me.btnStopAll)
        Me.batchOptionsGroup.Controls.Add(Me.btnRestartAll)
        Me.batchOptionsGroup.Location = New System.Drawing.Point(311, 9)
        Me.batchOptionsGroup.Name = "batchOptionsGroup"
        Me.batchOptionsGroup.Size = New System.Drawing.Size(229, 54)
        Me.batchOptionsGroup.TabIndex = 23
        Me.batchOptionsGroup.TabStop = false
        Me.batchOptionsGroup.Text = "Batch Operations"
        '
        'btnStartAll
        '
        Me.btnStartAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnStartAll.Location = New System.Drawing.Point(6, 19)
        Me.btnStartAll.Name = "btnStartAll"
        Me.btnStartAll.Size = New System.Drawing.Size(65, 25)
        Me.btnStartAll.TabIndex = 22
        Me.btnStartAll.Text = "Start"
        Me.btnStartAll.UseVisualStyleBackColor = true
        '
        'donationGroup
        '
        Me.donationGroup.Controls.Add(Me.paypalLabel)
        Me.donationGroup.Controls.Add(Me.repLabel)
        Me.donationGroup.Location = New System.Drawing.Point(972, 9)
        Me.donationGroup.Name = "donationGroup"
        Me.donationGroup.Size = New System.Drawing.Size(155, 54)
        Me.donationGroup.TabIndex = 24
        Me.donationGroup.TabStop = false
        Me.donationGroup.Text = "Help Developer"
        '
        'paypalLabel
        '
        Me.paypalLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.paypalLabel.AutoSize = true
        Me.paypalLabel.Location = New System.Drawing.Point(51, 25)
        Me.paypalLabel.Name = "paypalLabel"
        Me.paypalLabel.Size = New System.Drawing.Size(95, 13)
        Me.paypalLabel.TabIndex = 13
        Me.paypalLabel.TabStop = true
        Me.paypalLabel.Text = "Donate via PayPal"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.botSelectBox)
        Me.GroupBox1.Location = New System.Drawing.Point(546, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(229, 54)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Add Bot(s)"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 627)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1135, 22)
        Me.StatusStrip1.TabIndex = 25
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusLabel
        '
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.showPokemon)
        Me.GroupBox2.Controls.Add(Me.showExp)
        Me.GroupBox2.Controls.Add(Me.showLvl)
        Me.GroupBox2.Location = New System.Drawing.Point(781, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(185, 54)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Info to show"
        '
        'showPokemon
        '
        Me.showPokemon.AutoSize = true
        Me.showPokemon.Location = New System.Drawing.Point(131, 23)
        Me.showPokemon.Name = "showPokemon"
        Me.showPokemon.Size = New System.Drawing.Size(46, 17)
        Me.showPokemon.TabIndex = 2
        Me.showPokemon.Text = "P/H"
        Me.showPokemon.UseVisualStyleBackColor = true
        '
        'showExp
        '
        Me.showExp.AutoSize = true
        Me.showExp.Location = New System.Drawing.Point(57, 23)
        Me.showExp.Name = "showExp"
        Me.showExp.Size = New System.Drawing.Size(68, 17)
        Me.showExp.TabIndex = 1
        Me.showExp.Text = "EXP/HR"
        Me.showExp.UseVisualStyleBackColor = true
        '
        'showLvl
        '
        Me.showLvl.AutoSize = true
        Me.showLvl.Location = New System.Drawing.Point(6, 24)
        Me.showLvl.Name = "showLvl"
        Me.showLvl.Size = New System.Drawing.Size(45, 17)
        Me.showLvl.TabIndex = 0
        Me.showLvl.Text = "LVL"
        Me.showLvl.UseVisualStyleBackColor = true
        '
        'batchStarter
        '
        '
        'batchKiller
        '
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1135, 649)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.donationGroup)
        Me.Controls.Add(Me.batchOptionsGroup)
        Me.Controls.Add(Me.botsContainer)
        Me.Controls.Add(Me.selectedOptionsGroup)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "Pokemon Go Bot Manager"
        Me.botsContainer.Panel1.ResumeLayout(false)
        Me.botsContainer.Panel2.ResumeLayout(false)
        Me.botsContainer.Panel2.PerformLayout
        CType(Me.botsContainer,System.ComponentModel.ISupportInitialize).EndInit
        Me.botsContainer.ResumeLayout(false)
        Me.selectedOptionsGroup.ResumeLayout(false)
        Me.batchOptionsGroup.ResumeLayout(false)
        Me.donationGroup.ResumeLayout(false)
        Me.donationGroup.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.StatusStrip1.ResumeLayout(false)
        Me.StatusStrip1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents btnAdd As Button
        Friend WithEvents btnRemove As Button
        Friend WithEvents btnEdit As Button
        Friend WithEvents botSelectBox As ComboBox
        Friend WithEvents btnRestart As Button
        Friend WithEvents repLabel As LinkLabel
        Friend WithEvents btnStop As Button
        Friend WithEvents Timer As Timer
        Friend WithEvents botTree As TreeView
        Friend WithEvents botPanel As Panel
        Friend WithEvents BackgroundWorker As System.ComponentModel.BackgroundWorker
        Friend WithEvents botsContainer As SplitContainer
        Friend WithEvents btnStopAll As Button
        Friend WithEvents btnRestartAll As Button
        Friend WithEvents selectedOptionsGroup As System.Windows.Forms.GroupBox
        Friend WithEvents batchOptionsGroup As System.Windows.Forms.GroupBox
        Friend WithEvents donationGroup As System.Windows.Forms.GroupBox
        Friend WithEvents paypalLabel As System.Windows.Forms.LinkLabel
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
        Friend WithEvents statusLabel As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents showPokemon As System.Windows.Forms.CheckBox
        Friend WithEvents showExp As System.Windows.Forms.CheckBox
        Friend WithEvents showLvl As System.Windows.Forms.CheckBox
        Friend WithEvents batchStarter As System.ComponentModel.BackgroundWorker
        Friend WithEvents batchKiller As System.ComponentModel.BackgroundWorker
        Friend WithEvents btnStartAll As System.Windows.Forms.Button
    End Class
End NameSpace