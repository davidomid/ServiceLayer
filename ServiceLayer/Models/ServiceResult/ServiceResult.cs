namespace ServiceLayer
{
    public class ServiceResult : ServiceResult<ServiceResultTypes>
    {
        public ServiceResult(ServiceResultTypes resultType) : this(resultType, null)
        {
        }

        public ServiceResult(ServiceResultTypes resultType, params object[] errorDetails) : base(resultType, errorDetails)
        {
        }
    }
}