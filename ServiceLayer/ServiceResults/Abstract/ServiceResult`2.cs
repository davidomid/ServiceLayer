using System;

namespace ServiceLayer
{
    public abstract class ServiceResult<TResultType, TData> : ServiceResult<TResultType>, IServiceResult<TResultType, TData> where TResultType : Enum
    {
        protected ServiceResult(TResultType resultType, TData data = default, params string[] errorMessages) : base(resultType, errorMessages)
        {
            this.Data = data;
        }

        public TData Data { get; }
    }
}