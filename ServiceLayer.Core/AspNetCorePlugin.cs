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
            Context.ResultTypeConverters.AddOrReplace(new HttpStatusCodeToServiceResultTypesConverter());
            Context.ResultTypeConverters.AddOrReplace(new ServiceResultTypesToHttpStatusCodeConverter());
        }
    }
}
