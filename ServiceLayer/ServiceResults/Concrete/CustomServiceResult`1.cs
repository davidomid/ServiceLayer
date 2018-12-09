using System;

namespace ServiceLayer
{
    public class CustomServiceResult<TResultType> : ServiceResult, ICustomServiceResult<TResultType> where TResultType : Enum
    {
        public CustomServiceResult(TResultType resultType, params string[] errorMessages) : base(resultType.ToServiceResultType(), errorMessages)
        {
            this.ResultType = resultType;
        }

        public new TResultType ResultType { get; }
    }
}