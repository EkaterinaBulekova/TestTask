﻿Option Strict On
Option Explicit On
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports ListFileUIApp.Infrastructure
Imports ListFileDomain.Infrastructure
Imports Ninject.Modules
Imports ListFileDomain.FileHelpers
Imports Microsoft.Office.Interop.Word

Namespace My

    'NOTE: This file is auto-generated; do not modify it directly.  To make changes,
    ' or if you encounter build errors in this file, go to the Project Designer
    ' (go to Project Properties or double-click the My Project node in
    ' Solution Explorer), and make changes on the Application tab.
    '
    Partial Friend Class MyApplication

        <Global.System.Diagnostics.DebuggerStepThroughAttribute()> _
        Public Sub New()
            MyBase.New(Global.Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
            Me.IsSingleInstance = False
            Me.EnableVisualStyles = True
            Me.SaveMySettingsOnExit = True
            Me.ShutdownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
            CompositionRoot.Wire(New INinjectModule() {New ApplicationModule(), New DomainModule()})
        End Sub

        <Global.System.Diagnostics.DebuggerStepThroughAttribute()> _
        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = Global.ListFileUIApp.Form1
        End Sub

        Protected Overrides Sub OnRun()
            Try
                WordCreator.App = New Application()
            Catch ex As Exception
            End Try
            MyBase.OnRun()
        End Sub

        Protected Overrides Sub OnShutdown()
            MyBase.OnShutdown()
            Try
                WordCreator.App.Quit()
            Catch ex As Exception
                ' if word application droped outside
            End Try
        End Sub
    End Class
End Namespace
