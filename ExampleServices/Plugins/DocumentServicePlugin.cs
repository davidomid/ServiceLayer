using ServiceLayer;

namespace ExampleServices
{
    public class DocumentServicePlugin : Plugin
    {
        private readonly DocumentResultTypeHttpConverter _documentResultTypeConverter = new DocumentResultTypeHttpConverter();

        public DocumentServicePlugin() : base("Document Service")
        {
        }

        public override void Install()
        {
            Context.ResultTypeConverters.Install(_documentResultTypeConverter);
        }

        public override void Uninstall()
        {
            Context.ResultTypeConverters.Uninstall(_documentResultTypeConverter);
        }
    }
}
