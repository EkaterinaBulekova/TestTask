Imports ListFileDomain.FileHelpers
Imports ListFileDomain.Models
Imports ListFileDomain.SerializerHelpers

Namespace Infrastructure
    Public Class DomainModule
        Inherits Ninject.Modules.NinjectModule

        Public Overrides Sub Load()
            Bind(GetType(IHtmlHelper)).To(GetType(HtmlHelper))
            Bind(GetType(ISerialiser(Of FileInfoModel()))).To(GetType(XmlStreamSerializer(Of FileInfoModel())))
            Bind(GetType(IDataFileHelper(Of FileInfoModel))).To(GetType(DataFileHelper(Of FileInfoModel)))
            Bind(GetType(IUserFileHelper)).To(GetType(UserFileHelper))
        End Sub
    End Class
End Namespace