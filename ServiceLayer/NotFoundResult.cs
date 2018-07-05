namespace ServiceLayer
{
    public class NotFoundResult : ServiceResult
    {
        public NotFoundResult() : base(ServiceResultTypes.NotFound)
        {
        }
    }
}