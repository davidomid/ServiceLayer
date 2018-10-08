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

        public static FailureResult Failure(this IService service, params string[] errorMessages)
        {
            return new FailureResult(errorMessages);
        }

        public static ServiceResult Result(this IService service, ServiceResultTypes resultType, params string[] errorMessages)
        {
            return new ServiceResult(resultType, errorMessages);
        }

        public static ServiceResult<TData> Result<TData>(this IService service, ServiceResultTypes resultType, TData data, params string[] errorMessages)
        {
            return new ServiceResult<TData>(resultType, data, errorMessages);
        }

        public static ServiceResult<TData, TResultType> Result<TResultType, TData>(this IService service, TResultType resultType, TData data, params string[] errorMessages) where TResultType : Enum
        {
            return new ServiceResult<TData, TResultType>(resultType, data, errorMessages);
        }

    }
}
