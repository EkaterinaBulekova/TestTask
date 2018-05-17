Imports System.IO
Imports ListFileDomain.My.Resources
Imports ListFileDomain.SerializerHelpers

Namespace FileHelpers
    Public Class DataFileHelper(Of T)
        Implements IDataFileHelper(Of T)

        Private Const XmlFilePath = "data.xml"
        Private ReadOnly _serializer As ISerialiser(Of T())

        Sub New(serializer As ISerialiser(Of T()))
            _serializer = serializer
        End Sub

        Public Sub SetFileList(fileList As T()) Implements IDataFileHelper(Of T).SetFileList
            Try
                Using outStream As FileStream = File.Create(XmlFilePath)
                    _serializer.Serialization(outStream, fileList)
                    outStream.Close()
                End Using
            Catch ex As ArgumentException
                Throw New Exception(Messages.ImpossibleMakeChanges, ex)
            End Try
        End Sub

        Public Function GetFileList() As T() Implements IDataFileHelper(Of T).GetFileList
            Try
                If File.Exists(XmlFilePath) Then
                    Using inputStream As FileStream = File.Open(XmlFilePath, FileMode.Open)
                        Dim testcollection = _serializer.Deserialization(inputStream)
                        inputStream.Close()
                        Return testcollection
                    End Using
                End If
                Return New T() {}
            Catch ex As Exception
                Throw New Exception(Messages.ImpossibleOpenData, ex)
            End Try
        End Function

    End Class
End Namespace