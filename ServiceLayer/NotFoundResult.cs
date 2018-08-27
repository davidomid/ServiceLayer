namespace ServiceLayer
{
    public class NotFoundResult : ErrorResult
    {
        public NotFoundResult(params string[] errorMessages) : base(ServiceResultTypes.NotFound, errorMessages)
        {
        }
    }
}