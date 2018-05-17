Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports ListFileDomain.Models

Namespace Models
    Public Interface IViewModel
        ReadOnly Property HtmlListString As String

        ReadOnly Property Files As BindingList(Of FileInfoModel)

        Sub AddFiles(fileList As FileInfoModel)

        Sub OpenLink(filePath As String)

    End Interface
End Namespace
