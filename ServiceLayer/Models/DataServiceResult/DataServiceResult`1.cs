namespace ServiceLayer
{
    public class DataServiceResult<TData> : DataServiceResult<TData, ServiceResultTypes>
    {
        public DataServiceResult(TData data, ServiceResultTypes resultType) : base(data, resultType, null)
        {
        }

        public DataServiceResult(TData data, ServiceResultTypes resultType, params object[] errorDetails) : base(data, resultType, errorDetails)
        {
        }

        public static implicit operator DataServiceResult<TData>(TData data)
        {
            return new SuccessResult<TData>(data);
        }

        public static implicit operator DataServiceResult<TData>(FailureResult failureResult)
        {
            return new DataServiceResult<TData>(default, ServiceResultTypes.Failure, failureResult.ErrorDetails);
        }

        public static implicit operator DataServiceResult<TData>(ServiceResultTypes resultType)
        {
            return new DataServiceResult<TData>(default, resultType);
        }
    }
}