using ServiceLayer.Internal.Plugins;

namespace ServiceLayer
{
    /// <summary>
    /// You can inherit this abstract class to create your own ServiceLayer plugin.
    /// <remarks>Plugins are the backbone of ServiceLayer's extensibility. They allow you to specify mappings between different result types, using converters. Plugins are also capable of installing and uninstalling other plugins.</remarks>
    /// </summary>
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
        /// <remarks>Installed plugins are expected to have unique names. When installing a plugin, if an already installed plugin with the same name is found, it will be automatically installed before the new plugin is installed.</remarks>
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the static plugin context which is shared between all plugins.
        /// <remarks>You should use this within your implemented <see cref="Install"/> and <see cref="Uninstall"/> methods for making changes to ServiceLayer.</remarks>
        /// </summary>
        protected static IPluginContext Context { get; } = new PluginContext();

        /// <summary>
        /// This method contains all of the plugin's installation logic.
        /// <remarks>This method is executed automatically after calling <see cref="IPluginCollection.Install"/> and passing an instance of the plugin.</remarks>
        /// </summary>
        public abstract void Install();

        /// <summary>
        /// This method should contain all of your plugin's uninstallation logic.
        /// <remarks>This method is executed automatically after calling <see cref="IPluginCollection.Uninstall"/> and passing an instance of the plugin.</remarks>
        /// </summary>
        public abstract void Uninstall(); 
    }
}
