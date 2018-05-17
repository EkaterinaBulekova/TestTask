Imports System.ComponentModel
Imports System.IO
Imports ListFileDomain.Models
Imports ListFileUIApp.Infrastructure
Imports ListFileUIApp.Models

Public Class Form1
    Private _viewModel As IViewModel
'    Private ReadOnly _dataAttribute = "data"
    Private ReadOnly _filterString = $"Documents|*.doc;*.docx;*.txt"
    Private _addedFile As FileInfoModel

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _viewModel = CompositionRoot.Resolve(Of IViewModel)
        FileListBox.DataSource = _viewModel.Files
        FileListBox.DisplayMember = "Name"
'        FileListBrowser.DocumentText = _viewModel.HtmlListString
      End Sub

    'Private Sub FileListBrowser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) 
    '    If FileListBrowser.ReadyState = WebBrowserReadyState.Complete Then
    '        Dim links = FileListBrowser.Document.Links
    '        For Each link As HtmlElement In links
    '            AddHandler link.Click, AddressOf OnLinkclick
    '        Next
    '    End If
    'End Sub

    'Private Sub OnLinkclick(sender As Object, e As HtmlElementEventArgs)
    '    Dim htmlElement = TryCast(sender, HtmlElement)
    '    If Not htmlElement Is Nothing Then
    '        _viewModel.OpenLink(htmlElement.GetAttribute(_dataAttribute))
    '    End If
    'End Sub

    Private Sub AddDocumentButton_Click(sender As Object, e As EventArgs) Handles AddDocumentButton.Click
        Dim dialog = New OpenFileDialog With {
            .Filter = _filterString
        }
        AddHandler dialog.FileOk, AddressOf AddFileChoosed
        AddHandler dialog.Disposed, AddressOf AddFileToList
        Using dialog
            dialog.ShowDialog()
        End Using
    End Sub

    Private Sub AddFileToList(sender As Object, e As EventArgs)
        If Not _addedFile Is Nothing
            _viewModel.AddFiles(_addedFile)
        End If
        _addedFile = Nothing
'            FileListBrowser.DocumentText = _viewModel.HtmlListString
    End Sub

    Private Sub AddFileChoosed(sender As Object, e As CancelEventArgs)
        Dim dialog = TryCast(sender, OpenFileDialog)
        If Not dialog Is Nothing Then
           _addedFile = New FileInfoModel() With {
                    .FullName = dialog.FileName, 
                    .Name = Path.GetFileName(dialog.FileName)
                    }
        End If
    End Sub

    Private Sub FileListBox_Clik(sender As Object, e As EventArgs) Handles FileListBox.Click
        Dim list = TryCast(sender, ListBox)
        If Not list Is Nothing
            Dim item = TryCast(list.SelectedItem, FileInfoModel)
            If Not item Is Nothing
                _viewModel.OpenLink(item.FullName)
            End If
        End If
    End Sub
End Class

