Imports System.IO
Imports ListFileUIApp.FileHelpers
Imports ListFileUIApp.Loggers

Namespace Models
    Public Class ViewModel
        Implements IViewModel
        Private ReadOnly _dataFileHelper As IDataFileHelper(Of FileInfoModel)
        Private ReadOnly _userFileHelper As IUserFileHelper
        Private ReadOnly _htmlHelper As IHtmlHelper
        Private ReadOnly _files As List(Of FileInfoModel)
        Private ReadOnly _logger As ILogger

        Public Sub New(fileHelper As IDataFileHelper(Of FileInfoModel), htmlHelper As IHtmlHelper, logger As ILogger, userFileHelper As IUserFileHelper)
            _dataFileHelper = fileHelper
            _htmlHelper = htmlHelper
            _logger = logger
            _userFileHelper = userFileHelper
            _files = New List(Of FileInfoModel)(_dataFileHelper.GetFileList().ToList())
        End Sub

        Public ReadOnly Property HtmlListString() As String Implements IViewModel.HtmlListString
            Get
                If Not _files Is Nothing Then
                   Return _htmlHelper.GetHtmlString(_files.Where(Function(x) File.Exists(x.FullName)).ToList())
                End If
                Return String.Empty
            End Get
        End Property

        Public Sub AddFiles(fileInfo As FileInfoModel) Implements IViewModel.AddFiles
            Try
                _files.Add(fileInfo)
                _dataFileHelper.SetFileList(_files.ToArray())
            Catch ex As Exception
                _logger.Error_(ex.Message, ex)
                MessageBox.Show(Form1, ex.Message)
            End Try
        End Sub

        Public Sub OpenLink(filePath As String) Implements IViewModel.OpenLink
            Try
                _userFileHelper.OpenFile(filePath)
            Catch ex As Exception
                _logger.Error_(ex.Message, ex)
                MessageBox.Show(Form1, ex.Message)
            End Try
        End Sub

        Public Sub ClearTemp() Implements IViewModel.ClearTemp
            Try
                _userFileHelper.ClearTempFiles()
            Catch ex As Exception
                _logger.Error_(ex.Message, ex)
                MessageBox.Show(Form1, ex.Message)
            End Try
        End Sub
    End Class
End Namespace