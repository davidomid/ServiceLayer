using ServiceLayer.Enums;

namespace ServiceLayer.Results.Implementations
{
    public class NotFoundResult : ServiceResult
    {
        public NotFoundResult() : base(ServiceResultTypes.NotFound)
        {
        }
    }
}