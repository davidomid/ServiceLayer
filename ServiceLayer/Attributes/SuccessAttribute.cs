namespace ServiceLayer
{
    public class SuccessAttribute : ResultTypeAttribute
    {
        public SuccessAttribute() : base(ResultTypes.Success)
        {
        }
    }
}
