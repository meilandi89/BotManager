Namespace UserInterface
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SettingsEditor
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.DataGridView1 = New System.Windows.Forms.DataGridView()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.restartLabel = New System.Windows.Forms.Label()
            Me.txtRestartTimer = New System.Windows.Forms.TextBox()
            Me.minutesLabel = New System.Windows.Forms.Label()
            Me.chkBatchAdd = New System.Windows.Forms.CheckBox()
            Me.fileLoc = New System.Windows.Forms.TextBox()
            Me.chkHide = New System.Windows.Forms.CheckBox()
            Me.browseBtn = New System.Windows.Forms.Button()
            Me.batchSettingsGroup = New System.Windows.Forms.GroupBox()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.batchSettingsGroup.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridView1
            '
            Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridView1.Location = New System.Drawing.Point(12, 90)
            Me.DataGridView1.Name = "DataGridView1"
            Me.DataGridView1.Size = New System.Drawing.Size(384, 259)
            Me.DataGridView1.TabIndex = 0
            '
            'btnSave
            '
            Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSave.Location = New System.Drawing.Point(331, 355)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(65, 23)
            Me.btnSave.TabIndex = 1
            Me.btnSave.Text = "Save"
            Me.btnSave.UseVisualStyleBackColor = True
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.Location = New System.Drawing.Point(253, 355)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(72, 23)
            Me.btnCancel.TabIndex = 2
            Me.btnCancel.Text = "Cancel"
            Me.btnCancel.UseVisualStyleBackColor = True
            '
            'restartLabel
            '
            Me.restartLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.restartLabel.AutoSize = True
            Me.restartLabel.Location = New System.Drawing.Point(12, 359)
            Me.restartLabel.Name = "restartLabel"
            Me.restartLabel.Size = New System.Drawing.Size(73, 13)
            Me.restartLabel.TabIndex = 3
            Me.restartLabel.Text = "Restart every:"
            '
            'txtRestartTimer
            '
            Me.txtRestartTimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtRestartTimer.Location = New System.Drawing.Point(91, 357)
            Me.txtRestartTimer.Name = "txtRestartTimer"
            Me.txtRestartTimer.Size = New System.Drawing.Size(52, 20)
            Me.txtRestartTimer.TabIndex = 4
            Me.txtRestartTimer.Text = "30"
            '
            'minutesLabel
            '
            Me.minutesLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.minutesLabel.AutoSize = True
            Me.minutesLabel.Location = New System.Drawing.Point(149, 359)
            Me.minutesLabel.Name = "minutesLabel"
            Me.minutesLabel.Size = New System.Drawing.Size(43, 13)
            Me.minutesLabel.TabIndex = 5
            Me.minutesLabel.Text = "minutes"
            '
            'chkBatchAdd
            '
            Me.chkBatchAdd.AutoSize = True
            Me.chkBatchAdd.Location = New System.Drawing.Point(5, 18)
            Me.chkBatchAdd.Margin = New System.Windows.Forms.Padding(2)
            Me.chkBatchAdd.Name = "chkBatchAdd"
            Me.chkBatchAdd.Size = New System.Drawing.Size(76, 17)
            Me.chkBatchAdd.TabIndex = 6
            Me.chkBatchAdd.Text = "Batch Add"
            Me.chkBatchAdd.UseVisualStyleBackColor = True
            '
            'fileLoc
            '
            Me.fileLoc.Enabled = False
            Me.fileLoc.Location = New System.Drawing.Point(85, 15)
            Me.fileLoc.Margin = New System.Windows.Forms.Padding(2)
            Me.fileLoc.Name = "fileLoc"
            Me.fileLoc.Size = New System.Drawing.Size(294, 20)
            Me.fileLoc.TabIndex = 7
            Me.fileLoc.Text = "File Path"
            '
            'chkHide
            '
            Me.chkHide.AutoSize = True
            Me.chkHide.Location = New System.Drawing.Point(197, 358)
            Me.chkHide.Margin = New System.Windows.Forms.Padding(2)
            Me.chkHide.Name = "chkHide"
            Me.chkHide.Size = New System.Drawing.Size(51, 17)
            Me.chkHide.TabIndex = 8
            Me.chkHide.Text = "Hide!"
            Me.chkHide.UseVisualStyleBackColor = True
            '
            'browseBtn
            '
            Me.browseBtn.Enabled = False
            Me.browseBtn.Location = New System.Drawing.Point(3, 40)
            Me.browseBtn.Name = "browseBtn"
            Me.browseBtn.Size = New System.Drawing.Size(376, 23)
            Me.browseBtn.TabIndex = 9
            Me.browseBtn.Text = "Browse"
            Me.browseBtn.UseVisualStyleBackColor = True
            '
            'batchSettingsGroup
            '
            Me.batchSettingsGroup.Controls.Add(Me.chkBatchAdd)
            Me.batchSettingsGroup.Controls.Add(Me.browseBtn)
            Me.batchSettingsGroup.Controls.Add(Me.fileLoc)
            Me.batchSettingsGroup.Location = New System.Drawing.Point(12, 12)
            Me.batchSettingsGroup.Name = "batchSettingsGroup"
            Me.batchSettingsGroup.Size = New System.Drawing.Size(384, 72)
            Me.batchSettingsGroup.TabIndex = 10
            Me.batchSettingsGroup.TabStop = False
            Me.batchSettingsGroup.Text = "Batch Import"
            '
            'SettingsEditor
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(408, 390)
            Me.Controls.Add(Me.batchSettingsGroup)
            Me.Controls.Add(Me.chkHide)
            Me.Controls.Add(Me.minutesLabel)
            Me.Controls.Add(Me.txtRestartTimer)
            Me.Controls.Add(Me.restartLabel)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.DataGridView1)
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "SettingsEditor"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Settings Editor"
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.batchSettingsGroup.ResumeLayout(False)
            Me.batchSettingsGroup.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents DataGridView1 As DataGridView
        Friend WithEvents btnSave As Button
        Friend WithEvents btnCancel As Button
        Friend WithEvents restartLabel As Label
        Friend WithEvents txtRestartTimer As TextBox
        Friend WithEvents minutesLabel As Label
        Friend WithEvents chkBatchAdd As CheckBox
        Friend WithEvents fileLoc As TextBox
        Friend WithEvents chkHide As CheckBox
        Friend WithEvents browseBtn As System.Windows.Forms.Button
        Friend WithEvents batchSettingsGroup As System.Windows.Forms.GroupBox
    End Class
End NameSpace