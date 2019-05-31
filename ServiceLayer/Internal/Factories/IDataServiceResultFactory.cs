using System;

namespace ServiceLayer.Internal.Factories
{
    internal interface IDataServiceResultFactory
    {
        DataServiceResult<TData> Create<TData>(TData data);
        DataServiceResult<TData> Create<TData>(FailureResult failureResult);
        DataServiceResult<TData> Create<TData>(ServiceResultTypes resultType);

        DataServiceResult<TData, TResultType> Create<TData, TResultType>(TResultType resultType) where TResultType : struct, Enum;
        DataServiceResult<TData, TResultType> Create<TData, TResultType>(TData data) where TResultType : struct, Enum;
        DataServiceResult<TData, TResultType> Create<TData, TResultType>(FailureResult failureResult) where TResultType : struct, Enum;
        DataServiceResult<TData, TResultType> Create<TData, TResultType>(SuccessResult<TData> successResult) where TResultType : struct, Enum;
        DataServiceResult<TData, TResultType> Create<TData, TResultType>(TData data, TResultType resultType) where TResultType : struct, Enum;
        DataServiceResult<TData, TResultType> Create<TData, TResultType> (ServiceResult<TResultType> serviceResult) where TResultType : struct, Enum;
        DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TData data) where TResultType : struct, Enum;
        DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(FailureResult<TErrorType> failureResult) where TResultType : struct, Enum;
        DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(SuccessResult<TData> successResult) where TResultType : struct, Enum;
        DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TResultType resultType) where TResultType : struct, Enum;
        DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TErrorType errorDetails) where TResultType : struct, Enum;
        DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TData data, TResultType resultType, TErrorType errorDetails = default) where TResultType : struct, Enum;
    }
}
