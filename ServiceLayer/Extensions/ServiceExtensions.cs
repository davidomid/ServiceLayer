using System;

namespace ServiceLayer
{
    public static class ServiceExtensions
    {
        public static SuccessResult Success(this IService service)
        {
            return new SuccessResult();
        }

        public static SuccessResult<TData> Success<TData>(this IService service, TData data)
        {
            return new SuccessResult<TData>(data);
        }

        public static FailureResult Failure(this IService service, params object[] errorDetails)
        {
            return new FailureResult(errorDetails);
        }

        public static ServiceResult Result(this IService service, ServiceResultTypes resultType, params object[] errorDetails)
        {
            return new ServiceResult(resultType, errorDetails);
        }

        public static ServiceResult<TResultType> Result<TResultType>(this IService service, TResultType resultType, params object[] errorDetails) where TResultType : Enum
        {
            return new ServiceResult<TResultType>(resultType, errorDetails);
        }

        public static DataServiceResult<TData> DataResult<TData>(this IService service, TData data, ServiceResultTypes resultType, params object[] errorDetails)
        {
            return new DataServiceResult<TData>(data, resultType, errorDetails);
        }

        public static DataServiceResult<TData, TResultType> DataResult<TData, TResultType>(this IService service, TData data, TResultType resultType, params object[] errorDetails) where TResultType : Enum
        {
            return new DataServiceResult<TData, TResultType>(data, resultType, errorDetails);
        }
    }
}
