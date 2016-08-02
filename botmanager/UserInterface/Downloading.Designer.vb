Namespace UserInterface
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Downloading
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
        Me.downloadLabel = New System.Windows.Forms.Label()
        Me.downloadProgress = New System.Windows.Forms.ProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'downloadLabel
        '
        Me.downloadLabel.AutoSize = true
        Me.downloadLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.downloadLabel.Location = New System.Drawing.Point(6, 6)
        Me.downloadLabel.Name = "downloadLabel"
        Me.downloadLabel.Size = New System.Drawing.Size(142, 18)
        Me.downloadLabel.TabIndex = 0
        Me.downloadLabel.Text = "Get Latest Version ?"
        '
        'downloadProgress
        '
        Me.downloadProgress.Location = New System.Drawing.Point(11, 35)
        Me.downloadProgress.Name = "downloadProgress"
        Me.downloadProgress.Size = New System.Drawing.Size(258, 16)
        Me.downloadProgress.TabIndex = 1
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = true
        '
        'btnYes
        '
        Me.btnYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnYes.Location = New System.Drawing.Point(153, 4)
        Me.btnYes.Margin = New System.Windows.Forms.Padding(2)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(56, 23)
        Me.btnYes.TabIndex = 2
        Me.btnYes.Text = "Yes"
        Me.btnYes.UseVisualStyleBackColor = true
        Me.btnYes.Visible = false
        '
        'btnNo
        '
        Me.btnNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnNo.Location = New System.Drawing.Point(213, 4)
        Me.btnNo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(56, 23)
        Me.btnNo.TabIndex = 3
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = true
        Me.btnNo.Visible = false
        '
        'Downloading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 30)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.downloadLabel)
        Me.Controls.Add(Me.downloadProgress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = false
        Me.MaximumSize = New System.Drawing.Size(296, 92)
        Me.MinimizeBox = false
        Me.MinimumSize = New System.Drawing.Size(296, 69)
        Me.Name = "Downloading"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Download Manager"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents downloadLabel As Label
        Friend WithEvents downloadProgress As ProgressBar
        Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
        Friend WithEvents btnYes As Button
        Friend WithEvents btnNo As Button
    End Class
End NameSpace