Imports ListFileUIApp.Loggers
Imports ListFileUIApp.Models
Imports log4net

Namespace Infrastructure
    Friend Class ApplicationModule
        Inherits Ninject.Modules.NinjectModule

        Public Overrides Sub Load()
            Bind(GetType(IViewModel)).To(GetType(ViewModel))
            Bind(GetType(ILog)).ToMethod(Function(context) LogManager.GetLogger(context.Request.Target?.Member.ReflectedType))
            Bind(GetType(ILogger)).To(GetType(Logger))
        End Sub
    End Class
End NameSpace