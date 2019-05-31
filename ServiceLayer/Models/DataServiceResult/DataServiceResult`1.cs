namespace ServiceLayer
{
    public class DataServiceResult<TData> : ServiceResult<ServiceResultTypes, object>, IDataServiceResult<TData>
    {
        public DataServiceResult(TData data, ServiceResultTypes resultType) : this(data, resultType, default)
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
            return ServiceLayerConfiguration.DataServiceResultFactory.Create(data);
        }

        public static implicit operator DataServiceResult<TData>(FailureResult failureResult)
        {
            return ServiceLayerConfiguration.DataServiceResultFactory.Create<TData>(failureResult);
        }

        public static implicit operator DataServiceResult<TData>(ServiceResultTypes resultType)
        {
            return ServiceLayerConfiguration.DataServiceResultFactory.Create<TData>(resultType);
        }
    }
}