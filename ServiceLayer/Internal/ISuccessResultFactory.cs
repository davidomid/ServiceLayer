namespace ServiceLayer.Internal
{
    internal interface ISuccessResultFactory
    {
        SuccessResult Create();
        SuccessResult<TData> Create<TData>(TData data);
    }
}
