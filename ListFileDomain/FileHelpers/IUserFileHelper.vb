Namespace FileHelpers
    Public Interface IUserFileHelper
        Property TempPath As String

        Sub ClearTempFiles()

        Sub OpenFile(filePath As String)

        Sub CreateFile(filePath As String)

    End Interface
End Namespace
