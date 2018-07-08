namespace ServiceLayer.Internal
{
    internal sealed class InternalServiceResult<T> : ServiceResult<T>
    {
        public InternalServiceResult(ServiceResultTypes resultType, T data = default(T), params string[] errorMessages) : base(resultType, data, errorMessages)
        {
        }
    }
}
