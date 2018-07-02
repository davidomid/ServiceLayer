using ServiceLayer.Enums;

namespace ServiceLayer.Results.Implementations
{
    public class OkServiceResult<T> : ServiceResult<T>
    {
        public OkServiceResult(T data) : base(ServiceResultTypes.Ok, data)
        {
        }
    }
}