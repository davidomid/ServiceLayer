using ServiceLayer.Internal;

namespace ServiceLayer
{
    public abstract class ServiceResult<T> : ServiceResult
    {
        protected ServiceResult(ServiceResultTypes resultType, T data = default(T), params string[] errorMessages) : base(resultType, errorMessages)
        {
            this.Data = data;
        }

        public T Data { get; }

        public static implicit operator ServiceResult<T>(BadRequestResult badRequestResult)
        {
            return badRequestResult.ToGenericServiceResult<T>();
        }
        public static implicit operator ServiceResult<T>(ConflictResult conflictResult)
        {
            return conflictResult.ToGenericServiceResult<T>();
        }
        public static implicit operator ServiceResult<T>(ErrorResult errorResult)
        {
            return errorResult.ToGenericServiceResult<T>();
        }
        public static implicit operator ServiceResult<T>(NotFoundResult notFoundResult)
        {
            return notFoundResult.ToGenericServiceResult<T>();
        }

        public static implicit operator T(ServiceResult<T> serviceResult)
        {
            return serviceResult.Data; 
        }

        public static implicit operator ServiceResult<T>(T data)
        {
            return data.ToServiceResult();
        }

        public static ServiceResult<T> Create(ServiceResultTypes resultType, T data = default(T), params string[] errorMessages)
        {
            return new InternalServiceResult<T>(resultType, data, errorMessages);
        }
    }
}