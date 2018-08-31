using ServiceLayer.Internal;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public abstract class ServiceResult<T> : ServiceResult, IServiceResult<T>
    {
        protected ServiceResult(ServiceResultTypes resultType, T data = default(T), params string[] errorMessages) : base(resultType, errorMessages)
        {
            Data = data;
        }

        public T Data { get; }

        public static implicit operator ServiceResult<T>(ErrorResult errorResult)
        {
            return Create(errorResult);
        }

        public static implicit operator T(ServiceResult<T> serviceResult)
        {
            return serviceResult.Data; 
        }

        public static ServiceResult<T> Create(IServiceResult<T> serviceResult)
        {
            return Create(serviceResult.ResultType, serviceResult.Data, serviceResult.ErrorMessages);
        }

        public new static ServiceResult<T> Create(IServiceResult serviceResult)
        {
            return Create(serviceResult.ResultType, errorMessages: serviceResult.ErrorMessages);
        }

        public static ServiceResult<T> Create(ServiceResultTypes resultType, T data = default(T), params string[] errorMessages)
        {
            return new InternalServiceResult<T>(resultType, data, errorMessages);
        }

        private static ServiceResult<T> Create(ServiceResultTypes resultType, T data = default(T), IEnumerable<string> errorMessages = null)
        {
            return Create(resultType, data, errorMessages?.ToArray()); 
        }
    }
}