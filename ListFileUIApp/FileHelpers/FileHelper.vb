Imports System.IO
Imports ListFileUIApp.My.Resources
Imports ListFileUIApp.SerializerHelpers
Imports Microsoft.Office.Interop.Word

Namespace FileHelpers
    Public Class FileHelper(Of T)
        Implements IFileHelper(Of T)

        Private Const XmlFilePath = "data.xml"
        Private ReadOnly _tempPath = "\tmp"
        Private ReadOnly _extention = "html"
        Private ReadOnly _serializer As ISerialiser(Of T())

        Sub New(serializer As ISerialiser(Of T()))
            _serializer = serializer
        End Sub

        Public Sub OpenFile(filePath As String) Implements IFileHelper(Of T).OpenFile
            If File.Exists(filePath) Then
                Dim htmlFilePath = Path.ChangeExtension(filePath, _extention)
                htmlFilePath = Path.Combine(_tempPath, Path.GetFileName(htmlFilePath))

                Try
                    If File.Exists(htmlFilePath) Then
                        File.Delete(htmlFilePath)
                    End If
                    If Not Directory.Exists(_tempPath) Then
                        Directory.CreateDirectory(_tempPath)
                    End If
                    Dim appWord As New Application
                    Dim documentFormat As Object = 10

                    appWord.Documents.Open(filePath)
                    appWord.Visible = False
                    Dim document = appWord.ActiveDocument

                    document.SaveAs(htmlFilePath, documentFormat)

                    Process.Start(htmlFilePath)

                    document.Close()
                    appWord.Quit()
                Catch ex As Exception
                    Throw New Exception(Messages.ImpossibleConvertFile,ex)
                End Try
            End If
        End Sub

        Public Sub SetFileList(fileList As T()) Implements IFileHelper(Of T).SetFileList
            Try
                 Dim outStream As FileStream = File.Create(XmlFilePath)
                 _serializer.Serialization(outStream, fileList)
                 outStream.Close()
            Catch ex As ArgumentException
                Throw New Exception(Messages.ImpossibleMakeChanges,ex)
            End Try
        End Sub

        Public Function GetFileList() As T() Implements IFileHelper(Of T).GetFileList
            Try
                If File.Exists(XmlFilePath) Then
                    Dim inputStream As FileStream = File.Open(XmlFilePath, FileMode.Open)
                    Dim testcollection = _serializer.Deserialization(inputStream)
                    inputStream.Close()
                    Return testcollection
                End If
                Return New T(){}
            Catch ex As Exception
                Throw New Exception(Messages.ImpossibleOpenDataFile,ex)
            End Try
        End Function

        Public Sub ClearTempFile() Implements IFileHelper(Of T).ClearTempFile
            Try
                If Directory.Exists(_tempPath) Then
                    Directory.Delete(_tempPath, True)
                End If
            Catch ex As ArgumentException
                Throw New Exception(Messages.ImpossibleMakeChanges,ex)
            End Try
        End Sub

    End Class
End Namespace