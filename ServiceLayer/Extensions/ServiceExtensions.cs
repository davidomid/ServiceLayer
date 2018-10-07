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

        public static FailureResult<TData> Failure<TData>(this IService service, params string[] errorMessages)
        {
            return new FailureResult<TData>(errorMessages);
        }

        public static CustomResult<TResultType> Result<TResultType>(this IService service, TResultType resultType, params string[] errorMessages) where TResultType : Enum
        {
            return new CustomResult<TResultType>(resultType, errorMessages);
        }

        public static CustomResult<TResultType, TData> Result<TResultType, TData>(this IService service, TResultType resultType, TData data, params string[] errorMessages) where TResultType : Enum
        {
            return new CustomResult<TResultType, TData>(resultType, data, errorMessages);
        }

    }
}
