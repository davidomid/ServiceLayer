namespace ServiceLayer
{
    public class DataServiceResult<TData> : ServiceResult<ServiceResultTypes, object>, IDataServiceResult<TData>
    {
        public DataServiceResult(TData data, ServiceResultTypes resultType) : this(data, resultType, null)
        {
        }

        public DataServiceResult(TData data, ServiceResultTypes resultType, params object[] errorDetails) : this(data, resultType, (object)errorDetails)
        {
        }

        public DataServiceResult(TData data, ServiceResultTypes resultType, object errorDetails) : base(resultType, errorDetails)
        {
            Data = data;
        }

        public TData Data { get; }

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