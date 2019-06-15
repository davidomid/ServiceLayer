using System.Collections.Generic;
using ServiceLayer.Internal;

namespace ServiceLayer
{
    public class Context
    {
        public IResultTypeConverterCollection ResultTypeConverters =
            Engine.ResultTypeConverters;

        public IPluginCollection Plugins => Engine.Plugins;
    }
}
