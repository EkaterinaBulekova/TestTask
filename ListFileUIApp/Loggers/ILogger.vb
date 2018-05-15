Namespace Loggers
    Public Interface ILogger
        Sub Info(message As String)
        Sub Debug(message As String)
        Sub Error_(message As String)
        Sub Debug(message As String, exception As Exception)
        Sub Error_(message As String, exception As Exception)
        Sub Debug(exception As Exception)
        Sub Error_(exception As Exception)
    End Interface
End NameSpace