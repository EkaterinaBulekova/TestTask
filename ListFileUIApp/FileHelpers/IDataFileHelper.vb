Namespace FileHelpers
    Public Interface IDataFileHelper(Of T)

        Sub SetFileList(fileList() As T)

        Function GetFileList() As T()

    End Interface
End Namespace
