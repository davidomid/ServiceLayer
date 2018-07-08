namespace ServiceLayer
{
    public class NotFoundResult : ErrorResult
    {
        public NotFoundResult() : base(ServiceResultTypes.NotFound)
        {
        }
    }
}