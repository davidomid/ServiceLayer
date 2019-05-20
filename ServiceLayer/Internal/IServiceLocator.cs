namespace ServiceLayer.Internal
{
    internal interface IServiceLocator
    {
        T Resolve<T>() where T : class;
    }
}
