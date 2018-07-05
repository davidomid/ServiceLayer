namespace ServiceLayer
{
    public class ConflictResult : ServiceResult
    {
        public ConflictResult(params string[] errorMessages) : base(ServiceResultTypes.Conflict, errorMessages)
        {
        }
    }
}