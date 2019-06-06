namespace ServiceLayer.Attributes
{
    public class SuccessAttribute : ResultTypeAttribute
    {
        public SuccessAttribute() : base(ServiceResultTypes.Success)
        {
        }
    }
}
