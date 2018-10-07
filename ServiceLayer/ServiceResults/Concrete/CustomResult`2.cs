using System;

namespace ServiceLayer
{
    public class CustomResult<TResultType, TData> : ServiceResult<TResultType, TData> where TResultType : Enum
    {
        public CustomResult(TResultType resultType, TData data, params string[] errorMessages) : base(resultType, data, errorMessages)
        {
        }
    }
}
