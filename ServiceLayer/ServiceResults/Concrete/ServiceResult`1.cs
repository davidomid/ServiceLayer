namespace ServiceLayer
{
    public class ServiceResult<TData> : ServiceResult, IServiceResult<TData>
    {
        public ServiceResult(ServiceResultTypes resultType, TData data, params string[] errorMessages) : base(resultType, errorMessages)
        {
            this.Data = data;
        }

        public TData Data { get; }
    }
}