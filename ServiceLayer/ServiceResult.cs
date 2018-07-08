using ServiceLayer.Internal;
using System.Collections.Generic;
using System.Linq;

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

        public static ServiceResult Create(IServiceResult serviceResult)
        {
            return Create(serviceResult.ResultType, serviceResult.ErrorMessages?.ToArray());
        }

        public static ServiceResult Create(ServiceResultTypes resultType, params string[] errorMessages)
        {
            return new InternalServiceResult(resultType, errorMessages);
        }
    }
}