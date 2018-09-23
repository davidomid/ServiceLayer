using ServiceLayer;

namespace Testing.Common.Domain.TestClasses
{
    public sealed class TestServiceResult<T> : ServiceResult<T>
    {
        public TestServiceResult(ServiceResultTypes resultType, T data = default(T), params string[] errorMessages) : base(resultType, data, errorMessages)
        {
        }
    }
}
