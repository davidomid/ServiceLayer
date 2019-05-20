namespace ServiceLayer.Internal.Factories
{
    internal class SuccessResultFactory : ISuccessResultFactory
    {
        public SuccessResult Create()
        {
            return new SuccessResult();
        }

        public SuccessResult<TData> Create<TData>(TData data)
        {
            return new SuccessResult<TData>(data);
        }
    }
}
