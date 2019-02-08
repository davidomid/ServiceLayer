using System;
namespace ServiceLayer
{
    public class ServiceResult<TResultType> : ServiceResult<TResultType, object> where TResultType : Enum
    {
        public ServiceResult(TResultType resultType) : this(resultType, null)
        {
        }

        public ServiceResult(TResultType resultType, params object[] errorDetails) : base(resultType, errorDetails)
        {
        }
    }
}