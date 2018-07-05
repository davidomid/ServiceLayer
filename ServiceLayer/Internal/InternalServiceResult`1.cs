using System.Collections.Generic;

namespace ServiceLayer.Internal
{
    internal sealed class InternalServiceResult<T> : ServiceResult<T>
    {
        public InternalServiceResult(ServiceResultTypes resultType, T data = default(T), params string[] errorMessages) : base(resultType, data, errorMessages)
        {
        }

        public InternalServiceResult(ServiceResultTypes resultType, T data = default(T), IEnumerable<string> errorMessages = null) : base(resultType, data, errorMessages)
        {
        }
    }
}
