namespace ServiceLayer.UnitTests.Infrastructure
{
    internal sealed class TestServiceResult : ServiceLayer.ServiceResult
    {
        public TestServiceResult(ServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {
        }
    }
}
