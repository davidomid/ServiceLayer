using System;
using System.Collections.Generic;

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

        public static FailureResult Failure(this IService service, IEnumerable<string> errorMessages)
        {
            return new FailureResult(errorMessages);
        }

        public static ServiceResult Result(this IService service, ServiceResultTypes resultType, params string[] errorMessages)
        {
            return new ServiceResult(resultType, errorMessages);
        }

        public static ServiceResult Result(this IService service, ServiceResultTypes resultType, IEnumerable<string> errorMessages)
        {
            return new ServiceResult(resultType, errorMessages);
        }

        public static ServiceResult<TResultType> Result<TResultType>(this IService service, TResultType resultType, params string[] errorMessages) where TResultType : Enum
        {
            return new ServiceResult<TResultType>(resultType, errorMessages);
        }

        public static ServiceResult<TResultType> Result<TResultType>(this IService service, TResultType resultType, IEnumerable<string> errorMessages) where TResultType : Enum
        {
            return new ServiceResult<TResultType>(resultType, errorMessages);
        }

        public static DataServiceResult<TData> DataResult<TData>(this IService service, TData data, ServiceResultTypes resultType, params string[] errorMessages)
        {
            return new DataServiceResult<TData>(data, resultType, errorMessages);
        }

        public static DataServiceResult<TData> DataResult<TData>(this IService service, TData data, ServiceResultTypes resultType, IEnumerable<string> errorMessages)
        {
            return new DataServiceResult<TData>(data, resultType, errorMessages);
        }

        public static DataServiceResult<TData, TResultType> DataResult<TData, TResultType>(this IService service, TData data, TResultType resultType, params string[] errorMessages) where TResultType : Enum
        {
            return new DataServiceResult<TData, TResultType>(data, resultType, errorMessages);
        }

        public static DataServiceResult<TData, TResultType> DataResult<TData, TResultType>(this IService service, TData data, TResultType resultType, IEnumerable<string> errorMessages) where TResultType : Enum
        {
            return new DataServiceResult<TData, TResultType>(data, resultType, errorMessages);
        }
    }
}
