using System;
using System.Collections.Generic;
using System.Text;
using ServiceLayer.Internal;

namespace ServiceLayer
{
    public static class ServiceLayerConfig
    {
        public static IPluginCollection Plugins = Engine.Plugins;
    }
}
