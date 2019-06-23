namespace ServiceLayer
{
    public class FailureAttribute : ResultTypeAttribute
    {
        public FailureAttribute() : base(ServiceLayer.ResultType.Failure)
        {
        }
    }
}
