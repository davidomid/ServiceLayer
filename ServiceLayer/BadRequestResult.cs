namespace ServiceLayer
{
    public sealed class BadRequestResult : ErrorResult
    {
        public BadRequestResult(params string[] errorMessages) : base(ServiceResultTypes.BadRequest, errorMessages)
        {
        }
    }
}