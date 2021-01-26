using System.Collections.Generic;
using ServiceLayer.Core.Converters;
using ServiceLayer.Core.Internal.Converters;

namespace ServiceLayer.Core
{
    public class AspNetCorePluginSettings
    {
        public ActionResultConverterCollection ResultTypeConverters { get; set; } = new ActionResultConverterCollection(new List<IActionResultConverter>());
    }
}
