namespace ServiceLayer
{
    public interface IPluginContext
    {
        IResultTypeConverterCollection ResultTypeConverters { get; }
        IPluginCollection Plugins { get; }
    }
}