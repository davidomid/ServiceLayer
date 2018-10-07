using System;

namespace ServiceLayer
{
    public class CustomResult<TResultType> : ServiceResult<TResultType> where TResultType : Enum
    {
        public CustomResult(TResultType resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {

        }
    }
}
