using ServiceLayer.Enums;

namespace ServiceLayer.Results.Implementations
{
    public class ErrorResult : ServiceResult
    {
        public ErrorResult(params string[] errorMessages) : base(ServiceResultTypes.Error, errorMessages)
        {
        }
    }
}