using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IPluginCollection
    {
        IReadOnlyCollection<Plugin> Installed();
        void Install(Plugin plugin);
        void Uninstall(Plugin plugin);
    }
}
