using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.FailureResult_1.Operators
{
    public class From_ErrorDetails : UnitTestBase
    {
        private readonly TestErrorType _testErrorType = new TestErrorType();
        private FailureResult<TestErrorType> _actualFailureResult;
        private FailureResult<TestErrorType> _expectedFailureResult;    

        protected override void Act()
        {
            _actualFailureResult = _testErrorType;
        }

        [Test]
        public void Should_Be_Expected_FailureResult()
        {
            _actualFailureResult.Should().Be(_expectedFailureResult);
        }

        protected override void Arrange()
        {
            _expectedFailureResult = MockFailureResultFactory.Object.Create(_testErrorType);
        }
    }
}
