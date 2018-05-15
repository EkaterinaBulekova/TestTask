Imports ListFileUIApp.FileHelpers
Imports ListFileUIApp.Loggers
Imports ListFileUIApp.Models
Imports ListFileUIApp.SerializerHelpers
Imports log4net

Namespace Infrastructure
    Friend Class ApplicationModule
        Inherits Ninject.Modules.NinjectModule

        Public Overrides Sub Load()
            Bind(GetType(IHtmlHelper)).To(GetType(HtmlHelper))
            Bind(GetType(ISerialiser(Of FileInfoModel()))).To(GetType(XmlStreamSerializer(Of FileInfoModel())))
            Bind(GetType(IFileHelper(Of FileInfoModel))).To(GetType(FileHelper(Of FileInfoModel)))
            Bind(GetType(IViewModel)).To(GetType(ViewModel))
            Bind(GetType(ILog)).ToMethod(Function(context) LogManager.GetLogger(context.Request.Target?.Member.ReflectedType))
            Bind(GetType(ILogger)).To(GetType(Logger))
        End Sub
    End Class
End NameSpace