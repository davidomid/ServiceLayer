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

        public static FailureResult Failure(this IService service)
        {
            return new FailureResult();
        }

        public static FailureResult Failure(this IService service, params object[] errorDetails)
        {
            return new FailureResult(errorDetails);
        }

        public static FailureResult<TErrorType> Failure<TErrorType>(this IService service, TErrorType errorDetails = default)
        {
            return new FailureResult<TErrorType>(errorDetails);
        }

        public static ServiceResult Result(this IService service, ServiceResultTypes resultType)
        {
            return new ServiceResult(resultType);
        }
        public static ServiceResult Result(this IService service, ServiceResultTypes resultType, params object[] errorDetails)
        {
            return new ServiceResult(resultType, errorDetails);
        }

        public static ServiceResult<TResultType> Result<TResultType>(this IService service, TResultType resultType) where TResultType : Enum
        {
            return new ServiceResult<TResultType>(resultType);
        }
        public static ServiceResult<TResultType> Result<TResultType>(this IService service, TResultType resultType, params object[] errorDetails) where TResultType : Enum
        {
            return new ServiceResult<TResultType>(resultType, errorDetails);
        }
        public static ServiceResult<TResultType, TErrorType> Result<TResultType, TErrorType>(this IService service, TResultType resultType, TErrorType errorDetails = default) where TResultType : Enum
        {
            return new ServiceResult<TResultType, TErrorType>(resultType, errorDetails);
        }

        public static DataServiceResult<TData> DataResult<TData>(this IService service, TData data, ServiceResultTypes resultType)
        {
            return new DataServiceResult<TData>(data, resultType);
        }
        public static DataServiceResult<TData> DataResult<TData>(this IService service, TData data, ServiceResultTypes resultType, params object[] errorDetails)
        {
            return new DataServiceResult<TData>(data, resultType, errorDetails);
        }
        public static DataServiceResult<TData, TResultType> DataResult<TData, TResultType>(this IService service, TData data, TResultType resultType) where TResultType : Enum
        {
            return new DataServiceResult<TData, TResultType>(data, resultType);
        }
        public static DataServiceResult<TData, TResultType> DataResult<TData, TResultType>(this IService service, TData data, TResultType resultType, params object[] errorDetails) where TResultType : Enum
        {
            return new DataServiceResult<TData, TResultType>(data, resultType, errorDetails);
        }
        public static DataServiceResult<TData, TResultType, TErrorType> DataResult<TData, TResultType, TErrorType>(this IService service, TData data, TResultType resultType) where TResultType : Enum
        {
            return new DataServiceResult<TData, TResultType, TErrorType>(data, resultType);
        }
        public static DataServiceResult<TData, TResultType, TErrorType> DataResult<TData, TResultType, TErrorType>(this IService service, TData data, TResultType resultType, TErrorType errorDetails) where TResultType : Enum
        {
            return new DataServiceResult<TData, TResultType, TErrorType>(data, resultType, errorDetails);
        }
    }
}
