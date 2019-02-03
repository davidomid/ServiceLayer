using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public class FailureResult : ServiceResult
    {
        public FailureResult(params string[] errorMessages) : this(errorMessages.AsEnumerable())
        {
        }

        public FailureResult(IEnumerable<string> errorMessages) : base(ServiceResultTypes.Failure, errorMessages)
        {
        }
    }
}
