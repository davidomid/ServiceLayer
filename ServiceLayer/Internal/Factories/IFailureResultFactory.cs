namespace ServiceLayer.Internal.Factories
{
    internal interface IFailureResultFactory
    {
        FailureResult Create();
        FailureResult Create(object[] errorDetails);
        FailureResult<TErrorType> Create<TErrorType>(TErrorType errorDetails);
    }
}
