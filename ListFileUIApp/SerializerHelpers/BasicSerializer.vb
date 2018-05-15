Imports System.IO

Namespace SerializerHelpers
    Public MustInherit Class BasicSerializer(of TData, TSerializer)
        Implements ISerialiser(Of TData)

        protected  Serializer As TSerializer
        
        Public Sub New(serial as TSerializer)
            Serializer = serial
        End Sub

        Public MustOverride Sub Serialization(stream As Stream, obj As TData) Implements ISerialiser(Of TData).Serialization
        
        Public MustOverride Function Deserialization(stream As Stream) As TData Implements ISerialiser(Of TData).Deserialization
    End Class
End NameSpace