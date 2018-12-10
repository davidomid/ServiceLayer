namespace ServiceLayer
{
    public class ServiceResult : ServiceResult<ServiceResultTypes>
    {
        public ServiceResult(ServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {
        }
    }
}