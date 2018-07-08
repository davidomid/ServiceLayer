namespace ServiceLayer
{
    public class BadRequestResult : ErrorResult
    {
        public BadRequestResult(params string[] errorMessages) : base(ServiceResultTypes.BadRequest, errorMessages)
        {
        }
    }
}