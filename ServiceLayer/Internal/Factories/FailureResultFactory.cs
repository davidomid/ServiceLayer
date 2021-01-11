namespace ServiceLayer.Internal.Factories
{
    internal class FailureResultFactory : IFailureResultFactory
    {
        public FailureResult Create()
        {
            return new FailureResult();
        }

        public FailureResult<TErrorType> Create<TErrorType>(TErrorType errorDetails)
        {
            return new FailureResult<TErrorType>(errorDetails);
        }
    }
}
