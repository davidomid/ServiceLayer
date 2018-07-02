using ServiceLayer.Enums;

namespace ServiceLayer.Results.Implementations
{
    public class ConflictResult : ServiceResult
    {
        public ConflictResult(params string[] errorMessages) : base(ServiceResultTypes.Conflict, errorMessages)
        {
        }
    }
}