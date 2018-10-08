namespace ServiceLayer
{
    public class CustomResult : ServiceResult
    {
        public CustomResult(ServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {
        }
    }
}
