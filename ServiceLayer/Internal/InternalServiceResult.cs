using System.Collections.Generic;

namespace ServiceLayer.Internal
{
    internal sealed class InternalServiceResult : ServiceResult
    {
        public InternalServiceResult(ServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {
        }
    }
}
