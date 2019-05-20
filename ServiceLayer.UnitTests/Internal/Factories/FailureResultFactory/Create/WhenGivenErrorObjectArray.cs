using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.FailureResultFactory.Create
{
    public class WhenGivenErrorObjectArray : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.FailureResultFactory _failureResultFactory =
            new ServiceLayer.Internal.Factories.FailureResultFactory();

        private object[] _errorDetails; 

        private FailureResult _failureResult;

        protected override void Arrange()
        {
            _errorDetails = new[] {"test 123", 123, new object()};
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
