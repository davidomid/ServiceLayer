namespace ServiceLayer
{
    public class FailureAttribute : ResultTypeAttribute
    {
        public FailureAttribute() : base(ResultTypes.Failure)
        {
        }
    }
}
