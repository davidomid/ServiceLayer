using ServiceLayer.Internal.Plugins;

namespace ServiceLayer
{
    /// <summary>
    /// You can inherit this abstract class to create your own ServiceLayer plugin.
    /// </summary>
    /// <remarks>Plugins are the backbone of ServiceLayer's extensibility. They allow you to specify mappings between different result types, using converters. Plugins are also capable of installing and uninstalling other plugins.</remarks>
    public abstract class Plugin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Plugin"/> class
        /// </summary>
        /// <param name="name">Sets the value of the <see cref="Name"/> property.</param>
        protected Plugin(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name of the plugin.
        /// </summary>
        /// <remarks>Installed plugins are expected to have unique names. When installing a plugin, if an already installed plugin with the same name is found, it will be automatically installed before the new plugin is installed.</remarks>
        public string Name { get; }

        /// <summary>
        /// Gets the static plugin context which is shared between all plugins.
        /// </summary>
        /// <remarks>You should use this within your implemented <see cref="Install"/> and <see cref="Uninstall"/> methods for making changes to ServiceLayer.</remarks>
        protected static IPluginContext Context { get; } = new PluginContext();

        /// <summary>
        /// This method contains all of the plugin's installation logic.
        /// </summary>
        /// <remarks>This method is executed automatically after calling <see cref="IPluginCollection.Install"/> and passing an instance of the plugin.</remarks>
        public abstract void Install();

        /// <summary>
        /// This method should contain all of your plugin's uninstallation logic.
        /// </summary>
        /// <remarks>This method is executed automatically after calling <see cref="IPluginCollection.Uninstall"/> and passing an instance of the plugin.</remarks>
        public abstract void Uninstall(); 
    }
}
