using System;

namespace ServiceLayer
{
    public class ServiceResult<TData, TResultType> : ServiceResult<TData>, IServiceResult<TData, TResultType> where TResultType : Enum
    {
        public ServiceResult(TResultType resultType, TData data, params string[] errorMessages) : base(resultType.ToServiceResultType(), data, errorMessages)
        {
            this.ResultType = resultType;
        }

        public new TResultType ResultType { get; }
    }
}