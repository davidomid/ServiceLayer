using ServiceLayer.Enums;

namespace ServiceLayer.Results.Implementations
{
    public class OkResult : ServiceResult
    {
        public OkResult() : base(ServiceResultTypes.Ok)
        {
        }
    }
}