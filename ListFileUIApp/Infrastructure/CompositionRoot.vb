Imports Ninject
Imports Ninject.Modules

Namespace Infrastructure
    Friend Class CompositionRoot
        Private Shared _ninjectKernel As IKernel
        Public Shared Sub Wire(modul As INinjectModule)
            _ninjectKernel = New StandardKernel(modul)
        End Sub

        Public Shared Function Resolve(Of T) As  T
            Return _ninjectKernel.Get(Of T)()
        End Function
    End Class
End NameSpace