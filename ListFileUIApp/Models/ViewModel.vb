Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.IO
Imports ListFileDomain.FileHelpers
Imports ListFileDomain.Models
Imports ListFileUIApp.Loggers
Imports ListFileUIApp.My.Resources

Namespace Models
    Public Class ViewModel
        Implements IViewModel
        Private ReadOnly _dataFileHelper As IDataFileHelper(Of FileInfoModel)
        Private ReadOnly _userFileHelper As IUserFileHelper
        Private ReadOnly _htmlHelper As IHtmlHelper
        Private ReadOnly _logger As ILogger
        Public ReadOnly Property Files As BindingList(Of FileInfoModel) Implements IViewModel.Files

        Public Sub New(fileHelper As IDataFileHelper(Of FileInfoModel), htmlHelper As IHtmlHelper, logger As ILogger, userFileHelper As IUserFileHelper)
            _dataFileHelper = fileHelper
            _htmlHelper = htmlHelper
            _logger = logger
            _userFileHelper = userFileHelper
            _userFileHelper.TempPath = Path.Combine(Path.GetDirectoryName(GetType(Form1).Assembly.Location), "Temp") 
            Files = New BindingList(Of FileInfoModel)(_dataFileHelper.GetFileList().ToList())
        End Sub

        Public ReadOnly Property HtmlListString() As String Implements IViewModel.HtmlListString
            Get
                If Not Files Is Nothing Then
                   Return _htmlHelper.GetHtmlString(Files.Where(Function(x) File.Exists(x.FullName)).ToList())
                End If
                Return String.Empty
            End Get
        End Property


        Public Sub AddFiles(fileInfo As FileInfoModel) Implements IViewModel.AddFiles
            Try
                If Not Files.Any(Function(x) x.FullName = fileInfo.FullName) Then
                    Files.Add(fileInfo)
                    _dataFileHelper.SetFileList(Files.ToArray())
                    _userFileHelper.CreateFile(fileInfo.FullName)
                Else
                    MessageBox.Show(Form1, Messages.FileAlreadyExists)
                End If
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

    End Class
End Namespace