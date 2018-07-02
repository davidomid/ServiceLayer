using ServiceLayer.Enums;

namespace ServiceLayer.Results.Implementations
{
    public class OkServiceResult : ServiceResult
    {
        public OkServiceResult() : base(ServiceResultTypes.Ok)
        {
        }
    }
}