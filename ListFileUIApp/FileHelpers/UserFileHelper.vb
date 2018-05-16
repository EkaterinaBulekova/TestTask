Imports System.IO
Imports ListFileUIApp.My.Resources

Namespace FileHelpers
    Public Class UserFileHelper
        Implements IUserFileHelper

        Private Const HtmlFileStart = "<!DOCTYPE html><meta http-equiv='Content-Typ' content='text/html; charset=utf-8'><html><body><pre>"
        Private Const HtmlFileEnd = "</pre></body></html>"
        Private Const HtmlExtention = "html"
        Private ReadOnly _tempPath = Path.Combine(Path.GetDirectoryName(GetType(Form1).Assembly.Location), "Temp")

        Public Sub OpenFile(filePath As String) Implements IUserFileHelper.OpenFile
            If File.Exists(filePath) Then
                Dim htmlFilePath = Path.ChangeExtension(filePath, HtmlExtention)
                htmlFilePath = Path.Combine(_tempPath, Path.GetFileName(htmlFilePath))
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
                Catch ex As Exception
                    Throw New Exception(Messages.ImpossibleConvertFile, ex)
                End Try
            End If
        End Sub

        Public Sub CreateHtmlFile(source As String, destination As String) Implements IUserFileHelper.CreateHtmlFile
            If Not Directory.Exists(_tempPath) Then
                Directory.CreateDirectory(_tempPath)
            End If

            Dim extention = Path.GetExtension(source)

            If Not String.IsNullOrEmpty(extention) AndAlso String.Equals(extention, ".txt") Then
                TxtToHtmlProcess(source, destination)
            Else
                WordToHtmlProcess(source, destination)
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

            WordCreator.App.Documents.Open(source)
            WordCreator.App.Visible = False
            Dim document = WordCreator.App.ActiveDocument
            Try
                document.SaveAs(destination, documentFormat)
            Catch ex As Exception
                Throw New Exception(Messages.ImpossibleConvertFile, ex)
            Finally
                document.Close()
            End Try

        End Sub
        
        Public Sub ClearTempFiles() Implements IUserFileHelper.ClearTempFiles
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