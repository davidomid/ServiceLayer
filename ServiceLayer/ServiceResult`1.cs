using System.Collections.Generic;

namespace ServiceLayer
{
    public class ServiceResult<T> : IServiceResult<T>
    {
        protected ServiceResult(ServiceResultTypes resultType, T data = default(T), params string[] errorMessages)
        {
            this.ResultType = resultType;
            this.ErrorMessages = errorMessages;
            this.Data = data;
        }

        public string[] ErrorMessages { get; }
        public T Data { get; }

        public ServiceResultTypes ResultType { get; }

        IEnumerable<string> IServiceResult.ErrorMessages => this.ErrorMessages;

        public static implicit operator ServiceResult<T>(ServiceResult serviceResult)
        {
            return new ServiceResult<T>(serviceResult.ResultType, default(T), serviceResult.ErrorMessages);
        }

        public static implicit operator ServiceResult(ServiceResult<T> serviceResult)
        {
            return new ServiceResult(serviceResult.ResultType, serviceResult.ErrorMessages);
        }
    }
}