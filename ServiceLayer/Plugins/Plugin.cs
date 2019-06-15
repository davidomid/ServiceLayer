namespace ServiceLayer
{
    public abstract class Plugin
    {
        protected Plugin(string name)
        {
            Name = name;
        }

        public string Name { get; }

        protected Context Context { get; } = new Context();

        public abstract void Install();

        public virtual void Uninstall()
        {
        }
    }
}
