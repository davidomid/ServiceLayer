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
            Context.ResultTypeConverters.Add(new HttpStatusCodeToServiceResultTypesConverter());
            Context.ResultTypeConverters.Add(new ServiceResultTypesToHttpStatusCodeConverter());
        }
    }
}
