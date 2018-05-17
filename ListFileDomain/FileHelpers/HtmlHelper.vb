Imports System.Text
Imports ListFileDomain.Models

Namespace FileHelpers
    Public Class HtmlHelper
        Implements IHtmlHelper

        Private ReadOnly _startString = "<html><body>"
        Private ReadOnly _endString = "</body></html>"
        Private ReadOnly _link = "<br/><a href='{0}' data='{0}'>{1}</a><br/>"

        Private Function IHtmlHelper_GetHtmlString(list As List(Of FileInfoModel)) As String Implements IHtmlHelper.GetHtmlString
            Dim document = New StringBuilder
            document.AppendLine(_startString)
            For Each item In list
                document.AppendLine(String.Format(_link, item.FullName, item.Name))
            Next
            document.AppendLine(_endString)
            Return document.ToString()
        End Function

    End Class
End Namespace