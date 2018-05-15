Imports System.IO
Imports ListFileUIApp.FileHelpers
Imports ListFileUIApp.Loggers

Namespace Models
    Public Class ViewModel
        Implements IViewModel
        Private ReadOnly _fileHelper As IFileHelper(Of FileInfoModel)
        Private ReadOnly _htmlHelper As IHtmlHelper
        Private ReadOnly _files As List(Of FileInfoModel)
        Private ReadOnly _logger As ILogger

        Public Sub New(fileHelper As IFileHelper(Of FileInfoModel), htmlHelper As IHtmlHelper, logger As ILogger)
            _fileHelper = fileHelper
            _htmlHelper = htmlHelper
            _logger = logger
            _files = New List(Of FileInfoModel)(_fileHelper.GetFileList().ToList())
            _logger.Info("Create viewModel")
        End Sub

        Public ReadOnly Property HtmlListString() As String Implements IViewModel.HtmlListString
            Get
                If Not _files Is Nothing Then
                   Return _htmlHelper.GetHtmlString(_files.Where(Function(x) File.Exists(x.FullName)).ToList())
                End If
                Return String.Empty
            End Get
        End Property

        Public Sub AddFiles(fileList As FileInfoModel) Implements IViewModel.AddFiles
            Try
                _files.Add(fileList)
                _fileHelper.SetFileList(_files.ToArray())
            Catch ex As Exception
                _logger.Error_(ex.Message, ex)
                MessageBox.Show(Form1, ex.Message)
            End Try
        End Sub

        Public Sub OpenLink(filePath As String) Implements IViewModel.OpenLink
            Try
                _fileHelper.OpenFile(filePath)
            Catch ex As Exception
                _logger.Error_(ex.Message, ex)
                MessageBox.Show(Form1, ex.Message)
            End Try
        End Sub

        Public Sub ClearTemp() Implements IViewModel.ClearTemp
            Try
                _fileHelper.ClearTempFile()
            Catch ex As Exception
                _logger.Error_(ex.Message, ex)
                MessageBox.Show(Form1, ex.Message)
            End Try
        End Sub
    End Class
End Namespace