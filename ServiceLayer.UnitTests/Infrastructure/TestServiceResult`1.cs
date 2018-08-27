namespace ServiceLayer.UnitTests.Infrastructure
{
    internal sealed class TestServiceResult<T> : ServiceResult<T>
    {
        public TestServiceResult(ServiceResultTypes resultType, T data = default(T), params string[] errorMessages) : base(resultType, data, errorMessages)
        {
        }
    }
}
