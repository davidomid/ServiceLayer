namespace ServiceLayer
{
    public class CustomResult<TData> : CustomResult<TData, ServiceResultTypes> 
    {
        public CustomResult(ServiceResultTypes resultType, TData data, params string[] errorMessages) : base(resultType, data, errorMessages)
        {
        }
    }
}
