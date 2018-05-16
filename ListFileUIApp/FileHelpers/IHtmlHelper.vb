Imports ListFileUIApp.Models

Namespace FileHelpers
    Public Interface IHtmlHelper

        Function GetHtmlString(list As List(Of FileInfoModel)) As String

    End Interface
End Namespace
