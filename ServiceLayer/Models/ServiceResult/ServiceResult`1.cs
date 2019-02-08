using System;
namespace ServiceLayer
{
    public class ServiceResult<TResultType> : IServiceResult<TResultType> where TResultType : Enum
    {
        public ServiceResult(TResultType resultType) : this(resultType, null)
        {
        }

        public ServiceResult(TResultType resultType, params object[] errorDetails) 
        {
            this.ResultType = resultType;
            this.ErrorDetails = errorDetails;
        }

        public TResultType ResultType { get; }
        public object ErrorDetails { get; }
        public bool IsSuccessful => ResultType.ToServiceResultType() == ServiceResultTypes.Success;
        ServiceResultTypes IServiceResult.ResultType => ResultType.ToServiceResultType();
    }
}