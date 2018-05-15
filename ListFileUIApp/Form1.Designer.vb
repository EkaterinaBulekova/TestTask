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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FileListBrowser = New System.Windows.Forms.WebBrowser()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.AddDocumentButton = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout
        Me.SuspendLayout
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = true
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 10)
        Me.Panel1.TabIndex = 1
        '
        'FileListBrowser
        '
        Me.FileListBrowser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.FileListBrowser.Location = New System.Drawing.Point(3, 3)
        Me.FileListBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.FileListBrowser.Name = "FileListBrowser"
        Me.FileListBrowser.Size = New System.Drawing.Size(815, 456)
        Me.FileListBrowser.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.AddDocumentButton)
        Me.Panel2.Location = New System.Drawing.Point(6, 465)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(812, 60)
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 527)
        Me.Controls.Add(Me.FileListBrowser)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel2.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents AddDocumentButton As Button
    Friend WithEvents FileListBrowser As WebBrowser
End Class
