namespace ServiceLayer
{
    public class DataServiceResult<TData> : DataServiceResult<TData, ServiceResultTypes>
    {
        public DataServiceResult(TData data, ServiceResultTypes resultType, params string[] errorMessages) : base(data, resultType, errorMessages)
        {
        }
    }
}