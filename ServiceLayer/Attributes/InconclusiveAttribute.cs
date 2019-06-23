namespace ServiceLayer
{
    public class InconclusiveAttribute : ResultTypeAttribute
    {
        public InconclusiveAttribute() : base(ServiceLayer.ResultType.Inconclusive)
        {
        }
    }
}
