Imports log4net
Imports log4net.Config

Namespace Loggers
    Public Class Logger
        Implements ILogger

        Private ReadOnly _log As ILog

        Public Sub New(log As ILog)
            _log = log
        End Sub

        Public Shared Sub InitLogger()
            XmlConfigurator.Configure()
        End Sub

        Public Sub Info(message As String) Implements ILogger.Info
            _log.Info(message)
        End Sub

        Public Sub Debug(message As String) Implements ILogger.Debug
            if _log.IsDebugEnabled Then
                _log.Debug(message)
            End If
        End Sub

        Public Sub Error_(message As String) Implements ILogger.Error_
            if _log.IsErrorEnabled Then
                _log.Error(message)
            End If
        End Sub

        Public Sub Debug(message As String, exception As Exception) Implements ILogger.Debug
            if _log.IsDebugEnabled Then
                _log.Debug(message, exception)
            End If
        End Sub

        Public Sub Error_(message As String, exception As Exception) Implements ILogger.Error_
            if _log.IsErrorEnabled Then
                _log.Error(message, exception)
            End If
        End Sub

        Public Sub Debug(exception As Exception) Implements ILogger.Debug
            if _log.IsDebugEnabled Then
                _log.Debug(exception)
            End If
        End Sub

        Public Sub Error_(exception As Exception) Implements ILogger.Error_
            if _log.IsErrorEnabled Then
                _log.Error(exception)
            End If
        End Sub

    End Class
End NameSpace