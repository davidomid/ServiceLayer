namespace ServiceLayer.Models
{
    public class InconclusiveResult : Result
    {
        public InconclusiveResult() : base(ServiceLayer.ResultType.Inconclusive)
        {
        }
    }
}
