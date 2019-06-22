using ServiceLayer.Internal.Plugins;

namespace ServiceLayer
{
    public abstract class Plugin
    {
        protected Plugin(string name)
        {
            Name = name;
        }

        public string Name { get; }

        protected static IPluginContext Context { get; } = new PluginContext();

        public abstract void Install();

        public virtual void Uninstall()
        {
        }
    }
}
