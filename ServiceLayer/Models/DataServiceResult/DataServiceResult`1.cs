namespace ServiceLayer
{
    public class DataServiceResult<TData> : DataServiceResult<TData, ServiceResultTypes>
    {
        public DataServiceResult(ServiceResultTypes resultType, TData data, params string[] errorMessages) : base(resultType, data, errorMessages)
        {
        }
    }
}