using ServiceLayer.Internal;
using System.Linq;

namespace ServiceLayer
{
    public static class ServiceResultExtensions
    {
        internal static ServiceResult<T> ToGenericServiceResult<T>(this ServiceResult serviceResult)
        {
            return new InternalServiceResult<T>(serviceResult.ResultType, default(T), serviceResult.ErrorMessages?.ToArray());
        }

        public static ServiceResult<T> ToServiceResult<T>(this T data)
        {
            return new OkResult<T>(data);
        }
    }
}
