using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Extensions.ServiceExtensions.Failure
{
    public class WhenGivenCustomErrorType : UnitTestBase
    {
        private IService _service;
        private TestErrorType _errorDetails;
        private FailureResult _failureResult;
        private FailureResult _expectedResult;

        [Test]
        public void Should_Return_Expected_Result()
        {
            _failureResult.Should().Be(_expectedResult);
        }

        protected override void Act()
        {
            _failureResult = _service.Failure(_errorDetails); 
        }

        protected override void Arrange()
        {
            _service = new TestService();
            _errorDetails = new TestErrorType();
            _expectedResult = MockFailureResultFactory.Object.Create(_errorDetails);
        }
    }
}
