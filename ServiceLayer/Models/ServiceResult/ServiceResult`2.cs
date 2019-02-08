using System;
namespace ServiceLayer
{
    public class ServiceResult<TResultType, TErrorType> : IServiceResult<TResultType, TErrorType> where TResultType : Enum
    {
        public ServiceResult(TResultType resultType, TErrorType errorDetails = default) 
        {
            this.ResultType = resultType;
            this.ErrorDetails = errorDetails;
        }

        public TResultType ResultType { get; }
        ServiceResultTypes IServiceResult.ResultType => ResultType.ToServiceResultType();

        public TErrorType ErrorDetails { get; }
        object IServiceResult.ErrorDetails => ErrorDetails;

        public bool IsSuccessful => ResultType.ToServiceResultType() == ServiceResultTypes.Success;
    }
}