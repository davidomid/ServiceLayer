using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.FailureResultFactory.Create
{
    public class WhenGivenCustomErrorType : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.FailureResultFactory _failureResultFactory =
            new ServiceLayer.Internal.Factories.FailureResultFactory();

        private readonly TestErrorType _errorDetails = new TestErrorType(); 

        private FailureResult<TestErrorType> _failureResult;

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _failureResult = _failureResultFactory.Create(_errorDetails); 
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _failureResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_Result_With_Given_ErrorDetails()
        {
            _failureResult.ErrorDetails.Should().BeSameAs(_errorDetails);
        }
    }
}
