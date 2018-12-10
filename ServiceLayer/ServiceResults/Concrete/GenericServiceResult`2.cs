using System;

namespace ServiceLayer
{
    public class GenericServiceResult<TResultType, TData> : GenericServiceResult<TResultType> where TResultType : Enum
    {
        protected GenericServiceResult(TResultType resultType, TData data, params string[] errorMessages) : base(resultType, errorMessages)
        {
            this.Data = data;
        }

        public TData Data { get; }
    }
}