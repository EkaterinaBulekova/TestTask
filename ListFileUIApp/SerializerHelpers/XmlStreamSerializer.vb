Imports System.IO
Imports System.Xml.Serialization

Namespace SerializerHelpers
    Public Class XmlStreamSerializer(Of T)
        Inherits BasicSerializer(Of T, XmlSerializer)

        Public Sub New()
            MyBase.New(New XmlSerializer(GetType(T)))
        End Sub

        Public Overrides Sub Serialization(stream As Stream, obj As T)
            Serializer.Serialize(stream, obj)
        End Sub

        Public Overrides Function Deserialization(stream As Stream) As T
            Return Serializer.Deserialize(stream)
        End Function
    End Class
End Namespace