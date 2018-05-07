namespace ServiceLayer
{
    public class ErrorResult : ServiceResult
    {
        public ErrorResult(params string[] errorMessages) : base(ServiceResultTypes.Error, errorMessages)
        {
        }
    }
}