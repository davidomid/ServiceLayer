using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ServiceLayer.Internal.Plugins
{
    internal class PluginCollection : IPluginCollection
    {
        private readonly List<Plugin> _installedPlugins = new List<Plugin>();

        public IReadOnlyCollection<Plugin> Installed => new ReadOnlyCollection<Plugin>(_installedPlugins);

        public void Install(Plugin plugin)
        {
            if (_installedPlugins.Contains(plugin))
            {
                return;
            }

            Plugin existingPlugin = _installedPlugins.FirstOrDefault(p => p.Name == plugin.Name);
            if (existingPlugin != null)
            {
                Uninstall(existingPlugin);
            }
            plugin.Install();
            _installedPlugins.Add(plugin);
        }

        public void Uninstall(Plugin plugin)
        {
            if (_installedPlugins.Contains(plugin))
            {
                plugin.Uninstall();
                _installedPlugins.Remove(plugin);
            }
        }
    }
}
