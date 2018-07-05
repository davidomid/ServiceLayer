namespace ServiceLayer
{
    public class BadRequestResult : ServiceResult
    {
        public BadRequestResult(params string[] errorMessages) : base(ServiceResultTypes.BadRequest, errorMessages)
        {
        }
    }
}