using System.Collections.Generic;

namespace ServiceLayer
{
    public class ServiceResult : IServiceResult
    {
        public ServiceResult(ServiceResultTypes resultType, params string[] errorMessages)
        {
            ResultType = resultType;
            ErrorMessages = errorMessages;
        }

        public string[] ErrorMessages { get; }

        public bool IsSuccessful => this.ResultType == ServiceResultTypes.Success;

        public ServiceResultTypes ResultType { get; }

        IEnumerable<string> IServiceResult.ErrorMessages => this.ErrorMessages;
    }
}