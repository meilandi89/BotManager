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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRestartTimer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkBatchAdd = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.chkHide = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 39)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(533, 430)
        Me.DataGridView1.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(449, 476)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 28)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = true
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(341, 476)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(17, 485)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Restart every:"
        '
        'txtRestartTimer
        '
        Me.txtRestartTimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.txtRestartTimer.Location = New System.Drawing.Point(114, 479)
        Me.txtRestartTimer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRestartTimer.Name = "txtRestartTimer"
        Me.txtRestartTimer.Size = New System.Drawing.Size(68, 22)
        Me.txtRestartTimer.TabIndex = 4
        Me.txtRestartTimer.Text = "30"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(190, 485)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "minutes"
        '
        'chkBatchAdd
        '
        Me.chkBatchAdd.AutoSize = true
        Me.chkBatchAdd.Location = New System.Drawing.Point(19, 12)
        Me.chkBatchAdd.Name = "chkBatchAdd"
        Me.chkBatchAdd.Size = New System.Drawing.Size(89, 20)
        Me.chkBatchAdd.TabIndex = 6
        Me.chkBatchAdd.Text = "Batch Add"
        Me.chkBatchAdd.UseVisualStyleBackColor = true
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = false
        Me.TextBox1.Location = New System.Drawing.Point(114, 10)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(260, 22)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Text = "File Path"
        '
        'chkHide
        '
        Me.chkHide.AutoSize = true
        Me.chkHide.Location = New System.Drawing.Point(380, 12)
        Me.chkHide.Name = "chkHide"
        Me.chkHide.Size = New System.Drawing.Size(59, 20)
        Me.chkHide.TabIndex = 8
        Me.chkHide.Text = "Hide!"
        Me.chkHide.UseVisualStyleBackColor = true
        '
        'SettingsEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 513)
        Me.Controls.Add(Me.chkHide)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.chkBatchAdd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRestartTimer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "SettingsEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings Editor"
        CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents DataGridView1 As DataGridView
        Friend WithEvents btnSave As Button
        Friend WithEvents btnCancel As Button
        Friend WithEvents Label1 As Label
        Friend WithEvents txtRestartTimer As TextBox
        Friend WithEvents Label2 As Label
        Friend WithEvents chkBatchAdd As CheckBox
        Friend WithEvents TextBox1 As TextBox
        Friend WithEvents chkHide As CheckBox
    End Class
End NameSpace