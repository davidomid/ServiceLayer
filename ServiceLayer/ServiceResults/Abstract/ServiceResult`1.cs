using System;

namespace ServiceLayer
{
    public abstract class ServiceResult<TResultType> : ServiceResult, IServiceResult<TResultType> where TResultType : Enum
    {
        protected ServiceResult(TResultType resultType, params string[] errorMessages) : base(resultType.ToServiceResultType(), errorMessages)
        {
            this.ResultType = resultType;
        }

        public new TResultType ResultType { get; }

    }
}