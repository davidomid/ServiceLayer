using System;
namespace ServiceLayer
{
    public class ServiceResult<TResultType, TErrorType> : ServiceResult<TResultType>, IServiceResult<TResultType, TErrorType> where TResultType : Enum
    {
        public ServiceResult(TResultType resultType, TErrorType errorDetails = default) : base(resultType, errorDetails)
        {
            ErrorDetails = errorDetails;
        }

        public new TErrorType ErrorDetails { get; }
    }
}