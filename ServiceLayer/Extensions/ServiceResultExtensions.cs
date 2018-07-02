
using ServiceLayer.Results;
using ServiceLayer.Results.Implementations;
using ServiceLayer.Results.Implementations.Internal;

namespace ServiceLayer.Extensions
{
    public static class ServiceResultExtensions
    {
        internal static ServiceResult<T> ToGenericServiceResult<T>(this IServiceResult serviceResult)
        {
            return new InternalServiceResult<T>(serviceResult.ResultType, default(T), serviceResult.ErrorMessages); 
        }

        internal static ServiceResult ToNonGenericServiceResult<T>(this IServiceResult<T> serviceResult)
        {
            return new InternalServiceResult(serviceResult.ResultType, serviceResult.ErrorMessages);
        }

        public static ServiceResult<T> ToServiceResult<T>(this T data)
        {
            return new OkServiceResult<T>(data);
        }

        public static ServiceResult<T> ToServiceResult<T>(this IServiceResult<T> serviceResult)
        {
            return new InternalServiceResult<T>(serviceResult.ResultType, serviceResult.Data, serviceResult.ErrorMessages); 
        }

        public static ServiceResult<T> ToServiceResult<T>(this IServiceResult serviceResult)
        {
            return serviceResult.ToGenericServiceResult<T>(); 
        }

        public static ServiceResult ToServiceResult(this IServiceResult serviceResult)
        {
            return new InternalServiceResult(serviceResult.ResultType, serviceResult.ErrorMessages);
        }
    }
}
