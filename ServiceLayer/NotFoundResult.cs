namespace ServiceLayer
{
    public sealed class NotFoundResult : ErrorResult
    {
        public NotFoundResult() : base(ServiceResultTypes.NotFound)
        {
        }
    }
}