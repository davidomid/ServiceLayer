using ServiceLayer.Core.Internal.Converters;

namespace ServiceLayer.Core
{
    public class AspNetCorePluginSettings
    {
        public ActionResultConverterCollection ResultTypeConverters { get; set; } = new ActionResultConverterCollection();
    }
}
