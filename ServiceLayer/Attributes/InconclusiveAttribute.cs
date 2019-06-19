namespace ServiceLayer
{
    public class InconclusiveAttribute : ResultTypeAttribute
    {
        public InconclusiveAttribute() : base(ServiceResultTypes.Inconclusive)
        {
        }
    }
}
