namespace ServiceLayer.Internal
{
    internal class FailureResultFactory : IFailureResultFactory
    {
        public FailureResult Create()
        {
            return new FailureResult();
        }

        public FailureResult Create(object[] errorDetails)
        {
            return new FailureResult(errorDetails);
        }

        public FailureResult<TErrorType> Create<TErrorType>(TErrorType errorDetails)
        {
            return new FailureResult<TErrorType>(errorDetails);
        }
    }
}
