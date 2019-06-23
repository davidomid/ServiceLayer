namespace ServiceLayer
{
    public class InconclusiveAttribute : ResultTypeAttribute
    {
        public InconclusiveAttribute() : base(ResultTypes.Inconclusive)
        {
        }
    }
}
