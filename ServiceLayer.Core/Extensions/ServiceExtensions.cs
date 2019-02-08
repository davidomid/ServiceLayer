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

        public static BadRequestResult BadRequest(this IService service)
        {
            return service.BadRequest(null);
        }

        public static BadRequestResult BadRequest(this IService service, params object[] errorDetails)
        {
            return new BadRequestResult(errorDetails);
        }

        public static NotFoundResult NotFound(this IService service)
        {
            return service.NotFound(null);
        }

        public static NotFoundResult NotFound(this IService service, params object[] errorDetails)
        {
            return new NotFoundResult(errorDetails);
        }

        public static ConflictResult Conflict(this IService service)
        {
            return service.Conflict(null);
        }

        public static ConflictResult Conflict(this IService service, params object[] errorDetails)
        {
            return new ConflictResult(errorDetails);
        }
    }
}
