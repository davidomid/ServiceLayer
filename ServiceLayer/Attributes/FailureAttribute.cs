namespace ServiceLayer.Attributes
{
    public class FailureAttribute : ResultTypeAttribute
    {
        public FailureAttribute() : base(ServiceResultTypes.Failure)
        {
        }
    }
}
