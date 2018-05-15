Imports System.ComponentModel
Imports System.IO
Imports ListFileUIApp.Infrastructure
Imports ListFileUIApp.Models

Public Class Form1
    Private _viewModel As IViewModel
    Private ReadOnly _dataAttribute = "data"
    Private ReadOnly _filterString = $"Documents|*.doc;*.docx;*.txt"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _viewModel = CompositionRoot.Resolve(Of IViewModel)
        FileListBrowser.DocumentText = _viewModel.HtmlListString
    End Sub

    Private Sub FileListBrowser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles FileListBrowser.DocumentCompleted
        If FileListBrowser.ReadyState = WebBrowserReadyState.Complete Then
            Dim links = FileListBrowser.Document.Links
            For Each link As HtmlElement In links
                AddHandler link.Click, AddressOf OnLinkclick
            Next
        End If
    End Sub

    Private Sub OnLinkclick(sender As Object, e As HtmlElementEventArgs)
        Dim htmlElement = TryCast(sender, HtmlElement)
        If Not htmlElement Is Nothing Then
            _viewModel.OpenLink(htmlElement.GetAttribute(_dataAttribute))
        End If
    End Sub

    Private Sub AddDocumentButton_Click(sender As Object, e As EventArgs) Handles AddDocumentButton.Click
        Dim dialog  = New OpenFileDialog()
        dialog.Filter = _filterString
        AddHandler dialog.FileOk, AddressOf AddFileChoosed
        dialog.ShowDialog()
    End Sub

    Private Sub AddFileChoosed(sender As Object, e As CancelEventArgs)
        Dim dialog = TryCast(sender, OpenFileDialog)
        If Not dialog Is Nothing Then
            Dim file = New FileInfoModel()With{.FullName = dialog.FileName, .Name = Path.GetFileName(dialog.FileName)}
            _viewModel.AddFiles(file)
            FileListBrowser.DocumentText = _viewModel.HtmlListString
        End If
    End Sub

    Private Sub Form1_Close(sender As Object, e As EventArgs) Handles MyBase.Closing
        _viewModel.ClearTemp()
    End Sub
End Class

