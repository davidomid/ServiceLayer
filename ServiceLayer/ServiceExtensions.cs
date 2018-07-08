namespace ServiceLayer
{
    public static class ServiceExtensions
    {
        public static BadRequestResult BadRequest(this IService service, params string[] errorMessages)
        {
            return new BadRequestResult(errorMessages);
        }
        public static ConflictResult Conflict(this IService service, params string[] errorMessages)
        {
            return new ConflictResult(errorMessages);
        }
        public static ServiceErrorResult ServiceError(this IService service, params string[] errorMessages)
        {
            return new ServiceErrorResult(errorMessages);
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
            return data; 
        }
    }
}
