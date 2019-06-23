namespace ServiceLayer
{
    public class SuccessAttribute : ResultTypeAttribute
    {
        public SuccessAttribute() : base(ServiceLayer.ResultType.Success)
        {
        }
    }
}
