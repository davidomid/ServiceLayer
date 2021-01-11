namespace ServiceLayer.Internal.Factories
{
    internal interface IFailureResultFactory
    {
        FailureResult Create();
        FailureResult<TErrorType> Create<TErrorType>(TErrorType errorDetails);
    }
}
