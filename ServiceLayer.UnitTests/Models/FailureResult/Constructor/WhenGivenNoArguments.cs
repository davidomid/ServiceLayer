using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Models.FailureResult.Constructor
{
    public class WhenGivenNoArguments : UnitTestBase
    {
        private ServiceLayer.FailureResult _failureResult;

        [Test]
        public void Should_Have_Failure_ResultType()
        {
            _failureResult.ResultType.Should().Be(ResultType.Failure);
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
