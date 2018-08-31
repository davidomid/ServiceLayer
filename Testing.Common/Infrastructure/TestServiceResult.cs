using ServiceLayer;

namespace Testing.Common.Infrastructure
{
    public sealed class TestServiceResult : ServiceResult
    {
        public TestServiceResult(ServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {
        }
    }
}
