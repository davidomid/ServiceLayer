namespace ServiceLayer
{
    public class ConflictResult : ErrorResult
    {
        public ConflictResult(params string[] errorMessages) : base(ServiceResultTypes.Conflict, errorMessages)
        {
        }
    }
}