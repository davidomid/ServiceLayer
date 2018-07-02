using System.Collections.Generic;

namespace ServiceLayer
{
    internal sealed class InternalServiceResult : ServiceResult
    {
        public InternalServiceResult(ServiceResultTypes resultType, IEnumerable<string> errorMessages = null) : base(resultType, errorMessages)
        {
        }
        public InternalServiceResult(ServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {
        }
    }
}
