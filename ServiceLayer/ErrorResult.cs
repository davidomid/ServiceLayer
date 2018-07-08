namespace ServiceLayer
{
    public abstract class ErrorResult : ServiceResult
    {
        protected ErrorResult(ServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {
        }
    }
}