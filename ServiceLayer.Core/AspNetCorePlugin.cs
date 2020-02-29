using ServiceLayer.Core.Internal.Converters;

namespace ServiceLayer.Core
{
    public class AspNetCorePlugin : Plugin
    {
        private readonly ResultTypeConverter[] _resultTypeConverters = 
        {
            new HttpStatusCodeToResultTypesConverter(),
            new ResultTypesToHttpStatusCodeConverter()
        };

        public AspNetCorePlugin() : base("ASP.NET Core")
        {
        }

        public override void Install()
        {
            foreach (var resultTypeConverter in _resultTypeConverters)
            {
                Context.ResultTypeConverters.Install(resultTypeConverter);
            }
        }

        public override void Uninstall()
        {
            foreach (var resultTypeConverter in _resultTypeConverters)
            {
                Context.ResultTypeConverters.Uninstall(resultTypeConverter);
            }
        }
    }
}
