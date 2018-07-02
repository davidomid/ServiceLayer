using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public abstract class ServiceResult<T> : IServiceResult<T>
    {
        protected ServiceResult(ServiceResultTypes resultType, T data = default(T), IEnumerable<string> errorMessages = null) : this(resultType, data, errorMessages?.ToArray())
        {
        }

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
            return serviceResult.ToGenericServiceResult<T>();
        }

        public static implicit operator ServiceResult(ServiceResult<T> serviceResult)
        {
            return serviceResult.ToNonGenericServiceResult();
        }

        public static implicit operator T(ServiceResult<T> serviceResult)
        {
            return serviceResult.Data; 
        }

        public static implicit operator ServiceResult<T>(T data)
        {
            return data.ToServiceResult();
        }

        public static ServiceResult<T> FromServiceResult(IServiceResult<T> serviceResult)
        {
            return serviceResult.ToServiceResult();
        }

        public static ServiceResult<T> FromServiceResult(IServiceResult serviceResult)
        {
            return serviceResult.ToServiceResult<T>();
        }

        public static ServiceResult<T> Create(ServiceResultTypes resultType, T data = default(T), params string[] errorMessages)
        {
            return new InternalServiceResult<T>(resultType, data, errorMessages);
        }
 
        public static ServiceResult<T> Create(ServiceResultTypes resultType, T data = default(T), IEnumerable<string> errorMessages = null)
        {
            return new InternalServiceResult<T>(resultType, data, errorMessages);
        }
    }
}