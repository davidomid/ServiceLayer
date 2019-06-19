namespace ServiceLayer.Models
{
    public class InconclusiveResult : ServiceResult
    {
        public InconclusiveResult() : base(ServiceResultTypes.Inconclusive)
        {
        }
    }
}
