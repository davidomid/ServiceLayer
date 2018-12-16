using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.UnitTests.Models.FailureResult.Constructor
{
    public class WhenGivenNoArguments : UnitTestBase
    {
        private ServiceLayer.FailureResult _failureResult;

        [Test]
        public void Should_Have_Failure_ServiceResultType()
        {
            _failureResult.ResultType.Should().Be(ServiceResultTypes.Failure);
        }

        [Test]
        public void Should_Have_No_ErrorMessages()
        {
            _failureResult.ErrorMessages.Should().BeEmpty(); 
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
