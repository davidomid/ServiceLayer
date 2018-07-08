namespace ServiceLayer
{
    public class ServiceErrorResult : ErrorResult
    {
        public ServiceErrorResult(params string[] errorMessages) : base(ServiceResultTypes.ServiceError, errorMessages)
        {

        }
    }
}