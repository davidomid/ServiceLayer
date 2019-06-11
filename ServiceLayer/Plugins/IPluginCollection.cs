using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IPluginCollection
    {
        IReadOnlyCollection<Plugin> Installed();
        Plugin FindByName(string name);
        void Install(Plugin plugin);
        void Uninstall(Plugin plugin);
    }
}
