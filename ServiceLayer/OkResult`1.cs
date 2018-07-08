namespace ServiceLayer
{
    public class OkResult<T> : ServiceResult<T>
    {
        public OkResult(T data) : base(ServiceResultTypes.Ok, data)
        {

        }

        public static implicit operator OkResult<T>(T data)
        {
            return new OkResult<T>(data);
        }
    }
}