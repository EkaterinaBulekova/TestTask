Imports ListFileUIApp.Models

Namespace FileHelpers
    Public Interface IHtmlHelper
        Function GetHtmlString(list As List(Of FileInfoModel)) As Object
    End Interface
End Namespace
