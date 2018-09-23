using ServiceLayer;

namespace Testing.Common.Domain.TestClasses
{
    public sealed class TestServiceResult : ServiceResult
    {
        public TestServiceResult(ServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {
        }
    }
}
