namespace ServiceLayer
{
    public static class ServiceExtensions
    {
        public static ServiceResult CreateServiceResult(this IService service, ServiceResultTypes resultType, params string[] errorMessages)
        {
            return ServiceResult.Create(resultType, errorMessages); 
        }

        public static ServiceResult<T> CreateServiceResult<T>(this IService service, ServiceResultTypes resultType, T data = default(T), params string[] errorMessages)
        {
            return ServiceResult<T>.Create(resultType, data, errorMessages);
        }

        public static BadRequestResult BadRequest(this IService service, params string[] errorMessages)
        {
            return new BadRequestResult(errorMessages);
        }
        public static ConflictResult Conflict(this IService service, params string[] errorMessages)
        {
            return new ConflictResult(errorMessages);
        }
        public static ErrorResult Error(this IService service, params string[] errorMessages)
        {
            return new ErrorResult(errorMessages);
        }
        public static NotFoundResult NotFound(this IService service, params string[] errorMessages)
        {
            return new NotFoundResult();
        }
        public static OkResult Ok(this IService service)
        {
            return new OkResult();
        }
        public static OkResult<T> Ok<T>(this IService service, T data)
        {
            return new OkResult<T>(data);
        }

        public static OkResult<T> Ok<T>(this IService<T> service, T data)
        {
            return new OkResult<T>(data);
        }
    }
}
