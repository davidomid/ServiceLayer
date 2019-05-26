namespace ServiceLayer.Core.Internal
{
    internal interface IServiceLocator
    {
        T Resolve<T>() where T : class;
    }
}
