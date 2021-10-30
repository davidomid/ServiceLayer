using ServiceLayer.Internal;

namespace ServiceLayer
{
    /// <summary>
    /// Use this class to set the global ServiceLayer configuration for your application.
    /// </summary>
    public static class ServiceLayerConfig
    {
        /// <summary>
        /// Contains a collection of plugins which are currently installed.
        /// </summary>
        public static IPluginCollection Plugins = Engine.Plugins;
    }
}
