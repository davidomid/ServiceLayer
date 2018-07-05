using ServiceLayer.Enums;

namespace ServiceLayer.Results.Implementations
{
    public class OkResult<T> : ServiceResult<T>
    {
        public OkResult(T data) : base(ServiceResultTypes.Ok, data)
        {
        }
    }
}