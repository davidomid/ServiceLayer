using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public abstract class ServiceResult : IServiceResult
    {
        protected ServiceResult(ServiceResultTypes resultType, IEnumerable<string> errorMessages = null) : this(resultType,
            errorMessages?.ToArray())
        {
        }

        protected ServiceResult(ServiceResultTypes resultType, params string[] errorMessages)
        {
            this.ResultType = resultType;
            this.ErrorMessages = errorMessages;
        }

        public string[] ErrorMessages { get; }

        public ServiceResultTypes ResultType { get; }

        IEnumerable<string> IServiceResult.ErrorMessages => this.ErrorMessages;

        public static ServiceResult FromServiceResult(IServiceResult serviceResult)
        {
            return serviceResult.ToServiceResult();
        }

        public static ServiceResult FromServiceResult<T>(IServiceResult<T> serviceResult)
        {
            return serviceResult.ToServiceResult();
        }

        public static ServiceResult Create(ServiceResultTypes resultType, params string[] errorMessages)
        {
            return new InternalServiceResult(resultType, errorMessages);
        }

        public static ServiceResult Create(ServiceResultTypes resultType, IEnumerable<string> errorMessages = null)
        {
            return new InternalServiceResult(resultType, errorMessages);
        }
    }
}