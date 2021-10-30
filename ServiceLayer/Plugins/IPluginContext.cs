namespace ServiceLayer
{
    /// <summary>
    /// This allows you to retrieve and manipulate the plugins and result type converters which are installed by ServiceLayer, from within the installation and uninstallation logic of your custom plugins.
    /// </summary>
    /// <remarks>An instance of this interface is available via the <see cref="Plugin.Context"/> property</remarks>
    public interface IPluginContext
    {
        /// <summary>
        /// Contains a collection of result type converters which are currently installed.
        /// </summary>
        IResultTypeConverterCollection ResultTypeConverters { get; }
        /// <summary>
        /// Contains a collection of plugins which are currently installed.
        /// </summary>
        IPluginCollection Plugins { get; }
    }
}