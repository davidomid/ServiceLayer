using ServiceLayer.Core.Internal.Converters;

namespace ServiceLayer.Core
{
    public class AspNetCorePlugin : Plugin
    {
        public AspNetCorePlugin() : base("ASP.NET Core")
        {
        }

        public override void Install()
        {
            Context.ResultTypeConverters.Install(new HttpStatusCodeToServiceResultTypesConverter());
            Context.ResultTypeConverters.Install(new ServiceResultTypesToHttpStatusCodeConverter());
        }
    }
}
