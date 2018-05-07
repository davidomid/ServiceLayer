using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public class ServiceResult : IServiceResult
    {
        public ServiceResult(ServiceResultTypes resultType, IEnumerable<string> errorMessages = null) : this(resultType,
            errorMessages?.ToArray())
        {
        }

        public ServiceResult(ServiceResultTypes resultType, params string[] errorMessages)
        {
            this.ResultType = resultType;
            this.ErrorMessages = errorMessages;
        }

        public string[] ErrorMessages { get; }

        public ServiceResultTypes ResultType { get; }

        IEnumerable<string> IServiceResult.ErrorMessages => this.ErrorMessages;
    }
}