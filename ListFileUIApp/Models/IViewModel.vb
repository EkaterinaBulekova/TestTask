Namespace Models
    Public Interface IViewModel
        ReadOnly Property HtmlListString As String
        Sub AddFiles(fileList As FileInfoModel)
        Sub OpenLink(filePath As String)
        Sub ClearTemp()
    End Interface
End Namespace
