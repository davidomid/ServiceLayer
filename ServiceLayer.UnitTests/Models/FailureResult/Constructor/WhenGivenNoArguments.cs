using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Models.FailureResult.Constructor
{
    public class WhenGivenNoArguments : UnitTestBase
    {
        private ServiceLayer.FailureResult _failureResult;

        [Test]
        public void Should_Have_Failure_ServiceResultType()
        {
            _failureResult.ResultType.Should().Be(ResultType.Failure);
        }

        [Test]
        public void Should_Have_ErrorDetails_Null()
        {
            _failureResult.ErrorDetails.Should().BeNull(); 
        }

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
           _failureResult = new ServiceLayer.FailureResult();
        }
    }
}
