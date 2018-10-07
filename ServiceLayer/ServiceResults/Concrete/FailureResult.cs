namespace ServiceLayer
{
    public class FailureResult : ServiceResult<ServiceResultTypes>
    {
        public FailureResult(params string[] errorMessages) : base(ServiceResultTypes.Failure, errorMessages)
        {

        }
    }
}
