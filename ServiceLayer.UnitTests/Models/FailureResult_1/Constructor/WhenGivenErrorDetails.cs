using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.FailureResult_1.Constructor
{
    public class WhenGivenErrorDetails : UnitTestBase
    {
        private FailureResult<TestErrorType> _failureResult;
        private TestErrorType _errorDetails;

        [Test]
        public void Should_Have_Failure_ServiceResultType()
        {
            _failureResult.ResultType.Should().Be(ResultTypes.Failure);
        }

        [Test]
        public void Should_Have_ErrorDetails_Matching_Given_ErrorDetails()
        {
            _failureResult.ErrorDetails.Should().BeSameAs(_errorDetails);
        }

        protected override void Arrange()
        {
            _errorDetails = new TestErrorType();
        }

        protected override void Act()
        {
           _failureResult = new FailureResult<TestErrorType>(_errorDetails);
        }
    }
}
