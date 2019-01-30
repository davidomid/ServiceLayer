namespace ServiceLayer.Core
{
    public static class ServiceExtensions
    {
        public static OkResult Ok(this IService service)
        {
            return new OkResult();
        }

        public static OkResult<TData> Ok<TData>(this IService service, TData data)
        {
            return new OkResult<TData>(data);
        }

        public static BadRequestResult BadRequest(this IService service, params string[] errorMessages)
        {
            return new BadRequestResult(errorMessages);
        }

        public static NotFoundResult NotFound(this IService service, params string[] errorMessages)
        {
            return new NotFoundResult(errorMessages);
        }

        public static ConflictResult Conflict(this IService service, params string[] errorMessages)
        {
            return new ConflictResult(errorMessages);
        }
    }
}
