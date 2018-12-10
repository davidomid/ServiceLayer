namespace ServiceLayer
{
    public class FailureResult : ServiceResult
    {
        public FailureResult(params string[] errorMessages) : base(ServiceResultTypes.Failure, errorMessages)
        {

        }
    }
}
