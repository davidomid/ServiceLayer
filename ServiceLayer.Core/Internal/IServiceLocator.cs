namespace ServiceLayer.Core.Internal
{
    internal interface IServiceLocator
    {
        void Register<T>(T component) where T : class;
        T Resolve<T>() where T : class;
    }
}
