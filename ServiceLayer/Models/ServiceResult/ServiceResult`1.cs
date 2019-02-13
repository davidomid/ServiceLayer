using System;
namespace ServiceLayer
{
    public class ServiceResult<TResultType> : ServiceResult, IServiceResult<TResultType> where TResultType : Enum
    {
        public ServiceResult(TResultType resultType) : this(resultType, null)
        {
        }

        public ServiceResult(TResultType resultType, params object[] errorDetails) : base(resultType.ToServiceResultType(), errorDetails)
        {
            ResultType = resultType;
        }

        public new TResultType ResultType { get; }
    }
}