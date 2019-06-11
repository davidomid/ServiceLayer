using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ServiceLayer.Internal.Plugins
{
    internal class PluginCollection : IPluginCollection
    {
        private readonly List<Plugin> _installedPlugins = new List<Plugin>();

        public IReadOnlyCollection<Plugin> Installed()
        {
            return new ReadOnlyCollection<Plugin>(_installedPlugins);
        }

        public Plugin FindByName(string name)
        {
            return _installedPlugins.FirstOrDefault(p => p.Name == name);
        }

        public void Install(Plugin plugin)
        {
            if (_installedPlugins.Contains(plugin))
            {
                return;
            }

            Plugin existingPlugin = FindByName(plugin.Name);
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
