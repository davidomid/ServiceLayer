namespace ServiceLayer
{
    public class OkResult<T> : ServiceResult<T>
    {
        public OkResult(T data) : base(ServiceResultTypes.Ok, data)
        {
        }
    }
}