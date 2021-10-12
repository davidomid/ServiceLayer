using System.Collections.Generic;

namespace ServiceLayer.Core
{
    public class AspNetCorePluginSettings
    {
        public ActionResultConverterCollection ResultTypeConverters { get; set; } = new ActionResultConverterCollection(new List<IActionResultConverter>());
    }
}
