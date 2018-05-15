Namespace FileHelpers
    Public Interface IFileHelper(Of T)
        Sub OpenFile(filePath As String)

        Sub SetFileList(fileList As T())

        Function GetFileList() As T()

        Sub ClearTempFile()
    End Interface
End Namespace