namespace ServiceLayer.Internal.Factories
{
    internal interface ISuccessResultFactory
    {
        SuccessResult Create();
        SuccessResult<TData> Create<TData>(TData data);
    }
}
