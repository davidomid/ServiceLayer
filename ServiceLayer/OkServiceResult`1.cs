namespace ServiceLayer
{
    public class OkServiceResult<T> : ServiceResult<T>
    {
        public OkServiceResult(T data) : base(ServiceResultTypes.Ok, data)
        {
        }
    }
}