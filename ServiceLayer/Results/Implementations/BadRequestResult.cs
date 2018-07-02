using ServiceLayer.Enums;

namespace ServiceLayer.Results.Implementations
{
    public class BadRequestResult : ServiceResult
    {
        public BadRequestResult(params string[] errorMessages) : base(ServiceResultTypes.BadRequest, errorMessages)
        {
        }
    }
}