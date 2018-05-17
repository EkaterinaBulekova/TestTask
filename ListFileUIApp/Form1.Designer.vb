<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.AddDocumentButton = New System.Windows.Forms.Button()
        Me.FileListBox = New System.Windows.Forms.ListBox()
        Me.Panel2.SuspendLayout
        Me.SuspendLayout
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.AddDocumentButton)
        Me.Panel2.Location = New System.Drawing.Point(6, 465)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(768, 60)
        Me.Panel2.TabIndex = 2
        '
        'AddDocumentButton
        '
        Me.AddDocumentButton.Location = New System.Drawing.Point(9, 18)
        Me.AddDocumentButton.Name = "AddDocumentButton"
        Me.AddDocumentButton.Size = New System.Drawing.Size(148, 25)
        Me.AddDocumentButton.TabIndex = 0
        Me.AddDocumentButton.Text = "Add Document"
        Me.AddDocumentButton.UseVisualStyleBackColor = true
        '
        'FileListBox
        '
        Me.FileListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.FileListBox.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FileListBox.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.FileListBox.FormattingEnabled = true
        Me.FileListBox.HorizontalScrollbar = true
        Me.FileListBox.ItemHeight = 21
        Me.FileListBox.Location = New System.Drawing.Point(6, 2)
        Me.FileListBox.Margin = New System.Windows.Forms.Padding(10, 10, 10, 10)
        Me.FileListBox.Name = "FileListBox"
        Me.FileListBox.Size = New System.Drawing.Size(768, 466)
        Me.FileListBox.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 527)
        Me.Controls.Add(Me.FileListBox)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Form1"
        Me.Text = "TestForm"
        Me.Panel2.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents AddDocumentButton As Button
    Friend WithEvents FileListBox As ListBox
End Class
