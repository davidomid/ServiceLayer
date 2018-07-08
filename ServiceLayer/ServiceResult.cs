using System.Collections.Generic;

namespace ServiceLayer
{
    public abstract class ServiceResult : IServiceResult
    {
        protected ServiceResult(ServiceResultTypes resultType, params string[] errorMessages)
        {
            this.ResultType = resultType;
            this.ErrorMessages = errorMessages;
        }

        public string[] ErrorMessages { get; }

        public ServiceResultTypes ResultType { get; }

        IEnumerable<string> IServiceResult.ErrorMessages => this.ErrorMessages;
    }
}