using System;
using ServiceLayer.Internal;
using ServiceLayer.Internal.Factories;

namespace ServiceLayer
{
    public static class ServiceExtensions
    {
        internal static IServiceResultFactory ServiceResultFactory = ServiceLocator.Instance.Resolve<IServiceResultFactory>();

        internal static IDataServiceResultFactory DataServiceResultFactory =
            ServiceLocator.Instance.Resolve<IDataServiceResultFactory>();

        internal static ISuccessResultFactory SuccessResultFactory =
            ServiceLocator.Instance.Resolve<ISuccessResultFactory>();

        internal static IFailureResultFactory FailureResultFactory =
            ServiceLocator.Instance.Resolve<IFailureResultFactory>(); 

        public static SuccessResult Success(this IService service)
        {
            return SuccessResultFactory.Create();
        }

        public static SuccessResult<TData> Success<TData>(this IService service, TData data)
        {
            return SuccessResultFactory.Create(data); 
        }

        public static FailureResult Failure(this IService service)
        {
            return FailureResultFactory.Create();
        }

        public static FailureResult Failure(this IService service, params object[] errorDetails)
        {
            return FailureResultFactory.Create(errorDetails);
        }

        public static FailureResult<TErrorType> Failure<TErrorType>(this IService service, TErrorType errorDetails = default)
        {
            return FailureResultFactory.Create(errorDetails);
        }

        public static ServiceResult Result(this IService service, ServiceResultTypes resultType)
        {
            return ServiceResultFactory.Create(resultType);
        }
        public static ServiceResult Result(this IService service, ServiceResultTypes resultType, params object[] errorDetails)
        {
            return ServiceResultFactory.Create(resultType, errorDetails);
        }

        public static ServiceResult<TResultType> Result<TResultType>(this IService service, TResultType resultType) where TResultType : Enum
        {
            return ServiceResultFactory.Create(resultType);
        }
        public static ServiceResult<TResultType> Result<TResultType>(this IService service, TResultType resultType, params object[] errorDetails) where TResultType : Enum
        {
            return ServiceResultFactory.Create(resultType, errorDetails);
        }
        public static ServiceResult<TResultType, TErrorType> Result<TResultType, TErrorType>(this IService service, TResultType resultType, TErrorType errorDetails = default) where TResultType : Enum
        {
            return ServiceResultFactory.Create(resultType, errorDetails);
        }

        public static DataServiceResult<TData> DataResult<TData>(this IService service, TData data)
        {
            return DataServiceResultFactory.Create(data);
        }
        public static DataServiceResult<TData> DataResult<TData>(this IService service, TData data, ServiceResultTypes resultType)
        {
            return DataServiceResultFactory.Create(data, resultType);
        }
        public static DataServiceResult<TData> DataResult<TData>(this IService service, TData data, ServiceResultTypes resultType, params object[] errorDetails)
        {
            return DataServiceResultFactory.Create(data, resultType, errorDetails);
        }
        public static DataServiceResult<TData, TResultType> DataResult<TData, TResultType>(this IService service, TData data) where TResultType : Enum
        {
            return DataServiceResultFactory.Create<TData, TResultType>(data);
        }
        public static DataServiceResult<TData, TResultType> DataResult<TData, TResultType>(this IService service, TData data, TResultType resultType) where TResultType : Enum
        {
            return DataServiceResultFactory.Create(data, resultType);
        }
        public static DataServiceResult<TData, TResultType> DataResult<TData, TResultType>(this IService service, TData data, TResultType resultType, params object[] errorDetails) where TResultType : Enum
        {
            return DataServiceResultFactory.Create(data, resultType, errorDetails);
        }
        public static DataServiceResult<TData, TResultType, TErrorType> DataResult<TData, TResultType, TErrorType>(this IService service, TData data) where TResultType : Enum
        {
            return DataServiceResultFactory.Create<TData, TResultType, TErrorType>(data);
        }
        public static DataServiceResult<TData, TResultType, TErrorType> DataResult<TData, TResultType, TErrorType>(this IService service, TData data, TResultType resultType) where TResultType : Enum
        {
            return DataServiceResultFactory.Create<TData, TResultType, TErrorType>(data, resultType);
        }
        public static DataServiceResult<TData, TResultType, TErrorType> DataResult<TData, TResultType, TErrorType>(this IService service, TData data, TResultType resultType, TErrorType errorDetails) where TResultType : Enum
        {
            return DataServiceResultFactory.Create(data, resultType, errorDetails);
        }
    }
}
