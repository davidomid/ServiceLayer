using System.Collections.Generic;

namespace ServiceLayer
{
    /// <summary>
    /// <para>This interface provides access to a list of ServiceLayer plugins which are already installed.</para>
    /// </summary>
    /// <remarks>A static instance of this collection is available to you via the static <see cref="ServiceLayerConfig.Plugins"/> property. You can also access it directly from a Plugin instance, via the <see cref="Plugin.Context"/> property.</remarks>
    public interface IPluginCollection
    {
        /// <summary>
        /// A collection of plugins which are already installed.
        /// </summary>
        /// <remarks>This collection can be modified by calling the <see cref="Install"/> and <see cref="Uninstall"/> methods.</remarks>
        IReadOnlyCollection<Plugin> Installed { get; }
        /// <summary>
        /// Installs a new plugin, which can then be accessed via the <see cref="Installed"/> property.
        /// </summary>
        void Install(Plugin plugin);
        /// <summary>
        /// Uninstalls an installed plugin.
        /// </summary>
        void Uninstall(Plugin plugin);
    }
}
