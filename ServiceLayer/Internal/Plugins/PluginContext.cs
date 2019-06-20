namespace ServiceLayer.Internal.Plugins
{
    internal class PluginContext : IPluginContext
    {
        public IResultTypeConverterCollection ResultTypeConverters { get; } = Engine.ResultTypeConverters;
        public IPluginCollection Plugins { get; } = Engine.Plugins;
    }
}
