Imports System.IO

Namespace SerializerHelpers
    Public Interface ISerialiser(Of TData)
        Sub Serialization(stream As Stream, obj As TData)

        Function Deserialization(stream As Stream) As TData

    End Interface
End Namespace