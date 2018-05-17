Imports System.IO
Imports ListFileDomain.My.Resources
Imports Microsoft.Office.Interop.Word

Namespace FileHelpers
    Public Class UserFileHelper
        Implements IUserFileHelper

        Private Const HtmlFileStart = "<!DOCTYPE html><meta http-equiv='Content-Typ' content='text/html; charset=utf-8'><html><body><pre>"
        Private Const HtmlFileEnd = "</pre></body></html>"
        Private Const HtmlExtention = "html"
        Public Property TempPath As String = "Temp" Implements IUserFileHelper.TempPath 

        Public Sub OpenFile(filePath As String) Implements IUserFileHelper.OpenFile
            Dim htmlFilePath = GetDestanationPath(filePath)

            If Not String.IsNullOrEmpty(htmlFilePath) Then
                Try
                    If File.Exists(htmlFilePath) Then
                        If DateTime.Compare(File.GetLastWriteTime(htmlFilePath), File.GetLastWriteTime(filePath)) > 0 Then
                            Process.Start(htmlFilePath)
                            Return
                        End If
                        File.Delete(htmlFilePath)
                    End If

                    CreateHtmlFile(filePath, htmlFilePath)
                    Process.Start(htmlFilePath)
                Catch ex As ObjectDisposedException
                    Throw New Exception(Messages.ImpossbleStartProcess + htmlFilePath)
                Catch ex As FileNotFoundException
                    Throw New Exception(Messages.ImpossbleStartProcess + htmlFilePath)
                Catch ex As Exception
                    Throw
                End Try
            End If
        End Sub

        Public Sub CreateFile(filePath As String) Implements IUserFileHelper.CreateFile
            Dim htmlFilePath = GetDestanationPath(filePath)

            If Not String.IsNullOrEmpty(htmlFilePath) Then
                CreateHtmlFile(filePath, htmlFilePath)
            End If
        End Sub


        Public Sub ClearTempFiles() Implements IUserFileHelper.ClearTempFiles
            Try
                If Directory.Exists(TempPath) Then
                    Directory.Delete(TempPath, True)
                End If
            Catch ex As ArgumentException
                Throw New Exception(Messages.ImpossibleClearTempDirectory + TempPath, ex)
            End Try
        End Sub

        Private Function GetDestanationPath(source As String) As String
            Try
                If File.Exists(source) Then
                    Dim htmlFilePath = Path.ChangeExtension(source, HtmlExtention)
                    Return Path.Combine(TempPath, Path.GetFileName(htmlFilePath))
                End If
            Catch ex As Exception

            End Try
            Return String.Empty
        End Function

        Private Sub CreateHtmlFile(source As String, destination As String)
            Try
                If Not Directory.Exists(TempPath) Then
                    Directory.CreateDirectory(TempPath)
                End If
            Catch ex As Exception
                Throw New Exception(Messages.ImpossibleCreateTempDirectory, ex)
            End Try

            Dim extention = Path.GetExtension(source)

            If Not String.IsNullOrEmpty(extention) AndAlso String.Equals(extention, ".txt") Then
                Try
                    TxtToHtmlProcess(source, destination)
                Catch ex As Exception
                    Throw New Exception(Messages.ImpossibleConvertTxtFile + source, ex)
                End Try
            ElseIf Not String.IsNullOrEmpty(extention) AndAlso (String.Equals(extention, ".docx") Or String.Equals(extention, ".doc")) Then
                WordToHtmlProcess(source, destination)
            Else
                Throw New Exception(Messages.UncorrectFileExtention + source)
            End If
        End Sub

        Private Sub TxtToHtmlProcess(source As String, destination As String)
            Using sourceStream As New StreamReader(source)
                Using destinationStream As New StreamWriter(File.Create(destination))
                    destinationStream.Write(HtmlFileStart)
                    destinationStream.Write(sourceStream.ReadToEnd())
                    destinationStream.Write(HtmlFileEnd)
                    sourceStream.Close()
                    destinationStream.Close()
                End Using
            End Using
        End Sub

        Private Sub WordToHtmlProcess(source As String, destination As String)
            Dim documentFormat As Object = 10
            Try
                WordCreator.App.Documents.Open(source)
            Catch ex As Exception
                'if word application was dropped outside our application
                WordCreator.App = New Application()
                WordCreator.App.Documents.Open(source)
            End Try
                WordCreator.App.Visible = False
            Dim document = WordCreator.App.ActiveDocument
            Try
                document.SaveAs(destination, documentFormat)
            Catch ex As Exception
                Throw New Exception(Messages.ImpossibleConvertWordFile + source, ex)
            Finally
                document.Close()
            End Try

        End Sub

    End Class
End Namespace