Namespace UserInterface
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblBotPath = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(69, 9)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(300, 20)
        Me.TextBox1.TabIndex = 0
        '
        'lblBotPath
        '
        Me.lblBotPath.AutoSize = true
        Me.lblBotPath.Location = New System.Drawing.Point(12, 12)
        Me.lblBotPath.Name = "lblBotPath"
        Me.lblBotPath.Size = New System.Drawing.Size(51, 13)
        Me.lblBotPath.TabIndex = 1
        Me.lblBotPath.Text = "Bot Path:"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(375, 9)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(27, 20)
        Me.btnBrowse.TabIndex = 3
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = true
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(408, 9)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(37, 20)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = true
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Location = New System.Drawing.Point(15, 35)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(595, 242)
        Me.TabControl1.TabIndex = 5
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(451, 9)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(55, 20)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = true
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(523, 9)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(87, 20)
        Me.btnEdit.TabIndex = 7
        Me.btnEdit.Text = "Edit Selected"
        Me.btnEdit.UseVisualStyleBackColor = true
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 289)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblBotPath)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Main"
        Me.Text = "Pokemon Go Bot Manager"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents TextBox1 As TextBox
        Friend WithEvents lblBotPath As Label
        Friend WithEvents btnBrowse As Button
        Friend WithEvents btnAdd As Button
        Friend WithEvents TabControl1 As TabControl
        Friend WithEvents btnRemove As Button
        Friend WithEvents btnEdit As Button
        Friend WithEvents OpenFileDialog As OpenFileDialog
    End Class
End NameSpace