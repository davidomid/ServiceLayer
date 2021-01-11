using System;
using ServiceLayer.Internal;
using ServiceLayer.Internal.Factories;
using ServiceLayer.Models;

namespace ServiceLayer
{
    public static class ServiceExtensions
    {
        internal static IResultFactory ResultFactory = ServiceLocator.Instance.Resolve<IResultFactory>();

        internal static IDataResultFactory DataResultFactory =
            ServiceLocator.Instance.Resolve<IDataResultFactory>();

        internal static ISuccessResultFactory SuccessResultFactory =
            ServiceLocator.Instance.Resolve<ISuccessResultFactory>();

        internal static IFailureResultFactory FailureResultFactory =
            ServiceLocator.Instance.Resolve<IFailureResultFactory>();

        internal static IInconclusiveResultFactory InconclusiveResultFactory =
            ServiceLocator.Instance.Resolve<IInconclusiveResultFactory>();

        public static InconclusiveResult Inconclusive(this IService service)
        {
            return InconclusiveResultFactory.Create();
        }

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

        public static FailureResult<TErrorType> Failure<TErrorType>(this IService service, TErrorType errorDetails = default)
        {
            return FailureResultFactory.Create(errorDetails);
        }

        public static Result<TResultType> Result<TResultType>(this IService service, TResultType resultType) where TResultType : struct, Enum
        {
            return ResultFactory.Create(resultType);
        }

        public static Result<TResultType, TErrorType> Result<TResultType, TErrorType>(this IService service, TResultType resultType, TErrorType errorDetails = default) where TResultType : struct, Enum
        {
            return ResultFactory.Create(resultType, errorDetails);
        }

        public static DataResult<TData> DataResult<TData>(this IService service, TData data)
        {
            return DataResultFactory.Create(data);
        }
        public static DataResult<TData, TResultType> DataResult<TData, TResultType>(this IService service, TData data) where TResultType : struct, Enum
        {
            return DataResultFactory.Create<TData, TResultType>(data);
        }
        public static DataResult<TData, TResultType> DataResult<TData, TResultType>(this IService service, TData data, TResultType resultType) where TResultType : struct, Enum
        {
            return DataResultFactory.Create(data, resultType);
        }
        public static DataResult<TData, TResultType, TErrorType> DataResult<TData, TResultType, TErrorType>(this IService service, TData data) where TResultType : struct, Enum
        {
            return DataResultFactory.Create<TData, TResultType, TErrorType>(data);
        }
        public static DataResult<TData, TResultType, TErrorType> DataResult<TData, TResultType, TErrorType>(this IService service, TData data, TResultType resultType) where TResultType : struct, Enum
        {
            return DataResultFactory.Create<TData, TResultType, TErrorType>(data, resultType);
        }
        public static DataResult<TData, TResultType, TErrorType> DataResult<TData, TResultType, TErrorType>(this IService service, TData data, TResultType resultType, TErrorType errorDetails) where TResultType : struct, Enum
        {
            return DataResultFactory.Create(data, resultType, errorDetails);
        }
    }
}
