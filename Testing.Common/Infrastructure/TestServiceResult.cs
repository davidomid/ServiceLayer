using ServiceLayer;

namespace Testing.Common.Infrastructure
{
    internal sealed class TestServiceResult : ServiceResult
    {
        public TestServiceResult(ServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {
        }
    }
}
