using System;

namespace ServiceLayer
{
    public abstract class BaseServiceResult<TResultType, TData> : BaseServiceResult<TResultType> where TResultType : Enum
    {
        protected BaseServiceResult(TResultType resultType, TData data, params string[] errorMessages) : base(resultType, errorMessages)
        {
            this.Data = data;
        }

        public TData Data { get; }
    }
}